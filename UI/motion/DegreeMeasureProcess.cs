using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    public class DegreeMeasureProcess : AbstractProcess
    {
        private ManualResetEventSlim degreeStartEvent = new ManualResetEventSlim(); // 指示度数测量
        private List<LenInfo> lens = new List<LenInfo>();

        public DegreeMeasureProcess(GTSMotionProxy gts400, GTSMotionProxy gts800): base(gts400, gts800)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    this.startEvent.Wait();
                    this.DegreeMeasure();
                }
             });
        }

        public void Do()
        {
            this.degreeStartEvent.Set();
        }

        private void DegreeMeasure()
        {
            this.degreeStartEvent.Wait();

            // 测量
            Thread.Sleep(2000);

            this.degreeStartEvent.Reset();
        }

        public bool IsDegreeOK()
        {
            return !this.degreeStartEvent.IsSet;
        }
    }
}
