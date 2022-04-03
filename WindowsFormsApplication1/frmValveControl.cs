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
using System.Xml;
using ReaLTaiizor.Forms;

namespace SapflowApplication
{
    public partial class frmValveControl : MaterialForm
    {
        private const int SFModuleLength = SF_Test.SFModuleLength;      // SF_Test에 정의된 채널수를 참조
        private const int SFChannelLength = SF_Test.SFChannelLength;      // SF_Test에 정의된 채널수를 참조
        private const int VALVE_CONTROL_MAX_VALUE = SF_Test.VALVE_CONTROL_MAX_VALUE;

        public frmValveControl()
        {
            InitializeComponent();
        }

        enum typeParameter
        {
            READ,
            WRITE
        };

        private void exeVCParameter(typeParameter eType)
        {
            updateStartEndTime(SF_Test.VCParameter.StartEndEnabled);
            updateMaxMinTime(SF_Test.VCParameter.MaxMinEnabled);

            // Update Time Related Variables
            if (eType == typeParameter.READ)
            {
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        setSelectedChannel(mo, ch);
                    }
                }
                DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

                tbEventJoule.Text = SF_Test.VCParameter.EventJouleValue.ToString();

                dtpStartTime.Value = SF_Test.VCParameter.StartTime;
                dtpEndTime.Value = SF_Test.VCParameter.EndTime;
                dtpMaxTime.Value = dt + SF_Test.VCParameter.MaxTime;
                dtpMinTime.Value = dt + SF_Test.VCParameter.MinTime;

                updateListBoxLeft(String.Format("Load VC Parameter"));
            }
            else if (eType == typeParameter.WRITE)
            {
                try
                {
                    SF_Test.VCParameter.EventJouleValue = Convert.ToInt32(tbEventJoule.Text);

                    SF_Test.VCParameter.StartTime = dtpStartTime.Value;
                    SF_Test.VCParameter.EndTime = dtpEndTime.Value;
                    SF_Test.VCParameter.MaxTime = dtpMaxTime.Value.TimeOfDay; //new TimeSpan(dtpMaxTime.Value.Hour, dtpMaxTime.Value.Minute, 0);
                    SF_Test.VCParameter.MinTime = dtpMinTime.Value.TimeOfDay; //new TimeSpan(dtpMinTime.Value.Hour, dtpMinTime.Value.Minute, 0);
                }
                catch (Exception ex)
                {
                    updateListBoxLeft(String.Format("[ERR]{0}", ex.Message));
                    return;
                }

                updateListBoxLeft(String.Format("Save VC Parameter"));
            }
        }

        private void readVCParameter()
        {
            exeVCParameter(typeParameter.READ);
        }
        private void writeVCParameter()
        {
            if (SF_Test.flagLockControl)        // LockControl도중의 파라메터 변경을 금지
            {
                exeVCParameter(typeParameter.READ);
            }
            else
            {
                exeVCParameter(typeParameter.WRITE);
            }
        }

        private void frmValveControlSettingsLoad()
        {
            exeVCParameter(typeParameter.READ);
        }

        private void frmValveControlSettingsSave()
        {

            XmlDocument xdoc = new XmlDocument();

            // Root Node
            XmlNode root = xdoc.CreateElement("ValveControlParameter");
            xdoc.AppendChild(root);

            // Module Data
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                XmlNode module = xdoc.CreateElement("Module");
                XmlAttribute attr = xdoc.CreateAttribute("Number");
                attr.Value = (mo + 1).ToString();
                module.Attributes.Append(attr);

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    XmlNode channel = xdoc.CreateElement("Channel");
                    XmlAttribute attr1 = xdoc.CreateAttribute("Number");
                    attr1.Value = (ch + 1).ToString();
                    channel.Attributes.Append(attr1);

                    XmlNode Max = xdoc.CreateElement("Max");
                    Max.InnerText = SF_Test.VCParameter.Max[mo, ch].ToString();
                    channel.AppendChild(Max);

                    XmlNode Min = xdoc.CreateElement("Min");
                    Min.InnerText = SF_Test.VCParameter.Min[mo, ch].ToString();
                    channel.AppendChild(Min);

                    XmlNode Constrain = xdoc.CreateElement("Constrain");
                    Constrain.InnerText = SF_Test.VCParameter.Constrain[mo, ch].ToString();
                    channel.AppendChild(Constrain);

                    module.AppendChild(channel);
                }
                root.AppendChild(module);
            }
            xdoc.Save(@"C:\Temp\valvecontrolparameter.xml");
            /*
            Properties.Settings.Default.tbSFMax01Save = tbSFMax01.Text;
            Properties.Settings.Default.tbSFMax02Save = tbSFMax02.Text;
            Properties.Settings.Default.tbSFMax03Save = tbSFMax03.Text;
            Properties.Settings.Default.tbSFMax04Save = tbSFMax04.Text;

            Properties.Settings.Default.tbSFMin01Save = tbSFMin01.Text;
            Properties.Settings.Default.tbSFMin02Save = tbSFMin02.Text;
            Properties.Settings.Default.tbSFMin03Save = tbSFMin03.Text;
            Properties.Settings.Default.tbSFMin04Save = tbSFMin04.Text;

            Properties.Settings.Default.tbSFConstrain01Save = tbSFConstrain01.Text;
            Properties.Settings.Default.tbSFConstrain02Save = tbSFConstrain02.Text;
            Properties.Settings.Default.tbSFConstrain03Save = tbSFConstrain03.Text;
            Properties.Settings.Default.tbSFConstrain04Save = tbSFConstrain04.Text;
            Properties.Settings.Default.Save();
            */
        }

        private static Series[,] series = new Series[SFModuleLength, SFChannelLength];

        private void frmValveControl_Load(object sender, EventArgs e)
        {
            setWindowPosition();

            Chart chart = null;
            chart = chart1;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    Series series1 = new Series();

                    series1.ChartArea = "ChartArea1";
                    series1.ChartType = SeriesChartType.FastLine;
                    series1.Name = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");
                    series1.YValueType = ChartValueType.Int32;
                    series[mo, ch] = series1;
                    series[mo, ch].Enabled = true;
                    chart.Series.Add(series[mo, ch]);
                }

            }


            initializeScaleComboBox();

            this.Icon = SapflowApplication.Properties.Resources.logo_real;
            SF_Test.SystemParameter.ValveControlOn = true;

            frmValveControlSettingsLoad();     // 파라메터 설정값 로드

            for (int i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].XValueType = ChartValueType.DateTime;
            }
            for (int i = 0; i < 2; i++)
            {
                chart.ChartAreas[i].AxisX.LabelStyle.Format = "M/dd\nH";
                chart.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Hours;
                chart.ChartAreas[i].AxisX.Interval = 1;

                chart.ChartAreas[i].AxisY.Maximum = VALVE_CONTROL_MAX_VALUE;
                chart.ChartAreas[i].AxisY.Minimum = 0;

                chart.ChartAreas[i].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas[i].AxisY.ScaleView.ZoomReset(0);
            }

