using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    public class LenPackProcess : AbstractProcess
    {
        private ManualResetEventSlim packEvent = new ManualResetEventSlim(); // 指示挡料开关进料一片

        public LenPackProcess(GTSMotionProxy gts400, GTSMotionProxy gts800) : base(gts400, gts800)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    this.startEvent.Wait();
                    this.Paking();
                }
            });
        }

        public void Do()
        {
            this.packEvent.Set();
        }

        private void Paking()
        {
            this.packEvent.Wait();

            // 停止吸气
            this.gts400.SetDo(1, 4, false);
            this.gts400.SetDo(1, 5, true);

            // 顶料
            this.gts400.SetDo(0, 11, true);
            this.gts400.SetDo(0, 12, false);

            // 镜片旋转
            this.gts400.SetDo(0, 9, false);
            this.gts400.SetDo(0, 10, true);

            // 料袋上下缸
            this.gts800.SetDo(10, true);
            this.gts800.SetDo(11, false);

            // 料袋上下辅助缸
            this.gts800.SetDo(12, true);
            this.gts800.SetDo(13, false);

            // 料袋定位缸
            this.gts800.SetDo(8, true);
            this.gts800.SetDo(9, false);


            // 料袋衔接缸
            this.gts800.SetDo(14, true);
            this.gts800.SetDo(15, false);

            // 伸缩袋缸
            this.gts400.SetDo(0, 13, true);
            this.gts400.SetDo(0, 14, false);

            ///////////// 放袋子
            Thread.Sleep(1000);

            // 检测到袋子已落下  === 信号
            // 料袋定位缸
            this.gts800.SetDo(8, false);
            this.gts800.SetDo(9, true);

            Thread.Sleep(500); //////// 定位

            // 料袋定位缸
            this.gts800.SetDo(8, true);
            this.gts800.SetDo(9, false);

            // 伸缩袋缸
            this.gts400.SetDo(0, 13, false);
            this.gts400.SetDo(0, 14, true);

            Thread.Sleep(500);

            // 料袋上下缸
            this.gts800.SetDo(10, false);
            this.gts800.SetDo(11, true);

            ///// LOOP
            // 料袋上下辅助缸
            this.gts800.SetDo(12, false);
            this.gts800.SetDo(13, true);

            // 张开料袋
            this.gts400.SetDo(1, 4, true);
            this.gts400.SetDo(1, 5, false);

            Thread.Sleep(1000);

            // 料袋上下辅助缸
            this.gts800.SetDo(12, true);
            this.gts800.SetDo(13, false);

            Thread.Sleep(1000);

            //////// ///// 压力表到位，放倒

            // 料袋衔接缸
            this.gts800.SetDo(14, false);
            this.gts800.SetDo(15, true);

            // 顶镜片
            this.gts400.SetDo(0, 11, true);
            this.gts400.SetDo(0, 12, false);

            Thread.Sleep(1000);

            // 推镜片
            this.gts400.SetDo(1, 0, true);
            this.gts400.SetDo(1, 1, false);
            Thread.Sleep(1000);

            // 收推杆
            this.gts400.SetDo(1, 0, false);
            this.gts400.SetDo(1, 1, true);
            Thread.Sleep(1000);

            // 降镜片
            this.gts400.SetDo(0, 11, false);
            this.gts400.SetDo(0, 12, true);

            Thread.Sleep(1000);

            // 停止吸气
            this.gts400.SetDo(1, 4, false);
            this.gts400.SetDo(1, 5, true);

            // 料袋上下缸
            this.gts800.SetDo(10, true);
            this.gts800.SetDo(11, false);

            // 料袋衔接缸
            this.gts800.SetDo(14, true);
            this.gts800.SetDo(15, false);

            // 镜片旋转
            this.gts400.SetDo(0, 9, true);
            this.gts400.SetDo(0, 10, false);

            this.packEvent.Reset();
        }

        public bool IsPacked()
        {
            return !this.packEvent.IsSet;
        }
    }
}
