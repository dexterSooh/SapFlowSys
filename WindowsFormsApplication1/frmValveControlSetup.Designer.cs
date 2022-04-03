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
			this.cbLockSetup = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btLoad = new System.Windows.Forms.Button();
			this.btSave = new System.Windows.Forms.Button();
			this.lbResultText = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.btCancel = new System.Windows.Forms.Button();
			this.btConfirm = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tbGraphMin = new System.Windows.Forms.TextBox();
			this.tbGraphMax = new System.Windows.Forms.TextBox();
			this.tbVCMin = new System.Windows.Forms.TextBox();
			this.tbVCMax = new System.Windows.Forms.TextBox();
			this.tbVCRatio = new System.Windows.Forms.TextBox();
			this.cbEnableGraphMin = new System.Windows.Forms.CheckBox();
			this.cbEnableGraphMax = new System.Windows.Forms.CheckBox();
			this.cbEnableVCMin = new System.Windows.Forms.CheckBox();
			this.cbEnableVCMax = new System.Windows.Forms.CheckBox();
			this.cbEnableVCRatio = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbConstraint = new System.Windows.Forms.TextBox();
			this.cbEnableVCConstraint = new System.Windows.Forms.CheckBox();
			this.btDefault = new System.Windows.Forms.Button();
			this.lbenabl = new System.Windows.Forms.Label();
			this.cbEnableFlag = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbModuleNumber = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbChannelNumber = new System.Windows.Forms.ComboBox();
			this.cbEnableEnable = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
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
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 380);
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
			this.tabControl1.Size = new System.Drawing.Size(857, 250);
			this.tabControl1.TabIndex = 0;
			// 
			// tabValveControl
			// 
			this.tabValveControl.Controls.Add(this.dataGridView1);
			this.tabValveControl.Location = new System.Drawing.Point(4, 22);
			this.tabValveControl.Name = "tabValveControl";
			this.tabValveControl.Padding = new System.Windows.Forms.Padding(3);
			this.tabValveControl.Size = new System.Drawing.Size(849, 224);
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
			this.dataGridView1.Size = new System.Drawing.Size(843, 218);
			this.dataGridView1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(849, 224);
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
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 343);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(857, 34);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// cbLockSetup
			// 
			this.cbLockSetup.AutoSize = true;
			this.cbLockSetup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbLockSetup.Location = new System.Drawing.Point(3, 3);
			this.cbLockSetup.Name = "cbLockSetup";
			this.cbLockSetup.Size = new System.Drawing.Size(88, 28);
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
			this.btLoad.Location = new System.Drawing.Point(3, 3);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(75, 23);
			this.btLoad.TabIndex = 0;
			this.btLoad.Text = "Load";
			this.btLoad.UseVisualStyleBackColor = true;
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(84, 3);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 23);
			this.btSave.TabIndex = 1;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// lbResultText
			// 
			this.lbResultText.AutoSize = true;
			this.lbResultText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbResultText.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbResultText.Location = new System.Drawing.Point(347, 0);
			this.lbResultText.Name = "lbResultText";
			this.lbResultText.Size = new System.Drawing.Size(337, 34);
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
			this.flowLayoutPanel2.Location = new System.Drawing.Point(690, 3);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(164, 28);
			this.flowLayoutPanel2.TabIndex = 2;
			// 
			// btCancel
			// 
			this.btCancel.Location = new System.Drawing.Point(86, 3);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btConfirm
			// 
			this.btConfirm.Location = new System.Drawing.Point(5, 3);
			this.btConfirm.Name = "btConfirm";
			this.btConfirm.Size = new System.Drawing.Size(75, 23);
			this.btConfirm.TabIndex = 0;
			this.btConfirm.Text = "Confirm";
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
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 259);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(857, 78);
			this.tableLayoutPanel4.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Location = new System.Drawing.Point(258, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 26);
			this.label6.TabIndex = 0;
			this.label6.Text = "Graph Min.";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Location = new System.Drawing.Point(343, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(79, 26);
			this.label7.TabIndex = 0;
			this.label7.Text = "Graph Max.";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Location = new System.Drawing.Point(428, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(79, 26);
			this.label8.TabIndex = 0;
			this.label8.Text = "VC Min.";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point(513, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 26);
			this.label9.TabIndex = 0;
			this.label9.Text = "VC Max.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label10.Location = new System.Drawing.Point(683, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(79, 26);
			this.label10.TabIndex = 0;
			this.label10.Text = "Ratio(%)";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Location = new System.Drawing.Point(768, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(86, 26);
			this.label11.TabIndex = 0;
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbGraphMin
			// 
			this.tbGraphMin.Location = new System.Drawing.Point(258, 29);
			this.tbGraphMin.Name = "tbGraphMin";
			this.tbGraphMin.Size = new System.Drawing.Size(79, 21);
			this.tbGraphMin.TabIndex = 4;
			// 
			// tbGraphMax
			// 
			this.tbGraphMax.Location = new System.Drawing.Point(343, 29);
			this.tbGraphMax.Name = "tbGraphMax";
			this.tbGraphMax.Size = new System.Drawing.Size(79, 21);
			this.tbGraphMax.TabIndex = 4;
			// 
			// tbVCMin
			// 
			this.tbVCMin.Location = new System.Drawing.Point(428, 29);
			this.tbVCMin.Name = "tbVCMin";
			this.tbVCMin.Size = new System.Drawing.Size(79, 21);
			this.tbVCMin.TabIndex = 4;
			// 
			// tbVCMax
			// 
			this.tbVCMax.Location = new System.Drawing.Point(513, 29);
			this.tbVCMax.Name = "tbVCMax";
			this.tbVCMax.Size = new System.Drawing.Size(79, 21);
			this.tbVCMax.TabIndex = 4;
			// 
			// tbVCRatio
			// 
			this.tbVCRatio.Location = new System.Drawing.Point(683, 29);
			this.tbVCRatio.Name = "tbVCRatio";
			this.tbVCRatio.Size = new System.Drawing.Size(79, 21);
			this.tbVCRatio.TabIndex = 4;
			// 
			// cbEnableGraphMin
			// 
			this.cbEnableGraphMin.AutoSize = true;
			this.cbEnableGraphMin.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableGraphMin.Location = new System.Drawing.Point(258, 55);
			this.cbEnableGraphMin.Name = "cbEnableGraphMin";
			this.cbEnableGraphMin.Size = new System.Drawing.Size(79, 20);
			this.cbEnableGraphMin.TabIndex = 5;
			this.cbEnableGraphMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMin.UseVisualStyleBackColor = true;
			// 
			// cbEnableGraphMax
			// 
			this.cbEnableGraphMax.AutoSize = true;
			this.cbEnableGraphMax.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMax.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableGraphMax.Location = new System.Drawing.Point(343, 55);
			this.cbEnableGraphMax.Name = "cbEnableGraphMax";
			this.cbEnableGraphMax.Size = new System.Drawing.Size(79, 20);
			this.cbEnableGraphMax.TabIndex = 5;
			this.cbEnableGraphMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableGraphMax.UseVisualStyleBackColor = true;
			// 
			// cbEnableVCMin
			// 
			this.cbEnableVCMin.AutoSize = true;
			this.cbEnableVCMin.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCMin.Location = new System.Drawing.Point(428, 55);
			this.cbEnableVCMin.Name = "cbEnableVCMin";
			this.cbEnableVCMin.Size = new System.Drawing.Size(79, 20);
			this.cbEnableVCMin.TabIndex = 5;
			this.cbEnableVCMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMin.UseVisualStyleBackColor = true;
			// 
			// cbEnableVCMax
			// 
			this.cbEnableVCMax.AutoSize = true;
			this.cbEnableVCMax.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMax.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCMax.Location = new System.Drawing.Point(513, 55);
			this.cbEnableVCMax.Name = "cbEnableVCMax";
			this.cbEnableVCMax.Size = new System.Drawing.Size(79, 20);
			this.cbEnableVCMax.TabIndex = 5;
			this.cbEnableVCMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCMax.UseVisualStyleBackColor = true;
			// 
			// cbEnableVCRatio
			// 
			this.cbEnableVCRatio.AutoSize = true;
			this.cbEnableVCRatio.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCRatio.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCRatio.Location = new System.Drawing.Point(683, 55);
			this.cbEnableVCRatio.Name = "cbEnableVCRatio";
			this.cbEnableVCRatio.Size = new System.Drawing.Size(79, 20);
			this.cbEnableVCRatio.TabIndex = 5;
			this.cbEnableVCRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCRatio.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(598, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 26);
			this.label3.TabIndex = 6;
			this.label3.Text = "Constraint";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbConstraint
			// 
			this.tbConstraint.Location = new System.Drawing.Point(598, 29);
			this.tbConstraint.Name = "tbConstraint";
			this.tbConstraint.Size = new System.Drawing.Size(79, 21);
			this.tbConstraint.TabIndex = 4;
			// 
			// cbEnableVCConstraint
			// 
			this.cbEnableVCConstraint.AutoSize = true;
			this.cbEnableVCConstraint.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableVCConstraint.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableVCConstraint.Location = new System.Drawing.Point(598, 55);
			this.cbEnableVCConstraint.Name = "cbEnableVCConstraint";
			this.cbEnableVCConstraint.Size = new System.Drawing.Size(79, 20);
			this.cbEnableVCConstraint.TabIndex = 7;
			this.cbEnableVCConstraint.UseVisualStyleBackColor = true;
			// 
			// btDefault
			// 
			this.btDefault.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btDefault.Location = new System.Drawing.Point(768, 29);
			this.btDefault.Name = "btDefault";
			this.btDefault.Size = new System.Drawing.Size(86, 20);
			this.btDefault.TabIndex = 0;
			this.btDefault.Text = "Set";
			this.btDefault.UseVisualStyleBackColor = true;
			this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
			// 
			// lbenabl
			// 
			this.lbenabl.AutoSize = true;
			this.lbenabl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbenabl.Location = new System.Drawing.Point(173, 0);
			this.lbenabl.Name = "lbenabl";
			this.lbenabl.Size = new System.Drawing.Size(79, 26);
			this.lbenabl.TabIndex = 0;
			this.lbenabl.Text = "Enable";
			this.lbenabl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbEnableFlag
			// 
			this.cbEnableFlag.AutoSize = true;
			this.cbEnableFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableFlag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableFlag.Location = new System.Drawing.Point(173, 29);
			this.cbEnableFlag.Name = "cbEnableFlag";
			this.cbEnableFlag.Size = new System.Drawing.Size(79, 20);
			this.cbEnableFlag.TabIndex = 3;
			this.cbEnableFlag.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "Module";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbModuleNumber
			// 
			this.cbModuleNumber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbModuleNumber.FormattingEnabled = true;
			this.cbModuleNumber.Location = new System.Drawing.Point(3, 29);
			this.cbModuleNumber.Name = "cbModuleNumber";
			this.cbModuleNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbModuleNumber.Size = new System.Drawing.Size(79, 20);
			this.cbModuleNumber.TabIndex = 1;
			this.cbModuleNumber.SelectedIndexChanged += new System.EventHandler(this.cbModuleNumber_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(88, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Channel";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbChannelNumber
			// 
			this.cbChannelNumber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbChannelNumber.FormattingEnabled = true;
			this.cbChannelNumber.Location = new System.Drawing.Point(88, 29);
			this.cbChannelNumber.Name = "cbChannelNumber";
			this.cbChannelNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbChannelNumber.Size = new System.Drawing.Size(79, 20);
			this.cbChannelNumber.TabIndex = 2;
			this.cbChannelNumber.SelectedIndexChanged += new System.EventHandler(this.cbChannelNumber_SelectedIndexChanged);
			// 
			// cbEnableEnable
			// 
			this.cbEnableEnable.AutoSize = true;
			this.cbEnableEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableEnable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbEnableEnable.Location = new System.Drawing.Point(173, 55);
			this.cbEnableEnable.Name = "cbEnableEnable";
			this.cbEnableEnable.Size = new System.Drawing.Size(79, 20);
			this.cbEnableEnable.TabIndex = 8;
			this.cbEnableEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbEnableEnable.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(88, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 26);
			this.label4.TabIndex = 9;
			this.label4.Text = "Selected Set:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmValveControlSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Ivory;
			this.ClientSize = new System.Drawing.Size(869, 447);
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
        private System.Windows.Forms.CheckBox cbLockSetup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btDefault;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lbResultText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbenabl;
        private System.Windows.Forms.CheckBox cbEnableFlag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbModuleNumber;
        private System.Windows.Forms.ComboBox cbChannelNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbGraphMin;
        private System.Windows.Forms.TextBox tbGraphMax;
        private System.Windows.Forms.TextBox tbVCMin;
        private System.Windows.Forms.TextBox tbVCMax;
        private System.Windows.Forms.TextBox tbVCRatio;
        private System.Windows.Forms.CheckBox cbEnableGraphMin;
        private System.Windows.Forms.CheckBox cbEnableGraphMax;
        private System.Windows.Forms.CheckBox cbEnableVCMin;
        private System.Windows.Forms.CheckBox cbEnableVCMax;
        private System.Windows.Forms.CheckBox cbEnableVCRatio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbConstraint;
        private System.Windows.Forms.CheckBox cbEnableVCConstraint;
        private System.Windows.Forms.CheckBox cbEnableEnable;
        private System.Windows.Forms.Label label4;
    }
}