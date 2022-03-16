namespace SapflowApplication
{
    partial class frmSfMultiModules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSfMultiModules));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btTitle = new System.Windows.Forms.Button();
            this.btDate = new System.Windows.Forms.Button();
            this.btSF = new System.Windows.Forms.Button();
            this.btRT = new System.Windows.Forms.Button();
            this.btY1 = new System.Windows.Forms.Button();
            this.btY2 = new System.Windows.Forms.Button();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btReflesh = new System.Windows.Forms.Button();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btMaskView = new System.Windows.Forms.Button();
            this.btColorView = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbScale = new System.Windows.Forms.ComboBox();
            this.btScaleFull = new System.Windows.Forms.Button();
            this.btScale2d = new System.Windows.Forms.Button();
            this.btScale1d = new System.Windows.Forms.Button();
            this.btScaleNext = new System.Windows.Forms.Button();
            this.btScalePrevious = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1587, 48);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btTitle);
            this.flowLayoutPanel1.Controls.Add(this.btDate);
            this.flowLayoutPanel1.Controls.Add(this.btSF);
            this.flowLayoutPanel1.Controls.Add(this.btRT);
            this.flowLayoutPanel1.Controls.Add(this.btY1);
            this.flowLayoutPanel1.Controls.Add(this.btY2);
            this.flowLayoutPanel1.Controls.Add(this.lbStartDate);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lbEndDate);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(373, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(634, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btTitle
            // 
            this.btTitle.FlatAppearance.BorderSize = 0;
            this.btTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTitle.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.btTitle.Location = new System.Drawing.Point(4, 4);
            this.btTitle.Margin = new System.Windows.Forms.Padding(4);
            this.btTitle.Name = "btTitle";
            this.btTitle.Size = new System.Drawing.Size(46, 30);
            this.btTitle.TabIndex = 0;
            this.btTitle.Text = "#";
            this.btTitle.UseVisualStyleBackColor = false;
            this.btTitle.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btDate
            // 
            this.btDate.FlatAppearance.BorderSize = 0;
            this.btDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDate.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btDate.ForeColor = System.Drawing.Color.DarkRed;
            this.btDate.Location = new System.Drawing.Point(58, 4);
            this.btDate.Margin = new System.Windows.Forms.Padding(4);
            this.btDate.Name = "btDate";
            this.btDate.Size = new System.Drawing.Size(69, 30);
            this.btDate.TabIndex = 0;
            this.btDate.Text = "Time";
            this.btDate.UseVisualStyleBackColor = false;
            this.btDate.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btSF
            // 
            this.btSF.FlatAppearance.BorderSize = 0;
            this.btSF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSF.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btSF.ForeColor = System.Drawing.Color.DarkRed;
            this.btSF.Location = new System.Drawing.Point(135, 4);
            this.btSF.Margin = new System.Windows.Forms.Padding(4);
            this.btSF.Name = "btSF";
            this.btSF.Size = new System.Drawing.Size(51, 30);
            this.btSF.TabIndex = 0;
            this.btSF.Text = "SF";
            this.btSF.UseVisualStyleBackColor = false;
            this.btSF.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btRT
            // 
            this.btRT.FlatAppearance.BorderSize = 0;
            this.btRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRT.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btRT.ForeColor = System.Drawing.Color.DarkRed;
            this.btRT.Location = new System.Drawing.Point(194, 4);
            this.btRT.Margin = new System.Windows.Forms.Padding(4);
            this.btRT.Name = "btRT";
            this.btRT.Size = new System.Drawing.Size(51, 30);
            this.btRT.TabIndex = 0;
            this.btRT.Text = "RT";
            this.btRT.UseVisualStyleBackColor = false;
            this.btRT.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btY1
            // 
            this.btY1.FlatAppearance.BorderSize = 0;
            this.btY1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btY1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btY1.ForeColor = System.Drawing.Color.DarkRed;
            this.btY1.Location = new System.Drawing.Point(253, 4);
            this.btY1.Margin = new System.Windows.Forms.Padding(4);
            this.btY1.Name = "btY1";
            this.btY1.Size = new System.Drawing.Size(51, 30);
            this.btY1.TabIndex = 0;
            this.btY1.Text = "L1";
            this.btY1.UseVisualStyleBackColor = false;
            this.btY1.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btY2
            // 
            this.btY2.FlatAppearance.BorderSize = 0;
            this.btY2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btY2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btY2.ForeColor = System.Drawing.Color.DarkRed;
            this.btY2.Location = new System.Drawing.Point(312, 4);
            this.btY2.Margin = new System.Windows.Forms.Padding(4);
            this.btY2.Name = "btY2";
            this.btY2.Size = new System.Drawing.Size(51, 30);
            this.btY2.TabIndex = 0;
            this.btY2.Text = "L2";
            this.btY2.UseVisualStyleBackColor = false;
            this.btY2.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStartDate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbStartDate.Location = new System.Drawing.Point(371, 0);
            this.lbStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(54, 20);
            this.lbStartDate.TabIndex = 1;
            this.lbStartDate.Text = "Start";
            this.lbStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(433, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbEndDate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbEndDate.Location = new System.Drawing.Point(470, 0);
            this.lbEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(44, 20);
            this.lbEndDate.TabIndex = 1;
            this.lbEndDate.Text = "End";
            this.lbEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btReflesh);
            this.flowLayoutPanel2.Controls.Add(this.nudHeight);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.nudWidth);
            this.flowLayoutPanel2.Controls.Add(this.btMaskView);
            this.flowLayoutPanel2.Controls.Add(this.btColorView);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1045, 4);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(492, 40);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btReflesh
            // 
            this.btReflesh.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btReflesh.ForeColor = System.Drawing.Color.DarkRed;
            this.btReflesh.Location = new System.Drawing.Point(371, 4);
            this.btReflesh.Margin = new System.Windows.Forms.Padding(4);
            this.btReflesh.Name = "btReflesh";
            this.btReflesh.Size = new System.Drawing.Size(117, 34);
            this.btReflesh.TabIndex = 2;
            this.btReflesh.Text = "Relocate";
            this.btReflesh.UseVisualStyleBackColor = true;
            this.btReflesh.Click += new System.EventHandler(this.btReflesh_Click);
            // 
            // nudHeight
            // 
            this.nudHeight.ForeColor = System.Drawing.Color.DarkRed;
            this.nudHeight.Location = new System.Drawing.Point(306, 4);
            this.nudHeight.Margin = new System.Windows.Forms.Padding(4);
            this.nudHeight.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(57, 28);
            this.nudHeight.TabIndex = 1;
            this.nudHeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "x";
            // 
            // nudWidth
            // 
            this.nudWidth.ForeColor = System.Drawing.Color.DarkRed;
            this.nudWidth.Location = new System.Drawing.Point(215, 4);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(4);
            this.nudWidth.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(57, 28);
            this.nudWidth.TabIndex = 0;
            this.nudWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // btMaskView
            // 
            this.btMaskView.FlatAppearance.BorderSize = 0;
            this.btMaskView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaskView.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btMaskView.ForeColor = System.Drawing.Color.DarkRed;
            this.btMaskView.Location = new System.Drawing.Point(136, 4);
            this.btMaskView.Margin = new System.Windows.Forms.Padding(4);
            this.btMaskView.Name = "btMaskView";
            this.btMaskView.Size = new System.Drawing.Size(71, 30);
            this.btMaskView.TabIndex = 0;
            this.btMaskView.Text = "Mask";
            this.btMaskView.UseVisualStyleBackColor = false;
            this.btMaskView.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btColorView
            // 
            this.btColorView.FlatAppearance.BorderSize = 0;
            this.btColorView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btColorView.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btColorView.ForeColor = System.Drawing.Color.DarkRed;
            this.btColorView.Location = new System.Drawing.Point(51, 4);
            this.btColorView.Margin = new System.Windows.Forms.Padding(4);
            this.btColorView.Name = "btColorView";
            this.btColorView.Size = new System.Drawing.Size(77, 30);
            this.btColorView.TabIndex = 0;
            this.btColorView.Text = "Color";
            this.btColorView.UseVisualStyleBackColor = false;
            this.btColorView.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.cbScale);
            this.flowLayoutPanel3.Controls.Add(this.btScaleFull);
            this.flowLayoutPanel3.Controls.Add(this.btScale2d);
            this.flowLayoutPanel3.Controls.Add(this.btScale1d);
            this.flowLayoutPanel3.Controls.Add(this.btScaleNext);
            this.flowLayoutPanel3.Controls.Add(this.btScalePrevious);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(360, 39);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // cbScale
            // 
            this.cbScale.BackColor = System.Drawing.SystemColors.Control;
            this.cbScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScale.ForeColor = System.Drawing.Color.DarkRed;
            this.cbScale.FormattingEnabled = true;
            this.cbScale.Location = new System.Drawing.Point(261, 4);
            this.cbScale.Margin = new System.Windows.Forms.Padding(4);
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(95, 26);
            this.cbScale.TabIndex = 0;
            this.cbScale.SelectedIndexChanged += new System.EventHandler(this.cbScale_SelectedIndexChanged);
            // 
            // btScaleFull
            // 
            this.btScaleFull.FlatAppearance.BorderSize = 0;
            this.btScaleFull.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScaleFull.ForeColor = System.Drawing.Color.DarkRed;
            this.btScaleFull.Location = new System.Drawing.Point(219, 4);
            this.btScaleFull.Margin = new System.Windows.Forms.Padding(4);
            this.btScaleFull.Name = "btScaleFull";
            this.btScaleFull.Size = new System.Drawing.Size(34, 30);
            this.btScaleFull.TabIndex = 0;
            this.btScaleFull.Text = "F";
            this.btScaleFull.UseVisualStyleBackColor = false;
            this.btScaleFull.Click += new System.EventHandler(this.btScaleFull_Click);
            // 
            // btScale2d
            // 
            this.btScale2d.FlatAppearance.BorderSize = 0;
            this.btScale2d.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScale2d.ForeColor = System.Drawing.Color.DarkRed;
            this.btScale2d.Location = new System.Drawing.Point(177, 4);
            this.btScale2d.Margin = new System.Windows.Forms.Padding(4);
            this.btScale2d.Name = "btScale2d";
            this.btScale2d.Size = new System.Drawing.Size(34, 30);
            this.btScale2d.TabIndex = 0;
            this.btScale2d.Text = "3";
            this.btScale2d.UseVisualStyleBackColor = false;
            this.btScale2d.Click += new System.EventHandler(this.btScale3d_Click);
            // 
            // btScale1d
            // 
            this.btScale1d.FlatAppearance.BorderSize = 0;
            this.btScale1d.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScale1d.ForeColor = System.Drawing.Color.DarkRed;
            this.btScale1d.Location = new System.Drawing.Point(135, 4);
            this.btScale1d.Margin = new System.Windows.Forms.Padding(4);
            this.btScale1d.Name = "btScale1d";
            this.btScale1d.Size = new System.Drawing.Size(34, 30);
            this.btScale1d.TabIndex = 0;
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
            this.btScaleNext.Location = new System.Drawing.Point(81, 4);
            this.btScaleNext.Margin = new System.Windows.Forms.Padding(4);
            this.btScaleNext.Name = "btScaleNext";
            this.btScaleNext.Size = new System.Drawing.Size(46, 30);
            this.btScaleNext.TabIndex = 0;
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
            this.btScalePrevious.Location = new System.Drawing.Point(27, 4);
            this.btScalePrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btScalePrevious.Name = "btScalePrevious";
            this.btScalePrevious.Size = new System.Drawing.Size(46, 30);
            this.btScalePrevious.TabIndex = 0;
            this.btScalePrevious.Text = "<<";
            this.btScalePrevious.UseVisualStyleBackColor = false;
            this.btScalePrevious.Click += new System.EventHandler(this.btScalePrevious_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1587, 644);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSfMultiModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1587, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSfMultiModules";
            this.Text = "Real Multi Modules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSfMultiModules_FormClosing);
            this.Load += new System.EventHandler(this.SfMultiModules_Load);
            this.ResizeEnd += new System.EventHandler(this.frmSfMultiModules_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmSfMultiModules_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btTitle;
        private System.Windows.Forms.Button btDate;
        private System.Windows.Forms.Button btY1;
        private System.Windows.Forms.Button btY2;
        private System.Windows.Forms.Button btSF;
        private System.Windows.Forms.Button btRT;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Button btReflesh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox cbScale;
        private System.Windows.Forms.Button btScale1d;
        private System.Windows.Forms.Button btScale2d;
        private System.Windows.Forms.Button btScaleFull;
        private System.Windows.Forms.Button btScaleNext;
        private System.Windows.Forms.Button btScalePrevious;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btMaskView;
        private System.Windows.Forms.Button btColorView;
    }
}