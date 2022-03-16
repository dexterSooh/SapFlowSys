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
using System.IO;

namespace SapflowApplication
{
    public partial class frmSfMultiModules : Form
    {
        private SF_Test parentForm;
        private const int SFModuleLength = SF_Test.SFModuleLength;      // SF_Test에 정의된 채널수를 참조
        private const int SFChannelLength = SF_Test.SFChannelLength;      // SF_Test에 정의된 채널수를 참조

        public frmSubChannelMultiChart[,] ChartMultiCH = new frmSubChannelMultiChart[SFModuleLength, SFChannelLength];

        // Display 표시 초기값
        private Boolean fgTitleOn = SF_Test.fgMultiChartTitleOn;
        private Boolean fgDateOn = SF_Test.fgMultiChartDateOn;
        private Boolean fgY1On = SF_Test.fgMultiChartY1On;
        private Boolean fgY2On = SF_Test.fgMultiChartY2On;
        private Boolean fgSFOn = SF_Test.fgMultiChartSFOn;
        private Boolean fgRTOn = SF_Test.fgMultiChartRTOn;
        private Boolean fgMaskViewOn = SF_Test.fgMultiChartMaskViewOn;
        private Boolean fgColorOn = SF_Test.fgMultiChartColorOn;

        //      private Boolean fgRequestRefresh = false;
        private Boolean[,] MaskViewOn = new Boolean[SFModuleLength, SFChannelLength];

        public frmSfMultiModules(SF_Test parentForm)
        {
            this.parentForm = parentForm;

            InitializeComponent();
        }

        private void SfMultiModules_Load(object sender, EventArgs e)
        {
            this.Icon = SapflowApplication.Properties.Resources.logo_real;
            SF_Test.SystemParameter.MultiModuleOn = true;
            SF_Test.fgRequestMultiChartUpdate = false;

            setWindowPosition();
            initializeMultiChWindosw();
            relocatefrmSubChannelMultiChart();

            initializeScaleComboBox();

            this.Icon = SapflowApplication.Properties.Resources.logo_real;

            // 타이틀 표시 초기값 세팅
            fgTitleOn = !fgTitleOn;
            fgDateOn = !fgDateOn;
            fgY1On = !fgY1On;
            fgY2On = !fgY2On;
            fgSFOn = !fgSFOn;
            fgRTOn = !fgRTOn;
            fgMaskViewOn = !fgMaskViewOn;
            fgColorOn = !fgColorOn;

            btDataOn_Click(btTitle, null);
            btDataOn_Click(btDate, null);
            btDataOn_Click(btY1, null);
            btDataOn_Click(btY2, null);
            btDataOn_Click(btSF, null);
            btDataOn_Click(btRT, null);
            btDataOn_Click(btMaskView, null);
            btDataOn_Click(btColorView, null);
        }

        private TimeSpan[] listScaleComobBox =
        {
            new TimeSpan(0,0,10,0), // 10min
            new TimeSpan(0,0,30,0), // 30min
            new TimeSpan(0,1,0,0), // 1h
            new TimeSpan(0,2,0,0), // 2h
            new TimeSpan(0,4,0,0), // 4h
            new TimeSpan(0,6,0,0), // 6h
            new TimeSpan(0,8,0,0), // 8h
            new TimeSpan(0,12,0,0), // 12h
            new TimeSpan(0,18,0,0), // 18h

            new TimeSpan(1,0,0,0), // 1d
            new TimeSpan(2,0,0,0), // 2d
            new TimeSpan(3,0,0,0), // 3d
            new TimeSpan(4,0,0,0), // 4d
            new TimeSpan(5,0,0,0), // 5d
            new TimeSpan(6,0,0,0), // 6d
            new TimeSpan(7,0,0,0), // 7d

            new TimeSpan(8,0,0,0), // 8d
            new TimeSpan(9,0,0,0), // 9d
            new TimeSpan(10,0,0,0), // 10d
            new TimeSpan(11,0,0,0), // 11d
            new TimeSpan(12,0,0,0), // 12d
            new TimeSpan(13,0,0,0), // 13d
            new TimeSpan(14,0,0,0), // 14d

            new TimeSpan(15,0,0,0), // 15d
            new TimeSpan(20,0,0,0), // 20d
            new TimeSpan(25,0,0,0), // 25d
            new TimeSpan(30,0,0,0), // 30d
            new TimeSpan(60,0,0,0), // 60d
            new TimeSpan(0,0,0,0), // Full scale if TimeSpan = 0
        };

