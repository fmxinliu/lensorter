using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections.Specialized;
using MC;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.motion.Motion());
            //Application.Run(new MC.IOControl());
            //Application.Run(new UITest.RowMergeView());
        }
    }
}
