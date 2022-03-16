namespace SapflowApplication
{
    partial class frmSubChannelChart
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbDPosition = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbY1Position = new System.Windows.Forms.Label();
            this.lbRTemp = new System.Windows.Forms.Label();
            this.lbY2Position = new System.Windows.Forms.Label();
            this.lbTemp = new System.Windows.Forms.Label();
            this.lbTempValue = new System.Windows.Forms.Label();
            this.lbHumi = new System.Windows.Forms.Label();
            this.lbHumiValue = new System.Windows.Forms.Label();
            this.lbVPD = new System.Windows.Forms.Label();
            this.lbVPDValue = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 281);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbDPosition);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.lbY1Position);
            this.flowLayoutPanel1.Controls.Add(this.lbRTemp);
            this.flowLayoutPanel1.Controls.Add(this.lbY2Position);
            this.flowLayoutPanel1.Controls.Add(this.lbTemp);
            this.flowLayoutPanel1.Controls.Add(this.lbTempValue);
            this.flowLayoutPanel1.Controls.Add(this.lbHumi);
            this.flowLayoutPanel1.Controls.Add(this.lbHumiValue);
            this.flowLayoutPanel1.Controls.Add(this.lbVPD);
            this.flowLayoutPanel1.Controls.Add(this.lbVPDValue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 260);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(506, 18);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbDPosition
            // 
            this.lbDPosition.AutoSize = true;
            this.lbDPosition.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDPosition.ForeColor = System.Drawing.Color.DarkRed;
            this.lbDPosition.Location = new System.Drawing.Point(3, 0);
            this.lbDPosition.Name = "lbDPosition";
            this.lbDPosition.Size = new System.Drawing.Size(147, 15);
            this.lbDPosition.TabIndex = 2;
            this.lbDPosition.Text = "--/--/-- --:--:--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(156, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "SF";
            // 
            // lbY1Position
            // 
            this.lbY1Position.AutoSize = true;
            this.lbY1Position.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbY1Position.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbY1Position.Location = new System.Drawing.Point(189, 0);
            this.lbY1Position.Name = "lbY1Position";
            this.lbY1Position.Size = new System.Drawing.Size(34, 15);
            this.lbY1Position.TabIndex = 3;
            this.lbY1Position.Text = "---";
            // 
            // lbRTemp
            // 
            this.lbRTemp.AutoSize = true;
            this.lbRTemp.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbRTemp.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbRTemp.Location = new System.Drawing.Point(229, 0);
            this.lbRTemp.Name = "lbRTemp";
            this.lbRTemp.Size = new System.Drawing.Size(18, 15);
            this.lbRTemp.TabIndex = 1;
            this.lbRTemp.Text = "R";
            // 
            // lbY2Position
            // 
            this.lbY2Position.AutoSize = true;
            this.lbY2Position.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbY2Position.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbY2Position.Location = new System.Drawing.Point(253, 0);
            this.lbY2Position.Name = "lbY2Position";
            this.lbY2Position.Size = new System.Drawing.Size(34, 15);
            this.lbY2Position.TabIndex = 4;
            this.lbY2Position.Text = "---";
            // 
            // lbTemp
            // 
            this.lbTemp.AutoSize = true;
            this.lbTemp.Enabled = false;
            this.lbTemp.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTemp.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTemp.Location = new System.Drawing.Point(293, 0);
            this.lbTemp.Name = "lbTemp";
            this.lbTemp.Size = new System.Drawing.Size(16, 15);
            this.lbTemp.TabIndex = 1;
            this.lbTemp.Text = "T";
            this.lbTemp.Visible = false;
            // 
            // lbTempValue
            // 
            this.lbTempValue.AutoSize = true;
            this.lbTempValue.Enabled = false;
            this.lbTempValue.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTempValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTempValue.Location = new System.Drawing.Point(315, 0);
            this.lbTempValue.Name = "lbTempValue";
            this.lbTempValue.Size = new System.Drawing.Size(34, 15);
            this.lbTempValue.TabIndex = 3;
            this.lbTempValue.Text = "---";
            this.lbTempValue.Visible = false;
            // 
            // lbHumi
            // 
            this.lbHumi.AutoSize = true;
            this.lbHumi.Enabled = false;
            this.lbHumi.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbHumi.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbHumi.Location = new System.Drawing.Point(355, 0);
            this.lbHumi.Name = "lbHumi";
            this.lbHumi.Size = new System.Drawing.Size(18, 15);
            this.lbHumi.TabIndex = 1;
            this.lbHumi.Text = "H";
            this.lbHumi.Visible = false;
            // 
            // lbHumiValue
            // 
            this.lbHumiValue.AutoSize = true;
            this.lbHumiValue.Enabled = false;
            this.lbHumiValue.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbHumiValue.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbHumiValue.Location = new System.Drawing.Point(379, 0);
            this.lbHumiValue.Name = "lbHumiValue";
            this.lbHumiValue.Size = new System.Drawing.Size(34, 15);
            this.lbHumiValue.TabIndex = 4;
            this.lbHumiValue.Text = "---";
            this.lbHumiValue.Visible = false;
            // 
            // lbVPD
            // 
            this.lbVPD.AutoSize = true;
            this.lbVPD.Enabled = false;
            this.lbVPD.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbVPD.ForeColor = System.Drawing.Color.Tomato;
            this.lbVPD.Location = new System.Drawing.Point(419, 0);
            this.lbVPD.Name = "lbVPD";
            this.lbVPD.Size = new System.Drawing.Size(38, 15);
            this.lbVPD.TabIndex = 1;
            this.lbVPD.Text = "VPD";
            this.lbVPD.Visible = false;
            // 
            // lbVPDValue
            // 
            this.lbVPDValue.AutoSize = true;
            this.lbVPDValue.Enabled = false;
            this.lbVPDValue.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbVPDValue.ForeColor = System.Drawing.Color.Tomato;
            this.lbVPDValue.Location = new System.Drawing.Point(463, 0);
            this.lbVPDValue.Name = "lbVPDValue";
            this.lbVPDValue.Size = new System.Drawing.Size(34, 15);
            this.lbVPDValue.TabIndex = 4;
            this.lbVPDValue.Text = "---";
            this.lbVPDValue.Visible = false;
            // 
            // chart1
            // 
            lineAnnotation1.AnchorOffsetY = -2.5D;
            lineAnnotation1.Height = -5D;
            lineAnnotation1.Name = "LineAnnotation1";
            lineAnnotation1.SmartLabelStyle.IsOverlappedHidden = false;
            lineAnnotation1.Width = 0D;
            this.chart1.Annotations.Add(lineAnnotation1);
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.ScaleView.Zoomable = false;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY2.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY2.ScaleView.Zoomable = false;
            chartArea1.BorderColor = System.Drawing.Color.Gray;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Lime;
            chartArea1.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.Aquamarine;
            chartArea1.CursorY.LineColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Ivory;
            legend1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Enabled = false;
            legend1.ForeColor = System.Drawing.Color.DimGray;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.ReversedSeriesOrder;
            legend1.Name = "Legend1";
            legend1.TextWrapThreshold = 20;
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.EmptyPointStyle.BorderWidth = 5;
            series1.LabelBorderWidth = 8;
            series1.Legend = "Legend1";
            series1.Name = "SF";
            series1.YValuesPerPoint = 6;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Temp";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(506, 251);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "title1";
            title1.Text = "SF Value";
            title1.Visible = false;
            this.chart1.Titles.Add(title1);
            this.chart1.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chart1_AxisViewChanged);
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmSubChannelChart_MouseClick);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseDown);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseMove);
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseUp);
            this.chart1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseWheel);
            // 
            // frmSubChannelChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 281);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Tomato;
            this.Name = "frmSubChannelChart";
            this.ShowIcon = false;
            this.Text = "frmValveControl";
            this.Load += new System.EventHandler(this.frmSubChannelChart_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmSubChannelChart_MouseClick);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbDPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbY1Position;
        private System.Windows.Forms.Label lbRTemp;
        private System.Windows.Forms.Label lbY2Position;
        private System.Windows.Forms.Label lbTemp;
        private System.Windows.Forms.Label lbTempValue;
        private System.Windows.Forms.Label lbHumi;
        private System.Windows.Forms.Label lbHumiValue;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbVPD;
        private System.Windows.Forms.Label lbVPDValue;
    }
}