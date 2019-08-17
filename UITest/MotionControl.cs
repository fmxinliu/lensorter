using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MotionControl;

namespace UITest
{
    public partial class MotionControl : Form
    {
        private GtsMotion gts = new GtsMotion();

        public MotionControl()
        {
            InitializeComponent();
            gts.print();
        }
    }
}
