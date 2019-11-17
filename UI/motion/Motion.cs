using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MC;

namespace UI.motion
{
    public partial class Motion : Form
    {
        //private IOControl iocontrol = new IOControl();
        //private Dictionary<Axis, ParaInfo> paraInfo;
        GTSMotionProxy gts400 = new GTSMotionProxy(Axis.GTS400, Axis.GTS400Total, 4);
        GTSMotionProxy gts800 = new GTSMotionProxy(Axis.GTS800, Axis.GTS800Total, 0);
        private bool feedOne = false;
        private bool feedStart = false;
        private bool feedSwitch = false;

        public Motion()
        {
            InitializeComponent();
            this.btnInit_Click(null, null);
        }

        private bool FeedOne
        {
            get
            {
                lock (this)
                {
                    return this.feedOne;
                }
            }

            set
            {
                lock (this)
                {
                    this.feedOne = value;
                }
            }
        }

        private bool FeedStart
        {
            get
            {
                lock (this)
                {
                    return this.feedStart;
                }
            }

            set
            {
                lock (this)
                {
                    this.feedStart = value;
                }
            }
        }

        private bool Open()
        {
            if (!(gts400.OpenCard() && gts400.LoadConfig("GTS400.cfg")))
            {
                MessageBox.Show("GTS400 Open Fail");
                return false;
            }

            if (!(gts800.OpenCard() && gts800.LoadConfig("GTS800.cfg")))
            {
                MessageBox.Show("GTS800 Open Fail");
                return false;
            }

            // 停止各轴
            gts400.Stop();
            gts800.Stop();
            return true;
        }

        private bool Close()
        {
            // 停止各轴
            gts400.Stop();
            gts800.Stop();
            this.FeedStart = false;
            return gts400.CloseCard() && gts800.CloseCard();
        }

        private void WaitFeed(int mdl1, int port1, int mdl2, int port2, int axis)
        {
            while (gts400.ReadDi(mdl1, port1))
            {
                if (gts400.ReadDi(mdl2, port2))
                {
                    gts400.Stop(axis);
                }
            }
        }

        private void Feed()
        {
            bool hasFindLens1 = gts400.ReadDi(3, 5);
            bool hasFindLens2 = gts400.ReadDi(3, 2);

            if (this.FeedOne)
            {
                if (hasFindLens1 && !hasFindLens2)
                {
                    feedSwitch = false;
                    gts400.JogMove(Axis.LensMoveX1, 5, 0.1, 0.1);
                    this.WaitFeed(3, 5, 3, 2, Axis.LensMoveX2); // 放皮带1镜片通过
                }
                else if (!hasFindLens1 && hasFindLens2)
                {
                    feedSwitch = true;
                    gts400.JogMove((int)Axis.LensMoveX2, 5, 0.1, 0.1);
                    this.WaitFeed(3, 2, 3, 5, Axis.LensMoveX1); // 放皮带2镜片通过
                }
                else if (hasFindLens1 && hasFindLens2)
                {
                    if (feedSwitch)
                    {
                        gts400.JogMove((int)Axis.LensMoveX1, 5, 0.1, 0.1);
                        this.WaitFeed(3, 5, 3, 2, Axis.LensMoveX2); // 放皮带1镜片通过
                    }
                    else
                    {
                        gts400.JogMove((int)Axis.LensMoveX2, 5, 0.1, 0.1);
                        this.WaitFeed(3, 2, 3, 5, Axis.LensMoveX1); // 放皮带2镜片通过
                    }

                    feedSwitch = !feedSwitch;
                }
                else
                {
                    gts400.JogMove((int)Axis.LensMoveX1, 5, 0.1, 0.1);
                    gts400.JogMove((int)Axis.LensMoveX2, 5, 0.1, 0.1);
                }

                this.FeedOne = !hasFindLens1 && !hasFindLens2;
            }
            else
            {
                // 1号光耦检测到料停止皮带1
                if (hasFindLens1)
                    gts400.Stop((int)Axis.LensMoveX1);
                else
                    gts400.JogMove((int)Axis.LensMoveX1, 5, 0.1, 0.1);

                // 2号光耦检测到料停止皮带2
                if (hasFindLens2)
                    gts400.Stop((int)Axis.LensMoveX2);
                else
                    gts400.JogMove((int)Axis.LensMoveX2, 5, 0.1, 0.1);
            }

            // 3,4号皮带一直转
            gts800.JogMove((int)Axis.LensMoveY3, 5, 0.1, 0.1);
            gts800.JogMove((int)Axis.LensMoveX4, 5, 0.1, 0.1);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (btnInit.Text == "打开")
            {
                if (this.Open())
                {
                    btnInit.Text = "关闭";

                     // #1
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        while (true)
                        {
                            if (this.FeedStart)
                            {
                                this.Feed();
                            }

                            Thread.Sleep(100);
                        }
                    });
                }
            }
            else if (this.Close())
            {
                btnInit.Text = "打开";
            }

