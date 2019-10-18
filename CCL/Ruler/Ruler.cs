using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CCL
{
    [ToolboxBitmap(typeof(Ruler), @"Ruler.Ruler.bmp")]
    public partial class Ruler : UserControl
    {
        public Ruler()
        {
            InitializeComponent();
        }

        private void Ruler_Paint(object sender, PaintEventArgs e)
        {
            // board.Location=new Point(scaleHeight,scaleHeight);
            Graphics g = e.Graphics;
            int width = this.Width;
            int height = 50;
            Font font = new Font("Arial", 7);

            //Draw X 
            for (int i = 0; i <= width; i++)
            {
                SizeF size = g.MeasureString(Convert.ToString(i / 10), font);
                int x = 5 + (int)(7 * i); //放大倍数
                Point start = new Point(x, 30);
                Point end = new Point(x, 30 - 5);
                if (i % 5 == 0)
                {
                    end = new Point(x, 30 - 10);
                }
                if (i % 10 == 0)
                {
                    end = new Point(x, 30 - 15);
                    g.DrawString(Convert.ToString(i / 10), font, Brushes.Blue, new PointF(x - size.Width / 2, 15 - size.Height));
                }
                g.DrawLine(Pens.Blue, start, end);
            }
        }
    }
}
