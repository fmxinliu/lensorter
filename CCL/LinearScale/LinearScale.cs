using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCL
{
    [ToolboxBitmap(typeof(LinearScale), @"LinearScale.LinearScale.bmp")]
    public partial class LinearScale : UserControl
    {
        private int originLocation = 30; //坐标原地起始位置
        private int maxScaleX = 1000; //X轴最大刻度
        private int maxScaleY = 1000; //Y轴最大刻度
        private float scaling = 1.0F; //缩放比例
        private int offSetX = 0; //X轴偏移位置
        private int offSetY = 0; //Y轴偏移位置
        private Font font = new Font("Arial", 6); //刻度值显示字体
        private Bitmap bit;
        private TextureBrush textureBrush;
        int x = 0;
        int y = 0;
        bool showRec = false;

        public LinearScale()
        {
            InitializeComponent();
            bit = new Bitmap((int)(LinearScale.MonitorDPI / 25.4 * 1 * scaling) - offSetX, (int)(LinearScale.MonitorDPI / 25.4 * 1 * scaling) - offSetX);
            Graphics gh = Graphics.FromImage(bit);
            gh.Clear(this.BackColor);
            gh.DrawRectangle(Pens.Green, new Rectangle(0, 0, (int)(LinearScale.MonitorDPI / 25.4 * 1 * scaling) - offSetX, (int)(LinearScale.MonitorDPI / 25.4 * 1 * scaling) - offSetX));
            gh.Dispose();
            textureBrush = new TextureBrush(bit);//使用TextureBrush可以有效减少窗体拉伸时的闪烁    
        }

        private void LinearScale_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.Black, new Rectangle(30, 30, (int)(Settings.MonitorDPI / 25.4 * 1 * scaling) - offSetX,(int)(Settings.MonitorDPI / 25.4 * 1 * scaling) - offSetX));
            int widthInmm = maxScaleX;
            int heightInmm = maxScaleY;

            // 绘制X轴            
            for (int i = 0; i <= widthInmm; i++)
            {
                SizeF size = g.MeasureString(Convert.ToString(i), font);
                float x = originLocation + (float)(LinearScale.MonitorDPI / 25.4 * i * scaling) - offSetX;
                //float x = originLocation +i - offSetX;
                if (x >= originLocation)
                {
                    PointF start = new PointF(x, originLocation);
                    PointF end = new PointF(x, originLocation * 3 / 4);
                    if (i % 5 == 0)
                    {
                        end = new PointF(x, originLocation / 2);
                    }
                    if (i % 10 == 0)
                    {
                        end = new PointF(x, 3);
                        g.DrawString(Convert.ToString(i), font, Brushes.Black, new PointF(x, 0));
                    }
                    g.DrawLine(Pens.Black, start, end);
                }
            }
            g.DrawLine(Pens.Black, new PointF(originLocation, originLocation), new PointF(this.Width, originLocation));

            // 绘制Y轴
            for (int i = 0; i <= heightInmm; i++)
            {
                SizeF size = g.MeasureString(Convert.ToString(i), font);
                float y = originLocation + (float)(LinearScale.MonitorDPI / 25.4 * i * scaling) - offSetY;
                //Settings.MonitorDPI为一常量，在另外一个类中赋值。                

                if (y >= originLocation)
                {
                    PointF start = new PointF(originLocation, y);
                    PointF end = new PointF(originLocation * 3 / 4, y);
                    if (i % 5 == 0)
                    {
                        end = new PointF(originLocation / 2, y);
                    }
                    if (i % 10 == 0)
                    {
                        end = new PointF(3, y);
                        g.DrawString(Convert.ToString(i), font, Brushes.Black, new PointF(0, y));
                    }
                    g.DrawLine(Pens.Black, start, end);
                }
            }
            g.DrawLine(Pens.Black, new PointF(originLocation, originLocation), new PointF(originLocation, this.Height));
            g.FillRectangle(textureBrush, new Rectangle(originLocation + (int)(LinearScale.MonitorDPI / 25.4 * 1 * scaling) - offSetX, originLocation + (int)(LinearScale.MonitorDPI / 25.4 * 1 * scaling) - offSetX, maxScaleX - originLocation, maxScaleY - originLocation));
            if (showRec)
            {
                g.DrawRectangle(Pens.White, new Rectangle(x * 10, y * 10, 10, 10));
            }
        }

        public void OffSet(int offSetX, int offSetY)
        {
            this.offSetX = offSetX;
            this.offSetY = offSetY;
            this.Refresh();
        }

        #region Scaling
        public float Scaling
        {
            get
            {
                return scaling;
            }
            set
            {
                scaling = value;
                Refresh();
            }
        }
        #endregion

        #region OffSet
        public int OffSetX
        {
            get
            {
                return offSetX;
            }
            set
            {
                offSetX = value;
                Refresh();
            }
        }

        public int OffSetY
        {
            get
            {
                return offSetY;
            }
            set
            {
                offSetY = value;
                Refresh();
            }
        }
        #endregion

        public static int MonitorDPI
        {
            get
            {
                return 100;
            }
        }
    }
}
