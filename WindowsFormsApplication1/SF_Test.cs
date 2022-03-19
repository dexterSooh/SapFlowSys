//#define DEBUG_TIME_FAST    
//#define SERVER_INCLUDED

#if (SERVER_INCLUDED)
// link btServerSetup_Click, and add frmServserSetup.cs Form
#define SERVER_QUERY
// link btCommSetup_Click, btMQTTTest_Click, and add SF_Test.Comm.cs source
#define SERVER_COMMUNICATION
#endif

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
using System.IO.Ports;
using System.Diagnostics;
using System.IO;

namespace SapflowApplication
{
    public partial class SF_Test : Form
    {
        private const string ProgramShortName = "Real SF Monitoring Program";
#if DEBUG
        private const string ProgramName = ProgramShortName + "(D)";
#else
        private const string ProgramName = ProgramShortName + "(R)";
#endif
        // 2017/10/20 첫 릴리즈 
        private const string ProgramVersion = "1.000";
        public const int SFModuleLength = 32;        // 최대모듈수 32변경(18/06/11),  모듈수(!! 100보다 작은 값 사용, 100 이상시 log분석루틴 수정요)
        public const int SFChannelLength = 4;       // 모듈당 채널수 (!! 10보다 작은 값 사용, 10 이상시 log분석루틴 수정요)
        private int SfModuleSelectedItem = 1;
        public const int MODULE_ENABED_NUMBER = 1;  // 초기 Enable모듈수 지정

        /* Parameters */
        public float[] mTemperature = new float[SFModuleLength];
        public float[] mHumidity = new float[SFModuleLength];
        public float[] mSoilMoisture = new float[SFModuleLength];

        // public float[] mPara_a = new float[SFModuleLength];
        // public float[] mPara_b = new float[SFModuleLength];
        // public float[] mPara_c = new float[SFModuleLength];       // 3.141593f
        // public float[] mPara_Tm = new float[SFModuleLength];
        public UInt16[] CalibrationResult = new UInt16[SFChannelLength];
        public bool CalibrationDataReady;
        public bool CalibrationCommStatus;
        public int CalibrationErrorCount;

        public frmSfModule[] m_frmSfModule = new frmSfModule[SFModuleLength];
        public frmCalibration m_frmCalibration = null;
        public frmValveControl m_frmValveControl = null;
        public frmSfMultiModules m_frmSfMultiModules = null;
        public frmRestarting m_frmRestarting = null;
        public frmMessageBox m_frmMessageBox = null;

        private SerialPort _Port;
        public static List<double> m_TimeArray = new List<double>();       // 샘플링 시간을 기록하기 위한 변수 초기화
        public static List<totalRawModuleData> mModuleArray = new List<totalRawModuleData>();

        public static UInt32 m_SampleCount;
        private const int RECV_BUF_SIZE = 4096;

        private Byte[] recvBuf = new byte[RECV_BUF_SIZE];
        private Byte[] recvRawBuf = new byte[RECV_BUF_SIZE];
        private string[] recvCommand = new string[256];

        private int recvBufCnt = 0;
        private int readCnt = 0;
        private bool flagAllowAction = true;
        private bool flagTimerInProgress = false;

        private int subCountProgressBar = 0;
        private int currentMeasuringChannel = 0;

        private int[,] CurrentChartPointCount = new int[SFModuleLength, SFChannelLength];
        private int[,] CurrentMultiChartPointCount = new int[SFModuleLength, SFChannelLength];

        private const int VCSeriesCount = (SFModuleLength * SFChannelLength + 4);
        private int[] CurrentVCPointChannelCount = new int[VCSeriesCount];
        private int IndexTotalSFCount = 4;      // -4
        private int IndexMergedSFCount = 3;     // -3
        private int IndexIntegratedCount = 2;   // -2
        private int IndexValveControlCount = 1; // -1

#if (DEBUG_TIME_FAST)
        public DateTime FastTime;
#endif
        public DateTime StartTime;
        public DateTime StartMaxTime;
        public Boolean flagStarting = false;
        public static Boolean flagStarted = false;
        public Boolean flagLogReading = false;

        private Boolean flagAutoTmRequest = false;      // 00:00에 Set, 06:00에 실행후 Clear

        private const byte ModuleType_SF = 0x11;
        private const byte ModuleType_EC = 0x22;
        private const byte ModuleSubType = 0x00;

        // COMM COMMAND CODE
        private const int COMM_CMD_HUMIDITY = 0x11;
        private const int COMM_CMD_TEMPERATURE = 0x12;
        private const int COMM_CMD_START = 0x21;
        private const int COMM_CMD_FINISH = 0x22;
        private const int COMM_CMD_TUR = 0x23;
        private const int COMM_CMD_MODULE_INFO = 0x2E;
        private const int COMM_CMD_CALIBRATION = 0x31;
        private const int COMM_CMD_SOLAR_RAD = 0x41;
        private const int COMM_CMD_VALVE_CONTROL = 0x42;
        private const int COMM_CMD_EEPROM_READ = 0x71;
        private const int COMM_CMD_EEPROM_WRITE = 0x7E;

        // 2018/03/02 Added
        private const int COMM_CMD_START_CPT = 0x28;        // Broadcastion & no return
        private const int COMM_CMD_FINISH_CPT = 0x29;
        private const int COMM_CMD_TUR_CPT = 0x2A;
        private const int COMM_CMD_CALIBRATION_CPT = 0x38;

        // COMM ERROR CODE
        private const int COMM_ERROR_CODE_M_NUMBER_MISMATCH = 0x41;
        private const int COMM_ERROR_CODE_CHECKSUM_ERROR = 0x42;
        private const int COMM_ERROR_CODE_RSPLEN_MISMATCH = 0x43;
        private const int COMM_ERROR_CODE_CMD_MISMATCH = 0x44;

        // MODULE NUMBER & TYPE
        private const int VALUE_MODULE_NUMBER_SOLAR_RADIATION = 0x1000;
        private const int VALUE_MODULE_NUMBER_VALVE_CONTROL = 0x2000;

        private const int VALUE_MODULE_TYPE_SF = 0x8001;
        private const int VALUE_MODULE_TYPE_SOLAR_RADIATION = 0x8100;
        private const int VALUE_MODULE_TYPE_VALVE_CONTROL = 0x8002;

        // Module Selection

        public struct ModuleDefine
        {
            public byte mType;
            public byte mSubtype;
            public UInt16 mModuleNumber;
        }

        public struct RawDataSF
        {
            public UInt16 InitialTemperature;
            public UInt16 HeatedTemperature;
            public float Para_CH_Tm;
        }

        public struct AdditionalData
        {
            public float ExternalTemperature;
            public float ExternalHumidity;
            public float ExternalSoilMoisture;
            public float Para_a;
            public float Para_b;
            public float Para_c;
            public float Para_Tm_CH1;
            public float Para_Tm_CH2;
            public float Para_Tm_CH3;
            public float Para_Tm_CH4;

            public AdditionalData(float temp, float humi, float soil, float a, float b, float c, float Tm1, float Tm2, float Tm3, float Tm4)
            {
                ExternalTemperature = temp;
                ExternalHumidity = humi;
                ExternalSoilMoisture = soil;
                Para_a = a;
                Para_b = b;
                Para_c = c;
                Para_Tm_CH1 = Tm1;
                Para_Tm_CH2 = Tm2;
                Para_Tm_CH3 = Tm3;
                Para_Tm_CH4 = Tm4;
            }
        }

        // List Data 
        public class rawModuleData
        {
            public ModuleDefine moduleDefine; // schema { get; set; }
            public RawDataSF[] CHData = new RawDataSF[SFChannelLength];     // 채널별 데이터 기록
            public AdditionalData additionalData; // schema { get; set; }
        }

        public class rawValveControData
        {
            public bool[,] Enabled = new bool[SFModuleLength, SFChannelLength];
            public float[,] Max = new float[SFModuleLength, SFChannelLength];
            public float[,] Min = new float[SFModuleLength, SFChannelLength];
            public int[,] Constrain = new int[SFModuleLength, SFChannelLength];
            public int[,] Ratio = new int[SFModuleLength, SFChannelLength];
            public int EventJouleValue;
            public DateTime StartTime;
            public DateTime EndTime;
            public TimeSpan MaxTime;
            public TimeSpan MinTime;
        }

        // List Total Data 
        public class totalRawModuleData
        {
            public UInt32 Index;    // schema { get; set; }
            public double OADate;   // schema { get; set; }
            public rawModuleData[] rawModudle = new rawModuleData[SFModuleLength];  // 모든 모듈 데이터 기록
            public rawValveControData rawValveControl = new rawValveControData();
        }

        public const string S_CR = "\r";
        public const string S_NL = "\n";
        string[] strATStatus = new string[100];

        private double m_valuePrimary;
        private double m_valueSecondary;
        private float[,] valueSF = new float[SFModuleLength, SFChannelLength];
        private float[,] valueRTemp = new float[SFModuleLength, SFChannelLength];
        private float[] valueTemperature = new float[SFModuleLength];
        private float[] valueHumidity = new float[SFModuleLength];

        private UInt16[,] arrayInitialData = new UInt16[SFModuleLength, SFChannelLength];
        private UInt16[,] arrayHeatedData = new UInt16[SFModuleLength, SFChannelLength];
        private float[] arrayTemperatureData = new float[SFModuleLength];
        private float[] arrayHumidityData = new float[SFModuleLength];

        private float[,] valueSFMin = new float[SFModuleLength, SFChannelLength];
        private float[,] valueSFMax = new float[SFModuleLength, SFChannelLength];
        private float[,] valueRTempMin = new float[SFModuleLength, SFChannelLength];
        private float[,] valueRTempMax = new float[SFModuleLength, SFChannelLength];

        private float[] valueTemperatureMin = new float[SFModuleLength];
        private float[] valueTemperatureMax = new float[SFModuleLength];
        private float[] valueHumidityMin = new float[SFModuleLength];
        private float[] valueHumidityMax = new float[SFModuleLength];

        // Graph & Window Parameter saved
        public static Boolean fgGraphParameterSaved = false;

        // Graph Min, Max Parameter
        public static float[,] GraphMax = new float[SFModuleLength, SFChannelLength];
        public static float[,] GraphMin = new float[SFModuleLength, SFChannelLength];
        public static Boolean[,] fgGraphMax = new Boolean[SFModuleLength, SFChannelLength];
        public static Boolean[,] fgGraphMin = new Boolean[SFModuleLength, SFChannelLength];
        public static Boolean[,] fgMaskViewOn = new Boolean[SFModuleLength, SFChannelLength];

        // Graph Min, Max Parameter2
        public static float[,] GraphMax2 = new float[SFModuleLength, SFChannelLength];
        public static float[,] GraphMin2 = new float[SFModuleLength, SFChannelLength];
        public static Boolean[,] fgGraphMax2 = new Boolean[SFModuleLength, SFChannelLength];
        public static Boolean[,] fgGraphMin2 = new Boolean[SFModuleLength, SFChannelLength];

        // Graph Windows Size
        public static Point[] GraphLocation = new Point[SFModuleLength];
        public static Size[] GraphSize = new Size[SFModuleLength];

        public static Boolean fgRequestMultiChartUpdate = false;
        public static Boolean fgRequestValveControlUpdate = false;

        public static Boolean fgMultiChartRequestRefresh = false;

        private string fs;
        private string fs2;
        private string fs3;
        private string fs4;
        private string fs_preset;

        public static Boolean flagLockClose, flagLockControl;

        // Multichart Raw, Column Count
        public static Size MultiRawColumnSize = new Size(256, 256);    // Default undefined Max Size

        // Display 표시 초기값
        public static Boolean fgMultiChartTitleOn = true;
        public static Boolean fgMultiChartDateOn = false;
        public static Boolean fgMultiChartY1On = true;
        public static Boolean fgMultiChartY2On = false;
        public static Boolean fgMultiChartSFOn = true;
        public static Boolean fgMultiChartRTOn = true;
        public static Boolean fgMultiChartMaskViewOn = false;
        public static Boolean fgMultiChartColorOn = true;

#if (SERVER_INCLUDED)
        // SFProg Status Topic name define
        private const string STAT_TOPIC = "stat";
        // SFProg Status Payload define
        private const string STAT_PROGON_START = "{\"ProgOn\":\"Start\"}";
        private const string STAT_PROGON_STOP = "{\"ProgOn\":\"Stop\"}";
        private const string STAT_PROGRUN_START = "{\"ProgRun\":\"Start\"}";
        private const string STAT_PROGRUN_STOP = "{\"ProgRun\":\"Stop\"}";
        private const string STAT_BACKUPREQ_START = "{\"BackupReq\":\"Start\"}";
        private const string STAT_BACKUPREQ_STOP = "{\"BackupReq\":\"Stop\"}";
        private const string STAT_STATUSREQ_START = "{\"StatusReq\":\"Start\"}";
        private const string STAT_STATUSREQ_STOP = "{\"StatusReq\":\"Stop\"}";
#else
        // SFProg Status Topic name define
        private const string STAT_TOPIC = "";
        // SFProg Status Payload define
        private const string STAT_PROGON_START = "";
        private const string STAT_PROGON_STOP = "";
        private const string STAT_PROGRUN_START = "";
        private const string STAT_PROGRUN_STOP = "";
        private const string STAT_BACKUPREQ_START = "";
        private const string STAT_BACKUPREQ_STOP = "";
        private const string STAT_STATUSREQ_START = "";
        private const string STAT_STATUSREQ_STOP = "";
#endif // SERVER_INCLUDED       

        public class GraphTimeStep
        {
            private int day;
            private int hour;

            public GraphTimeStep(int d)
            {
                day = d;
                hour = 0;
            }

            public GraphTimeStep(int d, int h)
            {
                day = d;
                hour = h;
            }

            public int Hour
            {
                get
                {
                    return hour;
                }
                set
                {
                    if ((value >= 0) && (value <= 24))
                    {
                        hour = value;
                    }
                }
            }
            public int Day
            {
                get
                {
                    return day;
                }
                set
                {
                    if ((value >= 0) && (value <= 365))
                    {
                        day = value;
                    }
                }
            }
        }

        public GraphTimeStep valueTimeStep;

        public struct paraSapFlow
        {
            public float a;
            public float b;
            public float c;
            public float Tm;

            public paraSapFlow(float a, float b, float c, float Tm)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.Tm = Tm;
            }
        }

        // 구형센서
        //public paraSapFlow Default_Const_SFParameter = new paraSapFlow(4.2f, 1.3f, 0.000522f, 1.8f);
        // 신형센서(18/01/08 변경)
        //public static paraSapFlow Default_Const_SFParameter = new paraSapFlow(3.49f, 1.89f, 0.000396f, 1.8f);
        // 신규 튜닝(18/03/26 변경)
        //public static paraSapFlow Default_Const_SFParameter = new paraSapFlow(5.16031f, 1.01271f, 0.000396f, 1.8f);
        // 신규 튜닝(18/06/21 변경, v1.150이후)
        //public static paraSapFlow Default_Const_SFParameter = new paraSapFlow(2.9749f, 1.8121f, 0.000522f, 2.1041f);
        // 신규 튜닝(18/06/25 변경, v1.151이후)
        public static paraSapFlow Default_Const_SFParameter = new paraSapFlow(3.5391f, 1.4672f, 0.000522f, 1.8265f);


        public float[,] Default_SFOffsetParameter = new float[SFModuleLength, SFChannelLength]; // CH1 ~ CH4 Default Offset Parameter
        public paraSapFlow[] Default_SFabcParameter = new paraSapFlow[SFModuleLength]; // a,b,c Parameter(Tm is not used)

        public class setupParameter
        {
            public bool[] ModuleEnable = new bool[SFModuleLength];
            public bool[] ModuleOn = new bool[SFModuleLength];

            public paraSapFlow[,] Para = new paraSapFlow[SFModuleLength, SFChannelLength];
            public bool[,] ChannelEnable = new bool[SFModuleLength, SFChannelLength];

            public bool ValveControlEnable;
            public bool ValveControlOn;

            public bool MultiModuleOn;

            public bool RestartingOn;

        }

        public static setupParameter SystemParameter = new setupParameter();

        private void createIniFile(string filename)
        {
            string strText;

            updateDisplayBox("Create INI file.");
            StreamWriter sw = new StreamWriter(filename);

            sw.Write("Real_SF_Test Parameter" + System.DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss") + Environment.NewLine);

            int timeSeconds = Convert.ToInt32(BuildVersion) * 2;
            int timeHour = timeSeconds / 3600;
            int timeMin = (timeSeconds - (timeHour * 3600)) / 60;
            int timeSec = (timeSeconds - (timeHour * 3600) - (timeMin * 60));
            DateTime BuildVersionDate = new DateTime(2000, 1, 1, timeHour, timeMin, timeSec);

            strText = String.Format("{0} v{1}({2} {3}, r{4})", ProgramName, ProgramVersion,
                          BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);
            //           this.Text = String.Format("{0} v{1}({2}, r{4})", ProgramName, ProgramVersion,
            //                       BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);

            sw.Write("   created by " + strText + Environment.NewLine);
            sw.Write("---------------------------------------------------------------------------------------------" + Environment.NewLine);
            sw.Write("[Module Number]: [ON|OFF], [CH1 Para.], [CH2 Para.], [CH3  Para.], [CH4 Para.], [a], [b], [c]" + Environment.NewLine);
            sw.Write("---------------------------------------------------------------------------------------------" + Environment.NewLine);

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                Default_SFabcParameter[mo].a = Default_Const_SFParameter.a;
                Default_SFabcParameter[mo].b = Default_Const_SFParameter.b;
                Default_SFabcParameter[mo].c = Default_Const_SFParameter.c;

                string strDataVC = String.Format("Module {0}: ON, {1}, {1}, {1}, {1}, {2}, {3}, {4}",
                        (mo + 1).ToString(),
                        Math.Round(Default_Const_SFParameter.Tm / Default_Const_SFParameter.c).ToString(),
                        Default_SFabcParameter[mo].a.ToString(),
                        Default_SFabcParameter[mo].b.ToString(),
                        Default_SFabcParameter[mo].c.ToString()
                        );

                if (mo < MODULE_ENABED_NUMBER)
                {
                    // Enabled
                    sw.Write(strDataVC + Environment.NewLine);
                }
                else
                {
                    // Disabled
                    sw.Write("//" + strDataVC + Environment.NewLine);
                }
            }

            // "//ValveControl: ON"
            string strData = String.Format("//ValveControl: ON");
            sw.Write(strData + Environment.NewLine);

            sw.Close();
        }

        private void saveIniFile(string filename)
        {
            string strText;

            updateDisplayBox("Save INI file.");
            StreamWriter sw = new StreamWriter(filename);

            sw.Write("Real_SF_Test Parameter" + System.DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss") + Environment.NewLine);

            int timeSeconds = Convert.ToInt32(BuildVersion) * 2;
            int timeHour = timeSeconds / 3600;
            int timeMin = (timeSeconds - (timeHour * 3600)) / 60;
            int timeSec = (timeSeconds - (timeHour * 3600) - (timeMin * 60));
            DateTime BuildVersionDate = new DateTime(2000, 1, 1, timeHour, timeMin, timeSec);

            strText = String.Format("{0} v{1}({2} {3}, r{4})", ProgramName, ProgramVersion,
                          BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);
            //           this.Text = String.Format("{0} v{1}({2}, r{4})", ProgramName, ProgramVersion,
            //                       BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);

            sw.Write("   generated by " + strText + Environment.NewLine);

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo])
                {
                    sw.Write(String.Format("Module {0}: ON", (mo + 1).ToString()));
                }
                else
                {
                    sw.Write(String.Format("//Module {0}: ON", (mo + 1).ToString()));
                }

                // Add Channel Parameter
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.Para[mo, ch].c != 0)
                    {
                        sw.Write("," + Math.Round(SystemParameter.Para[mo, ch].Tm / SystemParameter.Para[mo, ch].c).ToString());
                    }
                    else
                    {
                        sw.Write("," + Math.Round(Default_Const_SFParameter.Tm / Default_Const_SFParameter.c).ToString());
                    }
                }

                // Add a_para, b_para, c_para
                sw.Write("," + SystemParameter.Para[mo, 0].a.ToString());
                sw.Write("," + SystemParameter.Para[mo, 0].b.ToString());
                sw.Write("," + SystemParameter.Para[mo, 0].c.ToString());

                sw.Write(Environment.NewLine);
            }

            if (fgValveControlActivated == true)     // 양액제어 활성화 유무 확인
            {
                string strData = String.Format("ValveControl: ON");
                sw.Write(strData + Environment.NewLine);
            }
            else
            {
                string strData = String.Format("//ValveControl: ON");
                sw.Write(strData + Environment.NewLine);
            }
            sw.Close();
        }

        private void loadIniFile(string filename)
        {
            Boolean fgEnabledModuleExist = false;

            updateDisplayBox("Load INI file.");

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // 초기 abc값 로드 from const value
                SystemParameter.ModuleEnable[mo] = false;
                Default_SFabcParameter[mo].a = Default_Const_SFParameter.a;
                Default_SFabcParameter[mo].b = Default_Const_SFParameter.b;
                Default_SFabcParameter[mo].c = Default_Const_SFParameter.c;

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // 초기 Offset값은 초기 파라메터를 참조하여 계산(Tm=1.8, c=0.000522)
                    Default_SFOffsetParameter[mo, ch] = Convert.ToSingle(Math.Round(Default_Const_SFParameter.Tm / Default_Const_SFParameter.c));

                }
            }

            StreamReader sr = new StreamReader(filename);
            string strLog;
            if (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                if (!strLog.StartsWith("Real_SF_Test Parameter"))
                {
                    SystemParameter.ModuleEnable[0] = true;
                    sr.Close();
                    return;
                }
            }

            while (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                if (strLog.StartsWith("Module "))     // 모듈 확인
                {
                    int mo = 0;
                    // "Module 1: ON,4545,4545,4545,4545,3.49,1.89,0.000396"
                    // "Module 1" , " ON,4545,4545,4545,4545,3.49,1.89,0.000396"
                    string[] spltBigStrArray = strLog.Split(':');  // ':'를 분리기호로 사용
                    if (spltBigStrArray.Length == 2)
                    {
                        try
                        {
                            mo = Convert.ToInt32(spltBigStrArray[0].Substring(7).ToString()) - 1;
                            if (mo >= SFModuleLength)
                            {
                                break;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        mo = 0;
                        break;
                    }

                    if (spltBigStrArray[1].Substring(1, 2) == "ON")
                    {
                        fgEnabledModuleExist = true;
                        SystemParameter.ModuleEnable[mo] = true;
                        updateListBox(String.Format("Module #{0} ON", (mo + 1).ToString()));


                        string[] spltStrArray = strLog.Split(',');  // ,를 분리기호로 사용
                                                                    // [0]Module On Off, [1]CH1 offset, [2]CH2 offset, [3]CH3 offset, [4]CH4 Offset, [5] a, [6] b, [7] c
                        if (spltStrArray.Length == 5) // 1~ 4 CH Offset Value detected, 해당 채널의 옵셋설정값을 업데이트 , (~ v1.003이전) a,b,c가 없는 경우임
                        {
                            for (int ch = 0; ch < 4; ch++)
                            {
                                try
                                {
                                    Default_SFOffsetParameter[mo, ch] = Convert.ToSingle(spltStrArray[ch + 1]); // Channel x Offset Value
                                }
                                catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }
                            }
                        }
                        else if (spltStrArray.Length == 8) // 1~ 4 CH Offset Value detected, 해당 채널의 옵셋설정값을 업데이트 , (v1.004이후) a,b,c가 존재
                        {
                            try
                            {
                                Default_SFabcParameter[mo].a = Convert.ToSingle(spltStrArray[5]); // a parameter
                                Default_SFabcParameter[mo].b = Convert.ToSingle(spltStrArray[6]); // b parameter
                                Default_SFabcParameter[mo].c = Convert.ToSingle(spltStrArray[7]); // c parameter

                                for (int ch = 0; ch < 4; ch++)
                                {

                                    Default_SFOffsetParameter[mo, ch] = Convert.ToSingle(spltStrArray[ch + 1]); // Channel x Offset Value
                                }
                            }
                            catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }

                        }


                    }
                }
                else if (strLog.StartsWith("ValveControl"))     // 양액제어 활성화 유무 확인
                {
                    string[] spltBigStrArray = strLog.Split(':');  // ':'를 분리기호로 사용
                    if (spltBigStrArray.Length != 2)
                    {
                        break;
                    }

                    if (spltBigStrArray[1].Substring(1, 2) == "ON")
                    {
                        // 양액제어 ON                       
                        fgValveControlActivated = true;
                        updateDisplayBox(String.Format("Valve Control Activated"));
                    }
                }
            }
            if (fgEnabledModuleExist == false)
            {
                // 활성화된 모듈이 0인경우에는 모듈1번을 켬
                SystemParameter.ModuleEnable[0] = true;
            }

            sr.Close();
        }

        private void initializeSystemParameter()
        {
            string DirectoryPath = Application.StartupPath + "\\";
            string fs_system_ini = DirectoryPath + "Real_SF_Test.ini";

            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(DirectoryPath);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fs_system_ini);

            if (fileInfo.Exists == false)
            {
                // Case 1: 파일이 없는경우, 신규 작성
                createIniFile(fs_system_ini);

                // 17/12/13 파일이 없는경우 윈도우 초기위치를 지움
                if (Properties.Settings.Default.GraphParameterSaved)
                {
                    Properties.Settings.Default.GraphParameterSaved = false;
                    updateDisplayBox("Clear Windows Graph Location");
                }
            }
            else
            {
                // Case 2: 파일이 있는경우
                StreamReader sr = new StreamReader(fs_system_ini);
                string strLog;
                if (sr.Peek() > -1)
                {
                    strLog = sr.ReadLine();
                    sr.Close();
                    if (!strLog.StartsWith("Real_SF_Test Parameter"))
                    {
                        // Case 2-1: 파일내에 String이 존재하고 Name이 매칭하지 않는 경우, 신규 작성
                        createIniFile(fs_system_ini);
                    }
                }
                else
                {
                    // Case 2-2: 빈 파일인 경우, 신규 작성
                    sr.Close();
                    createIniFile(fs_system_ini);
                }

            }

            // Load INI file
            loadIniFile(fs_system_ini);


            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    SystemParameter.Para[mo, ch].a = Default_SFabcParameter[mo].a;
                    SystemParameter.Para[mo, ch].b = Default_SFabcParameter[mo].b;
                    SystemParameter.Para[mo, ch].c = Default_SFabcParameter[mo].c;
                    SystemParameter.Para[mo, ch].Tm = Default_SFOffsetParameter[mo, ch] * SystemParameter.Para[mo, ch].c;

                    // Setup Each Channel
                    if ((SystemParameter.ModuleEnable[mo] == true) && (ch < 4))
                    {
                        SystemParameter.ChannelEnable[mo, ch] = true;
                    }
                    else
                    {
                        SystemParameter.ChannelEnable[mo, ch] = false;
                    }
                }
            }

            SystemParameter.ValveControlEnable = false;
            SystemParameter.ValveControlOn = false;
            SystemParameter.MultiModuleOn = false;
            SystemParameter.RestartingOn = false;

            updateMainSelection();
        }

        public const int VALVE_CONTROL_MAX_VALUE = 1500;

        public class vcParameter
        {
            public bool[,] Enabled = new bool[SFModuleLength, SFChannelLength];
            public float[,] Max = new float[SFModuleLength, SFChannelLength];
            public float[,] Min = new float[SFModuleLength, SFChannelLength];
            public int[,] Constrain = new int[SFModuleLength, SFChannelLength];
            public int[,] Ratio = new int[SFModuleLength, SFChannelLength];
            public int[,] CurrentSFValue = new int[SFModuleLength, SFChannelLength];
            public double[,] CurrentTime = new double[SFModuleLength, SFChannelLength];
            public int EventJouleValue;
            public int EventCount;
            public long IntegratedValue;
            public long totalValue;
            public DateTime StartTime;
            public DateTime EndTime;
            public TimeSpan MaxTime;
            public TimeSpan MinTime;
            public TimeSpan MaxTimeCount;
            public TimeSpan MinTimeCount;
            public TimeSpan ElapsedTime;
            public double EventExecutedTime;
            public bool EventActivated;
            public bool EventStarted;
            public bool StartEndEnabled;
            public bool MaxMinEnabled;
        }

        public static vcParameter VCParameter = new vcParameter();

        private void initializeVCParameter()
        {
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    VCParameter.Enabled[mo, ch] = false;

                    // if (mo == 0 && ch == 0) VCParameter.Enabled[mo, ch] = true;

                    if (VCParameter.Max[mo, ch] == 0) VCParameter.Max[mo, ch] = 1.8f;
                    if (VCParameter.Min[mo, ch] == 0) VCParameter.Min[mo, ch] = 0;
                    if (VCParameter.Constrain[mo, ch] == 0) VCParameter.Constrain[mo, ch] = 500;
                    if (VCParameter.Ratio[mo, ch] == 0) VCParameter.Ratio[mo, ch] = 100;

                }
            }
            if (VCParameter.EventJouleValue == 0) VCParameter.EventJouleValue = 150;
            if (VCParameter.IntegratedValue == 0) VCParameter.IntegratedValue = 0;
            if (VCParameter.EventExecutedTime == 0) VCParameter.EventExecutedTime = 0;

            if (TimeSpan.Compare(VCParameter.StartTime.TimeOfDay, TimeSpan.Zero) == 0) VCParameter.StartTime = new DateTime(2017, 1, 1, 6, 0, 0);
            if (TimeSpan.Compare(VCParameter.EndTime.TimeOfDay, TimeSpan.Zero) == 0) VCParameter.EndTime = new DateTime(2017, 1, 1, 18, 0, 0);
            if (TimeSpan.Compare(VCParameter.MaxTime, TimeSpan.Zero) == 0) VCParameter.MaxTime = new TimeSpan(2, 0, 0);
            if (TimeSpan.Compare(VCParameter.MinTime, TimeSpan.Zero) == 0) VCParameter.MinTime = new TimeSpan(0, 10, 0);

            VCParameter.StartEndEnabled = true;
            VCParameter.MaxMinEnabled = true;

            clearValveControlCount();
        }

        /// <summary>
        /// 시리얼포트 컨트롤 객체
        /// </summary>
        private SerialPort Port
        {
            get
            {
                if (_Port == null)
                {
                    _Port = new SerialPort();
                    _Port.PortName = "COM1";
                    _Port.BaudRate = 9600;
                    _Port.DataBits = 8;
                    _Port.Parity = Parity.None;
                    _Port.Handshake = Handshake.None;
                    _Port.StopBits = StopBits.One;
                    _Port.DataReceived += Port_DataReceived;
                }
                return _Port;
            }
        }

        public SF_Test()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
        }

        /// <summary>
        /// Delay 함수 MS
        /// </summary>
        /// <param name="MS">(단위 : MS)
        /// 
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private static DateTime DelayLock(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                //    System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private void clearModuleMinMaxValue(int mo)
        {
            for (int ch = 0; ch < SFChannelLength; ch++)
            {
                valueSFMin[mo, ch] = 0xffff;
                valueSFMax[mo, ch] = 0;

                valueRTempMin[mo, ch] = 0xffff;
                valueRTempMax[mo, ch] = 0;
            }

            valueTemperatureMin[mo] = 0xffff;
            valueTemperatureMax[mo] = 0;

            valueHumidityMin[mo] = 0xffff;
            valueHumidityMax[mo] = 0;
        }

        private void initializeVariables()
        {
            // 각종 파라메터 초기화
            for (uint mo = 0; mo < SFModuleLength; mo++)
            {
                //                mTemperature[mo] = 0x10 + mo;
                //                mHumidity[mo] = 0x20 + mo;
                //                mSoilMoisture[mo] = 0x30 + mo;

                // mPara_a[mo] = 4.2f;
                // mPara_b[mo] = 1.3f;
                // mPara_c[mo] = 0.00052f;
                // mPara_Tm[mo] = 1.8f;

                clearModuleMinMaxValue((int)mo);
            }

            btStartAction.Enabled = false;
            btStopAction.Enabled = false;
            btCalibration.Enabled = false;


        }

        private void initializefrmSfModule()
        {
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // Enable된 창만 활성화
                if (SystemParameter.ModuleEnable[mo])
                {
                    m_frmSfModule[mo] = new frmSfModule(this, mo);
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        CurrentChartPointCount[mo, ch] = 0;
                    }
                }
            }
        }

        private void graphUpdateMultichart()
        {
            if (SystemParameter.MultiModuleOn == true)
            {
                Chart chart = null;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                if (SystemParameter.ChannelEnable[mo, ch] == false) continue;
                                try
                                {
                                    chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                                    if (chart.Series["SF"].Points.Count > 0)
                                    {
                                        // 180409
                                        if ((fgGraphMin[mo, ch] == true) && (fgGraphMax[mo, ch] == true))
                                        {

                                            // Set Min, Max
                                            chart.ChartAreas[0].AxisY.Minimum = GraphMin[mo, ch];
                                            chart.ChartAreas[0].AxisY.Maximum = GraphMax[mo, ch];
                                        }
                                    }
                                }
                                catch { }

                            }
                        }
                    }
                }
            }
        }

        public void initializefrmSfMultiModules()
        {
            if (SystemParameter.MultiModuleOn == false)
            {
                m_frmSfMultiModules = new frmSfMultiModules(this);
                m_frmSfMultiModules.Visible = true;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        CurrentMultiChartPointCount[mo, ch] = 0;
                    }
                }
            }
            else
            {
                graphUpdateMultichart();
            }
        }


        private TimeSpan[] listBackupTermComobBox =
        {
            new TimeSpan(0,23,0,0), // 00:00 ~ today
            new TimeSpan(1,0,0,0), // -1d ~ today
            new TimeSpan(2,0,0,0), // -2d ~ today
            new TimeSpan(3,0,0,0), // -3d ~ today
            new TimeSpan(4,0,0,0), // -4d ~ today
            new TimeSpan(5,0,0,0), // -5d ~ today
            new TimeSpan(6,0,0,0), // -6d ~ today
            new TimeSpan(7,0,0,0), // -7d ~ today
            new TimeSpan(8,0,0,0), // -8d ~ today
            new TimeSpan(9,0,0,0), // -9d ~ today
            new TimeSpan(10,0,0,0), // -10d ~ today
            new TimeSpan(11,0,0,0), // -11d ~ today
            new TimeSpan(12,0,0,0), // -12d ~ today
            new TimeSpan(13,0,0,0), // -13d ~ today
            new TimeSpan(14,0,0,0), // -14d ~ today
            new TimeSpan(30,0,0,0), // -30d ~ today
            new TimeSpan(0,0,0,0), // Full scale if TimeSpan = 0
        };

        private void initializeBackupTermComboBox()
        {
            cbBackupTerm.Items.Clear();
            foreach (TimeSpan timeScale in listBackupTermComobBox)
            {
                string labelScale = "";
                if (timeScale.TotalHours == 0)
                {
                    // Full Scale
                    labelScale = "Full";
                }
                else if (timeScale.TotalHours < 24)
                {
                    labelScale = "Today";
                }
                else
                {
                    int TotalDays = (int)timeScale.TotalDays;

                    if ((TotalDays % 30) == 0)  // month
                    {
                        labelScale = "-" + (TotalDays / 30).ToString() + "month~";
                    }
                    else if ((TotalDays % 7) == 0)  // weeks
                    {
                        labelScale = "-" + (TotalDays / 7).ToString() + "week~";
                    }
                    else
                    {
                        labelScale = "-" + TotalDays.ToString() + "day~";
                    }
                }
                cbBackupTerm.Items.Add(labelScale);
            }
            //cbBackupTerm.SelectedIndex = 0;
            cbBackupTerm.SelectedItem = "Full";
        }


        // 창위채 초기화, fgInitial= true : 초기설정, fgInitial=false: 윈도우저장값 재사용
        private void relocatefrmSfModule(Boolean fgInitial)
        {
            Size defaultOffsetPosition = new Size(60, 60);
            Point StartPosition = new Point(0, 0) + new Size(defaultOffsetPosition.Width / 2, defaultOffsetPosition.Height / 2);

            Size DisplaySize = Screen.PrimaryScreen.WorkingArea.Size - defaultOffsetPosition;
            Size MainModuleSize = this.Size;
            Size SubModuleSize = new Size(0, 0);
            Size WinModuleSize = new Size(0, 0);

            int cntFrame = 0;

            // testing windows graph para.
            if (fgInitial == false)
            {
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if (SystemParameter.ModuleOn[mo])
                        {
                            m_frmSfModule[mo].Text = "SF Module # " + (mo + 1).ToString();
                            m_frmSfModule[mo].Visible = true;

                            m_frmSfModule[mo].StartPosition = FormStartPosition.Manual;
                            m_frmSfModule[mo].Location = GraphLocation[mo];
                            m_frmSfModule[mo].Size = GraphSize[mo];

                            m_frmSfModule[mo].LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);

                            // Min, Max 설정값 반영

                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                Boolean fgGraph;
                                float GraphValue;

                                // Update Min value
                                fgGraph = fgGraphMin[mo, ch];
                                GraphValue = GraphMin[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY.Minimum = GraphValue;
                                    }
                                    catch { }
                                }

                                // Update Max value
                                fgGraph = fgGraphMax[mo, ch];
                                GraphValue = GraphMax[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY.Maximum = GraphValue;
                                    }
                                    catch { }
                                }

                                // Update Min2 value
                                fgGraph = fgGraphMin2[mo, ch];
                                GraphValue = GraphMin2[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY2.Minimum = GraphValue;
                                    }
                                    catch { }
                                }

                                // Update Max value
                                fgGraph = fgGraphMax2[mo, ch];
                                GraphValue = GraphMax2[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY2.Maximum = GraphValue;
                                    }
                                    catch { }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                // Window Location, Min, Max 초기화
                if (fgGraphParameterSaved == false)
                {
                    createGraphDefaultParameter();
                    //saveGraphDefaultParameter();
                }
                else
                {
                    loadGraphDefaultParameter();
                }

                // Count Windows
                int count = 0;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if (SystemParameter.ModuleOn[mo])
                        {
                            count++;
                        }
                    }
                }

                Point ModulePosition = StartPosition;

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (cntFrame >= 8) continue;

                    // Enable된 창만 활성화
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if (SystemParameter.ModuleOn[mo])
                        {
                            Delay(100);

                            m_frmSfModule[mo].Text = "SF Module # " + (mo + 1).ToString();
                            m_frmSfModule[mo].Visible = true;

                            m_frmSfModule[mo].StartPosition = FormStartPosition.Manual;
                            m_frmSfModule[mo].Location = ModulePosition;

                            SubModuleSize = new Size((DisplaySize.Width / 4), (DisplaySize.Height / 2));

                            if (count == 1)    // 열린 모듈수가 1인경우 Width, Height 를 두배로 늘림
                            {
                                SubModuleSize = new Size(((DisplaySize.Width / 2)), (DisplaySize.Height / 2));
                            }
                            else if (count == 2)    // 열린 모듈수가 2인경우 Width를 두배로 늘림
                            {
                                SubModuleSize = new Size(((DisplaySize.Width / 2)), (DisplaySize.Height / 2));
                            }
                            else if (count <= 4)    // 열린 모듈수가 4인경우 Width를 조금 늘림
                            {
                                SubModuleSize = new Size(((DisplaySize.Width / 3)), (DisplaySize.Height / 2));
                            }
                            WinModuleSize = SubModuleSize + new Size(14, 8);

                            // 17/12/13 윈도우 위치 저장
                            SF_Test.GraphLocation[mo] = ModulePosition;
                            SF_Test.GraphSize[mo] = SubModuleSize;
                            m_frmSfModule[mo].Size = WinModuleSize;

                            if ((cntFrame % 4) == 3)
                            {
                                ModulePosition.X = StartPosition.X + SubModuleSize.Width * ((cntFrame + 1) / 4);
                                ModulePosition.Y = StartPosition.Y;
                            }
                            else
                            {
                                ModulePosition.Y += SubModuleSize.Height;
                            }
                            cntFrame++;

                            m_frmSfModule[mo].LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);

                            // Min, Max 설정값 반영

                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                Boolean fgGraph;
                                float GraphValue;

                                // Update Min value
                                fgGraph = fgGraphMin[mo, ch];
                                GraphValue = GraphMin[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY.Minimum = GraphValue;
                                    }
                                    catch { }
                                }

                                // Update Max value
                                fgGraph = fgGraphMax[mo, ch];
                                GraphValue = GraphMax[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY.Maximum = GraphValue;
                                    }
                                    catch { }
                                }

                                // Update Min2 value
                                fgGraph = fgGraphMin2[mo, ch];
                                GraphValue = GraphMin2[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY2.Minimum = GraphValue;
                                    }
                                    catch { }
                                }

                                // Update Max value
                                fgGraph = fgGraphMax2[mo, ch];
                                GraphValue = GraphMax2[mo, ch];
                                if ((fgGraph) && (!float.IsNaN(GraphValue)))
                                {
                                    try
                                    {
                                        m_frmSfModule[mo].ChartMultiCH[ch].chart1.ChartAreas[0].AxisY2.Maximum = GraphValue;
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }

            // 밸브컨트롤용 데이터 업데이트(17/08/10)
            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
            {

                m_frmValveControl.Focus();
                //     m_frmValveControl.StartPosition = FormStartPosition.Manual;
                //     m_frmValveControl.Location = new Point(0, 0);
            }

            this.Focus();
            //            this.StartPosition = FormStartPosition.Manual;
            //this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void refreshfrmSfModule()
        {
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // Enable된 창만 Close
                if (SystemParameter.ModuleEnable[mo])
                {
                    if (SystemParameter.ModuleOn[mo])
                    {
                        // 열린 그래픽창을 닫음
                        m_frmSfModule[mo].Close();
                        updateDisplayBox(String.Format("Close Module {0} Window", (mo + 1).ToString()));

                        // 그래픽창 신규 오픈, 열려있던 창을 기준으로 다시 Open 이외에는 Close(18/03/19)
                        m_frmSfModule[mo] = new frmSfModule(this, mo);
                        updateDisplayBox(String.Format("Open Module {0} Window", (mo + 1).ToString()));
                        m_frmSfModule[mo].Text = "SF Module # " + (mo + 1).ToString();
                        m_frmSfModule[mo].Visible = true;

                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            CurrentChartPointCount[mo, ch] = 0;
                        }
                        UpdateChartWithRawData(mo);
                        updateGraphOnly();
                    }
                }
            }


        }

        private void refreshfrmMultiModules()
        {
            // Multimodule에 대한 데이터를 새로 업데이트함
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    CurrentMultiChartPointCount[mo, ch] = 0;
                }
            }

            if (SystemParameter.MultiModuleOn)
            {
                // 열린 그래픽창을 닫음
                m_frmSfMultiModules.Close();
                updateDisplayBox(String.Format("Close Multi Module Window"));
            }

            initializefrmSfMultiModules();
            UpdateMultiChartWithRawData();
        }

        private void createGraphDefaultParameter()
        {
            fgGraphParameterSaved = true;

            // Setup Graph Min, Max Value
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // flag Min, Max
                    fgGraphMin[mo, ch] = true;
                    fgGraphMax[mo, ch] = false;

                    // initialize Min, Max value
                    GraphMin[mo, ch] = 0;
                    GraphMax[mo, ch] = float.NaN;

                    // flag Min2, Max2
                    fgGraphMin2[mo, ch] = true;
                    fgGraphMax2[mo, ch] = false;

                    // initialize Min2, Max2 value
                    GraphMin2[mo, ch] = 0;
                    GraphMax2[mo, ch] = float.NaN;
                }
            }

            // Setup Windows Location
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // Windows Default Location
                Point currentLocation = new Point(20 + mo * 20, 20 + mo * 20);
                Size currentSize = new Size(528, 320);
                GraphLocation[mo] = currentLocation;
                GraphSize[mo] = currentSize;
            }

        }

        private void loadGraphDefaultParameter()
        {
            // load from Settings

            if (Properties.Settings.Default.GraphParameterSaved)
            {
                // Load Graph Min, Max
                string strFgGraphMin = Properties.Settings.Default.fgGraphMin;
                string strFgGraphMax = Properties.Settings.Default.fgGraphMax;
                string strGraphMin = Properties.Settings.Default.GraphMin;
                string strGraphMax = Properties.Settings.Default.GraphMax;

                // Load Graph Min2, Max2
                string strFgGraphMin2 = Properties.Settings.Default.fgGraphMin2;
                string strFgGraphMax2 = Properties.Settings.Default.fgGraphMax2;
                string strGraphMin2 = Properties.Settings.Default.GraphMin2;
                string strGraphMax2 = Properties.Settings.Default.GraphMax2;

                string[] subFgGraphMin = strFgGraphMin.Split(',');
                string[] subFgGraphMax = strFgGraphMax.Split(',');
                string[] subGraphMin = strGraphMin.Split(',');
                string[] subGraphMax = strGraphMax.Split(',');

                if ((subFgGraphMin[0] == "fgGraphMin") && (subFgGraphMax[0] == "fgGraphMax") && (subGraphMin[0] == "GraphMin") && (subGraphMax[0] == "GraphMax"))
                {
                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            fgGraphMin[mo, ch] = Convert.ToBoolean(subFgGraphMin[1 + mo * 4 + ch]);
                            fgGraphMax[mo, ch] = Convert.ToBoolean(subFgGraphMax[1 + mo * 4 + ch]);
                            GraphMin[mo, ch] = Convert.ToSingle(subGraphMin[1 + mo * 4 + ch]);
                            GraphMax[mo, ch] = Convert.ToSingle(subGraphMax[1 + mo * 4 + ch]);
                        }
                    }
                }

                string[] subFgGraphMin2 = strFgGraphMin2.Split(',');
                string[] subFgGraphMax2 = strFgGraphMax2.Split(',');
                string[] subGraphMin2 = strGraphMin2.Split(',');
                string[] subGraphMax2 = strGraphMax2.Split(',');

                if ((subFgGraphMin2[0] == "fgGraphMin2") && (subFgGraphMax2[0] == "fgGraphMax2") && (subGraphMin2[0] == "GraphMin2") && (subGraphMax2[0] == "GraphMax2"))
                {
                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            fgGraphMin2[mo, ch] = Convert.ToBoolean(subFgGraphMin2[1 + mo * 4 + ch]);
                            fgGraphMax2[mo, ch] = Convert.ToBoolean(subFgGraphMax2[1 + mo * 4 + ch]);
                            GraphMin2[mo, ch] = Convert.ToSingle(subGraphMin2[1 + mo * 4 + ch]);
                            GraphMax2[mo, ch] = Convert.ToSingle(subGraphMax2[1 + mo * 4 + ch]);
                        }
                    }
                }

                // Load Graph Location, Size
                string strGraphLocation_x = Properties.Settings.Default.GraphWindowLocation_x;
                string strGraphSize_x = Properties.Settings.Default.GraphWindowSize_x;
                string strGraphLocation_y = Properties.Settings.Default.GraphWindowLocation_y;
                string strGraphSize_y = Properties.Settings.Default.GraphWindowSize_y;

                string[] subGraphLocation_x = strGraphLocation_x.Split(',');
                string[] subGraphSize_x = strGraphSize_x.Split(',');
                string[] subGraphLocation_y = strGraphLocation_y.Split(',');
                string[] subGraphSize_y = strGraphSize_y.Split(',');

                if ((subGraphLocation_x[0] == "GraphLocation_x") && (subGraphLocation_y[0] == "GraphLocation_y"))
                {
                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        GraphLocation[mo] = new Point(Convert.ToInt32(subGraphLocation_x[1 + mo]), Convert.ToInt32(subGraphLocation_y[1 + mo]));
                    }
                }

                if ((subGraphSize_x[0] == "GraphSize_x") && (subGraphSize_y[0] == "GraphSize_y"))
                {
                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        GraphSize[mo] = new Size(Convert.ToInt32(subGraphSize_x[1 + mo]), Convert.ToInt32(subGraphSize_y[1 + mo]));
                    }
                }
            }
        }

        private void saveGraphDefaultParameter()
        {
            // Update Settings for Graph Min, Max
            StringBuilder strFgGraphMin = new StringBuilder();
            StringBuilder strFgGraphMax = new StringBuilder();
            StringBuilder strGraphMin = new StringBuilder();
            StringBuilder strGraphMax = new StringBuilder();

            StringBuilder strFgGraphMin2 = new StringBuilder();
            StringBuilder strFgGraphMax2 = new StringBuilder();
            StringBuilder strGraphMin2 = new StringBuilder();
            StringBuilder strGraphMax2 = new StringBuilder();

            strFgGraphMin.Clear();
            strFgGraphMax.Clear();
            strGraphMin.Clear();
            strGraphMax.Clear();

            strFgGraphMin2.Clear();
            strFgGraphMax2.Clear();
            strGraphMin2.Clear();
            strGraphMax2.Clear();

            strFgGraphMin.Append("fgGraphMin");
            strFgGraphMax.Append("fgGraphMax");
            strGraphMin.Append("GraphMin");
            strGraphMax.Append("GraphMax");

            strFgGraphMin2.Append("fgGraphMin2");
            strFgGraphMax2.Append("fgGraphMax2");
            strGraphMin2.Append("GraphMin2");
            strGraphMax2.Append("GraphMax2");

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    strFgGraphMin.Append(",");
                    strFgGraphMin.Append(fgGraphMin[mo, ch].ToString());
                    strFgGraphMax.Append(",");
                    strFgGraphMax.Append(fgGraphMax[mo, ch].ToString());

                    strGraphMin.Append(",");
                    strGraphMin.Append(GraphMin[mo, ch].ToString());
                    strGraphMax.Append(",");
                    strGraphMax.Append(GraphMax[mo, ch].ToString());

                    strFgGraphMin2.Append(",");
                    strFgGraphMin2.Append(fgGraphMin2[mo, ch].ToString());
                    strFgGraphMax2.Append(",");
                    strFgGraphMax2.Append(fgGraphMax2[mo, ch].ToString());

                    strGraphMin2.Append(",");
                    strGraphMin2.Append(GraphMin2[mo, ch].ToString());
                    strGraphMax2.Append(",");
                    strGraphMax2.Append(GraphMax2[mo, ch].ToString());

                }
            }

            Properties.Settings.Default.fgGraphMin = strFgGraphMin.ToString();
            Properties.Settings.Default.fgGraphMax = strFgGraphMax.ToString();
            Properties.Settings.Default.GraphMin = strGraphMin.ToString();
            Properties.Settings.Default.GraphMax = strGraphMax.ToString();

            Properties.Settings.Default.fgGraphMin2 = strFgGraphMin2.ToString();
            Properties.Settings.Default.fgGraphMax2 = strFgGraphMax2.ToString();
            Properties.Settings.Default.GraphMin2 = strGraphMin2.ToString();
            Properties.Settings.Default.GraphMax2 = strGraphMax2.ToString();

            // Update Settings for Graph Location, Size
            StringBuilder strGraphLocation_x = new StringBuilder();
            StringBuilder strGraphSize_x = new StringBuilder();
            StringBuilder strGraphLocation_y = new StringBuilder();
            StringBuilder strGraphSize_y = new StringBuilder();

            strGraphLocation_x.Clear();
            strGraphSize_x.Clear();
            strGraphLocation_y.Clear();
            strGraphSize_y.Clear();

            strGraphLocation_x.Append("GraphLocation_x");
            strGraphSize_x.Append("GraphSize_x");
            strGraphLocation_y.Append("GraphLocation_y");
            strGraphSize_y.Append("GraphSize_y");

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                strGraphLocation_x.Append(",");
                strGraphLocation_x.Append(GraphLocation[mo].X.ToString());
                strGraphSize_x.Append(",");
                strGraphSize_x.Append(GraphSize[mo].Width.ToString());
                strGraphLocation_y.Append(",");
                strGraphLocation_y.Append(GraphLocation[mo].Y.ToString());
                strGraphSize_y.Append(",");
                strGraphSize_y.Append(GraphSize[mo].Height.ToString());
            }

            Properties.Settings.Default.GraphWindowLocation_x = strGraphLocation_x.ToString();
            Properties.Settings.Default.GraphWindowSize_x = strGraphSize_x.ToString();
            Properties.Settings.Default.GraphWindowLocation_y = strGraphLocation_y.ToString();
            Properties.Settings.Default.GraphWindowSize_y = strGraphSize_y.ToString();

            // Save Settings
            Properties.Settings.Default.GraphParameterSaved = fgGraphParameterSaved;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// In Properties, AssemblyInfo.cs
        ///   [assembly: AssemblyVersion("1.0.*")]
        /// </summary>
        static public DateTime BuildDate
        {
            get
            {
                System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                // assemblyVersion.Build = days after 2000-01-01
                // assemblyVersion.Revision*2 = seconds after 0-hour  (NEVER daylight saving time) 
                DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

                return buildDate;
            }
        }
        /// <summary>
        /// In Properties, AssemblyInfo.cs
        ///   [assembly: AssemblyVersion("1.0.*")]
        /// </summary>
        static public string BuildVersion
        {
            get
            {
                System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                // assemblyVersion.Build = days after 2000-01-01
                // assemblyVersion.Revision*2 = seconds after 0-hour  (NEVER daylight saving time) 

                return assemblyVersion.Revision.ToString();
            }
        }

        // 레지스트리의 키값을 확인
        // Return: false= 레지스트리에 키가 없는 경우
        //         true = 경로가 같은 경우, or 경로가 다른데 프로그램 이름이 같은 경우
        private bool checkStartup(string AppName)
        {
            bool fgEnable;

            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            Microsoft.Win32.RegistryKey startup = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey);

            object strValue = startup.GetValue(AppName);

            if (strValue == null)
            {
                fgEnable = false;
                //updateListBox("No registry auto start path.");
            }
            else
            {
                string currentProcessName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                if (strValue.ToString() == currentProcessName)
                {
                    // 프로그램 경로가 매치하는 동일한 프로그램인 경우
                    // Debug실행시에는 Telofar___.vhost.exe로 서로 mismatch됨

                    // 현 상태를 유지
                    fgEnable = true;
                    updateListBox("Found registry auto start path.");
                }
                else
                {
                    // 프로그램 경로가 다른경우
                    fgEnable = true;
                    updateListBox("Different registry auto start path.");
                }
            }

            return (fgEnable);
        }

        private void setStartup(string AppName, bool fgEnable)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            Microsoft.Win32.RegistryKey startup = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey);

            if (fgEnable == true)
            {
                object strValue = startup.GetValue(AppName);
                startup.Close();

                if (strValue == null)
                {
                    // Add reg. Key
                    startup = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey, true);
                    startup.SetValue(AppName, "\"" + Application.ExecutablePath.ToString() + "\" /autostart");
                    startup.Close();

                    updateDisplayBox("Enable Auto Start with Winows.");
                }
                else
                {
                    string currentProcessName = "\"" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + "\" /autostart";

                    if (strValue.ToString() == currentProcessName)
                    {
                        // 프로그램 경로가 매치하는 동일한 프로그램인 경우
                        // Debug실행시에는 Telofar___.vhost.exe로 서로 mismatch됨

                        // 현 상태를 유지
                        updateDisplayBox("Keep auto start with Windows.");
                    }
                    else
                    {
                        // 프로그램 경로가 다른경우
                        updateDisplayBox("Delete previous auto start path.");

                        // 기존 Value를 지우고 Update함
                        startup = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey, true);
                        startup.SetValue(AppName, "\"" + Application.ExecutablePath.ToString() + "\" /autostart");
                        startup.Close();
                        updateDisplayBox("Enable Auto Start with Winows.");
                    }
                }
            }
            else
            {
                // Remove reg. Key
                startup = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey, true);
                startup.DeleteValue(AppName, false);
                startup.Close();

                updateDisplayBox("Disable Auto Start with Winows.");
            }
        }

        private string RegistryAutoStartUpName = null;
        private Boolean fgAutoStartOption = false;

        private void frmSF_Test_Load(object sender, EventArgs e)
        {
            string ProgramFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string[] spltStrArray = ProgramFileName.Split('\\');
            RegistryAutoStartUpName = spltStrArray[spltStrArray.Length - 1];

            // Auto Start 플래그를 레지스트리 정보로 부터 가지고 옴
            cbAutoStart.Checked = checkStartup(RegistryAutoStartUpName);

#if DEBUG
            // 디버그모드 Factory Screen ON
            ActivateFactorySettingScreen();
            //DeactivateFactorySettingScreen();
#else
            // 릴리즈모드 Factory Screen OFF
            //ActivateFactorySettingScreen();
            DeactivateFactorySettingScreen();
#endif
            int timeSeconds = Convert.ToInt32(BuildVersion) * 2;
            int timeHour = timeSeconds / 3600;
            int timeMin = (timeSeconds - (timeHour * 3600)) / 60;
            int timeSec = (timeSeconds - (timeHour * 3600) - (timeMin * 60));
            DateTime BuildVersionDate = new DateTime(2000, 1, 1, timeHour, timeMin, timeSec);

            this.Text = String.Format("{0} v{1}({2} {3}, r{4})", ProgramName, ProgramVersion,
                          BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);
            //           this.Text = String.Format("{0} v{1}({2}, r{4})", ProgramName, ProgramVersion,
            //                       BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);


            updateTopMostState();
            setWindowPosition();

            ComPortUpdate();

            // BaudRate: 115200 57600 38400 19200 9600
            //cbBaudRate.SelectedIndex = 4;

            // DataSize: 8 7 6
            //cbDataSize.SelectedIndex = 0;

            // Parity: none even mark odd space
            // cbParity.SelectedIndex = 0;

            // HandShake: none Xon / Xoff request ot send request ot send Xon / Xoff
            //cbHandShake.SelectedIndex = 0;

            this.Icon = SapflowApplication.Properties.Resources.logo_real;

            m_SampleCount = 0;

            m_TimeArray.Clear();
            mModuleArray.Clear();

            //  SFChart = new frmChart();
            //  SFChart.Owner = this;
            //  SFChart.Show();

            // 자식 폼 생성

            //initializeSDIfrmChart();
            //initializeSDI2frmChart();
            initializeVariables();

            initializeSystemParameter();
            initializeVCParameter();

            // 릴리즈 모드에서 Valve Control이 활성화 된경우 DeactivateFactorySettingScreen을 호출하여 메뉴가 Visible하게 수정
#if DEBUG
#else
            // 릴리즈모드 Factory Screen OFF
            //ActivateFactorySettingScreen();
            if (fgValveControlActivated == true)
            {
                DeactivateFactorySettingScreen();
                cbValveControlEnable.Checked = true;
            }
#endif

            // 기존창 Defalut 비활성화 동작
            //initializefrmSfModule();
            initializefrmSfMultiModules();
            initializeBackupTermComboBox();

            fgGraphParameterSaved = Properties.Settings.Default.GraphParameterSaved;
            if (fgGraphParameterSaved)
            {
                // 저장된 위치 있음
                loadGraphDefaultParameter();
                relocatefrmSfModule(false);
            }
            else
            {
                // 위치초기화
                relocatefrmSfModule(true);
            }

#if (SERVER_INCLUDED)
#if (SERVER_COMMUNICATION)
            initializeMQTT();       
            initializeThread();
#endif // SERVER_COMMUNICATION
#endif // SERVER_INCLUDED

            /*
                        frmLogin login = new frmLogin();
                   DialogResult dlgResult = login.ShowDialog();
                        if (dlgResult == DialogResult.OK)
                        {
                            MessageBoxAutoClose("ID = " +  login.ID  +"\n" + "PW = " +  login.Password );
                        }
                        else
                        {
                            this.Close(); // 생성자에서 이 메소드를 호출하면 Exception 발생
                        }
            */

            tbY1Min.Enabled = false;
            tbY2Min.Enabled = false;

            // 모듈선택리스트 업데이트 
            ModuleListUpdate();

            // Update Min, Max
            SFModule_Clicked(sender, e);

            //            OutputFileInit();

            // Get Command
            // Update Graph
            SetStyle(ControlStyles.ResizeRedraw, true);

#if (DEBUG_TIME_FAST)
            FastTime = System.DateTime.Now;
#endif
            StartTime = System.DateTime.Now;
            lbStartTime.Text = String.Format("Start Time: {0}", StartTime.ToString("yyyy-MM-dd HH:mm:ss"));

            // Update After StartTIme set
            //cbTimeStep.SelectedIndex = 0;     // 2hours
            cbTimeStep.SelectedIndex = 26;      // Full Scale

            progressBar1.Visible = false;

            queueStatusSFProg("sfstatus", "SF Program is excueted.");
            initSFProgStatus();

            this.Focus();

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length == 2)
            {
                if (args[1] == "/autostart")
                {
                    fgAutoStartOption = waitAutoStartOption();
                }
            }

            if (fgAutoStartOption == true)
            {
                m_frmRestarting = new frmRestarting();
                m_frmRestarting.Visible = true;

                executeAutoStartOption();

                m_frmRestarting.Close();
            }
        }

        private void initSFProgStatus()
        {
#if (SERVER_INCLUDED)
            queueStatusSFProg(STAT_PROGRUN_STOP);
            queueStatusSFProg(STAT_PROGON_STOP);
            queueStatusSFProg(STAT_BACKUPREQ_STOP);
            queueStatusSFProg(STAT_STATUSREQ_STOP);
#endif //SERVER_INCLUDED 
        }

        // true: 자동실행 시작, false: 자동실행 멈춤
        private bool waitAutoStartOption()
        {
            bool fgAutoStart = false;

            updateDisplayBox("___SYSCALL[PREPARE AUTO START]");
            fgAutoStartOption = true;
            pictureBox1.BackColor = Color.Yellow;
            this.Text = "[WARNIG-PROGRAM AUTO STARTED]" + this.Text;

            bool backupTopMost;

            backupTopMost = this.TopMost;
            this.TopMost = false;

            frmAutoStart autostart = new frmAutoStart();
            autostart.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dlgResult = autostart.ShowDialog();

            this.TopMost = backupTopMost;

            if (dlgResult == DialogResult.OK)
            {
                updateDisplayBox("___SYSCALL[EXECUTE AUTO START]");
                fgAutoStart = true;

            }
            else
            {
                updateDisplayBox("___SYSCALL[ABORT AUTO START]");
                fgAutoStart = false;
            }

            return (fgAutoStart);
        }

        // true: 자동실행 시작, false: 자동실행 멈춤
        private void executeAutoStartOption()
        {
            bool fgComPortFound = false;
            bool fgFinished = false;

            for (int i = 0; i < 6 * 60 * 24; i++)   // Retry 1 day(10s * 6 * 60 * 24)
            {
                DateTime now = DateTime.Now;

                btConnectControl.Text = "Abort...";

                if (i == 0)
                {
                    updateDisplayBox(String.Format("[AUTO]Try searching COM Port... Time:{0}", now.ToString("yy-MM-dd HH:mm:ss")));
                }
                else
                {
                    updateDisplayBox(String.Format("[AUTO]Retry Count{0}, Time:{1}", i, now.ToString("yy-MM-dd HH:mm:ss")));
                }
                // 18/03/30 커넥션 복구 시도
                string matchedPortName = loadCurrentCOMPort();
                updateDisplayBox("[AUTO]Saved Port Name:" + matchedPortName);
                if (matchedPortName != "")
                {
                    try
                    {
                        ComPortUpdate();
                        if (cbComPort.Items.Count > 0)
                        {
                            cbComPort.SelectedIndex = 0;
                            for (int j = 0; j < cbComPort.Items.Count; j++)
                            {
                                if (matchedPortName == cbComPort.Items[j].ToString())
                                {
                                    cbComPort.SelectedIndex = j;
                                    fgComPortFound = true;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        updateDisplayBox("Port failed.");
                    }
                }

                Delay(1000);
                if (fgComPortFound == true)
                {
                    updateDisplayBox("[AUTO]Selected Port:" + cbComPort.SelectedText);
                    Delay(1000);

                    for (int retry = 0; retry < 5; retry++)
                    {
                        updateDisplayBox("[AUTO]Click Connect Control");
                        btConnectControl.Text = "Connect";
                        btConnectControl_Click(null, null);
                        Delay(1000);
                        if (Port.IsOpen)
                        {
                            updateDisplayBox("[AUTO]Connected");

                            Delay(10000);

                            btStartAction_Click(null, null);
                            //            Delay(10000);
                            fgFinished = true;

                            break;
                        }
                        else
                        {
                            updateDisplayBox("[AUTO]Retry connection");
                        }
                    }

                }
                else
                {
                    updateDisplayBox(String.Format("[AUTO]COM Port Failed(expected Port:{0})", matchedPortName));
                    Delay(9000);
                }

                if (SystemParameter.RestartingOn == false)
                {
                    updateDisplayBox("[AUTO]Aborting Automation.");
                    fgAutoStartOption = false;
                    btConnectControl.Text = "Connect";
                    btConnectControl.Enabled = false;
                }

                if (fgAutoStartOption == false)
                {
                    if (SystemParameter.RestartingOn == true)  // 경고창이 열려있으면 닫는다.
                    {
                        m_frmRestarting.Close();
                    }

                    btConnectControl.Enabled = true;
                    updateDisplayBox(String.Format("[AUTO]Automation Aborted. Time:{0}", now.ToString("yy-MM-dd HH:mm:ss")));
                    break;
                }

                if (fgFinished == true)
                {
                    updateDisplayBox("[AUTO]Automation Finished.");
                    break;
                }
            }
        }

        private void setWindowPosition()
        {
            Size defaultOffsetPosition = new Size(60, 60);
            Point StartPosition = new Point(0, 0) + new Size(defaultOffsetPosition.Width / 2, defaultOffsetPosition.Height / 2);

            Size DisplaySize = Screen.PrimaryScreen.WorkingArea.Size - defaultOffsetPosition;
            this.StartPosition = FormStartPosition.Manual;

            // 화며의 4분할에 오른쪽 위에 배치
            DisplaySize.Width /= 2;
            DisplaySize.Height /= 2;
            StartPosition.X += DisplaySize.Width;

            this.Location = StartPosition;
            // this.Size = DisplaySize;
        }

        // Serial Port State
        private Boolean IsOpen
        {
            get { return Port.IsOpen; }
            set
            {
                if (value)
                {
                    this.Cursor = Cursors.WaitCursor;

                    btConnectControl.Enabled = false;
                    cbComPort.Enabled = false;
                    updateDisplayBox("System Connecting");

                    // Dummy Data Discard
                    updateDisplayBoxOverwrite("Wait System Connection ... 2");
                    Delay(1000);
                    updateDisplayBoxOverwrite("Wait System Connection... 1");
                    Delay(1000);
                    Port.DiscardInBuffer();
                    updateDisplayBoxOverwrite("System Connected");

                    btConnectControl.Enabled = true;
                    btConnectControl.Text = "Connected";

                    gbSettings.Enabled = true;
                    // 연결됨
                    btStartAction.Enabled = true;

                    btStartAction.BackColor = Color.Ivory;
                    btStartAction.UseVisualStyleBackColor = true;

                    btCalibration.Enabled = true;

                    btStopAction.BackColor = Color.DarkOrange;
                    btStopAction.UseVisualStyleBackColor = false;

                    this.Cursor = Cursors.Default;

                    queueStatusSFProg("sfstatus", "System Connected.");
                    queueStatusSFProg(STAT_PROGON_START);
                }
                else
                {
                    try
                    {
                        updateDisplayBox(String.Format("System Disconnected.", cbComPort.SelectedItem.ToString()));
                    }
                    catch { }
                    btConnectControl.Text = "Connect";

                    cbComPort.Enabled = true;

                    gbSettings.Enabled = true;
                    // 연결안됨
                    btStartAction.Enabled = false;

                    btStartAction.BackColor = Color.Ivory;
                    btStartAction.UseVisualStyleBackColor = true;

                    btCalibration.Enabled = false;

                    btStopAction.BackColor = Color.Ivory;
                    btStopAction.UseVisualStyleBackColor = true;

                    queueStatusSFProg("sfstatus", "System Disconnected.");
                    queueStatusSFProg(STAT_PROGON_STOP);

                }
            }
        }

        private String strSavePortName;
        private void btConnectControl_Click(object sender, EventArgs e)
        {
            if (btConnectControl.Text == "Abort...")
            {
                updateDisplayBox("[AUTO]Aborting Automation.");
                fgAutoStartOption = false;
                btConnectControl.Text = "Connect";
                btConnectControl.Enabled = false;
                return;
            }

            if (!Port.IsOpen)
            {
                // 현재 시리얼이 연결된 상태가 아니면 연결. 
                if (cbComPort.Items.Count > 0)
                {
                    ComPortConnect(cbComPort.SelectedItem.ToString());

                    // 상태 변경
                    IsOpen = Port.IsOpen;

                    if (IsOpen)
                    {
                        strSavePortName = Port.PortName;
                    }
                    else
                    {
                        strSavePortName = "";
                    }

                }
                else
                {
                    updateDisplayBox("[ERR] Port is not available.");
                    Dummy_Click(sender, e);
                }
            }
            else
            {
                // 현재 시리얼이 연결 상태이면 연결 해제
                Port.Close();

                Dummy_Click(sender, e);

                // 상태 변경
                IsOpen = Port.IsOpen;

                if (IsOpen)
                {
                    strSavePortName = Port.PortName;
                }
                else
                {
                    strSavePortName = "";
                }
            }
        }

        private void updateDisplayBox(string str)
        {
            try
            {
                lock (this)
                {
                    if (listBox2.Items.Count > 1000)
                    {
                        listBox2.Items.RemoveAt(0);
                    }
                    listBox2.Items.Add(str);
                    listBox2.SelectedIndex = listBox2.Items.Count - 1;
                }
            }
            catch { }

        }

        private void updateDisplayBoxOverwrite(string str)
        {
            try
            {
                if (listBox2.Items.Count > 0)
                {
                    listBox2.Items.RemoveAt(listBox2.Items.Count - 1);
                }
                listBox2.Items.Add(str);
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
            catch { }
        }

        private void updateListBox(string str)
        {
            try
            {
                if (listBox1.Items.Count > 3000)
                {
                    listBox1.Items.RemoveAt(0);
                }
                listBox1.Items.Add(str);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            catch { }
        }

        private void updateListBoxOverwrite(string str)
        {
            try
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                }
                listBox1.Items.Add(str);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            catch { }
        }

        // Define Command Packet
        // HEAD  : AA 55
        // LEN   : xx /xx
        // CMD   : xx xx
        // CLEN  : xx /xx
        // DATA  : -
        // CRC   : xx xx
        // TAIL  : F0 0F
        public const byte CMD_HEAD_0 = 0xAA;
        public const byte CMD_HEAD_1 = 0x55;
        public const byte CMD_TAIL_0 = 0xF0;
        public const byte CMD_TAIL_1 = 0x0F;

        public const byte START_HEAD_0 = 0;
        public const byte START_HEAD_1 = 1;
        public const byte START_PKT_LENGTH_0 = 2;
        public const byte START_PKT_LENGTH_1 = 3;
        public const byte START_MODULE_NUM_0 = 4;
        public const byte START_MODULE_NUM_1 = 5;
        public const byte START_CMD_0 = 6;
        public const byte START_CMD_1 = 7;
        public const byte START_CMD_LENGTH_0 = 8;
        public const byte START_CMD_LENGTH_1 = 9;
        public const byte START_DATA_PACKET = 10;

        public const byte START_RSP_0 = 6;
        public const byte START_RSP_1 = 7;
        public const byte START_RSP_LENGTH_0 = 8;
        public const byte START_RSP_LENGTH_1 = 9;

        public const byte SIZE_HEAD = 2;
        public const byte SIZE_PKT_LENGTH = 2;
        public const byte SIZE_MODULE_NUM = 2;
        public const byte SIZE_CMD = 2;
        public const byte SIZE_CMD_LENGTH = 2;
        public const byte SIZE_CRC_LENGTH = 2;
        public const byte SIZE_TAIL = 2;
        public const byte SIZE_ZERO_DATA_PACKET = SIZE_HEAD + SIZE_PKT_LENGTH + SIZE_MODULE_NUM + SIZE_CMD + SIZE_CMD_LENGTH + SIZE_CRC_LENGTH + SIZE_TAIL;

        public const byte SIZE_RSP = 2;
        public const byte SIZE_RSP_LENGTH = 2;

        public const byte RSP_HEAD_0 = 0x55;
        public const byte RSP_HEAD_1 = 0xAA;
        public const byte RSP_TAIL_0 = 0x0F;
        public const byte RSP_TAIL_1 = 0xF0;


        private byte recvCommandLen;
        private bool RespondDataReceived = false;
        private int RespondDataErrorCode;

        private UInt16 RespondModuleNumber;

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int iRcvByte = Port.BytesToRead;

            if (iRcvByte > 0)
            {
                // Get string from Port Buffer to recvRawBuf
                try
                {
                    readCnt = Port.Read(recvRawBuf, 0, iRcvByte);
                }
                catch (TimeoutException ex)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        updateDisplayBox(ex.ToString());
                    }));
                }

                parseSerialCommand();

            }
        }

        private UInt16 calculateSFfromRawData(UInt16 max, UInt16 min)
        {
            UInt16 resultValue;
            if (max >= min)
            {
                resultValue = (UInt16)(max - min);
            }
            else
            {
                resultValue = 0;
            }
            return (resultValue);
        }

        private void updateSFMinMaxValue(int mo, int ch, float valueSF)
        {
            if (valueSF < valueSFMin[mo, ch])
            {
                valueSFMin[mo, ch] = valueSF;
            }

            if (valueSF > valueSFMax[mo, ch])
            {
                valueSFMax[mo, ch] = valueSF;
            }
        }

        private void updateRTempMinMaxValue(int mo, int ch, float valueRTemp)
        {
            if (valueRTemp < valueRTempMin[mo, ch])
            {
                valueRTempMin[mo, ch] = valueRTemp;
            }

            if (valueRTemp > valueRTempMax[mo, ch])
            {
                valueRTempMax[mo, ch] = valueRTemp;
            }
        }

        private void updateTemperatureMinMaxValue(int mo, float valueTemperature)
        {
            if (valueTemperature < valueTemperatureMin[mo])
            {
                valueTemperatureMin[mo] = valueTemperature;
            }

            if (valueTemperature > valueTemperatureMax[mo])
            {
                valueTemperatureMax[mo] = valueTemperature;
            }
        }

        private void updateHumidityMinMaxValue(int mo, float valueHumidity)
        {
            if (valueHumidity < valueHumidityMin[mo])
            {
                valueHumidityMin[mo] = valueHumidity;
            }

            if (valueHumidity > valueHumidityMax[mo])
            {
                valueHumidityMax[mo] = valueHumidity;
            }
        }

        // mCount : 현재까지 저장된 모듈데이터 개수, mCount-1번째 배열에 현재값 존재
        private void preprocessingParameter(int mCount, int mo, int ch, UInt16 min, UInt16 max)
        {
            int rawValue;

            /*필터를 위한 상수를 설정한다*/
            double f_cut = 1d / 600d;  // 1200, 2400 점점더 부드럽게
            double tau = 1d / 2d / Math.PI / f_cut;
            double t_s = 120d;

            double resultValue;

            /* Parameters */
            double a = (double)SystemParameter.Para[mo, ch].a;
            double b = (double)SystemParameter.Para[mo, ch].b;
            double c = (double)SystemParameter.Para[mo, ch].c;
            double Tm = (double)SystemParameter.Para[mo, ch].Tm;

            DateTime nTime, n1Time;


            //if((min==10876) &&(max==14526))
            //{
            //    min = 10876;
            //}

            /* 필터링을 위한 N-1, N-2, N-3 데이터를 가져온다. */
            //
            UInt16 data_n1_min, data_n1_max;
            UInt16 data_n2_min, data_n2_max;
            UInt16 data_n3_min, data_n3_max;

            if (mCount >= 2)
            {
                data_n1_min = mModuleArray[(mCount - 1) - 1].rawModudle[mo].CHData[ch].InitialTemperature;
                data_n1_max = mModuleArray[(mCount - 1) - 1].rawModudle[mo].CHData[ch].HeatedTemperature;
            }
            else
            {
                data_n1_min = 0;
                data_n1_max = 0;
            }

            if (mCount >= 3)
            {
                data_n2_min = mModuleArray[(mCount - 1) - 2].rawModudle[mo].CHData[ch].InitialTemperature;
                data_n2_max = mModuleArray[(mCount - 1) - 2].rawModudle[mo].CHData[ch].HeatedTemperature;
            }
            else
            {
                data_n2_min = 0;
                data_n2_max = 0;
            }

            if (mCount >= 4)
            {
                data_n3_min = mModuleArray[(mCount - 1) - 3].rawModudle[mo].CHData[ch].InitialTemperature;
                data_n3_max = mModuleArray[(mCount - 1) - 3].rawModudle[mo].CHData[ch].HeatedTemperature;
            }
            else
            {
                data_n3_min = 0;
                data_n3_max = 0;
            }

            // SF Value
            //     Diff = Max - Min;
            rawValue = max - min;

            /* 1st low pass filter N=3 */
            UInt16 data_n1_SF = calculateSFfromRawData(data_n1_max, data_n1_min);
            UInt16 data_n2_SF = calculateSFfromRawData(data_n2_max, data_n2_min);
            UInt16 data_n3_SF = calculateSFfromRawData(data_n3_max, data_n3_min);

            double filtValueSF = (tau / (tau + t_s)) * ((tau / (tau + t_s)) * ((tau / (tau + t_s)) * (double)data_n3_SF + (t_s / (tau + t_s)) * (double)data_n2_SF) + (t_s / (tau + t_s)) * (double)data_n1_SF) + (t_s / (tau + t_s)) * (double)rawValue;

            if (cbDataFilterON.CheckState != CheckState.Checked)
            {
                try
                {
                    double tmp = (Tm - rawValue * c) / (rawValue * c);
                    //tmp = Math.Abs(tmp);    // 17/06/15 v0.882

                    if ((tmp < 0) || (double.IsInfinity(tmp)) || (double.IsNegativeInfinity(tmp)))
                        resultValue = 0;
                    else
                        resultValue = a * Math.Pow(tmp, b);

                    if (resultValue > 99999) resultValue = 99999;   // 0122'18 그래프 표시 오버플러우 방지용

                }
                catch
                { resultValue = 99998; }
            }
            else
            {
                try
                {
                    // SapFlow case 1:
                    double tmp = (Tm - filtValueSF * c) / (filtValueSF * c);
                    //tmp = Math.Abs(tmp);    // 17/06/15 v0.882

                    if ((tmp < 0) || (double.IsInfinity(tmp)) || (double.IsNegativeInfinity(tmp)))
                        resultValue = 0;
                    else
                        resultValue = a * Math.Pow(tmp, b);

                    if (resultValue > 99999) resultValue = 99999;   // 0122'18 그래프 표시 오버플러우 방지용
                }
                catch
                { resultValue = 99998; }
            }

            valueSF[mo, ch] = (float)resultValue;
            updateSFMinMaxValue(mo, ch, valueSF[mo, ch]);

            // Relative Temperature
            //     value = Min;
            rawValue = min;

            UInt16 data_n1_RTemp = data_n1_min;
            UInt16 data_n2_RTemp = data_n2_min;
            UInt16 data_n3_RTemp = data_n3_min;
            double filtValueRTemp = (tau / (tau + t_s)) * ((tau / (tau + t_s)) * ((tau / (tau + t_s)) * data_n3_RTemp + (t_s / (tau + t_s)) * data_n2_RTemp) + (t_s / (tau + t_s)) * data_n1_RTemp) + (t_s / (tau + t_s)) * rawValue;

            if (cbDataFilterON.CheckState != CheckState.Checked)
            {
                resultValue = rawValue * c;
            }
            else
            {
                // RTemp case 2:
                resultValue = filtValueRTemp * c;
            }
            valueRTemp[mo, ch] = (float)resultValue;
            updateRTempMinMaxValue(mo, ch, valueRTemp[mo, ch]);
        }

        //
        // N번째 데이터를 참조하여 N-1의 SF를 온도보상을 적용하여 재계산하는 루틴
        // mCount : 현재까지 저장된 모듈데이터 개수, mCount-1번째 배열에 현재값 존재
        //
        private float preprocessingParameterCompensation(double currentDate, int mCount, int mo, int ch, UInt16 min, UInt16 max)
        {
            double rawValue;

            double resultValue;

            /* Parameters */
            double a = (double)SystemParameter.Para[mo, ch].a;
            double b = (double)SystemParameter.Para[mo, ch].b;
            double c = (double)SystemParameter.Para[mo, ch].c;
            double Tm = (double)SystemParameter.Para[mo, ch].Tm;

            DateTime nTime, n1Time;

            /* 온도보상을 위한 N-1 데이터를 가져온다. */
            UInt16 data_n_min, data_n_max;
            UInt16 data_n1_min, data_n1_max;
            double data_n1_min_comp, data_n1_max_comp;

            //Initail(N), Heated(N)의 값과 Time(N)을 읽음
            data_n_min = min; // mModuleArray[(mCount - 1)].rawModudle[mo].CHData[ch].InitialTemperature;
            data_n_max = max;  // mModuleArray[(mCount - 1)].rawModudle[mo].CHData[ch].HeatedTemperature;
            nTime = DateTime.FromOADate(currentDate);// DateTime.FromOADate(mModuleArray[(mCount - 1)].OADate);

            if (mCount >= 2)
            {
                //Initail(N-1), Heated(N-1)의 값과 Time(N-1)을 읽음
                data_n1_min = mModuleArray[(mCount - 1) - 1].rawModudle[mo].CHData[ch].InitialTemperature;
                data_n1_max = mModuleArray[(mCount - 1) - 1].rawModudle[mo].CHData[ch].HeatedTemperature;
                n1Time = DateTime.FromOADate(mModuleArray[(mCount - 1) - 1].OADate);
            }
            else
            {
                data_n1_min = 0;
                data_n1_max = 0;
                n1Time = DateTime.FromOADate(mModuleArray[(mCount - 1)].OADate);    // 그냥 현재값
            }

            // N-1번째와 N번째 사이의 시간 간격을 계산: Time(N) - Time(N-1) 
            // (가정) 측정시작이후 종료까지 delta_T는 일정(채널당 20초) 
            TimeSpan elaspedTime = nTime - n1Time;

            // 온도보상 실시
            double calDiffTemperature = data_n_min - data_n1_min;   // 측정간격에 대한 온도변화

            // (20초/측정간격)비율로 20초간의 온도변화 계산
            // (가정) 측정시간동안 온도변화는 선형)
            double timeRatio = 20.0 * 1000.0 / (elaspedTime.TotalMilliseconds);

            // 20초간의 온도변화를 Heated(N-1)에 보상
            data_n1_min_comp = data_n1_min;
            data_n1_max_comp = (data_n1_max - (calDiffTemperature * timeRatio));

            //if (ch == 0) updateDisplayBox("calDiffTemperature:" + (calDiffTemperature.ToString("0.000")));
            //if (ch == 0) updateDisplayBox("Temp. Compensation:" + (calDiffTemperature * timeRatio).ToString("0.000"));
            
            // SF Value
            //     Diff = Max - Min;
            rawValue = data_n1_max_comp - data_n1_min_comp;

            try
            {
                double tmp = (Tm - rawValue * c) / (rawValue * c);
                //tmp = Math.Abs(tmp);    // 17/06/15 v0.882

                if ((tmp < 0) || (double.IsInfinity(tmp)) || (double.IsNegativeInfinity(tmp)))
                    resultValue = 0;
                else
                    resultValue = a * Math.Pow(tmp, b);

                if (resultValue > 99999) resultValue = 99999;   // 0122'18 그래프 표시 오버플러우 방지용

            }
            catch
            { resultValue = 99998; }

            // resultValue로 SF(N-1)데이터를 다시 업데이트 
            return ((float)resultValue);
        }
        
        // SF 값을 연산
        private float calculateSFParameter(int mo, int ch, UInt16 min, UInt16 max)
        {
            int rawValue;

            double resultValue;

            /* Parameters */
            double a = (double)SystemParameter.Para[mo, ch].a;
            double b = (double)SystemParameter.Para[mo, ch].b;
            double c = (double)SystemParameter.Para[mo, ch].c;
            double Tm = (double)SystemParameter.Para[mo, ch].Tm;

            // SF Value
            //     Diff = Max - Min;
            rawValue = max - min;

            {
                try
                {
                    double tmp = (Tm - rawValue * c) / (rawValue * c);
                    //tmp = Math.Abs(tmp);    // 17/06/15 v0.882

                    if ((tmp < 0) || (double.IsInfinity(tmp)) || (double.IsNegativeInfinity(tmp)))
                        resultValue = 0;
                    else
                        resultValue = a * Math.Pow(tmp, b);

                    if (resultValue > 999999) resultValue = 999999;   // 0122'18 그래프 표시 오버플러우 방지용
                }
                catch
                { resultValue = 99998; }
            }

            return ((float)resultValue);
        }

        // RTemp 값을 연산
        private float calculateRTempParameter(int mo, int ch, UInt16 min, UInt16 max)
        {
            int rawValue;

            double resultValue;

            /* Parameters */
            double a = (double)SystemParameter.Para[mo, ch].a;
            double b = (double)SystemParameter.Para[mo, ch].b;
            double c = (double)SystemParameter.Para[mo, ch].c;
            double Tm = (double)SystemParameter.Para[mo, ch].Tm;

            // Relative Temperature
            rawValue = min;

            resultValue = rawValue * c;

            return ((float)resultValue);
        }

        private void updateDataBase()
        {
            StringBuilder savedata = new StringBuilder();

            savedata.Clear();

            if (flagStarting)
            {
                // for the first time starting
                flagStarting = false;
                //                            StartTime = System.DateTime.Now;
            }

#if (DEBUG_TIME_FAST)
            DateTime now = FastTime.AddMinutes(2);
            FastTime = now;

            lbDateTime.Text = String.Format("Current Time: {0}", now.ToString());

#else
            DateTime now = System.DateTime.Now;
            // 2018/05/08 Server SQL업데이트 일관성을 위해 ms단위 삭제
            now = DateTime.ParseExact(now.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);
            lbDateTime.Text = String.Format("Current Time: {0}", now.ToString("yyyy-MM-dd HH:mm:ss"));
#endif
            savedata.Append(now.ToString("[yyyy-MM-dd HH:mm:ss]") + ", Index=" + m_SampleCount.ToString());
            savedata.Append(Environment.NewLine);

            // Calculate Minimum Time Step 
            DateTime minDate = now;
            if (valueTimeStep.Hour > 0)
            {
                minDate = minDate.AddHours(-1 * valueTimeStep.Hour);
            }
            if (valueTimeStep.Day > 0)
            {
                minDate = minDate.AddDays(-1 * valueTimeStep.Day);
            }

            double currentDate = now.ToOADate();

            // DATA MANANGEMENT: OADate Update
            totalRawModuleData totalData = new totalRawModuleData();
            totalData.OADate = currentDate;
            totalData.Index = m_SampleCount;

            // DATA MANANGEMENT: Valve Control Data Update
            rawValveControData rawVCdata = null;
            rawVCdata = totalData.rawValveControl;

            Chart chart = null;
            rawModuleData rawdata = null;
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo])
                {
                    totalData.rawModudle[mo] = new rawModuleData();
                    rawdata = totalData.rawModudle[mo];

                    // DATA MANANGEMENT: module Number Update
                    rawdata.moduleDefine.mType = ModuleType_SF;
                    rawdata.moduleDefine.mSubtype = ModuleSubType;
                    rawdata.moduleDefine.mModuleNumber = (UInt16)mo;

                    //  DATA MANANGEMENT: Additional Data Update(Parameter, ...)
                    mTemperature[mo] = arrayTemperatureData[mo];
                    mHumidity[mo] = arrayHumidityData[mo];

                    savedata.Append("SF[");
                    savedata.Append((mo + 1).ToString("D2"));
                    savedata.Append("] ");       // 모듈 번호는 1 ~ N
                }

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if ((mo == MainSelection.ModuleNumber) && (ch == MainSelection.ChannelNumber[MainSelection.ModuleNumber]))
                    {
                        // 모듈번호와 채널이 매칭시 창 업데이트
                        lbTemperature.Text = valueSF[mo, ch].ToString("0.##");
                        lbHumidity.Text = valueRTemp[mo, ch].ToString("0.##");

                        if (tbY1MinValue.Text != valueSFMin[mo, ch].ToString()) tbY1MinValue.Text = valueSFMin[mo, ch].ToString();
                        if (tbY1MaxValue.Text != valueSFMax[mo, ch].ToString()) tbY1MaxValue.Text = valueSFMax[mo, ch].ToString();
                        if (tbY2MinValue.Text != valueRTempMin[mo, ch].ToString()) tbY2MinValue.Text = valueRTempMin[mo, ch].ToString();
                        if (tbY2MaxValue.Text != valueRTempMax[mo, ch].ToString()) tbY2MaxValue.Text = valueRTempMax[mo, ch].ToString();

                    }

                    // ch = channel number 0 ~ SFChannelLength(채널수)
                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                    {
                        rawdata.additionalData = new AdditionalData(mTemperature[mo], mHumidity[mo], mSoilMoisture[mo], SystemParameter.Para[mo, ch].a, SystemParameter.Para[mo, ch].b, SystemParameter.Para[mo, ch].c, SystemParameter.Para[mo, 0].Tm, SystemParameter.Para[mo, 1].Tm, SystemParameter.Para[mo, 2].Tm, SystemParameter.Para[mo, 3].Tm);

                        // DATA MANANGEMENT: Channel Data Update
                        //rawdata.CHData[ch].InitialTemperature =(UInt16)(ch + mo * 16); //;// (UInt16)valueSF[ch] + ch+ SFModule * 16;
                        //rawdata.CHData[ch].HeatedTemperature = (UInt16)(ch + mo * 16); ;  // (UInt16)valueRTemp[ch]+ ch + SFModule * 16;
                        rawdata.CHData[ch].InitialTemperature = arrayInitialData[mo, ch];
                        rawdata.CHData[ch].HeatedTemperature = arrayHeatedData[mo, ch];

                        savedata.Append(" ch");
                        savedata.Append((ch + 1).ToString());
                        savedata.Append("[");
                        savedata.Append(arrayInitialData[mo, ch].ToString("x2"));
                        savedata.Append(",");
                        savedata.Append(arrayHeatedData[mo, ch].ToString("x2"));
                        savedata.Append("]");

                        // 그래픽창을 업데이트
                        if (SystemParameter.MultiModuleOn)
                        {
                            //chart = m_frmSfMultiModules.ChartMultiCH[mmoo, ch].chart1;
                            chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                            chart.Series["SF"].Points.AddXY(currentDate, valueSF[mo, ch]);
                            chart.Series["Temp"].Points.AddXY(currentDate, valueRTemp[mo, ch]);

                            // 현재값은 arrayInitialData[mo,ch], arrayHeatedData[mo,ch]에 값이 저장되어있음
                            if (cbTCompensation.Checked == true)
                            {
                                UInt16 min = arrayInitialData[mo, ch];
                                UInt16 max = arrayHeatedData[mo, ch];

                                int index = mModuleArray.Count;

                                float compensatedSFValue;
                                if (index > 1)
                                {
                                    //mModuleArray는 업데이트 되지 않은 상태라 Count가 하나 작음
                                    compensatedSFValue = preprocessingParameterCompensation(currentDate, index + 1, mo, ch, min, max);
                                    chart.Series["SF"].Points[chart.Series["SF"].Points.Count - 2].YValues[0] = compensatedSFValue;
                                }
                            }

                            // Chart의 Point수를 제한
                            if (checkReduceMultiChartPoint(chart.Series["SF"], mo, ch))
                            {
                                executeReduceMultiChartPoint(chart.Series["SF"], mo, ch);
                                executeReduceMultiChartPoint(chart.Series["Temp"], mo, ch);
                            }
                            //chart.ChartAreas[0].RecalculateAxesScale();
                            fgRequestMultiChartUpdate = true;
                        }
                        if (SystemParameter.ModuleOn[mo])       // 해당 모듈의 그래픽창이 ON된 경우
                        {
                            chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                            chart.Series["SF"].Points.AddXY(currentDate, valueSF[mo, ch]);
                            if ((valueSF[mo, ch] <= 0) && double.IsNaN(chart.ChartAreas[0].AxisY.Maximum))
                            {
                                // Set Manual ViewScale for Mouse Movement
                                //                               chart.ChartAreas[0].AxisY.Maximum = 1000;
                                //                               chart.ChartAreas[0].AxisY.Minimum = 0;
                            }

                            // 현재값은 arrayInitialData[mo,ch], arrayHeatedData[mo,ch]에 값이 저장되어있음
                            if (cbTCompensation.Checked == true)
                            {
                                UInt16 min = arrayInitialData[mo, ch];
                                UInt16 max = arrayHeatedData[mo, ch];

                                int index = mModuleArray.Count;

                                float compensatedSFValue;
                                if (index > 1)
                                {
                                    //mModuleArray는 업데이트 되지 않은 상태라 Count가 하나 작음
                                    compensatedSFValue = preprocessingParameterCompensation(currentDate, index + 1, mo, ch, min, max);
                                    chart.Series["SF"].Points[chart.Series["SF"].Points.Count - 2].YValues[0] = compensatedSFValue;
                                }
                            }

                            chart.Series["Temp"].Points.AddXY(currentDate, valueRTemp[mo, ch]);


                            // SHT15데이터 업데이트 
                            // chart.Series["TempSHT15"].Points.AddXY(currentDate, mTemperature[mo]);
                            // chart.Series["HumSHT15"].Points.AddXY(currentDate, mHumidity[mo]);

                            // VPD Update
                            // chart.Series["VPD"].Points.AddXY(currentDate, (double)calculateVPD(mTemperature[mo], mHumidity[mo]));

                            // Chart의 Point수를 제한
                            if (checkReduceChartPoint(chart.Series["SF"], mo, ch))
                            {
                                executeReduceChartPoint(chart.Series["SF"], mo, ch);
                                executeReduceChartPoint(chart.Series["Temp"], mo, ch);
                            }

                            // Update Scale
                            if (mModuleArray.Count > 0)
                            {
                                int index = mModuleArray.Count - 1;     // Last Index
                                chart.ChartAreas[0].AxisX.Minimum = mModuleArray[0].OADate;
                                chart.ChartAreas[0].AxisX.Maximum = mModuleArray[index].OADate;
                                updateScaleDisplay(chart);
                            }
                        }

                        // VC관련 파라메터 업데이트
                        rawVCdata.Enabled[mo, ch] = VCParameter.Enabled[mo, ch];
                        rawVCdata.Max[mo, ch] = VCParameter.Max[mo, ch];
                        rawVCdata.Min[mo, ch] = VCParameter.Min[mo, ch];
                        rawVCdata.Constrain[mo, ch] = VCParameter.Constrain[mo, ch];
                        rawVCdata.Ratio[mo, ch] = VCParameter.Ratio[mo, ch];
                    }
                }

                if (SystemParameter.ModuleEnable[mo])
                {
                    savedata.Append(", TE[" + mTemperature[mo].ToString() + "]");
                    savedata.Append(", HU[" + mHumidity[mo].ToString() + "]");
                    savedata.Append(", a[" + SystemParameter.Para[mo, 0].a.ToString() + "]");    // a, b, c CH1으로 통일
                    savedata.Append(", b[" + SystemParameter.Para[mo, 0].b.ToString() + "]");
                    savedata.Append(", c[" + SystemParameter.Para[mo, 0].c.ToString() + "]");
                    savedata.Append(", Tm1[" + SystemParameter.Para[mo, 0].Tm.ToString() + "]");
                    savedata.Append(", Tm2[" + SystemParameter.Para[mo, 1].Tm.ToString() + "]");
                    savedata.Append(", Tm3[" + SystemParameter.Para[mo, 2].Tm.ToString() + "]");
                    savedata.Append(", Tm4[" + SystemParameter.Para[mo, 3].Tm.ToString() + "]");

                    savedata.Append(Environment.NewLine);
                }

            }
            // VC관련 파라메터 업데이트
            rawVCdata.EventJouleValue = VCParameter.EventJouleValue;
            if (VCParameter.StartEndEnabled)
            {
                rawVCdata.StartTime = VCParameter.StartTime;
                rawVCdata.EndTime = VCParameter.EndTime;
            }
            else
            {
                DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

                rawVCdata.StartTime = dt + TimeSpan.Zero;
                rawVCdata.EndTime = dt + TimeSpan.Zero;
            }
            if (VCParameter.MaxMinEnabled)
            {
                rawVCdata.MaxTime = VCParameter.MaxTime;
                rawVCdata.MinTime = VCParameter.MinTime;
            }
            else
            {
                rawVCdata.MaxTime = TimeSpan.Zero;
                rawVCdata.MinTime = TimeSpan.Zero;
            }

            // VC Parameter Print
            bool fgPrintVCParameter = false;
            int cnt;

            cnt = mModuleArray.Count;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo])
                {
                    if (cnt == 0)
                    {
                        // 처음엔 무조건 출력
                        fgPrintVCParameter = true;
                    }
                    else
                    {
                        // 파라메터가 변경된 경우만 출력
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                if (rawVCdata.Enabled[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Enabled[mo, ch])
                                {
                                    fgPrintVCParameter = true;
                                }

                                if (rawVCdata.Max[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Max[mo, ch])
                                {
                                    fgPrintVCParameter = true;
                                }

                                if (rawVCdata.Min[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Min[mo, ch])
                                {
                                    fgPrintVCParameter = true;
                                }

                                if (rawVCdata.Constrain[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Constrain[mo, ch])
                                {
                                    fgPrintVCParameter = true;
                                }

                                if (rawVCdata.Ratio[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Ratio[mo, ch])
                                {
                                    fgPrintVCParameter = true;
                                }
                            }
                        }

                        if (rawVCdata.EventJouleValue != mModuleArray[cnt - 1].rawValveControl.EventJouleValue)
                        {
                            fgPrintVCParameter = true;
                        }

                        if (DateTime.Compare(rawVCdata.StartTime, mModuleArray[cnt - 1].rawValveControl.StartTime) != 0)
                        {
                            fgPrintVCParameter = true;
                        }

                        if (DateTime.Compare(rawVCdata.EndTime, mModuleArray[cnt - 1].rawValveControl.EndTime) != 0)
                        {
                            fgPrintVCParameter = true;
                        }

                        if (TimeSpan.Compare(rawVCdata.MaxTime, mModuleArray[cnt - 1].rawValveControl.MaxTime) != 0)
                        {
                            fgPrintVCParameter = true;
                        }

                        if (TimeSpan.Compare(rawVCdata.MinTime, mModuleArray[cnt - 1].rawValveControl.MinTime) != 0)
                        {
                            fgPrintVCParameter = true;
                        }
                    }
                }
            }

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // VC 파라메터 출력
                if (fgPrintVCParameter)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        // VC[##]
                        savedata.Append("VC[");
                        savedata.Append((mo + 1).ToString("D2"));
                        savedata.Append("] ");       // 모듈 번호는 1 ~ N

                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {

                                // VC관련 파라메터 업데이트
                                // Channel Data
                                savedata.Append(" ch");
                                savedata.Append((ch + 1).ToString());
                                savedata.Append("[");
                                savedata.Append(rawVCdata.Enabled[mo, ch].ToString());
                                savedata.Append(",");
                                savedata.Append(rawVCdata.Min[mo, ch].ToString());
                                savedata.Append(",");
                                savedata.Append(rawVCdata.Max[mo, ch].ToString());
                                savedata.Append(",");
                                savedata.Append(rawVCdata.Constrain[mo, ch].ToString());
                                savedata.Append(",");
                                savedata.Append(rawVCdata.Ratio[mo, ch].ToString());
                                savedata.Append("]");
                            }
                        }

                        DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

                        savedata.Append(" SET[");
                        savedata.Append(rawVCdata.StartTime.ToString("HH:mm"));
                        savedata.Append(",");
                        savedata.Append(rawVCdata.EndTime.ToString("HH:mm"));
                        savedata.Append(",");
                        savedata.Append((dt + rawVCdata.MaxTime).ToString("HH:mm"));
                        savedata.Append(",");
                        savedata.Append((dt + rawVCdata.MinTime).ToString("HH:mm"));
                        savedata.Append(",");
                        savedata.Append(rawVCdata.EventJouleValue.ToString());
                        savedata.Append("]");
                        savedata.Append(Environment.NewLine);
                    }

                }
            }
            //epoch++;

            m_TimeArray.Add(currentDate);// .ToString("yyyy-MM-dd HH:mm:ss"));
            UpdateModuleArrayData(currentDate, totalData);
            m_SampleCount++;

            System.IO.File.AppendAllText(fs, savedata.ToString());
        }

        //                                                    
        // |<-30 per day->|<-30 per day->|...|<-30 per day->| |<-60 per day->|<-120 per day->|<-240 per day->|<-480 per day->|<-480 per day->|
        //                                                        level 3         level 2         level 1
        //                                                    |<------------REDUCE_POINT_AREA------------------------------->|
        //                                                                                                                   |<--R_P_COUNT-->|
        //
        // Step1. 줄이기전 |<-420 per day->|<-420 per day->|
        // Step2. 줄인후   |<--210-->|<-420 per day->|                                                
        // Step2. 포인트 추가  |<--210-->|<-420 per day->|<-420 per day->|
        //                    |<--- 줄일 영역----------->|
        private const int REDUCE_POINT_KEEP = 30;    //30 point per day
        private const int REDUCE_POINT_LEVEL = 3;    //60 , 120, 240
        private const int REDUCE_POINT_AREA = REDUCE_POINT_KEEP * 2 + REDUCE_POINT_KEEP * 4 + REDUCE_POINT_KEEP * 8 + REDUCE_POINT_KEEP * 16;    // 60+120+240+480
        private const int REDUCE_POINT_COUNT = REDUCE_POINT_KEEP * 16;       // 480

        // Point개수가 COUNT를 초과하면 TRUE return, 이외에는 count++
        private bool checkReduceChartPoint(Series series, int mo, int ch)
        {
            bool fgReducePoint = false;

            if (cbDisposeData.CheckState == CheckState.Checked)
            {
                int Count = series.Points.Count;

                if (Count == 0)
                {
                    CurrentChartPointCount[mo, ch] = 0;
                }
                else
                {
                    if (CurrentChartPointCount[mo, ch] < REDUCE_POINT_COUNT)
                    {
                        CurrentChartPointCount[mo, ch]++;
                    }

                    if (CurrentChartPointCount[mo, ch] >= REDUCE_POINT_COUNT)
                    {
                        // 포인트가 줄일만큼 모인경우
                        CurrentChartPointCount[mo, ch] = 0;
                        fgReducePoint = true;
                    }
                }
            }
            return (fgReducePoint);
        }

        private void executeReduceChartPoint(Series series, int mo, int ch)
        {
            int StartPoint, EndPoint;
            int Count = series.Points.Count;

            EndPoint = Math.Max((int)0, (Count - REDUCE_POINT_COUNT));
            StartPoint = Math.Max((int)0, (EndPoint - REDUCE_POINT_AREA));

            if (StartPoint < EndPoint)
            {
                updateListBox(String.Format("Reduce M{2}C{3}: [{0},{1})", StartPoint, EndPoint, mo + 1, ch + 1));
                for (int cnt = StartPoint; cnt < EndPoint; cnt += 2)
                {
                    // Average Point Value
                    double value1, value2, avg_value;
                    value1 = series.Points[cnt].YValues[0];
                    value2 = series.Points[cnt + 1].YValues[0];
                    avg_value = (value1 + value2) / 2;
                    series.Points[cnt].YValues[0] = avg_value;
                    series.Points.RemoveAt(cnt + 1);  // 두점을 평균낸뒤 한점을 지움
                }
            }
        }

        // Point개수가 COUNT를 초과하면 TRUE return, 이외에는 count++
        private bool checkReduceMultiChartPoint(Series series, int mo, int ch)
        {
            bool fgReducePoint = false;

            if (cbDisposeData.CheckState == CheckState.Checked)
            {
                int Count = series.Points.Count;

                if (Count == 0)
                {
                    CurrentMultiChartPointCount[mo, ch] = 0;
                }
                else
                {
                    if (CurrentMultiChartPointCount[mo, ch] < REDUCE_POINT_COUNT)
                    {
                        CurrentMultiChartPointCount[mo, ch]++;
                    }

                    if (CurrentMultiChartPointCount[mo, ch] >= REDUCE_POINT_COUNT)
                    {
                        // 포인트가 줄일만큼 모인경우
                        CurrentMultiChartPointCount[mo, ch] = 0;
                        fgReducePoint = true;
                    }
                }
            }
            return (fgReducePoint);
        }

        private void executeReduceMultiChartPoint(Series series, int mo, int ch)
        {
            int StartPoint, EndPoint;
            int Count = series.Points.Count;

            EndPoint = Math.Max((int)0, (Count - REDUCE_POINT_COUNT));
            StartPoint = Math.Max((int)0, (EndPoint - REDUCE_POINT_AREA));

            if (StartPoint < EndPoint)
            {
                //     updateListBox(String.Format("Reduce m{2}c{3}: [{0},{1})", StartPoint, EndPoint, mo + 1, ch + 1));
                for (int cnt = StartPoint; cnt < EndPoint; cnt += 2)
                {
                    // Average Point Value
                    double value1, value2, avg_value;
                    value1 = series.Points[cnt].YValues[0];
                    value2 = series.Points[cnt + 1].YValues[0];
                    avg_value = (value1 + value2) / 2;
                    series.Points[cnt].YValues[0] = avg_value;
                    series.Points.RemoveAt(cnt + 1);  // 두점을 평균낸뒤 한점을 지움
                }
            }
        }


        // Point개수가 COUNT를 초과하면 TRUE return, 이외에는 count++
        private bool checkReduceVCPoint(Series series, int index)
        {
            bool fgReducePoint = false;

            if (cbDisposeVCData.CheckState == CheckState.Checked)
            {
                int Count = series.Points.Count;

                if (Count == 0)
                {
                    CurrentVCPointChannelCount[index] = 0;
                }
                else
                {
                    if (CurrentVCPointChannelCount[index] < REDUCE_POINT_COUNT)
                    {
                        CurrentVCPointChannelCount[index]++;
                    }

                    if (CurrentVCPointChannelCount[index] >= REDUCE_POINT_COUNT)
                    {
                        // 포인트가 줄일만큼 모인경우
                        CurrentVCPointChannelCount[index] = 0;
                        fgReducePoint = true;
                    }
                }
            }
            return (fgReducePoint);
        }

        private void executeReduceVCPoint(Series series, int index)
        {
            int StartPoint, EndPoint;
            int Count = series.Points.Count;

            EndPoint = Math.Max((int)0, (Count - REDUCE_POINT_COUNT));
            StartPoint = Math.Max((int)0, (EndPoint - REDUCE_POINT_AREA));

            if (StartPoint < EndPoint)
            {
                //updateListBox(String.Format("Reduce VC Index{2}: [{0},{1})", StartPoint, EndPoint, index));
                for (int cnt = StartPoint; cnt < EndPoint; cnt += 2)
                {
                    // Average Point Value
                    double value1, value2, avg_value;
                    value1 = series.Points[cnt].YValues[0];
                    value2 = series.Points[cnt + 1].YValues[0];
                    avg_value = (value1 + value2) / 2;
                    series.Points[cnt].YValues[0] = avg_value;
                    series.Points.RemoveAt(cnt + 1);  // 두점을 평균낸뒤 한점을 지움
                }
            }
        }

        private void updateGraphOnly()
        {

            Chart chart = null;
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // 활성화된 창만 업데이트
                if (SystemParameter.ModuleEnable[mo] == false) continue;
                if (SystemParameter.ModuleOn[mo] == false) continue;

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // 활성화된 창만 업데이트
                    if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                    // i = channel number 0~ 3
                    // 창이 Defined되지 않은경우 업데이트 하지 않음
                    if (m_frmSfModule[mo].ChartMultiCH[ch].chart1 == null) continue;

                    chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                    chart.ChartAreas[0].RecalculateAxesScale();
                }
            }

            // VC 그래프 업데이트

            // 메인창 파라메터 업데이트
            {
                int mo = MainSelection.ModuleNumber;
                int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];
                lbTemperature.Text = valueSF[mo, ch].ToString("0.##");
                lbHumidity.Text = valueRTemp[mo, ch].ToString("0.##");

                if (tbY1MinValue.Text != valueSFMin[mo, ch].ToString()) tbY1MinValue.Text = valueSFMin[mo, ch].ToString();
                if (tbY1MaxValue.Text != valueSFMax[mo, ch].ToString()) tbY1MaxValue.Text = valueSFMax[mo, ch].ToString();
                if (tbY2MinValue.Text != valueRTempMin[mo, ch].ToString()) tbY2MinValue.Text = valueRTempMin[mo, ch].ToString();
                if (tbY2MaxValue.Text != valueRTempMax[mo, ch].ToString()) tbY2MaxValue.Text = valueRTempMax[mo, ch].ToString();

            }
        }

        private void OutputFileInit()
        {
            string outputPath = Application.StartupPath + "\\log\\" + System.DateTime.Now.ToString("yy-MM-dd") + "\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            fs = outputPath + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
            System.IO.File.WriteAllText(fs, "Start" + Environment.NewLine);

            if (cbValveControlEnable.Checked == true)
            {
                fs3 = outputPath + "VC" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
                //   textBoxLogs.AppendText("Filename for store : " + fs + Environment.NewLine);
                System.IO.File.WriteAllText(fs3, "Start" + Environment.NewLine);
            }
        }

        private void OutputValveFileInit()
        {
            string outputPath = Application.StartupPath + "\\log\\" + System.DateTime.Now.ToString("yy-MM-dd") + "\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            fs3 = outputPath + "VC" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
            //   textBoxLogs.AppendText("Filename for store : " + fs + Environment.NewLine);
            System.IO.File.WriteAllText(fs3, "Start" + Environment.NewLine);
        }

        private void cbY1Min_CheckedChanged(object sender, EventArgs e)
        {
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

            Boolean fgChecked = cbY1Min.Checked;
            float ValueGraph = GraphMin[mo, ch];
            TextBox tbText = tbY1Min;

            tbText.Enabled = fgChecked;
            fgGraphMin[mo, ch] = fgChecked;

            if (fgChecked)
            {
                if (Single.IsNaN(ValueGraph))
                {
                    // 그래프 최소값을 참조하여 MinData를 가지고 옴
                    tbText.Text = tbY1MinValue.Text;
                }
                else
                {
                    tbText.Text = ValueGraph.ToString();
                }
            }
            else
            {
                // Graph. Min is reverted to Auto Mode.
                tbText.Text = "";
            }
            KeyPressEventArgs etemp = new KeyPressEventArgs((char)Keys.Enter);
            Y1TextMin_KeyPress(sender, etemp);
        }

        private void cbY1Max_CheckedChanged(object sender, EventArgs e)
        {
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

            Boolean fgChecked = cbY1Max.Checked;
            float ValueGraph = GraphMax[mo, ch];
            TextBox tbText = tbY1Max;

            tbText.Enabled = fgChecked;
            fgGraphMax[mo, ch] = fgChecked;

            if (fgChecked)
            {
                if (Single.IsNaN(ValueGraph))
                {
                    // 그래프 최대값을 참조하여 Max Data를 가지고 옴
                    tbText.Text = tbY1MaxValue.Text;
                }
                else
                {
                    tbText.Text = ValueGraph.ToString();
                }
            }
            else
            {
                // Graph. Min is reverted to Auto Mode.
                tbText.Text = "";
            }
            KeyPressEventArgs etemp = new KeyPressEventArgs((char)Keys.Enter);
            Y1TextMax_KeyPress(sender, etemp);

        }

        private void cbY2Min_CheckedChanged(object sender, EventArgs e)
        {
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

            Boolean fgChecked = cbY2Min.Checked;
            float ValueGraph = GraphMin2[mo, ch];
            TextBox tbText = tbY2Min;

            tbText.Enabled = fgChecked;
            fgGraphMin2[mo, ch] = fgChecked;

            if (fgChecked)
            {
                if (Single.IsNaN(ValueGraph))
                {
                    // 그래프 최소값을 참조하여 MinData를 가지고 옴
                    tbText.Text = tbY2MinValue.Text;
                }
                else
                {
                    tbText.Text = ValueGraph.ToString();
                }
            }
            else
            {
                // Graph. Min is reverted to Auto Mode.
                tbText.Text = "";

                if (SystemParameter.MultiModuleOn)
                {
                    fgMultiChartRequestRefresh = true;
                }

            }
            KeyPressEventArgs etemp = new KeyPressEventArgs((char)Keys.Enter);
            Y2TextMin_KeyPress(sender, etemp);
        }

        private void cbY2Max_CheckedChanged(object sender, EventArgs e)
        {
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

            Boolean fgChecked = cbY2Max.Checked;
            float ValueGraph = GraphMax2[mo, ch];
            TextBox tbText = tbY2Max;

            tbText.Enabled = fgChecked;
            fgGraphMax2[mo, ch] = fgChecked;

            if (fgChecked)
            {
                if (Single.IsNaN(ValueGraph))
                {
                    // 그래프 최대값을 참조하여 Max Data를 가지고 옴
                    tbText.Text = tbY2MaxValue.Text;
                }
                else
                {
                    tbText.Text = ValueGraph.ToString();
                }
            }
            else
            {
                // Graph. Min is reverted to Auto Mode.
                //tbText.Text = "";  // 현재값 유지 
                if (SystemParameter.MultiModuleOn)
                {
                    fgMultiChartRequestRefresh = true;
                }

            }
            KeyPressEventArgs etemp = new KeyPressEventArgs((char)Keys.Enter);
            Y2TextMax_KeyPress(sender, etemp);
        }

        private void Y1TextMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox tbTemp;
                CheckBox cbTemp;

                tbTemp = tbY1Min;
                cbTemp = cbY1Min;

                int mo = MainSelection.ModuleNumber;
                int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

                if (cbTemp.CheckState == CheckState.Checked)
                {
                    if (tbTemp.Text != "")
                    {
                        try
                        {
                            float value = Convert.ToSingle(tbTemp.Text);
                            double maximum, minimum;
                            if (SystemParameter.ModuleOn[mo])
                            {
                                Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;

                                maximum = chart.ChartAreas[0].AxisY.Maximum;
                                minimum = chart.ChartAreas[0].AxisY.Minimum;

                                if (value < maximum)
                                {
                                    updateDisplayBox(String.Format("Set Y1 Min={0}", value));
                                    chart.ChartAreas[0].AxisY.Minimum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, minimum);
                                    value = (float)minimum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }
                                GraphMin[mo, ch] = value;

                            }

                            if (SystemParameter.MultiModuleOn)
                            {
                                Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;

                                maximum = chart.ChartAreas[0].AxisY.Maximum;
                                minimum = chart.ChartAreas[0].AxisY.Minimum;

                                if (value < maximum)
                                {
                                    updateDisplayBox(String.Format("Set Y1 Min={0}", value));
                                    chart.ChartAreas[0].AxisY.Minimum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, minimum);
                                    value = (float)minimum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }

                                GraphMin[mo, ch] = value;
                            }
                        }
                        catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }
                    }
                    else
                    {
                        // 빈칸으로 엔터를 한 경우, unchecked상태로 변경후 기존 기억하던 Min값을 지움
                        cbTemp.Checked = false;
                        GraphMin[mo, ch] = Single.NaN;
                    }
                }
                else if (cbTemp.CheckState == CheckState.Unchecked)
                {
                    try
                    {
                        updateDisplayBox(String.Format("Clear Y1 Min"));
                        if (SystemParameter.ModuleOn[mo])
                        {
                            Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                            chart.ChartAreas[0].AxisY.Minimum = double.NaN;
                        }
                        if (SystemParameter.MultiModuleOn)
                        {
                            Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                            chart.ChartAreas[0].AxisY.Minimum = double.NaN;
                        }
                    }
                    catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }

                }
            }
        }

        private void Y1TextMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox tbTemp;
                CheckBox cbTemp;

                tbTemp = tbY1Max;
                cbTemp = cbY1Max;

                int mo = MainSelection.ModuleNumber;
                int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

                if (cbTemp.CheckState == CheckState.Checked)
                {
                    if (tbTemp.Text != "")
                    {
                        try
                        {
                            float value = Convert.ToSingle(tbTemp.Text);
                            double maximum, minimum;

                            if (SystemParameter.ModuleOn[mo])
                            {
                                Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;

                                maximum = chart.ChartAreas[0].AxisY.Maximum;
                                minimum = chart.ChartAreas[0].AxisY.Minimum;

                                if (value > minimum)
                                {
                                    updateDisplayBox(String.Format("Set Y1 Max={0}", value));
                                    chart.ChartAreas[0].AxisY.Maximum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, maximum);
                                    value = (float)maximum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }

                                GraphMax[mo, ch] = value;
                            }

                            if (SystemParameter.MultiModuleOn)
                            {
                                Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;

                                maximum = chart.ChartAreas[0].AxisY.Maximum;
                                minimum = chart.ChartAreas[0].AxisY.Minimum;

                                if (value > minimum)
                                {
                                    updateDisplayBox(String.Format("Set Y1 Max={0}", value));
                                    chart.ChartAreas[0].AxisY.Maximum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, maximum);
                                    value = (float)maximum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }

                                GraphMax[mo, ch] = value;
                            }
                        }
                        catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }
                    }
                    else
                    {
                        // 빈칸으로 엔터를 한경우, unchecked상태로 변경후 기존 기억하던 Max값을 지움
                        cbTemp.Checked = false;
                        GraphMax[mo, ch] = Single.NaN;
                    }
                }
                else if (cbTemp.CheckState == CheckState.Unchecked)
                {
                    try
                    {
                        tbTemp.Text = "";
                        updateDisplayBox(String.Format("Clear Y1 Max"));
                        if (SystemParameter.ModuleOn[mo])
                        {
                            Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                            chart.ChartAreas[0].AxisY.Maximum = double.NaN;
                        }
                        if (SystemParameter.MultiModuleOn)
                        {
                            Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                            chart.ChartAreas[0].AxisY.Maximum = double.NaN;
                        }
                    }
                    catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }

                }
            }
        }

        private void Y2TextMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox tbTemp;
                CheckBox cbTemp;

                tbTemp = tbY2Min;
                cbTemp = cbY2Min;

                int mo = MainSelection.ModuleNumber;
                int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

                if (cbTemp.CheckState == CheckState.Checked)
                {
                    if (tbTemp.Text != "")
                    {
                        try
                        {
                            float value = Convert.ToSingle(tbTemp.Text);
                            double maximum, minimum;
                            if (SystemParameter.ModuleOn[mo])
                            {
                                Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                                maximum = chart.ChartAreas[0].AxisY2.Maximum;
                                minimum = chart.ChartAreas[0].AxisY2.Minimum;

                                if (value < maximum)
                                {
                                    updateDisplayBox(String.Format("Set Y2 Min={0}", value));
                                    chart.ChartAreas[0].AxisY2.Minimum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, minimum);
                                    value = (float)minimum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }

                                GraphMin2[mo, ch] = value;
                            }

                            if (SystemParameter.MultiModuleOn)
                            {
                                Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                                maximum = chart.ChartAreas[0].AxisY2.Maximum;
                                minimum = chart.ChartAreas[0].AxisY2.Minimum;

                                if (value < maximum)
                                {
                                    updateDisplayBox(String.Format("Set Y2 Min={0}", value));
                                    chart.ChartAreas[0].AxisY2.Minimum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, minimum);
                                    value = (float)minimum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }

                                GraphMin2[mo, ch] = value;
                            }

                        }
                        catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }
                    }
                    else
                    {
                        // 빈칸으로 엔터를 한경우, unchecked상태로 변경후 기존 기억하던 Min2값을 지움
                        cbTemp.Checked = false;
                        GraphMin2[mo, ch] = Single.NaN;
                    }

                }
                else if (cbTemp.CheckState == CheckState.Unchecked)
                {
                    try
                    {
                        updateDisplayBox(String.Format("Clear Y2 Min"));
                        if (SystemParameter.ModuleOn[mo])
                        {
                            Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                            chart.ChartAreas[0].AxisY2.Minimum = double.NaN;
                        }
                        if (SystemParameter.MultiModuleOn)
                        {
                            Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                            chart.ChartAreas[0].AxisY2.Minimum = double.NaN;
                        }

                    }
                    catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }
                }
            }
        }

        private void Y2TextMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox tbTemp;
                CheckBox cbTemp;

                tbTemp = tbY2Max;
                cbTemp = cbY2Max;

                int mo = MainSelection.ModuleNumber;
                int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

                if (cbTemp.CheckState == CheckState.Checked)
                {
                    if (tbTemp.Text != "")
                    {
                        try
                        {
                            float value = Convert.ToSingle(tbTemp.Text);
                            double maximum, minimum;

                            if (SystemParameter.ModuleOn[mo])
                            {
                                Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                                maximum = chart.ChartAreas[0].AxisY2.Maximum;
                                minimum = chart.ChartAreas[0].AxisY2.Minimum;

                                if (value > minimum)
                                {
                                    updateDisplayBox(String.Format("Set Y2 Max={0}", value));
                                    chart.ChartAreas[0].AxisY2.Maximum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, maximum);
                                    value = (float)maximum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }

                                GraphMax2[mo, ch] = value;
                            }
                            if (SystemParameter.MultiModuleOn)
                            {
                                Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                                maximum = chart.ChartAreas[0].AxisY2.Maximum;
                                minimum = chart.ChartAreas[0].AxisY2.Minimum;

                                if (value > minimum)
                                {
                                    updateDisplayBox(String.Format("Set Y2 Max={0}", value));
                                    chart.ChartAreas[0].AxisY2.Maximum = value;
                                }
                                else
                                {
                                    updateMinMaxText(tbTemp, maximum);
                                    value = (float)maximum;
                                    //updateDisplayBox("[Warning] Out of Range");
                                }

                                GraphMax2[mo, ch] = value;
                            }
                        }
                        catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }
                    }
                    else
                    {
                        // 빈칸으로 엔터를 한경우, unchecked상태로 변경후 기존 기억하던 Max2값을 지움
                        cbTemp.Checked = false;
                        GraphMax2[mo, ch] = Single.NaN;
                    }
                }
                else if (cbTemp.CheckState == CheckState.Unchecked)
                {
                    try
                    {
                        updateDisplayBox(String.Format("Clear Y2 Max"));
                        if (SystemParameter.ModuleOn[mo])
                        {
                            Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                            chart.ChartAreas[0].AxisY2.Maximum = double.NaN;
                        }
                        if (SystemParameter.MultiModuleOn)
                        {
                            Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                            chart.ChartAreas[0].AxisY2.Maximum = double.NaN;
                        }

                    }
                    catch (Exception ex) { updateDisplayBox(String.Format("[Warning] {0}", ex.Message)); }
                }
            }
        }

        private void updateMinMaxText(TextBox tbTemp, double value)
        {
            if (double.IsNaN(value))
            {
                tbTemp.Text = "";
            }
            else
            {
                tbTemp.Text = value.ToString();
            }
        }

        private void Y3TextMax_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Y3TextMin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Y4TextMax_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Y4TextMin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btTimeScale2H_Click(object sender, EventArgs e)
        {
            if (cbTimeStep.SelectedIndex == 0) changeDisplayScale();
            else cbTimeStep.SelectedIndex = 0;
        }

        private void btTimeScale1D_Click(object sender, EventArgs e)
        {
            if (cbTimeStep.SelectedIndex == 4) changeDisplayScale();
            else cbTimeStep.SelectedIndex = 4;
        }

        private void btTimeScale2d_Click(object sender, EventArgs e)
        {
            if (cbTimeStep.SelectedIndex == 6) changeDisplayScale();
            else cbTimeStep.SelectedIndex = 6;
        }

        private void btTimeScaleFullScale_Click(object sender, EventArgs e)
        {
            if (cbTimeStep.SelectedIndex == 26) changeDisplayScale();
            else cbTimeStep.SelectedIndex = 26;
        }

        private void updateScaleDisplay(Chart chart)
        {
            double firstOADate = chart.ChartAreas[0].AxisX.Minimum;
            double lastOADate = chart.ChartAreas[0].AxisX.Maximum;
            chart.ChartAreas[0].AxisX.Maximum = lastOADate;

            DateTime StartDate = DateTime.FromOADate(firstOADate);
            DateTime EndDate = DateTime.FromOADate(lastOADate);
            DateTime AxisMax = DateTime.FromOADate(chart.ChartAreas[0].AxisX.Maximum);

            DateTime scaleStartDate = DateTime.FromOADate(lastOADate);

            if (valueTimeStep.Day == 0)
            {
                scaleStartDate = scaleStartDate.AddHours(-1 * valueTimeStep.Hour);
            }
            else
            {
                scaleStartDate = scaleStartDate.AddDays(-1 * valueTimeStep.Day);
            }

            if (scaleStartDate.ToOADate() > firstOADate)
            {
                // 데이터량이 지정시간을 넘게 존재하여 스케일 표시
                DateTime axisLastDate = scaleStartDate;
                if (valueTimeStep.Day == 0)
                {
                    axisLastDate = axisLastDate.AddHours(valueTimeStep.Hour);
                    //  axisLastDate = axisLastDate.AddHours(1);
                }
                else
                {
                    axisLastDate = axisLastDate.AddDays(valueTimeStep.Day);
                    //  axisLastDate = axisLastDate.AddDays(1);
                }
                //chart.ChartAreas[0].AxisX.Maximum = axisLastDate.ToOADate();
                // To fix axis mismatch:
                // Chart1.ChartAreas(0).AxisX.IsMarginVisible = False !!
                chart.ChartAreas[0].AxisX.ScaleView.Zoom(scaleStartDate.ToOADate(), EndDate.ToOADate());
                chart.ChartAreas[0].RecalculateAxesScale();
            }
            else
            {
                DateTime axisLastDate = DateTime.FromOADate(firstOADate);
                if (valueTimeStep.Day == 0)
                {
                    axisLastDate = axisLastDate.AddHours(valueTimeStep.Hour);
                }
                else
                {
                    axisLastDate = axisLastDate.AddDays(valueTimeStep.Day);
                }

                // 데이터 량이 작음으로 Start~ 미래값으로 표시(축의 Max값이 미래값)
                if (valueTimeStep.Day >= 60) chart.ChartAreas[0].AxisX.Maximum = lastOADate;
                else chart.ChartAreas[0].AxisX.Maximum = axisLastDate.ToOADate();

                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas[0].RecalculateAxesScale();
            }
        }


        private void changeDisplayScale()
        {
            switch (cbTimeStep.SelectedIndex)
            {
                case 0: // 2 hour
                    valueTimeStep = new GraphTimeStep(0, 2); // (day, hour)
                    break;
                case 1: // 4 hour
                    valueTimeStep = new GraphTimeStep(0, 4);
                    break;
                case 2: // 8 hour
                    valueTimeStep = new GraphTimeStep(0, 8);
                    break;
                case 3: // 12 hour
                    valueTimeStep = new GraphTimeStep(0, 12);
                    break;
                case 4: // 1 day
                    valueTimeStep = new GraphTimeStep(1);
                    break;
                case 5: // 2 days
                    valueTimeStep = new GraphTimeStep(2);
                    break;
                case 6: // 3 days
                    valueTimeStep = new GraphTimeStep(3);
                    break;
                case 7: // 4 days
                    valueTimeStep = new GraphTimeStep(4);
                    break;
                case 8: // 5 days
                    valueTimeStep = new GraphTimeStep(5);
                    break;
                case 9: // 6 days
                    valueTimeStep = new GraphTimeStep(6);
                    break;
                case 10: // 1 week (7days)
                    valueTimeStep = new GraphTimeStep(7);
                    break;
                case 11: // 8 days
                    valueTimeStep = new GraphTimeStep(8);
                    break;
                case 12: // 9 days
                    valueTimeStep = new GraphTimeStep(9);
                    break;
                case 13: // 10 days
                    valueTimeStep = new GraphTimeStep(10);
                    break;
                case 14: // 11 days
                    valueTimeStep = new GraphTimeStep(11);
                    break;
                case 15: // 12 days
                    valueTimeStep = new GraphTimeStep(12);
                    break;
                case 16: // 13 days
                    valueTimeStep = new GraphTimeStep(13);
                    break;
                case 17: // 14 days
                    valueTimeStep = new GraphTimeStep(14);
                    break;
                case 18: // 16 days
                    valueTimeStep = new GraphTimeStep(16);
                    break;
                case 19: // 18 days
                    valueTimeStep = new GraphTimeStep(18);
                    break;
                case 20: // 20 days
                    valueTimeStep = new GraphTimeStep(20);
                    break;
                case 21: // 21 days
                    valueTimeStep = new GraphTimeStep(21);
                    break;
                case 22: // 23 days
                    valueTimeStep = new GraphTimeStep(23);
                    break;
                case 23: // 25 days
                    valueTimeStep = new GraphTimeStep(25);
                    break;
                case 24: // 27 days
                    valueTimeStep = new GraphTimeStep(27);
                    break;
                case 25: // 1 month (30days)
                    valueTimeStep = new GraphTimeStep(30);
                    break;
                case 26: // full scale  (2 month max.)
                    valueTimeStep = new GraphTimeStep(60);
                    break;
                default:
                    valueTimeStep = new GraphTimeStep(1);
                    break;
            }

            // mModuleArray
            double firstOADate, lastOADate;
            if (mModuleArray.Count > 0)
            {
                int index = mModuleArray.Count - 1;     // Last Index
                firstOADate = mModuleArray[0].OADate;
                lastOADate = mModuleArray[index].OADate;
            }
            else
            {
                return;
            }

            Chart chart = null;
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // 활성화된 창만 업데이트
                if (SystemParameter.ModuleEnable[mo] == false) continue;
                if (SystemParameter.ModuleOn[mo] == false) continue;

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // 활성화된 창만 업데이트
                    if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                    // 창이 Defined되지 않은경우 업데이트 하지 않음
                    if (m_frmSfModule[mo].ChartMultiCH[ch].chart1 == null) continue;

                    chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;

                    chart.ChartAreas["ChartArea1"].CursorX.Interval = 1;
                    chart.ChartAreas["ChartArea1"].CursorX.IntervalType = DateTimeIntervalType.Minutes;
                    chart.ChartAreas["ChartArea1"].CursorX.IntervalOffset = 2;

                    chart.ChartAreas["ChartArea1"].AxisX2.LabelStyle.Format = "yyyy/MM/dd";
                    chart.ChartAreas["ChartArea1"].AxisX2.IntervalType = DateTimeIntervalType.Days;
                    chart.ChartAreas["ChartArea1"].AxisX2.Interval = 1;

                    chart.ChartAreas[0].AxisX.Minimum = firstOADate;
                    chart.ChartAreas[0].AxisX.Maximum = lastOADate;

                    //Date Type[yyyy-MM-dd HH:mm:ss]
                    if (valueTimeStep.Day >= 60)       // (Full Scalce ~ 2 Months]
                    {
                        chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "MM/dd";
                        chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Days;
                        chart.ChartAreas["ChartArea1"].AxisX.Interval = 14;
                    }
                    else if (valueTimeStep.Day >= 30)       // (2 Months ~ 1 Month]
                    {
                        chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "MM/dd";
                        chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Days;
                        chart.ChartAreas["ChartArea1"].AxisX.Interval = 7;
                    }
                    else if (valueTimeStep.Day >= 14)       // (1 Month ~ 1 week]
                    {
                        chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "M/dd";
                        chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Days;
                        chart.ChartAreas["ChartArea1"].AxisX.Interval = 3;
                    }
                    else if (valueTimeStep.Day >= 7)       // (1 Month ~ 1 week]
                    {
                        chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "M/dd";
                        chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Days;
                        chart.ChartAreas["ChartArea1"].AxisX.Interval = 3;
                    }
                    else if (valueTimeStep.Day >= 1)     // (1week ~ 1 day]
                    {
                        if (valueTimeStep.Day <= 1)
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "M/dd\nH";
                            chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Hours;
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 6;
                        }
                        else if (valueTimeStep.Day <= 2)
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "M/dd\nH";
                            chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Hours;
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 12;
                        }
                        else if (valueTimeStep.Day <= 4)
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "M/dd";
                            chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Days;
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        }
                        else if (valueTimeStep.Day <= 6)
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "M/dd";
                            chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Days;
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 2;
                        }

                    }
                    else  //if (valueTimeStep.Day == 0)    // (1day ~ 0]
                    {
                        chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "H:mm";
                        chart.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Minutes;
                        if (valueTimeStep.Hour <= 2)
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 30;
                        }
                        else if (valueTimeStep.Hour <= 4)
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 60;
                        }
                        else if (valueTimeStep.Hour <= 8)
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 120;
                        }
                        else
                        {
                            chart.ChartAreas["ChartArea1"].AxisX.Interval = 180;
                        }
                    }


                    // 재로드시 Max < Min인경우 에러발생, 둘중 하나라도 NaN인경우 모두 NaN처리
                    double maximum, minimum;

                    maximum = chart.ChartAreas[0].AxisY.Maximum;
                    minimum = chart.ChartAreas[0].AxisY.Minimum;

                    if ((!double.IsNaN(minimum)) && (!double.IsNaN(maximum)))
                    {
                        if (minimum >= maximum)
                        {
                            chart.ChartAreas[0].AxisY.Minimum = double.NaN;
                            chart.ChartAreas[0].AxisY.Maximum = double.NaN;

                        }
                    }
                    else
                    {
                        chart.ChartAreas[0].AxisY.Minimum = double.NaN;
                        chart.ChartAreas[0].AxisY.Maximum = double.NaN;
                    }

                    // Change Scale
                    updateScaleDisplay(chart);
                }
            }

            updateGraphOnly();

            //  Debug.WriteLine(String.Format("TEST:{0}/Default Time Step : {2} {1}", this.ToString(), valueTimeStep.Hour, valueTimeStep.Day));
            //  Debug.WriteLine(String.Format("TEST:{0}", StartMaxTime.ToString()));

        }
        // Time Scale을 변경
        // 기준: mModuleArray
        private void cbTimeStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeDisplayScale();
        }

        private void updateTopMostState()
        {
            if (cbAlwaysOnTop.CheckState == CheckState.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void cbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            updateTopMostState();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Next Key
            SfModuleSelectedItem++;
            if ((SfModuleSelectedItem < 1) || (SfModuleSelectedItem > SFModuleLength))
            {
                SfModuleSelectedItem = 1;
            }
            gbSfModule.Text = String.Format("SF Module #{0}", SfModuleSelectedItem.ToString("D2"));
            //btCalibration.Text = String.Format(" M#{0} Calibration", (MainSelection.ModuleNumber + 1).ToString("D2"));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Previous Key
            SfModuleSelectedItem--;
            if ((SfModuleSelectedItem < 1) || (SfModuleSelectedItem > SFModuleLength))
            {
                SfModuleSelectedItem = 10;
            }
            gbSfModule.Text = String.Format("SF Module #{0}", SfModuleSelectedItem.ToString("D2"));
            //btCalibration.Text = String.Format(" M#{0} Calibration", (MainSelection.ModuleNumber + 1).ToString("D2"));
        }


        private Boolean sendReceiveCommandToModule(int mo, int cmd, int timeout)
        {
            int retryCount = 3;
            Boolean retValue = false;
            UInt16 commandModuleNumber;

            commandModuleNumber = (UInt16)(mo + 1);

            for (int i = 0; i < retryCount; i++)
            {
                //sendCommandToModule(commandModuleNumber, cmd);
                if (cmd == COMM_CMD_START_CPT)      // Start Command는 Broadcast방식으로 모듈번호는 00
                {
                    commandModuleNumber = 0;
                }
                sendCommandToModuleCPT(commandModuleNumber, cmd);
                if (cmd == COMM_CMD_START_CPT)      // Start Command는 Broadcast방식으로 return없이 시작함
                {
                    retValue = true;
                    break;
                }
                else
                {
                    waitRespondDataFromModule(timeout);
                    if (RespondDataReceived == true)
                    {
                        retValue = true;
                        break;
                    }
                }
            }
            CommandBufferClear();
            if (retValue == false)
            {
                // Command Fail

                System.Array.Clear(recvBuf, 0x00, RECV_BUF_SIZE);
            }
            else
            {
                // Command OK

            }

            return retValue;
        }

        /* 
         * sendCommandToModule
         *
         *  Input: Module Number
         *         Command
         */
        private string sendCommandToModule(UInt16 ModuleNumber, int cmd)
        {
            //int retryCount = 3;
            byte packet_length = 0;
            byte command_byte = 0;
            byte index = 0;

            string readString = "";

            byte[] dl_start = new byte[18];

            // Head(BP0 BP1)
            dl_start[index++] = CMD_HEAD_0;
            dl_start[index++] = CMD_HEAD_1;

            // Packet length(BP2 BP3) (update with pacekt_length)
            dl_start[index++] = 0;
            dl_start[index++] = unchecked((byte)~0);

            // Module Number(BP4 BP5) (update with module_number)
            RespondModuleNumber = ModuleNumber;
            byte[] RespondModuleNumberBytes = BitConverter.GetBytes(RespondModuleNumber);
            dl_start[index++] = RespondModuleNumberBytes[1];    // MSB
            dl_start[index++] = RespondModuleNumberBytes[0];    // LSB

            // CMD(BP6 BP7) 
            command_byte = (byte)cmd;
            /*
                if (cmd == 1) command_byte = COMM_CMD_TEMPERATURE;    
                else if (cmd == 2) command_byte = COMM_CMD_HUMIDITY;    
                else if (cmd == 3) command_byte = COMM_CMD_START;    
                else if (cmd == 4) command_byte = COMM_CMD_FINISH;    
                else if (cmd == 5) command_byte = COMM_CMD_TUR;     
                else if (cmd == 6) command_byte = COMM_CMD_CALIBRATION;   
            */

            dl_start[index++] = command_byte;
            dl_start[index++] = unchecked((byte)~command_byte);

            // DATA LENGTH(BP8 BP9)
            byte data_length = 4;
            dl_start[index++] = data_length;
            dl_start[index++] = unchecked((byte)~data_length);

            // DATA 4 BYTE Dummy
            dl_start[index++] = 0xAB;
            dl_start[index++] = 0xCD;

            dl_start[index++] = 0xEF;
            dl_start[index++] = 0x00;

            // Check Sum(BP10+DATALENGTH, BP11+DATALENGTH) (C/S from Module Number(BP4) ~ DATA) 
            int CheckSum = 0;
            for (int i = START_MODULE_NUM_0; i < (START_DATA_PACKET + data_length); i++)
            {
                CheckSum += dl_start[i];
            }

            byte[] CheckSumBytes = BitConverter.GetBytes(CheckSum);
            dl_start[index++] = CheckSumBytes[1];
            dl_start[index++] = CheckSumBytes[0];

            // TAIL
            dl_start[index++] = CMD_TAIL_0;
            dl_start[index++] = CMD_TAIL_1;

            // Update Packet length(BP2 BP3)
            packet_length = (byte)(index - SIZE_HEAD - SIZE_PKT_LENGTH);
            //  (update with pacekt_length)
            dl_start[START_PKT_LENGTH_0] = packet_length;
            dl_start[START_PKT_LENGTH_1] = unchecked((byte)~packet_length);

            if (cmd == COMM_CMD_START) updateListBox(String.Format("CMD#{0}[STR]", RespondModuleNumber.ToString()));
            else if (cmd == COMM_CMD_FINISH) updateListBox(String.Format("CMD#{0}[FIN]", RespondModuleNumber.ToString()));
            else if (cmd == COMM_CMD_TUR) updateListBox(String.Format("CMD#{0}[TUR]", RespondModuleNumber.ToString()));
            else if (cmd == COMM_CMD_CALIBRATION) updateListBox(String.Format("CMD#{0}[CAL]", RespondModuleNumber.ToString()));
            else updateListBox(String.Format("CMD#{0}:{1}", RespondModuleNumber.ToString(), cmd));

            if ((cbDebugLog.Checked) && (tbDebugLevel.Text == "level88"))
            {
                StringBuilder strCommand = new StringBuilder();

                strCommand.Clear();
                strCommand.Append("C:");
                for (int cnt = 0; cnt < index; cnt++)
                {
                    strCommand.Append(String.Format("{0:X2} ", dl_start[cnt]));
                }

                // Debug Log Display
                updateListBox(strCommand.ToString());
            }

            //for (int i = 0; i < retryCount; i++)
            {
                if (Port.IsOpen)
                {
                    try
                    {
                        Port.DiscardInBuffer();
                        Port.Write(dl_start, 0, index);
                        RespondDataErrorCode = 0x00;
                    }
                    catch (TimeoutException)
                    {
                        updateListBox("ACK from Arduino does not match.");
                        readString = "ERROR";
                        RespondDataErrorCode = 0x51;
                    }
                    catch (Exception)
                    {
                        updateListBox("Error during communicate with Arduino.");
                        readString = "ERROR";
                        RespondDataErrorCode = 0x52;
                    }
                }
                else
                {
                    updateDisplayBox("[ERR] Port is not available.");
                    readString = "ERROR";
                    RespondDataErrorCode = 0x53;

                    // 18/03/30 커넥션 복구 시도
                    updateDisplayBox("Try recovering COM Port...");
                    try
                    {
                        ComPortUpdate();
                        ComPortConnect(strSavePortName);
                        if (cbComPort.Items.Count > 0)
                        {
                            cbComPort.SelectedIndex = 0;
                            for (int i = 0; i < cbComPort.Items.Count; i++)
                            {
                                if (strSavePortName == cbComPort.Items[i].ToString())
                                {
                                    cbComPort.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        updateDisplayBox("failed.");
                    }
                }

                //break;
            }

            return readString;
        }

        /* 
         * sendCommandToModule CPT ver.
         *
         */
        private string sendCommandToModuleCPT(UInt16 ModuleNumber, int cmd)
        {
            byte packet_length = 0;
            byte command_byte = 0;
            byte index = 0;

            string readString = "";

            byte[] dl_start = new byte[18];

            // Head(BP0 BP1)
            dl_start[index++] = CMD_HEAD_0;
            dl_start[index++] = CMD_HEAD_1;

            // Packet length(BP2 BP3) (update with pacekt_length)
            dl_start[index++] = 0;
            dl_start[index++] = unchecked((byte)~0);

            // Module Number(BP4 BP5) (update with module_number)
            RespondModuleNumber = ModuleNumber;
            byte[] RespondModuleNumberBytes = BitConverter.GetBytes(RespondModuleNumber);
            dl_start[index++] = RespondModuleNumberBytes[1];    // MSB
            dl_start[index++] = RespondModuleNumberBytes[0];    // LSB

            // CMD(BP6 BP7) 
            command_byte = (byte)cmd;

            dl_start[index++] = command_byte;
            dl_start[index++] = unchecked((byte)~command_byte);

            // DATA LENGTH(BP8 BP9)
            byte data_length = 0;
            dl_start[index++] = data_length;
            dl_start[index++] = unchecked((byte)~data_length);

            // Check Sum(BP10+DATALENGTH, BP11+DATALENGTH) (C/S from Module Number(BP4) ~ DATA) 
            int CheckSum = 0;
            for (int i = START_MODULE_NUM_0; i < (START_DATA_PACKET + data_length); i++)
            {
                CheckSum += dl_start[i];
            }

            byte[] CheckSumBytes = BitConverter.GetBytes(CheckSum);
            dl_start[index++] = CheckSumBytes[1];
            dl_start[index++] = CheckSumBytes[0];

            // TAIL
            dl_start[index++] = CMD_TAIL_0;
            dl_start[index++] = CMD_TAIL_1;

            // Update Packet length(BP2 BP3)
            packet_length = (byte)(index - SIZE_HEAD - SIZE_PKT_LENGTH);
            //  (update with pacekt_length)
            dl_start[START_PKT_LENGTH_0] = packet_length;
            dl_start[START_PKT_LENGTH_1] = unchecked((byte)~packet_length);

            if (cmd == COMM_CMD_START_CPT) updateListBox(String.Format("CMD#B[str]"));
            else if (cmd == COMM_CMD_FINISH_CPT) updateListBox(String.Format("CMD#{0}[fin]", RespondModuleNumber.ToString()));
            else if (cmd == COMM_CMD_TUR_CPT) updateListBox(String.Format("CMD#{0}[tur]", RespondModuleNumber.ToString()));
            else if (cmd == COMM_CMD_CALIBRATION_CPT) updateListBox(String.Format("CMD#{0}[cal]", RespondModuleNumber.ToString()));
            else updateListBox(String.Format("CMD#{0}:{1}", RespondModuleNumber.ToString(), cmd));

            if ((cbDebugLog.Checked) && (tbDebugLevel.Text == "level88"))
            {
                StringBuilder strCommand = new StringBuilder();

                strCommand.Clear();
                strCommand.Append("C:");
                for (int cnt = 0; cnt < index; cnt++)
                {
                    strCommand.Append(String.Format("{0:X2} ", dl_start[cnt]));
                }

                // Debug Log Display
                updateListBox(strCommand.ToString());
            }

            //for (int i = 0; i < retryCount; i++)
            {
                if (Port.IsOpen)
                {
                    try
                    {
                        Port.DiscardInBuffer();
                        Port.Write(dl_start, 0, index);
                        RespondDataErrorCode = 0x00;
                    }
                    catch (TimeoutException)
                    {
                        updateListBox("ACK from Arduino does not match.");
                        readString = "ERROR";
                        RespondDataErrorCode = 0x51;
                    }
                    catch (Exception)
                    {
                        updateListBox("Error during communicate with Arduino.");
                        readString = "ERROR";
                        RespondDataErrorCode = 0x52;
                    }
                }
                else
                {
                    updateDisplayBox("[ERR] Port is not available.");
                    readString = "ERROR";
                    RespondDataErrorCode = 0x53;

                    // 18/03/30 커넥션 복구 시도
                    updateDisplayBox("Try recovering COM Port...");
                    try
                    {
                        ComPortUpdate();
                        ComPortConnect(strSavePortName);
                        if (cbComPort.Items.Count > 0)
                        {
                            cbComPort.SelectedIndex = 0;
                            for (int i = 0; i < cbComPort.Items.Count; i++)
                            {
                                if (strSavePortName == cbComPort.Items[i].ToString())
                                {
                                    cbComPort.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        updateDisplayBox("failed.");
                    }
                }

                //break;
            }

            return readString;
        }

        // timeout unit = 10ms
        private Boolean waitRespondDataFromModule(int timeout)
        {
            int waitTimeout = timeout;  // 0.5seconds
            while (RespondDataReceived == false)
            {
                Delay(10);      // wait 10ms
                if (waitTimeout > 0)
                {
                    waitTimeout--;
                    if (RespondDataErrorCode != 0x00)
                    {

                        if (RespondDataErrorCode == COMM_ERROR_CODE_M_NUMBER_MISMATCH)
                        {
                            updateListBox("[ERR] M_Number Mismatch");
                        }
                        else if (RespondDataErrorCode == COMM_ERROR_CODE_CHECKSUM_ERROR)
                        {
                            updateListBox("[ERR] Check Sum Error");
                        }
                        else
                        {
                            updateListBox(String.Format("[ERR] Code=0x{0}", RespondDataErrorCode.ToString("x2")));
                        }
                        break;      // Error occurs
                    }
                }
                else
                {
                    updateListBox("Respond Time Out");
                    break;      // Time Out
                }

            }

            if (RespondDataReceived == true)
            {

                if ((cbDebugLog.Checked) && (tbDebugLevel.Text == "level88"))
                {
                    StringBuilder strCommand = new StringBuilder();

                    strCommand.Clear();
                    strCommand.Append("R:");
                    for (int cnt = 0; cnt < recvBufCnt; cnt++)
                    {
                        strCommand.Append(String.Format("{0:X2} ", recvBuf[cnt]));
                    }

                    // Debug Log Display
                    updateListBox(strCommand.ToString());
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        private void btCmdSend2_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            // Start
            //sendCommandToModule(1, COMM_CMD_START);
            sendCommandToModuleCPT(1, COMM_CMD_START_CPT);
            waitRespondDataFromModule(50);
            if (RespondDataReceived == true)
            {
                RespondDataReceived = false;

                updateListBox(String.Format("C[{0}] RET:={1}", recvBuf[10].ToString("X"), recvBuf[15].ToString("X")));
                m_valuePrimary = recvBuf[15];
                CommandBufferClear();
            }

        }

        private void btCmdSend_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            // Read
            //sendCommandToModule(1, COMM_CMD_FINISH);
            sendCommandToModuleCPT(1, COMM_CMD_FINISH_CPT);
            waitRespondDataFromModule(50);
            if (RespondDataReceived == true)
            {
                RespondDataReceived = false;

                updateListBox(String.Format("C[{0}] RET:={1}", recvBuf[10].ToString("X"), recvBuf[15].ToString("X")));
                m_valueSecondary = recvBuf[15];
                CommandBufferClear();
            }

        }

        private void cmdTUR_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            RespondDataReceived = false;

            // TUR
            ushort mNumber = (ushort)nudModuleNumber.Value;
            if (mNumber > SFModuleLength)
            {
                mNumber = 1;
                nudModuleNumber.Value = 1;
            }
            sendCommandToModuleCPT(mNumber, COMM_CMD_TUR_CPT);
            //sendCommandToModule(mNumber, COMM_CMD_TUR);
            waitRespondDataFromModule(50);
            if (RespondDataReceived == true)
            {
                RespondDataReceived = false;

                updateListBox(String.Format("C[{0}] RET:={1} {2}", recvBuf[6].ToString("X"), recvBuf[10].ToString("X"), recvBuf[11].ToString("X")));
                //m_valuePrimary = recvBuf[13];
            }
            CommandBufferClear();
        }


        private int commandState = 0;
        private int[] commandModuleState = new int[SFModuleLength];

        void parseSerialCommand()
        {
            for (int cnt = 0; cnt < readCnt; cnt++)
            {
                byte ReceivedData;

                ReceivedData = recvRawBuf[cnt];
                if (recvBufCnt < 4)
                {
                    if (recvBufCnt == START_HEAD_0)
                    {
                        if (ReceivedData == RSP_HEAD_0)
                        {
                            recvBuf[recvBufCnt++] = ReceivedData;
                            //setTimeOut(3);
                        }
                    }
                    else if (recvBufCnt == START_HEAD_1)
                    {
                        if (ReceivedData == RSP_HEAD_1) recvBuf[recvBufCnt++] = ReceivedData;
                        else CommandBufferClear();
                    }
                    else if (recvBufCnt == START_PKT_LENGTH_0)
                    {
                        recvBuf[recvBufCnt++] = ReceivedData;
                        recvCommandLen = ReceivedData;
                    }
                    else if (recvBufCnt == START_PKT_LENGTH_1)
                    {
                        if (recvCommandLen == (byte)~ReceivedData) recvBuf[recvBufCnt++] = ReceivedData;
                        else CommandBufferClear();
                    }
                }
                else
                {
                    recvBuf[recvBufCnt++] = ReceivedData;
                    if (recvCommandLen > 0) recvCommandLen--;

                    if (recvBufCnt == START_DATA_PACKET) // Start Point of DATA Packet
                    {
                        if (recvBuf[START_RSP_LENGTH_0] != (byte)~recvBuf[START_RSP_LENGTH_1])
                        {
                            // Command Length Mismatch
                            RespondDataErrorCode = COMM_ERROR_CODE_RSPLEN_MISMATCH;    // Model Number Mismatch
                            CommandBufferClear();
                        }
                    }

                    if (recvCommandLen == 0)
                    {
                        if (recvBufCnt > SIZE_ZERO_DATA_PACKET)
                        {
                            // Check Total Length
                            if (recvBufCnt == (recvBuf[START_PKT_LENGTH_0] + SIZE_HEAD + SIZE_PKT_LENGTH))
                            {
                                // Check CRC
                                if (checkCRCError() == 0)
                                {
                                    if (checkModuleNumber() == 0)
                                    {
                                        // Check TAIL
                                        if (recvBuf[recvBufCnt - 2] == RSP_TAIL_0)
                                        {
                                            if (recvBuf[recvBufCnt - 1] == RSP_TAIL_1)
                                            {
                                                // Respond Data Received 
                                                RespondDataReceived = true;
                                                //setTimeOut(0);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        RespondDataErrorCode = COMM_ERROR_CODE_M_NUMBER_MISMATCH;    // Model Number Mismatch
                                    }
                                }
                                else
                                {
                                    RespondDataErrorCode = COMM_ERROR_CODE_CHECKSUM_ERROR;    // Check Sum Error
                                }
                            }

                            if (!RespondDataReceived)
                            {
                                // Illegal Packet Command
                                CommandBufferClear();
                            }

                        }
                    }
                }
            }
        }

        private void CommandBufferClear()
        {
            RespondDataReceived = false;
            recvBufCnt = 0;
            recvCommandLen = 0;

            //setTimeOut(0);
            //System.Array.Clear(recvBuf, 0x00, RECV_BUF_SIZE);
        }

        // CRC Check 0: ok, 1: fail
        private byte checkCRCError()
        {
            /*
            unsigned short retCRC, cmdCRC;

            retCRC = 0;
            // Check Sum
            for (tempCnt = 0; tempCnt < SerialCommandBuffer[START_CMD_LENGTH_0] + 4; tempCnt++)
            {
                retCRC += SerialCommandBuffer[tempCnt + START_CMD_0];
            }

            cmdCRC = SerialCommandBuffer[START_DATA_PACKET + SerialCommandBuffer[START_CMD_LENGTH_0]];
            cmdCRC <<= 8;
            cmdCRC += SerialCommandBuffer[START_DATA_PACKET + SerialCommandBuffer[START_CMD_LENGTH_0] + 1];

            // retCRC = crc16_ccitt(SerialCommandBuffer+START_CMD_0, SerialCommandBuffer[START_CMD_LENGTH_0]+4);

            if (retCRC == cmdCRC)
            {
                return 0;
            }
            else
            {
                Serial.println("CRC Error:");
                Serial.println(retCRC, HEX);
                Serial.println(cmdCRC, HEX);
                return 1;
            }
            */
            return 0;
        }

        // Check Module Number 0: matched, 1: mismatched
        private byte checkModuleNumber()
        {
            byte ret;
            UInt16 tempModuleNumber;

            tempModuleNumber = (UInt16)recvBuf[START_MODULE_NUM_0];
            tempModuleNumber <<= 8;
            tempModuleNumber |= (UInt16)recvBuf[START_MODULE_NUM_1];

            if (tempModuleNumber == RespondModuleNumber)
            {
                ret = 0;
            }
            else
            {
                this.Invoke(new EventHandler(delegate
                {
                    updateListBox(String.Format("C#={0}, R#={1}", RespondModuleNumber, tempModuleNumber));
                }));

                ret = 1;
            }
            return (ret);
        }

        private int command_statue;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Boolean retValue;
            int commandCurrentState;

            flagTimerInProgress = true;
            timer1.Stop();      // Stop during measurement.

            DateTime now = System.DateTime.Now;
            lbDateTime.Text = String.Format("Current Time: {0}", now.ToString("yyyy-MM-dd HH:mm:ss"));

            flagAllowAction = false;

            if (commandState == 0)
            {
                //////////////////////////////////
                // STATE 0: Check Activated Module
                //////////////////////////////////
                commandCurrentState = 0;
                // 채널 running동안에 그래픽 재로드, 데이터백업 허용

                flagAllowAction = true;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    // Enable된 창만 활성화
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if (mo > 0)
                        {
                            //                            commandModuleState[mo] = commandCurrentState;
                            //                            continue;
                        }
                        
                        // 2018/07/27 임시저장되는 변수를 Clear
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            valueSF[mo, ch] = 0;
                            valueRTemp[mo, ch] = 0;
                            valueTemperature[mo] = 0;
                            valueHumidity[mo] = 0;

                            arrayInitialData[mo, ch] = 0;
                            arrayInitialData[mo, ch] = 0;
                            arrayHeatedData[mo, ch] = 0;
                        }

                        retValue = sendReceiveCommandToModule(mo, COMM_CMD_TUR_CPT, 80);
                        RespondDataReceived = false;
                        if (retValue == true)
                        {
                            updateListBox("Conn. OK");
                            updateProgressBar(mo, 10, true);
                            subCountProgressBar = 0;
                            currentMeasuringChannel = -1;

                            commandModuleState[mo] = 1;
                        }
                        else
                        {
                            updateListBox("Conn. Fail");
                            updateProgressBar(mo, 0, false);
                            subCountProgressBar = 0;
                            currentMeasuringChannel = -1;

                            commandModuleState[mo] = commandCurrentState;
                        }
                    }
                    Delay(20);
                }

                int ActivatedModuleCount = 0;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (commandModuleState[mo] == 1)
                    {
                        ActivatedModuleCount++;
                    }
                }
                updateListBox(String.Format("{0} Module(s) Activated", ActivatedModuleCount));
                commandState++;

                goto timer1_Tick_endprocess;
            }
            else if (commandState == 1)
            {
                //////////////////////////////////
                // STATE 1: Broadcasting START 
                //////////////////////////////////
                commandCurrentState = 1;
                // 채널 running동안에 그래픽 재로드, 데이터백업 허용
                flagAllowAction = true;
                retValue = sendReceiveCommandToModule(0xff, COMM_CMD_START_CPT, 80);
                updateListBox("Broadcasting Start");
                updateProgressBar(0, 10, true);
                subCountProgressBar = 0;
                currentMeasuringChannel = -1;

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (commandModuleState[mo] == commandCurrentState)   // STATE 1단계의 모듈만 시작된것으로 간주
                    {
                        commandModuleState[mo]++;
                    }
                }
                commandState++;
            }
            else if (commandState == 2)
            {
                //////////////////////////////////
                // STATE 2: TUR
                //////////////////////////////////
                commandCurrentState = 2;
                // 채널 running동안에 그래픽 재로드, 데이터백업 허용
                flagAllowAction = true;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    // Enable된 창만 활성화
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if (commandModuleState[mo] == commandCurrentState)       // STATE 2단계의 모듈만 상태확인
                        {
                            retValue = sendReceiveCommandToModule(mo, COMM_CMD_TUR_CPT, 80);
                            if (retValue == true)
                            {
                                if (recvBuf[11] == 1)       // BUSY
                                {
                                    updateListBox(String.Format("RET: BUSY CH {0}", recvBuf[10] + 1));
                                    // 1번 2번 3번 4번 채널 running동안에 그래픽 재로드, 데이터백업 허용
                                    if (recvBuf[10] < 4)
                                    {
                                        flagAllowAction = true;

                                        int moSelected = MainSelection.ModuleNumber;
                                        if (mo == moSelected)
                                        {
                                            int chNumber = recvBuf[10];
                                            if (chNumber != currentMeasuringChannel)
                                            {
                                                // 측정채널이 변경된경우 값세팅 다시함
                                                int value2 = 10 + (chNumber * 20);
                                                updateProgressBar(mo, value2, true);
                                                currentMeasuringChannel = chNumber;
                                            }
                                            else
                                            {
                                                updateProgressBar(mo, 999, true);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    updateListBox(String.Format("RET: OK"));
                                    updateProgressBar(mo, 90, true);

                                    if (commandModuleState[mo] == commandCurrentState)   // STATE 2단계로 TUR OK가 된경우
                                    {
                                        commandModuleState[mo]++;
                                    }
                                }

                            }
                            else
                            {
                                updateListBox("RET: TUR Fail");
                                updateProgressBar(mo, 0, false);

                                if (commandModuleState[mo] == 2)   // STATE 2단계로 TUR Fail 된경우
                                {
                                    commandModuleState[mo]++;
                                }

                            }
                        }
                    }
                    Delay(20);
                }

                int RemainedModuleCount = 0;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (commandModuleState[mo] == commandCurrentState)
                    {
                        RemainedModuleCount++;
                    }
                }

                if (RemainedModuleCount > 0)
                {
                    updateListBox(String.Format("{0} Module(s) Remained", RemainedModuleCount));
                }
                else
                {
                    commandState++;
                    goto timer1_Tick_endprocess;
                }
            }
            else if (commandState == 3)
            {
                //////////////////////////////////
                // STATE 3: FINISH
                //////////////////////////////////
                commandCurrentState = 3;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if (commandModuleState[mo] == commandCurrentState)       // STATE 3단계의 모듈만 상태확인
                        {
                            retValue = sendReceiveCommandToModule(mo, COMM_CMD_FINISH_CPT, 100);
                            if (retValue == true)
                            {
                                RespondDataReceived = false;

                                if ((recvBuf[6] == COMM_CMD_TUR_CPT) && (recvBuf[11] == 1))  // Check Busy
                                {
                                    updateListBox(String.Format("RET: BUSY CH {0}", recvBuf[10] + 1));
                                }
                                else
                                {
                                    updateListBox(String.Format("RET: OK"));
                                    updateModuleResultData(mo);
                                    updateProgressBar(mo, 100, true);

                                    if (commandModuleState[mo] == commandCurrentState)   // STATE 3단계로 정상데이터가 읽힘
                                    {
                                        commandModuleState[mo]++;
                                    }
                                }
                            }
                            else
                            {
                                //updateListBox("RET: FIN Fail");
                                // 2018/07/27 update 00 data when fail
                                updateModuleResultData(mo);
                                updateProgressBar(mo, 0, false);
                                if (commandModuleState[mo] == commandCurrentState)   // STATE 3단계로 Fail 된경우
                                {
                                    commandModuleState[mo]++;
                                }
                            }
                        }
                    }
                    Delay(50);
                }

                int RemainedModuleCount = 0;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (commandModuleState[mo] == commandCurrentState)
                    {
                        RemainedModuleCount++;
                    }
                }

                if (RemainedModuleCount > 0)
                {
                    updateListBox(String.Format("{0} Module(s) Remained", RemainedModuleCount));
                }
                else
                {
                    commandState = 0;

                    progressBar1.PerformStep();

                    updateListBox(String.Format("Finished"));

                    updateDataBase();
                    CommandBufferClear();

                    if ((SystemParameter.ValveControlOn) && (VCParameter.EventStarted) && (VCParameter.EventActivated))
                    {
                        updateListBox("Execute Valve Control");
                        VCParameter.EventActivated = false;

                        // Valve Event Test
                        sendCommandToModule(VALUE_MODULE_NUMBER_VALVE_CONTROL, COMM_CMD_VALVE_CONTROL);
                        waitRespondDataFromModule(100);

                        // 55 aa 0e f1 20 00 00 00 04 fb 42 34 00 ff 01 1f 0f f0
                        // +0d                           +10d                 +17d
                        if (RespondDataReceived == true)
                        {
                            RespondDataReceived = false;

                            if ((recvBuf[10] == 0x23) && (recvBuf[15] == 1))  // Check Busy
                            {
                                updateListBox(String.Format("RET: BUSY CH {0}", recvBuf[14] + 1));
                            }
                            else
                            {
                                m_SampleCount++;
                                updateListBox(String.Format("RET: OK"));
                                updateListBox(String.Format("C[{0}] RET", recvBuf[10].ToString("X")));
                            }
                            CommandBufferClear();
                        }
                    }
                    goto timer1_Tick_endprocess;
                }
            }

            timer1_Tick_endprocess:
            if (flagStarted)
            {
                updateListBox("Start");
                timer1.Start();
            }
            else
            {
                updateListBox("Stop Measurement");
                queueStatusSFProg("sfstatus", "Program is stopped.");
            }

            if (flagAllowAction == false)
            {
                if (this.Cursor != Cursors.No)
                {
                    this.Cursor = Cursors.No;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Default)
                {
                    this.Cursor = Cursors.Default;
                }
            }

            // factory setting 진입용 코드
            if (FactorySetupOpenCount > 0) FactorySetupOpenCount = 0;
#if false           // 2017/10/20
            // Auto Tm Control Flag조정
            int currentHour = Convert.ToInt32(now.ToString("HH"));
            if (flagAutoTmRequest == false)  // 00:00인경우 Request Setting
            {
                if (currentHour == 0)    // 00h 00m ~ 00h 59m
                {
                    updateListBox("Request Tm Adjustment.");
                    flagAutoTmRequest = true;
                }
            }
            else
            {   // Flag가 True인경우 6시가 넘으면 AutoTm을 Start
                if (currentHour >= 6)   //6
                {
                    // Auto Tm Event 개시
                    updateListBox("Execute Tm Adjustment.");
                    btTmAdjust_Click(sender, e);
                }
            }
#endif
            flagTimerInProgress = false;
            return;
        }

        private void updateModuleResultData(int mo)
        {
            int count;
            int index = 10;         // Start index of Data

            if (AB_check.Checked == true)
            {
                count = int.Parse(AB_count.Text) + 2;

                AB_count.Text = count.ToString();

                if (count >= int.Parse(AB_tb.Text))
                {
                    AutoBackup();

                    AB_count.Text = "0";
                }
            }

            for (int ch = 0; ch < SFChannelLength; ch++)
            {
                UInt16 valueMin, valueMax;

                // min MSB
                valueMin = recvBuf[index++];
                valueMin <<= 8;
                // min LSB
                valueMin += recvBuf[index++];

                // max MSB
                valueMax = recvBuf[index++];
                valueMax <<= 8;
                // max MSB
                valueMax += recvBuf[index++];

                /*
                /// Test
                ushort temp1, temp2;
                temp1 = valueMax;
                temp2 = valueMin;

                valueMax = temp2;
                valueMin = temp1;
                */

                // 모듈별 업데이트
                if (SystemParameter.ModuleEnable[mo])
                {
                    // Update Channel Data, 차후 모듈번호 업데이트 필요
                    arrayInitialData[mo, ch] = valueMin;
                    arrayHeatedData[mo, ch] = valueMax;
                    //                                Random ran = new Random();
                    //                              arrayInitialData[mo, ch] = 10000;
                    //                            arrayHeatedData[mo, ch] = 10000;
                    //                          arrayHeatedData[mo, ch] += (UInt16)ran.Next(1000, 2000);
                    valueMin = arrayInitialData[mo, ch];
                    valueMax = arrayHeatedData[mo, ch];
                    // mModuleArray는 업데이트 되지 않은 상태라 Count가 하나 작음
                    preprocessingParameter(mModuleArray.Count + 1, mo, ch, valueMin, valueMax);
                }
            }
        }
        private void updateProgressBar(int mo, int value, Boolean status)
        {
            int moSelected = MainSelection.ModuleNumber;

            //updateListBox(String.Format("mo {0} moSelected {1}",mo.ToString(), moSelected.ToString()));

            if (mo == moSelected)
            {
#if false
                if (status == true)
                {
                    progressBar1.ForeColor = Color.LawnGreen;
                }
                else
                {
                    progressBar1.ForeColor = Color.OrangeRed;       // 해당 클래스 색변경이 금지됨
                }
#endif
                if (value == 999)
                {
                    int tempValue = (progressBar1.Value - 10) % 20;
                    tempValue += 4;
                    if (tempValue < 20)
                    {
                        value = progressBar1.Value + 4; // 시간이 흐를수록 3씩 증가(20step, 대략5초간격 30초 6회~7회)
                    }
                    else
                    {
                        value = progressBar1.Value;     // 유지
                    }
                }
            }

            if (value < 0) value = 0;
            else if (value > 100) value = 100;

            progressBar1.Value = value;
        }

        private void Dummy_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            if (!Port.IsOpen)
            {
                ComPortUpdate();
                updateDisplayBox("COM Port List Updated.");
            }
            else
            {
                updateDisplayBox("[Error update ComPort]Current Connection should be closed");
            }
        }

        private class SelectedModuleChannel
        {
            public int ModuleNumber;
            public int[] ChannelNumber = new int[SFModuleLength];

            public SelectedModuleChannel()
            {
                ModuleNumber = -1;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    ChannelNumber[mo] = -1;
                }

            }
        }

        private SelectedModuleChannel MainSelection = new SelectedModuleChannel();

        // Setup Open
        private void btSetup_Click(object sender, EventArgs e)
        {
            bool backupTopMost;

            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            backupTopMost = this.TopMost;
            this.TopMost = false;

            frmSetup setup = new frmSetup();
            setup.ShowDialog();

            if (setup.DialogResult == DialogResult.OK)
            {
                // 창을 닫기전 세팅된 GraphDefaultParameter Setting
                if (fgGraphParameterSaved)
                {
                    saveGraphDefaultParameter();
                }

                // end process, 라디오버튼을 업데이트
                updateMainSelection();

                // 잔존하는 창(비활성화 된 모듈창)을 끔
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo] == false)
                    {
                        if (SystemParameter.ModuleOn[mo])
                        {
                            // 열린 그래픽창을 닫음
                            m_frmSfModule[mo].Close();
                            updateDisplayBox(String.Format("Close Module {0} Window", (mo + 1).ToString()));
                        }
                    }
                }
                btRefresh_Click(sender, e);
                string DirectoryPath = Application.StartupPath + "\\";
                string fs_system_ini = DirectoryPath + "Real_SF_Test.ini";
                saveIniFile(fs_system_ini);
                // 파라메터를 재로드
                loadIniFile(fs_system_ini);
            }
            this.TopMost = backupTopMost;

        }

        // 프로그램 시작시 모듈List를 업데이트, 초기 선택값은 Index 0
        private void ModuleListUpdate()
        {
            cbSFModuleSelectionNumber.Text = "";
            cbSFModuleSelectionNumber.Items.Clear();
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo])
                {
                    cbSFModuleSelectionNumber.Items.Add((mo + 1).ToString());
                }
            }

            if (cbSFModuleSelectionNumber.Items.Count > 0)
            {
                cbSFModuleSelectionNumber.SelectedIndex = 0;
            }

            updateBtSFModuleSelectionNumber();
        }

        // 콤보박스에서 모듈Number를 획득, 실패 하거나 Disable된 모듈이 선택되는 경우 모듈 최초번호를 반환
        private int getSFModuleSelectionNumberFromComboBox()
        {
            int retModuleNumber;

            retModuleNumber = -1;
            try
            {
                int mo;
                mo = Convert.ToInt32(cbSFModuleSelectionNumber.Text) - 1;
                if (mo <= SFModuleLength)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        // 모듈이 Enable되고, 모듈범위에 있는경우 설정
                        retModuleNumber = mo;
                    }
                }
            }
            catch { }

            if (retModuleNumber == -1)  // 예외처리 발생시 최초 Enable된 모듈을 선택
            {
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        // 콤보박스의 SelectedItem를 변경
                        cbSFModuleSelectionNumber.Text = (mo + 1).ToString();
                        retModuleNumber = mo;
                        break;
                    }
                }
            }

            return (retModuleNumber);
        }

        private void updateMainSelection()
        {
#if true
            int mo;

            ModuleListUpdate();

            mo = getSFModuleSelectionNumberFromComboBox();
            if (mo > -1) // -1인경우 모듈선택을 하지 않음
            {
                MainSelection.ModuleNumber = mo;
            }
#else
            bool fSelectFirstItem = true;

            for (int mo = 0; mo < SFMODULE_RB_LENGTH; mo++)
            {
                // 라디오버튼: rbSF01
                StringBuilder strSearchMo = new StringBuilder("rbSFxx");
                strSearchMo.Remove(4, 2);
                strSearchMo.Insert(4, (mo + 1).ToString("D2"));
                RadioButton rbModule = this.Controls.Find(strSearchMo.ToString(), true)[0] as RadioButton;
                rbModule.Enabled = SystemParameter.ModuleEnable[mo];
                rbModule.Visible = SystemParameter.ModuleEnable[mo];

                if (fSelectFirstItem && rbModule.Enabled)
                {
                    fSelectFirstItem = false;
                    rbModule.Checked = true;
                    MainSelection.ModuleNumber = mo;
                }
                else
                {
                    rbModule.Checked = false;
                }
            }
#endif
            SelectMainSelectionModule();

            upateMainSelectionParameter();
        }

        private void upateMainSelectionParameter()
        {
            // 현재창의 모듈번호, 채널번호 획득
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[mo];

            // 모듈번호와 채널이 매칭시 창 업데이트
            lbTemperature.Text = valueSF[mo, ch].ToString("0.##");
            lbHumidity.Text = valueRTemp[mo, ch].ToString("0.##");

            tbY1MaxValue.Text = toStringMaxMinValue(valueSFMax[mo, ch]);
            tbY1MinValue.Text = toStringMaxMinValue(valueSFMin[mo, ch]);

            tbY2MaxValue.Text = toStringMaxMinValue(valueRTempMax[mo, ch]);
            tbY2MinValue.Text = toStringMaxMinValue(valueRTempMin[mo, ch]);

            tbParaSet_a.Text = SystemParameter.Para[mo, ch].a.ToString();
            tbParaSet_b.Text = SystemParameter.Para[mo, ch].b.ToString();
            tbParaSet_c.Text = SystemParameter.Para[mo, ch].c.ToString();
            tbParaSet_Tm.Text = SystemParameter.Para[mo, ch].Tm.ToString();

            // ComboBox Check changed시 text기준으로 업데이트됨으로 text먼저 업데이트 필요함
            exeUpdateMinMaxTextBox(fgGraphMin[mo, ch], tbY1Min, GraphMin[mo, ch]);
            exeUpdateMinMaxTextBox(fgGraphMax[mo, ch], tbY1Max, GraphMax[mo, ch]);
            exeUpdateMinMaxTextBox(fgGraphMin2[mo, ch], tbY2Min, GraphMin2[mo, ch]);
            exeUpdateMinMaxTextBox(fgGraphMax2[mo, ch], tbY2Max, GraphMax2[mo, ch]);

            // Update Min, Max Check Box  
            cbY1Min.Checked = fgGraphMin[mo, ch];
            cbY1Max.Checked = fgGraphMax[mo, ch];
            cbY2Min.Checked = fgGraphMin2[mo, ch];
            cbY2Max.Checked = fgGraphMax2[mo, ch];
        }

        private void exeUpdateMinMaxTextBox(Boolean fgSetting, TextBox tbTemp, float value)
        {
            try
            {
                if (Single.IsNaN(value))
                {
                    tbTemp.Text = "";
                }
                else
                {
                    tbTemp.Text = value.ToString();
                }
            }
            catch { }
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

        public string toStringMaxMinValue(float value)
        {
            string str;
            if ((value != 65535))//&& (value != 0))
            {
                str = value.ToString();
            }
            else
            {
                str = value.ToString();  //str = "--";
            }

            return (str);
        }

        private void SearchMainSelectionModuleNumber()
        {
#if true
            // 최초 Enable된 모듈을 선택
            if (MainSelection.ModuleNumber == -1)  // 예외처리 발생시 
            {
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        // 콤보박스의 SelectedItem를 변경
                        MainSelection.ModuleNumber = mo;
                        cbSFModuleSelectionNumber.Text = (mo + 1).ToString();
                        break;
                    }
                }
            }
#else
            // Enable된 라디오버튼의 최초 모듈번호를 찾음
            if (MainSelection.ModuleNumber == -1)
            {
                for (int mo = 0; mo < SFMODULE_RB_LENGTH; mo++)
                {
                    // 라디오버튼: rbSF01
                    StringBuilder strSearchMo = new StringBuilder("rbSFxx");
                    strSearchMo.Remove(4, 2);
                    strSearchMo.Insert(4, (mo + 1).ToString("D2"));
                    RadioButton rbModule = this.Controls.Find(strSearchMo.ToString(), true)[0] as RadioButton;
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        rbModule.Checked = true;
                        MainSelection.ModuleNumber = mo;
                        break;
                    }
                }
            }
#endif
        }

        // 선택된 모듈번호를 찾음
        private void SelectMainSelectionModule()
        {
            try
            {
#if true
                // 모듈 번호 획득
                int mo;
                mo = getSFModuleSelectionNumberFromComboBox();
                if (mo > -1) // -1인경우 모듈선택을 하지 않음
                {
                    MainSelection.ModuleNumber = mo;
                }
#else
            // 모듈 번호 획득
            for (int mo = 0; mo < SFMODULE_RB_LENGTH; mo++)
            {
                // 라디오버튼: rbSF01
                StringBuilder strSearchMo = new StringBuilder("rbSFxx");
                strSearchMo.Remove(4, 2);
                strSearchMo.Insert(4, (mo + 1).ToString("D2"));
                RadioButton rbModule = this.Controls.Find(strSearchMo.ToString(), true)[0] as RadioButton;
                if (rbModule.Checked)
                {
                    MainSelection.ModuleNumber = mo;
                    break;
                }
            }
#endif

                // 채널 번호 획득
                if (MainSelection.ModuleNumber > -1)
                {
                    // 모듈 선택시, 기존에 채널선택값이 존재하면 해당것으로 업데이트
                    if (MainSelection.ChannelNumber[MainSelection.ModuleNumber] > -1)
                    {
                        // 라디오버튼: rbCH1
                        StringBuilder strSearchMo = new StringBuilder("rbCHx");
                        strSearchMo.Remove(4, 1);
                        strSearchMo.Insert(4, (MainSelection.ChannelNumber[MainSelection.ModuleNumber] + 1).ToString("D1"));
                        RadioButton rbChannel = this.Controls.Find(strSearchMo.ToString(), true)[0] as RadioButton;
                        rbChannel.Checked = true;

                    }
                    else
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            // 라디오버튼: rbCH1
                            StringBuilder strSearchMo = new StringBuilder("rbCHx");
                            strSearchMo.Remove(4, 1);
                            strSearchMo.Insert(4, (ch + 1).ToString("D1"));
                            RadioButton rbChannel = this.Controls.Find(strSearchMo.ToString(), true)[0] as RadioButton;
                            if (ch == 0)
                            {
                                rbChannel.Checked = true;
                                MainSelection.ChannelNumber[MainSelection.ModuleNumber] = ch;
                            }
                            else
                            {
                                rbChannel.Checked = false;
                            }
                        }
                    }

                }

                // 선택가능 채널 표시
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // 라디오버튼: rbCH1
                    StringBuilder strSearchMo = new StringBuilder("rbCHx");
                    strSearchMo.Remove(4, 1);
                    strSearchMo.Insert(4, (ch + 1).ToString("D1"));
                    RadioButton rbChannel = this.Controls.Find(strSearchMo.ToString(), true)[0] as RadioButton;
                    rbChannel.Enabled = SystemParameter.ChannelEnable[MainSelection.ModuleNumber, ch];
                }

                updateDisplayBox(String.Format("Set MO:{0} CH:{1}", MainSelection.ModuleNumber + 1, MainSelection.ChannelNumber[MainSelection.ModuleNumber] + 1));
            }
            catch { }
        }

        private void SFModule_Clicked(object sender, EventArgs e)
        {
            // Previous, Next 버튼 활성화
            updateBtSFModuleSelectionNumber();

            // 선택된 라디오버튼의 모듈번호를 찾음
            SelectMainSelectionModule();
            gbSfModule.Text = String.Format("SF Module #{0}", (MainSelection.ModuleNumber + 1).ToString("D2"));
            gbChannel.Text = String.Format("Channel #{1}", (MainSelection.ModuleNumber + 1).ToString("D2"), (MainSelection.ChannelNumber[MainSelection.ModuleNumber] + 1).ToString("D1"));
            lbParameterMxCx.Text = String.Format("M#{0} C#{1}", (MainSelection.ModuleNumber + 1).ToString("D2"), (MainSelection.ChannelNumber[MainSelection.ModuleNumber] + 1).ToString("D1"));
            //btCalibration.Text = String.Format(" M#{0} Calibration", (MainSelection.ModuleNumber + 1).ToString("D2"));
            upateMainSelectionParameter();

            // 해당창 Focus 획득
            // 현재창의 모듈번호, 채널번호 획득
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[mo];
            if (SystemParameter.ModuleEnable[mo])
            {
                if (SystemParameter.ModuleOn[mo])
                {
                    m_frmSfModule[mo].Focus();
                    this.Focus();
                }

            }
        }

        private void SFChannel_Clicked(object sender, EventArgs e)
        {
            if (MainSelection.ModuleNumber == -1) SearchMainSelectionModuleNumber();

            for (int ch = 0; ch < SFChannelLength; ch++)
            {
                // 라디오버튼: rbCH1
                StringBuilder strSearchMo = new StringBuilder("rbCHx");
                strSearchMo.Remove(4, 1);
                strSearchMo.Insert(4, (ch + 1).ToString("D1"));
                RadioButton rbChannel = this.Controls.Find(strSearchMo.ToString(), true)[0] as RadioButton;
                if (rbChannel.Checked)
                {
                    MainSelection.ChannelNumber[MainSelection.ModuleNumber] = ch;
                    break;
                }
            }

            updateDisplayBox(String.Format("Set MO:{0} CH:{1}", MainSelection.ModuleNumber + 1, MainSelection.ChannelNumber[MainSelection.ModuleNumber] + 1));
            gbSfModule.Text = String.Format("SF Module #{0}", (MainSelection.ModuleNumber + 1).ToString("D2"));
            gbChannel.Text = String.Format("Channel #{1}", (MainSelection.ModuleNumber + 1).ToString("D2"), (MainSelection.ChannelNumber[MainSelection.ModuleNumber] + 1).ToString("D1"));
            lbParameterMxCx.Text = String.Format("M#{0} C#{1}", (MainSelection.ModuleNumber + 1).ToString("D2"), (MainSelection.ChannelNumber[MainSelection.ModuleNumber] + 1).ToString("D1"));

            //btCalibration.Text = String.Format(" M#{0} Calibration", (MainSelection.ModuleNumber + 1).ToString("D2"));
            upateMainSelectionParameter();
        }

        // 기존 데이터(mModuleArray)를 참조하여 차트에 업데이트
        private void UpdateChartWithRawData(int mo)
        {
            Chart chart = null;

            // clear min, max
            clearModuleMinMaxValue(mo);

            for (int index = 0; index < mModuleArray.Count; index++)
            {
                if (SystemParameter.ModuleEnable[mo] == false) continue;

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ChannelEnable[mo, ch])
                    {
                        if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                        if (mModuleArray[index].rawModudle[mo].moduleDefine.mType == ModuleType_SF)
                        {/*
                            mModuleArray[index].OADate;
                            mModuleArray[index].rawModudle[mo].CHData[ch].InitialTemperature;
                            mModuleArray[index].rawModudle[mo].CHData[ch].HeatedTemperature;
                            mModuleArray[index].rawModudle[mo].additionalData.ExternalTemperature;
                            mModuleArray[index].rawModudle[mo].additionalData.ExternalHumidity;
                            mModuleArray[index].rawModudle[mo].additionalData.ExternalSoilMoisture;
                            mModuleArray[index].rawModudle[mo].additionalData.Para_a;
                            mModuleArray[index].rawModudle[mo].additionalData.Para_b;
                            mModuleArray[index].rawModudle[mo].additionalData.Para_c;
                            mModuleArray[index].rawModudle[mo].additionalData.Para_Tm;
                            */
                            mTemperature[mo] = mModuleArray[index].rawModudle[mo].additionalData.ExternalTemperature;
                            mHumidity[mo] = mModuleArray[index].rawModudle[mo].additionalData.ExternalHumidity;

                            SystemParameter.Para[mo, ch].a = mModuleArray[index].rawModudle[mo].additionalData.Para_a;
                            SystemParameter.Para[mo, ch].b = mModuleArray[index].rawModudle[mo].additionalData.Para_b;
                            SystemParameter.Para[mo, ch].c = mModuleArray[index].rawModudle[mo].additionalData.Para_c;
                            if (ch == 0)
                            {
                                SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH1;
                            }
                            else if (ch == 1)
                            {
                                SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH2;
                            }
                            else if (ch == 2)
                            {
                                SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH3;
                            }
                            else if (ch == 3)
                            {
                                SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH4;
                            }

                            double currentDate = mModuleArray[index].OADate;
                            UInt16 min = mModuleArray[index].rawModudle[mo].CHData[ch].InitialTemperature;
                            UInt16 max = mModuleArray[index].rawModudle[mo].CHData[ch].HeatedTemperature;

                            preprocessingParameter(index + 1, mo, ch, min, max);

                            chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                            chart.Series["SF"].Points.AddXY(currentDate, valueSF[mo, ch]);

                            if (cbTCompensation.Checked == true)
                            {
                                float compensatedSFValue;

                                if (index > 1)
                                {
                                    compensatedSFValue = preprocessingParameterCompensation(currentDate, index + 1, mo, ch, min, max);
                                    chart.Series["SF"].Points[chart.Series["SF"].Points.Count - 2].YValues[0] = compensatedSFValue;
                                }
                            }

                            if ((valueSF[mo, ch] <= 0) && double.IsNaN(chart.ChartAreas[0].AxisY.Maximum))
                            {
                                if (index < 1)
                                {
                                    // Set Manual ViewScale for Mouse Movement
                                    //180312 chart.ChartAreas[0].AxisY.Maximum = 3;
                                    chart.ChartAreas[0].AxisY.Minimum = 0;
                                }
                            }
                            chart.Series["Temp"].Points.AddXY(currentDate, valueRTemp[mo, ch]);

                            // SHT15데이터 업데이트 
                            //chart.Series["TempSHT15"].Points.AddXY(currentDate, mTemperature[mo]);
                            //chart.Series["HumSHT15"].Points.AddXY(currentDate, mHumidity[mo]);

                            // VPD Update
                            //chart.Series["VPD"].Points.AddXY(currentDate, (double)calculateVPD(mTemperature[mo], mHumidity[mo]));

                            // Chart의 Point수를 제한
                            if (checkReduceChartPoint(chart.Series["SF"], mo, ch))
                            {
                                executeReduceChartPoint(chart.Series["SF"], mo, ch);
                                executeReduceChartPoint(chart.Series["Temp"], mo, ch);
                            }

                            updateTemperatureMinMaxValue(mo, mTemperature[mo]);
                            updateHumidityMinMaxValue(mo, mHumidity[mo]);

                        }
                    }
                }
            }

            if (chart != null)
            {
                chart.ChartAreas[0].AxisX.Minimum = chart.Series["SF"].Points[0].XValue;
                chart.ChartAreas[0].AxisX.Maximum = chart.Series["SF"].Points[chart.Series["SF"].Points.Count - 1].XValue;

                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart.ChartAreas[0].RecalculateAxesScale();
            }

        }

        // 기존 데이터(mModuleArray)를 참조하여 Multi차트에 업데이트(18/03/19)
        private void UpdateMultiChartWithRawData()
        {
            Chart chart = null;
            float progress;

            if (SystemParameter.MultiModuleOn == true)
            {
                for (int index = 0; index < mModuleArray.Count; index++)
                {
                    if ((index % 1000) == 0)
                    {
                        progress = 100 * (float)index / (float)mModuleArray.Count;
                        updateDisplayBox(String.Format("Multichart updating {0}%, Index={1}", progress.ToString("0"), index.ToString()));
                    }

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        if (SystemParameter.ModuleEnable[mo])
                        {
                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                                    SystemParameter.Para[mo, ch].a = mModuleArray[index].rawModudle[mo].additionalData.Para_a;
                                    SystemParameter.Para[mo, ch].b = mModuleArray[index].rawModudle[mo].additionalData.Para_b;
                                    SystemParameter.Para[mo, ch].c = mModuleArray[index].rawModudle[mo].additionalData.Para_c;
                                    if (ch == 0)
                                    {
                                        SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH1;
                                    }
                                    else if (ch == 1)
                                    {
                                        SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH2;
                                    }
                                    else if (ch == 2)
                                    {
                                        SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH3;
                                    }
                                    else if (ch == 3)
                                    {
                                        SystemParameter.Para[mo, ch].Tm = mModuleArray[index].rawModudle[mo].additionalData.Para_Tm_CH4;
                                    }

                                    double currentDate = mModuleArray[index].OADate;
                                    UInt16 min = mModuleArray[index].rawModudle[mo].CHData[ch].InitialTemperature;
                                    UInt16 max = mModuleArray[index].rawModudle[mo].CHData[ch].HeatedTemperature;

                                    preprocessingParameter(index + 1, mo, ch, min, max);

                                    chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                                    chart.Series["SF"].Points.AddXY(currentDate, valueSF[mo, ch]);

                                    if (cbTCompensation.Checked == true)
                                    {
                                        float compensatedSFValue;

                                        if (index > 1)
                                        {
                                            compensatedSFValue = preprocessingParameterCompensation(currentDate, index + 1, mo, ch, min, max);
                                            chart.Series["SF"].Points[chart.Series["SF"].Points.Count - 2].YValues[0] = compensatedSFValue;
                                        }
                                    }

                                    if ((valueSF[mo, ch] <= 0) && double.IsNaN(chart.ChartAreas[0].AxisY.Maximum))
                                    {
                                        if (index < 1)
                                        {
                                            // Set Manual ViewScale for Mouse Movement
                                            //180312 chart.ChartAreas[0].AxisY.Maximum = 3;
                                            chart.ChartAreas[0].AxisY.Minimum = 0;
                                        }
                                    }
                                    chart.Series["Temp"].Points.AddXY(currentDate, valueRTemp[mo, ch]);

                                    // Chart의 Point수를 제한
                                    if (checkReduceMultiChartPoint(chart.Series["SF"], mo, ch))
                                    {
                                        executeReduceMultiChartPoint(chart.Series["SF"], mo, ch);
                                        executeReduceMultiChartPoint(chart.Series["Temp"], mo, ch);
                                    }

                                }
                            }
                        }
                    }
                }

                // 각 그래프 Min, Max그래프 설정및 표시
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                                chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;
                                if (chart.Series["SF"].Points.Count > 0)
                                {
                                    chart.ChartAreas[0].AxisX.Minimum = chart.Series["SF"].Points[0].XValue;
                                    chart.ChartAreas[0].AxisX.Maximum = chart.Series["SF"].Points[chart.Series["SF"].Points.Count - 1].XValue;

                                    chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                                    chart.ChartAreas[0].RecalculateAxesScale();

                                    // 180409
                                    if ((fgGraphMin[mo, ch] == true) && (fgGraphMax[mo, ch] == true))
                                    {
                                        try
                                        {
                                            // Set Min, Max
                                            chart.ChartAreas[0].AxisY.Minimum = GraphMin[mo, ch];
                                            chart.ChartAreas[0].AxisY.Maximum = GraphMax[mo, ch];
                                        }
                                        catch { }

                                    }

                                }
                            }
                        }
                    }
                }

                progress = 100;
                updateDisplayBox(String.Format("Done, {0}%, Index={1}", progress.ToString(), mModuleArray.Count.ToString()));

            }
        }


        //  밸브컨트롤용 데이터 삭제
        private void clearValveControlChart()
        {
            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
            {
                Chart chart = null;
                chart = m_frmValveControl.chart1;

                chart.Series["mergedSFValue"].Points.Clear();
                chart.Series["totalSFValue"].Points.Clear();
                chart.Series["ValveControl"].Points.Clear();
                chart.Series["IntegratedValue"].Points.Clear();

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo] == false) continue;

                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        string strChartName = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");
                        chart.Series[strChartName].Points.Clear();
                    }
                }

                clearValveControlCount();
            }
        }

        private void clearValveControlCount()
        {
            // Clear Dispose Count
            for (int index = 0; index < CurrentVCPointChannelCount.Length; index++)
            {
                CurrentVCPointChannelCount[index] = 0;
            }
        }

        //  밸브컨트롤용 그래프 ON/FF 업데이트
        private void displayValveControlChart()
        {
            if (SystemParameter.ValveControlOn)
            {
                Chart chart = null;
                chart = m_frmValveControl.chart1;

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo] == false) continue;

                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                        string strChartName = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");

                        if (VCParameter.Enabled[mo, ch])    // 해당 채널을 참조하는 경우 그래프 표시
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

        }
        //  밸브컨트롤용 데이터 업데이트
        private void updateValveControlChart(double currentDate)
        {
            double value;
            int retValue;

            Chart chart = null;
            chart = m_frmValveControl.chart1;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo] == false) continue;

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                    string strChartName = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");

                    if (VCParameter.Enabled[mo, ch])    // 해당 채널을 참조하는 경우 업데이트
                    {
                        value = 0;
                        if (VCParameter.Max[mo, ch] > VCParameter.Min[mo, ch])
                        {
                            value = (valueSF[mo, ch] - VCParameter.Min[mo, ch]) * VALVE_CONTROL_MAX_VALUE / (VCParameter.Max[mo, ch] - VCParameter.Min[mo, ch]);
                            value *= (double)VCParameter.Ratio[mo, ch] / (double)100;       // 18'03'26 Ratio적용 .. 값을 %단위로 키우거나 줄임

                            if (value > VALVE_CONTROL_MAX_VALUE)
                            {
                                value = VALVE_CONTROL_MAX_VALUE;
                            }
                            if (value < 0)
                            {
                                value = 0;
                            }
                        }
                        retValue = Convert.ToInt32(value);
                        if (retValue > (VCParameter.CurrentSFValue[mo, ch] + VCParameter.Constrain[mo, ch]))
                        {
                            retValue = VCParameter.CurrentSFValue[mo, ch] + VCParameter.Constrain[mo, ch];
                        }
                        else if (retValue < (VCParameter.CurrentSFValue[mo, ch] - VCParameter.Constrain[mo, ch]))
                        {
                            retValue = VCParameter.CurrentSFValue[mo, ch] - VCParameter.Constrain[mo, ch];
                        }

                        chart.Series[strChartName].Points.AddXY(currentDate, retValue);
                        VCParameter.CurrentSFValue[mo, ch] = retValue;
                    }
                    else
                    {
                        chart.Series[strChartName].Points.AddXY(currentDate, 0);
                    }

                    // Dispose Point, Chart의 Point수를 제한
                    int index = mo * 4 + ch;
                    if (checkReduceVCPoint(chart.Series[strChartName], index))
                    {
                        executeReduceVCPoint(chart.Series[strChartName], index);
                    }
                }
            }

        }

        // 밸브 컨트롤용 이벤트 업데이트
        private void updateValveControlEvent(double currentDate)
        {
            int mergedValue, count;

            count = 0;
            mergedValue = 0;
            Chart chart = null;
            chart = m_frmValveControl.chart1;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo] == false) continue;

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ChannelEnable[mo, ch] == false) continue;

                    if (VCParameter.Enabled[mo, ch])    // 해당 채널을 참조하는 경우 업데이트
                    {
                        count++;
                        string strChartName = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");
                        if (chart.Series[strChartName].Points.Count > 0)
                        {
                            mergedValue += Convert.ToInt32(chart.Series[strChartName].Points[chart.Series[strChartName].Points.Count - 1].YValues[0]);
                        }
                    }
                }
            }
            if (count > 0)
            {
                mergedValue /= count;
            }
            chart.Series["mergedSFValue"].Points.AddXY(currentDate, mergedValue);

            // Dispose Point, Chart의 Point수를 제한
            int index = CurrentVCPointChannelCount.Length - IndexMergedSFCount;
            if (checkReduceVCPoint(chart.Series["mergedSFValue"], index))
            {
                executeReduceVCPoint(chart.Series["mergedSFValue"], index);
            }

            // 누적값을 계산
            if (mModuleArray.Count > 2)
            {
                DateTime now = DateTime.FromOADate(currentDate);
                DateTime old_now;
                if (currentDate != mModuleArray[mModuleArray.Count - 1].OADate)
                {
                    updateListBox("MISMATCH CURRENTTIME");
                }
                old_now = DateTime.FromOADate(mModuleArray[mModuleArray.Count - 2].OADate);
                TimeSpan result = now - old_now;

                //  Start와 End시간을 비교
                //   END가 00:00 인경우는 24:00로 취급
                //   Start가 00:00 인 경우는 00:00로 취급
                //      S   0 : S ~ 자정동안 ON
                //      S < E : S ~ E시간동안 ON          --> 18/03/16 End시간 기준에서 양액공급이 적은경우, 추가공급 알고리즘 추가
                //      S > E : S~자정, 자정~E 동안 ON
                //      S = E : OFF(단, 00:00인 경우 Always ON)
                Boolean fgUpdateData = false;
                Boolean fgEmergencyCheck = false;

                if (VCParameter.StartEndEnabled)
                {
                    if (TimeSpan.Compare(VCParameter.EndTime.TimeOfDay, new TimeSpan(0, 0, 0)) == 0)  // 종료시간 00:00인경우는 24:00으로 가정한다.
                    {
                        // S ~ 24:00 
                        if (TimeSpan.Compare(now.TimeOfDay, VCParameter.StartTime.TimeOfDay) >= 0)  // 시작시간보다 큰경우
                        {
                            fgUpdateData = true;
                        }
                    }
                    else if (TimeSpan.Compare(VCParameter.StartTime.TimeOfDay, VCParameter.EndTime.TimeOfDay) < 0)
                    {
                        //  S < E : S ~ E시간동안 ON
                        if (TimeSpan.Compare(now.TimeOfDay, VCParameter.StartTime.TimeOfDay) >= 0)  // 시작시간보다 큰경우
                        {
                            if (TimeSpan.Compare(now.TimeOfDay, VCParameter.EndTime.TimeOfDay) < 0)
                            {
                                // 18/3/16 End시간 기준에서 양액공급이 적은경우, 추가공급 알고리즘 추가
                                DateTime EmergencyCheckTime = VCParameter.EndTime;
                                EmergencyCheckTime = VCParameter.EndTime.AddMinutes(-30);     // 비상급수 확인시간은 종료 30분전

                                //m_frmValveControl.updateListBoxRight(String.Format("EM C {0} M:{1}", now.TimeOfDay.ToString(), EmergencyCheckTime.TimeOfDay.ToString()));
                                if (TimeSpan.Compare(now.TimeOfDay, EmergencyCheckTime.TimeOfDay) >= 0)
                                {
                                    fgEmergencyCheck = true;
                                    // m_frmValveControl.updateListBoxRight("EM True");
                                }
                                fgUpdateData = true;
                            }
                        }
                    }
                    else if (TimeSpan.Compare(VCParameter.StartTime.TimeOfDay, VCParameter.EndTime.TimeOfDay) > 0)
                    {
                        //  S > E : S~자정, 자정~E 동안 ON
                        if (TimeSpan.Compare(now.TimeOfDay, VCParameter.StartTime.TimeOfDay) >= 0)  // 시작시간보다 큰경우
                        {
                            fgUpdateData = true;
                        }
                        else if (TimeSpan.Compare(now.TimeOfDay, VCParameter.EndTime.TimeOfDay) < 0)
                        {
                            fgUpdateData = true;
                        }
                    }
                }
                else
                {
                    // Start, End Time이 disable된경우는 항상 ON
                    fgUpdateData = true;
                }

                if (fgUpdateData)
                {
                    DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

                    VCParameter.IntegratedValue += (int)mergedValue * (result.Ticks) / 10000000; //  * SolarRad (W/m2)
                    VCParameter.totalValue += (int)mergedValue * (result.Ticks) / 10000000;     // 10,000 ticks = 1msec
                    VCParameter.ElapsedTime = VCParameter.ElapsedTime.Add(result);

                    // 0205'18 H.J.Kim: 측정Time Interval이 15분이상인경우는 이어붙인경우로 광량에 적산하지 않음, 누적적산값을 Clear
                    if (TimeSpan.Compare(result, new TimeSpan(0, 15, 0)) >= 0)
                    {
                        VCParameter.IntegratedValue = 0;
                        VCParameter.totalValue = 0;
                        string strText = String.Format("Clear Integrated SolarRad(over time)");
                        m_frmValveControl.updateListBoxLeft(strText);
                        updateValveControlDetailed(currentDate, strText);
                    }

                    if (VCParameter.MaxMinEnabled)
                    {
                        string strText = String.Format("T:{0} E:{3} m:{4} M:{5} (R,J)=, {1}, {2}", result.TotalSeconds.ToString(), mergedValue.ToString(), (VCParameter.IntegratedValue / 10000).ToString("D"), (dt + VCParameter.ElapsedTime).ToString("HH:mm"), (dt + VCParameter.MinTime).ToString("HH:mm"), (dt + VCParameter.MaxTime).ToString("HH:mm"));
                        m_frmValveControl.updateListBoxRight(String.Format("{0}, {1}", now.ToString("MM-dd HH:mm:ss"), strText));
                        updateValveControlDetailed(currentDate, strText);
                    }
                    else
                    {
                        string strText = String.Format("T:{0} (R,J)=, {1}, {2}", result.TotalSeconds.ToString(), mergedValue.ToString(), (VCParameter.IntegratedValue / 10000).ToString("D"));
                        m_frmValveControl.updateListBoxRight(String.Format("{0}, {1}", now.ToString("MM-dd HH:mm:ss"), strText));
                        updateValveControlDetailed(currentDate, strText);
                    }
                }
                else
                {
                    VCParameter.IntegratedValue = 0;
                    VCParameter.totalValue = 0;
                    VCParameter.EventCount = 0;
                    VCParameter.ElapsedTime = TimeSpan.Zero;
                }

                //updateListBox(result.TotalSeconds.ToString());

                chart.Series["totalSFValue"].Points.AddXY(currentDate, VCParameter.totalValue / 10000);
                chart.Series["IntegratedValue"].Points.AddXY(currentDate, VCParameter.IntegratedValue / 10000);

                // Update Dispose Count; ZXC
                index = CurrentVCPointChannelCount.Length - IndexTotalSFCount;
                if (checkReduceVCPoint(chart.Series["totalSFValue"], index))
                {
                    executeReduceVCPoint(chart.Series["totalSFValue"], index);
                }

                index = CurrentVCPointChannelCount.Length - IndexIntegratedCount;
                if (checkReduceVCPoint(chart.Series["IntegratedValue"], index))
                {
                    executeReduceVCPoint(chart.Series["IntegratedValue"], index);
                }

                // Max./Min. Time Interval Calculation
                Boolean fgOverIntegratedValue = false;
                Boolean fgUnderMinTime = false;
                Boolean fgOverMaxTime = false;

                if ((VCParameter.IntegratedValue / 10000) >= VCParameter.EventJouleValue)
                {
                    // 누적광량이 이벤트 시간을 넘는경우 물주기를 시작
                    fgOverIntegratedValue = true;
                }

                if (VCParameter.MaxMinEnabled)  // Max, Min 세팅확인이 활성화 된경우 사용
                {
                    if (TimeSpan.Compare(VCParameter.ElapsedTime, VCParameter.MinTime) < 0)
                    {
                        if (fgOverIntegratedValue == true)
                        {
                            // Event가 발생한 상황에서도 최소시간이 넘지 않은경우 지연시킴
                            fgUnderMinTime = true;
                        }
                    }

                    if (TimeSpan.Compare(VCParameter.ElapsedTime, VCParameter.MaxTime) >= 0)
                    {
                        if (fgOverIntegratedValue == false)
                        {
                            // Event상황이 최대시간이 넘도록 발생하지 않은 경우 강제 이벤트 발생
                            fgOverMaxTime = true;

                            // 0205'18 H.J.Kim: 측정Time Interval이 5분이상인경우는 이어붙인경우로 Max Time지난후 강제 물주기 동작을 하지 않음
                            if (TimeSpan.Compare(result, new TimeSpan(0, 5, 0)) >= 0)
                            {
                                fgOverMaxTime = false;
                            }

                        }
                    }

                }

                // Emergency급수는 fgUnderMinTime을 Override하여 강제로 주도록한다.
                if (fgEmergencyCheck == true)
                {
                    //  m_frmValveControl.updateListBoxRight("EM True2");
                    if (VCParameter.EventCount <= nUDEmergencyNumber.Value)
                    {
                        if (nUDEmergencyNumber.Value < 10)       // 10이상의 경우 Fake로 모니터링 Only
                        {
                            fgOverIntegratedValue = true;
                            string strText = String.Format("Emergency VALVE ON(Count under [{0}])", nUDEmergencyNumber.Value);
                            m_frmValveControl.updateListBoxRight(String.Format("{0} {1}", now.ToString("MM-dd H:mm:ss"), strText));
                            updateValveControlDetailed(currentDate, strText);
                        }
                        else
                        {
                            m_frmValveControl.updateListBoxRight(String.Format("{0} Fake Emergency VALVE ON(Count under [{1}])", now.ToString("MM-dd HH:mm:ss H:mm:ss"), nUDEmergencyNumber.Value));
                        }

                    }

                    if (fgUnderMinTime == true)
                    {
                        string strText = String.Format("Min/Max Time overrided by Emergency checking");
                        m_frmValveControl.updateListBoxRight(String.Format("{0} {1}", now.ToString("MM-dd HH:mm:ss H:mm:ss"), strText));
                        fgUnderMinTime = false;
                        updateValveControlDetailed(currentDate, strText);
                    }
                }

                if (((fgOverIntegratedValue == true) && (fgUnderMinTime == false))
                 || ((fgOverIntegratedValue == false) && (fgOverMaxTime == true)))
                {
                    VCParameter.EventCount++;
                    string strText = String.Format("VALVE ON Count={0}", VCParameter.EventCount);
                    m_frmValveControl.updateListBoxLeft(String.Format("{0} {1}", now.ToString("MM-dd HH:mm:ss"), strText));
                    updateValveControlDetailed(currentDate, strText);
                    if (fgOverIntegratedValue)
                    {
                        //fgOverIntegratedValue에 의한 누적적산 물주기의 경우, 해당 누적적산량만큼 삭제후 계속 진행
                        VCParameter.IntegratedValue -= (VCParameter.EventJouleValue * 10000);

                        // 남은 적산량이 EventJouleValue보다 크게 남은 경우 EventJouleValue으로 Fix
                        if ((VCParameter.IntegratedValue / 10000) >= VCParameter.EventJouleValue)
                        {
                            VCParameter.IntegratedValue = (VCParameter.EventJouleValue * 10000) - 1;
                        }
                    }
                    else
                    {
                        // fgOverMaxTime에 의한 강제 물주기의 경우 누적적산값을 Clear
                        VCParameter.IntegratedValue = 0;
                    }

                    VCParameter.ElapsedTime = TimeSpan.Zero;

                    int logValue;
                    if ((SystemParameter.ValveControlOn) && (VCParameter.EventStarted))
                    {
                        DateTime now2 = DateTime.Now;
                        if (fgOverIntegratedValue)
                        {
                            strText = "Event Activated(Auto)";
                            m_frmValveControl.updateListBoxRight(String.Format("{0} {1}", now.ToString("M-dd H:mm:ss"), strText));
                            updateValveControlDetailed(currentDate, strText);
                        }
                        if (fgOverMaxTime)
                        {
                            strText = "Max Time Activated(Forced)";
                            m_frmValveControl.updateListBoxRight(String.Format("{0} {1}", now.ToString("M-dd H:mm:ss"), strText));
                            updateValveControlDetailed(currentDate, strText);
                        }
                        VCParameter.EventActivated = true;
                        chart.Series["ValveControl"].Points.AddXY(currentDate, VCParameter.EventJouleValue);
                        logValue = VCParameter.EventJouleValue;
                    }
                    else
                    {
                        chart.Series["ValveControl"].Points.AddXY(currentDate, 0);
                        logValue = 0;
                    }

                    // Valve Control 입력 데이터는 Dispose하지 않음
                    //index = CurrentVCPointChannelCount.Length - IndexValveControlCount;
                    //// Dispose Point, Chart의 Point수를 제한
                    //if (checkReduceVCPoint(chart.Series[index], index))
                    //{
                    //    executeReduceVCPoint(chart.Series[index], index);
                    //}


                    updateValveControlHistory(currentDate, logValue);
                }
                else if (fgUnderMinTime)
                {
                    // 강제로 멈춰 있는 동안의 누적적산은 하지 않음
                    VCParameter.IntegratedValue -= (int)mergedValue * (result.Ticks) / 10000000; //  * SolarRad (W/m2)

                    string strText = "Activation delayed(Forced)";
                    m_frmValveControl.updateListBoxRight(String.Format("{0} {1}", now.ToString("MM-dd HH:mm:ss"), strText));
                    updateValveControlDetailed(currentDate, strText);
                }

                // updateListBox(String.Format("{0}J/cm2", (VCParameter.IntegratesdValue / 10000).ToString("0")));
            }
            else
            {

                DateTime now = DateTime.FromOADate(currentDate);
                chart.Series["totalSFValue"].Points.AddXY(currentDate, VCParameter.totalValue / 10000);
                chart.Series["IntegratedValue"].Points.AddXY(currentDate, VCParameter.IntegratedValue / 10000);

                // Update Dispose Count; ZXC
                index = CurrentVCPointChannelCount.Length - IndexTotalSFCount;
                if (checkReduceVCPoint(chart.Series["totalSFValue"], index))
                {
                    executeReduceVCPoint(chart.Series["totalSFValue"], index);
                }

                index = CurrentVCPointChannelCount.Length - IndexIntegratedCount;
                if (checkReduceVCPoint(chart.Series["IntegratedValue"], index))
                {
                    executeReduceVCPoint(chart.Series["IntegratedValue"], index);
                }
            }

            // Check Dispose Count; ZXC

        }

        private void updateValveControlHistory(double currentDate, int logValue)
        {
            if (flagLogReading == true)
            {
                // Skip for Log Data Read;
                return;
            }

            StringBuilder savedata = new StringBuilder();
            savedata.Clear();

            DateTime now = DateTime.FromOADate(currentDate);

            //updateListBox("VC Export..");
            savedata.Append(now.ToString("yyyy-MM-dd HH:mm:ss") + ", ");

            if (logValue == 88888) savedata.Append("[Event On Mannually]");
            else if (logValue == 99999) savedata.Append("[Event Aborted]");
            else if (logValue == 0) savedata.Append("[Event Stopped]");
            else savedata.Append("[Event On J=" + (logValue).ToString() + "]");

            savedata.Append(Environment.NewLine);

            System.IO.File.AppendAllText(fs3, savedata.ToString());
        }

        private void updateValveControlDetailed(double currentDate, string strText)
        {
            if (flagLogReading == true)
            {
                // Skip for Log Data Read;
                return;
            }

            StringBuilder savedata = new StringBuilder();
            savedata.Clear();

            DateTime now = DateTime.FromOADate(currentDate);

            savedata.Append(now.ToString("yyyy-MM-dd HH:mm:ss") + ", ");
            savedata.Append((strText).ToString());
            savedata.Append(Environment.NewLine);

            System.IO.File.AppendAllText(fs3, savedata.ToString());
        }

        private void btGraphOpen_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication In Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            int mo = MainSelection.ModuleNumber;

            if (SystemParameter.ModuleOn[mo])
            {
                // 열린 그래픽창을 닫음
                m_frmSfModule[mo].Close();
                updateDisplayBox(String.Format("Close Module {0} Window", (mo + 1).ToString()));
            }
            else
            {
                // 그래픽창 신규 오픈
                m_frmSfModule[mo] = new frmSfModule(this, mo);
                updateDisplayBox(String.Format("Open Module {0} Window", (mo + 1).ToString()));
                m_frmSfModule[mo].Text = "SF Module # " + (mo + 1).ToString();
                m_frmSfModule[mo].Visible = true;
                // m_frmSfModule[mo].WindowState = FormWindowState.Maximized;

                UpdateChartWithRawData(mo);
                updateGraphOnly();

                // 열린창을 재로드한다.
                //  refreshfrmSfModule();

                relocatefrmSfModule(false);

                // change Full Scale;
                // cbTimeStep.SelectedIndex = 26;
                changeDisplayScale();

#if false
                // 17/12/18 그래프 재로드시 해당창의 Scale조정
                Chart chart = null;
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;
                    updateScaleDisplay(chart);
                }
#endif
            }

        }

        // Calibration Open
        private void btCalibration_Click(object sender, EventArgs e)
        {
            bool backupTopMost;
            bool backupTimerEnable;

            if (!Port.IsOpen)
            {
                updateDisplayBox("[ERR] Port is not available.");
                return;
            }

            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }

            frmCalibration calibration = new frmCalibration(this, MainSelection.ModuleNumber);
            m_frmCalibration = calibration;
            calibration.requestCommandEvent += new frmCalibration.FormSendDataHandler(callCommandEvent);
            //Controls.Add(calibration);

            //           backupTimerEnable = timer1.Enabled;
            backupTopMost = this.TopMost;
            this.TopMost = false;
            //            timer1.Enabled = false;
            Delay(250);

            calibration.ShowDialog();

            // 2017/11/24 Calibration이후 Start시 바로 OK되는 문제 수정, 
            //  수신되지 않는 Return Data가 남아 Command Return 데이터가 밀림
            Delay(2000);
            Port.DiscardInBuffer();
            Port.DiscardOutBuffer();
            CommandBufferClear();
            Delay(500);

            this.TopMost = backupTopMost;
            //            timer1.Enabled = backupTimerEnable;
        }

        // Command Call
        public void callCommandEvent(Object obj)
        {
            // Command 처리
            //updateListBox(String.Format("CMD#{0} from Calibration", MainSelection.ModuleNumber + 1));

            //sendCommandToModule((UInt16)(MainSelection.ModuleNumber + 1), COMM_CMD_CALIBRATION);
            sendCommandToModule((UInt16)(MainSelection.ModuleNumber + 1), COMM_CMD_CALIBRATION_CPT);
            waitRespondDataFromModule(100);

            UInt16[] valueRaw = new UInt16[SFChannelLength];
            if (RespondDataReceived == true)
            {
                CalibrationCommStatus = true;
                RespondDataReceived = false;
                /*
                if (recvBuf[15] == 1)
                {
                    updateListBox(String.Format("RET: CH {0} On going", recvBuf[14] + 1));
                }
                else
                {
                    updateListBox(String.Format("RET: OK"));
                    commandState++;
                }
                */

                int index = 10;         // Start index of Data

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // min MSB
                    valueRaw[ch] = recvBuf[index++];
                    valueRaw[ch] <<= 8;
                    // min LSB
                    valueRaw[ch] += recvBuf[index++];
                }
                commandState = 0;

            }
            else
            {
                CalibrationCommStatus = false;
            }
            for (int ch = 0; ch < SFChannelLength; ch++)
            {
                CalibrationResult[ch] = valueRaw[ch];
            }

            CalibrationDataReady = true;
            CommandBufferClear();
        }

        private void btStartAction_Click(object sender, EventArgs e)
        {
            if (Port.IsOpen)
            {
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    // Set Activate Command Set
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        commandModuleState[mo] = 0;
                    }
                    else
                    {
                        commandModuleState[mo] = 0xFF;      // Disabled
                    }
                }

                commandState = 0;


                // log파일을 새로 시작한다
                OutputFileInit();
                updateDisplayBox("Start Measurement");

                btSetup.Enabled = false;
                btRefresh.Enabled = false;
                btLog.Enabled = false;
                btCalibration.Enabled = false;
                btStartAction.Enabled = false;
                btStopAction.Enabled = true;
                //btGraphOpen.Enabled = false;
                //btBackupLog.Enabled = false;
                //btBackupLogDay.Enabled = false;
                //button3.Enabled = false;
                //btTmAdaptive.Enabled = false;

                // Start를 알림
                btStartAction.BackColor = Color.LawnGreen;
                btStartAction.UseVisualStyleBackColor = false;
                btStopAction.BackColor = Color.Ivory;
                btStopAction.UseVisualStyleBackColor = true;

                gbDebugSetting.Enabled = true;

                flagStarting = true;
                flagStarted = true;
                flagAllowAction = false;
                flagTimerInProgress = true;

                progressBar1.Visible = true;

                timer1_Tick(sender, e);

                queueStatusSFProg("sfstatus", "SF Measurement Started.");
                queueStatusSFProg(STAT_PROGRUN_START);
            }
            else
            {
                updateDisplayBox("[ERR] Port is not available.");
                queueStatusSFProg("sfstatus", "System(PORT) is not connected.");
            }
        }

        private void btStopAction_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                commandState = 0;
                if (timer1.Enabled)
                {
                    updateDisplayBox("Stop Measurement");
                }
                else
                {
                    updateDisplayBox("Aborting Measurement");
                }
                timer1.Stop();
            }

            flagStarted = false;

            btSetup.Enabled = true;
            btRefresh.Enabled = true;
            btLog.Enabled = true;
            btCalibration.Enabled = true;
            btStartAction.Enabled = true;
            btStopAction.Enabled = false;

            // Stop시 경고를 위해 DartOrange설정
            btStartAction.BackColor = Color.Ivory;
            btStartAction.UseVisualStyleBackColor = true;

            btStopAction.BackColor = Color.DarkOrange;
            btStopAction.UseVisualStyleBackColor = false;

            //btGraphOpen.Enabled = true;
            //btBackupLog.Enabled = true;
            //button3.Enabled = true;
            //btTmAdaptive.Enabled = true;

            gbDebugSetting.Enabled = true;

            flagAllowAction = true;
            flagTimerInProgress = false;

            progressBar1.Visible = false;
            if (this.Cursor != Cursors.Default)
            {
                this.Cursor = Cursors.Default;
            }

            queueStatusSFProg("sfstatus", "SF Measurement Stopped.");
            queueStatusSFProg(STAT_PROGRUN_STOP);
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

        private void btLog_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }

            if (flagLockClose)
            {
                updateDisplayBox("Prohibited during [Lock Close]");
                return;
            }

            if (cbValveControlEnable.CheckState == CheckState.Checked)
            {
                if (SystemParameter.ValveControlOn == false)
                {
                    btValveSetup_Click(sender, e);
                }
            }

            if (mModuleArray.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to clear the previous data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //code for Yes
                    m_SampleCount = 0;
                    m_TimeArray.Clear();
                    mModuleArray.Clear();
                    clearValveControlChart();
                }
                else if (result == DialogResult.No)
                {
                    //code for No
                }
            }

            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "*.log|*.*";
            open.InitialDirectory = Application.StartupPath + "\\log\\";
            open.Title = "Select Log file";

            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            int line = 0;

            StreamReader sr = new StreamReader(open.FileName);

            string strLog;

            if (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                line++;

                if (strLog != "Start")
                {
                    sr.Close();
                    MessageBoxAutoClose("It is not Real log file.");
                    return;
                }
            }

            flagLogReading = true;

            while (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                line++;
                btLog_Click_Repeat_Loop:
                if (strLog.StartsWith("["))     // 날짜 확인용
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
                            // parsing Channel Data
                            m_TimeArray.Add(pTime.ToOADate());// .ToString("yyyy-MM-dd HH:mm:ss"));
                            m_SampleCount++;

                            bool fDataExist = false;
                            while (sr.Peek() > -1)
                            {
                                strLog = sr.ReadLine();
                                line++;

                                if ((line % 10000) == 0)
                                {
                                    updateDisplayBox(String.Format("Loading... {0} lines", line.ToString()));
                                }

                                if (strLog.StartsWith("SF["))
                                {
                                    String strSF;
                                    // 채널벌 데이터를 분할함
                                    string[] spltStrArray = strLog.Split(' ');  // Space를 분리기호로 사용

                                    strSF = getInnerSideStringData(spltStrArray[0]);    // 모듈번호
                                    if ((strSF != null))// && (spltStrArray.Length == (SFChannelLength)))  // SF, CH0, CH1, ..., CHn, "" = 채널수 + 2 = Array Length
                                    {
                                        // 모듈번호 확인
                                        int mo = int.Parse(strSF) - 1;       // mo Index는 모듈번호 -1;

                                        foreach (string strCH in spltStrArray)
                                        {
                                            if (strCH.StartsWith("ch"))
                                            {
                                                if (strCH.Length > 6)   // 'c','h','0','[','/,'',]' 6 char 
                                                {
                                                    int ch = int.Parse(strCH.Substring(2, 1)) - 1; // ch Index는 채널번호 -1
                                                    if (ch < SFChannelLength)
                                                    {
                                                        // 채널번호 확인
                                                        string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                        if (strDataArray != null)
                                                        {
                                                            string[] spltStrDataArray = strDataArray.Split(',');  // ','를 분리기호로 사용
                                                            if (spltStrDataArray.Length == 2)
                                                            {
                                                                UInt16 initial, heated;
                                                                initial = UInt16.Parse(spltStrDataArray[0], System.Globalization.NumberStyles.HexNumber);
                                                                heated = UInt16.Parse(spltStrDataArray[1], System.Globalization.NumberStyles.HexNumber);

                                                                arrayInitialData[mo, ch] = initial;
                                                                arrayHeatedData[mo, ch] = heated;

                                                                if (!fDataExist) fDataExist = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            // Temperature or Humidity읽음
                                            if (strCH.StartsWith("TE[") || strCH.StartsWith("HU["))
                                            {
                                                if (strCH.Length > 5)   // 'T', 'E', '[', '/.', ]' 5 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float temperature, humidity;
                                                        if (strCH.StartsWith("TE["))
                                                        {
                                                            temperature = float.Parse(strDataArray);
                                                            arrayTemperatureData[mo] = temperature;
                                                        }
                                                        if (strCH.StartsWith("HU["))
                                                        {
                                                            humidity = float.Parse(strDataArray);
                                                            arrayHumidityData[mo] = humidity;
                                                        }
                                                    }
                                                }
                                            }

                                            // Parameter a
                                            if (strCH.StartsWith("a["))
                                            {
                                                if (strCH.Length > 4)   // 'a', '[', '/.', ]' 4 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float aValue;
                                                        aValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 0].a = aValue;
                                                        SystemParameter.Para[mo, 1].a = aValue;
                                                        SystemParameter.Para[mo, 2].a = aValue;
                                                        SystemParameter.Para[mo, 3].a = aValue;
                                                    }
                                                }
                                            }

                                            // Parameter b
                                            if (strCH.StartsWith("b["))
                                            {
                                                if (strCH.Length > 4)   // 'b', '[', '/.', ]' 4 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float bValue;
                                                        bValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 0].b = bValue;
                                                        SystemParameter.Para[mo, 1].b = bValue;
                                                        SystemParameter.Para[mo, 2].b = bValue;
                                                        SystemParameter.Para[mo, 3].b = bValue;
                                                    }
                                                }
                                            }

                                            // Parameter c
                                            if (strCH.StartsWith("c["))
                                            {
                                                if (strCH.Length > 4)   // 'c', '[', '/.', ]' 4 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float cValue;
                                                        cValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 0].c = cValue;
                                                        SystemParameter.Para[mo, 1].c = cValue;
                                                        SystemParameter.Para[mo, 2].c = cValue;
                                                        SystemParameter.Para[mo, 3].c = cValue;
                                                    }
                                                }
                                            }

                                            // Parameter Tm (OLD, Tm_CH1=Tm_CH2=Tm_CH3=Tm_CH4 = Tm)
                                            if (strCH.StartsWith("Tm["))
                                            {
                                                if (strCH.Length > 5)   // 'T','m','[', '/.', ]' 5 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float TmValue;
                                                        TmValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 0].Tm = TmValue;
                                                        SystemParameter.Para[mo, 1].Tm = TmValue;
                                                        SystemParameter.Para[mo, 2].Tm = TmValue;
                                                        SystemParameter.Para[mo, 3].Tm = TmValue;
                                                    }
                                                }
                                            }

                                            // Parameter Tm1 (Tm_CH1)
                                            if (strCH.StartsWith("Tm1["))
                                            {
                                                if (strCH.Length > 6)   // 'T','m','1','[', '/.', ]' 5 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float TmValue;
                                                        TmValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 0].Tm = TmValue;
                                                    }
                                                }
                                            }

                                            // Parameter Tm2 (Tm_CH2)
                                            if (strCH.StartsWith("Tm2["))
                                            {
                                                if (strCH.Length > 6)   // 'T','m','2','[', '/.', ]' 5 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float TmValue;
                                                        TmValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 1].Tm = TmValue;
                                                    }
                                                }
                                            }

                                            // Parameter Tm3 (Tm_CH3)
                                            if (strCH.StartsWith("Tm3["))
                                            {
                                                if (strCH.Length > 6)   // 'T','m','3','[', '/.', ]' 5 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float TmValue;
                                                        TmValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 2].Tm = TmValue;
                                                    }
                                                }
                                            }

                                            // Parameter Tm4 (Tm_CH4)
                                            if (strCH.StartsWith("Tm4["))
                                            {
                                                if (strCH.Length > 6)   // 'T','m','4','[', '/.', ]' 5 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        float TmValue;
                                                        TmValue = float.Parse(strDataArray);
                                                        SystemParameter.Para[mo, 3].Tm = TmValue;
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
                                else if (strLog.StartsWith("VC["))
                                {
                                    String strSF;
                                    // 채널벌 데이터를 분할함
                                    string[] spltStrArray = strLog.Split(' ');  // Space를 분리기호로 사용

                                    strSF = getInnerSideStringData(spltStrArray[0]);    // 모듈번호
                                    if ((strSF != null))// && (spltStrArray.Length == (SFChannelLength)))  // VC, CH0, CH1, ..., CHn, "" = 채널수 + 2 = Array Length
                                    {
                                        // 모듈번호 확인
                                        int mo = int.Parse(strSF) - 1;       // mo Index는 모듈번호 -1;

                                        foreach (string strCH in spltStrArray)
                                        {
                                            // chx[Enable, Min, Max, Contrain]
                                            if (strCH.StartsWith("ch"))
                                            {
                                                if (strCH.Length > 8)   // 'c' 'h' '0' '[' ','  ',' ','  ']' 8 char 
                                                {
                                                    int ch = int.Parse(strCH.Substring(2, 1)) - 1; // ch Index는 채널번호 -1
                                                    if (ch < SFChannelLength)
                                                    {
                                                        // 채널번호 확인
                                                        string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                        if (strDataArray != null)
                                                        {
                                                            //  chx[Enable, Min, Max, Contrain]
                                                            //  chx[Enable, Min, Max, Contrain,Ratio]  18/03/26 추가
                                                            string[] spltStrDataArray = strDataArray.Split(',');  // ','를 분리기호로 사용
                                                            if ((spltStrDataArray.Length == 4) || (spltStrDataArray.Length == 5))
                                                            {
                                                                Boolean EnableValue;
                                                                float MinValue, MaxValue;
                                                                int ConstrainValue, RatioValue;

                                                                EnableValue = Boolean.Parse(spltStrDataArray[0]);   // True or False
                                                                MinValue = float.Parse(spltStrDataArray[1]);
                                                                MaxValue = float.Parse(spltStrDataArray[2]);
                                                                ConstrainValue = int.Parse(spltStrDataArray[3]);
                                                                if (spltStrDataArray.Length == 5) // Ratio  18 / 03 / 26 추가
                                                                {
                                                                    RatioValue = int.Parse(spltStrDataArray[4]);
                                                                }
                                                                else
                                                                {
                                                                    RatioValue = 100;        // 기존 데이터와의 호환성유지
                                                                }

                                                                VCParameter.Enabled[mo, ch] = EnableValue;
                                                                VCParameter.Min[mo, ch] = MinValue;
                                                                VCParameter.Max[mo, ch] = MaxValue;
                                                                VCParameter.Constrain[mo, ch] = ConstrainValue;
                                                                VCParameter.Ratio[mo, ch] = RatioValue;

                                                                if (!fDataExist) fDataExist = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            // SET[시작시간, 종료시간, 최대시간, 최소시간, 단위적산량]
                                            if (strCH.StartsWith("SET"))
                                            {
                                                if (strCH.Length > 9)   // 'S' 'E' 'T' '[' ',' ',' ',' ',' ']' 9 char 
                                                {
                                                    string strDataArray = getInnerSideStringData(strCH);    // 데이터 어레이 
                                                    if (strDataArray != null)
                                                    {
                                                        //  SET[시작시간, 종료시간, 최대시간, 최소시간, 단위적산량]
                                                        string[] spltStrDataArray = strDataArray.Split(',');  // ','를 분리기호로 사용
                                                        if (spltStrDataArray.Length == 5)
                                                        {
                                                            DateTime StartTime;
                                                            DateTime EndTime;
                                                            TimeSpan MaxTime, MinTime;
                                                            int EventJouleValue;

                                                            IFormatProvider formatKor = new System.Globalization.CultureInfo("ko-KR", true);
                                                            StartTime = DateTime.ParseExact("20170801" + spltStrDataArray[0].Substring(0, 2) + spltStrDataArray[0].Substring(3, 2), "yyyyMMddHHmm", formatKor);   // True or False
                                                            EndTime = DateTime.ParseExact("20170801" + spltStrDataArray[1].Substring(0, 2) + spltStrDataArray[1].Substring(3, 2), "yyyyMMddHHmm", formatKor);   // True or False
                                                            MaxTime = TimeSpan.Parse(spltStrDataArray[2].Substring(0, 5) + ":00");
                                                            MinTime = TimeSpan.Parse(spltStrDataArray[3].Substring(0, 5) + ":00");
                                                            EventJouleValue = int.Parse(spltStrDataArray[4]);

                                                            VCParameter.StartTime = StartTime;
                                                            VCParameter.EndTime = EndTime;
                                                            VCParameter.MaxTime = MaxTime;
                                                            VCParameter.MinTime = MinTime;
                                                            VCParameter.EventJouleValue = EventJouleValue;

                                                            if ((TimeSpan.Compare(VCParameter.StartTime.TimeOfDay, TimeSpan.Zero) == 0) &&
                                                               (TimeSpan.Compare(VCParameter.EndTime.TimeOfDay, TimeSpan.Zero) == 0))
                                                            {
                                                                VCParameter.StartEndEnabled = false;
                                                            }
                                                            else
                                                            {
                                                                VCParameter.StartEndEnabled = true;
                                                            }

                                                            if ((TimeSpan.Compare(VCParameter.MaxTime, TimeSpan.Zero) == 0) &&
                                                                (TimeSpan.Compare(VCParameter.MinTime, TimeSpan.Zero) == 0))
                                                            {
                                                                VCParameter.MaxMinEnabled = false;
                                                            }
                                                            else
                                                            {
                                                                VCParameter.StartEndEnabled = true;
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
                                    // 모든 모듈데이터를 읽음, 다음 스텝[날짜확인]으로 이동
                                    // 데이터는  arrayInitialData[mo, ch],  arrayHeatedData[mo, ch]에 저장됨
                                    // Update Data Point
                                    // pTime.ToOADate(), mo, ch, initail, heated
                                    if (fDataExist) updateLoadDataToModuleArray(pTime.ToOADate());
                                    goto btLog_Click_Repeat_Loop;
                                }
                            }  //while (sr.Peek() > -1)

                            // 마지막 데이터 저장
                            if (fDataExist) updateLoadDataToModuleArray(pTime.ToOADate());

                        }  // (DateTime.TryParse(str, out pTime))
                        else
                        {
                            //MessageBoxAutoClose("Real 정상데이터가 아닙니다");
                            MessageBoxAutoClose("It is not Real Log File.");
                            break;
                        }
                    } //(str != null)
                } // (strLog.StartsWith("["))

            }

            flagLogReading = false;

            // 열린창을 재로드한다.
            refreshfrmSfModule();
            refreshfrmMultiModules();

            relocatefrmSfModule(false);

            // change Full Scale;
            // 기존값 유지
            //cbTimeStep.SelectedIndex = 26;

            changeDisplayScale();

            // 밸브컨트롤용 데이터 업데이트(17/08/10)
            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
            {
                m_frmValveControl.btLoadParameter_Click(sender, e);
                fgRequestValveControlUpdate = true;
            }

            //            MessageBoxAutoClose(String.Format("{0} 라인을 읽었습니다", line));
            MessageBoxAutoClose(String.Format("{0} lines. are updated.", line));
        }

        private void MessageBoxAutoClose(string message)
        {
            frmMessageBox mBox = new frmMessageBox(message);
            m_frmMessageBox = mBox;
            m_frmMessageBox.Visible = true;
            m_frmMessageBox.Show();
        }

        private void updateLoadDataToModuleArray(double epoch)
        {
            for (int ch = 0; ch < SFChannelLength; ch++)
            {
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    // 활성화된 창만 업데이트 0525
                    if (SystemParameter.ModuleEnable[mo] == false) continue;
                    // if (SystemParameter.ModuleOn[mo] == false) continue; --> 모듈ON아닌경우 valueSF가 업데이트 안됨

                    // Update Channel Data, 차후 모듈번호 업데이트 필요
                    // 모듈데이터가 업데이트 되지않아 Count는 증가되지 않은상태
                    preprocessingParameter(mModuleArray.Count + 1, mo, ch, arrayInitialData[mo, ch], arrayHeatedData[mo, ch]);
                }

            }
            double currentDate = epoch;

            // DATA MANANGEMENT: OADate Update
            totalRawModuleData totalData = new totalRawModuleData();
            totalData.OADate = currentDate;
            totalData.Index = m_SampleCount;

            // DATA MANANGEMENT: Valve Control Data Update
            rawValveControData rawVCdata = null;
            rawVCdata = totalData.rawValveControl;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                rawModuleData rawdata = null;
                if (SystemParameter.ModuleEnable[mo])
                {
                    totalData.rawModudle[mo] = new rawModuleData();
                    rawdata = totalData.rawModudle[mo];

                    // DATA MANANGEMENT: module Number Update
                    rawdata.moduleDefine.mType = ModuleType_SF;
                    rawdata.moduleDefine.mSubtype = ModuleSubType;
                    rawdata.moduleDefine.mModuleNumber = (UInt16)mo;

                    //  DATA MANANGEMENT: Additional Data Update(Parameter, ...)
                    mTemperature[mo] = arrayTemperatureData[mo];
                    mHumidity[mo] = arrayHumidityData[mo];

                }

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // ch = channel number 0 ~ SFChannelLength(채널수)
                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                    {
                        // DATA MANANGEMENT: Channel Data Update
                        //rawdata.CHData[ch].InitialTemperature =(UInt16)(ch + mo * 16); //;// (UInt16)valueSF[ch] + ch+ SFModule * 16;
                        //rawdata.CHData[ch].HeatedTemperature = (UInt16)(ch + mo * 16); ;  // (UInt16)valueRTemp[ch]+ ch + SFModule * 16;
                        rawdata.CHData[ch].InitialTemperature = arrayInitialData[mo, ch];
                        rawdata.CHData[ch].HeatedTemperature = arrayHeatedData[mo, ch];

                        rawdata.additionalData = new AdditionalData(mTemperature[mo], mHumidity[mo], mSoilMoisture[mo], SystemParameter.Para[mo, ch].a, SystemParameter.Para[mo, ch].b, SystemParameter.Para[mo, ch].c, SystemParameter.Para[mo, 0].Tm, SystemParameter.Para[mo, 1].Tm, SystemParameter.Para[mo, 2].Tm, SystemParameter.Para[mo, 3].Tm);

                        // VC관련 파라메터 업데이트
                        rawVCdata.Enabled[mo, ch] = VCParameter.Enabled[mo, ch];
                        rawVCdata.Max[mo, ch] = VCParameter.Max[mo, ch];
                        rawVCdata.Min[mo, ch] = VCParameter.Min[mo, ch];
                        rawVCdata.Constrain[mo, ch] = VCParameter.Constrain[mo, ch];
                        rawVCdata.Ratio[mo, ch] = VCParameter.Ratio[mo, ch];

                    }
                }
            }
            //epoch++;

            // VC관련 파라메터 업데이트
            rawVCdata.EventJouleValue = VCParameter.EventJouleValue;
            rawVCdata.StartTime = VCParameter.StartTime;
            rawVCdata.EndTime = VCParameter.EndTime;
            rawVCdata.MaxTime = VCParameter.MaxTime;
            rawVCdata.MinTime = VCParameter.MinTime;

            UpdateModuleArrayData(currentDate, totalData);
        }

        private void UpdateModuleArrayData(double currentDate, totalRawModuleData Data)
        {
            mModuleArray.Add(Data);
            if (flagLogReading == true)
            {
                // Skip for Log Data Read;
            }
            else
            {
#if (SERVER_INCLUDED)
#if (SERVER_COMMUNICATION)
                if (fgMQTTEnabled == true)
                {
                    queueSFData.Enqueue(Data);
                }
#endif  //  SERVER_COMMUNICATION
#endif  // SERVER_INCLUDED
            }

            // 밸브컨트롤용 데이터 업데이트(17/08/10)
            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
            {
                updateValveControlChart(currentDate);
                updateValveControlEvent(currentDate);
                fgRequestValveControlUpdate = true;

            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to clear the data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //code for Yes 
                m_SampleCount = 0;
                m_TimeArray.Clear();
                mModuleArray.Clear();

                // 
                MultiRawColumnSize = new Size(256, 256);    // Default undefined Max Size

                OutputFileInit();

                if (SystemParameter.ValveControlOn)
                {
                    clearValveControlCount();
                    m_frmValveControl.Close();
                    SystemParameter.ValveControlOn = false;
                }

                refreshfrmSfModule();
                refreshfrmMultiModules();

                if (fgGraphParameterSaved)
                {
                    // 저장된 위치 있음
                    relocatefrmSfModule(false);
                }
                else
                {
                    // 위치초기화
                    relocatefrmSfModule(true);
                }
            }
            else if (result == DialogResult.No)
            {
                //code for No
            }
        }

        private void SF_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                e.Cancel = true;
                return;
            }

            // return;
            btBackupLog.PerformClick();     // 강제 종료되는경우를 대비하여 백업을 한번 수행

            queueStatusSFProg("sfstatus", "SF Program is closing.");

            if (flagLockClose)
            {
                MessageBoxAutoClose(String.Format("Please uncheck [Lock Contol] to exit the program."));
                e.Cancel = true;
            }
            else if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                e.Cancel = true;
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to exit the program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //code for Yes
                    if (mModuleArray.Count > 0)
                    {
                        DialogResult result1 = MessageBox.Show("Do you want to backup the data?", "System Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result1 == DialogResult.Yes)
                        {
                            btBackupLog.PerformClick();
                        }
                    }

                    result = MessageBox.Show("Do you really want to exit the program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //code for Yes
                    }
                    else if (result == DialogResult.No)
                    {
                        //code for No
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.No)
                {
                    if (notifyIcon1.Visible == false)
                    {
                        DialogResult result3 = MessageBox.Show("Do you want to hide the Main Panel?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result3 == DialogResult.Yes)
                        {
                            //code for Yes
                            // Go to trayicon
                            e.Cancel = true;
                            notifyIcon_Activate();
                            return;
                        }
                    }
                    //code for No
                    e.Cancel = true;
                }

                // End Process
                saveGraphDefaultParameter();

#if (SERVER_INCLUDED)
                // Send initial Status
                initSFProgStatus();
                queueStatusSFProg("sfstatus", "SF Program is closed.");

                for (int i = 0; i < 10; i++)    // Wait 15 seconds
                {
                    Delay(1000);      // wait 10ms
                    if(queueSFProg.Count==0)
                    {
                        break;
                    }
                }

#if (SERVER_COMMUNICATION)
                fgProgramRun = false; // to stop thread 
                tMQTT.Join();
#endif  //  SERVER_COMMUNICATION
#endif  // SERVER_INCLUDED
            }
        }

        private void cbLockControl_CheckedChanged(object sender, EventArgs e)
        {
            bool fgChecked = cbLockControl.Checked;

            flagLockControl = fgChecked;
            flagLockClose = fgChecked;

            bool fgUnLock;
            if (fgChecked == true)
            {
                fgUnLock = false;
            }
            else
            {
                fgUnLock = true;
            }

            btConnectControl.Enabled = fgUnLock;
            gbDebugSetting.Enabled = fgUnLock;
            gbValveControl.Enabled = fgUnLock;
            gbDebugSetting.Enabled = fgUnLock;
            gbParameterSetting.Enabled = fgUnLock;
            gbSystemSetting.Enabled = fgUnLock;
            listBox1.Enabled = fgUnLock;

            cbDataFilterON.Enabled = fgUnLock;
            btGraphOpen.Enabled = fgUnLock;
            btBackupLog.Enabled = fgUnLock;
            btBackupLogDay.Enabled = fgUnLock;
            button3.Enabled = fgUnLock;
            btTmAdaptive.Enabled = fgUnLock;

            btValveEventOn.Enabled = fgUnLock;
            btValveControlGraph.Enabled = fgUnLock;

            btSetup.Enabled = fgUnLock;
            btRefresh.Enabled = fgUnLock;
            btLog.Enabled = fgUnLock;
            button6.Enabled = fgUnLock;

            btCalibration.Enabled = fgUnLock;
            btExportSF.Enabled = fgUnLock;
            btParaSet.Enabled = fgUnLock;
            btParaSet_Offset.Enabled = fgUnLock;
            btParaReset_Offset.Enabled = fgUnLock;
            tbParaSet_Tm.Enabled = fgUnLock;
            tbParaSet_Tm_Offset.Enabled = fgUnLock;
            btMultiViewOpen.Enabled = fgUnLock;

            cbDisposeData.Enabled = fgUnLock;
            cbDisposeVCData.Enabled = fgUnLock;

            // Start Stop Action
            if (fgUnLock == true)
            {
                if (Port.IsOpen)
                {
                    if (flagStarted)
                    {
                        btStopAction.Enabled = true;
                    }
                    else
                    {
                        btStartAction.Enabled = true;
                    }
                }
                queueStatusSFProg(STAT_STATUSREQ_STOP);
            }
            else
            {
                btStartAction.Enabled = fgUnLock;
                btStopAction.Enabled = fgUnLock;

                queueStatusSFProg(STAT_STATUSREQ_START);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int line = 0;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                return;
            }
            updateDisplayBox("Data Export...");

            StringBuilder savedata = new StringBuilder();

            if (mModuleArray.Count == 0) return;

            string outputPath = Application.StartupPath + "\\log\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            fs2 = outputPath + "SNU" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
            StreamWriter sw = new StreamWriter(fs2);
            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
            {
                sw.Write("Date, Module Number, Channel Number, Initial Temp., Last Temp., Diff Temp.,Temperature, Humidity, VPD, a, b, c, Tm, SF_Value, Enable, VC_Min, VC_Max, VC_Constrain, VC_Ratio, scaled SF, merged SF, accumulated SF, integrated Value" + Environment.NewLine);
            }
            else
            {
                sw.Write("Date, Module Number, Channel Number, Initial Temp., Last Temp., Diff Temp.,Temperature, Humidity, VPD, a, b, c, Tm, SF_Value" + Environment.NewLine);
            }

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

                            // Temperature, Humidity
                            savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.ExternalTemperature.ToString("00.##"));
                            savedata.Append(", ");
                            savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.ExternalHumidity.ToString("00.##"));
                            savedata.Append(", ");

                            // VPD

                            savedata.Append(calculateVPD(mModuleArray[cnt].rawModudle[mo].additionalData.ExternalTemperature,
                                (mModuleArray[cnt].rawModudle[mo].additionalData.ExternalHumidity)).ToString("0.###"));
                            savedata.Append(", ");

                            // a, b, c, Tm
                            savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_a.ToString());
                            savedata.Append(", ");
                            savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_b.ToString());
                            savedata.Append(", ");
                            savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_c.ToString());
                            savedata.Append(", ");
                            if (ch == 0)
                            {
                                savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1.ToString());
                            }
                            else if (ch == 1)
                            {
                                savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2.ToString());
                            }
                            else if (ch == 2)
                            {
                                savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3.ToString());
                            }
                            else if (ch == 3)
                            {
                                savedata.Append(mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4.ToString());
                            }
                            savedata.Append(", ");

                            savedata.Append(calculateSFParameter(mo, ch, tempInit, tempHeat).ToString());

                            // Enable, Parameter, Scaled Value, Accumulated Value
                            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
                            {
                                savedata.Append(", ");

                                Chart chart = null;
                                chart = m_frmValveControl.chart1;

                                // Enable
                                if (VCParameter.Enabled[mo, ch] == true)
                                {
                                    savedata.Append("true, ");
                                }
                                else
                                {
                                    savedata.Append("false, ");
                                }

                                // VC_Min
                                savedata.Append(VCParameter.Min[mo, ch].ToString());
                                savedata.Append(", ");

                                // VC_Max
                                savedata.Append(VCParameter.Max[mo, ch].ToString());
                                savedata.Append(", ");

                                // VC_Constrain
                                savedata.Append(VCParameter.Constrain[mo, ch].ToString());
                                savedata.Append(", ");

                                // VC_Ratio
                                savedata.Append(VCParameter.Ratio[mo, ch].ToString());
                                savedata.Append(", ");

                                // Scaled_Value
                                if (chart.Series[mo * 4 + ch].Points.Count > 0)
                                {
                                    savedata.Append(chart.Series[mo * 4 + ch].Points[cnt].YValues[0].ToString());
                                    savedata.Append(", ");
                                }

                                // Merged_Value
                                if (chart.Series[mo * 4 + ch].Points.Count > 0)
                                {
                                    savedata.Append(chart.Series["mergedSFValue"].Points[cnt].YValues[0].ToString());
                                    savedata.Append(", ");
                                }

                                // Accumulated SF Value
                                if (chart.Series[mo * 4 + ch].Points.Count > 0)
                                {
                                    savedata.Append(chart.Series["totalSFValue"].Points[cnt].YValues[0].ToString());
                                    savedata.Append(", ");
                                }




                                // IntegratedValue
                                if (chart.Series[mo * 4 + ch].Points.Count > 0)
                                {
                                    savedata.Append(chart.Series["IntegratedValue"].Points[cnt].YValues[0].ToString());
                                    savedata.Append(", ");
                                }

                                // ValveControl
                                if (chart.Series[mo * 4 + ch].Points.Count > 0)
                                {
                                    //                                savedata.Append(chart.Series["ValveControl"].Points[cnt].YValues[0].ToString());
                                }

                                savedata.Append(Environment.NewLine);
                            }

                            line++;
                        }
                    }
                }
                sw.Write(savedata.ToString());
            }
            sw.Close();
            updateDisplayBox(String.Format("Done, {0} Line Updated.", line));
        }

        private void btBackupLog_Click(object sender, EventArgs e)
        {
            int line = 0;
            float progress;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                queueStatusSFProg("sfstatus", "No data stored.");
                return;
            }
            updateDisplayBox("Data Backup...");
            queueStatusSFProg(STAT_BACKUPREQ_START);

            StringBuilder savedata = new StringBuilder();

            if (mModuleArray.Count == 0) return;

            string outputPath = Application.StartupPath + "\\log\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            fs2 = outputPath + "BackupLog" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write("Start" + Environment.NewLine);

            for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
            {
                if ((cnt % 500) == 0)
                {
                    progress = 100 * (float)cnt / (float)mModuleArray.Count;
                    updateDisplayBox(String.Format("Wait {0}%, Index={1}", progress.ToString("0"), cnt.ToString()));
                }
                savedata.Clear();

                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[cnt].OADate);

                // Date
                savedata.Append(tempDate.ToString("[yyyy-MM-dd HH:mm:ss]") + ", Index=" + cnt.ToString());
                savedata.Append(Environment.NewLine);

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        // SF[##]
                        savedata.Append("SF[");
                        savedata.Append((mo + 1).ToString("D2"));
                        savedata.Append("] ");       // 모듈 번호는 1 ~ N

                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                // Channel Data
                                UInt16 tempInit, tempHeat;
                                tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                                tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;

                                savedata.Append(" ch");
                                savedata.Append((ch + 1).ToString());
                                savedata.Append("[");
                                savedata.Append(tempInit.ToString("x2"));
                                savedata.Append(",");
                                savedata.Append(tempHeat.ToString("x2"));
                                savedata.Append("]");
                            }
                        }

                        // Temperature, Humidity
                        savedata.Append(" TE[" + mModuleArray[cnt].rawModudle[mo].additionalData.ExternalTemperature.ToString() + "]");
                        savedata.Append(" HU[" + mModuleArray[cnt].rawModudle[mo].additionalData.ExternalHumidity.ToString() + "]");

                        // Parameter
                        savedata.Append(" a[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_a.ToString() + "]");    // a, b, c CH1으로 통일
                        savedata.Append(" b[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_b.ToString() + "]");
                        savedata.Append(" c[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_c.ToString() + "]");
                        savedata.Append(" Tm1[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1.ToString() + "]");
                        savedata.Append(" Tm2[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2.ToString() + "]");
                        savedata.Append(" Tm3[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3.ToString() + "]");
                        savedata.Append(" Tm4[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4.ToString() + "]");
                        savedata.Append(Environment.NewLine);
                        line++;
                    }
                }

                // VC Parameter Print
                bool fgPrintVCParameter = false;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if ((cnt == 0) || (cnt == mModuleArray.Count - 1))
                        {
                            // 처음과 마지막엔 무조건 출력
                            fgPrintVCParameter = true;
                        }
                        else
                        {
                            // 파라메터가 변경된 경우만 출력
                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    if (mModuleArray[cnt].rawValveControl.Enabled[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Enabled[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Max[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Max[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Min[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Min[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Constrain[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Constrain[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Ratio[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Ratio[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                }
                            }

                            if (mModuleArray[cnt].rawValveControl.EventJouleValue != mModuleArray[cnt - 1].rawValveControl.EventJouleValue)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (DateTime.Compare(mModuleArray[cnt].rawValveControl.StartTime, mModuleArray[cnt - 1].rawValveControl.StartTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (DateTime.Compare(mModuleArray[cnt].rawValveControl.EndTime, mModuleArray[cnt - 1].rawValveControl.EndTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (TimeSpan.Compare(mModuleArray[cnt].rawValveControl.MaxTime, mModuleArray[cnt - 1].rawValveControl.MaxTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (TimeSpan.Compare(mModuleArray[cnt].rawValveControl.MinTime, mModuleArray[cnt - 1].rawValveControl.MinTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }
                        }
                    }
                }

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    // VC 파라메터 출력
                    if (fgPrintVCParameter)
                    {
                        if (SystemParameter.ModuleEnable[mo])
                        {
                            // VC[##]
                            savedata.Append("VC[");
                            savedata.Append((mo + 1).ToString("D2"));
                            savedata.Append("] ");       // 모듈 번호는 1 ~ N

                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    // Channel Data
                                    savedata.Append(" ch");
                                    savedata.Append((ch + 1).ToString());
                                    savedata.Append("[");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Enabled[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Min[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Max[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Constrain[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Ratio[mo, ch].ToString());
                                    savedata.Append("]");
                                }
                            }

                            DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

                            savedata.Append(" SET[");
                            savedata.Append(mModuleArray[cnt].rawValveControl.StartTime.ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append(mModuleArray[cnt].rawValveControl.EndTime.ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append((dt + mModuleArray[cnt].rawValveControl.MaxTime).ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append((dt + mModuleArray[cnt].rawValveControl.MinTime).ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append(mModuleArray[cnt].rawValveControl.EventJouleValue.ToString());
                            savedata.Append("]");
                            savedata.Append(Environment.NewLine);
                            line++;
                        }

                    }
                }
                sw.Write(savedata.ToString());
            }

            progress = 100;
            updateDisplayBox(String.Format("Done, {0}%, Index={1}", progress.ToString(), mModuleArray.Count.ToString()));
            sw.Close();

            queueStatusSFProg("sfstatus", String.Format("Backup is completed(Index={0}). ", mModuleArray.Count.ToString()));
            queueStatusSFProg(STAT_BACKUPREQ_STOP);
        }

        private void AutoBackup()
        {
            AB_Backup();

            AB_ExportSF();
        }
        
        private void AB_Backup()
        {
            int line = 0;
            float progress;

            /*if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }*/

            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                queueStatusSFProg("sfstatus", "No data stored.");
                return;
            }
            updateDisplayBox("Data Backup...");
            queueStatusSFProg(STAT_BACKUPREQ_START);

            StringBuilder savedata = new StringBuilder();

            if (mModuleArray.Count == 0) return;

            string outputPath = Application.StartupPath + "\\log\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            fs2 = outputPath + "AutoBackuplog" + System.DateTime.Now.ToString("yyMM").Replace(':', '-') + ".txt";
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write("Start" + Environment.NewLine);

            for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
            {
                if ((cnt % 500) == 0)
                {
                    progress = 100 * (float)cnt / (float)mModuleArray.Count;
                    updateDisplayBox(String.Format("Wait {0}%, Index={1}", progress.ToString("0"), cnt.ToString()));
                }
                savedata.Clear();

                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[cnt].OADate);

                // Date
                savedata.Append(tempDate.ToString("[yyyy-MM-dd HH:mm:ss]") + ", Index=" + cnt.ToString());
                savedata.Append(Environment.NewLine);

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        // SF[##]
                        savedata.Append("SF[");
                        savedata.Append((mo + 1).ToString("D2"));
                        savedata.Append("] ");       // 모듈 번호는 1 ~ N

                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                // Channel Data
                                UInt16 tempInit, tempHeat;
                                tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                                tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;

                                savedata.Append(" ch");
                                savedata.Append((ch + 1).ToString());
                                savedata.Append("[");
                                savedata.Append(tempInit.ToString("x2"));
                                savedata.Append(",");
                                savedata.Append(tempHeat.ToString("x2"));
                                savedata.Append("]");
                            }
                        }

                        // Temperature, Humidity
                        savedata.Append(" TE[" + mModuleArray[cnt].rawModudle[mo].additionalData.ExternalTemperature.ToString() + "]");
                        savedata.Append(" HU[" + mModuleArray[cnt].rawModudle[mo].additionalData.ExternalHumidity.ToString() + "]");

                        // Parameter
                        savedata.Append(" a[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_a.ToString() + "]");    // a, b, c CH1으로 통일
                        savedata.Append(" b[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_b.ToString() + "]");
                        savedata.Append(" c[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_c.ToString() + "]");
                        savedata.Append(" Tm1[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1.ToString() + "]");
                        savedata.Append(" Tm2[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2.ToString() + "]");
                        savedata.Append(" Tm3[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3.ToString() + "]");
                        savedata.Append(" Tm4[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4.ToString() + "]");
                        savedata.Append(Environment.NewLine);
                        line++;
                    }
                }

                // VC Parameter Print
                bool fgPrintVCParameter = false;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if ((cnt == 0) || (cnt == mModuleArray.Count - 1))
                        {
                            // 처음과 마지막엔 무조건 출력
                            fgPrintVCParameter = true;
                        }
                        else
                        {
                            // 파라메터가 변경된 경우만 출력
                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    if (mModuleArray[cnt].rawValveControl.Enabled[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Enabled[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Max[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Max[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Min[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Min[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Constrain[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Constrain[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Ratio[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Ratio[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                }
                            }

                            if (mModuleArray[cnt].rawValveControl.EventJouleValue != mModuleArray[cnt - 1].rawValveControl.EventJouleValue)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (DateTime.Compare(mModuleArray[cnt].rawValveControl.StartTime, mModuleArray[cnt - 1].rawValveControl.StartTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (DateTime.Compare(mModuleArray[cnt].rawValveControl.EndTime, mModuleArray[cnt - 1].rawValveControl.EndTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (TimeSpan.Compare(mModuleArray[cnt].rawValveControl.MaxTime, mModuleArray[cnt - 1].rawValveControl.MaxTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (TimeSpan.Compare(mModuleArray[cnt].rawValveControl.MinTime, mModuleArray[cnt - 1].rawValveControl.MinTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }
                        }
                    }
                }

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    // VC 파라메터 출력
                    if (fgPrintVCParameter)
                    {
                        if (SystemParameter.ModuleEnable[mo])
                        {
                            // VC[##]
                            savedata.Append("VC[");
                            savedata.Append((mo + 1).ToString("D2"));
                            savedata.Append("] ");       // 모듈 번호는 1 ~ N

                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    // Channel Data
                                    savedata.Append(" ch");
                                    savedata.Append((ch + 1).ToString());
                                    savedata.Append("[");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Enabled[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Min[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Max[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Constrain[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Ratio[mo, ch].ToString());
                                    savedata.Append("]");
                                }
                            }

                            DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

                            savedata.Append(" SET[");
                            savedata.Append(mModuleArray[cnt].rawValveControl.StartTime.ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append(mModuleArray[cnt].rawValveControl.EndTime.ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append((dt + mModuleArray[cnt].rawValveControl.MaxTime).ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append((dt + mModuleArray[cnt].rawValveControl.MinTime).ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append(mModuleArray[cnt].rawValveControl.EventJouleValue.ToString());
                            savedata.Append("]");
                            savedata.Append(Environment.NewLine);
                            line++;
                        }

                    }
                }
                sw.Write(savedata.ToString());
            }

            progress = 100;
            updateDisplayBox(String.Format("Done, {0}%, Index={1}", progress.ToString(), mModuleArray.Count.ToString()));
            sw.Close();

            queueStatusSFProg("sfstatus", String.Format("Backup is completed(Index={0}). ", mModuleArray.Count.ToString()));
            queueStatusSFProg(STAT_BACKUPREQ_STOP);
        }

        private void AB_ExportSF()
        {
            int line = 0;
            DateTime latestTime, currentTime;

            updateDisplayBox("SF Data Export...");

            StringBuilder savedata = new StringBuilder();

            if (mModuleArray.Count == 0) return;

            string outputPath = Application.StartupPath + "\\log_SF\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            Boolean fgFullBackup = false;

            if (mModuleArray.Count > 0)
            {
                latestTime = DateTime.FromOADate(mModuleArray[mModuleArray.Count - 1].OADate);
                currentTime = latestTime.Date;

                TimeSpan backupTerm = getBackupTermTimeSpan(cbBackupTerm.SelectedIndex);

                if (backupTerm <= new TimeSpan(0))
                {
                    // Full
                    fgFullBackup = true;
                    latestTime = DateTime.FromOADate(mModuleArray[0].OADate).Date;
                }
                if (backupTerm < new TimeSpan(1, 0, 0, 0))
                {
                    // Today
                    latestTime = latestTime.Date;
                }
                else
                {
                    int TotalDays = (int)backupTerm.TotalDays * -1;
                    latestTime = latestTime.Date.AddDays(TotalDays);
                }

                // 초기 데이터 시작일보다 작은경우에는 초기 시작일을 기준
                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[0].OADate);

                if (DateTime.Compare(latestTime, tempDate.Date) <= 0)
                {
                    latestTime = tempDate.Date;
                }
            }
            else
            {
                // 데이터취합된것이 없는경우 시스템 날짜 이용
                latestTime = System.DateTime.Now;
                currentTime = latestTime;
            }
            fs2 = outputPath + "AutoBackup_SF" + DateTime.Now.ToString("yyMM").Replace(':', '-') + ".txt";
            StreamWriter sw = new StreamWriter(fs2);

            savedata.Clear();
            savedata.Append("Date, ");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                    {
                        savedata.Append("SF[");
                        savedata.Append((mo + 1).ToString());
                        savedata.Append("-");
                        savedata.Append((ch + 1).ToString());
                        savedata.Append("], ");
                    }
                }
            }

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                    {
                        savedata.Append("RT[");
                        savedata.Append((mo + 1).ToString());
                        savedata.Append("-");
                        savedata.Append((ch + 1).ToString());
                        savedata.Append("], ");
                    }
                }
            }

            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
            {
                savedata.Append("AVG");
            }
            savedata.Append(Environment.NewLine);
            sw.Write(savedata.ToString());

            int firstCount = -1;

            for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
            {
                savedata.Clear();

                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[cnt].OADate);

                if (firstCount == -1)
                {
                    if (DateTime.Compare(tempDate, latestTime) < 0)
                    {
                        if (fgFullBackup == true)
                        {
                            firstCount = cnt;
                        }
                        else
                        {
                            // 오늘날짜만 백업
                            continue;
                        }

                    }
                    else
                    {
                        firstCount = cnt;
                    }
                }



                // Date
                savedata.Append(tempDate.ToString("yyyy-MM-dd HH:mm:ss"));
                savedata.Append(", ");


                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                        {
                            // Initial Temp., Last Temp., Diff Temp.
                            UInt16 tempInit, tempHeat;
                            int tempDiff;
                            tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                            tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;
                            tempDiff = tempHeat - tempInit;

                            savedata.Append(calculateSFParameter(mo, ch, tempInit, tempHeat).ToString());
                            savedata.Append(", ");
                        }
                    }
                }

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                        {
                            // Initial Temp., Last Temp., Diff Temp.
                            UInt16 tempInit, tempHeat;
                            int tempDiff;
                            tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                            tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;
                            tempDiff = tempHeat - tempInit;

                            savedata.Append(calculateRTempParameter(mo, ch, tempInit, tempHeat).ToString());
                            savedata.Append(", ");
                        }

                    }
                }

                if (cbDisposeVCData.Checked == false)
                {
                    if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
                    {
                        Chart chart = null;
                        chart = m_frmValveControl.chart1;

                        // Merged_Value
                        if (chart.Series["mergedSFValue"].Points.Count > 0)
                        {
                            savedata.Append(chart.Series["mergedSFValue"].Points[cnt].YValues[0].ToString());
                            savedata.Append(", ");
                        }
                    }
                }
                savedata.Append(Environment.NewLine);
                sw.Write(savedata.ToString());
                line++;

            }

            sw.Close();
            updateDisplayBox(String.Format("Done, {0} Line Updated.", line));
        }

        // index = index of cbList 
        private TimeSpan getBackupTermTimeSpan(int index)
        {
            TimeSpan timeSpan;

            if (index <= listBackupTermComobBox.Length)
            {
                timeSpan = listBackupTermComobBox[index];
            }
            else
            {
                // 범위를 벗어난경우 Full Scale로 동작
                timeSpan = new TimeSpan(0);
            }

            return (timeSpan);
        }

        private void btBackupLogCPT_Click(object sender, EventArgs e)
        {
            int line = 0;
            float progress;
            DateTime latestTime, currentTime;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                return;
            }
            updateDisplayBox("Data Backup...");

            StringBuilder savedata = new StringBuilder();

            if (mModuleArray.Count == 0) return;

            string outputPath = Application.StartupPath + "\\log_daily\\" + System.DateTime.Now.ToString("yy-MM-dd") + "\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            Boolean fgFullBackup = false;
            if (mModuleArray.Count > 0)
            {
                latestTime = DateTime.FromOADate(mModuleArray[mModuleArray.Count - 1].OADate);
                currentTime = latestTime.Date;

                TimeSpan backupTerm = getBackupTermTimeSpan(cbBackupTerm.SelectedIndex);

                if (backupTerm <= new TimeSpan(0))
                {
                    // Full
                    fgFullBackup = true;
                    latestTime = DateTime.FromOADate(mModuleArray[0].OADate).Date;
                }
                if (backupTerm < new TimeSpan(1, 0, 0, 0))
                {
                    // Today
                    latestTime = latestTime.Date;
                }
                else
                {
                    int TotalDays = (int)backupTerm.TotalDays * -1;
                    latestTime = latestTime.Date.AddDays(TotalDays);
                }

                // 초기 데이터 시작일보다 작은경우에는 초기 시작일을 기준
                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[0].OADate);

                if (DateTime.Compare(latestTime, tempDate.Date) <= 0)
                {
                    latestTime = tempDate.Date;
                }
            }
            else
            {
                // 데이터취합된것이 없는경우 시스템 날짜 이용
                latestTime = System.DateTime.Now;
                currentTime = latestTime;
            }
            fs2 = outputPath + "DayLog" + DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + "(" + latestTime.ToString("MMdd").Replace(':', '-') + "-" + currentTime.ToString("MMdd").Replace(':', '-') + ").txt";
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write("Start" + Environment.NewLine);


            int firstCount = -1;

            for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
            {
                currentTime = DateTime.FromOADate(mModuleArray[cnt].OADate);
                if (firstCount == -1)
                {
                    if (DateTime.Compare(currentTime, latestTime) < 0)
                    {
                        if (fgFullBackup == true)
                        {
                            firstCount = cnt;
                        }
                        else
                        {
                            // 오늘날짜만 백업
                            continue;
                        }

                    }
                    else
                    {
                        firstCount = cnt;
                    }
                }

                if ((cnt % 500) == 0)
                {
                    progress = 100 * (float)cnt / (float)mModuleArray.Count;
                    updateDisplayBox(String.Format("Wait {0}%, Index={1}", progress.ToString("0"), cnt.ToString()));
                }
                savedata.Clear();

                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[cnt].OADate);

                // Date
                savedata.Append(tempDate.ToString("[yyyy-MM-dd HH:mm:ss]") + ", Index=" + cnt.ToString());
                savedata.Append(Environment.NewLine);

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        // SF[##]
                        savedata.Append("SF[");
                        savedata.Append((mo + 1).ToString("D2"));
                        savedata.Append("] ");       // 모듈 번호는 1 ~ N

                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                // Channel Data
                                UInt16 tempInit, tempHeat;
                                tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                                tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;

                                savedata.Append(" ch");
                                savedata.Append((ch + 1).ToString());
                                savedata.Append("[");
                                savedata.Append(tempInit.ToString("x2"));
                                savedata.Append(",");
                                savedata.Append(tempHeat.ToString("x2"));
                                savedata.Append("]");
                            }
                        }

                        // Temperature, Humidity
                        savedata.Append(" TE[" + mModuleArray[cnt].rawModudle[mo].additionalData.ExternalTemperature.ToString() + "]");
                        savedata.Append(" HU[" + mModuleArray[cnt].rawModudle[mo].additionalData.ExternalHumidity.ToString() + "]");

                        // Parameter
                        savedata.Append(" a[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_a.ToString() + "]");    // a, b, c CH1으로 통일
                        savedata.Append(" b[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_b.ToString() + "]");
                        savedata.Append(" c[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_c.ToString() + "]");
                        savedata.Append(" Tm1[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1.ToString() + "]");
                        savedata.Append(" Tm2[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2.ToString() + "]");
                        savedata.Append(" Tm3[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3.ToString() + "]");
                        savedata.Append(" Tm4[" + mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4.ToString() + "]");
                        savedata.Append(Environment.NewLine);
                        line++;
                    }
                }

                // VC Parameter Print
                bool fgPrintVCParameter = false;
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo])
                    {
                        if ((cnt == firstCount) || (cnt == mModuleArray.Count - 1))
                        {
                            // 처음과 마지막엔 무조건 출력
                            fgPrintVCParameter = true;
                        }
                        else
                        {
                            // 파라메터가 변경된 경우만 출력
                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    if (mModuleArray[cnt].rawValveControl.Enabled[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Enabled[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Max[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Max[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Min[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Min[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Constrain[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Constrain[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                    if (mModuleArray[cnt].rawValveControl.Ratio[mo, ch] != mModuleArray[cnt - 1].rawValveControl.Ratio[mo, ch])
                                    {
                                        fgPrintVCParameter = true;
                                    }

                                }
                            }

                            if (mModuleArray[cnt].rawValveControl.EventJouleValue != mModuleArray[cnt - 1].rawValveControl.EventJouleValue)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (DateTime.Compare(mModuleArray[cnt].rawValveControl.StartTime, mModuleArray[cnt - 1].rawValveControl.StartTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (DateTime.Compare(mModuleArray[cnt].rawValveControl.EndTime, mModuleArray[cnt - 1].rawValveControl.EndTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (TimeSpan.Compare(mModuleArray[cnt].rawValveControl.MaxTime, mModuleArray[cnt - 1].rawValveControl.MaxTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }

                            if (TimeSpan.Compare(mModuleArray[cnt].rawValveControl.MinTime, mModuleArray[cnt - 1].rawValveControl.MinTime) != 0)
                            {
                                fgPrintVCParameter = true;
                            }
                        }
                    }
                }

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    // VC 파라메터 출력
                    if (fgPrintVCParameter)
                    {
                        if (SystemParameter.ModuleEnable[mo])
                        {
                            // VC[##]
                            savedata.Append("VC[");
                            savedata.Append((mo + 1).ToString("D2"));
                            savedata.Append("] ");       // 모듈 번호는 1 ~ N

                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    // Channel Data
                                    savedata.Append(" ch");
                                    savedata.Append((ch + 1).ToString());
                                    savedata.Append("[");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Enabled[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Min[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Max[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Constrain[mo, ch].ToString());
                                    savedata.Append(",");
                                    savedata.Append(mModuleArray[cnt].rawValveControl.Ratio[mo, ch].ToString());
                                    savedata.Append("]");
                                }
                            }

                            DateTime dt = new DateTime(2017, 1, 1); // dummy date for converting Timespan to Datetime

                            savedata.Append(" SET[");
                            savedata.Append(mModuleArray[cnt].rawValveControl.StartTime.ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append(mModuleArray[cnt].rawValveControl.EndTime.ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append((dt + mModuleArray[cnt].rawValveControl.MaxTime).ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append((dt + mModuleArray[cnt].rawValveControl.MinTime).ToString("HH:mm"));
                            savedata.Append(",");
                            savedata.Append(mModuleArray[cnt].rawValveControl.EventJouleValue.ToString());
                            savedata.Append("]");
                            savedata.Append(Environment.NewLine);
                            line++;
                        }

                    }
                }
                sw.Write(savedata.ToString());
            }

            progress = 100;
            updateDisplayBox(String.Format("Done, {0}%, Index={1}", progress.ToString(), mModuleArray.Count.ToString()));
            sw.Close();
        }


        private void btParaReset_Offset_Click(object sender, EventArgs e)
        {
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

            float setTm;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            // Use Default Value 18/06/07
            // a, b, c는 setup의 값을 사용
            // Tm은 constant parameter = 1.8 사용
            SystemParameter.Para[mo, ch].a = Default_SFabcParameter[mo].a;
            SystemParameter.Para[mo, ch].b = Default_SFabcParameter[mo].b;
            SystemParameter.Para[mo, ch].c = Default_SFabcParameter[mo].c;

            // setTm = Default_SFOffsetParameter[mo, ch] * Default_Const_SFParameter.Tm;
            setTm = Default_Const_SFParameter.Tm;
            SystemParameter.Para[mo, ch].Tm = setTm;

            // Min, Max Clear
            KeyPressEventArgs etemp = new KeyPressEventArgs((char)Keys.Enter);

            cbY1Min.Checked = true;
            tbY1Min.Text = "0";
            Y1TextMin_KeyPress(sender, etemp);

            cbY1Max.Checked = true;
            tbY1Max.Text = "";
            Y1TextMax_KeyPress(sender, etemp);

            cbY2Min.Checked = true;
            tbY2Min.Text = "0";
            Y2TextMin_KeyPress(sender, etemp);

            cbY2Max.Checked = true;
            tbY2Max.Text = "";
            Y2TextMax_KeyPress(sender, etemp);

            //updateDisplayBox(String.Format("Module{0} Channel{1} : Reset offset:{2}",(mo+1).ToString(), (ch+1).ToString(), Default_SFOffsetParameter[mo, ch].ToString()));
            updateDisplayBox(String.Format("Reset offset MO{0} CH{1}", (mo + 1).ToString(), (ch + 1).ToString()));
            updateListBox(String.Format("Tm Reset Tm ={0}, delta T={1}", setTm.ToString(), Default_SFOffsetParameter[mo, ch].ToString()));
            subParaSetTm(setTm);
        }

        private void btParaSet_Offset_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            // Convert Offset(SF) Value to Tm
            // SF = a*((Tm-Tdiff)/Tdiff)^b, where Tdiff=c*(tman - tmin)
            double value_Offset, value_a, value_b, value_c, value_Tm, value_temp, value_Tdiff;
            float setTm;

            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];
#if false
            // 해당창의 Min, Max checked인경우 unchecked로 변경(재로드시 min, max가 변경되어있음)
            fgGraphMin[mo, ch] = false;
            fgGraphMax[mo, ch] = false;
            GraphMin[mo, ch] = Single.NaN;
            GraphMax[mo, ch] = Single.NaN;
            upateMainSelectionParameter();
#endif

            if (tbParaSet_Tm_Offset.Text != "")
            {
                try
                {
                    if (Convert.ToSingle(tbParaSet_Tm_Offset.Text) >= 0)
                    {
                        value_Offset = Convert.ToDouble(tbParaSet_Tm_Offset.Text);
                        updateDisplayBox(String.Format("Set Offset ={0}", value_Offset.ToString()));

                        if (SystemParameter.ModuleEnable[mo])
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                value_a = SystemParameter.Para[mo, ch].a;
                                value_b = SystemParameter.Para[mo, ch].b;
                                value_c = SystemParameter.Para[mo, ch].c;
                                value_Tm = SystemParameter.Para[mo, ch].Tm;

                                updateListBox(String.Format("Current a ={0}", value_a.ToString()));
                                updateListBox(String.Format("Current b ={0}", value_b.ToString()));
                                updateListBox(String.Format("Current c ={0}", value_c.ToString()));
                                updateListBox(String.Format("Current Tm ={0}", value_Tm.ToString()));

                                // Calculate Tdiff = Tm /(1+ temp)
                                //                  where temp = (SF/a)^(1/b)
                                // SF = offset
                                // Tm = current Tm
                                // temp = (offset/a)^(1/b)
                                value_temp = Math.Pow((value_Offset / value_a), (1 / value_b));
                                value_Tdiff = value_Tm / (1 + value_temp);

                                // Calculate Tm (where SF is 0), if Td != 0, Tm = Td
                                // SF = 0 --> Tm = Tdiff 
                                value_Tm = value_Tdiff;
                                updateListBox(String.Format("Calculated Tm ={0}", value_Tm.ToString()));
                                setTm = Convert.ToSingle(value_Tm);
                                subParaSetTm(setTm);

                                // Min, Max Clear
                                KeyPressEventArgs etemp = new KeyPressEventArgs((char)Keys.Enter);

                                cbY1Min.Checked = true;
                                tbY1Min.Text = "0";
                                Y1TextMin_KeyPress(sender, etemp);

                                cbY1Max.Checked = true;
                                tbY1Max.Text = "";
                                Y1TextMax_KeyPress(sender, etemp);

                                cbY2Min.Checked = true;
                                tbY2Min.Text = "0";
                                Y2TextMin_KeyPress(sender, etemp);

                                cbY2Max.Checked = true;
                                tbY2Max.Text = "";
                                Y2TextMax_KeyPress(sender, etemp);
                            }
                        }
                        else
                        {
                            updateDisplayBox(String.Format("[ERR] Module is not enabled"));
                        }
                    }
                    else  // 음수는 기존으로 Restore
                    {
                        value_Offset = Convert.ToDouble(tbParaSet_Tm_Offset.Text);
                        updateDisplayBox(String.Format("Set Offset ={0}", value_Offset.ToString()));

                        value_Offset *= -1; // 음수부호 제거
                        if (SystemParameter.ModuleEnable[mo])
                        {
                            if (SystemParameter.ChannelEnable[mo, ch])
                            {
                                value_a = SystemParameter.Para[mo, ch].a;
                                value_b = SystemParameter.Para[mo, ch].b;
                                value_c = SystemParameter.Para[mo, ch].c;
                                value_Tm = SystemParameter.Para[mo, ch].Tm;

                                updateListBox(String.Format("Current a ={0}", value_a.ToString()));
                                updateListBox(String.Format("Current b ={0}", value_b.ToString()));
                                updateListBox(String.Format("Current c ={0}", value_c.ToString()));
                                updateListBox(String.Format("Current Tm ={0}", value_Tm.ToString()));

                                // Calculate Tdiff = Tm_old /(1+ temp)
                                //                  where temp = (SF/a)^(1/b)
                                // SF = offset
                                // Tm_old = 되돌아갈 Tm
                                // Tdiff = 현재 Tm에 해당 = Tm_current
                                // Tm_old = Tm_current(1+temp)
                                // temp = (offset/a)^(1/b)    where offset은 부호를 제거한 offset값
                                value_temp = Math.Pow((value_Offset / value_a), (1 / value_b));
                                value_Tdiff = value_Tm * (1 + value_temp);
                                // Calculate Tm (where SF is 0), if Td != 0, Tm = Td
                                // SF = 0 --> Tm = Tdiff 
                                value_Tm = value_Tdiff;
                                updateListBox(String.Format("Calculated Tm ={0}", value_Tm.ToString()));
                                setTm = Convert.ToSingle(value_Tm);
                                subParaSetTm(setTm);

                            }
                        }
                        else
                        {
                            updateDisplayBox(String.Format("[ERR] Module is not enabled"));
                        }
                    }
                }
                catch (Exception ex) { updateDisplayBox(String.Format("[ERR] {0}", ex.Message)); }
            }
        }

        private void btParaSet_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            float setTm;
            setTm = Convert.ToSingle(tbParaSet_Tm.Text);
            subParaSetTm(setTm);
        }

        private void btParaSetAll_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            float setTm;
            setTm = Convert.ToSingle(tbParaSet_Tm.Text);
            subParaSetTmAll(setTm);
        }

        private void subParaSetTm(float valueTm)
        {
            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            subParaSetTmMoCh(valueTm, mo, ch);

            tbParaSet_Tm_Offset.Text = "";
            //            MessageBoxAutoClose(String.Format("모듈 {0}, 채널{1}의 Tm값이 {2}로 변환되었습니다.\n [Graph]버튼으로 그래프를 재로드 해주세요.", (mo + 1).ToString(), ch + 1, (valueTm).ToString()));
            MessageBoxAutoClose(String.Format("The Tm value of Module {0}, Channel{1} is changed to {2}.\n Please, reload the Chart(using [Multi View, Graph] button).", (mo + 1).ToString(), ch + 1, (valueTm).ToString()));
        }

        private void subParaSetTmAll(float valueTm)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo] == true)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SystemParameter.ChannelEnable[mo, ch])
                        {
                            subParaSetTmMoCh(valueTm, mo, ch);
                        }
                    }
                }

                tbParaSet_Tm_Offset.Text = "";
            }

            //           MessageBoxAutoClosew(String.Format("모든 모듈과 채널의 Tm값이 {0}로 변환되었습니다.\n [Graph]버튼으로 그래프를 재로드 해주세요.", (valueTm).ToString()));
            MessageBoxAutoClose(String.Format("Tm values of All Modules and Channels are changed to {0}.\n Please reload the Chart(using [Multi View, Graph] button).", (valueTm).ToString()));

        }

        private void subParaSetTmMoCh(float valueTm, int mo, int ch)
        {
            if (SystemParameter.ModuleEnable[mo])
            {
                if (SystemParameter.ChannelEnable[mo, ch])
                {
                    for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
                    {
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_a = Convert.ToSingle(tbParaSet_a.Text);
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_b = Convert.ToSingle(tbParaSet_b.Text);
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_c = Convert.ToSingle(tbParaSet_c.Text);

                        // ch0의 파라메터를 모듈에서 전체적용
                        SystemParameter.Para[mo, 0].a = mModuleArray[cnt].rawModudle[mo].additionalData.Para_a;
                        SystemParameter.Para[mo, 1].a = mModuleArray[cnt].rawModudle[mo].additionalData.Para_a;
                        SystemParameter.Para[mo, 2].a = mModuleArray[cnt].rawModudle[mo].additionalData.Para_a;
                        SystemParameter.Para[mo, 3].a = mModuleArray[cnt].rawModudle[mo].additionalData.Para_a;

                        SystemParameter.Para[mo, 0].b = mModuleArray[cnt].rawModudle[mo].additionalData.Para_b;
                        SystemParameter.Para[mo, 1].b = mModuleArray[cnt].rawModudle[mo].additionalData.Para_b;
                        SystemParameter.Para[mo, 2].b = mModuleArray[cnt].rawModudle[mo].additionalData.Para_b;
                        SystemParameter.Para[mo, 3].b = mModuleArray[cnt].rawModudle[mo].additionalData.Para_b;

                        SystemParameter.Para[mo, 0].c = mModuleArray[cnt].rawModudle[mo].additionalData.Para_c;
                        SystemParameter.Para[mo, 1].c = mModuleArray[cnt].rawModudle[mo].additionalData.Para_c;
                        SystemParameter.Para[mo, 2].c = mModuleArray[cnt].rawModudle[mo].additionalData.Para_c;
                        SystemParameter.Para[mo, 3].c = mModuleArray[cnt].rawModudle[mo].additionalData.Para_c;

                        if (ch == 0)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1 = valueTm;
                        }
                        else if (ch == 1)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2 = valueTm;
                        }
                        else if (ch == 2)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3 = valueTm;
                        }
                        else if (ch == 3)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4 = valueTm;
                        }

                        SystemParameter.Para[mo, ch].Tm = valueTm;
                    }
                }
            }
        }

        private void subParaSetTmMoChWithLast(int mo)
        {
            int Count;
            Count = mModuleArray.Count;

            if (Count > 0)
            {
                float a, b, c, Tm1, Tm2, Tm3, Tm4;

                // 파라메터 설정값은 마지막 데이터의 파라메터값을 참조
                a = mModuleArray[Count - 1].rawModudle[mo].additionalData.Para_a;
                b = mModuleArray[Count - 1].rawModudle[mo].additionalData.Para_b;
                c = mModuleArray[Count - 1].rawModudle[mo].additionalData.Para_c;
                Tm1 = mModuleArray[Count - 1].rawModudle[mo].additionalData.Para_Tm_CH1;
                Tm2 = mModuleArray[Count - 1].rawModudle[mo].additionalData.Para_Tm_CH2;
                Tm3 = mModuleArray[Count - 1].rawModudle[mo].additionalData.Para_Tm_CH3;
                Tm4 = mModuleArray[Count - 1].rawModudle[mo].additionalData.Para_Tm_CH4;

                if (SystemParameter.ModuleEnable[mo])
                {
                    for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
                    {
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_a = a;
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_b = b;
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_c = c;

                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1 = Tm1;
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2 = Tm2;
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3 = Tm3;
                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4 = Tm4;
                    }

                    // ch0의 파라메터를 모듈에서 전체적용
                    SystemParameter.Para[mo, 0].a = a;
                    SystemParameter.Para[mo, 1].a = a;
                    SystemParameter.Para[mo, 2].a = a;
                    SystemParameter.Para[mo, 3].a = a;

                    SystemParameter.Para[mo, 0].b = b;
                    SystemParameter.Para[mo, 1].b = b;
                    SystemParameter.Para[mo, 2].b = b;
                    SystemParameter.Para[mo, 3].b = b;

                    SystemParameter.Para[mo, 0].c = c;
                    SystemParameter.Para[mo, 1].c = c;
                    SystemParameter.Para[mo, 2].c = c;
                    SystemParameter.Para[mo, 3].c = c;

                    SystemParameter.Para[mo, 0].Tm = Tm1;
                    SystemParameter.Para[mo, 1].Tm = Tm2;
                    SystemParameter.Para[mo, 2].Tm = Tm3;
                    SystemParameter.Para[mo, 3].Tm = Tm4;

                    updateListBox(String.Format("Set MO{0}: Tm1={1},Tm2={2},Tm3={3},Tm4={4}", (mo + 1).ToString("D2"),
                                                 Tm1.ToString("0.##"), Tm2.ToString("0.##"), Tm3.ToString("0.##"), Tm4.ToString("0.##")));
                }
            }
        }

        private int[] TotalAverage = new int[6];
        public int calculateArrayAverage(int[,] array, int[] count)
        {

            int MaxValue = 0;
            int countHour = 0;

            // Calculate Average for each Time Slot
            for (int cntSlot = 0; cntSlot < 6; cntSlot++)
            {
                TotalAverage[cntSlot] = 0;

                for (int i = 0; i < count[cntSlot]; i++)
                {
                    TotalAverage[cntSlot] += array[cntSlot, i];
                }
                TotalAverage[cntSlot] /= count[cntSlot];
            }

            // Find the max average
            for (int cntSlot = 0; cntSlot < 6; cntSlot++)
            {
                if (MaxValue < TotalAverage[cntSlot])
                {
                    MaxValue = TotalAverage[cntSlot];
                    countHour = cntSlot;
                }
            }

            updateListBox(String.Format("Max {0}hour, Value={1}", countHour.ToString(), MaxValue.ToString()));
            return (MaxValue);
        }

        // 전날 새벽기준 모든 모듈의 Ch1 ~ Ch4 Tm조정
        private void btTmAdjust_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }
            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                return;
            }

            updateDisplayBox("Tm Daily Calculation...");

            flagAutoTmRequest = false;

            subTmAdjustRoutine(false);

            //            MessageBoxAutoClose(String.Format("모든 모듈,채널의 오늘 Tm값이 Daily Tm값 기준으로 전체데이터를 변경하였습니다.\n [Graph]버튼으로 그래프를 재로드 해주세요."));
            MessageBoxAutoClose(String.Format("All Tm values today are changed as the auto-calculated values for all Modules and channels.\n Please reload the Chart(using [Multi View, Graph] button)."));
        }

        //  Input = true --> 매일적용,     false --> 마지막날만 적용
        private void subTmAdjustRoutine(Boolean fgDailyAuto)
        {
            int[,] arrayAverage = new int[6, 200];
            int[] countAverage = new int[6];
            UInt16 tempInit, tempHeat;
            int tempDiff;
            int currentHour, currentDay, currentMonth, currentYear, lastestDay, lastestMonth, lastestYear;
            float[,] currentTm = new float[SFModuleLength, SFChannelLength];

            string outputPath = Application.StartupPath + "\\log\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }
            if (fgDailyAuto)
            {
                fs2 = outputPath + "TM_AUTO_DAILY_All" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
            }
            else
            {
                fs2 = outputPath + "TM_AUTO_TODAY_All" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
            }
            StreamWriter sw = new StreamWriter(fs2);
            StringBuilder savedata = new StringBuilder();

            savedata.Clear();
            savedata.Append("Real Tm Daily Calculation Log");
            savedata.Append(Environment.NewLine);
            //            savedata.Append("Hour=-- Average=--- Count=--, value1, value2, ...");
            savedata.Append("[ ]Hour, Average, Count");
            savedata.Append(Environment.NewLine);
            sw.Write(savedata.ToString());
            savedata.Clear();

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // Enable된 창만 Close
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                    {
                        float tempTm = 0;
                        float tempTmOld = 0;

                        // Update Initial Tm Value
                        if (ch == 0)
                        {
                            currentTm[mo, ch] = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH1;
                        }
                        else if (ch == 1)
                        {
                            currentTm[mo, ch] = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH2;
                        }
                        else if (ch == 2)
                        {
                            currentTm[mo, ch] = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH3;
                        }
                        else if (ch == 3)
                        {
                            currentTm[mo, ch] = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH4;
                        }

                        DateTime latestDate = DateTime.FromOADate(mModuleArray[mModuleArray.Count - 1].OADate);
                        lastestDay = Convert.ToInt32(latestDate.ToString("dd"));
                        lastestMonth = Convert.ToInt32(latestDate.ToString("MM"));
                        lastestYear = Convert.ToInt32(latestDate.ToString("yyyy"));

                        for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
                        {
                            if (SystemParameter.ModuleEnable[mo])
                            {
                                if (SystemParameter.ChannelEnable[mo, ch])
                                {
                                    DateTime currentDate = DateTime.FromOADate(mModuleArray[cnt].OADate);
                                    currentHour = Convert.ToInt32(currentDate.ToString("HH"));
                                    currentDay = Convert.ToInt32(currentDate.ToString("dd"));
                                    currentMonth = Convert.ToInt32(currentDate.ToString("MM"));
                                    currentYear = Convert.ToInt32(currentDate.ToString("yyyy"));

                                    if ((currentDay != lastestDay) || (currentMonth != lastestMonth) || (currentYear != lastestYear))
                                    {
                                        if (fgDailyAuto == false)
                                        {
                                            // 마지막 날만 적용
                                            continue;
                                        }
                                    }
                                    tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                                    tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;
                                    tempDiff = tempHeat - tempInit;

                                    if (currentHour < 6)
                                    {
                                        arrayAverage[currentHour, countAverage[currentHour]] = tempDiff;
                                        countAverage[currentHour]++;
                                    }
                                    if (currentHour == 6)
                                    {
                                        if ((countAverage[0] > 10) && (countAverage[1] > 10) && (countAverage[2] > 10) && (countAverage[3] > 10) && (countAverage[4] > 10) && (countAverage[5] > 10))
                                        {
                                            updateListBox(currentDate.ToString());
                                            int MaxValue = calculateArrayAverage(arrayAverage, countAverage); // 밤사이 최저값을 찾기위해, Diff가 가장 큰 값을 서치함


                                            for (int cal = 0; cal < 6; cal++)
                                            {
                                                if ((MaxValue != 0) && (MaxValue == TotalAverage[cal]))
                                                {
                                                    savedata.Append("[*]");
                                                }
                                                else
                                                {
                                                    savedata.Append("[ ]");
                                                }
                                                //savedata.Append("Hour=");
                                                savedata.Append(cal.ToString());                // Hour
                                                savedata.Append(", ");
                                                //savedata.Append(" Average=");
                                                savedata.Append(TotalAverage[cal].ToString());  // Average Value
                                                savedata.Append(", ");
                                                //savedata.Append(" Count=");
                                                savedata.Append(countAverage[cal].ToString());  // Count
                                                for (int cal2 = 0; cal2 < countAverage[cal]; cal2++)
                                                {
                                                    // savedata.Append(",");
                                                    // savedata.Append(arrayAverage[cal, cal2].ToString());    // value1, value2, ...
                                                }
                                                savedata.Append(Environment.NewLine);
                                            }
                                            savedata.Append(currentDate.ToString() + ", Mo" + (mo + 1).ToString() + ", Ch" + (ch + 1).ToString() + ", [MAX]" + MaxValue.ToString());

                                            // Clear variable
                                            for (int cntSlot = 0; cntSlot < 6; cntSlot++)
                                            {
                                                countAverage[cntSlot] = 0;      // Tm적용후 이후 동작 안되도록 Clear
                                            }

                                            //double a, b;
                                            double c;
                                            // a = mModuleArray[cnt].rawModudle[mo].additionalData.Para_a;
                                            // b = mModuleArray[cnt].rawModudle[mo].additionalData.Para_b;
                                            c = mModuleArray[cnt].rawModudle[mo].additionalData.Para_c;

                                            double tmp = MaxValue * c;

                                            if ((tmp < 0) || (double.IsInfinity(tmp)) || (double.IsNegativeInfinity(tmp)))
                                            {
                                                tmp = 0;
                                                tempTm = 0;
                                                savedata.Append(", [Tm](under)");
                                            }
                                            else
                                            {
                                                tempTm = Convert.ToSingle(tmp);
                                                savedata.Append(", [Tm]");
                                            }
                                            currentTm[mo, ch] = tempTm;

                                            SystemParameter.Para[mo, ch].Tm = tempTm;

                                            savedata.Append(tempTmOld.ToString() + "-->" + tempTm.ToString());

                                            savedata.Append(Environment.NewLine);
                                            sw.Write(savedata.ToString());
                                            savedata.Clear();

                                        }
                                    } // AM 6:00
                                    tempTmOld = 0;
                                    if (ch == 0)
                                    {
                                        tempTmOld = mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1;
                                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1 = currentTm[mo, ch];
                                    }
                                    else if (ch == 1)
                                    {
                                        tempTmOld = mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2;
                                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2 = currentTm[mo, ch];
                                    }
                                    else if (ch == 2)
                                    {
                                        tempTmOld = mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3;
                                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3 = currentTm[mo, ch];
                                    }
                                    else if (ch == 3)
                                    {
                                        tempTmOld = mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4;
                                        mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4 = currentTm[mo, ch];
                                    }
                                }
                            }
                        }
                        updateDisplayBox(String.Format("Tm Updated MO={0}, CH={1}, Tm={2}-->{3}", (mo + 1).ToString(), (ch + 1).ToString(), tempTmOld.ToString(), SystemParameter.Para[mo, ch].Tm.ToString()));
                    }  // ch
                }  // mo
            }
            sw.Close();
        }

        // 특정채널 Daily Tm 조정
        private void btTmAdaptive_Click(object sender, EventArgs e)
        {
            int[,] arrayAverage = new int[6, 200];
            int[] countAverage = new int[6];
            UInt16 tempInit, tempHeat;
            int tempDiff;
            int currentHour;

            int mo = MainSelection.ModuleNumber;
            int ch = MainSelection.ChannelNumber[MainSelection.ModuleNumber];

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }
            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                return;
            }

            updateDisplayBox("Tm Auto Calculation...");

            string outputPath = Application.StartupPath + "\\log\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            StringBuilder savedata = new StringBuilder();

            fs2 = outputPath + "TM_AUTO_DAILY_" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + String.Format("_M{0}C{1}", (mo + 1).ToString(), (ch + 1).ToString()) + ".txt";
            StreamWriter sw = new StreamWriter(fs2);

            // Update Initial Text for Tm Value
            if (ch == 0)
            {
                tbParaSet_Tm.Text = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH1.ToString();
            }
            else if (ch == 1)
            {
                tbParaSet_Tm.Text = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH2.ToString();
            }
            else if (ch == 2)
            {
                tbParaSet_Tm.Text = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH3.ToString();
            }
            else if (ch == 3)
            {
                tbParaSet_Tm.Text = mModuleArray[0].rawModudle[mo].additionalData.Para_Tm_CH4.ToString();
            }

            savedata.Clear();
            savedata.Append("Real Tm Auto Calculation Log, ");
            savedata.Append(String.Format("Module={0}, Channel={1}", (mo + 1).ToString(), (ch + 1).ToString()));
            savedata.Append(Environment.NewLine);
            //            savedata.Append("Hour=-- Average=--- Count=--, value1, value2, ...");
            savedata.Append("[ ]Hour, Average, Count");
            savedata.Append(Environment.NewLine);
            sw.Write(savedata.ToString());
            savedata.Clear();

            for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
            {
                if (SystemParameter.ModuleEnable[mo])
                {
                    if (SystemParameter.ChannelEnable[mo, ch])
                    {
                        DateTime currentDate = DateTime.FromOADate(mModuleArray[cnt].OADate);
                        currentHour = Convert.ToInt32(currentDate.ToString("HH"));

                        tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                        tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;
                        tempDiff = tempHeat - tempInit;

                        if (currentHour < 6)
                        {
                            arrayAverage[currentHour, countAverage[currentHour]] = tempDiff;
                            countAverage[currentHour]++;
                        }
                        if (currentHour == 6)
                        {
                            if ((countAverage[0] > 10) && (countAverage[1] > 10) && (countAverage[2] > 10) && (countAverage[3] > 10) && (countAverage[4] > 10) && (countAverage[5] > 10))
                            {
                                updateListBox(currentDate.ToString());
                                int MaxValue = calculateArrayAverage(arrayAverage, countAverage); // 밤사이 최저값을 찾기위해, Diff가 가장 큰 값을 서치함


                                for (int cal = 0; cal < 6; cal++)
                                {
                                    if (MaxValue == TotalAverage[cal])
                                    {
                                        savedata.Append("[*]");
                                    }
                                    else
                                    {
                                        savedata.Append("[ ]");
                                    }
                                    //savedata.Append("Hour=");
                                    savedata.Append(cal.ToString());                // Hour
                                    savedata.Append(", ");
                                    //savedata.Append(" Average=");
                                    savedata.Append(TotalAverage[cal].ToString());  // Average Value
                                    savedata.Append(", ");
                                    //savedata.Append(" Count=");
                                    savedata.Append(countAverage[cal].ToString());  // Count
                                    for (int cal2 = 0; cal2 < countAverage[cal]; cal2++)
                                    {
                                        // savedata.Append(",");
                                        // savedata.Append(arrayAverage[cal, cal2].ToString());    // value1, value2, ...
                                    }
                                    savedata.Append(Environment.NewLine);
                                }
                                savedata.Append(currentDate.ToString() + ", Mo" + (mo + 1).ToString() + ", Ch" + (ch + 1).ToString() + ", [MAX]" + MaxValue.ToString());

                                // Clear variable
                                for (int cntSlot = 0; cntSlot < 6; cntSlot++)
                                {
                                    countAverage[cntSlot] = 0;
                                }

                                //double a, b;
                                double c;
                                // a = mModuleArray[cnt].rawModudle[mo].additionalData.Para_a;
                                // b = mModuleArray[cnt].rawModudle[mo].additionalData.Para_b;
                                c = mModuleArray[cnt].rawModudle[mo].additionalData.Para_c;

                                double tmp = MaxValue * c;

                                if ((tmp < 0) || (double.IsInfinity(tmp)) || (double.IsNegativeInfinity(tmp)))
                                {
                                    savedata.Append(", [Tm]0 (Under " + tmp.ToString() + ")");
                                    tmp = 0;
                                }
                                else
                                {
                                    tbParaSet_Tm.Text = Convert.ToSingle(tmp).ToString();
                                    savedata.Append(", [Tm]" + Convert.ToSingle(tmp).ToString());
                                }

                                savedata.Append(Environment.NewLine);
                                sw.Write(savedata.ToString());
                                savedata.Clear();
                            }
                        }


                        if (ch == 0)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH1 = Convert.ToSingle(tbParaSet_Tm.Text);
                        }
                        else if (ch == 1)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH2 = Convert.ToSingle(tbParaSet_Tm.Text);
                        }
                        else if (ch == 2)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH3 = Convert.ToSingle(tbParaSet_Tm.Text);
                        }
                        else if (ch == 3)
                        {
                            mModuleArray[cnt].rawModudle[mo].additionalData.Para_Tm_CH4 = Convert.ToSingle(tbParaSet_Tm.Text);
                        }

                        SystemParameter.Para[mo, ch].Tm = Convert.ToSingle(tbParaSet_Tm.Text);
                    }
                }
            }

            sw.Close();

            updateDisplayBox(String.Format("Tm Updated MO={0}, CH={1}, Tm={2}", (mo + 1).ToString(), (ch + 1).ToString(), SystemParameter.Para[mo, ch].Tm.ToString()));

        }

        private void notifyIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // show notifyIcon ToolTip List
            }
            else
            {
                notifyIcon_Deactivate();
            }
        }

        private void notifyIcon_Activate()
        {
            this.Hide();
            this.Visible = false;
            this.ShowIcon = false;
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Real";
            notifyIcon1.BalloonTipText = "SF_Test";
            //notifyIcon1.ShowBalloonTip(5);
        }

        private void notifyIcon_Deactivate()
        {
            this.Show();
            this.Visible = true;
            this.ShowIcon = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();

            notifyIcon1.Visible = false;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            notifyIcon_Deactivate();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ComPortUpdater_Tick(object sender, EventArgs e)
        {
            //          ComPortUpdate();

        }

        private void ComPortUpdate()
        {
            try
            {
                cbComPort.DataSource = SerialPort.GetPortNames();
            }
            catch { }

            // 기타 셋팅 목록 기본값 선택
            if (cbComPort.Items.Count > 0)
            {
                cbComPort.SelectedIndex = 0;
                for (int i = 0; i < cbComPort.Items.Count; i++)
                {
                    updateDisplayBox("Port List " + (i + 1).ToString() + ": " + cbComPort.Items[i].ToString());
                }
            }
            else
            {
                cbComPort.Text = "";
            }
        }

        private void ComPortConnect(String ComPortName)
        {
            if (ComPortName != "")
            {
                Port.PortName = ComPortName;
                Port.BaudRate = 9600; // Convert.ToInt32(cbBaudRate.SelectedItem);
                Port.DataBits = 8; // Convert.ToInt32(cbDataSize.SelectedItem);
                Port.Parity = Parity.None;  // (Parity)cbParity.SelectedIndex;
                Port.Handshake = Handshake.None; // (Handshake)cbHandShake.SelectedIndex;
                Port.DtrEnable = true;
                Port.RtsEnable = true;

                //  Strings = String.Format("[CON] {0}", Port.PortName);
                try
                {
                    // 연결
                    Port.Open();
                }
                catch (Exception ex)
                {
                    updateDisplayBox(String.Format("[ERR] {0}", ex.Message));
                    ComPortUpdate();
                }

                if (Port.IsOpen)
                {
                    // 열린포트를 현재 COMPORT로 판단하여 파일에 기록
                    saveCurrentCOMPort(Port.PortName);
                }
            }
        }

        private void saveCurrentCOMPort(string strPortName)
        {
            // 현재 포트번호를 "Real_SF_Test_Port.ini"파일에 저장
            string DirectoryPath = Application.StartupPath + "\\";
            string fs_system_ini = DirectoryPath + "Real_SF_Test_Port.ini";

            string strText;

            updateDisplayBox("Save Port INI file.");
            StreamWriter sw = new StreamWriter(fs_system_ini);

            sw.Write("Real_SF_Test Port Number" + System.DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss") + Environment.NewLine);

            int timeSeconds = Convert.ToInt32(BuildVersion) * 2;
            int timeHour = timeSeconds / 3600;
            int timeMin = (timeSeconds - (timeHour * 3600)) / 60;
            int timeSec = (timeSeconds - (timeHour * 3600) - (timeMin * 60));
            DateTime BuildVersionDate = new DateTime(2000, 1, 1, timeHour, timeMin, timeSec);

            strText = String.Format("{0} v{1}({2} {3}, r{4})", ProgramName, ProgramVersion,
                          BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);
            //           this.Text = String.Format("{0} v{1}({2}, r{4})", ProgramName, ProgramVersion,
            //                       BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);

            sw.Write("   generated by " + strText + Environment.NewLine);

            // Port번호 
            sw.Write(String.Format("PortName: [{0}]", strPortName));
            sw.Write(Environment.NewLine);
            sw.Close();

        }

        // ini파일내용중 포트번호를 읽어옴
        // PortName: [COM15]
        private string loadCurrentCOMPort()
        {
            string strPortName = "";

            // 파라메터를 재로드
            string DirectoryPath = Application.StartupPath + "\\";
            string fs_system_ini = DirectoryPath + "Real_SF_Test_Port.ini";
            updateDisplayBox("Load Port INI file.");

            if (System.IO.File.Exists(fs_system_ini))
            {
                //
            }
            else
            {
                updateDisplayBox("No INI file exists.");
                return (strPortName);
            }

            StreamReader sr = new StreamReader(fs_system_ini);
            string strLog;
            if (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                if (!strLog.StartsWith("Real_SF_Test Port Number"))
                {
                    sr.Close();
                }
            }

            while (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                if (strLog.StartsWith("PortName"))
                {
                    // "  PortName: "COM13"  "
                    string[] spltBigStrArray = strLog.Split(':');  // ':'를 분리기호로 사용
                    if (spltBigStrArray.Length == 2)
                    {
                        string str = spltBigStrArray[1];
                        int startPosition = str.IndexOf("[");
                        int lastPosition = str.IndexOf("]");
                        if (lastPosition > startPosition)
                        {

                            strPortName = str.Substring(startPosition + 1, lastPosition - startPosition - 1);
                        }
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            sr.Close();

            return (strPortName);
        }

        private void btValveEvent_Click(object sender, EventArgs e)
        {
            if ((SystemParameter.ValveControlOn) && (VCParameter.EventStarted))
            {
                if (VCParameter.EventActivated == false)
                {
                    DateTime now = DateTime.Now;
                    m_frmValveControl.updateListBoxRight(String.Format("{0} Event Activated(Mannually)", now.ToString("MM-dd HH:mm:ss")));
                    VCParameter.EventActivated = true;
                    updateValveControlHistory(now.ToOADate(), 88888);
                }
            }
            else
            {
                updateListBox("Event prohibited");

            }
        }

        private void btValveSetup_Click(object sender, EventArgs e)
        {
            if (SystemParameter.ValveControlOn)
            {
                if (flagStarted)
                {
                    MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                    return;
                }

                if (flagLockClose)
                {
                    updateListBox("Lock Close");
                    return;
                }

                //                DialogResult result = MessageBox.Show("양액제어창을 닫으면 기존 양액제어 데이터가 지워집니다. 닫으시겠습니까?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                DialogResult result = MessageBox.Show("The data will be cleared if you close the control windows, would you want to close the control window?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //code for Yes
                    clearValveControlCount();
                    m_frmValveControl.Close();
                    SystemParameter.ValveControlOn = false;
                }
                else if (result == DialogResult.No)
                {
                    //code for No
                }

            }
            else
            {
                clearValveControlCount();

                OutputValveFileInit();
                frmValveControl valveControl = new frmValveControl();
                m_frmValveControl = valveControl;
                m_frmValveControl.Show();

                if (cbValveControlEnable.Checked == false)
                {
                    cbValveControlEnable.Checked = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (VCParameter.EventActivated)
            {
                DateTime now = DateTime.Now;
                m_frmValveControl.updateListBoxRight(String.Format("{0} Event Aborted", now.ToString()));
                updateValveControlHistory(now.ToOADate(), 99999);
                VCParameter.EventActivated = false;
            }
        }

        private void btValve_Click(object sender, EventArgs e)
        {
            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }
            // TUR
            // Valve Event Test
            sendCommandToModule(VALUE_MODULE_NUMBER_VALVE_CONTROL, COMM_CMD_VALVE_CONTROL);
            waitRespondDataFromModule(100);

            // 55 aa 0e f1 20 00 00 00 04 fb 42 34 00 ff 01 1f 0f f0
            // +0d                           +10d                 +17d
            if (RespondDataReceived == true)
            {
                RespondDataReceived = false;

                if ((recvBuf[10] == 0x23) && (recvBuf[15] == 1))  // Check Busy
                {
                    updateListBox(String.Format("RET: BUSY CH {0}", recvBuf[14] + 1));
                }
                else
                {
                    m_SampleCount++;
                    updateListBox(String.Format("RET: OK"));
                    //                            commandState++;
                    updateListBox(String.Format("C[{0}] RET", recvBuf[10].ToString("X")));
                }
                CommandBufferClear();
            }
        }

        private int FactorySetupOpenCount = 0;
        public static Boolean fgActivateFactorySetup = false;
        public static Boolean fgFactoryModeActivated = false;

        public static Boolean fgValveControlActivated = false;
        private object btStartValveControl;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FactorySetupOpenCount++;
            if (FactorySetupOpenCount == 5)
            {
                FactorySetupOpenCount = 0;
                fgActivateFactorySetup = false;

                bool backupTopMost;

                backupTopMost = this.TopMost;
                this.TopMost = false;

                frmLogin setup = new frmLogin();
                setup.ShowDialog();

                this.TopMost = backupTopMost;

                if (fgActivateFactorySetup)
                {
                    fgActivateFactorySetup = false;
                    ActivateFactorySettingScreen();
                }

            }
        }

        private void btCloseScreen_Click(object sender, EventArgs e)
        {
            // Close Screen
            DeactivateFactorySettingScreen();
        }

        private void ActivateFactorySettingScreen()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            fgFactoryModeActivated = true;
            lbExtendScreen.Text = "Factory Mode:";
            IncreaseScreen();

            int timeSeconds = Convert.ToInt32(BuildVersion) * 2;
            int timeHour = timeSeconds / 3600;
            int timeMin = (timeSeconds - (timeHour * 3600)) / 60;
            int timeSec = (timeSeconds - (timeHour * 3600) - (timeMin * 60));
            DateTime BuildVersionDate = new DateTime(2000, 1, 1, timeHour, timeMin, timeSec);

            this.Text = String.Format("{0} v{1}({2} {3}, r{4})", ProgramName, ProgramVersion,
                                    BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);

            gbValveControl.Visible = true;
            gbDebugSetting.Visible = true;
            gbSystemSetting.Visible = true;
            lbParameterA.Visible = true;
            lbParameterB.Visible = true;
            lbParameterC.Visible = true;
            tbParaSet_a.Visible = true;
            tbParaSet_b.Visible = true;
            tbParaSet_c.Visible = true;

            btExitFactoryMode.Visible = true;
            cbDataFilterON.Visible = true;
            listBox1.Visible = true;
            //btMinMaxtoVC.Visible = true;
            //btMinMaxfrimVC.Visible = true;
            //btSetup.Visible = true;
            //btLoadPreset.Visible = true;
            //btSavePreset.Visible = true;
            //button3.Visible = true;

            btSetup.Visible = true;
            btLoadPreset.Visible = true;
            btSavePreset.Visible = true;
            button3.Visible = true;

        }

        private void DeactivateFactorySettingScreen()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            fgFactoryModeActivated = false;
            DecreaseScreen();
            lbExtendScreen.Text = "Extend Screen:";

            int timeSeconds = Convert.ToInt32(BuildVersion) * 2;
            int timeHour = timeSeconds / 3600;
            int timeMin = (timeSeconds - (timeHour * 3600)) / 60;
            int timeSec = (timeSeconds - (timeHour * 3600) - (timeMin * 60));
            DateTime BuildVersionDate = new DateTime(2000, 1, 1, timeHour, timeMin, timeSec);

            this.Text = String.Format("{0} v{1}({2}, r{4})", ProgramName, ProgramVersion,
                                    BuildDate.ToString("yy/MM/dd"), BuildVersionDate.ToString("HH:mm:ss"), BuildVersion);

            if (fgValveControlActivated == true)
            {
                // 릴리즈 모드에서 양액제어 메뉴 Open
                gbValveControl.Visible = true;
                gbSystemSetting.Visible = true;

                btSetup.Visible = false;
                btLoadPreset.Visible = false;
                btSavePreset.Visible = false;
                button3.Visible = false;
            }
            else
            {
                gbValveControl.Visible = false;
                gbSystemSetting.Visible = false;

                btSetup.Visible = true;
                btLoadPreset.Visible = true;
                btSavePreset.Visible = true;
                button3.Visible = true;
            }

            gbDebugSetting.Visible = false;
            lbParameterA.Visible = false;
            lbParameterB.Visible = false;
            lbParameterC.Visible = false;
            tbParaSet_a.Visible = false;
            tbParaSet_b.Visible = false;
            tbParaSet_c.Visible = false;

            btExitFactoryMode.Visible = false;
            cbDataFilterON.Visible = false;
            listBox1.Visible = false;
            //btMinMaxtoVC.Visible = false;
            //btMinMaxfrimVC.Visible = false;
            //btSetup.Visible = false;
            //btLoadPreset.Visible = false;
            //btSavePreset.Visible = false;
            //button3.Visible = false;
        }

        private void IncreaseScreen()
        {
            if ((fgFactoryModeActivated == true) || (fgValveControlActivated == true))
            {
                this.Size = new System.Drawing.Size(960, 600);
            }
            else
            {
                this.Size = new System.Drawing.Size(770, 600);
            }
            btWindowExtend.Text = "<<";
        }
        private void DecreaseScreen()
        {
            //this.Size = new System.Drawing.Size(541, 470);
            this.Size = new System.Drawing.Size(541, 600);
            btWindowExtend.Text = ">>";
        }


        // Min, Max Parameter --> [VC Parameter]
        private void btMinMaxtoVC_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            //            DialogResult result = MessageBox.Show("[Warning]그래프의 Min, Max값이 양액제어 파라메터에 업데이트됩니다.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            DialogResult result = MessageBox.Show("[Warning]Graph Min,Max Parameters are updated to VC Parameters.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if ((fgGraphMin[mo, ch] && fgGraphMax[mo, ch]))
                        {
                            if ((!float.IsNaN(GraphMin[mo, ch])) && (!float.IsNaN(GraphMax[mo, ch])))
                            {
                                VCParameter.Min[mo, ch] = GraphMin[mo, ch];
                                VCParameter.Max[mo, ch] = GraphMax[mo, ch];
                                updateListBox(String.Format("Para->VC M[{0}] C[{1}]: Min={2},Max={3}", (mo + 1).ToString(), (ch + 1).ToString(), GraphMin[mo, ch].ToString(), GraphMax[mo, ch].ToString()));
                            }
                        }

                    }
                }

                // 밸브컨트롤용 데이터 업데이트(17/08/10)
                if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
                {

                    m_frmValveControl.btLoadParameter_Click(sender, e);
                }
            }
        }

        // Min, Max Parameter <-- [VC Parameter]
        private void btMinMaxfrimVC_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            //            DialogResult result = MessageBox.Show("[Warning]양액제어 파라메터값이 그래프 Min,Max에 업데이트 합니다.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            DialogResult result = MessageBox.Show("[Warning]VC Parameters are updated to Graph Min,Max Parameters.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (SystemParameter.ValveControlOn)      // 밸브컨트롤 창이 열린경우 업데이트
                {
                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        if (SystemParameter.ModuleEnable[mo] == true)
                        {

                            for (int ch = 0; ch < SFChannelLength; ch++)
                            {
                                Boolean fgMin, fgMax;

                                // fg를 ON
                                fgMin = fgGraphMin[mo, ch];
                                fgMax = fgGraphMax[mo, ch];
                                fgGraphMin[mo, ch] = true;
                                fgGraphMax[mo, ch] = true;

                                if ((fgGraphMin[mo, ch] && fgGraphMax[mo, ch]))
                                {
                                    if ((!float.IsNaN(VCParameter.Min[mo, ch])) && (!float.IsNaN(VCParameter.Max[mo, ch])))
                                    {
                                        GraphMin[mo, ch] = VCParameter.Min[mo, ch];
                                        GraphMax[mo, ch] = VCParameter.Max[mo, ch];

                                        // 그래프의 Min, Max를 업데이트
                                        try
                                        {
                                            if (SystemParameter.MultiModuleOn == true)
                                            {
                                                Chart chart = m_frmSfMultiModules.ChartMultiCH[mo, ch].chart1;

                                                if (GraphMax[mo, ch] > GraphMin[mo, ch])
                                                {
                                                    chart.ChartAreas[0].AxisY.Maximum = GraphMax[mo, ch];
                                                    chart.ChartAreas[0].AxisY.Minimum = GraphMin[mo, ch];
                                                }
                                            }

                                            if (SystemParameter.ModuleOn[mo] == true)
                                            {
                                                Chart chart = m_frmSfModule[mo].ChartMultiCH[ch].chart1;

                                                if (GraphMax[mo, ch] > GraphMin[mo, ch])
                                                {
                                                    chart.ChartAreas[0].AxisY.Maximum = GraphMax[mo, ch];
                                                    chart.ChartAreas[0].AxisY.Minimum = GraphMin[mo, ch];
                                                }
                                            }

                                        }
                                        catch
                                        {
                                            // 에러발생시 fg를 원복시킴
                                            fgGraphMin[mo, ch] = fgMin;
                                            fgGraphMax[mo, ch] = fgMax;
                                            updateListBox(String.Format("Err M[{0}] C[{1}]: Min={2},Max={3}", (mo + 1).ToString(), (ch + 1).ToString(), GraphMin[mo, ch].ToString(), GraphMax[mo, ch].ToString()));
                                        }
                                        updateListBox(String.Format("Para<-VC M[{0}] C[{1}]: Min={2},Max={3}", (mo + 1).ToString(), (ch + 1).ToString(), GraphMin[mo, ch].ToString(), GraphMax[mo, ch].ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
                SFModule_Clicked(sender, e);
            }
        }

        private void btSavePreset_Click(object sender, EventArgs e)
        {
            int line = 0;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            updateDisplayBox("Windows Preset Export...");

            StringBuilder savedata = new StringBuilder();

            string outputPath = Application.StartupPath + "\\log\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            fs2 = outputPath + "WP_" + System.DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + ".txt";
            StreamWriter sw = new StreamWriter(fs2);

            savedata.Clear();

            sw.Write("Start" + Environment.NewLine);
            line++;

            // fgGraphMin
            savedata.Append("fgGraphMin1");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(fgGraphMin[mo, ch]);
                }
            }
            savedata.Append(Environment.NewLine);
            line++;

            // fgGraphMax
            savedata.Append("fgGraphMax1");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(fgGraphMax[mo, ch]);
                }
            }
            savedata.Append(Environment.NewLine);
            line++;

            // fgGraphMin2
            savedata.Append("fgGraphMin2");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(fgGraphMin2[mo, ch]);
                }
            }
            savedata.Append(Environment.NewLine);
            line++;

            // fgGraphMax2
            savedata.Append("fgGraphMax2");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(fgGraphMax2[mo, ch]);
                }
            }
            savedata.Append(Environment.NewLine);
            sw.Write(savedata.ToString());
            line++;

            // Min, Max Value
            savedata.Clear();

            savedata.Append("GraphMin1");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(GraphMin[mo, ch].ToString());
                }
            }
            savedata.Append(Environment.NewLine);
            line++;

            savedata.Append("GraphMax1");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(GraphMax[mo, ch].ToString());
                }
            }
            savedata.Append(Environment.NewLine);
            line++;

            savedata.Append("GraphMin2");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(GraphMin2[mo, ch].ToString());
                }
            }
            savedata.Append(Environment.NewLine);
            line++;

            savedata.Append("GraphMax2");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    savedata.Append(", ");
                    savedata.Append(GraphMax2[mo, ch].ToString());
                }
            }
            savedata.Append(Environment.NewLine);
            sw.Write(savedata.ToString());
            line++;

            // Windows Location
            savedata.Clear();

            savedata.Append("Location_X");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                savedata.Append(", ");
                savedata.Append(GraphLocation[mo].X.ToString());
            }
            savedata.Append(Environment.NewLine);
            line++;

            savedata.Append("Location_Y");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                savedata.Append(", ");
                savedata.Append(GraphLocation[mo].Y.ToString());
            }
            savedata.Append(Environment.NewLine);
            line++;

            savedata.Append("Size_X");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                savedata.Append(", ");
                savedata.Append(GraphSize[mo].Width.ToString());
            }
            savedata.Append(Environment.NewLine);
            line++;

            savedata.Append("Size_Y");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                savedata.Append(", ");
                savedata.Append(GraphSize[mo].Height.ToString());
            }
            savedata.Append(Environment.NewLine);
            sw.Write(savedata.ToString());
            line++;

            sw.Close();
            updateDisplayBox(String.Format("Save Preset Parameter Done, {0} Line Updated.", line));
        }

        private void btLoadPreset_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "*.log|*.*";
            open.InitialDirectory = Application.StartupPath + "\\log\\";
            open.Title = "Select Log file";

            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            int line = 0;

            StreamReader sr = new StreamReader(open.FileName);

            string strLog;

            if (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                line++;

                if (strLog != "Start")
                {
                    sr.Close();
                    MessageBoxAutoClose("It is not Real log file.");
                    return;
                }
            }

            while (sr.Peek() > -1)
            {
                strLog = sr.ReadLine();
                line++;
                if (strLog.StartsWith("fgGraphMin1"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                fgGraphMin[mo, ch] = Convert.ToBoolean(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("fgGraphMax1"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                fgGraphMax[mo, ch] = Convert.ToBoolean(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("fgGraphMin2"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                fgGraphMin2[mo, ch] = Convert.ToBoolean(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("fgGraphMax2"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                fgGraphMax2[mo, ch] = Convert.ToBoolean(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("GraphMin1"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                GraphMin[mo, ch] = Convert.ToSingle(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("GraphMax1"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                GraphMax[mo, ch] = Convert.ToSingle(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("GraphMin2"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                GraphMin2[mo, ch] = Convert.ToSingle(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("GraphMax2"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        for (int ch = 0; ch < SFChannelLength; ch++)
                        {
                            try
                            {
                                GraphMax2[mo, ch] = Convert.ToSingle(spltStrArray[mo * 4 + ch + 1]);
                            }
                            catch { }
                        }
                    }
                }
                else if (strLog.StartsWith("Location_X"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        try
                        {
                            GraphLocation[mo].X = Convert.ToInt32(spltStrArray[mo + 1]);
                        }
                        catch { }
                    }
                }
                else if (strLog.StartsWith("Location_Y"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        try
                        {
                            GraphLocation[mo].Y = Convert.ToInt32(spltStrArray[mo + 1]);
                        }
                        catch { }
                    }
                }
                else if (strLog.StartsWith("Size_X"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        try
                        {
                            GraphSize[mo].Width = Convert.ToInt32(spltStrArray[mo + 1]);
                        }
                        catch { }
                    }
                }
                else if (strLog.StartsWith("Size_Y"))
                {
                    string[] spltStrArray = strLog.Split(',');

                    for (int mo = 0; mo < SFModuleLength; mo++)
                    {
                        try
                        {
                            GraphSize[mo].Height = Convert.ToInt32(spltStrArray[mo + 1]);
                        }
                        catch { }
                    }
                }
            }

            sr.Close();

            // Update Window Location
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo])
                {
                    if (SystemParameter.ModuleOn[mo])
                    {
                        m_frmSfModule[mo].StartPosition = FormStartPosition.Manual;
                        m_frmSfModule[mo].Location = GraphLocation[mo];
                        m_frmSfModule[mo].Size = GraphSize[mo];

                        m_frmSfModule[mo].LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
                    }
                }
            }

            // Update Graph for MultiChart
            graphUpdateMultichart();

            SFModule_Clicked(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            try
            {
                string s1 = "";
                foreach (object item in listBox1.Items) s1 += item.ToString() + "\r\n";
                Clipboard.SetText(s1);
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagStarted)
            {
                MessageBoxAutoClose(String.Format("Please stop the process to exit the program."));
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            try
            {
                string s1 = "";
                foreach (object item in listBox2.Items) s1 += item.ToString() + "\r\n";
                Clipboard.SetText(s1);
            }
            catch { }
        }

        private void cbDisposeData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisposeData.CheckState == CheckState.Unchecked)
            {
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        CurrentChartPointCount[mo, ch] = 0;
                    }
                }
            }
        }

        private void cbDisposeVCData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisposeData.CheckState == CheckState.Unchecked)
            {
                clearValveControlCount();
            }
        }

        private void btSFModuleSelectionNumberPrevious_Click(object sender, EventArgs e)
        {
            int index;
            if (cbSFModuleSelectionNumber.Items.Count > 0)
            {
                index = cbSFModuleSelectionNumber.SelectedIndex;
                if (index > 0)
                {
                    index--;
                }

                cbSFModuleSelectionNumber.SelectedIndex = index;

                updateBtSFModuleSelectionNumber();
            }
        }

        private void btSFModuleSelectionNumberNext_Click(object sender, EventArgs e)
        {
            int index;
            if (cbSFModuleSelectionNumber.Items.Count > 0)
            {
                index = cbSFModuleSelectionNumber.SelectedIndex;
                if (index < (cbSFModuleSelectionNumber.Items.Count - 1))
                {
                    index++;
                }

                cbSFModuleSelectionNumber.SelectedIndex = index;

                updateBtSFModuleSelectionNumber();
            }
        }

        private void updateBtSFModuleSelectionNumber()
        {
            if (cbSFModuleSelectionNumber.Items.Count > 0)
            {
                if (cbSFModuleSelectionNumber.SelectedIndex == 0)
                {
                    btSFModuleSelectionNumberPrevious.Enabled = false;
                }
                else
                {
                    btSFModuleSelectionNumberPrevious.Enabled = true;
                }

                if (cbSFModuleSelectionNumber.SelectedIndex == (cbSFModuleSelectionNumber.Items.Count - 1))
                {
                    btSFModuleSelectionNumberNext.Enabled = false;
                }
                else
                {
                    btSFModuleSelectionNumberNext.Enabled = true;
                }
            }
            else
            {
                btSFModuleSelectionNumberPrevious.Enabled = false;
                btSFModuleSelectionNumberNext.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool backupTopMost;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }
            
            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            backupTopMost = this.TopMost;
            this.TopMost = false;

            frmSetupMulti setup = new frmSetupMulti(this);
            setup.ShowDialog();

            if (setup.DialogResult == DialogResult.OK)
            {
                // 창을 닫기전 세팅된 GraphDefaultParameter Setting
                if (fgGraphParameterSaved)
                {
                    saveGraphDefaultParameter();
                }

                // end process, 라디오버튼을 업데이트
                updateMainSelection();

                // 잔존하는 창(비활성화 된 모듈창)을 끔
                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    if (SystemParameter.ModuleEnable[mo] == false)
                    {
                        if (SystemParameter.ModuleOn[mo])
                        {
                            bool fgChecked = cbLockControl.Checked;
                            if (fgChecked == false)
                            {
                                // 열린 그래픽창을 닫음
                                m_frmSfModule[mo].Close();
                                updateDisplayBox(String.Format("Close Module {0} Window", (mo + 1).ToString()));
                            }
                        }
                    }
                }
                //  btRefresh_Click(sender, e);
                string DirectoryPath = Application.StartupPath + "\\";
                string fs_system_ini = DirectoryPath + "Real_SF_Test.ini";
                saveIniFile(fs_system_ini);
                // 파라메터를 재로드
                loadIniFile(fs_system_ini);

                // 18/07/09 Setup에서 모듈를 변경시 오류발생, 멀티 모듈창을 재오픈함
                if (SystemParameter.MultiModuleOn)
                {
                    // 열린 그래픽창을 닫음
                    m_frmSfMultiModules.Close();
                    updateDisplayBox(String.Format("Close Multi Module Window"));
                }

                initializefrmSfMultiModules();

            }
            this.TopMost = backupTopMost;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            frmValveControlSetup setup = new frmValveControlSetup();
            setup.ShowDialog();

            // update Valve Control Graph
            displayValveControlChart();

            if (SystemParameter.MultiModuleOn)
            {
                fgMultiChartRequestRefresh = true;
            }



        }

        private void button8_Click(object sender, EventArgs e)
        {
            Chart chart = null;

            chart = m_frmValveControl.chart1;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    String Name = "M" + (mo + 1).ToString("D2") + "-C" + (ch + 1).ToString("D2");
                    chart.Series[Name].Points.AddXY(DateTime.Now, 500);
                }
                SF_Test.fgRequestValveControlUpdate = true;
            }

            chart.Series["mergedSFValue"].Points.AddXY(DateTime.Now, 100);
            chart.Series["totalSFValue"].Points.AddXY(DateTime.Now, 200);
            chart.Series["ValveControl"].Points.AddXY(DateTime.Now, 300);
            chart.Series["IntegratedValue"].Points.AddXY(DateTime.Now, 400);


        }

        private void cbValveControlEnable_CheckedChanged(object sender, EventArgs e)
        {
            bool fgChecked = cbValveControlEnable.Checked;

            btValveControlGraph.Enabled = fgChecked;
            btValveControlSetup.Enabled = fgChecked;
            btValveEventOn.Enabled = fgChecked;
            btValveEventAbort.Enabled = fgChecked;
            nUDEmergencyNumber.Enabled = fgChecked;
            cbDisposeVCData.Enabled = fgChecked;
        }

        private void cbDebugLog_CheckedChanged(object sender, EventArgs e)
        {
            bool fgChecked = cbDebugLog.Checked;

            btCopyBox1.Enabled = fgChecked;
            btCopyBox2.Enabled = fgChecked;
            btCmdSendTUR.Enabled = fgChecked;
            btCmdSendStart.Enabled = fgChecked;
            btCmdSendFinish.Enabled = fgChecked;
            nudModuleNumber.Enabled = fgChecked;
            tbDebugLevel.Enabled = fgChecked;

            if ((cbDebugLog.Checked) && (tbDebugLevel.Text == "autostart"))
            {
                cbAutoStart.Enabled = true;
                cbAutoStart.Visible = true;
            }
        }

        private void btMultiViewOpen_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            if (SystemParameter.MultiModuleOn)
            {
                // 열린 그래픽창을 닫음
                m_frmSfMultiModules.Close();
                updateDisplayBox("Close Multi Module Window");
            }
            else
            {
                initializefrmSfMultiModules();
                UpdateMultiChartWithRawData();
                this.Focus();
            }

        }

        private void btTmAdjustLast_Click(object sender, EventArgs e)
        {
            float valueTm;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }
            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                return;
            }


            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                if (SystemParameter.ModuleEnable[mo] == true)
                {
                    subParaSetTmMoChWithLast(mo);
                }
            }

            tbParaSet_Tm_Offset.Text = "";
            MessageBoxAutoClose(String.Format("All daily Tm values are changed as the last daily Tm for all Modules and Channels. CH. Tm.\n Please reload the Chart(using [Multi View, Graph] button)."));
        }

        // 모든채널 Daily Tm 조정
        private void btTmAdjustAll_Click(object sender, EventArgs e)
        {
            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }
            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                return;
            }

            updateDisplayBox("All Channel Tm Daily Calculation...");

            flagAutoTmRequest = false;

            subTmAdjustRoutine(true);

            //MessageBoxAutoClose(String.Format("모든 모듈,채널의 Tm값이 마지막 Tm값 기준으로 전체데이터를 변경하였습니다.\n [Graph]버튼으로 그래프를 재로드 해주세요."));
            MessageBoxAutoClose(String.Format("All daily Tm values are changed as the dalily auto-calculated values for all Modules and channels.\n Please reload the Chart(using [Multi View, Graph] button)."));
        }

        private void btWindowExtend_Click(object sender, EventArgs e)
        {
            if (btWindowExtend.Text == ">>")
            {
                IncreaseScreen();
            }
            else
            {
                DecreaseScreen();
            }
        }

        private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoStart.Checked == true)
            {
                setStartup(RegistryAutoStartUpName, true);
            }
            else
            {
                setStartup(RegistryAutoStartUpName, false);
            }
        }

#if (SERVER_INCLUDED)
#if (SERVER_QUERY)
        private void btServerSetup_Click(object sender, EventArgs e)
        {
            bool backupTopMost;

            if (timer1.Enabled)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            backupTopMost = this.TopMost;
            this.TopMost = false;

            frmServerSetup setup = new frmServerSetup();
            setup.ShowDialog();

            if (setup.DialogResult == DialogResult.OK)
            {

            }
            this.TopMost = backupTopMost;
        }
#endif  // SERVER_QUERY

#if (SERVER_COMMUNICATION)
        private void btCommSetup_Click(object sender, EventArgs e)
        {
            bool backupTopMost;

            if (timer1.Enabled)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }
            if (flagLockClose)
            {
                updateDisplayBox("Please uncheck[Lock Close] to exit the program.");
                return;
            }

            backupTopMost = this.TopMost;
            this.TopMost = false;

            frmCommSetup setup = new frmCommSetup();
            setup.ShowDialog();
            if (setup.DialogResult == DialogResult.OK)
            {
                updateDisplayBox("Comm. Setting OK.");
                initializeMQTT();

                queueStatusSFProg("sfstatus", "SF Comm. is enabled.");
            }
            else
            {
                updateDisplayBox("Comm. Setting Failed.");
            }
                        
            this.TopMost = backupTopMost;
            if(fgMQTTEnabled == true)
            {
                btCommSetup.ForeColor = Color.White;
                btCommSetup.BackColor = Color.Green;
            }
            else
            {
                btCommSetup.ForeColor = Color.DarkRed;
                btCommSetup.BackColor = Color.DimGray;
            }
        }


        private void btMQTTTest_Click(object sender, EventArgs e)
        {
            if (fgMQTTEnabled == false)
            {
                updateDisplayBox("Comm. Function is not enabled");
                return;
            }

            try
            {
                sendMqttTest();

            }
            catch (Exception ex) { updateDisplayBox(String.Format("[Warning] MQTT {0}", ex.Message)); }
        }

#endif  //  SERVER_COMMUNICATION

#endif  // SERVER_INCLUDED


        private void btExportSF_Click(object sender, EventArgs e)
        {
            int line = 0;
            DateTime latestTime, currentTime;

            if (flagTimerInProgress == true)
            {
                updateDisplayBox("Prohibited during Communication in Progress.");
                return;
            }

            if (flagAllowAction == false)
            {
                updateDisplayBox("Prohibited during Measurement.");
                return;
            }

            if (mModuleArray.Count == 0)
            {
                updateDisplayBox("No data stored.");
                return;
            }
            updateDisplayBox("SF Data Export...");

            StringBuilder savedata = new StringBuilder();

            if (mModuleArray.Count == 0) return;

            string outputPath = Application.StartupPath + "\\log_SF\\" + System.DateTime.Now.ToString("yy-MM-dd") + "\\";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(outputPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            Boolean fgFullBackup = false;

            if (mModuleArray.Count > 0)
            {
                latestTime = DateTime.FromOADate(mModuleArray[mModuleArray.Count - 1].OADate);
                currentTime = latestTime.Date;

                TimeSpan backupTerm = getBackupTermTimeSpan(cbBackupTerm.SelectedIndex);

                if (backupTerm <= new TimeSpan(0))
                {
                    // Full
                    fgFullBackup = true;
                    latestTime = DateTime.FromOADate(mModuleArray[0].OADate).Date;
                }
                if (backupTerm < new TimeSpan(1, 0, 0, 0))
                {
                    // Today
                    latestTime = latestTime.Date;
                }
                else
                {
                    int TotalDays = (int)backupTerm.TotalDays * -1;
                    latestTime = latestTime.Date.AddDays(TotalDays);
                }

                // 초기 데이터 시작일보다 작은경우에는 초기 시작일을 기준
                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[0].OADate);

                if (DateTime.Compare(latestTime, tempDate.Date) <= 0)
                {
                    latestTime = tempDate.Date;
                }
            }
            else
            {
                // 데이터취합된것이 없는경우 시스템 날짜 이용
                latestTime = System.DateTime.Now;
                currentTime = latestTime;
            }
            fs2 = outputPath + "SF_" + DateTime.Now.ToString("yyMMdd_HHmmss").Replace(':', '-') + "(" + latestTime.ToString("MMdd").Replace(':', '-') + "-" + currentTime.ToString("MMdd").Replace(':', '-') + ").txt";
            StreamWriter sw = new StreamWriter(fs2);

            savedata.Clear();
            savedata.Append("Date, ");
            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                    {
                        savedata.Append("SF[");
                        savedata.Append((mo + 1).ToString());
                        savedata.Append("-");
                        savedata.Append((ch + 1).ToString());
                        savedata.Append("], ");
                    }
                }
            }

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                    {
                        savedata.Append("RT[");
                        savedata.Append((mo + 1).ToString());
                        savedata.Append("-");
                        savedata.Append((ch + 1).ToString());
                        savedata.Append("], ");
                    }
                }
            }

            if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
            {
                savedata.Append("AVG");
            }
            savedata.Append(Environment.NewLine);
            sw.Write(savedata.ToString());

            int firstCount = -1;

            for (int cnt = 0; cnt < mModuleArray.Count; cnt++)
            {
                savedata.Clear();

                DateTime tempDate;
                tempDate = DateTime.FromOADate(mModuleArray[cnt].OADate);

                if (firstCount == -1)
                {
                    if (DateTime.Compare(tempDate, latestTime) < 0)
                    {
                        if (fgFullBackup == true)
                        {
                            firstCount = cnt;
                        }
                        else
                        {
                            // 오늘날짜만 백업
                            continue;
                        }

                    }
                    else
                    {
                        firstCount = cnt;
                    }
                }



                // Date
                savedata.Append(tempDate.ToString("yyyy-MM-dd HH:mm:ss"));
                savedata.Append(", ");


                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                        {
                            // Initial Temp., Last Temp., Diff Temp.
                            UInt16 tempInit, tempHeat;
                            int tempDiff;
                            tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                            tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;
                            tempDiff = tempHeat - tempInit;

                            savedata.Append(calculateSFParameter(mo, ch, tempInit, tempHeat).ToString());
                            savedata.Append(", ");
                        }
                    }
                }

                for (int mo = 0; mo < SFModuleLength; mo++)
                {
                    for (int ch = 0; ch < SFChannelLength; ch++)
                    {
                        if (SystemParameter.ModuleEnable[mo] && SystemParameter.ChannelEnable[mo, ch])
                        {
                            // Initial Temp., Last Temp., Diff Temp.
                            UInt16 tempInit, tempHeat;
                            int tempDiff;
                            tempInit = mModuleArray[cnt].rawModudle[mo].CHData[ch].InitialTemperature;
                            tempHeat = mModuleArray[cnt].rawModudle[mo].CHData[ch].HeatedTemperature;
                            tempDiff = tempHeat - tempInit;

                            savedata.Append(calculateRTempParameter(mo, ch, tempInit, tempHeat).ToString());
                            savedata.Append(", ");
                        }

                    }
                }

                if (cbDisposeVCData.Checked == false)
                {
                    if (SystemParameter.ValveControlOn)     // 밸브컨트롤 창이 열린경우 업데이트
                    {
                        Chart chart = null;
                        chart = m_frmValveControl.chart1;

                        // Merged_Value
                        if (chart.Series["mergedSFValue"].Points.Count > 0)
                        {
                            savedata.Append(chart.Series["mergedSFValue"].Points[cnt].YValues[0].ToString());
                            savedata.Append(", ");
                        }
                    }
                }
                savedata.Append(Environment.NewLine);
                sw.Write(savedata.ToString());
                line++;

            }

            sw.Close();
            updateDisplayBox(String.Format("Done, {0} Line Updated.", line));
        }

        

        // SF Program상태를 HA에 전달매개
        private void queueStatusSFProg(string topic, string payload)
        {
#if (SERVER_INCLUDED)
#if (SERVER_COMMUNICATION)
            if (fgMQTTEnabled == true)
            {
                if(topic == "sfstatus")
                {
                    if (payload == "System Locked.")
                    {
                        // Enable Lock
                        cbLockControl.Checked = true;
                        payload = "System Locked.";

                        if (flagStarted==true)
                        {
                            payload = "[SYS:START]" + payload;
                        }
                        else
                        {
                            payload = "[SYS:STOP]" + payload;
                        }
                    }
                    else if (payload == "System Unlocked.")
                    {
                        // Enable Lock
                        cbLockControl.Checked = false;
                        payload = "System Unlocked.";

                        if (flagStarted == true)
                        {
                            payload = "[SYS:START]" + payload;
                        }
                        else
                        {
                            payload = "[SYS:STOP]" + payload;
                        }
                    }

                    payload += "("+System.DateTime.Now.ToString("MM-dd HH:mm:ss")+")";
                }
                stateQueueSFProg statSFProg = new stateQueueSFProg(topic, payload);
                queueSFProg.Enqueue(statSFProg);
            }
#endif  //  SERVER_COMMUNICATION
#endif  // SERVER_INCLUDED
            return;
        }

        private void AB_check_CheckedChanged(object sender, EventArgs e)
        {
            int result;
            
            if (AB_check.Checked == true)
            {
                if (!int.TryParse(AB_tb.Text, out result) || int.Parse(AB_tb.Text) < 1)
                    AB_tb.Text = "180";
                
                AB_tb.Enabled = false;
            }
            else
            {
                AB_tb.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var newForm = new NewForm();
            newForm.ShowDialog();
        }

        private void queueStatusSFProg(string payload)
        {
#if (SERVER_INCLUDED)
#if (SERVER_COMMUNICATION)
            if (fgMQTTEnabled == true)
            {
                stateQueueSFProg statSFProg = new stateQueueSFProg(STAT_TOPIC, payload);
                queueSFProg.Enqueue(statSFProg);
            }
#endif  //  SERVER_COMMUNICATION
#endif  // SERVER_INCLUDED
            return;
        }

    }
}