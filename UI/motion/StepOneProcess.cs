using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    /// <summary>
    /// 步进一位
    /// </summary>
    public class StepOneProcess : AbstractProcess
    {
        private ManualResetEventSlim stepEvent = new ManualResetEventSlim(); // 指示皮带1、2进料一片
        private List<LenInfo> lens = new List<LenInfo>();
        private bool moveToPackingpos = false;

        public StepOneProcess(GTSMotionProxy gts400, GTSMotionProxy gts800): base(gts400, gts800)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    this.startEvent.Wait();
                    this.Step();
                }
            });
        }

        public void StepOne()
        {
            this.moveToPackingpos = false;
            this.stepEvent.Set();
        }

        public void MoveToPackpos()
        {
            this.moveToPackingpos = true;
            this.stepEvent.Set();
        }

        public override bool IsDone()
        {
            return !this.stepEvent.IsSet;
        }

        //private void Step()
        //{
        //    this.stepEvent.Wait();

        //    // 皮带5移动s1到厚度检测位
        //    this.gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, 7000);

        //    this.stepEvent.Reset();
        //}

        //private void Step()
        //{
        //    this.stepEvent.Wait();

        //    if (this.lens.Count >= 3 && this.lens[0].hasLen)
        //        this.gts800.P2PMove(Axis.LensMoveX6, 10, 0.5, 0.5, 5555000);

        //    this.gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, 10000);

        //    if (this.lens.Count >= 4 && this.lens[0].hasLen)
        //    {
        //        this.gts800.P2PMoveWaitFinished(Axis.LensMoveX6, 10, 0.5, 0.5, 45000);
        //        this.lens.RemoveAt(0);
        //    }

        //    this.stepEvent.Reset();
        //}

        private void Step()
        {
            this.stepEvent.Wait();
 
            // 皮带6先动
            if (this.moveToPackingpos)
                this.gts800.P2PMove(Axis.LensMoveX6, 10, 0.5, 0.5, 5555000);

            // 皮带5移动一位，让镜片顺利移到皮带6上
            this.gts800.P2PMoveWaitFinished(Axis.LensMoveX5, 5, 0.5, 0.5, 7000);

            // 将镜片移动到装料位
            if (this.moveToPackingpos)
                this.gts800.P2PMoveWaitFinished(Axis.LensMoveX6, 10, 0.5, 0.5, 45000);

            this.stepEvent.Reset();
        }
    }
}