        private void initializeScaleComboBox()
        {
            cbScale.Items.Clear();
            foreach (TimeSpan timeScale in listScaleComobBox)
            {
                string labelScale = "";
                if (timeScale.TotalHours == 0)
                {
                    // Full Scale
                    labelScale = "Full";
                }
                else if (timeScale.TotalMinutes < 60)
                {
                    labelScale = timeScale.TotalMinutes.ToString() + "min";
                }
                else if (timeScale.TotalHours < 24)
                {
                    labelScale = timeScale.TotalHours.ToString() + "hour";
                }
                else
                {
                    int TotalDays = (int)timeScale.TotalDays;

                    if ((TotalDays % 30) == 0)  // month
                    {
                        labelScale = (TotalDays / 30).ToString() + "month";
                    }
                    else if ((TotalDays % 7) == 0)  // weeks
                    {
                        labelScale = (TotalDays / 7).ToString() + "week";
                    }
                    else
                    {
                        labelScale = TotalDays.ToString() + "day";
                    }
                }
                cbScale.Items.Add(labelScale);
            }
            cbScale.SelectedIndex = cbScale.Items.Count - 1;
        }

        private void setWindowPosition()
        {
            Size defaultOffsetPosition = new Size(60, 60);
            Point StartPosition = new Point(0, 0) + new Size(defaultOffsetPosition.Width / 2, defaultOffsetPosition.Height / 2);

            Size DisplaySize = Screen.PrimaryScreen.WorkingArea.Size - defaultOffsetPosition;
            this.StartPosition = FormStartPosition.Manual;

#if DEBUG
            // 사이즈를 절반으로 줄이고 왼쪽 위에 배치
            DisplaySize.Width /= 2;
            DisplaySize.Height /= 2;
#else
//            // 폭을 절반으로 줄이고 왼쪽 위에 배치
//            DisplaySize.Width /= 2;

            // 사이즈를 절반으로 줄이고 왼쪽 위에 배치
            DisplaySize.Width /= 2;
            DisplaySize.Height /= 2;
#endif

            this.Location = StartPosition;
            this.Size = DisplaySize;
        }

        private void initializeMultiChWindosw()
        {
            Chart chart = null;
            int ChartCount = 0;

            DateTime now = System.DateTime.Now;

            // Enable된 창을 화면에 표시
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SF_Test.SystemParameter.ModuleEnable[mo])
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SF_Test.SystemParameter.ChannelEnable[mo, ch])
                        {
#if true
                            ChartCount++;
                            ChartMultiCH[mo, ch] = new frmSubChannelMultiChart(this, mo, ch); // mo, ch
                                                                                              // Set the Parent Form of the Child window.
                            ChartMultiCH[mo, ch].MdiParent = this;
                            // Display the new form.
                            panel1.Controls.Add(ChartMultiCH[mo, ch]);

                            ChartMultiCH[mo, ch].Show();
                            ChartMultiCH[mo, ch].Text = String.Format("[{1}]MO=#{0}, CH={1}", mo + 1, ch + 1);

                            chart = ChartMultiCH[mo, ch].chart1;

                            chart.Series["SF"].XValueType = ChartValueType.DateTime;
                            chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "hh:mm";

                            chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "0.####";
                            chart.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Format = "0.####";

                            // Scale
                            chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                            chart.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);

                            //                            for (int i = 0; i < 160; i++)
                            //                            {
                            //                                DateTime now1 = System.DateTime.Now;
                            //                                now1 = now1.AddSeconds(i * 90);
                            //                                chart.Series["SF"].Points.AddXY(now1, i * 10);
                            //                                chart.Series["Temp"].Points.AddXY(now1, i);
                            //                            }
                            chart.Titles[0].Text = String.Format("M{0}-{1}", mo + 1, ch + 1);

