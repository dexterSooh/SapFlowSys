using System.Windows.Forms;

namespace SapflowApplication
{
    partial class NewForm2_Demo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewForm2_Demo));
            this.materialTabControl1 = new ReaLTaiizor.Controls.MaterialTabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.button6 = new ReaLTaiizor.Controls.MaterialButton();
            this.btRefresh = new ReaLTaiizor.Controls.MaterialButton();
            this.btLog = new ReaLTaiizor.Controls.MaterialButton();
            this.btBackupLog = new ReaLTaiizor.Controls.MaterialButton();
            this.btExportSF = new ReaLTaiizor.Controls.MaterialButton();
            this.btStopAction = new ReaLTaiizor.Controls.MaterialButton();
            this.btStartAction = new ReaLTaiizor.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbSettings = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.btConnectControl = new ReaLTaiizor.Controls.MaterialButton();
            this.cbComPort = new ReaLTaiizor.Controls.MaterialComboBox();
            this.groupBox2 = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.btTimeScale1D = new ReaLTaiizor.Controls.MaterialButton();
            this.btTimeScaleFullScale = new ReaLTaiizor.Controls.MaterialButton();
            this.btTimeScale2d = new ReaLTaiizor.Controls.MaterialButton();
            this.btTimeScale2H = new ReaLTaiizor.Controls.MaterialButton();
            this.cbTimeStep = new ReaLTaiizor.Controls.MaterialComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbSfModule = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new ReaLTaiizor.Controls.MaterialLabel();
            this.btSFModuleSelectionNumberPrevious = new ReaLTaiizor.Controls.MaterialButton();
            this.btGraphOpen = new ReaLTaiizor.Controls.MaterialButton();
            this.btCalibration = new ReaLTaiizor.Controls.MaterialButton();
            this.btSFModuleSelectionNumberNext = new ReaLTaiizor.Controls.MaterialButton();
            this.cbSFModuleSelectionNumber = new ReaLTaiizor.Controls.MaterialComboBox();
            this.btMultiViewOpen = new ReaLTaiizor.Controls.MaterialButton();
            this.progressBar1 = new ReaLTaiizor.Controls.MaterialProgressBar();
            this.gbChannel = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new ReaLTaiizor.Controls.MaterialLabel();
            this.lbTemperature = new ReaLTaiizor.Controls.MaterialLabel();
            this.lbHumidity = new ReaLTaiizor.Controls.MaterialLabel();
            this.label9 = new ReaLTaiizor.Controls.MaterialLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbY1Max = new ReaLTaiizor.Controls.MaterialTextBox();
            this.tbY1Min = new ReaLTaiizor.Controls.MaterialTextBox();
            this.cbDisposeData = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.tbY2Min = new ReaLTaiizor.Controls.MaterialTextBox();
            this.cbY1Min = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.cbY2Min = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.cbY2Max = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.tbY2Max = new ReaLTaiizor.Controls.MaterialTextBox();
            this.cbY1Max = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.label2 = new ReaLTaiizor.Controls.MaterialLabel();
            this.label3 = new ReaLTaiizor.Controls.MaterialLabel();
            this.label4 = new ReaLTaiizor.Controls.MaterialLabel();
            this.label5 = new ReaLTaiizor.Controls.MaterialLabel();
            this.label6 = new ReaLTaiizor.Controls.MaterialLabel();
            this.label7 = new ReaLTaiizor.Controls.MaterialLabel();
            this.tbY1MinValue = new ReaLTaiizor.Controls.MaterialTextBox();
            this.tbY2MinValue = new ReaLTaiizor.Controls.MaterialTextBox();
            this.tbY1MaxValue = new ReaLTaiizor.Controls.MaterialTextBox();
            this.tbY2MaxValue = new ReaLTaiizor.Controls.MaterialTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btParaReset_Offset = new ReaLTaiizor.Controls.MaterialButton();
            this.btParaSet_Offset = new ReaLTaiizor.Controls.MaterialButton();
            this.tbParaSet_Tm_Offset = new ReaLTaiizor.Controls.MaterialTextBox();
            this.label18 = new ReaLTaiizor.Controls.MaterialLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbCH1 = new ReaLTaiizor.Controls.MaterialRadioButton();
            this.rbCH2 = new ReaLTaiizor.Controls.MaterialRadioButton();
            this.rbCH3 = new ReaLTaiizor.Controls.MaterialRadioButton();
            this.rbCH4 = new ReaLTaiizor.Controls.MaterialRadioButton();
            this.lbStartTime = new ReaLTaiizor.Controls.MaterialLabel();
            this.lbDateTime = new ReaLTaiizor.Controls.MaterialLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label17 = new ReaLTaiizor.Controls.MaterialLabel();
            this.label16 = new ReaLTaiizor.Controls.MaterialLabel();
            this.AB_tb = new ReaLTaiizor.Controls.MaterialTextBox();
            this.AB_check = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.label15 = new ReaLTaiizor.Controls.MaterialLabel();
            this.AB_count = new ReaLTaiizor.Controls.MaterialLabel();
            this.lbExtendScreen = new ReaLTaiizor.Controls.MaterialLabel();
            this.btWindowExtend = new ReaLTaiizor.Controls.MaterialButton();
            this.label20 = new ReaLTaiizor.Controls.MaterialLabel();
            this.cbBackupTerm = new ReaLTaiizor.Controls.MaterialComboBox();
            this.btBackupLogDay = new ReaLTaiizor.Controls.MaterialButton();
            this.listBox2 = new ReaLTaiizor.Controls.DungeonListBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbLockControl = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.cbAlwaysOnTop = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gbSystemSetting = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.btSetup = new ReaLTaiizor.Controls.MaterialButton();
            this.btSavePreset = new ReaLTaiizor.Controls.MaterialButton();
            this.btLoadPreset = new ReaLTaiizor.Controls.MaterialButton();
            this.btMinMaxfrimVC = new ReaLTaiizor.Controls.MaterialButton();
            this.btMinMaxtoVC = new ReaLTaiizor.Controls.MaterialButton();
            this.btUpdateCOM = new ReaLTaiizor.Controls.MaterialButton();
            this.button3 = new ReaLTaiizor.Controls.MaterialButton();
            this.gbValveControl = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.btValve = new ReaLTaiizor.Controls.MaterialButton();
            this.btValveEventAbort = new ReaLTaiizor.Controls.MaterialButton();
            this.label11 = new ReaLTaiizor.Controls.MaterialLabel();
            this.btValveEventOn = new ReaLTaiizor.Controls.MaterialButton();
            this.nUDEmergencyNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new ReaLTaiizor.Controls.MaterialLabel();
            this.cbValveControlEnable = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.btValveControlGraph = new ReaLTaiizor.Controls.MaterialButton();
            this.btValveControlSetup = new ReaLTaiizor.Controls.MaterialButton();
            this.cbDisposeVCData = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.gbDebugSetting = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.btCmdSendFinish = new ReaLTaiizor.Controls.MaterialButton();
            this.btCmdSendStart = new ReaLTaiizor.Controls.MaterialButton();
            this.btCmdSendTUR = new ReaLTaiizor.Controls.MaterialButton();
            this.nudModuleNumber = new System.Windows.Forms.NumericUpDown();
            this.label10 = new ReaLTaiizor.Controls.MaterialLabel();
            this.cbDebugLog = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.btCopyBox2 = new ReaLTaiizor.Controls.MaterialButton();
            this.tbDebugLevel = new ReaLTaiizor.Controls.MaterialTextBox();
            this.btCopyBox1 = new ReaLTaiizor.Controls.MaterialButton();
            this.label12 = new ReaLTaiizor.Controls.MaterialLabel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cbAutoStart = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.listBox1 = new ReaLTaiizor.Controls.DungeonListBox();
            this.gbParameterSetting = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.cbTCompensation = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbParaSet_Tm = new ReaLTaiizor.Controls.MaterialTextBox();
            this.label24 = new ReaLTaiizor.Controls.MaterialLabel();
            this.lbParameterMxCx = new ReaLTaiizor.Controls.MaterialLabel();
            this.btParaSetAll = new ReaLTaiizor.Controls.MaterialButton();
            this.btParaSet = new ReaLTaiizor.Controls.MaterialButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbParaSet_c = new ReaLTaiizor.Controls.MaterialTextBox();
            this.tbParaSet_a = new ReaLTaiizor.Controls.MaterialTextBox();
            this.lbParameterC = new ReaLTaiizor.Controls.MaterialLabel();
            this.lbParameterB = new ReaLTaiizor.Controls.MaterialLabel();
            this.lbParameterA = new ReaLTaiizor.Controls.MaterialLabel();
            this.tbParaSet_b = new ReaLTaiizor.Controls.MaterialTextBox();
            this.btTmAdjustLast = new ReaLTaiizor.Controls.MaterialButton();
            this.btTmAdjustAll = new ReaLTaiizor.Controls.MaterialButton();
            this.btTmAdjust = new ReaLTaiizor.Controls.MaterialButton();
            this.btExitFactoryMode = new ReaLTaiizor.Controls.MaterialButton();
            this.cbDataFilterON = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.btTmAdaptive = new ReaLTaiizor.Controls.MaterialButton();
            this.label14 = new ReaLTaiizor.Controls.MaterialLabel();
            this.label13 = new ReaLTaiizor.Controls.MaterialLabel();
            this.menuIconList = new System.Windows.Forms.ImageList(this.components);
            this.materialContextMenuStrip1 = new ReaLTaiizor.Controls.MaterialContextMenuStrip();
            this.item1ToolStripMenuItem = new ReaLTaiizor.Controls.MaterialToolStripMenuItem();
            this.subItem1ToolStripMenuItem = new ReaLTaiizor.Controls.MaterialToolStripMenuItem();
            this.subItem2ToolStripMenuItem = new ReaLTaiizor.Controls.MaterialToolStripMenuItem();
            this.disabledItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item2ToolStripMenuItem = new ReaLTaiizor.Controls.MaterialToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.item3ToolStripMenuItem = new ReaLTaiizor.Controls.MaterialToolStripMenuItem();
            this.materialTabControl1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbSfModule.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbChannel.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gbSystemSetting.SuspendLayout();
            this.gbValveControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEmergencyNumber)).BeginInit();
            this.gbDebugSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModuleNumber)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.gbParameterSetting.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage7);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Controls.Add(this.tabPage5);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.menuIconList;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1023, 555);
            this.materialTabControl1.TabIndex = 18;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.White;
            this.tabPage7.Controls.Add(this.flowLayoutPanel6);
            this.tabPage7.Controls.Add(this.btStopAction);
            this.tabPage7.Controls.Add(this.btStartAction);
            this.tabPage7.Controls.Add(this.pictureBox1);
            this.tabPage7.Controls.Add(this.gbSettings);
            this.tabPage7.Controls.Add(this.groupBox2);
            this.tabPage7.ImageKey = "round_gps_fixed_white_24dp.png";
            this.tabPage7.Location = new System.Drawing.Point(4, 31);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1015, 520);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Serial Setting";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.button6);
            this.flowLayoutPanel6.Controls.Add(this.btRefresh);
            this.flowLayoutPanel6.Controls.Add(this.btLog);
            this.flowLayoutPanel6.Controls.Add(this.btBackupLog);
            this.flowLayoutPanel6.Controls.Add(this.btExportSF);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(212, 90);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(396, 58);
            this.flowLayoutPanel6.TabIndex = 55;
            // 
            // button6
            // 
            this.button6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button6.Depth = 0;
            this.button6.DrawShadows = true;
            this.button6.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.ForeColor = System.Drawing.Color.DarkRed;
            this.button6.HighEmphasis = true;
            this.button6.Icon = null;
            this.button6.Location = new System.Drawing.Point(4, 6);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button6.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 36);
            this.button6.TabIndex = 56;
            this.button6.Text = "Setup";
            this.button6.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.button6.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button6.UseAccentColor = false;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btRefresh.Depth = 0;
            this.btRefresh.DrawShadows = true;
            this.btRefresh.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btRefresh.ForeColor = System.Drawing.Color.DarkRed;
            this.btRefresh.HighEmphasis = true;
            this.btRefresh.Icon = null;
            this.btRefresh.Location = new System.Drawing.Point(72, 6);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btRefresh.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(56, 36);
            this.btRefresh.TabIndex = 35;
            this.btRefresh.Text = "Clear";
            this.btRefresh.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btRefresh.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btRefresh.UseAccentColor = false;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btLog
            // 
            this.btLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btLog.Depth = 0;
            this.btLog.DrawShadows = true;
            this.btLog.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btLog.ForeColor = System.Drawing.Color.DarkRed;
            this.btLog.HighEmphasis = true;
            this.btLog.Icon = null;
            this.btLog.Location = new System.Drawing.Point(136, 6);
            this.btLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btLog.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btLog.Name = "btLog";
            this.btLog.Size = new System.Drawing.Size(46, 36);
            this.btLog.TabIndex = 35;
            this.btLog.Text = "Log";
            this.btLog.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btLog.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btLog.UseAccentColor = false;
            this.btLog.UseVisualStyleBackColor = true;
            // 
            // btBackupLog
            // 
            this.btBackupLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btBackupLog.Depth = 0;
            this.btBackupLog.DrawShadows = true;
            this.btBackupLog.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btBackupLog.ForeColor = System.Drawing.Color.DarkRed;
            this.btBackupLog.HighEmphasis = true;
            this.btBackupLog.Icon = null;
            this.btBackupLog.Location = new System.Drawing.Point(190, 6);
            this.btBackupLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btBackupLog.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btBackupLog.Name = "btBackupLog";
            this.btBackupLog.Size = new System.Drawing.Size(71, 36);
            this.btBackupLog.TabIndex = 40;
            this.btBackupLog.Text = "Backup";
            this.btBackupLog.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btBackupLog.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btBackupLog.UseAccentColor = false;
            this.btBackupLog.UseVisualStyleBackColor = true;
            // 
            // btExportSF
            // 
            this.btExportSF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btExportSF.Depth = 0;
            this.btExportSF.DrawShadows = true;
            this.btExportSF.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExportSF.ForeColor = System.Drawing.Color.DarkRed;
            this.btExportSF.HighEmphasis = true;
            this.btExportSF.Icon = null;
            this.btExportSF.Location = new System.Drawing.Point(269, 6);
            this.btExportSF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btExportSF.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btExportSF.Name = "btExportSF";
            this.btExportSF.Size = new System.Drawing.Size(85, 36);
            this.btExportSF.TabIndex = 40;
            this.btExportSF.Text = "Export SF";
            this.btExportSF.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btExportSF.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btExportSF.UseAccentColor = false;
            this.btExportSF.UseVisualStyleBackColor = true;
            // 
            // btStopAction
            // 
            this.btStopAction.AutoSize = false;
            this.btStopAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btStopAction.Depth = 0;
            this.btStopAction.DrawShadows = true;
            this.btStopAction.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btStopAction.ForeColor = System.Drawing.Color.DarkRed;
            this.btStopAction.HighEmphasis = true;
            this.btStopAction.Icon = null;
            this.btStopAction.Location = new System.Drawing.Point(108, 96);
            this.btStopAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btStopAction.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btStopAction.Name = "btStopAction";
            this.btStopAction.Size = new System.Drawing.Size(78, 36);
            this.btStopAction.TabIndex = 52;
            this.btStopAction.Text = "STOP";
            this.btStopAction.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btStopAction.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btStopAction.UseAccentColor = false;
            this.btStopAction.UseVisualStyleBackColor = true;
            // 
            // btStartAction
            // 
            this.btStartAction.AutoSize = false;
            this.btStartAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btStartAction.Depth = 0;
            this.btStartAction.DrawShadows = true;
            this.btStartAction.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btStartAction.ForeColor = System.Drawing.Color.DarkRed;
            this.btStartAction.HighEmphasis = true;
            this.btStartAction.Icon = null;
            this.btStartAction.Location = new System.Drawing.Point(15, 96);
            this.btStartAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btStartAction.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btStartAction.Name = "btStartAction";
            this.btStartAction.Size = new System.Drawing.Size(78, 36);
            this.btStartAction.TabIndex = 54;
            this.btStartAction.Text = "START";
            this.btStartAction.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btStartAction.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btStartAction.UseAccentColor = false;
            this.btStartAction.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(614, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // gbSettings
            // 
            this.gbSettings.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gbSettings.BorderWidth = 1;
            this.gbSettings.Controls.Add(this.btConnectControl);
            this.gbSettings.Controls.Add(this.cbComPort);
            this.gbSettings.ForeColor = System.Drawing.Color.DarkRed;
            this.gbSettings.Location = new System.Drawing.Point(9, 17);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.ShowText = true;
            this.gbSettings.Size = new System.Drawing.Size(184, 63);
            this.gbSettings.TabIndex = 49;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Serial Setting";
            this.gbSettings.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // btConnectControl
            // 
            this.btConnectControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btConnectControl.Depth = 0;
            this.btConnectControl.DrawShadows = true;
            this.btConnectControl.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btConnectControl.ForeColor = System.Drawing.Color.DarkRed;
            this.btConnectControl.HighEmphasis = true;
            this.btConnectControl.Icon = null;
            this.btConnectControl.Location = new System.Drawing.Point(6, 15);
            this.btConnectControl.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btConnectControl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btConnectControl.Name = "btConnectControl";
            this.btConnectControl.Size = new System.Drawing.Size(77, 36);
            this.btConnectControl.TabIndex = 0;
            this.btConnectControl.Text = "Connect";
            this.btConnectControl.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btConnectControl.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btConnectControl.UseAccentColor = false;
            this.btConnectControl.UseVisualStyleBackColor = true;
            // 
            // cbComPort
            // 
            this.cbComPort.AutoResize = false;
            this.cbComPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbComPort.Depth = 0;
            this.cbComPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbComPort.DropDownHeight = 118;
            this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPort.DropDownWidth = 121;
            this.cbComPort.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbComPort.ForeColor = System.Drawing.Color.DarkRed;
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.IntegralHeight = false;
            this.cbComPort.ItemHeight = 29;
            this.cbComPort.Location = new System.Drawing.Point(99, 15);
            this.cbComPort.MaxDropDownItems = 4;
            this.cbComPort.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(79, 35);
            this.cbComPort.StartIndex = 0;
            this.cbComPort.TabIndex = 5;
            this.cbComPort.UseTallSize = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.groupBox2.BorderWidth = 1;
            this.groupBox2.Controls.Add(this.btTimeScale1D);
            this.groupBox2.Controls.Add(this.btTimeScaleFullScale);
            this.groupBox2.Controls.Add(this.btTimeScale2d);
            this.groupBox2.Controls.Add(this.btTimeScale2H);
            this.groupBox2.Controls.Add(this.cbTimeStep);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(212, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.ShowText = true;
            this.groupBox2.Size = new System.Drawing.Size(396, 63);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Scale";
            this.groupBox2.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // btTimeScale1D
            // 
            this.btTimeScale1D.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTimeScale1D.Depth = 0;
            this.btTimeScale1D.DrawShadows = true;
            this.btTimeScale1D.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTimeScale1D.HighEmphasis = true;
            this.btTimeScale1D.Icon = null;
            this.btTimeScale1D.Location = new System.Drawing.Point(53, 14);
            this.btTimeScale1D.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTimeScale1D.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTimeScale1D.Name = "btTimeScale1D";
            this.btTimeScale1D.Size = new System.Drawing.Size(38, 36);
            this.btTimeScale1D.TabIndex = 20;
            this.btTimeScale1D.Text = "1d";
            this.btTimeScale1D.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTimeScale1D.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTimeScale1D.UseAccentColor = false;
            this.btTimeScale1D.UseVisualStyleBackColor = true;
            // 
            // btTimeScaleFullScale
            // 
            this.btTimeScaleFullScale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTimeScaleFullScale.Depth = 0;
            this.btTimeScaleFullScale.DrawShadows = true;
            this.btTimeScaleFullScale.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTimeScaleFullScale.HighEmphasis = true;
            this.btTimeScaleFullScale.Icon = null;
            this.btTimeScaleFullScale.Location = new System.Drawing.Point(145, 14);
            this.btTimeScaleFullScale.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTimeScaleFullScale.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTimeScaleFullScale.Name = "btTimeScaleFullScale";
            this.btTimeScaleFullScale.Size = new System.Drawing.Size(29, 36);
            this.btTimeScaleFullScale.TabIndex = 20;
            this.btTimeScaleFullScale.Text = "F";
            this.btTimeScaleFullScale.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTimeScaleFullScale.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTimeScaleFullScale.UseAccentColor = false;
            this.btTimeScaleFullScale.UseVisualStyleBackColor = true;
            // 
            // btTimeScale2d
            // 
            this.btTimeScale2d.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTimeScale2d.Depth = 0;
            this.btTimeScale2d.DrawShadows = true;
            this.btTimeScale2d.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTimeScale2d.HighEmphasis = true;
            this.btTimeScale2d.Icon = null;
            this.btTimeScale2d.Location = new System.Drawing.Point(99, 14);
            this.btTimeScale2d.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTimeScale2d.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTimeScale2d.Name = "btTimeScale2d";
            this.btTimeScale2d.Size = new System.Drawing.Size(38, 36);
            this.btTimeScale2d.TabIndex = 20;
            this.btTimeScale2d.Text = "3d";
            this.btTimeScale2d.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTimeScale2d.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTimeScale2d.UseAccentColor = false;
            this.btTimeScale2d.UseVisualStyleBackColor = true;
            // 
            // btTimeScale2H
            // 
            this.btTimeScale2H.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTimeScale2H.Depth = 0;
            this.btTimeScale2H.DrawShadows = true;
            this.btTimeScale2H.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTimeScale2H.HighEmphasis = true;
            this.btTimeScale2H.Icon = null;
            this.btTimeScale2H.Location = new System.Drawing.Point(7, 14);
            this.btTimeScale2H.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTimeScale2H.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTimeScale2H.Name = "btTimeScale2H";
            this.btTimeScale2H.Size = new System.Drawing.Size(38, 36);
            this.btTimeScale2H.TabIndex = 20;
            this.btTimeScale2H.Text = "2h";
            this.btTimeScale2H.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTimeScale2H.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTimeScale2H.UseAccentColor = false;
            this.btTimeScale2H.UseVisualStyleBackColor = true;
            // 
            // cbTimeStep
            // 
            this.cbTimeStep.AutoResize = false;
            this.cbTimeStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbTimeStep.Depth = 0;
            this.cbTimeStep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbTimeStep.DropDownHeight = 118;
            this.cbTimeStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeStep.DropDownWidth = 121;
            this.cbTimeStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbTimeStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbTimeStep.FormattingEnabled = true;
            this.cbTimeStep.IntegralHeight = false;
            this.cbTimeStep.ItemHeight = 29;
            this.cbTimeStep.Items.AddRange(new object[] {
            "2h",
            "4h",
            "8h",
            "12h",
            "1d",
            "2d",
            "3d",
            "4d",
            "5d",
            "6d",
            "1w",
            "8d",
            "9d",
            "10d",
            "11d",
            "12d",
            "13d",
            "2w",
            "16d",
            "18d",
            "20d",
            "3w",
            "23d",
            "25d",
            "27d",
            "1m",
            "full"});
            this.cbTimeStep.Location = new System.Drawing.Point(181, 14);
            this.cbTimeStep.MaxDropDownItems = 4;
            this.cbTimeStep.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.cbTimeStep.Name = "cbTimeStep";
            this.cbTimeStep.Size = new System.Drawing.Size(156, 35);
            this.cbTimeStep.StartIndex = 0;
            this.cbTimeStep.TabIndex = 19;
            this.cbTimeStep.UseTallSize = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.gbSfModule);
            this.tabPage2.ImageKey = "round_bluetooth_white_24dp.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1015, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SF Module";
            // 
            // gbSfModule
            // 
            this.gbSfModule.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gbSfModule.BorderWidth = 1;
            this.gbSfModule.Controls.Add(this.tableLayoutPanel3);
            this.gbSfModule.Controls.Add(this.progressBar1);
            this.gbSfModule.Controls.Add(this.gbChannel);
            this.gbSfModule.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbSfModule.ForeColor = System.Drawing.Color.DarkRed;
            this.gbSfModule.Location = new System.Drawing.Point(6, 6);
            this.gbSfModule.Name = "gbSfModule";
            this.gbSfModule.ShowText = true;
            this.gbSfModule.Size = new System.Drawing.Size(780, 498);
            this.gbSfModule.TabIndex = 23;
            this.gbSfModule.TabStop = false;
            this.gbSfModule.Text = "SF Module #01";
            this.gbSfModule.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btSFModuleSelectionNumberPrevious, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btGraphOpen, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.btCalibration, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btSFModuleSelectionNumberNext, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbSFModuleSelectionNumber, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btMultiViewOpen, 6, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(13, 51);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(554, 51);
            this.tableLayoutPanel3.TabIndex = 49;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Depth = 0;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label19.ForeColor = System.Drawing.Color.DarkRed;
            this.label19.Location = new System.Drawing.Point(3, 0);
            this.label19.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 51);
            this.label19.TabIndex = 30;
            this.label19.Text = "Module";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSFModuleSelectionNumberPrevious
            // 
            this.btSFModuleSelectionNumberPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSFModuleSelectionNumberPrevious.Depth = 0;
            this.btSFModuleSelectionNumberPrevious.DrawShadows = true;
            this.btSFModuleSelectionNumberPrevious.ForeColor = System.Drawing.Color.DarkRed;
            this.btSFModuleSelectionNumberPrevious.HighEmphasis = true;
            this.btSFModuleSelectionNumberPrevious.Icon = null;
            this.btSFModuleSelectionNumberPrevious.Location = new System.Drawing.Point(70, 6);
            this.btSFModuleSelectionNumberPrevious.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSFModuleSelectionNumberPrevious.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btSFModuleSelectionNumberPrevious.Name = "btSFModuleSelectionNumberPrevious";
            this.btSFModuleSelectionNumberPrevious.Size = new System.Drawing.Size(36, 36);
            this.btSFModuleSelectionNumberPrevious.TabIndex = 32;
            this.btSFModuleSelectionNumberPrevious.Text = "<<";
            this.btSFModuleSelectionNumberPrevious.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btSFModuleSelectionNumberPrevious.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btSFModuleSelectionNumberPrevious.UseAccentColor = false;
            this.btSFModuleSelectionNumberPrevious.UseVisualStyleBackColor = true;
            // 
            // btGraphOpen
            // 
            this.btGraphOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btGraphOpen.Depth = 0;
            this.btGraphOpen.DrawShadows = true;
            this.btGraphOpen.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btGraphOpen.ForeColor = System.Drawing.Color.DarkRed;
            this.btGraphOpen.HighEmphasis = true;
            this.btGraphOpen.Icon = null;
            this.btGraphOpen.Location = new System.Drawing.Point(365, 6);
            this.btGraphOpen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btGraphOpen.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btGraphOpen.Name = "btGraphOpen";
            this.btGraphOpen.Size = new System.Drawing.Size(61, 36);
            this.btGraphOpen.TabIndex = 22;
            this.btGraphOpen.Text = "Graph";
            this.btGraphOpen.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btGraphOpen.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btGraphOpen.UseAccentColor = false;
            this.btGraphOpen.UseVisualStyleBackColor = true;
            // 
            // btCalibration
            // 
            this.btCalibration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCalibration.Depth = 0;
            this.btCalibration.DrawShadows = true;
            this.btCalibration.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btCalibration.ForeColor = System.Drawing.Color.DarkRed;
            this.btCalibration.HighEmphasis = true;
            this.btCalibration.Icon = null;
            this.btCalibration.Location = new System.Drawing.Point(250, 6);
            this.btCalibration.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btCalibration.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btCalibration.Name = "btCalibration";
            this.btCalibration.Size = new System.Drawing.Size(94, 36);
            this.btCalibration.TabIndex = 35;
            this.btCalibration.Text = "Calibration";
            this.btCalibration.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btCalibration.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btCalibration.UseAccentColor = false;
            this.btCalibration.UseVisualStyleBackColor = true;
            // 
            // btSFModuleSelectionNumberNext
            // 
            this.btSFModuleSelectionNumberNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSFModuleSelectionNumberNext.Depth = 0;
            this.btSFModuleSelectionNumberNext.DrawShadows = true;
            this.btSFModuleSelectionNumberNext.ForeColor = System.Drawing.Color.DarkRed;
            this.btSFModuleSelectionNumberNext.HighEmphasis = true;
            this.btSFModuleSelectionNumberNext.Icon = null;
            this.btSFModuleSelectionNumberNext.Location = new System.Drawing.Point(127, 6);
            this.btSFModuleSelectionNumberNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSFModuleSelectionNumberNext.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btSFModuleSelectionNumberNext.Name = "btSFModuleSelectionNumberNext";
            this.btSFModuleSelectionNumberNext.Size = new System.Drawing.Size(37, 36);
            this.btSFModuleSelectionNumberNext.TabIndex = 33;
            this.btSFModuleSelectionNumberNext.Text = ">>";
            this.btSFModuleSelectionNumberNext.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btSFModuleSelectionNumberNext.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btSFModuleSelectionNumberNext.UseAccentColor = false;
            this.btSFModuleSelectionNumberNext.UseVisualStyleBackColor = true;
            // 
            // cbSFModuleSelectionNumber
            // 
            this.cbSFModuleSelectionNumber.AutoResize = false;
            this.cbSFModuleSelectionNumber.BackColor = System.Drawing.Color.Ivory;
            this.cbSFModuleSelectionNumber.Depth = 0;
            this.cbSFModuleSelectionNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbSFModuleSelectionNumber.DropDownHeight = 118;
            this.cbSFModuleSelectionNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSFModuleSelectionNumber.DropDownWidth = 121;
            this.cbSFModuleSelectionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbSFModuleSelectionNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.cbSFModuleSelectionNumber.FormattingEnabled = true;
            this.cbSFModuleSelectionNumber.IntegralHeight = false;
            this.cbSFModuleSelectionNumber.ItemHeight = 29;
            this.cbSFModuleSelectionNumber.Location = new System.Drawing.Point(183, 3);
            this.cbSFModuleSelectionNumber.MaxDropDownItems = 4;
            this.cbSFModuleSelectionNumber.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.cbSFModuleSelectionNumber.Name = "cbSFModuleSelectionNumber";
            this.cbSFModuleSelectionNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbSFModuleSelectionNumber.Size = new System.Drawing.Size(46, 35);
            this.cbSFModuleSelectionNumber.StartIndex = 0;
            this.cbSFModuleSelectionNumber.TabIndex = 31;
            this.cbSFModuleSelectionNumber.UseTallSize = false;
            // 
            // btMultiViewOpen
            // 
            this.btMultiViewOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btMultiViewOpen.Depth = 0;
            this.btMultiViewOpen.DrawShadows = true;
            this.btMultiViewOpen.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btMultiViewOpen.ForeColor = System.Drawing.Color.DarkRed;
            this.btMultiViewOpen.HighEmphasis = true;
            this.btMultiViewOpen.Icon = null;
            this.btMultiViewOpen.Location = new System.Drawing.Point(449, 6);
            this.btMultiViewOpen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btMultiViewOpen.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btMultiViewOpen.Name = "btMultiViewOpen";
            this.btMultiViewOpen.Size = new System.Drawing.Size(91, 36);
            this.btMultiViewOpen.TabIndex = 22;
            this.btMultiViewOpen.Text = "Multi View";
            this.btMultiViewOpen.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btMultiViewOpen.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btMultiViewOpen.UseAccentColor = false;
            this.btMultiViewOpen.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Ivory;
            this.progressBar1.Depth = 0;
            this.progressBar1.ForeColor = System.Drawing.Color.LawnGreen;
            this.progressBar1.Location = new System.Drawing.Point(13, 15);
            this.progressBar1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(554, 18);
            this.progressBar1.Step = 25;
            this.progressBar1.TabIndex = 51;
            // 
            // gbChannel
            // 
            this.gbChannel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gbChannel.BorderWidth = 1;
            this.gbChannel.Controls.Add(this.tableLayoutPanel5);
            this.gbChannel.Controls.Add(this.tableLayoutPanel2);
            this.gbChannel.Controls.Add(this.flowLayoutPanel1);
            this.gbChannel.Controls.Add(this.flowLayoutPanel2);
            this.gbChannel.Controls.Add(this.lbStartTime);
            this.gbChannel.Controls.Add(this.lbDateTime);
            this.gbChannel.Location = new System.Drawing.Point(13, 130);
            this.gbChannel.Name = "gbChannel";
            this.gbChannel.ShowText = true;
            this.gbChannel.Size = new System.Drawing.Size(565, 345);
            this.gbChannel.TabIndex = 32;
            this.gbChannel.TabStop = false;
            this.gbChannel.Text = "Channel #1";
            this.gbChannel.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.20773F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.79227F));
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lbTemperature, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lbHumidity, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(347, 13);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(207, 46);
            this.tableLayoutPanel5.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Depth = 0;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label8.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 37;
            this.label8.Text = "Sap Flow:";
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Depth = 0;
            this.lbTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTemperature.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbTemperature.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbTemperature.Location = new System.Drawing.Point(109, 0);
            this.lbTemperature.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(95, 23);
            this.lbTemperature.TabIndex = 20;
            this.lbTemperature.Text = "--";
            this.lbTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHumidity
            // 
            this.lbHumidity.AutoSize = true;
            this.lbHumidity.Depth = 0;
            this.lbHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHumidity.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbHumidity.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbHumidity.Location = new System.Drawing.Point(109, 23);
            this.lbHumidity.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbHumidity.Name = "lbHumidity";
            this.lbHumidity.Size = new System.Drawing.Size(95, 23);
            this.lbHumidity.TabIndex = 20;
            this.lbHumidity.Text = "--";
            this.lbHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Depth = 0;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.ForeColor = System.Drawing.Color.DarkOrange;
            this.label9.Location = new System.Drawing.Point(3, 23);
            this.label9.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "R. Temp:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tbY1Max, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbY1Min, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbDisposeData, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbY2Min, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbY1Min, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbY2Min, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbY2Max, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbY2Max, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbY1Max, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbY1MinValue, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbY2MinValue, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbY1MaxValue, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbY2MaxValue, 6, 2);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(548, 132);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // tbY1Max
            // 
            this.tbY1Max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY1Max.Depth = 0;
            this.tbY1Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY1Max.Enabled = false;
            this.tbY1Max.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY1Max.ForeColor = System.Drawing.Color.DarkRed;
            this.tbY1Max.Location = new System.Drawing.Point(303, 39);
            this.tbY1Max.MaxLength = 50;
            this.tbY1Max.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY1Max.Multiline = false;
            this.tbY1Max.Name = "tbY1Max";
            this.tbY1Max.Size = new System.Drawing.Size(42, 36);
            this.tbY1Max.TabIndex = 18;
            this.tbY1Max.Text = "";
            this.tbY1Max.UseTallSize = false;
            // 
            // tbY1Min
            // 
            this.tbY1Min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY1Min.Depth = 0;
            this.tbY1Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY1Min.Enabled = false;
            this.tbY1Min.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY1Min.ForeColor = System.Drawing.Color.DarkRed;
            this.tbY1Min.Location = new System.Drawing.Point(198, 39);
            this.tbY1Min.MaxLength = 50;
            this.tbY1Min.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY1Min.Multiline = false;
            this.tbY1Min.Name = "tbY1Min";
            this.tbY1Min.Size = new System.Drawing.Size(68, 36);
            this.tbY1Min.TabIndex = 18;
            this.tbY1Min.Text = "";
            this.tbY1Min.UseTallSize = false;
            // 
            // cbDisposeData
            // 
            this.cbDisposeData.AutoSize = true;
            this.cbDisposeData.Checked = true;
            this.cbDisposeData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisposeData.Depth = 0;
            this.cbDisposeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDisposeData.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbDisposeData.ForeColor = System.Drawing.Color.DarkRed;
            this.cbDisposeData.Location = new System.Drawing.Point(0, 0);
            this.cbDisposeData.Margin = new System.Windows.Forms.Padding(0);
            this.cbDisposeData.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbDisposeData.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbDisposeData.Name = "cbDisposeData";
            this.cbDisposeData.Ripple = true;
            this.cbDisposeData.Size = new System.Drawing.Size(156, 36);
            this.cbDisposeData.TabIndex = 56;
            this.cbDisposeData.Text = "Compact Data";
            this.cbDisposeData.UseVisualStyleBackColor = true;
            // 
            // tbY2Min
            // 
            this.tbY2Min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY2Min.Depth = 0;
            this.tbY2Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY2Min.Enabled = false;
            this.tbY2Min.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY2Min.ForeColor = System.Drawing.Color.DarkRed;
            this.tbY2Min.Location = new System.Drawing.Point(198, 78);
            this.tbY2Min.MaxLength = 50;
            this.tbY2Min.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY2Min.Multiline = false;
            this.tbY2Min.Name = "tbY2Min";
            this.tbY2Min.Size = new System.Drawing.Size(68, 36);
            this.tbY2Min.TabIndex = 18;
            this.tbY2Min.Text = "";
            this.tbY2Min.UseTallSize = false;
            // 
            // cbY1Min
            // 
            this.cbY1Min.AutoSize = true;
            this.cbY1Min.Depth = 0;
            this.cbY1Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbY1Min.ForeColor = System.Drawing.Color.DarkRed;
            this.cbY1Min.Location = new System.Drawing.Point(156, 36);
            this.cbY1Min.Margin = new System.Windows.Forms.Padding(0);
            this.cbY1Min.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbY1Min.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbY1Min.Name = "cbY1Min";
            this.cbY1Min.Ripple = true;
            this.cbY1Min.Size = new System.Drawing.Size(39, 39);
            this.cbY1Min.TabIndex = 17;
            this.cbY1Min.UseVisualStyleBackColor = true;
            // 
            // cbY2Min
            // 
            this.cbY2Min.AutoSize = true;
            this.cbY2Min.Depth = 0;
            this.cbY2Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbY2Min.ForeColor = System.Drawing.Color.DarkRed;
            this.cbY2Min.Location = new System.Drawing.Point(156, 75);
            this.cbY2Min.Margin = new System.Windows.Forms.Padding(0);
            this.cbY2Min.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbY2Min.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbY2Min.Name = "cbY2Min";
            this.cbY2Min.Ripple = true;
            this.cbY2Min.Size = new System.Drawing.Size(39, 57);
            this.cbY2Min.TabIndex = 17;
            this.cbY2Min.UseVisualStyleBackColor = true;
            // 
            // cbY2Max
            // 
            this.cbY2Max.AutoSize = true;
            this.cbY2Max.Depth = 0;
            this.cbY2Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbY2Max.ForeColor = System.Drawing.Color.DarkRed;
            this.cbY2Max.Location = new System.Drawing.Point(269, 75);
            this.cbY2Max.Margin = new System.Windows.Forms.Padding(0);
            this.cbY2Max.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbY2Max.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbY2Max.Name = "cbY2Max";
            this.cbY2Max.Ripple = true;
            this.cbY2Max.Size = new System.Drawing.Size(31, 57);
            this.cbY2Max.TabIndex = 17;
            this.cbY2Max.UseVisualStyleBackColor = true;
            // 
            // tbY2Max
            // 
            this.tbY2Max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY2Max.Depth = 0;
            this.tbY2Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY2Max.Enabled = false;
            this.tbY2Max.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY2Max.ForeColor = System.Drawing.Color.DarkRed;
            this.tbY2Max.Location = new System.Drawing.Point(303, 78);
            this.tbY2Max.MaxLength = 50;
            this.tbY2Max.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY2Max.Multiline = false;
            this.tbY2Max.Name = "tbY2Max";
            this.tbY2Max.Size = new System.Drawing.Size(42, 36);
            this.tbY2Max.TabIndex = 18;
            this.tbY2Max.Text = "";
            this.tbY2Max.UseTallSize = false;
            // 
            // cbY1Max
            // 
            this.cbY1Max.AutoSize = true;
            this.cbY1Max.Depth = 0;
            this.cbY1Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbY1Max.ForeColor = System.Drawing.Color.DarkRed;
            this.cbY1Max.Location = new System.Drawing.Point(269, 36);
            this.cbY1Max.Margin = new System.Windows.Forms.Padding(0);
            this.cbY1Max.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbY1Max.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbY1Max.Name = "cbY1Max";
            this.cbY1Max.Ripple = true;
            this.cbY1Max.Size = new System.Drawing.Size(31, 39);
            this.cbY1Max.TabIndex = 17;
            this.cbY1Max.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 39);
            this.label2.TabIndex = 19;
            this.label2.Text = "Sap Flow";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 57);
            this.label3.TabIndex = 19;
            this.label3.Text = "Relative Temp.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Depth = 0;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(303, 0);
            this.label4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 36);
            this.label4.TabIndex = 20;
            this.label4.Text = "Max.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(198, 0);
            this.label5.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 36);
            this.label5.TabIndex = 20;
            this.label5.Text = "Min.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Depth = 0;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(351, 0);
            this.label6.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 36);
            this.label6.TabIndex = 34;
            this.label6.Text = "Min. Value";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Depth = 0;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(451, 0);
            this.label7.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 36);
            this.label7.TabIndex = 35;
            this.label7.Text = "Max. Value";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbY1MinValue
            // 
            this.tbY1MinValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY1MinValue.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbY1MinValue.Depth = 0;
            this.tbY1MinValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY1MinValue.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY1MinValue.Location = new System.Drawing.Point(351, 39);
            this.tbY1MinValue.MaxLength = 50;
            this.tbY1MinValue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY1MinValue.Multiline = false;
            this.tbY1MinValue.Name = "tbY1MinValue";
            this.tbY1MinValue.Size = new System.Drawing.Size(94, 36);
            this.tbY1MinValue.TabIndex = 36;
            this.tbY1MinValue.Text = "";
            this.tbY1MinValue.UseTallSize = false;
            // 
            // tbY2MinValue
            // 
            this.tbY2MinValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY2MinValue.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbY2MinValue.Depth = 0;
            this.tbY2MinValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY2MinValue.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY2MinValue.Location = new System.Drawing.Point(351, 78);
            this.tbY2MinValue.MaxLength = 50;
            this.tbY2MinValue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY2MinValue.Multiline = false;
            this.tbY2MinValue.Name = "tbY2MinValue";
            this.tbY2MinValue.Size = new System.Drawing.Size(94, 36);
            this.tbY2MinValue.TabIndex = 37;
            this.tbY2MinValue.Text = "";
            this.tbY2MinValue.UseTallSize = false;
            // 
            // tbY1MaxValue
            // 
            this.tbY1MaxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY1MaxValue.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbY1MaxValue.Depth = 0;
            this.tbY1MaxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY1MaxValue.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY1MaxValue.Location = new System.Drawing.Point(451, 39);
            this.tbY1MaxValue.MaxLength = 50;
            this.tbY1MaxValue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY1MaxValue.Multiline = false;
            this.tbY1MaxValue.Name = "tbY1MaxValue";
            this.tbY1MaxValue.Size = new System.Drawing.Size(94, 36);
            this.tbY1MaxValue.TabIndex = 40;
            this.tbY1MaxValue.Text = "";
            this.tbY1MaxValue.UseTallSize = false;
            // 
            // tbY2MaxValue
            // 
            this.tbY2MaxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbY2MaxValue.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbY2MaxValue.Depth = 0;
            this.tbY2MaxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbY2MaxValue.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbY2MaxValue.Location = new System.Drawing.Point(451, 78);
            this.tbY2MaxValue.MaxLength = 50;
            this.tbY2MaxValue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbY2MaxValue.Multiline = false;
            this.tbY2MaxValue.Name = "tbY2MaxValue";
            this.tbY2MaxValue.Size = new System.Drawing.Size(94, 36);
            this.tbY2MaxValue.TabIndex = 41;
            this.tbY2MaxValue.Text = "";
            this.tbY2MaxValue.UseTallSize = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btParaReset_Offset);
            this.flowLayoutPanel1.Controls.Add(this.btParaSet_Offset);
            this.flowLayoutPanel1.Controls.Add(this.tbParaSet_Tm_Offset);
            this.flowLayoutPanel1.Controls.Add(this.label18);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(220, 262);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 47);
            this.flowLayoutPanel1.TabIndex = 42;
            // 
            // btParaReset_Offset
            // 
            this.btParaReset_Offset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btParaReset_Offset.Depth = 0;
            this.btParaReset_Offset.DrawShadows = true;
            this.btParaReset_Offset.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btParaReset_Offset.ForeColor = System.Drawing.Color.DarkRed;
            this.btParaReset_Offset.HighEmphasis = true;
            this.btParaReset_Offset.Icon = null;
            this.btParaReset_Offset.Location = new System.Drawing.Point(206, 6);
            this.btParaReset_Offset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btParaReset_Offset.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btParaReset_Offset.Name = "btParaReset_Offset";
            this.btParaReset_Offset.Size = new System.Drawing.Size(59, 36);
            this.btParaReset_Offset.TabIndex = 42;
            this.btParaReset_Offset.Text = "Reset";
            this.btParaReset_Offset.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btParaReset_Offset.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btParaReset_Offset.UseAccentColor = false;
            this.btParaReset_Offset.UseVisualStyleBackColor = true;
            // 
            // btParaSet_Offset
            // 
            this.btParaSet_Offset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btParaSet_Offset.Depth = 0;
            this.btParaSet_Offset.DrawShadows = true;
            this.btParaSet_Offset.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btParaSet_Offset.ForeColor = System.Drawing.Color.DarkRed;
            this.btParaSet_Offset.HighEmphasis = true;
            this.btParaSet_Offset.Icon = null;
            this.btParaSet_Offset.Location = new System.Drawing.Point(155, 6);
            this.btParaSet_Offset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btParaSet_Offset.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btParaSet_Offset.Name = "btParaSet_Offset";
            this.btParaSet_Offset.Size = new System.Drawing.Size(43, 36);
            this.btParaSet_Offset.TabIndex = 42;
            this.btParaSet_Offset.Text = "Set";
            this.btParaSet_Offset.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btParaSet_Offset.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btParaSet_Offset.UseAccentColor = false;
            this.btParaSet_Offset.UseVisualStyleBackColor = true;
            // 
            // tbParaSet_Tm_Offset
            // 
            this.tbParaSet_Tm_Offset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbParaSet_Tm_Offset.Depth = 0;
            this.tbParaSet_Tm_Offset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParaSet_Tm_Offset.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbParaSet_Tm_Offset.ForeColor = System.Drawing.Color.DarkRed;
            this.tbParaSet_Tm_Offset.Location = new System.Drawing.Point(93, 3);
            this.tbParaSet_Tm_Offset.MaxLength = 50;
            this.tbParaSet_Tm_Offset.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbParaSet_Tm_Offset.Multiline = false;
            this.tbParaSet_Tm_Offset.Name = "tbParaSet_Tm_Offset";
            this.tbParaSet_Tm_Offset.Size = new System.Drawing.Size(55, 36);
            this.tbParaSet_Tm_Offset.TabIndex = 41;
            this.tbParaSet_Tm_Offset.Text = "";
            this.tbParaSet_Tm_Offset.UseTallSize = false;
            // 
            // label18
            // 
            this.label18.Depth = 0;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label18.ForeColor = System.Drawing.Color.DarkRed;
            this.label18.Location = new System.Drawing.Point(7, 0);
            this.label18.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 48);
            this.label18.TabIndex = 43;
            this.label18.Text = "SF Offset=";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rbCH1);
            this.flowLayoutPanel2.Controls.Add(this.rbCH2);
            this.flowLayoutPanel2.Controls.Add(this.rbCH3);
            this.flowLayoutPanel2.Controls.Add(this.rbCH4);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 20);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(335, 39);
            this.flowLayoutPanel2.TabIndex = 30;
            // 
            // rbCH1
            // 
            this.rbCH1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCH1.Checked = true;
            this.rbCH1.Depth = 0;
            this.rbCH1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbCH1.ForeColor = System.Drawing.Color.DarkRed;
            this.rbCH1.Location = new System.Drawing.Point(0, 0);
            this.rbCH1.Margin = new System.Windows.Forms.Padding(0);
            this.rbCH1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbCH1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.rbCH1.Name = "rbCH1";
            this.rbCH1.Ripple = true;
            this.rbCH1.Size = new System.Drawing.Size(69, 30);
            this.rbCH1.TabIndex = 29;
            this.rbCH1.TabStop = true;
            this.rbCH1.Text = "CH1";
            this.rbCH1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCH1.UseVisualStyleBackColor = true;
            // 
            // rbCH2
            // 
            this.rbCH2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCH2.Depth = 0;
            this.rbCH2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbCH2.ForeColor = System.Drawing.Color.DarkRed;
            this.rbCH2.Location = new System.Drawing.Point(69, 0);
            this.rbCH2.Margin = new System.Windows.Forms.Padding(0);
            this.rbCH2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbCH2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.rbCH2.Name = "rbCH2";
            this.rbCH2.Ripple = true;
            this.rbCH2.Size = new System.Drawing.Size(75, 30);
            this.rbCH2.TabIndex = 29;
            this.rbCH2.Text = "CH2";
            this.rbCH2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCH2.UseVisualStyleBackColor = true;
            // 
            // rbCH3
            // 
            this.rbCH3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCH3.Depth = 0;
            this.rbCH3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbCH3.ForeColor = System.Drawing.Color.DarkRed;
            this.rbCH3.Location = new System.Drawing.Point(144, 0);
            this.rbCH3.Margin = new System.Windows.Forms.Padding(0);
            this.rbCH3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbCH3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.rbCH3.Name = "rbCH3";
            this.rbCH3.Ripple = true;
            this.rbCH3.Size = new System.Drawing.Size(71, 30);
            this.rbCH3.TabIndex = 29;
            this.rbCH3.Text = "CH3";
            this.rbCH3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCH3.UseVisualStyleBackColor = true;
            // 
            // rbCH4
            // 
            this.rbCH4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCH4.Depth = 0;
            this.rbCH4.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbCH4.ForeColor = System.Drawing.Color.DarkRed;
            this.rbCH4.Location = new System.Drawing.Point(215, 0);
            this.rbCH4.Margin = new System.Windows.Forms.Padding(0);
            this.rbCH4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbCH4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.rbCH4.Name = "rbCH4";
            this.rbCH4.Ripple = true;
            this.rbCH4.Size = new System.Drawing.Size(74, 30);
            this.rbCH4.TabIndex = 29;
            this.rbCH4.Text = "CH4";
            this.rbCH4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCH4.UseVisualStyleBackColor = true;
            // 
            // lbStartTime
            // 
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.Depth = 0;
            this.lbStartTime.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbStartTime.ForeColor = System.Drawing.Color.DarkGray;
            this.lbStartTime.Location = new System.Drawing.Point(5, 262);
            this.lbStartTime.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(75, 19);
            this.lbStartTime.TabIndex = 20;
            this.lbStartTime.Text = "Start Time";
            this.lbStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.Depth = 0;
            this.lbDateTime.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbDateTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lbDateTime.Location = new System.Drawing.Point(3, 281);
            this.lbDateTime.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(92, 19);
            this.lbDateTime.TabIndex = 20;
            this.lbDateTime.Text = "Current Time";
            this.lbDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.AB_tb);
            this.tabPage3.Controls.Add(this.AB_check);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.AB_count);
            this.tabPage3.Controls.Add(this.lbExtendScreen);
            this.tabPage3.Controls.Add(this.btWindowExtend);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.cbBackupTerm);
            this.tabPage3.Controls.Add(this.btBackupLogDay);
            this.tabPage3.Controls.Add(this.listBox2);
            this.tabPage3.Controls.Add(this.flowLayoutPanel4);
            this.tabPage3.ImageKey = "round_build_white_24dp.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1015, 520);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Window";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Depth = 0;
            this.label17.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label17.Location = new System.Drawing.Point(465, 133);
            this.label17.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(8, 19);
            this.label17.TabIndex = 83;
            this.label17.Text = "/";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Depth = 0;
            this.label16.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label16.Location = new System.Drawing.Point(502, 133);
            this.label16.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 19);
            this.label16.TabIndex = 82;
            this.label16.Text = "min";
            // 
            // AB_tb
            // 
            this.AB_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AB_tb.Depth = 0;
            this.AB_tb.Enabled = false;
            this.AB_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AB_tb.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AB_tb.Location = new System.Drawing.Point(401, 127);
            this.AB_tb.MaxLength = 50;
            this.AB_tb.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.AB_tb.Multiline = false;
            this.AB_tb.Name = "AB_tb";
            this.AB_tb.Size = new System.Drawing.Size(60, 36);
            this.AB_tb.TabIndex = 81;
            this.AB_tb.Text = "180";
            this.AB_tb.UseTallSize = false;
            // 
            // AB_check
            // 
            this.AB_check.AutoSize = true;
            this.AB_check.Checked = true;
            this.AB_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AB_check.Depth = 0;
            this.AB_check.Location = new System.Drawing.Point(499, 93);
            this.AB_check.Margin = new System.Windows.Forms.Padding(0);
            this.AB_check.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AB_check.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.AB_check.Name = "AB_check";
            this.AB_check.Ripple = true;
            this.AB_check.Size = new System.Drawing.Size(35, 37);
            this.AB_check.TabIndex = 80;
            this.AB_check.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Depth = 0;
            this.label15.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label15.Location = new System.Drawing.Point(399, 103);
            this.label15.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 19);
            this.label15.TabIndex = 79;
            this.label15.Text = "Auto Backup :";
            // 
            // AB_count
            // 
            this.AB_count.AutoSize = true;
            this.AB_count.Depth = 0;
            this.AB_count.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AB_count.Location = new System.Drawing.Point(488, 134);
            this.AB_count.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.AB_count.Name = "AB_count";
            this.AB_count.Size = new System.Drawing.Size(10, 19);
            this.AB_count.TabIndex = 78;
            this.AB_count.Text = "0";
            // 
            // lbExtendScreen
            // 
            this.lbExtendScreen.AutoSize = true;
            this.lbExtendScreen.Depth = 0;
            this.lbExtendScreen.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbExtendScreen.Location = new System.Drawing.Point(399, 266);
            this.lbExtendScreen.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbExtendScreen.Name = "lbExtendScreen";
            this.lbExtendScreen.Size = new System.Drawing.Size(105, 19);
            this.lbExtendScreen.TabIndex = 77;
            this.lbExtendScreen.Text = "Extend Screen:";
            // 
            // btWindowExtend
            // 
            this.btWindowExtend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btWindowExtend.Depth = 0;
            this.btWindowExtend.DrawShadows = true;
            this.btWindowExtend.ForeColor = System.Drawing.Color.DarkRed;
            this.btWindowExtend.HighEmphasis = true;
            this.btWindowExtend.Icon = null;
            this.btWindowExtend.Location = new System.Drawing.Point(508, 260);
            this.btWindowExtend.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btWindowExtend.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btWindowExtend.Name = "btWindowExtend";
            this.btWindowExtend.Size = new System.Drawing.Size(37, 36);
            this.btWindowExtend.TabIndex = 76;
            this.btWindowExtend.Text = ">>";
            this.btWindowExtend.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btWindowExtend.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btWindowExtend.UseAccentColor = false;
            this.btWindowExtend.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Depth = 0;
            this.label20.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label20.Location = new System.Drawing.Point(399, 17);
            this.label20.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 19);
            this.label20.TabIndex = 75;
            this.label20.Text = "Window:";
            // 
            // cbBackupTerm
            // 
            this.cbBackupTerm.AutoResize = false;
            this.cbBackupTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbBackupTerm.Depth = 0;
            this.cbBackupTerm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbBackupTerm.DropDownHeight = 118;
            this.cbBackupTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackupTerm.DropDownWidth = 121;
            this.cbBackupTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbBackupTerm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbBackupTerm.FormattingEnabled = true;
            this.cbBackupTerm.IntegralHeight = false;
            this.cbBackupTerm.ItemHeight = 29;
            this.cbBackupTerm.Location = new System.Drawing.Point(477, 14);
            this.cbBackupTerm.MaxDropDownItems = 4;
            this.cbBackupTerm.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.cbBackupTerm.Name = "cbBackupTerm";
            this.cbBackupTerm.Size = new System.Drawing.Size(72, 35);
            this.cbBackupTerm.StartIndex = 0;
            this.cbBackupTerm.TabIndex = 74;
            this.cbBackupTerm.UseTallSize = false;
            // 
            // btBackupLogDay
            // 
            this.btBackupLogDay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btBackupLogDay.Depth = 0;
            this.btBackupLogDay.DrawShadows = true;
            this.btBackupLogDay.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btBackupLogDay.ForeColor = System.Drawing.Color.DarkRed;
            this.btBackupLogDay.HighEmphasis = true;
            this.btBackupLogDay.Icon = null;
            this.btBackupLogDay.Location = new System.Drawing.Point(401, 57);
            this.btBackupLogDay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btBackupLogDay.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btBackupLogDay.Name = "btBackupLogDay";
            this.btBackupLogDay.Size = new System.Drawing.Size(112, 36);
            this.btBackupLogDay.TabIndex = 71;
            this.btBackupLogDay.Text = "Backup(term)";
            this.btBackupLogDay.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btBackupLogDay.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btBackupLogDay.UseAccentColor = false;
            this.btBackupLogDay.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.IntegralHeight = false;
            this.listBox2.ItemHeight = 11;
            this.listBox2.Location = new System.Drawing.Point(22, 16);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(371, 297);
            this.listBox2.TabIndex = 72;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.cbLockControl);
            this.flowLayoutPanel4.Controls.Add(this.cbAlwaysOnTop);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(399, 168);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(150, 75);
            this.flowLayoutPanel4.TabIndex = 73;
            // 
            // cbLockControl
            // 
            this.cbLockControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLockControl.AutoSize = true;
            this.cbLockControl.Depth = 0;
            this.cbLockControl.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbLockControl.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbLockControl.Location = new System.Drawing.Point(0, 0);
            this.cbLockControl.Margin = new System.Windows.Forms.Padding(0);
            this.cbLockControl.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbLockControl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbLockControl.Name = "cbLockControl";
            this.cbLockControl.Ripple = true;
            this.cbLockControl.Size = new System.Drawing.Size(124, 37);
            this.cbLockControl.TabIndex = 34;
            this.cbLockControl.Text = "Lock Control";
            this.cbLockControl.UseVisualStyleBackColor = true;
            // 
            // cbAlwaysOnTop
            // 
            this.cbAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlwaysOnTop.AutoSize = true;
            this.cbAlwaysOnTop.Depth = 0;
            this.cbAlwaysOnTop.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbAlwaysOnTop.Location = new System.Drawing.Point(0, 37);
            this.cbAlwaysOnTop.Margin = new System.Windows.Forms.Padding(0);
            this.cbAlwaysOnTop.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbAlwaysOnTop.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbAlwaysOnTop.Name = "cbAlwaysOnTop";
            this.cbAlwaysOnTop.Ripple = true;
            this.cbAlwaysOnTop.Size = new System.Drawing.Size(142, 37);
            this.cbAlwaysOnTop.TabIndex = 23;
            this.cbAlwaysOnTop.Text = "Always On Top";
            this.cbAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.gbSystemSetting);
            this.tabPage4.Controls.Add(this.gbValveControl);
            this.tabPage4.Controls.Add(this.gbDebugSetting);
            this.tabPage4.ImageKey = "round_backup_white_24dp.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1015, 520);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Valve";
            // 
            // gbSystemSetting
            // 
            this.gbSystemSetting.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gbSystemSetting.BorderWidth = 1;
            this.gbSystemSetting.Controls.Add(this.btSetup);
            this.gbSystemSetting.Controls.Add(this.btSavePreset);
            this.gbSystemSetting.Controls.Add(this.btLoadPreset);
            this.gbSystemSetting.Controls.Add(this.btMinMaxfrimVC);
            this.gbSystemSetting.Controls.Add(this.btMinMaxtoVC);
            this.gbSystemSetting.Controls.Add(this.btUpdateCOM);
            this.gbSystemSetting.Controls.Add(this.button3);
            this.gbSystemSetting.Font = new System.Drawing.Font("굴림", 9F);
            this.gbSystemSetting.ForeColor = System.Drawing.Color.DarkRed;
            this.gbSystemSetting.Location = new System.Drawing.Point(6, 140);
            this.gbSystemSetting.Name = "gbSystemSetting";
            this.gbSystemSetting.ShowText = true;
            this.gbSystemSetting.Size = new System.Drawing.Size(407, 122);
            this.gbSystemSetting.TabIndex = 63;
            this.gbSystemSetting.TabStop = false;
            this.gbSystemSetting.Text = "System Setting";
            this.gbSystemSetting.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // btSetup
            // 
            this.btSetup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSetup.Depth = 0;
            this.btSetup.DrawShadows = true;
            this.btSetup.Font = new System.Drawing.Font("굴림", 9F);
            this.btSetup.ForeColor = System.Drawing.Color.DarkRed;
            this.btSetup.HighEmphasis = true;
            this.btSetup.Icon = null;
            this.btSetup.Location = new System.Drawing.Point(5, 68);
            this.btSetup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSetup.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btSetup.Name = "btSetup";
            this.btSetup.Size = new System.Drawing.Size(113, 36);
            this.btSetup.TabIndex = 35;
            this.btSetup.Text = "Module Setup";
            this.btSetup.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btSetup.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btSetup.UseAccentColor = false;
            this.btSetup.UseVisualStyleBackColor = true;
            // 
            // btSavePreset
            // 
            this.btSavePreset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSavePreset.Depth = 0;
            this.btSavePreset.DrawShadows = true;
            this.btSavePreset.Font = new System.Drawing.Font("굴림", 9F);
            this.btSavePreset.ForeColor = System.Drawing.Color.DarkRed;
            this.btSavePreset.HighEmphasis = true;
            this.btSavePreset.Icon = null;
            this.btSavePreset.Location = new System.Drawing.Point(213, 68);
            this.btSavePreset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSavePreset.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btSavePreset.Name = "btSavePreset";
            this.btSavePreset.Size = new System.Drawing.Size(79, 36);
            this.btSavePreset.TabIndex = 55;
            this.btSavePreset.Text = "s_Preset";
            this.btSavePreset.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btSavePreset.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btSavePreset.UseAccentColor = false;
            this.btSavePreset.UseVisualStyleBackColor = true;
            // 
            // btLoadPreset
            // 
            this.btLoadPreset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btLoadPreset.Depth = 0;
            this.btLoadPreset.DrawShadows = true;
            this.btLoadPreset.Font = new System.Drawing.Font("굴림", 9F);
            this.btLoadPreset.ForeColor = System.Drawing.Color.DarkRed;
            this.btLoadPreset.HighEmphasis = true;
            this.btLoadPreset.Icon = null;
            this.btLoadPreset.Location = new System.Drawing.Point(126, 68);
            this.btLoadPreset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btLoadPreset.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btLoadPreset.Name = "btLoadPreset";
            this.btLoadPreset.Size = new System.Drawing.Size(79, 36);
            this.btLoadPreset.TabIndex = 54;
            this.btLoadPreset.Text = "L_Preset";
            this.btLoadPreset.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btLoadPreset.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btLoadPreset.UseAccentColor = false;
            this.btLoadPreset.UseVisualStyleBackColor = true;
            // 
            // btMinMaxfrimVC
            // 
            this.btMinMaxfrimVC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btMinMaxfrimVC.Depth = 0;
            this.btMinMaxfrimVC.DrawShadows = true;
            this.btMinMaxfrimVC.Font = new System.Drawing.Font("굴림", 9F);
            this.btMinMaxfrimVC.ForeColor = System.Drawing.Color.DarkRed;
            this.btMinMaxfrimVC.HighEmphasis = true;
            this.btMinMaxfrimVC.Icon = null;
            this.btMinMaxfrimVC.Location = new System.Drawing.Point(268, 20);
            this.btMinMaxfrimVC.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btMinMaxfrimVC.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btMinMaxfrimVC.Name = "btMinMaxfrimVC";
            this.btMinMaxfrimVC.Size = new System.Drawing.Size(113, 36);
            this.btMinMaxfrimVC.TabIndex = 41;
            this.btMinMaxfrimVC.Text = "MinMax <- VC";
            this.btMinMaxfrimVC.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btMinMaxfrimVC.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btMinMaxfrimVC.UseAccentColor = false;
            this.btMinMaxfrimVC.UseVisualStyleBackColor = true;
            // 
            // btMinMaxtoVC
            // 
            this.btMinMaxtoVC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btMinMaxtoVC.Depth = 0;
            this.btMinMaxtoVC.DrawShadows = true;
            this.btMinMaxtoVC.Font = new System.Drawing.Font("굴림", 9F);
            this.btMinMaxtoVC.ForeColor = System.Drawing.Color.DarkRed;
            this.btMinMaxtoVC.HighEmphasis = true;
            this.btMinMaxtoVC.Icon = null;
            this.btMinMaxtoVC.Location = new System.Drawing.Point(147, 20);
            this.btMinMaxtoVC.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btMinMaxtoVC.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btMinMaxtoVC.Name = "btMinMaxtoVC";
            this.btMinMaxtoVC.Size = new System.Drawing.Size(113, 36);
            this.btMinMaxtoVC.TabIndex = 41;
            this.btMinMaxtoVC.Text = "MinMax -> VC";
            this.btMinMaxtoVC.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btMinMaxtoVC.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btMinMaxtoVC.UseAccentColor = false;
            this.btMinMaxtoVC.UseVisualStyleBackColor = true;
            // 
            // btUpdateCOM
            // 
            this.btUpdateCOM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btUpdateCOM.Depth = 0;
            this.btUpdateCOM.DrawShadows = true;
            this.btUpdateCOM.Font = new System.Drawing.Font("굴림", 9F);
            this.btUpdateCOM.ForeColor = System.Drawing.Color.DarkRed;
            this.btUpdateCOM.HighEmphasis = true;
            this.btUpdateCOM.Icon = null;
            this.btUpdateCOM.Location = new System.Drawing.Point(6, 20);
            this.btUpdateCOM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btUpdateCOM.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btUpdateCOM.Name = "btUpdateCOM";
            this.btUpdateCOM.Size = new System.Drawing.Size(136, 36);
            this.btUpdateCOM.TabIndex = 27;
            this.btUpdateCOM.Text = "Update COM port";
            this.btUpdateCOM.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btUpdateCOM.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btUpdateCOM.UseAccentColor = false;
            this.btUpdateCOM.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Depth = 0;
            this.button3.DrawShadows = true;
            this.button3.Font = new System.Drawing.Font("굴림", 9F);
            this.button3.ForeColor = System.Drawing.Color.DarkRed;
            this.button3.HighEmphasis = true;
            this.button3.Icon = null;
            this.button3.Location = new System.Drawing.Point(300, 68);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 36);
            this.button3.TabIndex = 39;
            this.button3.Text = "SNU Export";
            this.button3.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.button3.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button3.UseAccentColor = false;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // gbValveControl
            // 
            this.gbValveControl.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gbValveControl.BorderWidth = 1;
            this.gbValveControl.Controls.Add(this.btValve);
            this.gbValveControl.Controls.Add(this.btValveEventAbort);
            this.gbValveControl.Controls.Add(this.label11);
            this.gbValveControl.Controls.Add(this.btValveEventOn);
            this.gbValveControl.Controls.Add(this.nUDEmergencyNumber);
            this.gbValveControl.Controls.Add(this.label1);
            this.gbValveControl.Controls.Add(this.cbValveControlEnable);
            this.gbValveControl.Controls.Add(this.btValveControlGraph);
            this.gbValveControl.Controls.Add(this.btValveControlSetup);
            this.gbValveControl.Controls.Add(this.cbDisposeVCData);
            this.gbValveControl.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.gbValveControl.ForeColor = System.Drawing.Color.DarkRed;
            this.gbValveControl.Location = new System.Drawing.Point(6, 6);
            this.gbValveControl.Name = "gbValveControl";
            this.gbValveControl.ShowText = true;
            this.gbValveControl.Size = new System.Drawing.Size(419, 127);
            this.gbValveControl.TabIndex = 62;
            this.gbValveControl.TabStop = false;
            this.gbValveControl.Text = "Valve Control";
            this.gbValveControl.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // btValve
            // 
            this.btValve.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btValve.Depth = 0;
            this.btValve.DrawShadows = true;
            this.btValve.Font = new System.Drawing.Font("굴림", 9F);
            this.btValve.HighEmphasis = true;
            this.btValve.Icon = null;
            this.btValve.Location = new System.Drawing.Point(248, 20);
            this.btValve.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btValve.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btValve.Name = "btValve";
            this.btValve.Size = new System.Drawing.Size(51, 36);
            this.btValve.TabIndex = 28;
            this.btValve.Text = "Test";
            this.btValve.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btValve.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btValve.UseAccentColor = false;
            this.btValve.UseVisualStyleBackColor = true;
            // 
            // btValveEventAbort
            // 
            this.btValveEventAbort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btValveEventAbort.Depth = 0;
            this.btValveEventAbort.DrawShadows = true;
            this.btValveEventAbort.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btValveEventAbort.ForeColor = System.Drawing.Color.DarkRed;
            this.btValveEventAbort.HighEmphasis = true;
            this.btValveEventAbort.Icon = null;
            this.btValveEventAbort.Location = new System.Drawing.Point(182, 20);
            this.btValveEventAbort.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btValveEventAbort.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btValveEventAbort.Name = "btValveEventAbort";
            this.btValveEventAbort.Size = new System.Drawing.Size(58, 36);
            this.btValveEventAbort.TabIndex = 39;
            this.btValveEventAbort.Text = "Abort";
            this.btValveEventAbort.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btValveEventAbort.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btValveEventAbort.UseAccentColor = false;
            this.btValveEventAbort.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Depth = 0;
            this.label11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label11.Location = new System.Drawing.Point(92, 25);
            this.label11.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 19);
            this.label11.TabIndex = 47;
            this.label11.Text = "Event:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btValveEventOn
            // 
            this.btValveEventOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btValveEventOn.Depth = 0;
            this.btValveEventOn.DrawShadows = true;
            this.btValveEventOn.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btValveEventOn.ForeColor = System.Drawing.Color.DarkRed;
            this.btValveEventOn.HighEmphasis = true;
            this.btValveEventOn.Icon = null;
            this.btValveEventOn.Location = new System.Drawing.Point(138, 20);
            this.btValveEventOn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btValveEventOn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btValveEventOn.Name = "btValveEventOn";
            this.btValveEventOn.Size = new System.Drawing.Size(40, 36);
            this.btValveEventOn.TabIndex = 39;
            this.btValveEventOn.Text = "On";
            this.btValveEventOn.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btValveEventOn.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btValveEventOn.UseAccentColor = false;
            this.btValveEventOn.UseVisualStyleBackColor = true;
            // 
            // nUDEmergencyNumber
            // 
            this.nUDEmergencyNumber.Font = new System.Drawing.Font("굴림", 9F);
            this.nUDEmergencyNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.nUDEmergencyNumber.Location = new System.Drawing.Point(219, 83);
            this.nUDEmergencyNumber.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nUDEmergencyNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDEmergencyNumber.Name = "nUDEmergencyNumber";
            this.nUDEmergencyNumber.Size = new System.Drawing.Size(52, 21);
            this.nUDEmergencyNumber.TabIndex = 45;
            this.nUDEmergencyNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUDEmergencyNumber.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(93, 86);
            this.label1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 19);
            this.label1.TabIndex = 46;
            this.label1.Text = "Daily Min. Count:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbValveControlEnable
            // 
            this.cbValveControlEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbValveControlEnable.AutoSize = true;
            this.cbValveControlEnable.Depth = 0;
            this.cbValveControlEnable.Font = new System.Drawing.Font("굴림", 9F);
            this.cbValveControlEnable.Location = new System.Drawing.Point(308, 25);
            this.cbValveControlEnable.Margin = new System.Windows.Forms.Padding(0);
            this.cbValveControlEnable.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbValveControlEnable.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbValveControlEnable.Name = "cbValveControlEnable";
            this.cbValveControlEnable.Ripple = true;
            this.cbValveControlEnable.Size = new System.Drawing.Size(107, 37);
            this.cbValveControlEnable.TabIndex = 40;
            this.cbValveControlEnable.Text = "Enable VC";
            this.cbValveControlEnable.UseVisualStyleBackColor = true;
            // 
            // btValveControlGraph
            // 
            this.btValveControlGraph.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btValveControlGraph.Depth = 0;
            this.btValveControlGraph.DrawShadows = true;
            this.btValveControlGraph.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btValveControlGraph.ForeColor = System.Drawing.Color.DarkRed;
            this.btValveControlGraph.HighEmphasis = true;
            this.btValveControlGraph.Icon = null;
            this.btValveControlGraph.Location = new System.Drawing.Point(6, 20);
            this.btValveControlGraph.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btValveControlGraph.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btValveControlGraph.Name = "btValveControlGraph";
            this.btValveControlGraph.Size = new System.Drawing.Size(61, 36);
            this.btValveControlGraph.TabIndex = 39;
            this.btValveControlGraph.Text = "Graph";
            this.btValveControlGraph.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btValveControlGraph.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btValveControlGraph.UseAccentColor = false;
            this.btValveControlGraph.UseVisualStyleBackColor = true;
            // 
            // btValveControlSetup
            // 
            this.btValveControlSetup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btValveControlSetup.Depth = 0;
            this.btValveControlSetup.DrawShadows = true;
            this.btValveControlSetup.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btValveControlSetup.ForeColor = System.Drawing.Color.DarkRed;
            this.btValveControlSetup.HighEmphasis = true;
            this.btValveControlSetup.Icon = null;
            this.btValveControlSetup.Location = new System.Drawing.Point(7, 68);
            this.btValveControlSetup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btValveControlSetup.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btValveControlSetup.Name = "btValveControlSetup";
            this.btValveControlSetup.Size = new System.Drawing.Size(60, 36);
            this.btValveControlSetup.TabIndex = 57;
            this.btValveControlSetup.Text = "Setup";
            this.btValveControlSetup.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btValveControlSetup.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btValveControlSetup.UseAccentColor = false;
            this.btValveControlSetup.UseVisualStyleBackColor = true;
            // 
            // cbDisposeVCData
            // 
            this.cbDisposeVCData.AutoSize = true;
            this.cbDisposeVCData.Checked = true;
            this.cbDisposeVCData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisposeVCData.Depth = 0;
            this.cbDisposeVCData.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbDisposeVCData.ForeColor = System.Drawing.Color.DarkRed;
            this.cbDisposeVCData.Location = new System.Drawing.Point(276, 85);
            this.cbDisposeVCData.Margin = new System.Windows.Forms.Padding(0);
            this.cbDisposeVCData.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbDisposeVCData.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbDisposeVCData.Name = "cbDisposeVCData";
            this.cbDisposeVCData.Ripple = true;
            this.cbDisposeVCData.Size = new System.Drawing.Size(137, 37);
            this.cbDisposeVCData.TabIndex = 56;
            this.cbDisposeVCData.Text = "Compact Data";
            this.cbDisposeVCData.UseVisualStyleBackColor = true;
            // 
            // gbDebugSetting
            // 
            this.gbDebugSetting.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gbDebugSetting.BorderWidth = 1;
            this.gbDebugSetting.Controls.Add(this.btCmdSendFinish);
            this.gbDebugSetting.Controls.Add(this.btCmdSendStart);
            this.gbDebugSetting.Controls.Add(this.btCmdSendTUR);
            this.gbDebugSetting.Controls.Add(this.nudModuleNumber);
            this.gbDebugSetting.Controls.Add(this.label10);
            this.gbDebugSetting.Controls.Add(this.cbDebugLog);
            this.gbDebugSetting.Controls.Add(this.btCopyBox2);
            this.gbDebugSetting.Controls.Add(this.tbDebugLevel);
            this.gbDebugSetting.Controls.Add(this.btCopyBox1);
            this.gbDebugSetting.Controls.Add(this.label12);
            this.gbDebugSetting.Font = new System.Drawing.Font("굴림", 9F);
            this.gbDebugSetting.ForeColor = System.Drawing.Color.DarkRed;
            this.gbDebugSetting.Location = new System.Drawing.Point(6, 267);
            this.gbDebugSetting.Name = "gbDebugSetting";
            this.gbDebugSetting.ShowText = true;
            this.gbDebugSetting.Size = new System.Drawing.Size(491, 121);
            this.gbDebugSetting.TabIndex = 61;
            this.gbDebugSetting.TabStop = false;
            this.gbDebugSetting.Text = "Debug";
            this.gbDebugSetting.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // btCmdSendFinish
            // 
            this.btCmdSendFinish.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCmdSendFinish.Depth = 0;
            this.btCmdSendFinish.DrawShadows = true;
            this.btCmdSendFinish.Font = new System.Drawing.Font("굴림", 9F);
            this.btCmdSendFinish.HighEmphasis = true;
            this.btCmdSendFinish.Icon = null;
            this.btCmdSendFinish.Location = new System.Drawing.Point(380, 73);
            this.btCmdSendFinish.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btCmdSendFinish.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btCmdSendFinish.Name = "btCmdSendFinish";
            this.btCmdSendFinish.Size = new System.Drawing.Size(61, 36);
            this.btCmdSendFinish.TabIndex = 26;
            this.btCmdSendFinish.Text = "Finish";
            this.btCmdSendFinish.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btCmdSendFinish.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btCmdSendFinish.UseAccentColor = false;
            this.btCmdSendFinish.UseVisualStyleBackColor = true;
            // 
            // btCmdSendStart
            // 
            this.btCmdSendStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCmdSendStart.Depth = 0;
            this.btCmdSendStart.DrawShadows = true;
            this.btCmdSendStart.Font = new System.Drawing.Font("굴림", 9F);
            this.btCmdSendStart.HighEmphasis = true;
            this.btCmdSendStart.Icon = null;
            this.btCmdSendStart.Location = new System.Drawing.Point(325, 73);
            this.btCmdSendStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btCmdSendStart.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btCmdSendStart.Name = "btCmdSendStart";
            this.btCmdSendStart.Size = new System.Drawing.Size(53, 36);
            this.btCmdSendStart.TabIndex = 26;
            this.btCmdSendStart.Text = "Start";
            this.btCmdSendStart.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btCmdSendStart.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btCmdSendStart.UseAccentColor = false;
            this.btCmdSendStart.UseVisualStyleBackColor = true;
            // 
            // btCmdSendTUR
            // 
            this.btCmdSendTUR.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCmdSendTUR.Depth = 0;
            this.btCmdSendTUR.DrawShadows = true;
            this.btCmdSendTUR.Font = new System.Drawing.Font("굴림", 9F);
            this.btCmdSendTUR.HighEmphasis = true;
            this.btCmdSendTUR.Icon = null;
            this.btCmdSendTUR.Location = new System.Drawing.Point(273, 73);
            this.btCmdSendTUR.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btCmdSendTUR.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btCmdSendTUR.Name = "btCmdSendTUR";
            this.btCmdSendTUR.Size = new System.Drawing.Size(49, 36);
            this.btCmdSendTUR.TabIndex = 28;
            this.btCmdSendTUR.Text = "TUR";
            this.btCmdSendTUR.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btCmdSendTUR.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btCmdSendTUR.UseAccentColor = false;
            this.btCmdSendTUR.UseVisualStyleBackColor = true;
            // 
            // nudModuleNumber
            // 
            this.nudModuleNumber.Font = new System.Drawing.Font("굴림", 9F);
            this.nudModuleNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.nudModuleNumber.Location = new System.Drawing.Point(215, 75);
            this.nudModuleNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudModuleNumber.Name = "nudModuleNumber";
            this.nudModuleNumber.Size = new System.Drawing.Size(47, 21);
            this.nudModuleNumber.TabIndex = 44;
            this.nudModuleNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudModuleNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Ivory;
            this.label10.Depth = 0;
            this.label10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(6, 77);
            this.label10.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Send Commnad to Moudle: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDebugLog
            // 
            this.cbDebugLog.AutoSize = true;
            this.cbDebugLog.Depth = 0;
            this.cbDebugLog.Font = new System.Drawing.Font("굴림", 9F);
            this.cbDebugLog.ForeColor = System.Drawing.Color.DarkRed;
            this.cbDebugLog.Location = new System.Drawing.Point(286, 23);
            this.cbDebugLog.Margin = new System.Windows.Forms.Padding(0);
            this.cbDebugLog.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbDebugLog.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbDebugLog.Name = "cbDebugLog";
            this.cbDebugLog.Ripple = true;
            this.cbDebugLog.Size = new System.Drawing.Size(81, 37);
            this.cbDebugLog.TabIndex = 52;
            this.cbDebugLog.Text = "Debug";
            this.cbDebugLog.UseVisualStyleBackColor = true;
            // 
            // btCopyBox2
            // 
            this.btCopyBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCopyBox2.Depth = 0;
            this.btCopyBox2.DrawShadows = true;
            this.btCopyBox2.Font = new System.Drawing.Font("굴림", 9F);
            this.btCopyBox2.HighEmphasis = true;
            this.btCopyBox2.Icon = null;
            this.btCopyBox2.Location = new System.Drawing.Point(221, 20);
            this.btCopyBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btCopyBox2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btCopyBox2.Name = "btCopyBox2";
            this.btCopyBox2.Size = new System.Drawing.Size(56, 36);
            this.btCopyBox2.TabIndex = 42;
            this.btCopyBox2.Text = "Right";
            this.btCopyBox2.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btCopyBox2.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btCopyBox2.UseAccentColor = false;
            this.btCopyBox2.UseVisualStyleBackColor = true;
            // 
            // tbDebugLevel
            // 
            this.tbDebugLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDebugLevel.Depth = 0;
            this.tbDebugLevel.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbDebugLevel.ForeColor = System.Drawing.Color.DarkRed;
            this.tbDebugLevel.Location = new System.Drawing.Point(380, 20);
            this.tbDebugLevel.MaxLength = 50;
            this.tbDebugLevel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbDebugLevel.Multiline = false;
            this.tbDebugLevel.Name = "tbDebugLevel";
            this.tbDebugLevel.Password = true;
            this.tbDebugLevel.Size = new System.Drawing.Size(72, 36);
            this.tbDebugLevel.TabIndex = 53;
            this.tbDebugLevel.Text = "";
            this.tbDebugLevel.UseTallSize = false;
            // 
            // btCopyBox1
            // 
            this.btCopyBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCopyBox1.Depth = 0;
            this.btCopyBox1.DrawShadows = true;
            this.btCopyBox1.Font = new System.Drawing.Font("굴림", 9F);
            this.btCopyBox1.HighEmphasis = true;
            this.btCopyBox1.Icon = null;
            this.btCopyBox1.Location = new System.Drawing.Point(170, 20);
            this.btCopyBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btCopyBox1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btCopyBox1.Name = "btCopyBox1";
            this.btCopyBox1.Size = new System.Drawing.Size(47, 36);
            this.btCopyBox1.TabIndex = 43;
            this.btCopyBox1.Text = "Left";
            this.btCopyBox1.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btCopyBox1.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btCopyBox1.UseAccentColor = false;
            this.btCopyBox1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Depth = 0;
            this.label12.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(7, 24);
            this.label12.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 19);
            this.label12.TabIndex = 46;
            this.label12.Text = "Sys. Log to clipboard:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.cbAutoStart);
            this.tabPage5.Controls.Add(this.listBox1);
            this.tabPage5.Controls.Add(this.gbParameterSetting);
            this.tabPage5.ImageKey = "round_report_problem_white_24dp.png";
            this.tabPage5.Location = new System.Drawing.Point(4, 31);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1015, 520);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Parameter";
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Depth = 0;
            this.cbAutoStart.Enabled = false;
            this.cbAutoStart.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbAutoStart.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cbAutoStart.Location = new System.Drawing.Point(388, 6);
            this.cbAutoStart.Margin = new System.Windows.Forms.Padding(0);
            this.cbAutoStart.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbAutoStart.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Ripple = true;
            this.cbAutoStart.Size = new System.Drawing.Size(207, 37);
            this.cbAutoStart.TabIndex = 61;
            this.cbAutoStart.Text = "Auto start with Windows";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.listBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(294, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(433, 350);
            this.listBox1.TabIndex = 60;
            // 
            // gbParameterSetting
            // 
            this.gbParameterSetting.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gbParameterSetting.BorderWidth = 1;
            this.gbParameterSetting.Controls.Add(this.cbTCompensation);
            this.gbParameterSetting.Controls.Add(this.tableLayoutPanel4);
            this.gbParameterSetting.Controls.Add(this.lbParameterMxCx);
            this.gbParameterSetting.Controls.Add(this.btParaSetAll);
            this.gbParameterSetting.Controls.Add(this.btParaSet);
            this.gbParameterSetting.Controls.Add(this.tableLayoutPanel1);
            this.gbParameterSetting.Controls.Add(this.btTmAdjustLast);
            this.gbParameterSetting.Controls.Add(this.btTmAdjustAll);
            this.gbParameterSetting.Controls.Add(this.btTmAdjust);
            this.gbParameterSetting.Controls.Add(this.btExitFactoryMode);
            this.gbParameterSetting.Controls.Add(this.cbDataFilterON);
            this.gbParameterSetting.Controls.Add(this.btTmAdaptive);
            this.gbParameterSetting.Controls.Add(this.label14);
            this.gbParameterSetting.Controls.Add(this.label13);
            this.gbParameterSetting.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbParameterSetting.ForeColor = System.Drawing.Color.DarkRed;
            this.gbParameterSetting.Location = new System.Drawing.Point(6, 6);
            this.gbParameterSetting.Name = "gbParameterSetting";
            this.gbParameterSetting.ShowText = true;
            this.gbParameterSetting.Size = new System.Drawing.Size(282, 511);
            this.gbParameterSetting.TabIndex = 62;
            this.gbParameterSetting.TabStop = false;
            this.gbParameterSetting.Text = "SF Parameter";
            this.gbParameterSetting.TextColor = System.Drawing.Color.DodgerBlue;
            // 
            // cbTCompensation
            // 
            this.cbTCompensation.AutoSize = true;
            this.cbTCompensation.Depth = 0;
            this.cbTCompensation.Font = new System.Drawing.Font("굴림", 9F);
            this.cbTCompensation.Location = new System.Drawing.Point(9, 408);
            this.cbTCompensation.Margin = new System.Windows.Forms.Padding(0);
            this.cbTCompensation.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbTCompensation.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbTCompensation.Name = "cbTCompensation";
            this.cbTCompensation.Ripple = true;
            this.cbTCompensation.Size = new System.Drawing.Size(187, 37);
            this.cbTCompensation.TabIndex = 66;
            this.cbTCompensation.Text = "Temp. Compensation";
            this.cbTCompensation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tbParaSet_Tm, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(9, 97);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.70588F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.29412F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(123, 68);
            this.tableLayoutPanel4.TabIndex = 46;
            // 
            // tbParaSet_Tm
            // 
            this.tbParaSet_Tm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbParaSet_Tm.Depth = 0;
            this.tbParaSet_Tm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParaSet_Tm.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbParaSet_Tm.ForeColor = System.Drawing.Color.DarkRed;
            this.tbParaSet_Tm.Location = new System.Drawing.Point(3, 29);
            this.tbParaSet_Tm.MaxLength = 50;
            this.tbParaSet_Tm.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbParaSet_Tm.Multiline = false;
            this.tbParaSet_Tm.Name = "tbParaSet_Tm";
            this.tbParaSet_Tm.Size = new System.Drawing.Size(117, 36);
            this.tbParaSet_Tm.TabIndex = 41;
            this.tbParaSet_Tm.Text = "";
            this.tbParaSet_Tm.UseTallSize = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Depth = 0;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label24.Location = new System.Drawing.Point(3, 0);
            this.label24.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(117, 26);
            this.label24.TabIndex = 43;
            this.label24.Text = "Tm";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbParameterMxCx
            // 
            this.lbParameterMxCx.AutoSize = true;
            this.lbParameterMxCx.Depth = 0;
            this.lbParameterMxCx.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbParameterMxCx.Location = new System.Drawing.Point(123, 177);
            this.lbParameterMxCx.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbParameterMxCx.Name = "lbParameterMxCx";
            this.lbParameterMxCx.Size = new System.Drawing.Size(41, 19);
            this.lbParameterMxCx.TabIndex = 45;
            this.lbParameterMxCx.Text = "MxCx";
            this.lbParameterMxCx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btParaSetAll
            // 
            this.btParaSetAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btParaSetAll.Depth = 0;
            this.btParaSetAll.DrawShadows = true;
            this.btParaSetAll.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btParaSetAll.ForeColor = System.Drawing.Color.DarkRed;
            this.btParaSetAll.HighEmphasis = true;
            this.btParaSetAll.Icon = null;
            this.btParaSetAll.Location = new System.Drawing.Point(139, 267);
            this.btParaSetAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btParaSetAll.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btParaSetAll.Name = "btParaSetAll";
            this.btParaSetAll.Size = new System.Drawing.Size(64, 36);
            this.btParaSetAll.TabIndex = 42;
            this.btParaSetAll.Text = "Set All";
            this.btParaSetAll.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btParaSetAll.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btParaSetAll.UseAccentColor = false;
            this.btParaSetAll.UseVisualStyleBackColor = true;
            // 
            // btParaSet
            // 
            this.btParaSet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btParaSet.Depth = 0;
            this.btParaSet.DrawShadows = true;
            this.btParaSet.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btParaSet.ForeColor = System.Drawing.Color.DarkRed;
            this.btParaSet.HighEmphasis = true;
            this.btParaSet.Icon = null;
            this.btParaSet.Location = new System.Drawing.Point(139, 197);
            this.btParaSet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btParaSet.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btParaSet.Name = "btParaSet";
            this.btParaSet.Size = new System.Drawing.Size(43, 36);
            this.btParaSet.TabIndex = 42;
            this.btParaSet.Text = "Set";
            this.btParaSet.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btParaSet.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btParaSet.UseAccentColor = false;
            this.btParaSet.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.tbParaSet_c, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbParaSet_a, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbParameterC, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbParameterB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbParameterA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbParaSet_b, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.34426F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.65574F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(195, 61);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // tbParaSet_c
            // 
            this.tbParaSet_c.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbParaSet_c.Depth = 0;
            this.tbParaSet_c.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParaSet_c.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbParaSet_c.ForeColor = System.Drawing.Color.DarkRed;
            this.tbParaSet_c.Location = new System.Drawing.Point(133, 27);
            this.tbParaSet_c.MaxLength = 50;
            this.tbParaSet_c.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbParaSet_c.Multiline = false;
            this.tbParaSet_c.Name = "tbParaSet_c";
            this.tbParaSet_c.Size = new System.Drawing.Size(59, 36);
            this.tbParaSet_c.TabIndex = 41;
            this.tbParaSet_c.Text = "";
            this.tbParaSet_c.UseTallSize = false;
            // 
            // tbParaSet_a
            // 
            this.tbParaSet_a.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbParaSet_a.Depth = 0;
            this.tbParaSet_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParaSet_a.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbParaSet_a.ForeColor = System.Drawing.Color.DarkRed;
            this.tbParaSet_a.Location = new System.Drawing.Point(3, 27);
            this.tbParaSet_a.MaxLength = 50;
            this.tbParaSet_a.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbParaSet_a.Multiline = false;
            this.tbParaSet_a.Name = "tbParaSet_a";
            this.tbParaSet_a.Size = new System.Drawing.Size(59, 36);
            this.tbParaSet_a.TabIndex = 41;
            this.tbParaSet_a.Text = "";
            this.tbParaSet_a.UseTallSize = false;
            // 
            // lbParameterC
            // 
            this.lbParameterC.Depth = 0;
            this.lbParameterC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbParameterC.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbParameterC.Location = new System.Drawing.Point(133, 0);
            this.lbParameterC.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbParameterC.Name = "lbParameterC";
            this.lbParameterC.Size = new System.Drawing.Size(59, 24);
            this.lbParameterC.TabIndex = 43;
            this.lbParameterC.Text = "c";
            this.lbParameterC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbParameterB
            // 
            this.lbParameterB.Depth = 0;
            this.lbParameterB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbParameterB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbParameterB.Location = new System.Drawing.Point(68, 0);
            this.lbParameterB.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbParameterB.Name = "lbParameterB";
            this.lbParameterB.Size = new System.Drawing.Size(59, 24);
            this.lbParameterB.TabIndex = 43;
            this.lbParameterB.Text = "b";
            this.lbParameterB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbParameterA
            // 
            this.lbParameterA.Depth = 0;
            this.lbParameterA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbParameterA.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbParameterA.Location = new System.Drawing.Point(3, 0);
            this.lbParameterA.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lbParameterA.Name = "lbParameterA";
            this.lbParameterA.Size = new System.Drawing.Size(59, 24);
            this.lbParameterA.TabIndex = 43;
            this.lbParameterA.Text = "a";
            this.lbParameterA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbParaSet_b
            // 
            this.tbParaSet_b.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbParaSet_b.Depth = 0;
            this.tbParaSet_b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParaSet_b.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbParaSet_b.ForeColor = System.Drawing.Color.DarkRed;
            this.tbParaSet_b.Location = new System.Drawing.Point(68, 27);
            this.tbParaSet_b.MaxLength = 50;
            this.tbParaSet_b.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.tbParaSet_b.Multiline = false;
            this.tbParaSet_b.Name = "tbParaSet_b";
            this.tbParaSet_b.Size = new System.Drawing.Size(59, 36);
            this.tbParaSet_b.TabIndex = 41;
            this.tbParaSet_b.Text = "";
            this.tbParaSet_b.UseTallSize = false;
            // 
            // btTmAdjustLast
            // 
            this.btTmAdjustLast.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTmAdjustLast.Depth = 0;
            this.btTmAdjustLast.DrawShadows = true;
            this.btTmAdjustLast.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTmAdjustLast.ForeColor = System.Drawing.Color.DarkRed;
            this.btTmAdjustLast.HighEmphasis = true;
            this.btTmAdjustLast.Icon = null;
            this.btTmAdjustLast.Location = new System.Drawing.Point(11, 363);
            this.btTmAdjustLast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTmAdjustLast.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTmAdjustLast.Name = "btTmAdjustLast";
            this.btTmAdjustLast.Size = new System.Drawing.Size(124, 36);
            this.btTmAdjustLast.TabIndex = 44;
            this.btTmAdjustLast.Text = "Tm(Last Value)";
            this.btTmAdjustLast.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTmAdjustLast.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTmAdjustLast.UseAccentColor = false;
            this.btTmAdjustLast.UseVisualStyleBackColor = true;
            // 
            // btTmAdjustAll
            // 
            this.btTmAdjustAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTmAdjustAll.Depth = 0;
            this.btTmAdjustAll.DrawShadows = true;
            this.btTmAdjustAll.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTmAdjustAll.ForeColor = System.Drawing.Color.DarkRed;
            this.btTmAdjustAll.HighEmphasis = true;
            this.btTmAdjustAll.Icon = null;
            this.btTmAdjustAll.Location = new System.Drawing.Point(11, 268);
            this.btTmAdjustAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTmAdjustAll.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTmAdjustAll.Name = "btTmAdjustAll";
            this.btTmAdjustAll.Size = new System.Drawing.Size(121, 36);
            this.btTmAdjustAll.TabIndex = 44;
            this.btTmAdjustAll.Text = "Tm Auto(Daily)";
            this.btTmAdjustAll.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTmAdjustAll.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTmAdjustAll.UseAccentColor = false;
            this.btTmAdjustAll.UseVisualStyleBackColor = true;
            // 
            // btTmAdjust
            // 
            this.btTmAdjust.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTmAdjust.Depth = 0;
            this.btTmAdjust.DrawShadows = true;
            this.btTmAdjust.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTmAdjust.ForeColor = System.Drawing.Color.DarkRed;
            this.btTmAdjust.HighEmphasis = true;
            this.btTmAdjust.Icon = null;
            this.btTmAdjust.Location = new System.Drawing.Point(11, 315);
            this.btTmAdjust.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTmAdjust.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTmAdjust.Name = "btTmAdjust";
            this.btTmAdjust.Size = new System.Drawing.Size(130, 36);
            this.btTmAdjust.TabIndex = 44;
            this.btTmAdjust.Text = "Tm Auto(Today)";
            this.btTmAdjust.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTmAdjust.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTmAdjust.UseAccentColor = false;
            this.btTmAdjust.UseVisualStyleBackColor = true;
            // 
            // btExitFactoryMode
            // 
            this.btExitFactoryMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btExitFactoryMode.Depth = 0;
            this.btExitFactoryMode.DrawShadows = true;
            this.btExitFactoryMode.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExitFactoryMode.ForeColor = System.Drawing.Color.DarkRed;
            this.btExitFactoryMode.HighEmphasis = true;
            this.btExitFactoryMode.Icon = null;
            this.btExitFactoryMode.Location = new System.Drawing.Point(139, 363);
            this.btExitFactoryMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btExitFactoryMode.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btExitFactoryMode.Name = "btExitFactoryMode";
            this.btExitFactoryMode.Size = new System.Drawing.Size(46, 36);
            this.btExitFactoryMode.TabIndex = 50;
            this.btExitFactoryMode.Text = "Exit";
            this.btExitFactoryMode.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btExitFactoryMode.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btExitFactoryMode.UseAccentColor = false;
            this.btExitFactoryMode.UseVisualStyleBackColor = true;
            // 
            // cbDataFilterON
            // 
            this.cbDataFilterON.AutoSize = true;
            this.cbDataFilterON.Depth = 0;
            this.cbDataFilterON.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.cbDataFilterON.Location = new System.Drawing.Point(135, 128);
            this.cbDataFilterON.Margin = new System.Windows.Forms.Padding(0);
            this.cbDataFilterON.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbDataFilterON.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.cbDataFilterON.Name = "cbDataFilterON";
            this.cbDataFilterON.Ripple = true;
            this.cbDataFilterON.Size = new System.Drawing.Size(70, 37);
            this.cbDataFilterON.TabIndex = 37;
            this.cbDataFilterON.Text = "Filter";
            this.cbDataFilterON.UseVisualStyleBackColor = true;
            // 
            // btTmAdaptive
            // 
            this.btTmAdaptive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btTmAdaptive.Depth = 0;
            this.btTmAdaptive.DrawShadows = true;
            this.btTmAdaptive.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btTmAdaptive.ForeColor = System.Drawing.Color.DarkRed;
            this.btTmAdaptive.HighEmphasis = true;
            this.btTmAdaptive.Icon = null;
            this.btTmAdaptive.Location = new System.Drawing.Point(12, 198);
            this.btTmAdaptive.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btTmAdaptive.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btTmAdaptive.Name = "btTmAdaptive";
            this.btTmAdaptive.Size = new System.Drawing.Size(121, 36);
            this.btTmAdaptive.TabIndex = 42;
            this.btTmAdaptive.Text = "Tm Auto(Daily)";
            this.btTmAdaptive.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
            this.btTmAdaptive.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btTmAdaptive.UseAccentColor = false;
            this.btTmAdaptive.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Ivory;
            this.label14.Depth = 0;
            this.label14.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(10, 243);
            this.label14.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(182, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Adjust Para for All Mo, Ch";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Ivory;
            this.label13.Depth = 0;
            this.label13.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(10, 178);
            this.label13.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "Adjust Para for";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuIconList
            // 
            this.menuIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuIconList.ImageStream")));
            this.menuIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuIconList.Images.SetKeyName(0, "round_assessment_white_24dp.png");
            this.menuIconList.Images.SetKeyName(1, "round_backup_white_24dp.png");
            this.menuIconList.Images.SetKeyName(2, "round_bluetooth_white_24dp.png");
            this.menuIconList.Images.SetKeyName(3, "round_bookmark_white_24dp.png");
            this.menuIconList.Images.SetKeyName(4, "round_build_white_24dp.png");
            this.menuIconList.Images.SetKeyName(5, "round_gps_fixed_white_24dp.png");
            this.menuIconList.Images.SetKeyName(6, "round_http_white_24dp.png");
            this.menuIconList.Images.SetKeyName(7, "round_report_problem_white_24dp.png");
            this.menuIconList.Images.SetKeyName(8, "round_swap_vert_white_24dp.png");
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem,
            this.disabledItemToolStripMenuItem,
            this.item2ToolStripMenuItem,
            this.toolStripSeparator1,
            this.item3ToolStripMenuItem});
            this.materialContextMenuStrip1.Margin = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.materialContextMenuStrip1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(170, 130);
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.AutoSize = false;
            this.item1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItem1ToolStripMenuItem,
            this.subItem2ToolStripMenuItem});
            this.item1ToolStripMenuItem.Image = global::SapflowApplication.Properties.Resources.minus;
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.item1ToolStripMenuItem.Text = "Item 1";
            // 
            // subItem1ToolStripMenuItem
            // 
            this.subItem1ToolStripMenuItem.AutoSize = false;
            this.subItem1ToolStripMenuItem.Name = "subItem1ToolStripMenuItem";
            this.subItem1ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.subItem1ToolStripMenuItem.Text = "SubItem 1";
            // 
            // subItem2ToolStripMenuItem
            // 
            this.subItem2ToolStripMenuItem.AutoSize = false;
            this.subItem2ToolStripMenuItem.Name = "subItem2ToolStripMenuItem";
            this.subItem2ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.subItem2ToolStripMenuItem.Text = "SubItem 2";
            // 
            // disabledItemToolStripMenuItem
            // 
            this.disabledItemToolStripMenuItem.AutoSize = false;
            this.disabledItemToolStripMenuItem.Enabled = false;
            this.disabledItemToolStripMenuItem.Name = "disabledItemToolStripMenuItem";
            this.disabledItemToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.disabledItemToolStripMenuItem.Text = "Disabled item";
            // 
            // item2ToolStripMenuItem
            // 
            this.item2ToolStripMenuItem.AutoSize = false;
            this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
            this.item2ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.item2ToolStripMenuItem.Text = "Item 2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // item3ToolStripMenuItem
            // 
            this.item3ToolStripMenuItem.AutoSize = false;
            this.item3ToolStripMenuItem.Name = "item3ToolStripMenuItem";
            this.item3ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.item3ToolStripMenuItem.Text = "Item 3";
            // 
            // NewForm2_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 622);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "NewForm2_Demo";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Demo";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbSfModule.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gbChannel.ResumeLayout(false);
            this.gbChannel.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.gbSystemSetting.ResumeLayout(false);
            this.gbSystemSetting.PerformLayout();
            this.gbValveControl.ResumeLayout(false);
            this.gbValveControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEmergencyNumber)).EndInit();
            this.gbDebugSetting.ResumeLayout(false);
            this.gbDebugSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModuleNumber)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.gbParameterSetting.ResumeLayout(false);
            this.gbParameterSetting.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ReaLTaiizor.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ReaLTaiizor.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private ReaLTaiizor.Controls.MaterialToolStripMenuItem item1ToolStripMenuItem;
        private ReaLTaiizor.Controls.MaterialToolStripMenuItem subItem1ToolStripMenuItem;
        private ReaLTaiizor.Controls.MaterialToolStripMenuItem subItem2ToolStripMenuItem;
        private ReaLTaiizor.Controls.MaterialToolStripMenuItem item2ToolStripMenuItem;
        private ReaLTaiizor.Controls.MaterialToolStripMenuItem item3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem disabledItemToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private ImageList menuIconList;
        private System.Windows.Forms.TabPage tabPage7;
        private FlowLayoutPanel flowLayoutPanel6;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.ParrotGroupBox gbSettings;
        private ReaLTaiizor.Controls.MaterialComboBox cbComPort;
        private ReaLTaiizor.Controls.MaterialComboBox cbTimeStep;
        private ReaLTaiizor.Controls.MaterialTextBox AB_tb;
        private ReaLTaiizor.Controls.DungeonListBox listBox2;
        private FlowLayoutPanel flowLayoutPanel4;
        private NumericUpDown nUDEmergencyNumber;
        private NumericUpDown nudModuleNumber;
        private ReaLTaiizor.Controls.MaterialTextBox tbDebugLevel;
        private ReaLTaiizor.Controls.DungeonListBox listBox1;
        private TableLayoutPanel tableLayoutPanel4;
        private ReaLTaiizor.Controls.MaterialTextBox tbParaSet_Tm;
        private TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialTextBox tbParaSet_c;
        private ReaLTaiizor.Controls.MaterialTextBox tbParaSet_a;
        private ReaLTaiizor.Controls.MaterialTextBox tbParaSet_b;
        private ReaLTaiizor.Controls.MaterialButton btConnectControl;
        private ReaLTaiizor.Controls.MaterialButton button6;
        private ReaLTaiizor.Controls.MaterialButton btRefresh;
        private ReaLTaiizor.Controls.MaterialButton btLog;
        private ReaLTaiizor.Controls.MaterialButton btBackupLog;
        private ReaLTaiizor.Controls.MaterialButton btExportSF;
        private ReaLTaiizor.Controls.MaterialButton btStopAction;
        private ReaLTaiizor.Controls.MaterialButton btStartAction;
        private ReaLTaiizor.Controls.ParrotGroupBox groupBox2;
        private ReaLTaiizor.Controls.MaterialButton btTimeScale1D;
        private ReaLTaiizor.Controls.MaterialButton btTimeScaleFullScale;
        private ReaLTaiizor.Controls.MaterialButton btTimeScale2d;
        private ReaLTaiizor.Controls.MaterialButton btTimeScale2H;
        private ReaLTaiizor.Controls.MaterialButton btWindowExtend;
        private ReaLTaiizor.Controls.MaterialButton btBackupLogDay;
        private ReaLTaiizor.Controls.ParrotGroupBox gbSystemSetting;
        private ReaLTaiizor.Controls.MaterialButton btSetup;
        private ReaLTaiizor.Controls.MaterialButton btSavePreset;
        private ReaLTaiizor.Controls.MaterialButton btLoadPreset;
        private ReaLTaiizor.Controls.MaterialButton btMinMaxfrimVC;
        private ReaLTaiizor.Controls.MaterialButton btMinMaxtoVC;
        private ReaLTaiizor.Controls.MaterialButton btUpdateCOM;
        private ReaLTaiizor.Controls.MaterialButton button3;
        private ReaLTaiizor.Controls.ParrotGroupBox gbValveControl;
        private ReaLTaiizor.Controls.MaterialButton btValve;
        private ReaLTaiizor.Controls.MaterialButton btValveEventAbort;
        private ReaLTaiizor.Controls.MaterialButton btValveEventOn;
        private ReaLTaiizor.Controls.MaterialButton btValveControlGraph;
        private ReaLTaiizor.Controls.MaterialButton btValveControlSetup;
        private ReaLTaiizor.Controls.ParrotGroupBox gbDebugSetting;
        private ReaLTaiizor.Controls.MaterialButton btCmdSendFinish;
        private ReaLTaiizor.Controls.MaterialButton btCmdSendStart;
        private ReaLTaiizor.Controls.MaterialButton btCmdSendTUR;
        private ReaLTaiizor.Controls.MaterialButton btCopyBox2;
        private ReaLTaiizor.Controls.MaterialButton btCopyBox1;
        private ReaLTaiizor.Controls.ParrotGroupBox gbParameterSetting;
        private ReaLTaiizor.Controls.MaterialButton btParaSetAll;
        private ReaLTaiizor.Controls.MaterialButton btParaSet;
        private ReaLTaiizor.Controls.MaterialButton btTmAdjustLast;
        private ReaLTaiizor.Controls.MaterialButton btTmAdjustAll;
        private ReaLTaiizor.Controls.MaterialButton btTmAdjust;
        private ReaLTaiizor.Controls.MaterialButton btExitFactoryMode;
        private ReaLTaiizor.Controls.MaterialButton btTmAdaptive;
        private ReaLTaiizor.Controls.ParrotGroupBox gbSfModule;
        private TableLayoutPanel tableLayoutPanel3;
        private ReaLTaiizor.Controls.MaterialLabel label19;
        private ReaLTaiizor.Controls.MaterialButton btSFModuleSelectionNumberPrevious;
        private ReaLTaiizor.Controls.MaterialButton btGraphOpen;
        private ReaLTaiizor.Controls.MaterialButton btCalibration;
        private ReaLTaiizor.Controls.MaterialButton btSFModuleSelectionNumberNext;
        private ReaLTaiizor.Controls.MaterialComboBox cbSFModuleSelectionNumber;
        private ReaLTaiizor.Controls.MaterialButton btMultiViewOpen;
        private ReaLTaiizor.Controls.MaterialProgressBar progressBar1;
        private ReaLTaiizor.Controls.ParrotGroupBox gbChannel;
        private TableLayoutPanel tableLayoutPanel5;
        private ReaLTaiizor.Controls.MaterialLabel label8;
        private ReaLTaiizor.Controls.MaterialLabel label9;
        private TableLayoutPanel tableLayoutPanel2;
        private ReaLTaiizor.Controls.MaterialTextBox tbY1Max;
        private ReaLTaiizor.Controls.MaterialTextBox tbY1Min;
        private ReaLTaiizor.Controls.MaterialCheckBox cbDisposeData;
        private ReaLTaiizor.Controls.MaterialTextBox tbY2Min;
        private ReaLTaiizor.Controls.MaterialTextBox tbY2Max;
        private ReaLTaiizor.Controls.MaterialLabel label2;
        private ReaLTaiizor.Controls.MaterialTextBox tbY1MinValue;
        private ReaLTaiizor.Controls.MaterialTextBox tbY2MinValue;
        private ReaLTaiizor.Controls.MaterialTextBox tbY1MaxValue;
        private ReaLTaiizor.Controls.MaterialTextBox tbY2MaxValue;
        private FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialButton btParaReset_Offset;
        private ReaLTaiizor.Controls.MaterialButton btParaSet_Offset;
        private ReaLTaiizor.Controls.MaterialTextBox tbParaSet_Tm_Offset;
        private FlowLayoutPanel flowLayoutPanel2;
        private ReaLTaiizor.Controls.MaterialRadioButton rbCH1;
        private ReaLTaiizor.Controls.MaterialRadioButton rbCH2;
        private ReaLTaiizor.Controls.MaterialRadioButton rbCH3;
        private ReaLTaiizor.Controls.MaterialRadioButton rbCH4;
        private ReaLTaiizor.Controls.MaterialLabel lbStartTime;
        private ReaLTaiizor.Controls.MaterialLabel lbDateTime;
        private ReaLTaiizor.Controls.MaterialLabel label3;
        private ReaLTaiizor.Controls.MaterialLabel label4;
        private ReaLTaiizor.Controls.MaterialLabel label5;
        private ReaLTaiizor.Controls.MaterialLabel label6;
        private ReaLTaiizor.Controls.MaterialLabel label7;
        private ReaLTaiizor.Controls.MaterialCheckBox cbY1Min;
        private ReaLTaiizor.Controls.MaterialCheckBox cbY2Min;
        private ReaLTaiizor.Controls.MaterialCheckBox cbY2Max;
        private ReaLTaiizor.Controls.MaterialCheckBox cbY1Max;
        private ReaLTaiizor.Controls.MaterialLabel label17;
        private ReaLTaiizor.Controls.MaterialLabel label16;
        private ReaLTaiizor.Controls.MaterialLabel label15;
        private ReaLTaiizor.Controls.MaterialLabel AB_count;
        private ReaLTaiizor.Controls.MaterialLabel lbExtendScreen;
        private ReaLTaiizor.Controls.MaterialLabel label20;
        private ReaLTaiizor.Controls.MaterialLabel label11;
        private ReaLTaiizor.Controls.MaterialLabel label1;
        private ReaLTaiizor.Controls.MaterialLabel label10;
        private ReaLTaiizor.Controls.MaterialLabel label12;
        private ReaLTaiizor.Controls.MaterialLabel label24;
        private ReaLTaiizor.Controls.MaterialLabel lbParameterMxCx;
        private ReaLTaiizor.Controls.MaterialLabel lbParameterC;
        private ReaLTaiizor.Controls.MaterialLabel lbParameterB;
        private ReaLTaiizor.Controls.MaterialLabel lbParameterA;
        private ReaLTaiizor.Controls.MaterialLabel label14;
        private ReaLTaiizor.Controls.MaterialLabel label13;
        private ReaLTaiizor.Controls.MaterialLabel lbTemperature;
        private ReaLTaiizor.Controls.MaterialLabel lbHumidity;
        private ReaLTaiizor.Controls.MaterialLabel label18;
        private ReaLTaiizor.Controls.MaterialCheckBox AB_check;
        private ReaLTaiizor.Controls.MaterialCheckBox cbLockControl;
        private ReaLTaiizor.Controls.MaterialCheckBox cbAlwaysOnTop;
        private ReaLTaiizor.Controls.MaterialCheckBox cbValveControlEnable;
        private ReaLTaiizor.Controls.MaterialCheckBox cbDisposeVCData;
        private ReaLTaiizor.Controls.MaterialCheckBox cbDebugLog;
        private ReaLTaiizor.Controls.MaterialCheckBox cbAutoStart;
        private ReaLTaiizor.Controls.MaterialCheckBox cbTCompensation;
        private ReaLTaiizor.Controls.MaterialCheckBox cbDataFilterON;
        private ReaLTaiizor.Controls.MaterialComboBox cbBackupTerm;
    }
}