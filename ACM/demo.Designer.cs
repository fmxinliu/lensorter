namespace ACM
{
    partial class demo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadValue = new System.Windows.Forms.Button();
            this.btnLoadClass = new System.Windows.Forms.Button();
            this.btnLoadArray = new System.Windows.Forms.Button();
            this.btnSaveArray = new System.Windows.Forms.Button();
            this.btnSaveClass = new System.Windows.Forms.Button();
            this.btnSaveValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadValue
            // 
            this.btnLoadValue.Location = new System.Drawing.Point(56, 56);
            this.btnLoadValue.Name = "btnLoadValue";
            this.btnLoadValue.Size = new System.Drawing.Size(75, 23);
            this.btnLoadValue.TabIndex = 0;
            this.btnLoadValue.Text = "加载值";
            this.btnLoadValue.UseVisualStyleBackColor = true;
            this.btnLoadValue.Click += new System.EventHandler(this.btnLoadValue_Click);
            // 
            // btnLoadClass
            // 
            this.btnLoadClass.Location = new System.Drawing.Point(56, 148);
            this.btnLoadClass.Name = "btnLoadClass";
            this.btnLoadClass.Size = new System.Drawing.Size(75, 23);
            this.btnLoadClass.TabIndex = 1;
            this.btnLoadClass.Text = "加载类";
            this.btnLoadClass.UseVisualStyleBackColor = true;
            this.btnLoadClass.Click += new System.EventHandler(this.btnLoadClass_Click);
            // 
            // btnLoadArray
            // 
            this.btnLoadArray.Location = new System.Drawing.Point(56, 103);
            this.btnLoadArray.Name = "btnLoadArray";
            this.btnLoadArray.Size = new System.Drawing.Size(75, 23);
            this.btnLoadArray.TabIndex = 2;
            this.btnLoadArray.Text = "加载数组";
            this.btnLoadArray.UseVisualStyleBackColor = true;
            this.btnLoadArray.Click += new System.EventHandler(this.btnLoadArray_Click);
            // 
            // btnSaveArray
            // 
            this.btnSaveArray.Location = new System.Drawing.Point(157, 103);
            this.btnSaveArray.Name = "btnSaveArray";
            this.btnSaveArray.Size = new System.Drawing.Size(75, 23);
            this.btnSaveArray.TabIndex = 5;
            this.btnSaveArray.Text = "保存数组";
            this.btnSaveArray.UseVisualStyleBackColor = true;
            this.btnSaveArray.Click += new System.EventHandler(this.btnSaveArray_Click);
            // 
            // btnSaveClass
            // 
            this.btnSaveClass.Location = new System.Drawing.Point(157, 148);
            this.btnSaveClass.Name = "btnSaveClass";
            this.btnSaveClass.Size = new System.Drawing.Size(75, 23);
            this.btnSaveClass.TabIndex = 4;
            this.btnSaveClass.Text = "保存类";
            this.btnSaveClass.UseVisualStyleBackColor = true;
            this.btnSaveClass.Click += new System.EventHandler(this.btnSaveClass_Click);
            // 
            // btnSaveValue
            // 
            this.btnSaveValue.Location = new System.Drawing.Point(157, 56);
            this.btnSaveValue.Name = "btnSaveValue";
            this.btnSaveValue.Size = new System.Drawing.Size(75, 23);
            this.btnSaveValue.TabIndex = 3;
            this.btnSaveValue.Text = "保存值";
            this.btnSaveValue.UseVisualStyleBackColor = true;
            this.btnSaveValue.Click += new System.EventHandler(this.btnSaveValue_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.btnSaveArray);
            this.Controls.Add(this.btnSaveClass);
            this.Controls.Add(this.btnSaveValue);
            this.Controls.Add(this.btnLoadArray);
            this.Controls.Add(this.btnLoadClass);
            this.Controls.Add(this.btnLoadValue);
            this.Name = "Form1";
            this.Text = "SharpConfig";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadValue;
        private System.Windows.Forms.Button btnLoadClass;
        private System.Windows.Forms.Button btnLoadArray;
        private System.Windows.Forms.Button btnSaveArray;
        private System.Windows.Forms.Button btnSaveClass;
        private System.Windows.Forms.Button btnSaveValue;
    }
}

