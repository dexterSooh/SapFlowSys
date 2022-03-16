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
    public partial class frmCalibration : Form
    {
        private SF_Test parentForm;
        private int formID;
        private int index = 1;

        private const int SFChannelLength = SF_Test.SFChannelLength;      // SF_Test에 정의된 채널수를 참조

        public delegate void FormSendDataHandler(Object obj);
        public event FormSendDataHandler requestCommandEvent;

        private const int AD_LOWER_LIMIT = 11000;
        private const int AD_UPPER_LIMIT = 13000;
        
        public frmCalibration(SF_Test parentForm, int formID)
        {
            this.parentForm = parentForm;
            this.formID = formID;       // formID 는 모듈번호 -1
            InitializeComponent();
        }

#if false
        class stripLineClone : ICloneable
        {
            public StripLine stripLine = new StripLine();
            public stripLineClone(StripLine sv)
            {
                stripLine = sv;
            }
            public object Clone()
            {
                return (stripLine);
            }
        }
#endif
        private void initChartAreaProperties(Chart chart)
        {
            const int valueMaximum = 33000;

            // Chart 세로축 간격 조절
            chart.ChartAreas[0].AxisY.Maximum = valueMaximum;
            chart.ChartAreas[0].AxisY.Interval = 10000;

            // Lower, Upper 
            StripLine stripLine = new StripLine();

            stripLine.BackColor = Color.LightGreen;
            stripLine.StripWidth = 1;
            stripLine.BorderDashStyle = ChartDashStyle.Dot;
            stripLine.BorderWidth = 1;
            stripLine.BorderColor = Color.Green;
            stripLine.ForeColor = Color.Green;
            stripLine.TextAlignment = StringAlignment.Far;

            stripLine.Text = "Lower Limit(11000)";
            stripLine.IntervalOffset = AD_LOWER_LIMIT;
            stripLine.TextLineAlignment = StringAlignment.Near;
            chart.ChartAreas[0].AxisY.StripLines.Add(stripLine);

            StripLine stripLine2 = new StripLine();

            stripLine2.BackColor = Color.LightGreen;
            stripLine2.StripWidth = 1;
            stripLine2.BorderDashStyle = ChartDashStyle.Dot;
            stripLine2.BorderWidth = 1;
            stripLine2.BorderColor = Color.Green;
            stripLine2.ForeColor = Color.Green;
            stripLine2.TextAlignment = StringAlignment.Far;

            stripLine2.Text = "Upper Limit(13000)";
            stripLine2.IntervalOffset = AD_UPPER_LIMIT;
            stripLine2.TextLineAlignment = StringAlignment.Far;
            chart.ChartAreas[0].AxisY.StripLines.Add(stripLine2);
        }

        private void frmCalibration_Load(object sender, EventArgs e)
        {
            this.Icon = SapflowApplication.Properties.Resources.logo_real;

            this.Text = "Calibration SF Module # " + (formID + 1).ToString();

            timer1.Enabled = true;


            initChartAreaProperties(chart1);
            initChartAreaProperties(chart2);
            initChartAreaProperties(chart3);
            initChartAreaProperties(chart4);
            
            this.parentForm.CalibrationErrorCount = 0;
#if false
            if (MessageBox.Show("Do you want to start calibration \r for SF Module #" + (formID + 1) + "?", "Start Calibration", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                timer1.Enabled = true;

                initChartAreaProperties(chart1);
                initChartAreaProperties(chart2);
                initChartAreaProperties(chart3);
                initChartAreaProperties(chart4);

            }
            else
            {
                timer1.Enabled = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
#endif
        }

        private void initializeCalibrationChart()
        {

            Int16[] valueResult = new Int16[SFChannelLength];

            Chart chart = null;
            TextBox textbox = null;

            this.parentForm.CalibrationDataReady = false;
            requestCommandEvent(1);
            while (this.parentForm.CalibrationDataReady == false)
            {
            }           
            this.parentForm.CalibrationDataReady = false;
            if(this.parentForm.CalibrationCommStatus == false)
            {
                // Communication Error 
                this.parentForm.CalibrationErrorCount++;
                if (this.parentForm.CalibrationErrorCount>3)
                {
                    timer1.Enabled = false;
                    chart1.Titles[0].Text = "Comm. Error";
                    chart1.Titles[0].BackColor = Color.Red;
                    chart2.Titles[0].Text = "Comm. Error";
                    chart2.Titles[0].BackColor = Color.Red;
                    chart3.Titles[0].Text = "Comm. Error";
                    chart3.Titles[0].BackColor = Color.Red;
                    chart4.Titles[0].Text = "Comm. Error";
                    chart4.Titles[0].BackColor = Color.Red;
                    return;
                }
            }
            else
            {
                this.parentForm.CalibrationErrorCount = 0;
            }

            for (int ch = 0; ch < SFChannelLength; ch++)
            {
                valueResult[ch] = (Int16)this.parentForm.CalibrationResult[ch];

                switch (ch)
                {
                    case 0:
                        chart = chart1;
                        textbox = tbRawDataCH1;
                        break;
                    case 1:
                        chart = chart2;
                        textbox = tbRawDataCH2;
                        break;
                    case 2:
                        chart = chart3;
                        textbox = tbRawDataCH3;
                        break;
                    case 3:
                        chart = chart4;
                        textbox = tbRawDataCH4;
                        break;
                    default:
                        chart = chart1;
                        textbox = tbRawDataCH1;
                        break;
                }

                // Display
                // Chart Update
                //if (valueResult[ch] != 0xffff)
                {
                    chart.Series[0].Points.AddXY(index, valueResult[ch]);
                    if (chart.Series[0].Points.Count > 60)
                    {
                        chart.Series[0].Points.RemoveAt(0);
                        chart.ChartAreas[0].RecalculateAxesScale();
                    }
                }


                //chart.ChartAreas[0].AxisX.ScaleView.SizeType = UInt16;
                // chart.ChartAreas[0].AxisX.ScaleView.Size = 30;
                // chart.ChartAreas[0].AxisX.ScaleView.Scroll(30);

                // Listbox Update
                // if (valueResult[ch] != 0xffff)

                // Textbox Update
                if ((valueResult[ch] > AD_LOWER_LIMIT) && (valueResult[ch] < AD_UPPER_LIMIT)) // 2017-09-20수정(기존 11500~12500)
                {
                    textbox.ForeColor = Color.FromName("Green");
                    //textbox.ForeColor = Color.FromName("Lime");
                }
                else
                {
                    textbox.ForeColor = Color.FromName("Silver");
                    //textbox.ForeColor = Color.FromName("Crimson");
                }

                if (valueResult[ch] == 0xffff)
                {
                    textbox.Text = valueResult[ch].ToString("-----");
                    textbox.ForeColor = Color.FromName("Silver");
                }
                else
                {
                    //   textbox.Text = String.Format("{1}",(ch+1),valueResult[ch].ToString("D5"));
                    textbox.Text = String.Format("{1}",(ch+1),valueResult[ch].ToString("D"));

                }

            }
            index++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            initializeCalibrationChart();
        }

        private void frmCalibrationClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            this.DialogResult = DialogResult.OK;
            // this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