            // #2
            ThreadPool.QueueUserWorkItem(o =>
            {
               
            });
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            this.FeedStart = true;
        }

        private void btnFeedOne_Click(object sender, EventArgs e)
        {
            // 降下挡料
            gts400.SetDo(0, 3, true);
            gts400.SetDo(0, 4, false);

            // 皮带5移动s1到厚度检测位
            gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, 8000);

            // 升起挡料
            gts400.SetDo(0, 3, false);
            gts400.SetDo(0, 4, true);

            this.FeedOne = true;
        }

        private void btnThicknessMeasure_Click(object sender, EventArgs e)
        {
            // 夹镜片
            gts400.SetDo(1, 11, true);

            // 测厚
            Thread.Sleep(2000);

            // 松镜片
            gts400.SetDo(1, 11, false);
        }

        private void btnDegreeMeasure_Click(object sender, EventArgs e)
        {
            // 皮带5移动s2到度数检测位
            gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 10, 0.5, 0.5, 7000);

            // 测量
            Thread.Sleep(2000);

            // 皮带6移动s3到装料位
            gts800.P2PMove(Axis.LensMoveX6, 10, 0.5, 0.5, 15000);
            gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 10, 0.5, 0.5, 12000);
            gts800.P2PMoveWaitFinished(Axis.LensMoveX6, 10, 0.5, 0.5, 35000);
        }

        private void btnPack_Click(object sender, EventArgs e)
        {
            // 顶料
            gts400.SetDo(0, 11, true);
            gts400.SetDo(0, 12, false);

            // 镜片旋转
            gts400.SetDo(0, 9, false);
            gts400.SetDo(0, 10, true);

            // 料袋上下缸
            gts800.SetDo(10, true);
            gts800.SetDo(11, false);

            // 料袋上下辅助缸
            gts800.SetDo(12, true);
            gts800.SetDo(13, false);

            // 料袋定位缸
            gts800.SetDo(8, true);
            gts800.SetDo(9, false);

            // 料袋衔接缸
            gts800.SetDo(14, false);
            gts800.SetDo(15, true);

            // 伸缩袋缸
            gts400.SetDo(0, 13, true);
            gts400.SetDo(0, 14, false);

            ///////////// 放袋子
            Thread.Sleep(1000);

            // 料袋衔接缸
            gts800.SetDo(14, true);
            gts800.SetDo(15, false);

            // 料袋定位缸
            gts800.SetDo(8, false);
            gts800.SetDo(9, true);

            // 伸缩袋缸
            gts400.SetDo(0, 13, false);
            gts400.SetDo(0, 14, true);

            // 料袋上下缸
            gts800.SetDo(10, false);
            gts800.SetDo(11, true);

            // 料袋上下辅助缸
            gts800.SetDo(12, false);
            gts800.SetDo(13, true);

            // 张开料袋
            gts400.SetDo(1, 4, true);
            gts400.SetDo(1, 5, false);

            // 料袋上下辅助缸
            gts800.SetDo(12, true);
            gts800.SetDo(13, false);

            // 顶镜片
            gts400.SetDo(0, 11, true);
            gts400.SetDo(0, 12, false);

            Thread.Sleep(1000);

            // 推镜片
            gts400.SetDo(1, 0, true);
            gts400.SetDo(1, 1, false); 

            // 收推杆
            gts400.SetDo(1, 0, false);
            gts400.SetDo(1, 1, true);

            // 降镜片
            gts400.SetDo(0, 11, false);
            gts400.SetDo(0, 12, true);

            Thread.Sleep(1000);

            // 停止吸气
            gts400.SetDo(1, 4, true);
            gts400.SetDo(1, 5, false);

            // 料袋上下缸
            gts800.SetDo(10, true);
            gts800.SetDo(11, false);

            // 镜片旋转
            gts400.SetDo(0, 9, false);
            gts400.SetDo(0, 10, true);

            // 料袋定位缸
            gts800.SetDo(8, true);
            gts800.SetDo(9, false);

            Thread.Sleep(1000);

            // 料袋衔接缸
            gts400.SetDo(14, true);
            gts400.SetDo(15, false);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //gts400.HomeInit();
            //gts400.ClearSts();
        }
    }
}
