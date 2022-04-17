namespace SapflowApplication
{
    partial class frmValveControlSetup
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValveControlSetup));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabValveControl = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.cbLockSetup = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btLoad = new ReaLTaiizor.Controls.MaterialButton();
			this.btSave = new ReaLTaiizor.Controls.MaterialButton();
			this.lbResultText = new ReaLTaiizor.Controls.MaterialLabel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.btCancel = new ReaLTaiizor.Controls.MaterialButton();
			this.btConfirm = new ReaLTaiizor.Controls.MaterialButton();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label7 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label8 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label9 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label10 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label11 = new ReaLTaiizor.Controls.MaterialLabel();
			this.tbGraphMin = new ReaLTaiizor.Controls.MaterialTextBox();
			this.tbGraphMax = new ReaLTaiizor.Controls.MaterialTextBox();
			this.tbVCMin = new ReaLTaiizor.Controls.MaterialTextBox();
			this.tbVCMax = new ReaLTaiizor.Controls.MaterialTextBox();
			this.tbVCRatio = new ReaLTaiizor.Controls.MaterialTextBox();
			this.cbEnableGraphMin = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.cbEnableGraphMax = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.cbEnableVCMin = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.cbEnableVCMax = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.cbEnableVCRatio = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.label3 = new ReaLTaiizor.Controls.MaterialLabel();
			this.tbConstraint = new ReaLTaiizor.Controls.MaterialTextBox();
			this.cbEnableVCConstraint = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.btDefault = new ReaLTaiizor.Controls.MaterialButton();
			this.lbenabl = new ReaLTaiizor.Controls.MaterialLabel();
			this.cbEnableFlag = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.label2 = new ReaLTaiizor.Controls.MaterialLabel();
			this.cbModuleNumber = new ReaLTaiizor.Controls.MaterialComboBox();
			this.label1 = new ReaLTaiizor.Controls.MaterialLabel();
			this.cbChannelNumber = new ReaLTaiizor.Controls.MaterialComboBox();
			this.cbEnableEnable = new ReaLTaiizor.Controls.MaterialCheckBox();
			this.label4 = new ReaLTaiizor.Controls.MaterialLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabValveControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(949, 423);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabValveControl);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(943, 279);
			this.tabControl1.TabIndex = 0;
			// 
			// tabValveControl
			// 
			this.tabValveControl.Controls.Add(this.dataGridView1);
			this.tabValveControl.Location = new System.Drawing.Point(4, 22);
			this.tabValveControl.Name = "tabValveControl";
			this.tabValveControl.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabValveControl.Size = new System.Drawing.Size(935, 253);
			this.tabValveControl.TabIndex = 1;
			this.tabValveControl.Text = "Valve Control";
			this.tabValveControl.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(929, 247);
			this.dataGridView1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage1.Size = new System.Drawing.Size(936, 252);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Reseved";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
			this.tableLayoutPanel2.Controls.Add(this.cbLockSetup, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.lbResultText, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 3, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 386);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(943, 34);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// cbLockSetup
			// 
			this.cbLockSetup.AutoSize = true;
			this.cbLockSetup.Depth = 0;
			this.cbLockSetup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbLockSetup.Location = new System.Drawing.Point(0, 0);
			this.cbLockSetup.Margin = new System.Windows.Forms.Padding(0);
			this.cbLockSetup.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbLockSetup.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbLockSetup.Name = "cbLockSetup";
			this.cbLockSetup.Ripple = true;
			this.cbLockSetup.Size = new System.Drawing.Size(94, 34);
			this.cbLockSetup.TabIndex = 0;
			this.cbLockSetup.Text = "Lock Setup";
			this.cbLockSetup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbLockSetup.UseVisualStyleBackColor = true;
			this.cbLockSetup.CheckedChanged += new System.EventHandler(this.cbLockSetup_CheckedChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btLoad);
			this.flowLayoutPanel1.Controls.Add(this.btSave);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(97, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 28);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// btLoad
			// 
			this.btLoad.AutoSize = false;
			this.btLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btLoad.Depth = 0;
			this.btLoad.DrawShadows = true;
			this.btLoad.HighEmphasis = true;
			this.btLoad.Icon = null;
			this.btLoad.Location = new System.Drawing.Point(3, 3);
			this.btLoad.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(75, 23);
			this.btLoad.TabIndex = 0;
			this.btLoad.Text = "Load";
			this.btLoad.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btLoad.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btLoad.UseAccentColor = false;
			this.btLoad.UseVisualStyleBackColor = true;
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// btSave
			// 
			this.btSave.AutoSize = false;
			this.btSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btSave.Depth = 0;
			this.btSave.DrawShadows = true;
			this.btSave.HighEmphasis = true;
			this.btSave.Icon = null;
			this.btSave.Location = new System.Drawing.Point(84, 3);
			this.btSave.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 23);
			this.btSave.TabIndex = 1;
			this.btSave.Text = "Save";
			this.btSave.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btSave.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btSave.UseAccentColor = false;
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// lbResultText
			// 
			this.lbResultText.AutoSize = true;
			this.lbResultText.Depth = 0;
			this.lbResultText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbResultText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbResultText.Location = new System.Drawing.Point(347, 0);
			this.lbResultText.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.lbResultText.Name = "lbResultText";
			this.lbResultText.Size = new System.Drawing.Size(423, 34);
			this.lbResultText.TabIndex = 2;
			this.lbResultText.Text = "Ready";
			this.lbResultText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.btCancel);
			this.flowLayoutPanel2.Controls.Add(this.btConfirm);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(776, 3);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(164, 28);
			this.flowLayoutPanel2.TabIndex = 2;
			// 
			// btCancel
			// 
			this.btCancel.AutoSize = false;
			this.btCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btCancel.Depth = 0;
			this.btCancel.DrawShadows = true;
			this.btCancel.HighEmphasis = true;
			this.btCancel.Icon = null;
			this.btCancel.Location = new System.Drawing.Point(86, 3);
			this.btCancel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			this.btCancel.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btCancel.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btCancel.UseAccentColor = false;
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btConfirm
			// 
			this.btConfirm.AutoSize = false;
			this.btConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btConfirm.Depth = 0;
			this.btConfirm.DrawShadows = true;
			this.btConfirm.HighEmphasis = true;
			this.btConfirm.Icon = null;
			this.btConfirm.Location = new System.Drawing.Point(5, 3);
			this.btConfirm.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btConfirm.Name = "btConfirm";
			this.btConfirm.Size = new System.Drawing.Size(75, 23);
			this.btConfirm.TabIndex = 0;
			this.btConfirm.Text = "Confirm";
			this.btConfirm.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btConfirm.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btConfirm.UseAccentColor = false;
			this.btConfirm.UseVisualStyleBackColor = true;
			this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 10;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel4.Controls.Add(this.label6, 3, 0);
			this.tableLayoutPanel4.Controls.Add(this.label7, 4, 0);
			this.tableLayoutPanel4.Controls.Add(this.label8, 5, 0);
			this.tableLayoutPanel4.Controls.Add(this.label9, 6, 0);
			this.tableLayoutPanel4.Controls.Add(this.label10, 8, 0);
			this.tableLayoutPanel4.Controls.Add(this.label11, 9, 0);
			this.tableLayoutPanel4.Controls.Add(this.tbGraphMin, 3, 1);
			this.tableLayoutPanel4.Controls.Add(this.tbGraphMax, 4, 1);
			this.tableLayoutPanel4.Controls.Add(this.tbVCMin, 5, 1);
			this.tableLayoutPanel4.Controls.Add(this.tbVCMax, 6, 1);
			this.tableLayoutPanel4.Controls.Add(this.tbVCRatio, 8, 1);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableGraphMin, 3, 2);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableGraphMax, 4, 2);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableVCMin, 5, 2);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableVCMax, 6, 2);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableVCRatio, 8, 2);
			this.tableLayoutPanel4.Controls.Add(this.label3, 7, 0);
			this.tableLayoutPanel4.Controls.Add(this.tbConstraint, 7, 1);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableVCConstraint, 7, 2);
			this.tableLayoutPanel4.Controls.Add(this.btDefault, 9, 1);
			this.tableLayoutPanel4.Controls.Add(this.lbenabl, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableFlag, 2, 1);
			this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.cbModuleNumber, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.cbChannelNumber, 1, 1);
			this.tableLayoutPanel4.Controls.Add(this.cbEnableEnable, 2, 2);
			this.tableLayoutPanel4.Controls.Add(this.label4, 1, 2);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 288);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(943, 92);
			this.tableLayoutPanel4.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Depth = 0;
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label6.Location = new System.Drawing.Point(285, 0);
			this.label6.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 30);
			this.label6.TabIndex = 0;
			this.label6.Text = "Graph Min.";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Depth = 0;
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label7.Location = new System.Drawing.Point(379, 0);
			this.label7.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 30);
			this.label7.TabIndex = 0;
			this.label7.Text = "Graph Max.";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Depth = 0;
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label8.Location = new System.Drawing.Point(473, 0);
			this.label8.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 30);
			this.label8.TabIndex = 0;
			this.label8.Text = "VC Min.";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Depth = 0;
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label9.Location = new System.Drawing.Point(567, 0);
			this.label9.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 30);
			this.label9.TabIndex = 0;
			this.label9.Text = "VC Max.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Depth = 0;
			this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label10.Location = new System.Drawing.Point(755, 0);
			this.label10.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 30);
			this.label10.TabIndex = 0;
			this.label10.Text = "Ratio(%)";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Depth = 0;
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label11.Location = new System.Drawing.Point(849, 0);
			this.label11.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(91, 30);
			this.label11.TabIndex = 0;
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbGraphMin
			// 
			this.tbGraphMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbGraphMin.Depth = 0;
			this.tbGraphMin.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbGraphMin.Location = new System.Drawing.Point(285, 33);
			this.tbGraphMin.MaxLength = 50;
			this.tbGraphMin.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.tbGraphMin.Multiline = false;
			this.tbGraphMin.Name = "tbGraphMin";
			this.tbGraphMin.Size = new System.Drawing.Size(79, 36);
			this.tbGraphMin.TabIndex = 4;
			this.tbGraphMin.Text = "";
			this.tbGraphMin.UseTallSize = false;
			// 
			// tbGraphMax
			// 
			this.tbGraphMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbGraphMax.Depth = 0;
			this.tbGraphMax.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbGraphMax.Location = new System.Drawing.Point(379, 33);
			this.tbGraphMax.MaxLength = 50;
			this.tbGraphMax.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.tbGraphMax.Multiline = false;
			this.tbGraphMax.Name = "tbGraphMax";
			this.tbGraphMax.Size = new System.Drawing.Size(79, 36);
			this.tbGraphMax.TabIndex = 4;
			this.tbGraphMax.Text = "";
			this.tbGraphMax.UseTallSize = false;
			// 
			// tbVCMin
			// 
			this.tbVCMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbVCMin.Depth = 0;
			this.tbVCMin.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbVCMin.Location = new System.Drawing.Point(473, 33);
			this.tbVCMin.MaxLength = 50;
			this.tbVCMin.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.tbVCMin.Multiline = false;
			this.tbVCMin.Name = "tbVCMin";
			this.tbVCMin.Size = new System.Drawing.Size(79, 36);
			this.tbVCMin.TabIndex = 4;
			this.tbVCMin.Text = "";
			this.tbVCMin.UseTallSize = false;
			// 
			// tbVCMax
			// 
			this.tbVCMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbVCMax.Depth = 0;
			this.tbVCMax.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbVCMax.Location = new System.Drawing.Point(567, 33);
			this.tbVCMax.MaxLength = 50;
			this.tbVCMax.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.tbVCMax.Multiline = false;
			this.tbVCMax.Name = "tbVCMax";
			this.tbVCMax.Size = new System.Drawing.Size(79, 36);
			this.tbVCMax.TabIndex = 4;
			this.tbVCMax.Text = "";
			this.tbVCMax.UseTallSize = false;
			// 
			// tbVCRatio
			// 
			this.tbVCRatio.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbVCRatio.Depth = 0;
			this.tbVCRatio.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbVCRatio.Location = new System.Drawing.Point(755, 33);
			this.tbVCRatio.MaxLength = 50;
			this.tbVCRatio.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.tbVCRatio.Multiline = false;
			this.tbVCRatio.Name = "tbVCRatio";
			this.tbVCRatio.Size = new System.Drawing.Size(79, 36);
			this.tbVCRatio.TabIndex = 4;
			this.tbVCRatio.Text = "";
			this.tbVCRatio.UseTallSize = false;
			// 
			// cbEnableGraphMin
			// 
			this.cbEnableGraphMin.AutoSize = true;
			this.cbEnableGraphMin.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMin.Depth = 0;
			this.cbEnableGraphMin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableGraphMin.Location = new System.Drawing.Point(282, 60);
			this.cbEnableGraphMin.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableGraphMin.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableGraphMin.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableGraphMin.Name = "cbEnableGraphMin";
			this.cbEnableGraphMin.Ripple = true;
			this.cbEnableGraphMin.Size = new System.Drawing.Size(94, 32);
			this.cbEnableGraphMin.TabIndex = 5;
			this.cbEnableGraphMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMin.UseVisualStyleBackColor = true;
			// 
			// cbEnableGraphMax
			// 
			this.cbEnableGraphMax.AutoSize = true;
			this.cbEnableGraphMax.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMax.Depth = 0;
			this.cbEnableGraphMax.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableGraphMax.Location = new System.Drawing.Point(376, 60);
			this.cbEnableGraphMax.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableGraphMax.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableGraphMax.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableGraphMax.Name = "cbEnableGraphMax";
			this.cbEnableGraphMax.Ripple = true;
			this.cbEnableGraphMax.Size = new System.Drawing.Size(94, 32);
			this.cbEnableGraphMax.TabIndex = 5;
			this.cbEnableGraphMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMax.UseVisualStyleBackColor = true;
			// 
			// cbEnableVCMin
			// 
			this.cbEnableVCMin.AutoSize = true;
			this.cbEnableVCMin.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMin.Depth = 0;
			this.cbEnableVCMin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCMin.Location = new System.Drawing.Point(470, 60);
			this.cbEnableVCMin.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableVCMin.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableVCMin.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableVCMin.Name = "cbEnableVCMin";
			this.cbEnableVCMin.Ripple = true;
			this.cbEnableVCMin.Size = new System.Drawing.Size(94, 32);
			this.cbEnableVCMin.TabIndex = 5;
			this.cbEnableVCMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMin.UseVisualStyleBackColor = true;
			// 
			// cbEnableVCMax
			// 
			this.cbEnableVCMax.AutoSize = true;
			this.cbEnableVCMax.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMax.Depth = 0;
			this.cbEnableVCMax.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCMax.Location = new System.Drawing.Point(564, 60);
			this.cbEnableVCMax.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableVCMax.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableVCMax.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableVCMax.Name = "cbEnableVCMax";
			this.cbEnableVCMax.Ripple = true;
			this.cbEnableVCMax.Size = new System.Drawing.Size(94, 32);
			this.cbEnableVCMax.TabIndex = 5;
			this.cbEnableVCMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMax.UseVisualStyleBackColor = true;
			// 
			// cbEnableVCRatio
			// 
			this.cbEnableVCRatio.AutoSize = true;
			this.cbEnableVCRatio.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCRatio.Depth = 0;
			this.cbEnableVCRatio.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCRatio.Location = new System.Drawing.Point(752, 60);
			this.cbEnableVCRatio.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableVCRatio.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableVCRatio.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableVCRatio.Name = "cbEnableVCRatio";
			this.cbEnableVCRatio.Ripple = true;
			this.cbEnableVCRatio.Size = new System.Drawing.Size(94, 32);
			this.cbEnableVCRatio.TabIndex = 5;
			this.cbEnableVCRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCRatio.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Depth = 0;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.Location = new System.Drawing.Point(661, 0);
			this.label3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 30);
			this.label3.TabIndex = 6;
			this.label3.Text = "Constraint";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbConstraint
			// 
			this.tbConstraint.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbConstraint.Depth = 0;
			this.tbConstraint.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbConstraint.Location = new System.Drawing.Point(661, 33);
			this.tbConstraint.MaxLength = 50;
			this.tbConstraint.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.tbConstraint.Multiline = false;
			this.tbConstraint.Name = "tbConstraint";
			this.tbConstraint.Size = new System.Drawing.Size(79, 36);
			this.tbConstraint.TabIndex = 4;
			this.tbConstraint.Text = "";
			this.tbConstraint.UseTallSize = false;
			// 
			// cbEnableVCConstraint
			// 
			this.cbEnableVCConstraint.AutoSize = true;
			this.cbEnableVCConstraint.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCConstraint.Depth = 0;
			this.cbEnableVCConstraint.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCConstraint.Location = new System.Drawing.Point(658, 60);
			this.cbEnableVCConstraint.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableVCConstraint.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableVCConstraint.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableVCConstraint.Name = "cbEnableVCConstraint";
			this.cbEnableVCConstraint.Ripple = true;
			this.cbEnableVCConstraint.Size = new System.Drawing.Size(94, 32);
			this.cbEnableVCConstraint.TabIndex = 7;
			this.cbEnableVCConstraint.UseVisualStyleBackColor = true;
			// 
			// btDefault
			// 
			this.btDefault.AutoSize = false;
			this.btDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btDefault.Depth = 0;
			this.btDefault.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btDefault.DrawShadows = true;
			this.btDefault.HighEmphasis = true;
			this.btDefault.Icon = null;
			this.btDefault.Location = new System.Drawing.Point(849, 33);
			this.btDefault.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btDefault.Name = "btDefault";
			this.btDefault.Size = new System.Drawing.Size(91, 24);
			this.btDefault.TabIndex = 0;
			this.btDefault.Text = "Set";
			this.btDefault.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btDefault.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btDefault.UseAccentColor = false;
			this.btDefault.UseVisualStyleBackColor = true;
			this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
			// 
			// lbenabl
			// 
			this.lbenabl.AutoSize = true;
			this.lbenabl.Depth = 0;
			this.lbenabl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbenabl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbenabl.Location = new System.Drawing.Point(191, 0);
			this.lbenabl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.lbenabl.Name = "lbenabl";
			this.lbenabl.Size = new System.Drawing.Size(88, 30);
			this.lbenabl.TabIndex = 0;
			this.lbenabl.Text = "Enable";
			this.lbenabl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbEnableFlag
			// 
			this.cbEnableFlag.AutoSize = true;
			this.cbEnableFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableFlag.Depth = 0;
			this.cbEnableFlag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableFlag.Location = new System.Drawing.Point(188, 30);
			this.cbEnableFlag.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableFlag.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableFlag.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableFlag.Name = "cbEnableFlag";
			this.cbEnableFlag.Ripple = true;
			this.cbEnableFlag.Size = new System.Drawing.Size(94, 30);
			this.cbEnableFlag.TabIndex = 3;
			this.cbEnableFlag.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Depth = 0;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 30);
			this.label2.TabIndex = 0;
			this.label2.Text = "Module";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbModuleNumber
			// 
			this.cbModuleNumber.AutoResize = false;
			this.cbModuleNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cbModuleNumber.Depth = 0;
			this.cbModuleNumber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbModuleNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cbModuleNumber.DropDownHeight = 118;
			this.cbModuleNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModuleNumber.DropDownWidth = 121;
			this.cbModuleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.cbModuleNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cbModuleNumber.FormattingEnabled = true;
			this.cbModuleNumber.IntegralHeight = false;
			this.cbModuleNumber.ItemHeight = 29;
			this.cbModuleNumber.Location = new System.Drawing.Point(3, 33);
			this.cbModuleNumber.MaxDropDownItems = 4;
			this.cbModuleNumber.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.cbModuleNumber.Name = "cbModuleNumber";
			this.cbModuleNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbModuleNumber.Size = new System.Drawing.Size(88, 35);
			this.cbModuleNumber.StartIndex = 0;
			this.cbModuleNumber.TabIndex = 1;
			this.cbModuleNumber.UseTallSize = false;
			this.cbModuleNumber.SelectedIndexChanged += new System.EventHandler(this.cbModuleNumber_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Depth = 0;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.Location = new System.Drawing.Point(97, 0);
			this.label1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "Channel";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbChannelNumber
			// 
			this.cbChannelNumber.AutoResize = false;
			this.cbChannelNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cbChannelNumber.Depth = 0;
			this.cbChannelNumber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbChannelNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cbChannelNumber.DropDownHeight = 118;
			this.cbChannelNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChannelNumber.DropDownWidth = 121;
			this.cbChannelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.cbChannelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cbChannelNumber.FormattingEnabled = true;
			this.cbChannelNumber.IntegralHeight = false;
			this.cbChannelNumber.ItemHeight = 29;
			this.cbChannelNumber.Location = new System.Drawing.Point(97, 33);
			this.cbChannelNumber.MaxDropDownItems = 4;
			this.cbChannelNumber.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.cbChannelNumber.Name = "cbChannelNumber";
			this.cbChannelNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbChannelNumber.Size = new System.Drawing.Size(88, 35);
			this.cbChannelNumber.StartIndex = 0;
			this.cbChannelNumber.TabIndex = 2;
			this.cbChannelNumber.UseTallSize = false;
			this.cbChannelNumber.SelectedIndexChanged += new System.EventHandler(this.cbChannelNumber_SelectedIndexChanged);
			// 
			// cbEnableEnable
			// 
			this.cbEnableEnable.AutoSize = true;
			this.cbEnableEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableEnable.Depth = 0;
			this.cbEnableEnable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableEnable.Location = new System.Drawing.Point(188, 60);
			this.cbEnableEnable.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableEnable.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableEnable.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.cbEnableEnable.Name = "cbEnableEnable";
			this.cbEnableEnable.Ripple = true;
			this.cbEnableEnable.Size = new System.Drawing.Size(94, 32);
			this.cbEnableEnable.TabIndex = 8;
			this.cbEnableEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableEnable.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Depth = 0;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label4.Location = new System.Drawing.Point(97, 60);
			this.label4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 32);
			this.label4.TabIndex = 9;
			this.label4.Text = "Selected Set:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmValveControlSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Ivory;
			this.ClientSize = new System.Drawing.Size(955, 490);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmValveControlSetup";
			this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
			this.Text = "frmValveControlSetup";
			this.Load += new System.EventHandler(this.frmValveControlSetup_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabValveControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabValveControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ReaLTaiizor.Controls.MaterialCheckBox cbLockSetup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialButton btDefault;
        private ReaLTaiizor.Controls.MaterialButton btLoad;
        private ReaLTaiizor.Controls.MaterialButton btSave;
        private ReaLTaiizor.Controls.MaterialLabel lbResultText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ReaLTaiizor.Controls.MaterialButton btCancel;
        private ReaLTaiizor.Controls.MaterialButton btConfirm;
        private ReaLTaiizor.Controls.MaterialLabel label2;
        private ReaLTaiizor.Controls.MaterialLabel lbenabl;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableFlag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ReaLTaiizor.Controls.MaterialLabel label1;
        private ReaLTaiizor.Controls.MaterialLabel label6;
        private ReaLTaiizor.Controls.MaterialLabel label7;
        private ReaLTaiizor.Controls.MaterialLabel label8;
        private ReaLTaiizor.Controls.MaterialLabel label9;
        private ReaLTaiizor.Controls.MaterialLabel label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage1;
        private ReaLTaiizor.Controls.MaterialComboBox cbModuleNumber;
        private ReaLTaiizor.Controls.MaterialComboBox cbChannelNumber;
        private ReaLTaiizor.Controls.MaterialLabel label11;
        private ReaLTaiizor.Controls.MaterialTextBox tbGraphMin;
        private ReaLTaiizor.Controls.MaterialTextBox tbGraphMax;
        private ReaLTaiizor.Controls.MaterialTextBox tbVCMin;
        private ReaLTaiizor.Controls.MaterialTextBox tbVCMax;
        private ReaLTaiizor.Controls.MaterialTextBox tbVCRatio;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableGraphMin;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableGraphMax;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableVCMin;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableVCMax;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableVCRatio;
        private ReaLTaiizor.Controls.MaterialLabel label3;
        private ReaLTaiizor.Controls.MaterialTextBox tbConstraint;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableVCConstraint;
        private ReaLTaiizor.Controls.MaterialCheckBox cbEnableEnable;
        private ReaLTaiizor.Controls.MaterialLabel label4;
    }
}