#if false
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    String Name = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");
                    chart.Series[Name].Points.AddXY(DateTime.Now, 100);
                    chart.Series[Name].Points.AddXY(DateTime.Now.AddHours(1), 200);
                    chart.Series[Name].Points.AddXY(DateTime.Now.AddHours(2), 300);
                }
                SF_Test.fgRequestValveControlUpdate = true;
            }
#endif
        }

        private TimeSpan[] listScaleComobBox = {
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

            // 화며의 4분할에 왼쪽 아래에 배치
            DisplaySize.Width /= 2;
            DisplaySize.Height /= 2;
            StartPosition.Y += DisplaySize.Height;

            this.Location = StartPosition;
            this.Size = DisplaySize;
        }

        private void frmValveControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SF_Test.flagLockClose)
            {
                updateListBoxRight("Lock Close");
                e.Cancel = true;
                return;
            }

            DialogResult result = MessageBox.Show("양액제어창을 닫으면 기존 양액제어 데이터가 지워집니다. 닫으시겠습니까?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //code for Yes
                //   frmValveControlSettingsSave();     // 파라메터 설정값 세이브
                SF_Test.SystemParameter.ValveControlOn = false;
            }
            else if (result == DialogResult.No)
            {
                //code for No
                e.Cancel = true;
            }

        }

        private void setSelectedModule(int number)
        {
            // save data
            writeVCParameter();

            // load data
            readVCParameter();
        }

        private void setSelectedChannel(int mo, int ch)
        {
            chart1.Series[mo * 4 + ch].Enabled = SF_Test.VCParameter.Enabled[mo, ch];
        }

        public void updateListBoxLeft(string str)
        {
            if (listBoxLeft.Items.Count > 9999)
            {
                listBoxLeft.Items.RemoveAt(0);
            }
            listBoxLeft.Items.Add(str);
            listBoxLeft.SelectedIndex = listBoxLeft.Items.Count - 1;
        }

        public void updateListBoxRight(string str)
        {
            if (listBoxRight.Items.Count > 9999)
            {
                listBoxRight.Items.RemoveAt(0);
            }
            listBoxRight.Items.Add(str);
            listBoxRight.SelectedIndex = listBoxRight.Items.Count - 1;
        }

        public void btLoadParameter_Click(object sender, EventArgs e)
        {
            // load data
            readVCParameter();

            graphEnableUpdate();
        }
        private void btSaveParameter_Click(object sender, EventArgs e)
        {
            // write data
            writeVCParameter();
        }

        private void tbPreprocess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {

                e.Handled = true;
            }
        }

        private void tbPreprocessPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
            {

                e.Handled = true;
            }
        }

        private void btStartValveControl_Click(object sender, EventArgs e)
        {
            if (SF_Test.flagLockControl)
            {
                updateListBoxLeft("Please uncheck[Lock Close].");
                return;
            }
            SF_Test.VCParameter.EventStarted = true;
            btStartValveControl.Enabled = false;
            btStopValveControl.Enabled = true;

            handleGUIRelated(false);

            graphEnableUpdate();

            // Start를 알림
            btStartValveControl.BackColor = Color.LawnGreen;
            btStartValveControl.UseVisualStyleBackColor = false;
            btStopValveControl.BackColor = Color.Ivory;
            btStopValveControl.UseVisualStyleBackColor = true;
        }

        private void btStopValveControl_Click(object sender, EventArgs e)
        {
            if (SF_Test.flagLockControl)
            {
                updateListBoxLeft("Please uncheck[Lock Close].");
                return;
            }

            SF_Test.VCParameter.EventStarted = false;
            SF_Test.VCParameter.EventActivated = false;
            btStartValveControl.Enabled = true;
            btStopValveControl.Enabled = false;

            handleGUIRelated(true);

            graphEnableUpdate();

            // Stop시 경고를 위해 DartOrange설정
            btStartValveControl.BackColor = Color.Ivory;
            btStartValveControl.UseVisualStyleBackColor = true;

            btStopValveControl.BackColor = Color.DarkOrange;
            btStopValveControl.UseVisualStyleBackColor = false;
        }


        private void graphEnableUpdate()
        {
            Chart chart;
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SF_Test.SystemParameter.ModuleEnable[mo] == false) continue;
                chart = chart1;
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SF_Test.SystemParameter.ChannelEnable[mo, ch] == false) continue;
                    string strChartName = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");
                    if (SF_Test.SystemParameter.ChannelEnable[mo, ch])
                    {
                        if (SF_Test.VCParameter.Enabled[mo, ch])    // 해당 채널을 참조하는 경우 업데이트
                        {
                            chart.Series[strChartName].Enabled = true;
                        }
                        else
                        {
                            chart.Series[strChartName].Enabled = false;
                        }
                    }
                }
            }

            chart = chart1;
            chart.Series["mergedSFValue"].Enabled = true;
            chart.Series["totalSFValue"].Enabled = true;
            chart.Series["ValveControl"].Enabled = true;
            chart.Series["IntegratedValue"].Enabled = true;

            // Update Chart
            cbScale_SelectedIndexChanged(null,null);
        }

        private void handleGUIRelated(bool state)
        {
            tbEventJoule.Enabled = state;
            btSaveParameter.Enabled = state;
            btLoadParameter.Enabled = state;

            dtpStartTime.Enabled = state;
            dtpEndTime.Enabled = state;
            dtpMaxTime.Enabled = state;
            dtpMinTime.Enabled = state;

        }

        private void btDataExport_Click(object sender, EventArgs e)
        {
            if (SF_Test.VCParameter.EventStarted)
            {
                updateListBoxLeft("Prohibited during Measurement.");
                return;
            }
            if (SF_Test.flagLockControl)
            {
                updateListBoxLeft("Please uncheck[Lock Close].");
                return;
            }
            /*
                        int line = 0;

                        if (mModuleArray.Count == 0)
                        {
                            updateListBoxLeft("No data stored.");
                            return;
                        }
                        updateListBoxLeft("Data Export...");

                        StringBuilder savedata = new StringBuilder();

                        if (mModuleArray.Count == 0) return;

                        string outputPath = Application.StartupPath + "\\log\\";
                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
                        if (di.Exists == false)
                        {
                            di.Create();
                        }

                        fsDataExport = outputPath + "ValveControl_" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
                        StreamWriter sw = new StreamWriter(fsDataExport);
                        sw.Write("Date, Module Number, Channel Number, Initial Temp., Last Temp., Diff Temp.,Temperature, Humidity, VPD, a, b, c, Tm" + Environment.NewLine);

                        for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
                        {
                            savedata.Clear();

                            DateTime tempDate;
                            tempDate = DateTime.FromOADate(mModuleArray[cnt].OADate);

                            for (int mo = 0; mo < SFModuleLength; mo++)
                            {
                                for (int ch = 0; ch < SFChannelLength; ch++)
                                {
                                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                                    {
                                        // Date
                                        savedata.Append(tempDate.ToString("yyyy-MM-dd HH:mm:ss"));
                                        savedata.Append(", ");

                                        // Module number, Channel number
                                        savedata.Append((mo + 1).ToString("#"));
                                        savedata.Append(", ");
                                        savedata.Append((ch + 1).ToString("#"));
                                        savedata.Append(", ");

                                        // Initial Temp., Last Temp., Diff Temp.
                                        UInt16 tempInit, tempHeat;
                                        int tempDiff;
                                        tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                                        tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;
                                        tempDiff = tempHeat - tempInit;

                                        savedata.Append(tempInit.ToString("D5"));
                                        savedata.Append(", ");
                                        savedata.Append(tempHeat.ToString("D5"));
                                        savedata.Append(", ");
                                        savedata.Append(tempDiff.ToString("D5"));
                                        savedata.Append(", ");

                                        // a, b, c, Tm
                                        savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_a.ToString());
                                        savedata.Append(", ");
                                        savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_b.ToString());
                                        savedata.Append(", ");
                                        savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_c.ToString());
                                        savedata.Append(", ");

                                        savedata.Append(Environment.NewLine);
                                        line++;
                                    }
                                }
                            }
                            sw.Write(savedata.ToString());
                        }
                        sw.Close();
                        updateListBoxLeft(String.Format("Done, {0} Line Updated.", line));
                        */
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if ((SF_Test.VCParameter.EventStarted) || (SF_Test.flagLockControl))
            {
                readVCParameter();
                return;
            }

            try
            {
                SF_Test.VCParameter.StartTime = dtpStartTime.Value;
            }
            catch (Exception ex)
            {
                updateListBoxLeft(String.Format("[ERR]{0}", ex.Message));
                return;
            }

            updateListBoxLeft(String.Format("S:{0}", SF_Test.VCParameter.StartTime.ToString("HH:mm")));
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if ((SF_Test.VCParameter.EventStarted) || (SF_Test.flagLockControl))
            {
                readVCParameter();
                return;
            }

            try
            {
                SF_Test.VCParameter.EndTime = dtpEndTime.Value;
            }
            catch (Exception ex)
            {
                updateListBoxLeft(String.Format("[ERR]{0}", ex.Message));
                return;
            }
            updateListBoxLeft(String.Format("E:{0}", SF_Test.VCParameter.EndTime.ToString("HH:mm")));
        }


        private void dtpMaxTime_ValueChanged(object sender, EventArgs e)
        {
            if ((SF_Test.VCParameter.EventStarted) || (SF_Test.flagLockControl))
            {
                readVCParameter();
                return;
            }
            try
            {
                SF_Test.VCParameter.MaxTime = dtpMaxTime.Value.TimeOfDay;
            }
            catch (Exception ex)
            {
                updateListBoxLeft(String.Format("[ERR]{0}", ex.Message));
                return;
            }
            DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

            updateListBoxLeft(String.Format("Max:{0}", dt.Add(SF_Test.VCParameter.MaxTime).ToString("HH:mm")));

        }

        private void dtpMinTime_ValueChanged(object sender, EventArgs e)
        {
            if ((SF_Test.VCParameter.EventStarted) || (SF_Test.flagLockControl))
            {
                readVCParameter();
                return;
            }
            try
            {
                SF_Test.VCParameter.MinTime = dtpMinTime.Value.TimeOfDay;
            }
            catch (Exception ex)
            {
                updateListBoxLeft(String.Format("[ERR]{0}", ex.Message));
                return;
            }

            DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

            updateListBoxLeft(String.Format("Min:{0}", dt.Add(SF_Test.VCParameter.MinTime).ToString("HH:mm")));

        }

        private void tbEventJoule_TextChanged(object sender, EventArgs e)
        {
            int JouleValue;

            if ((SF_Test.VCParameter.EventStarted) || (SF_Test.flagLockControl))
            {
                readVCParameter();
                return;
            }

            try
            {
                JouleValue = Convert.ToInt32(tbEventJoule.Text);
            }
            catch (Exception ex)
            {
                updateListBoxLeft(String.Format("[ERR]{0}", ex.Message));
                return;
            }
            if (JouleValue < 99999)
            {
                SF_Test.VCParameter.EventJouleValue = JouleValue;
                updateListBoxLeft(String.Format("J:{0}", SF_Test.VCParameter.EventJouleValue.ToString()));
            }
            else
            {
                updateListBoxLeft(String.Format("[ERR] Too large number :{0}", JouleValue));
                tbEventJoule.Text = SF_Test.VCParameter.EventJouleValue.ToString();
            }
        }

        private void lbStartEndTime_Click(object sender, EventArgs e)
        {
            Boolean fgEnabled;

            if (SF_Test.VCParameter.EventStarted) return;
            if (SF_Test.flagLockControl) return;

            fgEnabled = SF_Test.VCParameter.StartEndEnabled;

            SF_Test.VCParameter.StartEndEnabled ^= true;

            writeVCParameter();
        }

        private void lbMaxMinTime_Click(object sender, EventArgs e)
        {
            if (SF_Test.VCParameter.EventStarted) return;
            if (SF_Test.flagLockControl) return;

            SF_Test.VCParameter.MaxMinEnabled ^= true;

            writeVCParameter();
        }

        private void updateStartEndTime(Boolean fgEnabled)
        {
            Label lbFunction1, lbFunction2;
            DateTimePicker dtpFunction1, dtpFunction2;

            lbFunction1 = lbStartTime;
            lbFunction2 = lbEndTime;
            dtpFunction1 = dtpStartTime;
            dtpFunction2 = dtpEndTime;

            if (fgEnabled)
            {
                // Status ON 
                lbFunction1.ForeColor = System.Drawing.Color.Lime;
                lbFunction2.ForeColor = System.Drawing.Color.Lime;
                dtpFunction1.Enabled = true;
                dtpFunction2.Enabled = true;
            }
            else
            {
                // Status OFF 
                lbFunction1.ForeColor = System.Drawing.Color.Gray;
                lbFunction2.ForeColor = System.Drawing.Color.Gray;
                dtpFunction1.Enabled = false;
                dtpFunction2.Enabled = false;
            }
        }

        private void updateMaxMinTime(Boolean fgEnabled)
        {
            Label lbFunction1, lbFunction2;
            DateTimePicker dtpFunction1, dtpFunction2;

            lbFunction1 = lbMaxTime;
            lbFunction2 = lbMinTime;
            dtpFunction1 = dtpMaxTime;
            dtpFunction2 = dtpMinTime;

            if (fgEnabled)
            {
                // Status ON 
                lbFunction1.ForeColor = System.Drawing.Color.Lime;
                lbFunction2.ForeColor = System.Drawing.Color.Lime;
                dtpFunction1.Enabled = true;
                dtpFunction2.Enabled = true;

            }
            else
            {
                // Status OFF 
                lbFunction1.ForeColor = System.Drawing.Color.Gray;
                lbFunction2.ForeColor = System.Drawing.Color.Gray;
                dtpFunction1.Enabled = false;
                dtpFunction2.Enabled = false;
            }
        }

        private void executeAxisViewChanged()
        {
            for (int i = 0; i < 2; i++)
            {

                TimeSpan interval = DateTime.FromOADate(chart1.ChartAreas[i].AxisX.ScaleView.ViewMaximum)
                                    - DateTime.FromOADate(chart1.ChartAreas[i].AxisX.ScaleView.ViewMinimum);

                chart1.ChartAreas[i].AxisX2.LabelStyle.Format = "MM/dd";
                chart1.ChartAreas[i].AxisX2.IntervalType = DateTimeIntervalType.Minutes;
                chart1.ChartAreas[i].AxisX2.Interval = Convert.ToInt32(Convert.ToInt32(interval.TotalMinutes / 30) * 30 / 8);


                if (interval.Days < 1)   // 하루 이내
                {
                    chart1.ChartAreas[i].AxisX.LabelStyle.Format = "MM/dd\nHH:mm";
                    chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Minutes;
                    chart1.ChartAreas[i].AxisX.Interval = Convert.ToInt32(Convert.ToInt32(interval.TotalMinutes / 30) * 30 / 8);
                }
                else if (interval.Days < 7)  // Week
                {
                    chart1.ChartAreas[i].AxisX.LabelStyle.Format = "MM/dd\nHH:mm";
                    chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Hours;
                    chart1.ChartAreas[i].AxisX.Interval = Convert.ToInt32(interval.TotalHours / 8);
                }
                else //  if (interval.Days < 30)  // Month
                {
                    chart1.ChartAreas[i].AxisX.LabelStyle.Format = "MM/dd";
                    chart1.ChartAreas[i].AxisX.IntervalType = DateTimeIntervalType.Days;
                    chart1.ChartAreas[i].AxisX.Interval = Convert.ToInt32(interval.TotalDays / 8);
                }
            }

        }

        private void chart1_AxisViewChanged_1(object sender, ViewEventArgs e)
        {
            executeAxisViewChanged();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmValveControlSetup setup = new frmValveControlSetup();
            setup.ShowDialog();

            graphEnableUpdate();
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
#if false
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SF_Test.SystemParameter.ModuleEnable[mo] == false) continue;

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SF_Test.SystemParameter.ChannelEnable[mo, ch] == false) continue;

                    string strChartName = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");

                    if (SF_Test.VCParameter.Enabled[mo, ch])    // 해당 채널을 참조하는 경우 업데이트
                    {
                        if (SF_Test.SystemParameter.ChannelEnable[mo, ch])
                        {
                            subScaleViewChange(strChartName, timeSpan, timeOffset);
                            break;
                        }
                    }
                }
            }
