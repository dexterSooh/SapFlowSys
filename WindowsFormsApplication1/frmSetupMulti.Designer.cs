namespace SapflowApplication
{
    partial class frmSetupMulti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupMulti));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpMultiSetup = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btDefaultAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDefault_a = new System.Windows.Forms.TextBox();
            this.tbDefault_b = new System.Windows.Forms.TextBox();
            this.tbDefault_c = new System.Windows.Forms.TextBox();
            this.tbDefault_Tm = new System.Windows.Forms.TextBox();
            this.lbenabl = new System.Windows.Forms.Label();
            this.cbEnableFlag = new System.Windows.Forms.CheckBox();
            this.btDefault = new System.Windows.Forms.Button();
            this.tbpGraphSetup = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbGraphEnable = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSFMin = new System.Windows.Forms.TextBox();
            this.tbSFMax = new System.Windows.Forms.TextBox();
            this.tbRTempMin = new System.Windows.Forms.TextBox();
            this.tbRTempMax = new System.Windows.Forms.TextBox();
            this.cbEnableSFMin = new System.Windows.Forms.CheckBox();
            this.cbEnableSFMax = new System.Windows.Forms.CheckBox();
            this.cbEnableRTempMin = new System.Windows.Forms.CheckBox();
            this.cbEnableRTempMax = new System.Windows.Forms.CheckBox();
            this.btSetGraph = new System.Windows.Forms.Button();
            this.btSetGraphAll = new System.Windows.Forms.Button();
            this.btResetLocation = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbLockSetup = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btGraph = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lbResultText = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btConfirm = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbpMultiSetup.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tbpGraphSetup.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpMultiSetup);
            this.tabControl1.Controls.Add(this.tbpGraphSetup);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 356);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpMultiSetup
            // 
            this.tbpMultiSetup.Controls.Add(this.tableLayoutPanel4);
            this.tbpMultiSetup.Location = new System.Drawing.Point(4, 22);
            this.tbpMultiSetup.Name = "tbpMultiSetup";
            this.tbpMultiSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMultiSetup.Size = new System.Drawing.Size(647, 330);
            this.tbpMultiSetup.TabIndex = 0;
            this.tbpMultiSetup.Text = "Module Setup";
            this.tbpMultiSetup.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(641, 324);
            this.tableLayoutPanel4.TabIndex = 1;
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
            this.dataGridView1.Size = new System.Drawing.Size(635, 288);
            this.dataGridView1.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 12;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel3.Controls.Add(this.btDefaultAll, 11, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbDefault_a, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbDefault_b, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbDefault_c, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbDefault_Tm, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbenabl, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbEnableFlag, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btDefault, 10, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 297);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(635, 24);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btDefaultAll
            // 
            this.btDefaultAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btDefaultAll.Location = new System.Drawing.Point(581, 3);
            this.btDefaultAll.Name = "btDefaultAll";
            this.btDefaultAll.Size = new System.Drawing.Size(65, 18);
            this.btDefaultAll.TabIndex = 0;
            this.btDefaultAll.Text = "Set All";
            this.btDefaultAll.UseVisualStyleBackColor = true;
            this.btDefaultAll.Click += new System.EventHandler(this.btDefaultAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(186, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "b:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(290, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "c:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(82, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "a:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(394, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tm:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDefault_a
            // 
            this.tbDefault_a.Location = new System.Drawing.Point(106, 3);
            this.tbDefault_a.Name = "tbDefault_a";
            this.tbDefault_a.Size = new System.Drawing.Size(74, 21);
            this.tbDefault_a.TabIndex = 1;
            this.tbDefault_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDefault_b
            // 
            this.tbDefault_b.Location = new System.Drawing.Point(210, 3);
            this.tbDefault_b.Name = "tbDefault_b";
            this.tbDefault_b.Size = new System.Drawing.Size(74, 21);
            this.tbDefault_b.TabIndex = 1;
            this.tbDefault_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDefault_c
            // 
            this.tbDefault_c.Location = new System.Drawing.Point(314, 3);
            this.tbDefault_c.Name = "tbDefault_c";
            this.tbDefault_c.Size = new System.Drawing.Size(74, 21);
            this.tbDefault_c.TabIndex = 1;
            this.tbDefault_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDefault_Tm
            // 
            this.tbDefault_Tm.Location = new System.Drawing.Point(430, 3);
            this.tbDefault_Tm.Name = "tbDefault_Tm";
            this.tbDefault_Tm.Size = new System.Drawing.Size(74, 21);
            this.tbDefault_Tm.TabIndex = 1;
            this.tbDefault_Tm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbenabl
            // 
            this.lbenabl.AutoSize = true;
            this.lbenabl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbenabl.Location = new System.Drawing.Point(3, 0);
            this.lbenabl.Name = "lbenabl";
            this.lbenabl.Size = new System.Drawing.Size(49, 24);
            this.lbenabl.TabIndex = 0;
            this.lbenabl.Text = "Enable:";
            this.lbenabl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbEnableFlag
            // 
            this.cbEnableFlag.AutoSize = true;
            this.cbEnableFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEnableFlag.Location = new System.Drawing.Point(58, 3);
            this.cbEnableFlag.Name = "cbEnableFlag";
            this.cbEnableFlag.Size = new System.Drawing.Size(18, 18);
            this.cbEnableFlag.TabIndex = 3;
            this.cbEnableFlag.UseVisualStyleBackColor = true;
            // 
            // btDefault
            // 
            this.btDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btDefault.Location = new System.Drawing.Point(510, 3);
            this.btDefault.Name = "btDefault";
            this.btDefault.Size = new System.Drawing.Size(65, 18);
            this.btDefault.TabIndex = 0;
            this.btDefault.Text = "Set";
            this.btDefault.UseVisualStyleBackColor = true;
            this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
            // 
            // tbpGraphSetup
            // 
            this.tbpGraphSetup.Controls.Add(this.tableLayoutPanel5);
            this.tbpGraphSetup.Controls.Add(this.dataGridView2);
            this.tbpGraphSetup.Location = new System.Drawing.Point(4, 22);
            this.tbpGraphSetup.Name = "tbpGraphSetup";
            this.tbpGraphSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGraphSetup.Size = new System.Drawing.Size(647, 330);
            this.tbpGraphSetup.TabIndex = 1;
            this.tbpGraphSetup.Text = "Graph Setup";
            this.tbpGraphSetup.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(641, 324);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 7;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.06044F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.75825F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.06044F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.06044F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.06044F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label10, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.label11, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbGraphEnable, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label13, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.tbSFMin, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.tbSFMax, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.tbRTempMin, 3, 1);
            this.tableLayoutPanel6.Controls.Add(this.tbRTempMax, 4, 1);
            this.tableLayoutPanel6.Controls.Add(this.cbEnableSFMin, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.cbEnableSFMax, 2, 2);
            this.tableLayoutPanel6.Controls.Add(this.cbEnableRTempMin, 3, 2);
            this.tableLayoutPanel6.Controls.Add(this.cbEnableRTempMax, 4, 2);
            this.tableLayoutPanel6.Controls.Add(this.btSetGraph, 5, 1);
            this.tableLayoutPanel6.Controls.Add(this.btSetGraphAll, 6, 1);
            this.tableLayoutPanel6.Controls.Add(this.btResetLocation, 6, 2);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 231);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(635, 90);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enable";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(95, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "SF Min.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(185, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "SF Max.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(277, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "RTemp Min.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(369, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "RTemp Max.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbGraphEnable
            // 
            this.cbGraphEnable.AutoSize = true;
            this.cbGraphEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGraphEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbGraphEnable.Location = new System.Drawing.Point(3, 27);
            this.cbGraphEnable.Name = "cbGraphEnable";
            this.cbGraphEnable.Size = new System.Drawing.Size(86, 23);
            this.cbGraphEnable.TabIndex = 3;
            this.cbGraphEnable.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(461, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 24);
            this.label13.TabIndex = 0;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSFMin
            // 
            this.tbSFMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSFMin.Location = new System.Drawing.Point(95, 27);
            this.tbSFMin.Name = "tbSFMin";
            this.tbSFMin.Size = new System.Drawing.Size(84, 21);
            this.tbSFMin.TabIndex = 4;
            // 
            // tbSFMax
            // 
            this.tbSFMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSFMax.Location = new System.Drawing.Point(185, 27);
            this.tbSFMax.Name = "tbSFMax";
            this.tbSFMax.Size = new System.Drawing.Size(86, 21);
            this.tbSFMax.TabIndex = 4;
            // 
            // tbRTempMin
            // 
            this.tbRTempMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRTempMin.Location = new System.Drawing.Point(277, 27);
            this.tbRTempMin.Name = "tbRTempMin";
            this.tbRTempMin.Size = new System.Drawing.Size(86, 21);
            this.tbRTempMin.TabIndex = 4;
            // 
            // tbRTempMax
            // 
            this.tbRTempMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRTempMax.Location = new System.Drawing.Point(369, 27);
            this.tbRTempMax.Name = "tbRTempMax";
            this.tbRTempMax.Size = new System.Drawing.Size(86, 21);
            this.tbRTempMax.TabIndex = 4;
            // 
            // cbEnableSFMin
            // 
            this.cbEnableSFMin.AutoSize = true;
            this.cbEnableSFMin.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableSFMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEnableSFMin.Location = new System.Drawing.Point(95, 56);
            this.cbEnableSFMin.Name = "cbEnableSFMin";
            this.cbEnableSFMin.Size = new System.Drawing.Size(84, 31);
            this.cbEnableSFMin.TabIndex = 5;
            this.cbEnableSFMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableSFMin.UseVisualStyleBackColor = true;
            // 
            // cbEnableSFMax
            // 
            this.cbEnableSFMax.AutoSize = true;
            this.cbEnableSFMax.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableSFMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEnableSFMax.Location = new System.Drawing.Point(185, 56);
            this.cbEnableSFMax.Name = "cbEnableSFMax";
            this.cbEnableSFMax.Size = new System.Drawing.Size(86, 31);
            this.cbEnableSFMax.TabIndex = 5;
            this.cbEnableSFMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableSFMax.UseVisualStyleBackColor = true;
            // 
            // cbEnableRTempMin
            // 
            this.cbEnableRTempMin.AutoSize = true;
            this.cbEnableRTempMin.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableRTempMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEnableRTempMin.Location = new System.Drawing.Point(277, 56);
            this.cbEnableRTempMin.Name = "cbEnableRTempMin";
            this.cbEnableRTempMin.Size = new System.Drawing.Size(86, 31);
            this.cbEnableRTempMin.TabIndex = 5;
            this.cbEnableRTempMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableRTempMin.UseVisualStyleBackColor = true;
            // 
            // cbEnableRTempMax
            // 
            this.cbEnableRTempMax.AutoSize = true;
            this.cbEnableRTempMax.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableRTempMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEnableRTempMax.Location = new System.Drawing.Point(369, 56);
            this.cbEnableRTempMax.Name = "cbEnableRTempMax";
            this.cbEnableRTempMax.Size = new System.Drawing.Size(86, 31);
            this.cbEnableRTempMax.TabIndex = 5;
            this.cbEnableRTempMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnableRTempMax.UseVisualStyleBackColor = true;
            // 
            // btSetGraph
            // 
            this.btSetGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSetGraph.Location = new System.Drawing.Point(461, 27);
            this.btSetGraph.Name = "btSetGraph";
            this.btSetGraph.Size = new System.Drawing.Size(64, 23);
            this.btSetGraph.TabIndex = 0;
            this.btSetGraph.Text = "Set";
            this.btSetGraph.UseVisualStyleBackColor = true;
            this.btSetGraph.Click += new System.EventHandler(this.btSetGraph_Click);
            // 
            // btSetGraphAll
            // 
            this.btSetGraphAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSetGraphAll.Location = new System.Drawing.Point(531, 27);
            this.btSetGraphAll.Name = "btSetGraphAll";
            this.btSetGraphAll.Size = new System.Drawing.Size(101, 23);
            this.btSetGraphAll.TabIndex = 0;
            this.btSetGraphAll.Text = "Set All";
            this.btSetGraphAll.UseVisualStyleBackColor = true;
            this.btSetGraphAll.Click += new System.EventHandler(this.btSetGraphAll_Click);
            // 
            // btResetLocation
            // 
            this.btResetLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btResetLocation.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btResetLocation.Location = new System.Drawing.Point(531, 56);
            this.btResetLocation.Name = "btResetLocation";
            this.btResetLocation.Size = new System.Drawing.Size(101, 31);
            this.btResetLocation.TabIndex = 6;
            this.btResetLocation.Text = "Reset Location";
            this.btResetLocation.UseVisualStyleBackColor = true;
            this.btResetLocation.Click += new System.EventHandler(this.btResetLocation_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(641, 324);
            this.dataGridView2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 402);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 365);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(655, 34);
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
            this.flowLayoutPanel1.Controls.Add(this.btGraph);
            this.flowLayoutPanel1.Controls.Add(this.btLoad);
            this.flowLayoutPanel1.Controls.Add(this.btSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(97, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btGraph
            // 
            this.btGraph.Location = new System.Drawing.Point(3, 3);
            this.btGraph.Name = "btGraph";
            this.btGraph.Size = new System.Drawing.Size(78, 23);
            this.btGraph.TabIndex = 2;
            this.btGraph.Text = "Graph On";
            this.btGraph.UseVisualStyleBackColor = true;
            this.btGraph.Click += new System.EventHandler(this.btGraph_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(87, 3);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(52, 23);
            this.btLoad.TabIndex = 0;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(145, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(52, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbResultText
            // 
            this.lbResultText.AutoSize = true;
            this.lbResultText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResultText.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResultText.Location = new System.Drawing.Point(347, 0);
            this.lbResultText.Name = "lbResultText";
            this.lbResultText.Size = new System.Drawing.Size(135, 34);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(488, 3);
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
            // frmSetupMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetupMulti";
            this.Text = "frmSetupMulti";
            this.Load += new System.EventHandler(this.frmSetupMulti_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpMultiSetup.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tbpGraphSetup.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpMultiSetup;
        private System.Windows.Forms.TabPage tbpGraphSetup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox cbLockSetup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbResultText;
        private System.Windows.Forms.Button btDefaultAll;
        private System.Windows.Forms.Button btGraph;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDefault_a;
        private System.Windows.Forms.TextBox tbDefault_b;
        private System.Windows.Forms.TextBox tbDefault_c;
        private System.Windows.Forms.TextBox tbDefault_Tm;
        private System.Windows.Forms.Label lbenabl;
        private System.Windows.Forms.CheckBox cbEnableFlag;
        private System.Windows.Forms.Button btDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbGraphEnable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbSFMin;
        private System.Windows.Forms.TextBox tbSFMax;
        private System.Windows.Forms.TextBox tbRTempMin;
        private System.Windows.Forms.TextBox tbRTempMax;
        private System.Windows.Forms.CheckBox cbEnableSFMin;
        private System.Windows.Forms.CheckBox cbEnableSFMax;
        private System.Windows.Forms.CheckBox cbEnableRTempMin;
        private System.Windows.Forms.CheckBox cbEnableRTempMax;
        private System.Windows.Forms.Button btSetGraph;
        private System.Windows.Forms.Button btSetGraphAll;
        private System.Windows.Forms.Button btResetLocation;
    }
}