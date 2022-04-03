#define DEBUG_TIME_FAST

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using ReaLTaiizor.Forms;

namespace SapflowApplication
{
    public partial class frmSfModule : MaterialForm
    {
        private SF_Test parentForm;
        private int formID;
        private int ModuleNumber;

        private const int SFChannelLength = SF_Test.SFChannelLength;      // SF_Test에 정의된 채널수를 참조

        public frmSubChannelChart[] ChartMultiCH = new frmSubChannelChart[SFChannelLength];
        public bool fgPositionInfo = true;

        private static bool flagCurrentMDILayout = false;
        private static MdiLayout currentMDILayout = System.Windows.Forms.MdiLayout.TileVertical;

        public frmSfModule(SF_Test parentForm, int formID)
        {
            this.parentForm = parentForm;
            this.formID = formID;

            ModuleNumber = formID;

            SF_Test.SystemParameter.ModuleOn[ModuleNumber] = true;

            InitializeComponent();
        }

        private void initializeMultiChWindow()
        {
            Chart chart = null;

            DateTime now = System.DateTime.Now;
#if (DEBUG_TIME_FAST)
            DateTime maxDate = now.AddMinutes(+2 * 60);
#else
                DateTime maxDate = now.AddSeconds(+60);
#endif
            for (int i = SFChannelLength - 1; i >= 0; i--)
            {
                // 활성화된 창만 업데이트
                if (SF_Test.SystemParameter.ChannelEnable[this.formID, i] == false) continue;

                ChartMultiCH[i] = new frmSubChannelChart(this, formID, i); // mo, ch
                // Set the Parent Form of the Child window.
                ChartMultiCH[i].MdiParent = this;
                // Display the new form.

                ChartMultiCH[i].Show();
                ChartMultiCH[i].Text = String.Format("[{1}]SF Module #{0}, CH={1}", this.formID + 1, i + 1);

                chart = ChartMultiCH[i].chart1;

                chart.Series["SF"].XValueType = ChartValueType.DateTime;
                //chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "mm:ss";
                chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "hh:mm";
#if (DEBUG_TIME_FAST)
                chart.ChartAreas["ChartArea1"].AxisX.Interval = 10 * 60;
#else
                chart.ChartAreas["ChartArea1"].AxisX.Interval = 10;
#endif
                chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Seconds;

                chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "0.####";
                chart.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Format = "0.####";

                chart.ChartAreas["ChartArea1"].AxisX.Minimum = now.ToOADate();
                chart.ChartAreas["ChartArea1"].AxisX.Maximum = maxDate.ToOADate();

                // Scale
                chart.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset(0);

                // Scroll bar
                //                chart.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                //                chart.ChartAreas["ChartArea1"].AxisX.ScrollBar.Size = 10;

                //DateTime scrollTime = lastTime.AddHours(-48);
                //chart.ChartAreas["ChartArea1"].AxisX.ScaleView.Scroll(scrollTime);

                //   chart.Series["SF"].Points.AddXY(now, 0);
                //   chart.Series["Temp"].Points.AddXY(now, 0);

                if (i > 3)
                {
                    ChartMultiCH[i].WindowState = FormWindowState.Minimized;
                }

                if (i > 0)
                {
                    // ChartMultiCH[i].WindowState = FormWindowState.Minimized;
                }
                else
                {
                    // ChartMultiCH[i].WindowState = FormWindowState.Maximized;
                    //ChartMultiCH[i].Size = this.parentForm.Size - new Size(10,10);
                }

            }

            VisibleChannelAll();            //VisibleChannelAll();

            cascadeWindowsToolStripMenuItem.Checked = false;
            tileHorizontalToolStripMenuItem.Checked = false;
            tileVerticalToolStripMenuItem.Checked = true;

            // Turn On all graph
           // TempToolStripMenuItem.Checked = true;
           // humidityToolStripMenuItem.Checked = true;
           // vPDToolStripMenuItem.Checked = true;
            rTempToolStripMenuItem.Checked = true;
            positionInfoToolStripMenuItem.Checked = true;
            showDateToolStripMenuItem.Checked = true;
            showSFLableToolStripMenuItem.Checked = true;
            viewChartSeries();

        }

