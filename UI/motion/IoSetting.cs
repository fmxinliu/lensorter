using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI.motion
{
    public partial class IoSetting : Form
    {
        public IoSetting()
        {
            InitializeComponent();

            Image image = System.Drawing.Image.FromFile(@"C:\Users\xinliu\Desktop\led.png");
            Bitmap pbitmap = new Bitmap(image);
            pbitmap.MakeTransparent(Color.White);//当图片的背景为白色时

            led.Image = pbitmap;

            for (int i = 0; i < 16; i++)
            {
            }
        }

        private void led_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).FlatStyle = FlatStyle.Flat;
            (sender as Button).BackColor = SystemColors.Control;
        }
    }
}
