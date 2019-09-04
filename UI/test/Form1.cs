using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UITest
{
    public partial class RowMergeView : Form
    {
        public RowMergeView()
        {
            InitializeComponent();
            this.CancelButton = this.button1;
            DataTable dt = new DataTable();
            for (int i = 0; i < rowMergeView1.ColumnCount; i++)
            {
                dt.Columns.Add(this.rowMergeView1.Columns[i].Name);
            }

            dt.Rows.Add("中国", "上海", "5000", "7000");
            dt.Rows.Add("中国", "北京", "3000", "5600");
            dt.Rows.Add("美国", "纽约", "6000", "8600");
            dt.Rows.Add("美国", "华劢顿", "8000", "9000");
            dt.Rows.Add("英国", "伦敦", "7000", "8800");
            this.rowMergeView1.DataSource = dt;
            this.rowMergeView1.ColumnHeadersHeight = 40;
            this.rowMergeView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rowMergeView1.AddSpanHeader(2, 2, "平均工资");

            /* Name 为 Column1 的 同名单元格合并 */
            this.rowMergeView1.MergeColumnNames.Add("Column1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}