                            MaskViewOn[mo, ch] = true;
#endif
                        }
                    }
                }
            }

            if ((SF_Test.MultiRawColumnSize.Width == 256) && (SF_Test.MultiRawColumnSize.Height == 256))
            {
                Size size;
                int moduleCount = ChartCount / 4;
                if (moduleCount == 1)
                {
                    size = new Size(2, 2);
                }
                else if (moduleCount <= 4)
                {
                    size = new Size(4, moduleCount);
                }
                else if (moduleCount <= 8)
                {
                    size = new Size(moduleCount, 4);
                }
                else if (moduleCount <= 12)
                {
                    size = new Size(6, 8);
                }
                else if (moduleCount <= 16)
                {
                    size = new Size(12, 6);
                }
                else if (moduleCount == 18)
                {
                    size = new Size(3, 6);
                }
                else if (moduleCount <= 20)
                {
                    size = new Size(10, 8);
                }
                else if (moduleCount == 24)
                {
                    size = new Size(4, 6);
                }
                else
                {
                    size = new Size(12, 8);
                }
                nudWidth.Value = size.Width;
                nudHeight.Value = size.Height;
                SF_Test.MultiRawColumnSize.Width = size.Width;
                SF_Test.MultiRawColumnSize.Height = size.Height;
            }
            else
            {
                // Keep the current Raw, Column Size
                nudWidth.Value = SF_Test.MultiRawColumnSize.Width;
                nudHeight.Value = SF_Test.MultiRawColumnSize.Height;
            }
        }

        private void relocatefrmSubChannelMultiChart()
        {
            panel1.AutoScroll = false;
            //Size defaultOffsetPosition = new Size(0, tableLayoutPanel1.Size.Height);
            //Point StartPosition = new Point(0, 0) + defaultOffsetPosition;
            //Size MainModuleSize = this.Size - new Size(30, 0) - defaultOffsetPosition;

            Size MainModuleSize = panel1.Size - new Size(16, 16);
            Point StartPosition = new Point(0, 0);

            int ChartHeightCount = (int)nudHeight.Value;
            int ChartWidthCount = (int)nudWidth.Value;
            Size SubModuleSize = new Size(0, 0);
            Size WinModuleSize = new Size(0, 0);

            SubModuleSize = new Size(((MainModuleSize.Width - 8) / ChartWidthCount), ((MainModuleSize.Height - 8) / ChartHeightCount));
            WinModuleSize = SubModuleSize;

            Point ModulePosition = StartPosition;
            int cntFrame = 0;

            // Count Windows
            int count = 0;
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SF_Test.SystemParameter.ModuleEnable[mo])
                {
                    if (SF_Test.SystemParameter.ModuleOn[mo])
                    {
                        count++;
                    }
                }
            }

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                //Delay(100);
                // if (cntFrame >= 80) break;

                // Enable된 창만 활성화
                if (SF_Test.SystemParameter.ModuleEnable[mo])
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        Boolean fgMaskValveControlOn = false;
                        if ((SF_Test.SystemParameter.ValveControlOn == true) && (SF_Test.VCParameter.Enabled[mo, ch]))   // 해당 채널을 참조하는 경우 업데이트
                        {
                            fgMaskValveControlOn = true;
                        }

                        if ((SF_Test.fgGraphMin2[mo, ch] == false) && (SF_Test.fgGraphMax2[mo, ch] == false))
                        {
                            MaskViewOn[mo, ch] = false;
                        }
                        else
                        {
                            MaskViewOn[mo, ch] = true;
                        }

                        if (fgMaskViewOn)
                        {
                            if (MaskViewOn[mo, ch] == false)
                            {
                                // skip View
                                if (fgMaskValveControlOn == true)
                                {
                                    // Mask된 신호를 Valve Control에 이용하는것은 비정상임으로 표시를 해줌
                                }
                                else
                                {
                                    ChartMultiCH[mo, ch].Visible = false;
                                    continue;
                                }
                            }
                        }
                        //  ChartMultiCH[mo, ch].chart1.Series["SF"].Points.Clear();
                        //  ChartMultiCH[mo, ch].chart1.Series["Temp"].Points.Clear();

                        ChartMultiCH[mo, ch].Text = "SF Module # " + (mo + 1).ToString();
                        ChartMultiCH[mo, ch].Visible = true;
                        ChartMultiCH[mo, ch].StartPosition = FormStartPosition.Manual;
                        ChartMultiCH[mo, ch].Location = ModulePosition;

                        ChartMultiCH[mo, ch].Size = WinModuleSize;



                        if (fgColorOn) // 칼라표시를 켬
                        {
                            if (SF_Test.SystemParameter.ValveControlOn == true)
                            {
                                // 양액제어 화면 ON시

                                if ((MaskViewOn[mo, ch] == true) && (fgMaskValveControlOn == true))
                                {
                                    // Mask On(Alive Signal) & VavleControl On: 그래프 칼라처리
                                    ChartMultiCH[mo, ch].chart1.ChartAreas[0].BackColor = Color.White;
                                    ChartMultiCH[mo, ch].chart1.Titles["title1"].ForeColor = Color.ForestGreen;
                                    ChartMultiCH[mo, ch].chart1.Series["SF"].Color = Color.DeepSkyBlue;
                                    ChartMultiCH[mo, ch].chart1.Series["Temp"].Color = Color.DarkOrange;
                                }
                                else if (MaskViewOn[mo, ch] == true)
                                {
                                    // Mask On(Alive Signal): 그래프만 흑백처리
                                    //ChartMultiCH[mo, ch].chart1.ChartAreas[0].BackColor = Color.LightGray;
                                    ChartMultiCH[mo, ch].chart1.Titles["title1"].ForeColor = Color.DimGray;
                                    ChartMultiCH[mo, ch].chart1.Series["SF"].Color = Color.Gray;
                                    ChartMultiCH[mo, ch].chart1.Series["Temp"].Color = Color.DarkGray;

                                }
                                else if (fgMaskValveControlOn == true)
                                {
                                    // VavleControl On with Mask OFF 죽은 신호를 이용한것임으로 비정상상황
                                    ChartMultiCH[mo, ch].chart1.ChartAreas[0].BackColor = Color.Red;
                                    ChartMultiCH[mo, ch].chart1.Titles["title1"].ForeColor = Color.DimGray;
                                    ChartMultiCH[mo, ch].chart1.Series["SF"].Color = Color.Gray;
                                    ChartMultiCH[mo, ch].chart1.Series["Temp"].Color = Color.DarkGray;
                                }
                                else
                                {
                                    // Mask Off & ValveControl Off : 그래프와 배경 모두 흑백처리
                                    ChartMultiCH[mo, ch].chart1.ChartAreas[0].BackColor = Color.LightGray;
                                    ChartMultiCH[mo, ch].chart1.Titles["title1"].ForeColor = Color.DimGray;
                                    ChartMultiCH[mo, ch].chart1.Series["SF"].Color = Color.Gray;
                                    ChartMultiCH[mo, ch].chart1.Series["Temp"].Color = Color.DarkGray;
                                }
                            }
                            else
                            {
                                // 양액제어 화면 OFF시
                                if (MaskViewOn[mo, ch] == true)
                                {
                                    // Mask On(Alive Signal): 그래프 칼라처리
                                    ChartMultiCH[mo, ch].chart1.ChartAreas[0].BackColor = Color.White;
                                    ChartMultiCH[mo, ch].chart1.Titles["title1"].ForeColor = Color.ForestGreen;
                                    ChartMultiCH[mo, ch].chart1.Series["SF"].Color = Color.DeepSkyBlue;
                                    ChartMultiCH[mo, ch].chart1.Series["Temp"].Color = Color.DarkOrange;

                                }
                                else
                                {
                                    // Mask Off: 그래프와 배경 모두 흑백처리
                                    ChartMultiCH[mo, ch].chart1.ChartAreas[0].BackColor = Color.LightGray;
                                    ChartMultiCH[mo, ch].chart1.Titles["title1"].ForeColor = Color.DimGray;
                                    ChartMultiCH[mo, ch].chart1.Series["SF"].Color = Color.Gray;
                                    ChartMultiCH[mo, ch].chart1.Series["Temp"].Color = Color.DarkGray;
                                }
                            }

                        }
                        else
                        {
                            // Color표시를 끔
                            ChartMultiCH[mo, ch].chart1.ChartAreas[0].BackColor = Color.White;
                            ChartMultiCH[mo, ch].chart1.Titles["title1"].ForeColor = Color.ForestGreen;
                            ChartMultiCH[mo, ch].chart1.Series["SF"].Color = Color.DeepSkyBlue;
                            ChartMultiCH[mo, ch].chart1.Series["Temp"].Color = Color.DarkOrange;
                        }

                        if ((cntFrame % ChartWidthCount) == (ChartWidthCount - 1))
                        {
                            ModulePosition.X = StartPosition.X;
                            ModulePosition.Y = StartPosition.Y + SubModuleSize.Height * ((cntFrame + 1) / ChartWidthCount);
                        }
                        else
                        {
                            ModulePosition.X += SubModuleSize.Width;
                        }
                        cntFrame++;

                        ChartMultiCH[mo, ch].LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);

                    }
                }
            }
            panel1.AutoScroll = true;
        }

        private void btDataOn_Click(object sender, EventArgs e)
        {
            Button btTemp = (Button)sender;

            bool fgDataON;

            if (btTemp.Name == "btTitle")
            {
                fgDataON = fgTitleOn;
            }
            else if (btTemp.Name == "btDate")
            {
                fgDataON = fgDateOn;
            }
            else if (btTemp.Name == "btY1")
            {
                fgDataON = fgY1On;
            }
            else if (btTemp.Name == "btY2")
            {
                fgDataON = fgY2On;
            }
            else if (btTemp.Name == "btSF")
            {
                fgDataON = fgSFOn;
            }
            else if (btTemp.Name == "btRT")
            {
                fgDataON = fgRTOn;
            }
            else if (btTemp.Name == "btMaskView")
            {
                fgDataON = fgMaskViewOn;
            }
            else if (btTemp.Name == "btColorView")
            {
                fgDataON = fgColorOn;
            }
            else
            {
                fgDataON = false;
            }

            if (fgDataON)
            {
                fgDataON = false;
                btTemp.BackColor = System.Drawing.SystemColors.Control;
                btTemp.ForeColor = Color.Black;
            }
            else
            {
                fgDataON = true;
                btTemp.BackColor = Color.DarkGreen;
                btTemp.ForeColor = Color.White;
            }

            // 해당 디스플레이를 ON/OFF한다
            ChartDisplayOnOff(btTemp.Name, fgDataON);

            if (btTemp.Name == "btTitle")
            {
                fgTitleOn = fgDataON;
                SF_Test.fgMultiChartTitleOn = fgDataON;
            }
            else if (btTemp.Name == "btDate")
            {
                fgDateOn = fgDataON;
                SF_Test.fgMultiChartDateOn = fgDataON;
            }
            else if (btTemp.Name == "btY1")
            {
                fgY1On = fgDataON;
                SF_Test.fgMultiChartY1On = fgDataON;
            }
            else if (btTemp.Name == "btY2")
            {
                fgY2On = fgDataON;
                SF_Test.fgMultiChartY2On = fgDataON;
            }
            else if (btTemp.Name == "btSF")
            {
                fgSFOn = fgDataON;
                SF_Test.fgMultiChartSFOn = fgDataON;
            }
            else if (btTemp.Name == "btRT")
            {
                fgRTOn = fgDataON;
                SF_Test.fgMultiChartRTOn = fgDataON;
            }
            else if (btTemp.Name == "btMaskView")
            {
                fgMaskViewOn = fgDataON;
                SF_Test.fgMultiChartMaskViewOn = fgDataON;
                SF_Test.fgMultiChartRequestRefresh = true;
            }
            else if (btTemp.Name == "btColorView")
            {
                fgColorOn = fgDataON;
                SF_Test.fgMultiChartColorOn = fgDataON;
                SF_Test.fgMultiChartRequestRefresh = true;
            }
        }

        // fgON= true면 타이틀 표시, 아니면 숨김
        private void ChartDisplayOnOff(String strName, Boolean fgON)
        {
            Chart chart = null;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SF_Test.SystemParameter.ModuleEnable[mo])
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SF_Test.SystemParameter.ChannelEnable[mo, ch])
                        {
                            chart = ChartMultiCH[mo, ch].chart1;

                            if (strName == "btTitle")
                            {
                                chart.Titles["title1"].Visible = fgON;
                            }
                            else if (strName == "btDate")
                            {
                                chart.ChartAreas[0].AxisX.LabelStyle.Enabled = fgON;
                            }
                            else if (strName == "btY1")
                            {
                                chart.ChartAreas[0].AxisY.LabelStyle.Enabled = fgON;
                            }
                            else if (strName == "btY2")
                            {
                                chart.ChartAreas[0].AxisY2.LabelStyle.Enabled = fgON;
                            }
                            else if (strName == "btSF")
                            {
                                chart.Series["SF"].Enabled = fgON;
                            }
                            else if (strName == "btRT")
                            {
                                chart.Series["Temp"].Enabled = fgON;
                            }

                        }
                    }
                }
            }
        }

        private void btReflesh_Click(object sender, EventArgs e)
        {
            try
            {
                relocatefrmSubChannelMultiChart();
            }
            catch { }
        }

        private void frmSfMultiModules_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SF_Test.flagLockClose)
            {
                MessageBox.Show("Please, release [Lock Close].");
                e.Cancel = true;
                return;
            }

            // if (SF_Test.flagStarted)
            // {
            //     MessageBox.Show(String.Format("Please stop the process to exit the program."));
            //      e.Cancel = true;
            //     return;
            // }

            SF_Test.SystemParameter.MultiModuleOn = false;
        }

        private void btScale1d_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(1, 0, 0, 0);
            selectScaleIndexFromTimeSpan(timeSpan);
        }

        private void btScale3d_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(3, 0, 0, 0);
            selectScaleIndexFromTimeSpan(timeSpan);
        }

        private void btScaleFull_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(0);
            selectScaleIndexFromTimeSpan(timeSpan);
        }

        private void cbScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeSpan timeSpan = getScaleTimeSpan(cbScale.SelectedIndex);
            scaleOffset = 0;
            btScaleNext.Enabled = false;
            btScalePrevious.Enabled = true;
            scaleViewChange(timeSpan, scaleOffset);
        }

        // index = index of cbList 
        private TimeSpan getScaleTimeSpan(int index)
        {
            TimeSpan timeSpan;

            if (index <= listScaleComobBox.Length)
            {
                timeSpan = listScaleComobBox[index];
            }
            else
            {
                // 범위를 벗어난경우 Full Scale로 동작
                timeSpan = new TimeSpan(0);
            }

            return (timeSpan);
        }

        private void selectScaleIndexFromTimeSpan(TimeSpan timeSpan)
        {
            // Find cbBox Index from timeSpan Value
            for (int index = 0; index < cbScale.Items.Count; index++)
            {
                if (getScaleTimeSpan(index) == timeSpan)
                {
                    cbScale.SelectedIndex = index;
                    break;
                }
            }
        }

        // index = TimeSpan in cbList , timeOffset은 현위치로부터 몇스텝 떨어져있는지를 표시
        private void scaleViewChange(TimeSpan timeSpan, int timeOffset)
        {
            Chart chart = null;
            DateTime currentTime;
            Boolean fgUpdateTextOnce = true;    // 날짜 표시는 1회만 수행

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SF_Test.SystemParameter.ModuleEnable[mo])
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SF_Test.SystemParameter.ChannelEnable[mo, ch])
                        {
                            // SF기준 가장 최신 데이터의 Date값을 얻어옴
                            chart = ChartMultiCH[mo, ch].chart1;
                            int index = chart.Series["SF"].Points.Count;
                            if ((chart != null) && (index > 0))
                            {
                                currentTime = DateTime.FromOADate(chart.Series["SF"].Points[index - 1].XValue);
                            }
                            else
                            {
                                currentTime = DateTime.Now;
                            }

                            // timeSpan이 하루이상인경우 그날 자정을 기준으로 Scale을 설정
                            if (timeSpan >= new TimeSpan(1, 0, 0, 0))
                            {
                                currentTime = currentTime.Date.AddDays(1);
                            }

                            // Offset 처리
                            if (timeOffset > 0)
                            {
                                TimeSpan Offset;

                                if (timeSpan >= new TimeSpan(1, 0, 0, 0))
                                {
                                    Offset = new TimeSpan(1, 0, 0, 0);
                                }
                                else if (timeSpan >= new TimeSpan(1, 0, 0))
                                {
                                    Offset = new TimeSpan(1, 0, 0);
                                }
                                else
                                {
                                    Offset = timeSpan;
                                }

                                for (int i = 0; i < timeOffset; i++)
                                {
                                    currentTime -= Offset;
                                }
                            }


                            DateTime FirstTime, LastTime, BeginTime;

                            FirstTime = currentTime - timeSpan;  // 계산된 최초 표시 시간
                            LastTime = currentTime;              // 마지막 표시시간
                            if (chart.Series["SF"].Points.Count > 0)
                            {
                                BeginTime = DateTime.FromOADate(chart.Series["SF"].Points[0].XValue); // 그래프 최초시간
                            }
                            else
                            {
                                BeginTime = DateTime.Now;
                            }

                            if (FirstTime < BeginTime)
                            {
                                // BeginTime부터 표시
                                FirstTime = BeginTime;
                                LastTime = FirstTime + timeSpan;
                            }

                            if (timeSpan == new TimeSpan(0))
                            {
                                // Full Scale
                                FirstTime = BeginTime;
                                LastTime = currentTime;
                            }

                            chart.ChartAreas["ChartArea1"].AxisX.Minimum = FirstTime.ToOADate();
                            chart.ChartAreas["ChartArea1"].AxisX.Maximum = LastTime.ToOADate();
                            //chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                            //chart.ChartAreas[0].RecalculateAxesScale();

                            calculateChartAreasInterval(chart.ChartAreas["ChartArea1"], FirstTime, LastTime);
                            if (fgUpdateTextOnce == true)
                            {
                                fgUpdateTextOnce = false;
                                lbStartDate.Text = FirstTime.ToString("M/d H:mm");
                                lbEndDate.Text = LastTime.ToString("M/d H:mm");
                            }
                        }
                    }
                }
            }

        }

        // 축의 Min, Max값을 토대로 X축 Label표시값을 정한다.
        private void calculateChartAreasInterval(ChartArea chartAreas, DateTime FirstTime, DateTime LastTime)
        {
            TimeSpan timeSpan = LastTime - FirstTime;
            int timeStepMinute = 0;
            int timeStepHour = 0;
            int timeStepDay = 0;

            if (timeSpan < new TimeSpan(1, 0, 0, 0))
            {
                timeStepMinute = (int)(timeSpan.TotalMinutes / 4);
                chartAreas.AxisX.LabelStyle.Format = "M/dd\nH:mm";
                chartAreas.AxisX.IntervalType = DateTimeIntervalType.Minutes;
                chartAreas.AxisX.Interval = timeStepMinute;
            }
            else
            {
                timeStepHour = (int)(timeSpan.TotalHours / 4);
                chartAreas.AxisX.LabelStyle.Format = "M/dd\nH";
                chartAreas.AxisX.IntervalType = DateTimeIntervalType.Hours;
                chartAreas.AxisX.Interval = timeStepHour;
            }

        }

        private int scaleOffset = 0;
        private void btScalePrevious_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = getScaleTimeSpan(cbScale.SelectedIndex);
            if (scaleOffset == 0)
            {
                btScaleNext.Enabled = true;
            }
            scaleOffset++;
            scaleViewChange(timeSpan, scaleOffset);
        }

        private void btScaleNext_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = getScaleTimeSpan(cbScale.SelectedIndex);
            if (scaleOffset > 0)
            {
                scaleOffset--;
                scaleViewChange(timeSpan, scaleOffset);
            }

            if (scaleOffset == 0)
            {
                btScaleNext.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SF_Test.fgRequestMultiChartUpdate == true)
            {
                SF_Test.fgRequestMultiChartUpdate = false;

                // Update Chart
                cbScale_SelectedIndexChanged(sender, e);
            }

            if (SF_Test.fgMultiChartRequestRefresh == true)
            {
                SF_Test.fgMultiChartRequestRefresh = false;
                btReflesh_Click(sender, e);
            }
        }

        private void frmSfMultiModules_ResizeEnd(object sender, EventArgs e)
        {
            setfgRequestRefreshUpdate();
        }

        private void frmSfMultiModules_MaximumSizeChanged(object sender, EventArgs e)
        {
            setfgRequestRefreshUpdate();
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            SF_Test.MultiRawColumnSize.Width = (int)nudWidth.Value;
            setfgRequestRefreshUpdate();
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            SF_Test.MultiRawColumnSize.Height = (int)nudHeight.Value;
            setfgRequestRefreshUpdate();
        }

        private void setfgRequestRefreshUpdate()
        {
            if (SF_Test.fgMultiChartRequestRefresh == false)
            {
                SF_Test.fgMultiChartRequestRefresh = true;
            }
        }

        private void frmSfMultiModules_SizeChanged(object sender, EventArgs e)
        {
            setfgRequestRefreshUpdate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
