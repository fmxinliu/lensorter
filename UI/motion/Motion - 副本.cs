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
        GTSMotionProxy gts400;
        GTSMotionProxy gts800;
        FeedOneProcess feedOneProcess;
        PassOneProcess passOneProcess;
        StepOneProcess stepOneProcess;
        DimMeasureProcess dimMeasureProcess;
        DegreeMeasureProcess degreeMeasureProcess;
        LenPackProcess lenPackProcess;

        private List<IODefine> ioList = new List<IODefine>();
        private List<LenInfo> lenList = new List<LenInfo>();
        private ManualResetEventSlim feedOneEvent = new ManualResetEventSlim(); // 指示皮带1、2进料
        private ManualResetEventSlim passOneEvent = new ManualResetEventSlim(); // 指示皮带3进料
        private ManualResetEventSlim stepOneEvent = new ManualResetEventSlim(); // 指示挡料开关可以进料
        private bool start = false;

        private bool Start
        {
            get
            {
                lock (this)
                {
                    return this.start;
                }
            }

            set
            {
                lock (this)
                {
                    this.start = value;
                }
            }
        }

        #region 
        private bool passOne = false;
        private bool feedOne = false;
        private bool feedStart = false;
        private bool feedSwitch = false;
        private bool feedOpened = false;
        private bool stepOne = false;
        private bool op1 = false;
        private bool op2 = false;
        #endregion

        public Motion()
        {
            InitializeComponent();
            //iocontrol.Show();
            //this.btnInit_Click(null, null);
            this.gts400 = new GTSMotionProxy(Axis.GTS400, Axis.GTS400Total, 4);
            this.gts800 = new GTSMotionProxy(Axis.GTS800, Axis.GTS800Total, 0);
            this.feedOneProcess = new FeedOneProcess(gts400, gts800);
            this.passOneProcess = new PassOneProcess(gts400, gts800);
            this.stepOneProcess = new StepOneProcess(gts400, gts800);
            this.dimMeasureProcess = new DimMeasureProcess(gts400, gts800);
            this.degreeMeasureProcess = new DegreeMeasureProcess(gts400, gts800);
            this.lenPackProcess = new LenPackProcess(gts400, gts800);
            
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (this.Start)
                        this.Process();
                    Thread.Sleep(100);
                }
            });

            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (this.Start)
                        this.Process();
                    Thread.Sleep(100);
                }
            });
        }

        private void Process()
        {
            if (this.IsOnposOp3())
            {
                this.lenPackProcess.Do(); // 启动打包
            }
            else if (!this.IsOnposOp1() && !this.IsOnposOp2())
            {
                bool hasFindLens3 = this.gts400.ReadDi(3, 3);
                bool hasFindLens4 = this.gts400.ReadDi(3, 4);

                //if (!this.gts400.ReadDi(3, 4)) // 如果挡料位没有料
                //{
                //    if (!this.gts400.ReadDi(3, 3)) // 如果备料位没有料
                //    {
                //        // 启动进料
                //        this.feedOneProcess.Do();
                //        // 等待备料位有料
                //        while (!this.gts400.ReadDi(3, 3))
                //            Thread.Sleep(10);
                //    }

                //    // 启动预进料
                //    this.prefeedProcess.Do();

                //    // 等待挡料位进料完成
                //    while (!this.gts400.ReadDi(3, 4))
                //        Thread.Sleep(10);
                //}

                //this.AddLen();
                //this.passOneProcess.Do(); // 开始进料
                
                //// 等待进料完成
                //while (this.gts400.ReadDi(3, 4))
                //    Thread.Sleep(1000);

                //// 继续备料一片
                //this.prefeedProcess.Do();
                //this.feedOneProcess.Do();
            }
            else if (this.IsReadyOp1() && this.IsReadyOp2())
            {
                if (this.IsOnposOp2())
                    this.stepOneProcess.MoveToPackpos();
                else
                    this.stepOneProcess.StepOne(); // 启动移动一位

                this.Step(); // 镜片队列中全部前移一位

                while (!this.stepOneProcess.IsDone())
                    Thread.Sleep(200);
            }
            else
            {
            }

            if (this.IsOnposOp1())
                this.dimMeasureProcess.Do();
            
            if (this.IsOnposOp2())
                this.degreeMeasureProcess.Do();
        }


        private void Step()
        {
            lock (this.lenList)
            {
                for (int i = 0; i < this.lenList.Count; i++)
                {
                    this.lenList[i].step++;
                }
            }
        }

        #region
        private bool Op1
        {
            get
            {
                lock (this)
                {
                    return this.op1;
                }
            }

            set
            {
                lock (this)
                {
                    this.op1 = value;
                }
            }
        }

        private bool Op2
        {
            get
            {
                lock (this)
                {
                    return this.op2;
                }
            }

            set
            {
                lock (this)
                {
                    this.op2 = value;
                }
            }
        }

        private bool StepOne
        {
            get
            {
                lock (this)
                {
                    return this.stepOne;
                }
            }

            set
            {
                lock (this)
                {
                    this.stepOne = value;
                }
            }
        }

        private bool PassOne
        {
            get
            {
                lock (this)
                {
                    return this.passOne;
                }
            }

            set
            {
                lock (this)
                {
                    this.passOne = value;
                }
            }
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

        public bool FeedOpened
        {
            get
            {
                lock (this)
                {
                    return this.feedOpened;
                }
            }

            set
            {
                lock (this)
                {
                    this.feedOpened = value;
                }
            }
        }
        #endregion

        private bool Open()
        {
            bool ret = true;
            if (ret && !(gts400.OpenCard() && gts400.LoadConfig("GTS400.cfg")))
            {
                MessageBox.Show("GTS400 Open Fail");
                ret = false;
            }

            if (ret && !(gts800.OpenCard() && gts800.LoadConfig("GTS800.cfg")))
            {
                MessageBox.Show("GTS800 Open Fail");
                ret = false;
            }

            this.FeedOpened = ret;
            return ret;
        }

        private new bool Close()
        {
            this.FeedStart = false;
            this.FeedOpened = false;
            return gts400.CloseCard() && gts800.CloseCard();
        }

        private void Step1()
        {
            if (this.StepOne && this.IsReadyOp1() && this.IsReadyOp2())
            {
                // 降下挡料
                gts400.SetDo(0, 3, true);
                gts400.SetDo(0, 4, false);

                Thread.Sleep(200);

                if (lenList.Count >= 3 && lenList[0].hasLen)
                    gts800.P2PMove(Axis.LensMoveX6, 10, 0.5, 0.5, 5555000);

                // 皮带5移动s1到厚度检测位
                gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, -3000);
                gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, 10000);

                // 升起挡料
                gts400.SetDo(0, 3, false);
                gts400.SetDo(0, 4, true);

                this.PassOne = true;

                this.AddLen();
                if (lenList.Count >= 4 && lenList[0].hasLen)
                {
                    gts800.P2PMoveWaitFinished(Axis.LensMoveX6, 10, 0.5, 0.5, 45000);
                    lenList.RemoveAt(0);
                }

                this.StepOne = false;
            }
        }
        
        private void Measure1()
        {
            if (this.IsOnposOp1())
            {
                // 夹镜片
                gts400.SetDo(1, 11, true);

                // 测厚
                Thread.Sleep(2000);

                // 松镜片
                gts400.SetDo(1, 11, false);

                this.SetReadyOp1();
            }
        }

        private void Measure2()
        {
            if (this.IsOnposOp2())
            {
                // 皮带5移动s2到度数检测位
                gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 10, 0.5, 0.5, 7000);

                // 测量
                Thread.Sleep(2000);

                this.SetReadyOp2();          

                // 皮带6移动s3到装料位
                gts800.P2PMove(Axis.LensMoveX6, 10, 0.5, 0.5, 15000);
                gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 10, 0.5, 0.5, 12000);
                gts800.P2PMoveWaitFinished(Axis.LensMoveX6, 10, 0.5, 0.5, 35000);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (btnInit.Text == "打开")
            {
                if (this.Open())
                {
                    btnInit.Text = "关闭";

                    // #1 ~ #6
                    this.feedOneProcess.Start();
                    this.passOneProcess.Start();
                    this.stepOneProcess.Start();
                    this.dimMeasureProcess.Start();
                    this.degreeMeasureProcess.Start();
                    this.Start = true;
                }
            }
            else if (this.Close())
            {
                btnInit.Text = "打开";
            }
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            this.FeedStart = this.FeedOpened;
        }

        private void btnFeedOne_Click(object sender, EventArgs e)
        {
            if (!this.StepOne)
                this.StepOne = true;
        }

        private void btnThicknessMeasure_Click(object sender, EventArgs e)
        {
        }

        private void btnDegreeMeasure_Click(object sender, EventArgs e)
        {
        }

        private void btnPack_Click(object sender, EventArgs e)
        {
           
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //gts400.HomeInit();
            //gts400.ClearSts();
        }

        private void AddLen()
        {
            LenInfo li = new LenInfo();
            li.hasLen = true;
            li.hasOK = false;
            li.step = 0;

            lock (this.lenList)
            {
                this.lenList.Add(li);

                for (int i = 0; i < this.lenList.Count; i++)
                {
                    this.lenList[i].step++;
                }
            }
        }

        private bool IsOnposOp1()
        {
            lock (this.lenList)
            {
                foreach (LenInfo li in this.lenList)
                {
                    if (li.step == 1 && !li.hasOK)
                        return true;
                }

                return false;
            }
        }

        private bool IsOnposOp2()
        {
            lock (this.lenList)
            {
                foreach (LenInfo li in this.lenList)
                {
                    if (li.step == 2 && !li.hasOK)
                        return true;
                }

                return false;
            }
        }

        private bool IsOnposOp3()
        {
            lock (this.lenList)
            {
                foreach (LenInfo li in this.lenList)
                {
                    if (li.step > 2 && li.hasOK)
                        return true;
                }

                return false;
            }
        }

        private bool IsReadyOp1()
        {
            lock (this.lenList)
            {
                foreach (LenInfo li in this.lenList)
                {
                    if (li.step == 1 && !li.hasOK)
                        return false;
                }

                return true;
            }
        }

        private bool IsReadyOp2()
        {
            lock (this.lenList)
            {
                foreach (LenInfo li in this.lenList)
                {
                    if (li.step == 2 && !li.hasOK)
                        return false;
                }

                return true;
            }
        }

        private void SetReadyOp1()
        {
            lock (this.lenList)
            {
                for (int i = 0; i < this.lenList.Count; i++)
                {
                    LenInfo li = this.lenList[i];
                    if (li.step == 1)
                    {
                        li.hasOK = true;
                        break;
                    }
                }
            }
        }

        private void SetReadyOp2()
        {
            lock (this.lenList)
            {
                for (int i = 0; i < this.lenList.Count; i++)
                {
                    LenInfo li = this.lenList[i];
                    if (li.step == 2)
                    {
                        li.hasOK = true;
                        break;
                    }
                }
            }
        }
    }

    public class LenInfo
    {
        public int step;
        public bool hasLen;
        public bool hasOK;
    }

    public class IODefine
    {
        public string Name;
        public int CardIdx;
        public int MdlIdx;
        public bool Value;
    }
}