        private void cascadeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagCurrentMDILayout = true;
            currentMDILayout = System.Windows.Forms.MdiLayout.Cascade;
            this.LayoutMdi(currentMDILayout);
            cascadeWindowsToolStripMenuItem.Checked = true;
            tileHorizontalToolStripMenuItem.Checked = false;
            tileVerticalToolStripMenuItem.Checked = false;
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagCurrentMDILayout = true;
            currentMDILayout = System.Windows.Forms.MdiLayout.TileHorizontal;
            this.LayoutMdi(currentMDILayout);
            cascadeWindowsToolStripMenuItem.Checked = false;
            tileHorizontalToolStripMenuItem.Checked = true;
            tileVerticalToolStripMenuItem.Checked = false;
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagCurrentMDILayout = true;
            currentMDILayout = System.Windows.Forms.MdiLayout.TileVertical;
            this.LayoutMdi(currentMDILayout);
            cascadeWindowsToolStripMenuItem.Checked = false;
            tileHorizontalToolStripMenuItem.Checked = false;
            tileVerticalToolStripMenuItem.Checked = true;

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "*.log|*.*";
            open.InitialDirectory = Application.StartupPath + "\\log\\";
            open.Title = "Select Log file";

            if (open.ShowDialog() == DialogResult.OK)
            {
                SF_Test.m_SampleCount = 0;
                SF_Test.m_TimeArray.Clear();

                // MessageBox.Show("FileName = " + open.FileName);
                parsingLoadFileInit(open.FileName);
                Chart chart = null;
                if (SF_Test.m_SampleCount > 0)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SF_Test.SystemParameter.ChannelEnable[formID, ch] == false) continue;

                        chart = ChartMultiCH[ch].chart1;
                        chart.ChartAreas["ChartArea1"].AxisX.Minimum = chart.Series[0].Points[0].XValue;
                        chart.ChartAreas["ChartArea1"].AxisX.Maximum = chart.Series[0].Points[(int)SF_Test.m_SampleCount - 1].XValue;
                        //                        chart.ChartAreas[0].AxisY.Minimum = chart.Series[0].Points[0].YValues.Min();
                        //                        chart.ChartAreas[0].AxisY.Maximum = chart.Series[0].Points[SF_Test.m_SampleCount - 1].YValues.Max();

