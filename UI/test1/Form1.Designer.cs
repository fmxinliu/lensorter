namespace UITest
{
    partial class Form1
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
            this.cbxSelectCard = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.轴 = new System.Windows.Forms.Label();
            this.cbxSelectAxis = new System.Windows.Forms.ComboBox();
            this.btnJogP = new System.Windows.Forms.Button();
            this.btnJogN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAcc = new System.Windows.Forms.TextBox();
            this.tbxDec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxVel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxSelectCard
            // 
            this.cbxSelectCard.FormattingEnabled = true;
            this.cbxSelectCard.Items.AddRange(new object[] {
            "GTS-400",
            "GTS-800"});
            this.cbxSelectCard.Location = new System.Drawing.Point(331, 64);
            this.cbxSelectCard.Name = "cbxSelectCard";
            this.cbxSelectCard.Size = new System.Drawing.Size(121, 23);
            this.cbxSelectCard.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "卡";
            // 
            // 轴
            // 
            this.轴.AutoSize = true;
            this.轴.Location = new System.Drawing.Point(282, 118);
            this.轴.Name = "轴";
            this.轴.Size = new System.Drawing.Size(22, 15);
            this.轴.TabIndex = 5;
            this.轴.Text = "卡";
            // 
            // cbxSelectAxis
            // 
            this.cbxSelectAxis.FormattingEnabled = true;
            this.cbxSelectAxis.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbxSelectAxis.Location = new System.Drawing.Point(331, 114);
            this.cbxSelectAxis.Name = "cbxSelectAxis";
            this.cbxSelectAxis.Size = new System.Drawing.Size(121, 23);
            this.cbxSelectAxis.TabIndex = 4;
            // 
            // btnJogP
            // 
            this.btnJogP.Location = new System.Drawing.Point(568, 166);
            this.btnJogP.Name = "btnJogP";
            this.btnJogP.Size = new System.Drawing.Size(75, 23);
            this.btnJogP.TabIndex = 6;
            this.btnJogP.Text = "正向";
            this.btnJogP.UseVisualStyleBackColor = true;
            this.btnJogP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogP_MouseDown);
            this.btnJogP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogP_MouseUp);
            // 
            // btnJogN
            // 
            this.btnJogN.Location = new System.Drawing.Point(677, 166);
            this.btnJogN.Name = "btnJogN";
            this.btnJogN.Size = new System.Drawing.Size(75, 23);
            this.btnJogN.TabIndex = 7;
            this.btnJogN.Text = "反向";
            this.btnJogN.UseVisualStyleBackColor = true;
            this.btnJogN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogN_MouseDown);
            this.btnJogN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogN_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "加速度";
            // 
            // tbxAcc
            // 
            this.tbxAcc.Location = new System.Drawing.Point(352, 183);
            this.tbxAcc.Name = "tbxAcc";
            this.tbxAcc.Size = new System.Drawing.Size(100, 25);
            this.tbxAcc.TabIndex = 9;
            // 
            // tbxDec
            // 
            this.tbxDec.Location = new System.Drawing.Point(352, 227);
            this.tbxDec.Name = "tbxDec";
            this.tbxDec.Size = new System.Drawing.Size(100, 25);
            this.tbxDec.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "减速度";
            // 
            // tbxVel
            // 
            this.tbxVel.Location = new System.Drawing.Point(352, 271);
            this.tbxVel.Name = "tbxVel";
            this.tbxVel.Size = new System.Drawing.Size(100, 25);
            this.tbxVel.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "速度";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(568, 60);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 14;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(677, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 479);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbxVel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxDec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxAcc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnJogN);
            this.Controls.Add(this.btnJogP);
            this.Controls.Add(this.轴);
            this.Controls.Add(this.cbxSelectAxis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxSelectCard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.ComboBox cbxSelectCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 轴;
        private System.Windows.Forms.ComboBox cbxSelectAxis;
        private System.Windows.Forms.Button btnJogP;
        private System.Windows.Forms.Button btnJogN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxAcc;
        private System.Windows.Forms.TextBox tbxDec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxVel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
    }
}

