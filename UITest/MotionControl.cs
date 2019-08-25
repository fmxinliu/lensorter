using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MotionControl;
using SharpConfig;

namespace UITest
{
    public partial class MotionControl : Form
    {
        private DataTable dt = new DataTable();
        private readonly string path = Application.StartupPath + "\\motion.ini";
        //private List<ParaInfo> paras = new List<ParaInfo>();
        //private Configuration cfg = Configuration.LoadFromFile(Application.StartupPath + "\\motion.ini");
        //private GtsMotionProxy gts = new GtsMotionProxy();
        //private ParaInfo ui = new ParaInfo();
        public MotionControl()
        {
            InitializeComponent();
            //gts.print();
            //ui.Show();

            this.CancelButton = btnExit;

            LoadPara();
            //DataTable dt = new DataTable();
            //for (int i = 0; i < dgvTable.ColumnCount; i++)
            //{
            //    dt.Columns.Add(this.dgvTable.Columns[i].Name);
            //}

            //dt.Rows.Add("1", "GTS-400", "5000", "7000");
            //dt.Rows.Add("1", "GTS-400", "3000", "5600");
            //dt.Rows.Add("1", "GTS-400", "6000", "8600");
            //dt.Rows.Add("1", "GTS-400", "8000", "9000");
            //dt.Rows.Add("2", "GTS-800", "5000", "7000");
            //dt.Rows.Add("2", "GTS-800", "3000", "5600");
            //dt.Rows.Add("2", "GTS-800", "6000", "8600");
            //dt.Rows.Add("2", "GTS-800", "8000", "9000");
            //dt.Rows.Add("2", "GTS-800", "5000", "7000");
            //dt.Rows.Add("2", "GTS-800", "3000", "5600");
            //dt.Rows.Add("2", "GTS-800", "6000", "8600");
            //dt.Rows.Add("2", "GTS-800", "8000", "9000");

            //this.dgvTable.DataSource = LoadPara();
            //this.dgvTable.AddSpanHeader(6, 3, "手动");
            //this.dgvTable.AddSpanHeader(9, 3, "自动");
            //this.dgvTable.AddSpanHeader(12, 3, "复位");

            this.MinimumSize = new Size(1024, 600);
        }

        private void dgvTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 3)
            {
                if (dgvTable.CurrentCell is DataGridViewCheckBoxCell)
                {
                    dgvTable[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.White;
                }
                dgvTable[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }

        private void dgvTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvTable[e.ColumnIndex, e.RowIndex].ReadOnly = true;
            
            if (dgvTable.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvTable[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Empty;
            }
            dgvTable[e.ColumnIndex, e.RowIndex].Style.BackColor = dgvTable.RowTemplate.DefaultCellStyle.BackColor;
        }

        private void dgvTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 3)
            {
                dgvTable[e.ColumnIndex, e.RowIndex].ReadOnly = false;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex < 2)
            {
                OpenFileDialog ofg = new OpenFileDialog();
                ofg.Title = "请选择配置文件 " + ((e.RowIndex > 3) ? "[GTS-800]" : "[GTS-400]");
                ofg.Filter = "cfg files (*.cfg)|*.cfg|All files(*.*)|*.*";
                //ofg.InitialDirectory = Application.StartupPath;
                ofg.RestoreDirectory = true; // 记忆上次打开的目录
                ofg.Multiselect = false;
                if (DialogResult.OK == ofg.ShowDialog())
                {
                    TextBox tbxCfgPath = (e.RowIndex > 3) ? this.tbxCfg800 : this.tbxCfg400;
                    tbxCfgPath.Text = ofg.FileName;
                }
            }
        }

        private int row = -1; // 获得焦点的单元格所在的行
        private int col = -1; // 获得焦点的单元格所在的列
        private void dgvTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (row != e.RowIndex || col != e.ColumnIndex)
            {
                row = e.RowIndex; col = e.ColumnIndex; // 单元格获得焦点
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 3)
            {
                dgvTable[e.ColumnIndex, e.RowIndex].ReadOnly = false; // 使能编辑
            }

