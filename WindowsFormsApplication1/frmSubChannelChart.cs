using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SapflowApplication
{
    public partial class frmSubChannelChart : Form
    {
        private frmSfModule parentForm;
        private int formID;
        private int formMo;

        public frmSubChannelChart(frmSfModule parentForm, int formMo, int formID)
        {
            this.parentForm = parentForm;
            this.formMo = formMo;
            this.formID = formID;

            InitializeComponent();
        }


        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            Chart chart = this.chart1;

            //  if (chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum > 10000)
            {
                //    return;
            }


            if (e.Delta < 0)
            {
                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas[0].RecalculateAxesScale();
                executeAxisViewChanged();
            }
            else
            {
                chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

                double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double xCur = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X);

                if (chart.Series["SF"].Points.Count > 0)
                {
                    DataPoint yDataPoint = chart.Series["SF"].Points.FindByValue(xCur);
                    if (!(yDataPoint == null))
                    {
                        double yCur = yDataPoint.GetValueByName("SF");
                        lbY1Position.Text = DateTime.FromOADate(yCur).ToString();
                    }
                }


                if ((xCur > xMin) && (xCur < xMax))
                {
                    double posXStart = xCur - ((xCur - xMin) / 2);
                    double posXFinish = xCur + ((xMax - xCur) / 2);

                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    //                chart.ChartAreas[0].RecalculateAxesScale();
                    executeAxisViewChanged();
                    //tbPosition.Text = xCur.ToString();


                    // tbViewMinimum.Text = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum.ToString();
                    // tbViewMaximum.Text = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum.ToString();


                    lbDPosition.Text = DateTime.FromOADate(chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X)).ToString("yyyy-MM-dd HH:mm:ss");
                    // tbDViewMinimum.Text = DateTime.FromOADate(chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum).ToString();
                    // tbDViewMaximum.Text = DateTime.FromOADate(chart.ChartArea[0].AxisX.ScaleView.ViewMaximum).ToString();

                }
            }
        }

        private bool fDragProcessing;
        private double xDragStartPosition, xDragMinPosition, xDragMaxPosition;

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = this.chart1;

            double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

            double xCur, yCur;
            try
            {
                xCur = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X);
                yCur = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y);

            }
            catch (Exception)
            {
                //                updateListBox("Error during communicate with Arduino.");
                //              readString = "ERROR";
                return;
            }

            //tbY2Position.Text = yCur.ToString();

            try
            {

                if (((xCur > xMin) && (xCur < xMax)) && ((yCur >= yMin) && (yCur <= yMax)))
            {
                //tbPosition.Text = xCur.ToString();
                // tbViewMinimum.Text = xMin.ToString();
                // tbViewMaximum.Text = SF_Test.m_SampleCount.ToString(); // xMax.ToString();


                // tbDViewMinimum.Text = DateTime.FromOADate(xMin).ToString();
                //  tbDViewMaximum.Text = DateTime.FromOADate(xMax).ToString();

                // Graphics formGraphics = this.chart1.CreateGraphics();
                // Pen myPen = new Pen(Color.Green);
                // formGraphics.DrawLine(myPen, e.Location.X, 0, e.Location.X, 200);
                // myPen.Dispose();
                // formGraphics.Dispose();

                // Find Y Data by Index
                    for (int index = (int)chart.Series["SF"].Points.Count - 1; index >= 0; index--)
                {
                    //      if (Array.GetLength(chart.Series["SF"].Points) > SF_Test.m_SampleCount - 1)
                    double tempXValue = chart.Series["SF"].Points[index].XValue;
                        if (tempXValue <= xCur)
                    {
                        double yCurTemp;

                        if (parentForm.fgPositionInfo)
                        {
                            chart.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = tempXValue;
                        }
                        else
                        {
                            chart.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = -1;
                        }
                        lbDPosition.Text = DateTime.FromOADate(tempXValue).ToString("yy/MM/dd HH:mm:ss");

                        // Set SF
                        yCurTemp = chart.Series[0].Points[index].YValues[0];
                        lbY1Position.Text = yCurTemp.ToString("0.000");
                        if (parentForm.fgPositionInfo)
                        {
                            chart.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = yCurTemp;
                            chart.ChartAreas[0].AxisY.StripLines[0].Text = yCurTemp.ToString("0.000");
                        }
                        else
                        {
                            chart.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = -1;
                            chart.ChartAreas[0].AxisY.StripLines[0].Text = yCurTemp.ToString("0.000");
                        }

#if true
                        // Set RTemp
                        yCurTemp = chart.Series[1].Points[index].YValues[0];
                        //     chart.ChartAreas[0].AxisY.StripLines[1].IntervalOffset = yCurTemp;
                        //  chart.ChartAreas[0].AxisY.StripLines[1].Text = yCurTemp.ToString();
                        lbY2Position.Text = yCurTemp.ToString("0.00");

                        // Set Temp
                            //yCurTemp2 = chart.Series[2].Points[index].YValues[0];
                            //lbTempValue.Text = yCurTemp2.ToString("0.0");
                            //Temp = (float)yCurTemp2;

                        // Set Humi
                            //yCurTemp2 = chart.Series[3].Points[index].YValues[0];
                            //lbHumiValue.Text = yCurTemp2.ToString("0.0");
                            //Humi = (float)yCurTemp2;

                        // Set VPD
                            //yCurTemp2 = chart.Series[3].Points[index].YValues[0];
                            //lbVPDValue.Text = calculateVPD(Temp, Humi).ToString("0.###");
#endif
                        break;
                    }
                }
            }
            }
            catch { }

            if (fDragProcessing)
            {
                if (((xCur > xMin) && (xCur < xMax)) && ((yCur > yMin) && (yCur < yMax)))
                {
                    double posDiff = xCur - xDragStartPosition;

                    if (posDiff != 0)
                    {
                        xDragStartPosition = xCur;
                        xDragMinPosition -= posDiff;
                        xDragMaxPosition -= posDiff;

                        // 최초 데이터보다 작으면 Drag clear
                        if (xDragMinPosition <= (chart.ChartAreas[0].AxisX.Minimum)) fDragProcessing = false;
                        // {
                        //     xDragMinPosition += posDiff;
                        //     xDragMaxPosition += posDiff;
                        // }

                        // 최후 데이터보다 크면 Drag clear
                        if (xDragMaxPosition >= (chart.ChartAreas[0].AxisX.Maximum)) fDragProcessing = false;
                        // {
                        //     xDragMinPosition += posDiff;
                        //     xDragMaxPosition += posDiff;
                        // }

                        if (fDragProcessing == true)
                        {
                            //    double xDragMinPositionBackup, xDragMaxPositionBackup;
                            //     xDragMinPositionBackup = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                            //     xDragMaxPositionBackup = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                            chart.ChartAreas[0].AxisX.ScaleView.Zoom(xDragMinPosition, xDragMaxPosition);

                            //  if ((xDragMaxPositionBackup == chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum) ||
                            //      (xDragMinPositionBackup == chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum))
                            {
                                // 변경이 안되는 경우는 원복
                                //     fDragProcessing = false;
                                //     chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0); 

                                //아래루틴으로 원복안됨(Scale Interval 오차)
                                //chart.ChartAreas[0].AxisX.ScaleView.Zoom(xDragMinPositionBackup, xDragMaxPositionBackup);
                            }
                        }
                    }

                }
                else
                {
                    fDragProcessing = false;
                }
            }
        }

        private float calculateVPD(float Temp, float Humi)
        {
            double valueVPD;

            valueVPD = 0.0;
            if ((Temp > 0) && (Temp < 80))
            {
                if ((Humi > 0) && (Humi < 99))
                {
                    // VPD = ((100-RH)/100)*SVP
                    // SVP = 610.7 * 10 ^ (7.5T/(237.3+T))
                    double valueSVP;
                    valueSVP = 610.7 * Math.Pow(10.0, (7.5 * Temp / (237.3 + Temp)));
                    valueVPD = ((100 - Humi) / 100) * valueSVP;
                    valueVPD /= 1000; // kPa
                }
            }
            return ((float)valueVPD);
        }

        private void frmSubChannelChart_Load(object sender, EventArgs e)
        {
            if (SF_Test.fgFactoryModeActivated)
            {
                //lbTemp.Visible = true;
                //lbHumi.Visible = true;
                //lbVPD.Visible = true;
                //lbTempValue.Visible = true;
                //lbHumiValue.Visible = true;
                //lbVPDValue.Visible = true;

                lbTemp.Visible = false;
                lbHumi.Visible = false;
                lbVPD.Visible = false;
                lbTempValue.Visible = false;
                lbHumiValue.Visible = false;
                lbVPDValue.Visible = false;

            }
            else
            {
                lbTemp.Visible = false;
                lbHumi.Visible = false;
                lbVPD.Visible = false;
                lbTempValue.Visible = false;
                lbHumiValue.Visible = false;
                lbVPDValue.Visible = false;

            }

            this.Icon = SapflowApplication.Properties.Resources.logo_real;

                seupStripLines();
        }

        private void seupStripLines()
        {
            Chart chart = this.chart1;

            chart.ChartAreas[0].AxisX.StripLines.Add(new StripLine());
            chart.ChartAreas[0].AxisX.StripLines[0].BackColor = Color.Lime;
            chart.ChartAreas[0].AxisX.StripLines[0].StripWidth = 0.01;
            chart.ChartAreas[0].AxisX.StripLines[0].StripWidthType = DateTimeIntervalType.Seconds;
            chart.ChartAreas[0].AxisX.StripLines[0].IntervalOffsetType = DateTimeIntervalType.Seconds;
            chart.ChartAreas[0].AxisX.StripLines[0].BorderDashStyle = ChartDashStyle.Dot;
            chart.ChartAreas[0].AxisX.StripLines[0].BorderWidth = 1;
            chart.ChartAreas[0].AxisX.StripLines[0].BorderColor = Color.Lime;

            chart.ChartAreas[0].AxisY.StripLines.Add(new StripLine());
            chart.ChartAreas[0].AxisY.StripLines[0].BackColor = Color.Blue;
            chart.ChartAreas[0].AxisY.StripLines[0].StripWidth = 0.0005;
            //chart.ChartAreas[0].AxisY.StripLines[0].StripWidthType = 1;
            chart.ChartAreas[0].AxisY.StripLines[0].IntervalOffsetType = DateTimeIntervalType.Seconds;
            chart.ChartAreas[0].AxisY.StripLines[0].BorderDashStyle = ChartDashStyle.Dot;
            chart.ChartAreas[0].AxisY.StripLines[0].BorderColor = Color.LightBlue;
            chart.ChartAreas[0].AxisY.StripLines[0].BorderWidth = 1;
#if false
            chart.ChartAreas[0].AxisY.StripLines.Add(new StripLine());
            chart.ChartAreas[0].AxisY.StripLines[1].BackColor = Color.Orange;
            chart.ChartAreas[0].AxisY.StripLines[1].StripWidth = 0.001;
            //chart.ChartAreas[0].AxisY.StripLines[0].StripWidthType = 1;
            chart.ChartAreas[0].AxisY.StripLines[1].IntervalOffsetType = DateTimeIntervalType.Seconds;
            chart.ChartAreas[0].AxisY.StripLines[1].BorderDashStyle = ChartDashStyle.Dot;
            chart.ChartAreas[0].AxisY.StripLines[1].BorderColor = Color.Orange;
            chart.ChartAreas[0].AxisY.StripLines[1].BorderWidth = 1;
#endif
        }

        private void disposeStripLines()
        {
            if (parentForm.fgPositionInfo)
            {
                //                Chart chart = this.chart1;
                //
                //               chart.ChartAreas[0].AxisX.StripLines.Dispose();
                //               chart.ChartAreas[0].AxisY.StripLines.Dispose();
            }
        }


        void MenuClick(object obj, EventArgs ea)
        {
            ToolStripMenuItem mI = (ToolStripMenuItem)obj;
            String str = mI.Text;

            if (str == "Hide Chart") this.Visible = false;
            if (str == "Minimize Chart") this.WindowState = FormWindowState.Minimized;
            if (str == "Normal Chart") this.WindowState = FormWindowState.Normal;
            if (str == "Maximize Chart") this.WindowState = FormWindowState.Maximized;
        }

        private void frmSubChannelChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                EventHandler eh = new EventHandler(MenuClick);


                ToolStripMenuItem[] ami = {
                    new ToolStripMenuItem("Hide Chart",null, eh),
                    new ToolStripMenuItem("Minimize Chart",null, eh),
                    new ToolStripMenuItem("Normal Chart",null, eh),
                    new ToolStripMenuItem("Maximize Chart",null, eh),
                    };
                //ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(ami);

            }
        }

        private void executeAxisViewChanged()
        {
            int i = 0;

            TimeSpan interval = DateTime.FromOADate(chart1.ChartAreas[i].AxisX.ScaleView.ViewMaximum)
                                - DateTime.FromOADate(chart1.ChartAreas[i].AxisX.ScaleView.ViewMinimum);

//            chart1.ChartAreas[i].AxisX2.LabelStyle.Format = "MM/dd";
//            chart1.ChartAreas[i].AxisX2.IntervalType = DateTimeIntervalType.Minutes;
//            chart1.ChartAreas[i].AxisX2.Interval = Convert.ToInt32(Convert.ToInt32(interval.TotalMinutes / 30) * 30 / 8);


            if (interval.Days < 1)   // 하루 이내
            {
                chart1.ChartAreas[i].AxisX.LabelStyle.Format = "H:mm";
                chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Minutes;
                chart1.ChartAreas[i].AxisX.Interval = Convert.ToInt32(Convert.ToInt32(interval.TotalMinutes / 4));
            }
            else if (interval.Days <= 2)  // 2day
            {
                chart1.ChartAreas[i].AxisX.LabelStyle.Format = "M/dd\nH";
                chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Hours;
                chart1.ChartAreas[i].AxisX.Interval = Convert.ToInt32(interval.TotalHours / 4);
            }
            else if (interval.Days < 7)  // Week
            {
                chart1.ChartAreas[i].AxisX.LabelStyle.Format = "M/dd";
                chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Hours;
                chart1.ChartAreas[i].AxisX.Interval = Convert.ToInt32(interval.TotalHours / 4);
            }
            else //  if (interval.Days < 30)  // Month
            {
                chart1.ChartAreas[i].AxisX.LabelStyle.Format = "M/dd";
                chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[i].AxisX.Interval = Convert.ToInt32(interval.TotalDays / 4);
            }
        }

        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            executeAxisViewChanged();
        }

        private void Chart1_MouseDown(object sender, MouseEventArgs e)
        {
            Chart chart = this.chart1;

            double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            double xCur = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X);

            double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
            double yCur = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y);

            if (((xCur > xMin) && (xCur < xMax)) && ((yCur > yMin) && (yCur < yMax)))
            {
                fDragProcessing = true;
                xDragStartPosition = xCur;
                xDragMinPosition = xMin;
                xDragMaxPosition = xMax;
            }
            else
            {
                fDragProcessing = false;
            }
        }

        private void Chart1_MouseUp(object sender, MouseEventArgs e)
        {
            Chart chart = this.chart1;
#if false
            if (false) // fDragProcessing)
            {
                double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double xCur = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X);

                double posXStart = xMin;
                double posXFinish = xMax;

                double posDiff = xCur - xDragStartPosition;

                if (posDiff != 0)
                {
                    posXStart = xMin - posDiff;
                    posXFinish = xMax - posDiff;
                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                }

            }
            else
#endif
            {
                fDragProcessing = false;
            }
        }
    }
}