                        chart.ChartAreas["ChartArea1"].RecalculateAxesScale();
                    }
                }

            }
        }

        private string getInnerSideStringData(string str)
        {
            int startPosition = str.IndexOf("[");
            int lastPosition = str.IndexOf("]");
            if (lastPosition > startPosition)
            {
                return (str.Substring(startPosition + 1, lastPosition - startPosition - 1));
            }
            else
            {
                return null;
            }
        }

        private void parsingLoadFileInit(string FileName)
        {
            int line = 0;

            StreamReader sr = new StreamReader(FileName);

            string strLog;

            if (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                line++;

                if (strLog != "Start")
                {
                    MessageBox.Show("Real 로그가 아닙니다");
                    return;
                }
            }

            while (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                line++;
            parsingLoadFileInit_Repeat_Loop:
                if (strLog.StartsWith("["))
                {
                    // 날짜 시간 데이터를 획득
                    DateTime pTime = new DateTime();
                    String str;

                    str = getInnerSideStringData(strLog);
                    if (str != null)
                    {
                        if (DateTime.TryParse(str, out pTime))
                        {
                            // OK
                            //MessageBox.Show("데이터 날짜: {0}",pTime.ToString());
                            // parsing Channel Data
                            SF_Test.m_TimeArray.Add(pTime.ToOADate());// .ToString("yyyy-MM-dd HH:mm:ss"));
                            SF_Test.m_SampleCount++;

                            while (sr.Peek() > -1)
                            {
                                strLog = sr.ReadLine();
                                line++;
                                if (strLog.StartsWith("SF"))
                                {
                                    String strSF;
                                    // 채널벌 데이터를 분할함
                                    string[] spltStrArray = strLog.Split(' ');  // Space를 분리기호로 사용

                                    strSF = getInnerSideStringData(spltStrArray[0]);    // 모듈번호
                                    if ((strSF != null))// && (spltStrArray.Length == (SFChannelLength)))  // SF, CH0, CH1, ..., CHn, "" = 채널수 + 2 = Array Length
                                    {
                                        if (this.formID == int.Parse(strSF))
                                        {
                                            // 모듈번호 확인됨
                                            foreach (string strCH in spltStrArray)
                                            {
                                                if (strCH.StartsWith("ch"))
                                                {
                                                    if (strCH.Length > 6)   // 'c','h','0','[','/,'',]' 6 char 
                                                    {
                                                        int ch = int.Parse(strCH.Substring(2, 1));
                                                        if (ch < SFChannelLength)
                                                        {
                                                            // 채널번호 확인됨
                                                            Chart chart = null;
                                                            chart = ChartMultiCH[ch].chart1;

                                                            string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                            if (strDataArray != null)
                                                            {
                                                                string[] spltStrDataArray = strDataArray.Split(',');  // ','를 분리기호로 사용
                                                                if (spltStrDataArray.Length == 2)
                                                                {
                                                                    double valueSF, valueRTemp;
                                                                    valueSF = double.Parse(spltStrDataArray[0]);
                                                                    valueRTemp = double.Parse(spltStrDataArray[1]);

                                                                    // Update Data Point

                                                                    chart.Series["SF"].Points.AddXY(pTime, valueSF);
                                                                    chart.Series["Temp"].Points.AddXY(pTime, valueRTemp);
                                                                }


                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    goto parsingLoadFileInit_Repeat_Loop;
                                }
                            }  //while (sr.Peek() > -1)

                        }  // (DateTime.TryParse(str, out pTime))
                        else
                        {
                            MessageBox.Show("Real 정상데이터가 아닙니다");
                            break;
                        }
                    } //(str != null)
                } // (strLog.StartsWith("["))

            }
            MessageBox.Show(String.Format("{0} 라인을 읽었습니다", line));
        }

        private void frmSfModuleClosing(object sender, FormClosingEventArgs e)
        {
            if (SF_Test.flagLockClose == true)
            {
                e.Cancel = true; 
            }
            else
            {
                SF_Test.SystemParameter.ModuleOn[ModuleNumber] = false;
                // 2017/12/13 윈도우 사이즈 저장 , Closing시 저장하면, Setup 설정이후 그래프 재로드시 설정값이 업데이트되지 않음
                //SF_Test.GraphLocation[ModuleNumber] = this.Location;
                //SF_Test.GraphSize[ModuleNumber] = this.Size;
            }
        }

        private void frmSfModule_Load(object sender, EventArgs e)
        {
            this.Icon = SapflowApplication.Properties.Resources.logo_real;
            initializeMultiChWindow();

            // file메뉴를 끔
            fileToolStripMenuItem.Visible = false;
            if (SF_Test.fgFactoryModeActivated)
            {
                //TempToolStripMenuItem.Visible = true;
                //humidityToolStripMenuItem.Visible = true;
                //vPDToolStripMenuItem.Visible = true;

                TempToolStripMenuItem.Visible = false;
                humidityToolStripMenuItem.Visible = false;
                vPDToolStripMenuItem.Visible = false;
            }
            else
            {

                TempToolStripMenuItem.Visible = false;
                humidityToolStripMenuItem.Visible = false;
                vPDToolStripMenuItem.Visible = false;
            }
        }

        private void cH1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisibleChannelOne(0);
        }

        private void cH2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisibleChannelOne(1);
        }

        private void cH3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisibleChannelOne(2);
        }

        private void cH4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisibleChannelOne(3);
        }

        private void cH1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ch1, ch2
            VisibleChannelTwo(0, 1);
        }

        private void cH2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ch1, ch3
            VisibleChannelTwo(0, 2);
        }

        private void cH3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ch1, ch4
            VisibleChannelTwo(0, 3);
        }

        private void cH4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ch2, ch3
            VisibleChannelTwo(1, 2);
        }

        private void cH2AndCH4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ch2, ch4
            VisibleChannelTwo(1, 3);
        }

        private void cH3AndCH4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ch3, ch4
            VisibleChannelTwo(2, 3);
        }

        private void cH1CH2CH3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ch1, ch2, ch3
            VisibleChannelThree(3);
        }

        private void cH1CH3CH4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ch1, ch2, ch4
            VisibleChannelThree(2);
        }

        private void cH2CH3CH4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ch1, ch3, ch4
            VisibleChannelThree(1);
        }

        private void cH2CH3CH4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ch2, ch3, ch4
            VisibleChannelThree(0);
        }

        private void tileAllWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ch1, ch2, ch3, ch4
            VisibleChannelAll();
        }

        private void VisibleChannelOne(int ch)
        {
            for (int i = 0; i < SFChannelLength; i++)
            {
                ChartMultiCH[i].WindowState = FormWindowState.Normal;
                if (i == ch)
                {
                    ChartMultiCH[i].Visible = true;
                }
                else
                {
                    ChartMultiCH[i].Visible = false;
                }
            }
            VisibleChannelReallocate();
        }


        private void VisibleChannelTwo(int ch1, int ch2)
        {
            for (int i = SFChannelLength - 1; i >= 0; i--)
            {
                ChartMultiCH[i].WindowState = FormWindowState.Normal;
                if ((i == ch1) || (i == ch2))
                {
                    ChartMultiCH[i].Visible = true;
                }
                else
                {
                    ChartMultiCH[i].Visible = false;
                }
            }
            VisibleChannelReallocate();
        }

        private void VisibleChannelThree(int ch)
        {
            for (int i = SFChannelLength - 1; i >= 0; i--)
            {
                ChartMultiCH[i].WindowState = FormWindowState.Normal;
                if (i != ch)
                {
                    ChartMultiCH[i].Visible = true;
                }
                else
                {
                    ChartMultiCH[i].Visible = false;
                }
            }
            VisibleChannelReallocate();
        }

        private void VisibleChannelAll()
        {
            for (int i = SFChannelLength - 1; i >= 0; i--)
            {
                ChartMultiCH[i].WindowState = FormWindowState.Normal;
                ChartMultiCH[i].Visible = true;
            }
            VisibleChannelReallocate();
        }
        private void frmSFModule_ResizedEnd(object sender, EventArgs e)
        {
            VisibleChannelReallocate();

            if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                // Normal의 경우에 저장, 창이 Min/Max인경우 저장하면 안됨
                SF_Test.GraphLocation[ModuleNumber] = this.Location;
                SF_Test.GraphSize[ModuleNumber] = this.Size;
            }
        }

        private void VisibleChannelReallocate()
        {
            for (int i = 0; i < SFChannelLength; i++)
            {
                if (ChartMultiCH[i] == null)
                {
                    // 2017/11/15 영문윈도우에서 시작시,SizeChanged이벤트가 발생함
                    // 원인: Child Chart: frmSubChannelChart가 생성되지 않는상태에서 이벤트 발생
                    return;
                }
            }

            for (int i = SFChannelLength - 1; i >= 0; i--)
            {
                if (ChartMultiCH[i].Visible)
                {
                    ChartMultiCH[i].BringToFront();
                }
            }

            this.LayoutMdi(currentMDILayout);
        }

        private void TempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TempToolStripMenuItem.Checked)
            {
                TempToolStripMenuItem.Checked = false;
            }
            else
            {
                TempToolStripMenuItem.Checked = true;
            }


            viewChartSeries();
        }

        private void humidityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (humidityToolStripMenuItem.Checked)
            {
                humidityToolStripMenuItem.Checked = false;
            }
            else
            {
                humidityToolStripMenuItem.Checked = true;
            }
            viewChartSeries();
        }

        private void vPDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vPDToolStripMenuItem.Checked)
            {
                vPDToolStripMenuItem.Checked = false;
            }
            else
            {
                vPDToolStripMenuItem.Checked = true;
            }
            viewChartSeries();
        }

        private void viewChartSeries()
        {
            Chart chart = null;
            for (int i = 0; i < SFChannelLength; i++)
            {
                chart = ChartMultiCH[i].chart1;

                if (TempToolStripMenuItem.Checked)
                {
                   // chart.Series["TempSHT15"].Enabled = true;
                }
                else
                {
                    //chart.Series["TempSHT15"].Enabled = false;
                }

                if (humidityToolStripMenuItem.Checked)
                {
                   // chart.Series["HumSHT15"].Enabled = true;
                }
                else
                {
                   // chart.Series["HumSHT15"].Enabled = false;
                }

                if (vPDToolStripMenuItem.Checked)
                {
                    //chart.Series["VPD"].Enabled = true;
                }
                else
                {
                  //  chart.Series["VPD"].Enabled = false;
                }

                if (rTempToolStripMenuItem.Checked)
                {
                    chart.Series["Temp"].Enabled = true;
                }
                else
                {
                    chart.Series["Temp"].Enabled = false;
                }

                if (showDateToolStripMenuItem.Checked)
                {
                    chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                }
                else
                {
                    chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                }

                if (showSFLableToolStripMenuItem.Checked)
                {
                    chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = true;
                }
                else
                {
                    chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                }

                if (showRTempLabelToolStripMenuItem.Checked)
                {
                    chart.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Enabled = true;
                }
                else
                {
                    chart.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Enabled = false;
                }

            }
        }

        private void rTempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rTempToolStripMenuItem.Checked)
            {
                rTempToolStripMenuItem.Checked = false;
            }
            else
            {
                rTempToolStripMenuItem.Checked = true;
            }
            viewChartSeries();
        }

        private void positionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (positionInfoToolStripMenuItem.Checked)
            {
                positionInfoToolStripMenuItem.Checked = false;
                fgPositionInfo = false;
            }
            else
            {
                positionInfoToolStripMenuItem.Checked = true;
                fgPositionInfo = true;
            }

        }

        private void showDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showDateToolStripMenuItem.Checked)
            {
                showDateToolStripMenuItem.Checked = false;
            }
            else
            {
                showDateToolStripMenuItem.Checked = true;
            }
            viewChartSeries();

        }

        private void showRTempLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showRTempLabelToolStripMenuItem.Checked)
            {
                showRTempLabelToolStripMenuItem.Checked = false;
            }
            else
            {
                showRTempLabelToolStripMenuItem.Checked = true;
            }
            viewChartSeries();
        }

        private void showSFLableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showSFLableToolStripMenuItem.Checked)
            {
                showSFLableToolStripMenuItem.Checked = false;
            }
            else
            {
                showSFLableToolStripMenuItem.Checked = true;
            }
            viewChartSeries();


        }
    }
}