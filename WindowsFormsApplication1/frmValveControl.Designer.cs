namespace SapflowApplication
{
    partial class frmValveControl
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValveControl));
			this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutRight = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
			this.btDataExport = new System.Windows.Forms.Button();
			this.btSetup = new System.Windows.Forms.Button();
			this.lbStartTime = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
			this.btLoadParameter = new System.Windows.Forms.Button();
			this.btSaveParameter = new System.Windows.Forms.Button();
			this.lbEndTime = new System.Windows.Forms.Label();
			this.lbMaxTime = new System.Windows.Forms.Label();
			this.lbMinTime = new System.Windows.Forms.Label();
			this.tbEventJoule = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
			this.btStartValveControl = new System.Windows.Forms.Button();
			this.btStopValveControl = new System.Windows.Forms.Button();
			this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
			this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
			this.dtpMaxTime = new System.Windows.Forms.DateTimePicker();
			this.dtpMinTime = new System.Windows.Forms.DateTimePicker();
			this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.listBoxLeft = new System.Windows.Forms.ListBox();
			this.listBoxRight = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.cbScale = new System.Windows.Forms.ComboBox();
			this.btScaleFull = new System.Windows.Forms.Button();
			this.btScale3d = new System.Windows.Forms.Button();
			this.btScale1d = new System.Windows.Forms.Button();
			this.btScaleNext = new System.Windows.Forms.Button();
			this.btScalePrevious = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel12.SuspendLayout();
			this.tableLayoutRight.SuspendLayout();
			this.tableLayoutPanel13.SuspendLayout();
			this.tableLayoutPanel15.SuspendLayout();
			this.tableLayoutPanel14.SuspendLayout();
			this.tableLayoutPanel16.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel12
			// 
			this.tableLayoutPanel12.ColumnCount = 2;
			this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
			this.tableLayoutPanel12.Controls.Add(this.tableLayoutRight, 1, 0);
			this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel16, 0, 0);
			this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 33);
			this.tableLayoutPanel12.Name = "tableLayoutPanel12";
			this.tableLayoutPanel12.RowCount = 1;
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 466F));
			this.tableLayoutPanel12.Size = new System.Drawing.Size(881, 466);
			this.tableLayoutPanel12.TabIndex = 2;
			// 
			// tableLayoutRight
			// 
			this.tableLayoutRight.ColumnCount = 1;
			this.tableLayoutRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutRight.Controls.Add(this.tableLayoutPanel13, 0, 12);
			this.tableLayoutRight.Controls.Add(this.lbStartTime, 0, 0);
			this.tableLayoutRight.Controls.Add(this.label53, 0, 8);
			this.tableLayoutRight.Controls.Add(this.tableLayoutPanel15, 0, 10);
			this.tableLayoutRight.Controls.Add(this.lbEndTime, 0, 2);
			this.tableLayoutRight.Controls.Add(this.lbMaxTime, 0, 4);
			this.tableLayoutRight.Controls.Add(this.lbMinTime, 0, 6);
			this.tableLayoutRight.Controls.Add(this.tbEventJoule, 0, 9);
			this.tableLayoutRight.Controls.Add(this.tableLayoutPanel14, 0, 11);
			this.tableLayoutRight.Controls.Add(this.dtpEndTime, 0, 3);
			this.tableLayoutRight.Controls.Add(this.dtpStartTime, 0, 1);
			this.tableLayoutRight.Controls.Add(this.dtpMaxTime, 0, 5);
			this.tableLayoutRight.Controls.Add(this.dtpMinTime, 0, 7);
			this.tableLayoutRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutRight.Location = new System.Drawing.Point(761, 3);
			this.tableLayoutRight.Name = "tableLayoutRight";
			this.tableLayoutRight.RowCount = 13;
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutRight.Size = new System.Drawing.Size(117, 460);
			this.tableLayoutRight.TabIndex = 0;
			// 
			// tableLayoutPanel13
			// 
			this.tableLayoutPanel13.ColumnCount = 2;
			this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel13.Controls.Add(this.btDataExport, 0, 0);
			this.tableLayoutPanel13.Controls.Add(this.btSetup, 1, 0);
			this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 425);
			this.tableLayoutPanel13.Name = "tableLayoutPanel13";
			this.tableLayoutPanel13.RowCount = 1;
			this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel13.Size = new System.Drawing.Size(111, 32);
			this.tableLayoutPanel13.TabIndex = 6;
			// 
			// btDataExport
			// 
			this.btDataExport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btDataExport.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btDataExport.Location = new System.Drawing.Point(3, 3);
			this.btDataExport.Name = "btDataExport";
			this.btDataExport.Size = new System.Drawing.Size(49, 26);
			this.btDataExport.TabIndex = 0;
			this.btDataExport.Text = "Export";
			this.btDataExport.UseVisualStyleBackColor = true;
			this.btDataExport.Visible = false;
			this.btDataExport.Click += new System.EventHandler(this.btDataExport_Click);
			// 
			// btSetup
			// 
			this.btSetup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btSetup.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btSetup.Location = new System.Drawing.Point(58, 3);
			this.btSetup.Name = "btSetup";
			this.btSetup.Size = new System.Drawing.Size(50, 26);
			this.btSetup.TabIndex = 1;
			this.btSetup.Text = "Setup";
			this.btSetup.UseVisualStyleBackColor = true;
			this.btSetup.Visible = false;
			this.btSetup.Click += new System.EventHandler(this.button2_Click);
			// 
			// lbStartTime
			// 
			this.lbStartTime.AutoSize = true;
			this.lbStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbStartTime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbStartTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbStartTime.Location = new System.Drawing.Point(3, 0);
			this.lbStartTime.Name = "lbStartTime";
			this.lbStartTime.Size = new System.Drawing.Size(111, 34);
			this.lbStartTime.TabIndex = 0;
			this.lbStartTime.Text = "Start Time";
			this.lbStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbStartTime.Click += new System.EventHandler(this.lbStartEndTime_Click);
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label53.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label53.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label53.Location = new System.Drawing.Point(3, 272);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(111, 34);
			this.label53.TabIndex = 0;
			this.label53.Text = "EVENT(J)";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel15
			// 
			this.tableLayoutPanel15.ColumnCount = 2;
			this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel15.Controls.Add(this.btLoadParameter, 0, 0);
			this.tableLayoutPanel15.Controls.Add(this.btSaveParameter, 1, 0);
			this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 343);
			this.tableLayoutPanel15.Name = "tableLayoutPanel15";
			this.tableLayoutPanel15.RowCount = 1;
			this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel15.Size = new System.Drawing.Size(111, 34);
			this.tableLayoutPanel15.TabIndex = 2;
			// 
			// btLoadParameter
			// 
			this.btLoadParameter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btLoadParameter.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btLoadParameter.Location = new System.Drawing.Point(3, 3);
			this.btLoadParameter.Name = "btLoadParameter";
			this.btLoadParameter.Size = new System.Drawing.Size(49, 28);
			this.btLoadParameter.TabIndex = 0;
			this.btLoadParameter.Text = "Load";
			this.btLoadParameter.UseVisualStyleBackColor = true;
			this.btLoadParameter.Click += new System.EventHandler(this.btLoadParameter_Click);
			// 
			// btSaveParameter
			// 
			this.btSaveParameter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btSaveParameter.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btSaveParameter.Location = new System.Drawing.Point(58, 3);
			this.btSaveParameter.Name = "btSaveParameter";
			this.btSaveParameter.Size = new System.Drawing.Size(50, 28);
			this.btSaveParameter.TabIndex = 1;
			this.btSaveParameter.Text = "Save";
			this.btSaveParameter.UseVisualStyleBackColor = true;
			this.btSaveParameter.Click += new System.EventHandler(this.btSaveParameter_Click);
			// 
			// lbEndTime
			// 
			this.lbEndTime.AutoSize = true;
			this.lbEndTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbEndTime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbEndTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbEndTime.Location = new System.Drawing.Point(3, 68);
			this.lbEndTime.Name = "lbEndTime";
			this.lbEndTime.Size = new System.Drawing.Size(111, 34);
			this.lbEndTime.TabIndex = 0;
			this.lbEndTime.Text = "End Time";
			this.lbEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbEndTime.Click += new System.EventHandler(this.lbStartEndTime_Click);
			// 
			// lbMaxTime
			// 
			this.lbMaxTime.AutoSize = true;
			this.lbMaxTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbMaxTime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbMaxTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbMaxTime.Location = new System.Drawing.Point(3, 136);
			this.lbMaxTime.Name = "lbMaxTime";
			this.lbMaxTime.Size = new System.Drawing.Size(111, 34);
			this.lbMaxTime.TabIndex = 0;
			this.lbMaxTime.Text = "Max. Time";
			this.lbMaxTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbMaxTime.Click += new System.EventHandler(this.lbMaxMinTime_Click);
			// 
			// lbMinTime
			// 
			this.lbMinTime.AutoSize = true;
			this.lbMinTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbMinTime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbMinTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbMinTime.Location = new System.Drawing.Point(3, 204);
			this.lbMinTime.Name = "lbMinTime";
			this.lbMinTime.Size = new System.Drawing.Size(111, 34);
			this.lbMinTime.TabIndex = 0;
			this.lbMinTime.Text = "Min. Time";
			this.lbMinTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbMinTime.Click += new System.EventHandler(this.lbMaxMinTime_Click);
			// 
			// tbEventJoule
			// 
			this.tbEventJoule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbEventJoule.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tbEventJoule.Location = new System.Drawing.Point(3, 309);
			this.tbEventJoule.Name = "tbEventJoule";
			this.tbEventJoule.Size = new System.Drawing.Size(111, 29);
			this.tbEventJoule.TabIndex = 5;
			this.tbEventJoule.Text = "0";
			this.tbEventJoule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbEventJoule.TextChanged += new System.EventHandler(this.tbEventJoule_TextChanged);
			this.tbEventJoule.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPreprocess_KeyPress);
			// 
			// tableLayoutPanel14
			// 
			this.tableLayoutPanel14.ColumnCount = 2;
			this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel14.Controls.Add(this.btStartValveControl, 0, 0);
			this.tableLayoutPanel14.Controls.Add(this.btStopValveControl, 1, 0);
			this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 383);
			this.tableLayoutPanel14.Name = "tableLayoutPanel14";
			this.tableLayoutPanel14.RowCount = 1;
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel14.Size = new System.Drawing.Size(111, 36);
			this.tableLayoutPanel14.TabIndex = 2;
			// 
			// btStartValveControl
			// 
			this.btStartValveControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btStartValveControl.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btStartValveControl.Location = new System.Drawing.Point(3, 3);
			this.btStartValveControl.Name = "btStartValveControl";
			this.btStartValveControl.Size = new System.Drawing.Size(49, 30);
			this.btStartValveControl.TabIndex = 0;
			this.btStartValveControl.Text = "Start";
			this.btStartValveControl.UseVisualStyleBackColor = true;
			this.btStartValveControl.Click += new System.EventHandler(this.btStartValveControl_Click);
			// 
			// btStopValveControl
			// 
			this.btStopValveControl.BackColor = System.Drawing.Color.DarkOrange;
			this.btStopValveControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btStopValveControl.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btStopValveControl.Location = new System.Drawing.Point(58, 3);
			this.btStopValveControl.Name = "btStopValveControl";
			this.btStopValveControl.Size = new System.Drawing.Size(50, 30);
			this.btStopValveControl.TabIndex = 1;
			this.btStopValveControl.Text = "Stop";
			this.btStopValveControl.UseVisualStyleBackColor = false;
			this.btStopValveControl.Click += new System.EventHandler(this.btStopValveControl_Click);
			// 
			// dtpEndTime
			// 
			this.dtpEndTime.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtpEndTime.Checked = false;
			this.dtpEndTime.CustomFormat = "HH:mm";
			this.dtpEndTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtpEndTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndTime.Location = new System.Drawing.Point(28, 106);
			this.dtpEndTime.Name = "dtpEndTime";
			this.dtpEndTime.ShowUpDown = true;
			this.dtpEndTime.Size = new System.Drawing.Size(61, 26);
			this.dtpEndTime.TabIndex = 7;
			this.dtpEndTime.Value = new System.DateTime(2017, 9, 4, 0, 0, 0, 0);
			this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
			// 
			// dtpStartTime
			// 
			this.dtpStartTime.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtpStartTime.CustomFormat = "HH:mm";
			this.dtpStartTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtpStartTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartTime.Location = new System.Drawing.Point(28, 38);
			this.dtpStartTime.Name = "dtpStartTime";
			this.dtpStartTime.ShowUpDown = true;
			this.dtpStartTime.Size = new System.Drawing.Size(61, 26);
			this.dtpStartTime.TabIndex = 7;
			this.dtpStartTime.Value = new System.DateTime(2017, 9, 4, 0, 0, 0, 0);
			this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
			// 
			// dtpMaxTime
			// 
			this.dtpMaxTime.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtpMaxTime.CustomFormat = "HH:mm";
			this.dtpMaxTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtpMaxTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dtpMaxTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpMaxTime.Location = new System.Drawing.Point(28, 174);
			this.dtpMaxTime.Name = "dtpMaxTime";
			this.dtpMaxTime.ShowUpDown = true;
			this.dtpMaxTime.Size = new System.Drawing.Size(61, 26);
			this.dtpMaxTime.TabIndex = 7;
			this.dtpMaxTime.Value = new System.DateTime(2017, 9, 4, 0, 0, 0, 0);
			this.dtpMaxTime.ValueChanged += new System.EventHandler(this.dtpMaxTime_ValueChanged);
			// 
			// dtpMinTime
			// 
			this.dtpMinTime.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtpMinTime.CustomFormat = "HH:mm";
			this.dtpMinTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtpMinTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dtpMinTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpMinTime.Location = new System.Drawing.Point(28, 242);
			this.dtpMinTime.Name = "dtpMinTime";
			this.dtpMinTime.ShowUpDown = true;
			this.dtpMinTime.Size = new System.Drawing.Size(61, 26);
			this.dtpMinTime.TabIndex = 7;
			this.dtpMinTime.Value = new System.DateTime(2017, 9, 4, 0, 0, 0, 0);
			this.dtpMinTime.ValueChanged += new System.EventHandler(this.dtpMinTime_ValueChanged);
			// 
			// tableLayoutPanel16
			// 
			this.tableLayoutPanel16.ColumnCount = 1;
			this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel16.Controls.Add(this.chart1, 0, 0);
			this.tableLayoutPanel16.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel16.Name = "tableLayoutPanel16";
			this.tableLayoutPanel16.RowCount = 2;
			this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
			this.tableLayoutPanel16.Size = new System.Drawing.Size(752, 460);
			this.tableLayoutPanel16.TabIndex = 3;
			// 
			// chart1
			// 
			chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
			chartArea1.AxisX.IsMarginVisible = false;
			chartArea1.AxisX.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
			chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Transparent;
			chartArea1.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
			chartArea1.AxisX2.IsMarginVisible = false;
			chartArea1.AxisX2.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
			chartArea1.AxisY.IsMarginVisible = false;
			chartArea1.AxisY.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea1.AxisY2.IsMarginVisible = false;
			chartArea1.AxisY2.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.BorderColor = System.Drawing.Color.Gray;
			chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
			chartArea1.CursorX.IsUserEnabled = true;
			chartArea1.CursorX.IsUserSelectionEnabled = true;
			chartArea1.CursorX.LineColor = System.Drawing.Color.LightGray;
			chartArea1.CursorY.IsUserEnabled = true;
			chartArea1.CursorY.IsUserSelectionEnabled = true;
			chartArea1.CursorY.LineColor = System.Drawing.Color.LightGray;
			chartArea1.Name = "ChartArea1";
			chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
			chartArea2.AxisX.IsMarginVisible = false;
			chartArea2.AxisX.LineColor = System.Drawing.Color.Silver;
			chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea2.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
			chartArea2.AxisX2.IsMarginVisible = false;
			chartArea2.AxisX2.LineColor = System.Drawing.Color.Silver;
			chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea2.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
			chartArea2.AxisY.IsMarginVisible = false;
			chartArea2.AxisY.LineColor = System.Drawing.Color.Silver;
			chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea2.AxisY2.IsMarginVisible = false;
			chartArea2.AxisY2.LineColor = System.Drawing.Color.Silver;
			chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.BorderColor = System.Drawing.Color.Gray;
			chartArea2.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
			chartArea2.CursorX.IsUserEnabled = true;
			chartArea2.CursorX.IsUserSelectionEnabled = true;
			chartArea2.CursorX.LineColor = System.Drawing.Color.LightGray;
			chartArea2.CursorY.IsUserEnabled = true;
			chartArea2.CursorY.IsUserSelectionEnabled = true;
			chartArea2.CursorY.LineColor = System.Drawing.Color.LightGray;
			chartArea2.Name = "ChartArea2";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.ChartAreas.Add(chartArea2);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chart1.Location = new System.Drawing.Point(3, 3);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea2";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
			series1.Color = System.Drawing.Color.Wheat;
			series1.Name = "totalSFValue";
			series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
			series2.ChartArea = "ChartArea2";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series2.Name = "mergedSFValue";
			series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
			series3.ChartArea = "ChartArea2";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
			series3.Color = System.Drawing.Color.DarkSeaGreen;
			series3.MarkerSize = 1;
			series3.Name = "IntegratedValue";
			series4.BorderWidth = 8;
			series4.ChartArea = "ChartArea2";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			series4.Color = System.Drawing.Color.Lime;
			series4.MarkerBorderWidth = 8;
			series4.Name = "ValveControl";
			series4.YValuesPerPoint = 2;
			series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.Series.Add(series3);
			this.chart1.Series.Add(series4);
			this.chart1.Size = new System.Drawing.Size(746, 380);
			this.chart1.TabIndex = 1;
			this.chart1.Text = "chart1";
			this.chart1.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chart1_AxisViewChanged_1);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 389);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.listBoxLeft);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listBoxRight);
			this.splitContainer1.Size = new System.Drawing.Size(746, 68);
			this.splitContainer1.SplitterDistance = 258;
			this.splitContainer1.TabIndex = 2;
			// 
			// listBoxLeft
			// 
			this.listBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxLeft.FormattingEnabled = true;
			this.listBoxLeft.ItemHeight = 12;
			this.listBoxLeft.Location = new System.Drawing.Point(0, 0);
			this.listBoxLeft.Name = "listBoxLeft";
			this.listBoxLeft.Size = new System.Drawing.Size(258, 68);
			this.listBoxLeft.TabIndex = 0;
			// 
			// listBoxRight
			// 
			this.listBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxRight.FormattingEnabled = true;
			this.listBoxRight.ItemHeight = 12;
			this.listBoxRight.Location = new System.Drawing.Point(0, 0);
			this.listBoxRight.Name = "listBoxRight";
			this.listBoxRight.Size = new System.Drawing.Size(484, 68);
			this.listBoxRight.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 502);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.cbScale);
			this.flowLayoutPanel1.Controls.Add(this.btScaleFull);
			this.flowLayoutPanel1.Controls.Add(this.btScale3d);
			this.flowLayoutPanel1.Controls.Add(this.btScale1d);
			this.flowLayoutPanel1.Controls.Add(this.btScaleNext);
			this.flowLayoutPanel1.Controls.Add(this.btScalePrevious);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(253, 24);
			this.flowLayoutPanel1.TabIndex = 11;
			// 
			// cbScale
			// 
			this.cbScale.BackColor = System.Drawing.SystemColors.Control;
			this.cbScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbScale.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cbScale.FormattingEnabled = true;
			this.cbScale.Location = new System.Drawing.Point(182, 3);
			this.cbScale.Name = "cbScale";
			this.cbScale.Size = new System.Drawing.Size(68, 20);
			this.cbScale.TabIndex = 3;
			this.cbScale.SelectedIndexChanged += new System.EventHandler(this.cbScale_SelectedIndexChanged);
			// 
			// btScaleFull
			// 
			this.btScaleFull.FlatAppearance.BorderSize = 0;
			this.btScaleFull.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btScaleFull.Location = new System.Drawing.Point(152, 3);
			this.btScaleFull.Name = "btScaleFull";
			this.btScaleFull.Size = new System.Drawing.Size(24, 20);
			this.btScaleFull.TabIndex = 9;
			this.btScaleFull.Text = "F";
			this.btScaleFull.UseVisualStyleBackColor = false;
			this.btScaleFull.Click += new System.EventHandler(this.btScaleFull_Click);
			// 
			// btScale3d
			// 
			this.btScale3d.FlatAppearance.BorderSize = 0;
			this.btScale3d.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btScale3d.Location = new System.Drawing.Point(122, 3);
			this.btScale3d.Name = "btScale3d";
			this.btScale3d.Size = new System.Drawing.Size(24, 20);
			this.btScale3d.TabIndex = 10;
			this.btScale3d.Text = "3";
			this.btScale3d.UseVisualStyleBackColor = false;
			this.btScale3d.Click += new System.EventHandler(this.btScale3d_Click);
			// 
			// btScale1d
			// 
			this.btScale1d.FlatAppearance.BorderSize = 0;
			this.btScale1d.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btScale1d.Location = new System.Drawing.Point(92, 3);
			this.btScale1d.Name = "btScale1d";
			this.btScale1d.Size = new System.Drawing.Size(24, 20);
			this.btScale1d.TabIndex = 11;
			this.btScale1d.Text = "1";
			this.btScale1d.UseVisualStyleBackColor = false;
			this.btScale1d.Click += new System.EventHandler(this.btScale1d_Click);
			// 
			// btScaleNext
			// 
			this.btScaleNext.FlatAppearance.BorderSize = 0;
			this.btScaleNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btScaleNext.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btScaleNext.ForeColor = System.Drawing.Color.DarkGreen;
			this.btScaleNext.Location = new System.Drawing.Point(54, 3);
			this.btScaleNext.Name = "btScaleNext";
			this.btScaleNext.Size = new System.Drawing.Size(32, 20);
			this.btScaleNext.TabIndex = 12;
			this.btScaleNext.Text = ">>";
			this.btScaleNext.UseVisualStyleBackColor = false;
			this.btScaleNext.Click += new System.EventHandler(this.btScaleNext_Click);
			// 
			// btScalePrevious
			// 
			this.btScalePrevious.FlatAppearance.BorderSize = 0;
			this.btScalePrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btScalePrevious.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btScalePrevious.ForeColor = System.Drawing.Color.DarkGreen;
			this.btScalePrevious.Location = new System.Drawing.Point(16, 3);
			this.btScalePrevious.Name = "btScalePrevious";
			this.btScalePrevious.Size = new System.Drawing.Size(32, 20);
			this.btScalePrevious.TabIndex = 13;
			this.btScalePrevious.Text = "<<";
			this.btScalePrevious.UseVisualStyleBackColor = false;
			this.btScalePrevious.Click += new System.EventHandler(this.btScalePrevious_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmValveControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Ivory;
			this.ClientSize = new System.Drawing.Size(893, 569);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmValveControl";
			this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
			this.Text = "Valve Control";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmValveControl_FormClosing);
			this.Load += new System.EventHandler(this.frmValveControl_Load);
			this.tableLayoutPanel12.ResumeLayout(false);
			this.tableLayoutRight.ResumeLayout(false);
			this.tableLayoutRight.PerformLayout();
			this.tableLayoutPanel13.ResumeLayout(false);
			this.tableLayoutPanel15.ResumeLayout(false);
			this.tableLayoutPanel14.ResumeLayout(false);
			this.tableLayoutPanel16.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Button btDataExport;
        private System.Windows.Forms.Button btSetup;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Button btLoadParameter;
        private System.Windows.Forms.Button btSaveParameter;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.Label lbMaxTime;
        private System.Windows.Forms.Label lbMinTime;
        private System.Windows.Forms.TextBox tbEventJoule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Button btStartValveControl;
        private System.Windows.Forms.Button btStopValveControl;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpMaxTime;
        private System.Windows.Forms.DateTimePicker dtpMinTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxLeft;
        private System.Windows.Forms.ListBox listBoxRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cbScale;
        private System.Windows.Forms.Button btScaleFull;
        private System.Windows.Forms.Button btScale3d;
        private System.Windows.Forms.Button btScale1d;
        private System.Windows.Forms.Button btScaleNext;
        private System.Windows.Forms.Button btScalePrevious;
    }
}