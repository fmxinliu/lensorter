using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    public abstract class AbstractProcess
    {
        protected GTSMotionProxy gts400;
        protected GTSMotionProxy gts800;
        protected ManualResetEventSlim startEvent; // 指示线程开始

        public AbstractProcess(GTSMotionProxy gts400, GTSMotionProxy gts800)
        {
            this.gts400 = gts400;
            this.gts800 = gts800;
            this.startEvent = new ManualResetEventSlim();
        }

        public virtual void Start()
        {
            this.startEvent.Set();
        }

        public virtual void Stop()
        {
            this.startEvent.Reset();
        }
    }
}
