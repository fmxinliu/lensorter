using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    /// <summary>
    /// 进料一片
    /// </summary>
    public class PassOneProcess : AbstractProcess
    {
        private ManualResetEventSlim passEvent = new ManualResetEventSlim(); // 指示挡料开关进料

        public PassOneProcess(GTSMotionProxy gts400, GTSMotionProxy gts800) : base(gts400, gts800)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    this.startEvent.Wait();
                    this.Pass();
                }
            });
        }

        public void Do()
        {
            this.passEvent.Set();
        }

        private void Pass()
        {
            this.passEvent.Wait();

            //bool hasFindLens4 = this.gts400.ReadDi(3, 4);
            //while (!hasFindLens4)
            //{
            //    Thread.Sleep(1000);
            //    if (!this.startEvent.IsSet)
            //    {
            //        this.passEvent.Reset();
            //        return;
            //    }
            //}

            // 降下挡料
            this.gts400.SetDo(0, 3, true);
            this.gts400.SetDo(0, 4, false);
            Thread.Sleep(200);
            
            // 皮带5移动s1到厚度检测位
            this.gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, -3000);
            this.gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, 10000);

            // 升起挡料
            this.gts400.SetDo(0, 3, false);
            this.gts400.SetDo(0, 4, true);

            this.passEvent.Reset();
        }
    }
}