#endif
            // 한가지 그래프만 가지고 전체 그래프를 같이 움직이도록함
            subScaleViewChange("mergedSFValue", timeSpan, timeOffset);
            //subScaleViewChange("totalSFValue", timeSpan, timeOffset);
            //subScaleViewChange("ValveControl", timeSpan, timeOffset);
            //subScaleViewChange("IntegratedValue", timeSpan, timeOffset);

        }


        private void subScaleViewChange(String ChartName, TimeSpan timeSpan, int timeOffset)
        {
            Chart chart = null;
            DateTime currentTime;

            chart = chart1;
            // SF기준 가장 최신 데이터의 Date값을 얻어옴
            int index = chart.Series[ChartName].Points.Count;
            if ((chart != null) && (index > 0))
            {
                currentTime = DateTime.FromOADate(chart.Series[ChartName].Points[index - 1].XValue);
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

                if(timeSpan >= new TimeSpan(1,0,0,0))
                {
                    Offset = new TimeSpan(1, 0, 0, 0);
                }
                else if(timeSpan >= new TimeSpan(1, 0, 0))
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
            if (chart.Series[ChartName].Points.Count > 0)
            {
                BeginTime = DateTime.FromOADate(chart.Series[ChartName].Points[0].XValue); // 그래프 최초시간
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

            chart.ChartAreas["ChartArea2"].AxisX.Minimum = FirstTime.ToOADate();
            chart.ChartAreas["ChartArea2"].AxisX.Maximum = LastTime.ToOADate();

            //chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
    //        chart.ChartAreas[0].RecalculateAxesScale();
    //        chart.ChartAreas[1].RecalculateAxesScale();

            //calculateChartAreasInterval(chart.ChartAreas["ChartArea1"], FirstTime, LastTime);
            chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false; // 윗쪽 그래프의 날짜표시는 끔
            calculateChartAreasInterval(chart.ChartAreas["ChartArea1"], FirstTime, LastTime);
            calculateChartAreasInterval(chart.ChartAreas["ChartArea2"], FirstTime, LastTime);

            try
            {
                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas[1].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas[0].RecalculateAxesScale();
                chart.ChartAreas[1].RecalculateAxesScale();
            }
            catch { }
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
            if (SF_Test.fgRequestValveControlUpdate == true)
            {
                SF_Test.fgRequestValveControlUpdate = false;

                // Update Chart
                cbScale_SelectedIndexChanged(sender, e);
            }
        }

    }
}