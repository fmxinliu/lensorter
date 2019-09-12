namespace UI.motion
{
    partial class AxisSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AxisSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxCfg400 = new System.Windows.Forms.TextBox();
            this.lblCfg400 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCfg800 = new System.Windows.Forms.Label();
            this.tbxCfg800 = new System.Windows.Forms.TextBox();
            this.dgvTable = new CCL.RowMergeView();
            this.CardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AxisPausePerMM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisJogAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisJogDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisJogVel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AixMoveAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisMoveDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisMoveVel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AxisResetMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AxisResetDir = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AxisResetSetZero = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Location = new System.Drawing.Point(892, 12);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 29);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 630);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1345, 54);
            this.panel1.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.Location = new System.Drawing.Point(324, 12);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 29);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(617, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tbxCfg400);
            this.panel2.Controls.Add(this.lblCfg400);
            this.panel2.Location = new System.Drawing.Point(1, 569);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 55);
            this.panel2.TabIndex = 2;
            // 
            // tbxCfg400
            // 
            this.tbxCfg400.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCfg400.Location = new System.Drawing.Point(116, 15);
            this.tbxCfg400.Name = "tbxCfg400";
            this.tbxCfg400.Size = new System.Drawing.Size(512, 25);
            this.tbxCfg400.TabIndex = 6;
            // 
            // lblCfg400
            // 
            this.lblCfg400.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCfg400.AutoSize = true;
            this.lblCfg400.Location = new System.Drawing.Point(28, 18);
            this.lblCfg400.Name = "lblCfg400";
            this.lblCfg400.Size = new System.Drawing.Size(63, 15);
            this.lblCfg400.TabIndex = 7;
            this.lblCfg400.Text = "GTS-400";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblCfg800);
            this.panel3.Controls.Add(this.tbxCfg800);
            this.panel3.Location = new System.Drawing.Point(668, 569);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(674, 55);
            this.panel3.TabIndex = 9;
            // 
            // lblCfg800
            // 
            this.lblCfg800.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCfg800.AutoSize = true;
            this.lblCfg800.Location = new System.Drawing.Point(31, 18);
            this.lblCfg800.Name = "lblCfg800";
            this.lblCfg800.Size = new System.Drawing.Size(63, 15);
            this.lblCfg800.TabIndex = 7;
            this.lblCfg800.Text = "GTS-800";
            // 
            // tbxCfg800
            // 
            this.tbxCfg800.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCfg800.Location = new System.Drawing.Point(116, 15);
            this.tbxCfg800.Name = "tbxCfg800";
            this.tbxCfg800.Size = new System.Drawing.Size(518, 25);
            this.tbxCfg800.TabIndex = 6;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.AllowUserToResizeRows = false;
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTable.ColumnHeadersHeight = 80;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardID,
            this.CardName,
            this.AxisID,
            this.AxisName,
            this.AxisEnable,
            this.AxisPausePerMM,
            this.AxisJogAcc,
            this.AxisJogDec,
            this.AxisJogVel,
            this.AixMoveAcc,
            this.AxisMoveDec,
            this.AxisMoveVel,
            this.AxisResetMode,
            this.AxisResetDir,
            this.AxisResetSetZero});
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTable.Location = new System.Drawing.Point(0, 0);
            this.dgvTable.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgvTable.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvTable.MergeColumnNames")));
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(216)))), ((int)(((byte)(245)))));
            this.dgvTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(255)))), ((int)(((byte)(189)))));
            this.dgvTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTable.RowTemplate.Height = 30;
            this.dgvTable.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvTable.Size = new System.Drawing.Size(1345, 630);
            this.dgvTable.TabIndex = 1;
            this.dgvTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTable_CellBeginEdit);
            this.dgvTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellEndEdit);
            this.dgvTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseClick);
            this.dgvTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDoubleClick);
            this.dgvTable.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTable_EditingControlShowing);
            // 
            // CardID
            // 
            this.CardID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CardID.DataPropertyName = "CardID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardID.DefaultCellStyle = dataGridViewCellStyle2;
            this.CardID.Frozen = true;
            this.CardID.HeaderText = "卡号";
            this.CardID.Name = "CardID";
            this.CardID.ReadOnly = true;
            this.CardID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CardID.ToolTipText = "运动卡在PC上的序号[1-?]";
            this.CardID.Width = 58;
            // 
            // CardName
            // 
            this.CardName.DataPropertyName = "CardName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardName.DefaultCellStyle = dataGridViewCellStyle3;
            this.CardName.HeaderText = "卡名";
            this.CardName.Name = "CardName";
            this.CardName.ReadOnly = true;
            this.CardName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CardName.Width = 80;
            // 
            // AxisID
            // 
            this.AxisID.DataPropertyName = "AxisID";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AxisID.DefaultCellStyle = dataGridViewCellStyle4;
            this.AxisID.HeaderText = "轴号";
            this.AxisID.Name = "AxisID";
            this.AxisID.ReadOnly = true;
            this.AxisID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AxisID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AxisID.ToolTipText = "运动卡对应的轴编号[1-4/8]";
            this.AxisID.Width = 80;
            // 
            // AxisName
            // 
            this.AxisName.DataPropertyName = "AxisName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AxisName.DefaultCellStyle = dataGridViewCellStyle5;
            this.AxisName.HeaderText = "轴名";
            this.AxisName.Name = "AxisName";
            this.AxisName.ReadOnly = true;
            this.AxisName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AxisName.Width = 80;
            // 
            // AxisEnable
            // 
            this.AxisEnable.DataPropertyName = "AxisEnable";
            this.AxisEnable.FalseValue = "False";
            this.AxisEnable.HeaderText = "使能";
            this.AxisEnable.Name = "AxisEnable";
            this.AxisEnable.ReadOnly = true;
            this.AxisEnable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AxisEnable.ToolTipText = "是否启用该轴";
            this.AxisEnable.TrueValue = "True";
            this.AxisEnable.Width = 60;
            // 
            // AxisPausePerMM
            // 
            this.AxisPausePerMM.DataPropertyName = "AxisPausePerMM";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AxisPausePerMM.DefaultCellStyle = dataGridViewCellStyle6;
            this.AxisPausePerMM.HeaderText = "脉冲比(p/mm)";
            this.AxisPausePerMM.Name = "AxisPausePerMM";
            this.AxisPausePerMM.ReadOnly = true;
            this.AxisPausePerMM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AxisPausePerMM.ToolTipText = "1mm对应的脉冲数";
            // 
            // AxisJogAcc
            // 
            this.AxisJogAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AxisJogAcc.DataPropertyName = "AxisJogAcc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = "0";
            this.AxisJogAcc.DefaultCellStyle = dataGridViewCellStyle7;
            this.AxisJogAcc.HeaderText = "加速度";
            this.AxisJogAcc.Name = "AxisJogAcc";
            this.AxisJogAcc.ReadOnly = true;
            this.AxisJogAcc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AxisJogDec
            // 
            this.AxisJogDec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AxisJogDec.DataPropertyName = "AxisJogDec";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "0";
            this.AxisJogDec.DefaultCellStyle = dataGridViewCellStyle8;
            this.AxisJogDec.HeaderText = "减速度";
            this.AxisJogDec.Name = "AxisJogDec";
            this.AxisJogDec.ReadOnly = true;
            this.AxisJogDec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AxisJogVel
            // 
            this.AxisJogVel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AxisJogVel.DataPropertyName = "AxisJogVel";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = "0";
            this.AxisJogVel.DefaultCellStyle = dataGridViewCellStyle9;
            this.AxisJogVel.HeaderText = "速度";
            this.AxisJogVel.Name = "AxisJogVel";
            this.AxisJogVel.ReadOnly = true;
            this.AxisJogVel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AixMoveAcc
            // 
            this.AixMoveAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AixMoveAcc.DataPropertyName = "AixMoveAcc";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = "0";
            this.AixMoveAcc.DefaultCellStyle = dataGridViewCellStyle10;
            this.AixMoveAcc.HeaderText = "加速度";
            this.AixMoveAcc.Name = "AixMoveAcc";
            this.AixMoveAcc.ReadOnly = true;
            this.AixMoveAcc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AxisMoveDec
            // 
            this.AxisMoveDec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AxisMoveDec.DataPropertyName = "AxisMoveDec";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.NullValue = "0";
            this.AxisMoveDec.DefaultCellStyle = dataGridViewCellStyle11;
            this.AxisMoveDec.HeaderText = "减速度";
            this.AxisMoveDec.Name = "AxisMoveDec";
            this.AxisMoveDec.ReadOnly = true;
            this.AxisMoveDec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AxisMoveVel
            // 
            this.AxisMoveVel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AxisMoveVel.DataPropertyName = "AxisMoveVel";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.NullValue = "0";
            this.AxisMoveVel.DefaultCellStyle = dataGridViewCellStyle12;
            this.AxisMoveVel.HeaderText = "速度";
            this.AxisMoveVel.Name = "AxisMoveVel";
            this.AxisMoveVel.ReadOnly = true;
            this.AxisMoveVel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AxisResetMode
            // 
            this.AxisResetMode.DataPropertyName = "AxisResetMode";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AxisResetMode.DefaultCellStyle = dataGridViewCellStyle13;
            this.AxisResetMode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.AxisResetMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AxisResetMode.HeaderText = "模式";
            this.AxisResetMode.Items.AddRange(new object[] {
            "Home",
            "Index"});
            this.AxisResetMode.Name = "AxisResetMode";
            this.AxisResetMode.ReadOnly = true;
            this.AxisResetMode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AxisResetMode.Width = 60;
            // 
            // AxisResetDir
            // 
            this.AxisResetDir.DataPropertyName = "AxisResetDir";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AxisResetDir.DefaultCellStyle = dataGridViewCellStyle14;
            this.AxisResetDir.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.AxisResetDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AxisResetDir.HeaderText = "方向";
            this.AxisResetDir.Items.AddRange(new object[] {
            "正向",
            "反向"});
            this.AxisResetDir.Name = "AxisResetDir";
            this.AxisResetDir.ReadOnly = true;
            this.AxisResetDir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AxisResetDir.Width = 60;
            // 
            // AxisResetSetZero
            // 
            this.AxisResetSetZero.DataPropertyName = "AxisResetSetZero";
            this.AxisResetSetZero.FalseValue = "False";
            this.AxisResetSetZero.HeaderText = "置零";
            this.AxisResetSetZero.Name = "AxisResetSetZero";
            this.AxisResetSetZero.ReadOnly = true;
            this.AxisResetSetZero.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AxisResetSetZero.TrueValue = "True";
            this.AxisResetSetZero.Width = 60;
            // 
            // AxisSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 684);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.panel1);
            this.Name = "AxisSetting";
            this.Text = "轴配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotionControl_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MotionControl_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private CCL.RowMergeView dgvTable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbxCfg400;
        private System.Windows.Forms.Label lblCfg400;
        private System.Windows.Forms.Label lblCfg800;
        private System.Windows.Forms.TextBox tbxCfg800;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AxisEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisPausePerMM;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisJogAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisJogDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisJogVel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AixMoveAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisMoveDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn AxisMoveVel;
        private System.Windows.Forms.DataGridViewComboBoxColumn AxisResetMode;
        private System.Windows.Forms.DataGridViewComboBoxColumn AxisResetDir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AxisResetSetZero;
    }
}

