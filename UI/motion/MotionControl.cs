using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using MotionControl;
using SharpConfig;


namespace UI
{
    public partial class MotionControl : Form
    {
        private DataTable dt, rawdt;
        private readonly string path = Application.StartupPath + "\\motion.ini";
        public MotionControl()
        {
            InitializeComponent();

            LoadPara();
            this.CancelButton = btnExit;
            this.MinimumSize = new Size(1024, 600);
        }

        #region 单元格编辑
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

            if (tbxCellInput != null)
            {
                dgvTable[e.ColumnIndex, e.RowIndex].Value = tbxCellInput.Text;
                tbxCellInput = null;
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

            // Enter 键
            if (keyString.Contains("Return") && !keyString.Contains("Control"))
            {
                row = (row < dgvTable.RowCount - 1) ? row + 1 : row; // 移动到下一行
            }

            if (row >= 0 && col >= 0 && !dgvTable[col, row].IsInEditMode)
            {
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
            }

            //Console.WriteLine("==row = {0}, col = {1}", row, col);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private TextBox tbxCellInput;    // 定义输入框控件对象
        private void dgvTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // 只对TextBox类型的单元格进行验证
            if (e.Control is TextBox)
            {
                tbxCellInput = e.Control as TextBox;
            }

            if (e.Control.GetType().BaseType.Name == "TextBox")
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvTable_EditingControlKeyPress);
                e.Control.Leave += new EventHandler(dgvTable_EditingControlKeyLeave);
            }
        }

        private void dgvTable_EditingControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 3 || e.KeyChar == 22)
            {
                Console.Write((int)e.KeyChar);
            }
            else
            if (col <= 3)
            {
                int startpos = tbxCellInput.SelectionStart;
                int length = tbxCellInput.SelectionLength;

                string inputText = tbxCellInput.Text
                    .Remove(startpos, length)
                    .Insert(startpos, e.KeyChar.ToString());

                List<string> names = new List<string>();
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    if (r != row)
                    {
                        names.Add(dt.Rows[r][col].ToString()); // 除去正在编辑的对话框
                    }
                }

                e.Handled = names.Contains(inputText); // 轴名不能重复
            }
            else if (e.KeyChar != '\b' && e.KeyChar != '-' && e.KeyChar != '.' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                int startpos = tbxCellInput.SelectionStart;
                int length = tbxCellInput.SelectionLength;
                e.Handled = !(
                    (startpos == 0 && length != 0) ||
                     startpos == 0 && length == 0 && !tbxCellInput.Text.Contains("-"));
            }
            else
            {
                int startpos = tbxCellInput.SelectionStart;
                int length = tbxCellInput.SelectionLength;

                string inputText = tbxCellInput.Text
                    .Remove(startpos, length)
                    .Insert(startpos, e.KeyChar.ToString());
                inputText = inputText.StartsWith("-") ? inputText.Substring(1) : inputText;
                e.Handled = !(
                    Regex.IsMatch(inputText, @"^\d+(.\d*)?$") && !inputText.Contains("-"));
            }
        }

        private void dgvTable_EditingControlKeyLeave(object sender, EventArgs e)
        {
            if (col <= 3)
            {
                // 如果轴名为空，随机生成一个
                if (tbxCellInput.Text.Trim() == "")
                {
                    Random rd = new Random();
                    tbxCellInput.Text = "A" + rd.Next(0, 999);
                }

                return;
            }
            
            if (tbxCellInput.Text.EndsWith("."))
            {
                tbxCellInput.Text = tbxCellInput.Text.Replace(".", "");
            }

            long value;
            string inputText = tbxCellInput.Text;
            if (string.Empty == inputText || "-" == inputText || "-0" == inputText || !long.TryParse(inputText, out value))
            {
                tbxCellInput.Text = "0";
            }
        }
        #endregion

        #region 缩放
        private void MotionControl_SizeChanged(object sender, EventArgs e)
        {
            panel2.Size = new Size(this.Width / 2 - 2, panel2.Height);
            panel3.Size = new Size(this.Width / 2 - 2, panel2.Height);
            panel3.Location = new Point(panel2.Width - 2, panel2.Location.Y);
            btnReset.Location = new Point(this.Width / 4, btnReset.Location.Y);
            btnExit.Location = new Point(this.Width - this.Size.Width / 4 - btnExit.Width, btnExit.Location.Y);
        }
        #endregion

        #region 设置
        private DataTable LoadPara()
        {
            dt = new DataTable();
            for (int i = 0; i < dgvTable.ColumnCount; i++)
            {
                dt.Columns.Add(this.dgvTable.Columns[i].Name);
            }

            Configuration cfg = Configuration.LoadFromFile(path);
            for (int i = 1; i <= 12; i++)
            {
                ParaInfo pi = cfg["A" + i].ToObject<ParaInfo>();
                dt.Rows.Add(pi.ToArray());
            }

            this.dgvTable.DataSource = dt;
            this.dgvTable.AddSpanHeader(6, 3, "手动");
            this.dgvTable.AddSpanHeader(9, 3, "自动");
            this.dgvTable.AddSpanHeader(12, 3, "复位");

            this.tbxCfg400.Text = cfg["Path"]["cfg400"].StringValue;
            this.tbxCfg800.Text = cfg["Path"]["cfg800"].StringValue;

            rawdt = dt.Copy();

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

            rawdt = dt.Copy();
        }

        private bool HasRawData()
        {
            bool bRaw = false;
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    string x = rawdt.Rows[r][c].ToString();
                    string y = dt.Rows[r][c].ToString();
                    if (x != y)
                    {
                        bRaw = true;
                        break;
                    }
                }
            }

            return bRaw;
        }

        private void SaveParaPrompt()
        {
            if (HasRawData() && DialogResult.Yes == MessageBox.Show("是否保存修改", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                SavePara();
            }
            else
            {
                rawdt = dt;
            }
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
            SaveParaPrompt();
            this.Close();
        }

        private void MotionControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveParaPrompt();
        }
        #endregion
    }
}
