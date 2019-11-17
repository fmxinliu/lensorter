namespace UI.motion
{
    partial class Motion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTransport = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnFeedOne = new System.Windows.Forms.Button();
            this.btnThicknessMeasure = new System.Windows.Forms.Button();
            this.btnDegreeMeasure = new System.Windows.Forms.Button();
            this.btnPack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTransport
            // 
            this.btnTransport.Location = new System.Drawing.Point(78, 94);
            this.btnTransport.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransport.Name = "btnTransport";
            this.btnTransport.Size = new System.Drawing.Size(63, 27);
            this.btnTransport.TabIndex = 0;
            this.btnTransport.Text = "启动进料";
            this.btnTransport.UseVisualStyleBackColor = true;
            this.btnTransport.Click += new System.EventHandler(this.btnTransport_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(78, 38);
            this.btnInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(63, 27);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "打开";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnFeedOne
            // 
            this.btnFeedOne.Location = new System.Drawing.Point(78, 150);
            this.btnFeedOne.Margin = new System.Windows.Forms.Padding(2);
            this.btnFeedOne.Name = "btnFeedOne";
            this.btnFeedOne.Size = new System.Drawing.Size(63, 29);
            this.btnFeedOne.TabIndex = 2;
            this.btnFeedOne.Text = "FeedOne";
            this.btnFeedOne.UseVisualStyleBackColor = true;
            this.btnFeedOne.Click += new System.EventHandler(this.btnFeedOne_Click);
            // 
            // btnThicknessMeasure
            // 
            this.btnThicknessMeasure.Location = new System.Drawing.Point(78, 208);
            this.btnThicknessMeasure.Margin = new System.Windows.Forms.Padding(2);
            this.btnThicknessMeasure.Name = "btnThicknessMeasure";
            this.btnThicknessMeasure.Size = new System.Drawing.Size(63, 29);
            this.btnThicknessMeasure.TabIndex = 3;
            this.btnThicknessMeasure.Text = "测厚";
            this.btnThicknessMeasure.UseVisualStyleBackColor = true;
            this.btnThicknessMeasure.Click += new System.EventHandler(this.btnThicknessMeasure_Click);
            // 
            // btnDegreeMeasure
            // 
            this.btnDegreeMeasure.Location = new System.Drawing.Point(78, 260);
            this.btnDegreeMeasure.Margin = new System.Windows.Forms.Padding(2);
            this.btnDegreeMeasure.Name = "btnDegreeMeasure";
            this.btnDegreeMeasure.Size = new System.Drawing.Size(63, 29);
            this.btnDegreeMeasure.TabIndex = 4;
            this.btnDegreeMeasure.Text = "测度数";
            this.btnDegreeMeasure.UseVisualStyleBackColor = true;
            this.btnDegreeMeasure.Click += new System.EventHandler(this.btnDegreeMeasure_Click);
            // 
            // btnPack
            // 
            this.btnPack.Location = new System.Drawing.Point(78, 322);
            this.btnPack.Margin = new System.Windows.Forms.Padding(2);
            this.btnPack.Name = "btnPack";
            this.btnPack.Size = new System.Drawing.Size(63, 29);
            this.btnPack.TabIndex = 5;
            this.btnPack.Text = "装料";
            this.btnPack.UseVisualStyleBackColor = true;
            this.btnPack.Click += new System.EventHandler(this.btnPack_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(217, 38);
            this.btnHome.Margin = new System.Windows.Forms.Padding(2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(63, 27);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "复位";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // Motion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 477);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnPack);
            this.Controls.Add(this.btnDegreeMeasure);
            this.Controls.Add(this.btnThicknessMeasure);
            this.Controls.Add(this.btnFeedOne);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnTransport);
            this.Name = "Motion";
            this.Text = "MotionTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTransport;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnFeedOne;
        private System.Windows.Forms.Button btnThicknessMeasure;
        private System.Windows.Forms.Button btnDegreeMeasure;
        private System.Windows.Forms.Button btnPack;
        private System.Windows.Forms.Button btnHome;

    }
}