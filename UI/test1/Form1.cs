using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            MotionControl c = new MotionControl();
            c.ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnJogP_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnJogP_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btnJogN_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnJogN_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}