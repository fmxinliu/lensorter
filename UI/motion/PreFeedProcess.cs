using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    /// <summary>
    /// 备料一片
    /// </summary>
    public class PreFeedProcess : AbstractProcess
    {
        private ManualResetEventSlim prefeedEvent = new ManualResetEventSlim(); // 指示皮带3备料

        public PreFeedProcess(GTSMotionProxy gts400, GTSMotionProxy gts800) : base(gts400, gts800)
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
            this.prefeedEvent.Set();
        }

        private void Pass()
        {
            bool hasFindLens3 = this.gts400.ReadDi(3, 3);
            bool hasFindLens4 = this.gts400.ReadDi(3, 4);

            bool timeout = this.prefeedEvent.Wait(1000);
            if (timeout)
            {
                // 3号光耦检测到料停止皮带3
                if (hasFindLens3)
                    this.gts800.Stop(Axis.LensMoveY3);
                else
                    this.gts800.JogMove(Axis.LensMoveY3, 10, 0.1, 0.1);
            }
            else
            {
                if (hasFindLens3)
                {
                    this.gts800.JogMove(Axis.LensMoveY3, 10, 0.1, 0.1);
                    while (this.gts400.ReadDi(3, 3))
                    {
                        Thread.Sleep(10);
                        if (!this.prefeedEvent.IsSet)
                            break;
                    }
                    this.prefeedEvent.Reset();
                }
            }

            //if (!this.gts400.ReadDi(3, 3))
            //{
            //    this.FeedOne = true;
            //    while (!this.gts400.ReadDi(3, 3))
            //    {
            //        Thread.Sleep(10);
            //        if (!this.feedOpened)
            //            return;
            //    }
            //}
        }
    }
}
