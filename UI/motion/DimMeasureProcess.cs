using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MC;

namespace UI.motion
{
    /// <summary>
    /// 尺寸测量
    /// </summary>
    public class DimMeasureProcess : AbstractProcess
    {
        private ManualResetEventSlim dimStartEvent = new ManualResetEventSlim(); // 指示厚度测量
        private List<LenInfo> lens = new List<LenInfo>();

        public DimMeasureProcess(GTSMotionProxy gts400, GTSMotionProxy gts800): base(gts400, gts800)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    this.startEvent.Wait();
                    this.DimMeasure();
                }
            });
        }

        public void Do()
        {
            this.dimStartEvent.Set();
        }

        public void DimMeasure()
        {
            this.dimStartEvent.Wait();

            // 夹镜片
            this.gts400.SetDo(1, 11, true);

            // 测厚
            Thread.Sleep(2000);

            // 松镜片
            this.gts400.SetDo(1, 11, false);

            this.dimStartEvent.Reset();
        }

        public bool IsDimOK()
        {
            return !this.dimStartEvent.IsSet;
        }
    }
}