            //Console.WriteLine("row = {0}, col = {1}", row, col);
        }

        // 捕获获得焦点的单元格
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string keyString = keyData.ToString();

            // Tab 键
            if (keyString.Contains("Tab") && !keyString.Contains("Control"))
            {
                if (keyString.Contains("Shift"))
                {
                    if (col > 0)
                    {
                        col--; // 移动到上一列
                    }
                    else if (row > 0)
                    {
                        row--; col = dgvTable.ColumnCount - 1; // 移动到上一行末
                    }
                }
                else
                {
                    if (col < dgvTable.Columns.Count - 1)
                    {
                        col++; // 移动到下一列
                    }
                    else if (row < dgvTable.RowCount - 1)
                    {
                        row++; col = 0; // 移动到下一行首
                    }
                } 
            }

            // Enter 键
            if (keyString.Contains("Return") && !keyString.Contains("Control"))
            {
                row = (row < dgvTable.RowCount - 1) ? row + 1 : row; // 移动到下一行
            }

            // 方向键
            if (keyString.Contains("Up"))
            {
                row = (!keyString.Contains("Control") && row > 0) ? row - 1 : 0;
            }

            if (keyString.Contains("Down"))
            {
                row = (!keyString.Contains("Control") && row < dgvTable.RowCount - 1) ? row + 1 : dgvTable.RowCount - 1; 
            }

            if (keyString.Contains("Left"))
            {
                col = (!keyString.Contains("Control") && col > 0) ? col - 1 : 0; 
            }

            if (keyString.Contains("Right"))
            {
                col = (!keyString.Contains("Control") && col < dgvTable.ColumnCount - 1) ? col + 1 : dgvTable.ColumnCount - 1; 
            }
           
            //Console.WriteLine("==row = {0}, col = {1}", row, col);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MotionControl_SizeChanged(object sender, EventArgs e)
        {
            panel2.Size = new Size(this.Size.Width / 2 - 2, panel2.Size.Height);
            panel3.Size = new Size(this.Size.Width / 2 - 2, panel2.Size.Height);
            panel3.Location = new Point(panel2.Size.Width - 2, panel2.Location.Y);
        }

        private DataTable LoadPara()
        {
            dt = new DataTable();
            //DataTable dt = new DataTable();
            for (int i = 0; i < dgvTable.ColumnCount; i++)
            {
                dt.Columns.Add(this.dgvTable.Columns[i].Name);
            }

            Configuration cfg = Configuration.LoadFromFile(path);
            //List<ParaInfo> paras = new List<ParaInfo>();
            for (int i = 1; i <= 12; i++)
            {
                ParaInfo pi = cfg["A" + i].ToObject<ParaInfo>();
                //paras.Add(pi);
                dt.Rows.Add(pi.ToArray());
            }

            this.dgvTable.DataSource = dt;
            this.dgvTable.AddSpanHeader(6, 3, "手动");
            this.dgvTable.AddSpanHeader(9, 3, "自动");
            this.dgvTable.AddSpanHeader(12, 3, "复位");

            this.tbxCfg400.Text = cfg["Path"]["cfg400"].StringValue;
            this.tbxCfg800.Text = cfg["Path"]["cfg800"].StringValue;

            return dt;
        }

        private void SavePara()
        {
            Configuration cfg = new Configuration();

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    string s = dt.Rows[r][c].ToString();
                    cfg["A" + (r + 1)][dt.Columns[c].ColumnName].StringValue = dt.Rows[r][c].ToString();
                }
            }

            cfg["Path"]["cfg400"].StringValue = this.tbxCfg400.Text;
            cfg["Path"]["cfg800"].StringValue = this.tbxCfg800.Text;
            cfg.SaveToFile(path);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadPara();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePara();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
