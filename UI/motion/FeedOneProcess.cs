using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    /// <summary>
    /// 进样备料
    /// </summary>
    public class FeedOneProcess : AbstractProcess
    {
        private bool feedSwitch = false; // 指示皮带1、2交替进料
        private ManualResetEventSlim feedEvent = new ManualResetEventSlim(); // 指示进料
        private ManualResetEventSlim prefeedEvent = new ManualResetEventSlim(); // 指示皮带1、2进料一片

        public FeedOneProcess(GTSMotionProxy gts400, GTSMotionProxy gts800)
            : base(gts400, gts800)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    this.startEvent.Wait();
                    this.Feed();
                }
            });

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
            this.feedEvent.Set();
        }

        public override bool IsDone()
        {
            return !this.feedEvent.IsSet;
        }

        private void Feed()
        {
            bool hasFindLens1 = this.gts400.ReadDi(3, 5);
            bool hasFindLens2 = this.gts400.ReadDi(3, 2);
            bool hasFindLens3 = this.gts400.ReadDi(3, 3);

            bool timeout = !this.prefeedEvent.Wait(50);
            if (timeout)
            {
                // 1号光耦检测到料停止皮带1
                if (hasFindLens1)
                    this.gts400.Stop(Axis.LensMoveX1);
                else
                    this.gts400.JogMove(Axis.LensMoveX1, 10, 0.1, 0.1);

                // 2号光耦检测到料停止皮带2
                if (hasFindLens2)
                    this.gts400.Stop(Axis.LensMoveX2);
                else
                    this.gts400.JogMove(Axis.LensMoveX2, 10, 0.1, 0.1);
            }
            else
            {
                if (hasFindLens1 && !hasFindLens2)
                {
                    feedSwitch = false;
                    this.gts400.JogMove(Axis.LensMoveX1, 10, 0.1, 0.1);
                    this.WaitFeed(3, 5, 3, 2, Axis.LensMoveX2); // 放皮带1镜片通过
                }
                else if (!hasFindLens1 && hasFindLens2)
                {
                    feedSwitch = true;
                    this.gts400.JogMove((int)Axis.LensMoveX2, 10, 0.1, 0.1);
                    this.WaitFeed(3, 2, 3, 5, Axis.LensMoveX1); // 放皮带2镜片通过
                }
                else if (hasFindLens1 && hasFindLens2)
                {
                    if (feedSwitch)
                    {
                        this.gts400.JogMove(Axis.LensMoveX1, 10, 0.1, 0.1);
                        this.WaitFeed(3, 5, 3, 2, Axis.LensMoveX2); // 放皮带1镜片通过
                    }
                    else
                    {
                        this.gts400.JogMove(Axis.LensMoveX2, 10, 0.1, 0.1);
                        this.WaitFeed(3, 2, 3, 5, Axis.LensMoveX1); // 放皮带2镜片通过
                    }

                    feedSwitch = !feedSwitch;
                }
                else
                {
                    this.gts400.JogMove(Axis.LensMoveX1, 10, 0.1, 0.1);
                    this.gts400.JogMove(Axis.LensMoveX2, 10, 0.1, 0.1);
                }

                if (hasFindLens1 || hasFindLens2)
                {
                    this.prefeedEvent.Reset(); // 进料一片OK
                }
            }

            // 4号皮带一直转
            this.gts800.JogMove(Axis.LensMoveX4, 10, 0.1, 0.1);
        }

        private void WaitFeed(int mdl1, int port1, int mdl2, int port2, int axis)
        {
            while (this.gts400.ReadDi(mdl1, port1))
            {
                if (this.gts400.ReadDi(mdl2, port2))
                    this.gts400.Stop(axis);
                if (!this.startEvent.IsSet)
                    break;
                Thread.Sleep(10);
            }
        }

        private void Pass()
        {
            bool hasFindLens3 = this.gts400.ReadDi(3, 3);
            bool hasFindLens4 = this.gts400.ReadDi(3, 4);

            bool timeout = !this.feedEvent.Wait(10);
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
                        if (!this.feedEvent.IsSet)
                            break;
                    }
                    this.feedEvent.Reset();
                }
                else
                {
                    this.gts800.JogMove(Axis.LensMoveY3, 10, 0.1, 0.1);
                }
            }

            if (!this.gts400.ReadDi(3, 3))
            {
                this.prefeedEvent.Set();
                while (!this.gts400.ReadDi(3, 3))
                {
                    Thread.Sleep(1);
                    
                    if (!this.gts400.ReadDi(3, 3))
                        this.gts800.JogMove(Axis.LensMoveY3, 10, 0.1, 0.1);

                    if (!this.startEvent.IsSet)
                        break;
                }
            }
        }
    }
}
