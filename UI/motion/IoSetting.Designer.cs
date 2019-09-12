namespace UI.motion
{
    partial class IoSetting
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
            this.led = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // led
            // 
            this.led.BackColor = System.Drawing.SystemColors.Control;
            this.led.FlatAppearance.BorderSize = 0;
            this.led.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.led.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.led.Location = new System.Drawing.Point(30, 50);
            this.led.Name = "led";
            this.led.Size = new System.Drawing.Size(237, 33);
            this.led.TabIndex = 0;
            this.led.Text = "button1";
            this.led.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.led.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.led.UseVisualStyleBackColor = false;
            this.led.MouseEnter += new System.EventHandler(this.led_MouseEnter);
            // 
            // IoSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1098, 641);
            this.Controls.Add(this.led);
            this.Name = "IoSetting";
            this.Text = "io配置";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button led;
    }
}