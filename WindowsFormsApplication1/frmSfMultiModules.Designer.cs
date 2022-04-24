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
            this.btTitle = new ReaLTaiizor.Controls.MaterialButton();
            this.btDate = new ReaLTaiizor.Controls.MaterialButton();
            this.btSF = new ReaLTaiizor.Controls.MaterialButton();
            this.btRT = new ReaLTaiizor.Controls.MaterialButton();
            this.btY1 = new ReaLTaiizor.Controls.MaterialButton();
            this.btY2 = new ReaLTaiizor.Controls.MaterialButton();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btReflesh = new ReaLTaiizor.Controls.MaterialButton();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btMaskView = new ReaLTaiizor.Controls.MaterialButton();
            this.btColorView = new ReaLTaiizor.Controls.MaterialButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbScale = new ReaLTaiizor.Controls.MaterialComboBox();
            this.btScaleFull = new ReaLTaiizor.Controls.MaterialButton();
            this.btScale2d = new ReaLTaiizor.Controls.MaterialButton();
            this.btScale1d = new ReaLTaiizor.Controls.MaterialButton();
            this.btScaleNext = new ReaLTaiizor.Controls.MaterialButton();
            this.btScalePrevious = new ReaLTaiizor.Controls.MaterialButton();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1107, 50);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(345, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 42);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btTitle
            // 
            this.btTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTitle.Depth = 0;
            this.btTitle.DrawShadows = true;
            this.btTitle.FlatAppearance.BorderSize = 0;
            this.btTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTitle.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.btTitle.HighEmphasis = true;
            this.btTitle.Icon = null;
            this.btTitle.Location = new System.Drawing.Point(4, 6);
            this.btTitle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTitle.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTitle.Name = "btTitle";
            this.btTitle.Size = new System.Drawing.Size(30, 36);
            this.btTitle.TabIndex = 0;
            this.btTitle.Text = "#";
            this.btTitle.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTitle.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTitle.UseAccentColor = false;
            this.btTitle.UseVisualStyleBackColor = false;
            this.btTitle.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btDate
            // 
            this.btDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btDate.Depth = 0;
            this.btDate.DrawShadows = true;
            this.btDate.FlatAppearance.BorderSize = 0;
            this.btDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDate.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btDate.ForeColor = System.Drawing.Color.DarkRed;
            this.btDate.HighEmphasis = true;
            this.btDate.Icon = null;
            this.btDate.Location = new System.Drawing.Point(42, 6);
            this.btDate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btDate.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btDate.Name = "btDate";
            this.btDate.Size = new System.Drawing.Size(55, 36);
            this.btDate.TabIndex = 0;
            this.btDate.Text = "Time";
            this.btDate.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btDate.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btDate.UseAccentColor = false;
            this.btDate.UseVisualStyleBackColor = false;
            this.btDate.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btSF
            // 
            this.btSF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSF.Depth = 0;
            this.btSF.DrawShadows = true;
            this.btSF.FlatAppearance.BorderSize = 0;
            this.btSF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSF.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btSF.ForeColor = System.Drawing.Color.DarkRed;
            this.btSF.HighEmphasis = true;
            this.btSF.Icon = null;
            this.btSF.Location = new System.Drawing.Point(105, 6);
            this.btSF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSF.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btSF.Name = "btSF";
            this.btSF.Size = new System.Drawing.Size(38, 36);
            this.btSF.TabIndex = 0;
            this.btSF.Text = "SF";
            this.btSF.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btSF.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btSF.UseAccentColor = false;
            this.btSF.UseVisualStyleBackColor = false;
            this.btSF.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btRT
            // 
            this.btRT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btRT.Depth = 0;
            this.btRT.DrawShadows = true;
            this.btRT.FlatAppearance.BorderSize = 0;
            this.btRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRT.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btRT.ForeColor = System.Drawing.Color.DarkRed;
            this.btRT.HighEmphasis = true;
            this.btRT.Icon = null;
            this.btRT.Location = new System.Drawing.Point(151, 6);
            this.btRT.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btRT.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btRT.Name = "btRT";
            this.btRT.Size = new System.Drawing.Size(39, 36);
            this.btRT.TabIndex = 0;
            this.btRT.Text = "RT";
            this.btRT.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btRT.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btRT.UseAccentColor = false;
            this.btRT.UseVisualStyleBackColor = false;
            this.btRT.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btY1
            // 
            this.btY1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btY1.Depth = 0;
            this.btY1.DrawShadows = true;
            this.btY1.FlatAppearance.BorderSize = 0;
            this.btY1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btY1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btY1.ForeColor = System.Drawing.Color.DarkRed;
            this.btY1.HighEmphasis = true;
            this.btY1.Icon = null;
            this.btY1.Location = new System.Drawing.Point(198, 6);
            this.btY1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btY1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btY1.Name = "btY1";
            this.btY1.Size = new System.Drawing.Size(38, 36);
            this.btY1.TabIndex = 0;
            this.btY1.Text = "L1";
            this.btY1.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btY1.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btY1.UseAccentColor = false;
            this.btY1.UseVisualStyleBackColor = false;
            this.btY1.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btY2
            // 
            this.btY2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btY2.Depth = 0;
            this.btY2.DrawShadows = true;
            this.btY2.FlatAppearance.BorderSize = 0;
            this.btY2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btY2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btY2.ForeColor = System.Drawing.Color.DarkRed;
            this.btY2.HighEmphasis = true;
            this.btY2.Icon = null;
            this.btY2.Location = new System.Drawing.Point(244, 6);
            this.btY2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btY2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btY2.Name = "btY2";
            this.btY2.Size = new System.Drawing.Size(38, 36);
            this.btY2.TabIndex = 0;
            this.btY2.Text = "L2";
            this.btY2.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btY2.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btY2.UseAccentColor = false;
            this.btY2.UseVisualStyleBackColor = false;
            this.btY2.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStartDate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbStartDate.Location = new System.Drawing.Point(289, 0);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(40, 13);
            this.lbStartDate.TabIndex = 1;
            this.lbStartDate.Text = "Start";
            this.lbStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(335, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbEndDate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbEndDate.Location = new System.Drawing.Point(360, 0);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(34, 13);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(763, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(331, 50);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btReflesh
            // 
            this.btReflesh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btReflesh.Depth = 0;
            this.btReflesh.DrawShadows = true;
            this.btReflesh.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btReflesh.ForeColor = System.Drawing.Color.DarkRed;
            this.btReflesh.HighEmphasis = true;
            this.btReflesh.Icon = null;
            this.btReflesh.Location = new System.Drawing.Point(248, 6);
            this.btReflesh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btReflesh.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btReflesh.Name = "btReflesh";
            this.btReflesh.Size = new System.Drawing.Size(79, 36);
            this.btReflesh.TabIndex = 2;
            this.btReflesh.Text = "Relocate";
            this.btReflesh.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btReflesh.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btReflesh.UseAccentColor = false;
            this.btReflesh.UseVisualStyleBackColor = true;
            this.btReflesh.Click += new System.EventHandler(this.btReflesh_Click);
            // 
            // nudHeight
            // 
            this.nudHeight.AutoSize = true;
            this.nudHeight.Font = new System.Drawing.Font("굴림", 12F);
            this.nudHeight.ForeColor = System.Drawing.Color.DarkRed;
            this.nudHeight.Location = new System.Drawing.Point(200, 10);
            this.nudHeight.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
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
            this.nudHeight.Size = new System.Drawing.Size(41, 26);
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
            this.label1.Location = new System.Drawing.Point(182, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "x";
            // 
            // nudWidth
            // 
            this.nudWidth.AutoSize = true;
            this.nudWidth.Font = new System.Drawing.Font("굴림", 12F);
            this.nudWidth.ForeColor = System.Drawing.Color.DarkRed;
            this.nudWidth.Location = new System.Drawing.Point(135, 10);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
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
            this.nudWidth.Size = new System.Drawing.Size(41, 26);
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
            this.btMaskView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btMaskView.Depth = 0;
            this.btMaskView.DrawShadows = true;
            this.btMaskView.FlatAppearance.BorderSize = 0;
            this.btMaskView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaskView.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btMaskView.ForeColor = System.Drawing.Color.DarkRed;
            this.btMaskView.HighEmphasis = true;
            this.btMaskView.Icon = null;
            this.btMaskView.Location = new System.Drawing.Point(71, 6);
            this.btMaskView.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btMaskView.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btMaskView.Name = "btMaskView";
            this.btMaskView.Size = new System.Drawing.Size(57, 36);
            this.btMaskView.TabIndex = 0;
            this.btMaskView.Text = "Mask";
            this.btMaskView.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btMaskView.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btMaskView.UseAccentColor = false;
            this.btMaskView.UseVisualStyleBackColor = false;
            this.btMaskView.Click += new System.EventHandler(this.btDataOn_Click);
            // 
            // btColorView
            // 
            this.btColorView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btColorView.Depth = 0;
            this.btColorView.DrawShadows = true;
            this.btColorView.FlatAppearance.BorderSize = 0;
            this.btColorView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btColorView.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btColorView.ForeColor = System.Drawing.Color.DarkRed;
            this.btColorView.HighEmphasis = true;
            this.btColorView.Icon = null;
            this.btColorView.Location = new System.Drawing.Point(6, 6);
            this.btColorView.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btColorView.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btColorView.Name = "btColorView";
            this.btColorView.Size = new System.Drawing.Size(57, 36);
            this.btColorView.TabIndex = 0;
            this.btColorView.Text = "Color";
            this.btColorView.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btColorView.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btColorView.UseAccentColor = false;
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
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(336, 42);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // cbScale
            // 
            this.cbScale.AutoResize = true;
            this.cbScale.BackColor = System.Drawing.SystemColors.Control;
            this.cbScale.Depth = 0;
            this.cbScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbScale.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbScale.DropDownHeight = 118;
            this.cbScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScale.DropDownWidth = 121;
            this.cbScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbScale.ForeColor = System.Drawing.Color.DarkRed;
            this.cbScale.FormattingEnabled = true;
            this.cbScale.IntegralHeight = false;
            this.cbScale.ItemHeight = 29;
            this.cbScale.Location = new System.Drawing.Point(212, 3);
            this.cbScale.MaxDropDownItems = 4;
            this.cbScale.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(121, 35);
            this.cbScale.StartIndex = 0;
            this.cbScale.TabIndex = 0;
            this.cbScale.UseTallSize = false;
            this.cbScale.SelectedIndexChanged += new System.EventHandler(this.cbScale_SelectedIndexChanged);
            // 
            // btScaleFull
            // 
            this.btScaleFull.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btScaleFull.Depth = 0;
            this.btScaleFull.DrawShadows = true;
            this.btScaleFull.FlatAppearance.BorderSize = 0;
            this.btScaleFull.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScaleFull.ForeColor = System.Drawing.Color.DarkRed;
            this.btScaleFull.HighEmphasis = true;
            this.btScaleFull.Icon = null;
            this.btScaleFull.Location = new System.Drawing.Point(176, 6);
            this.btScaleFull.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btScaleFull.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btScaleFull.Name = "btScaleFull";
            this.btScaleFull.Size = new System.Drawing.Size(29, 36);
            this.btScaleFull.TabIndex = 0;
            this.btScaleFull.Text = "F";
            this.btScaleFull.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btScaleFull.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btScaleFull.UseAccentColor = false;
            this.btScaleFull.UseVisualStyleBackColor = false;
            this.btScaleFull.Click += new System.EventHandler(this.btScaleFull_Click);
            // 
            // btScale2d
            // 
            this.btScale2d.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btScale2d.Depth = 0;
            this.btScale2d.DrawShadows = true;
            this.btScale2d.FlatAppearance.BorderSize = 0;
            this.btScale2d.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScale2d.ForeColor = System.Drawing.Color.DarkRed;
            this.btScale2d.HighEmphasis = true;
            this.btScale2d.Icon = null;
            this.btScale2d.Location = new System.Drawing.Point(138, 6);
            this.btScale2d.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btScale2d.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btScale2d.Name = "btScale2d";
            this.btScale2d.Size = new System.Drawing.Size(30, 36);
            this.btScale2d.TabIndex = 0;
            this.btScale2d.Text = "3";
            this.btScale2d.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btScale2d.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btScale2d.UseAccentColor = false;
            this.btScale2d.UseVisualStyleBackColor = false;
            this.btScale2d.Click += new System.EventHandler(this.btScale3d_Click);
            // 
            // btScale1d
            // 
            this.btScale1d.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btScale1d.Depth = 0;
            this.btScale1d.DrawShadows = true;
            this.btScale1d.FlatAppearance.BorderSize = 0;
            this.btScale1d.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScale1d.ForeColor = System.Drawing.Color.DarkRed;
            this.btScale1d.HighEmphasis = true;
            this.btScale1d.Icon = null;
            this.btScale1d.Location = new System.Drawing.Point(100, 6);
            this.btScale1d.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btScale1d.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btScale1d.Name = "btScale1d";
            this.btScale1d.Size = new System.Drawing.Size(30, 36);
            this.btScale1d.TabIndex = 0;
            this.btScale1d.Text = "1";
            this.btScale1d.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btScale1d.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btScale1d.UseAccentColor = false;
            this.btScale1d.UseVisualStyleBackColor = false;
            this.btScale1d.Click += new System.EventHandler(this.btScale1d_Click);
            // 
            // btScaleNext
            // 
            this.btScaleNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btScaleNext.Depth = 0;
            this.btScaleNext.DrawShadows = true;
            this.btScaleNext.FlatAppearance.BorderSize = 0;
            this.btScaleNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btScaleNext.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScaleNext.ForeColor = System.Drawing.Color.DarkGreen;
            this.btScaleNext.HighEmphasis = true;
            this.btScaleNext.Icon = null;
            this.btScaleNext.Location = new System.Drawing.Point(55, 6);
            this.btScaleNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btScaleNext.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btScaleNext.Name = "btScaleNext";
            this.btScaleNext.Size = new System.Drawing.Size(37, 36);
            this.btScaleNext.TabIndex = 0;
            this.btScaleNext.Text = ">>";
            this.btScaleNext.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btScaleNext.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btScaleNext.UseAccentColor = false;
            this.btScaleNext.UseVisualStyleBackColor = false;
            this.btScaleNext.Click += new System.EventHandler(this.btScaleNext_Click);
            // 
            // btScalePrevious
            // 
            this.btScalePrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btScalePrevious.Depth = 0;
            this.btScalePrevious.DrawShadows = true;
            this.btScalePrevious.FlatAppearance.BorderSize = 0;
            this.btScalePrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btScalePrevious.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btScalePrevious.ForeColor = System.Drawing.Color.DarkGreen;
            this.btScalePrevious.HighEmphasis = true;
            this.btScalePrevious.Icon = null;
            this.btScalePrevious.Location = new System.Drawing.Point(11, 6);
            this.btScalePrevious.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btScalePrevious.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btScalePrevious.Name = "btScalePrevious";
            this.btScalePrevious.Size = new System.Drawing.Size(36, 36);
            this.btScalePrevious.TabIndex = 0;
            this.btScalePrevious.Text = "<<";
            this.btScalePrevious.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btScalePrevious.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btScalePrevious.UseAccentColor = false;
            this.btScalePrevious.UseVisualStyleBackColor = false;
            this.btScalePrevious.Click += new System.EventHandler(this.btScalePrevious_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 345);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1111, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmSfMultiModules";
            this.Padding = new System.Windows.Forms.Padding(2, 64, 2, 2);
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
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialButton btTitle;
        private ReaLTaiizor.Controls.MaterialButton btDate;
        private ReaLTaiizor.Controls.MaterialButton btY1;
        private ReaLTaiizor.Controls.MaterialButton btY2;
        private ReaLTaiizor.Controls.MaterialButton btSF;
        private ReaLTaiizor.Controls.MaterialButton btRT;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private ReaLTaiizor.Controls.MaterialButton btReflesh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ReaLTaiizor.Controls.MaterialComboBox cbScale;
        private ReaLTaiizor.Controls.MaterialButton btScale1d;
        private ReaLTaiizor.Controls.MaterialButton btScale2d;
        private ReaLTaiizor.Controls.MaterialButton btScaleFull;
        private ReaLTaiizor.Controls.MaterialButton btScaleNext;
        private ReaLTaiizor.Controls.MaterialButton btScalePrevious;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.MaterialButton btMaskView;
        private ReaLTaiizor.Controls.MaterialButton btColorView;
    }
}