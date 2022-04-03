using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SapflowApplication
{
    public partial class frmSetup : MaterialForm
    {
        private int SFModuleLength = SF_Test.SFModuleLength;      // SF_Test에 정의된 채널수를 참조
        private int SFChannelLength = SF_Test.SFChannelLength;      // SF_Test에 정의된 채널수를 참조
        private int Limit_SFModuleLength = 8; // 이 세업 Config는 모듈 8번까지만 작동가능
        public frmSetup()
        {
            InitializeComponent();
        }

        enum typeParameter
        {
            READ,
            WRITE
        };

        private void exeSetupParameter(typeParameter eType)
        {
            StringBuilder strSearchMo = new StringBuilder("cbMxxEnable");
            StringBuilder strSearchPara_a = new StringBuilder("tbMxxDefaultPara_a");
            StringBuilder strSearchPara_b = new StringBuilder("tbMxxDefaultPara_b");
            StringBuilder strSearchPara_c = new StringBuilder("tbMxxDefaultPara_c");
            StringBuilder strSearchPara_Tm = new StringBuilder("tbMxxDefaultPara_Tm_CHx");
            StringBuilder strSearchPara_Custom = new StringBuilder("tbMxxCustomPara_CHx");

            StringBuilder strSearchCH = new StringBuilder("cbMxxCHxEnable");

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // cbM00Enable
                strSearchMo.Remove(3, 2);
                strSearchMo.Insert(3, (mo + 1).ToString("D2"));
                CheckBox cbModule = this.Controls.Find(strSearchMo.ToString(), true)[0] as CheckBox;
                if (eType == typeParameter.READ)
                {
                    cbModule.Checked = SF_Test.SystemParameter.ModuleEnable[mo];
                }
                else if (eType == typeParameter.WRITE)
                {
                    SF_Test.SystemParameter.ModuleEnable[mo] = cbModule.Checked;
                }

                // tbM00DefaultPara_a 
                strSearchPara_a.Remove(3, 2);
                strSearchPara_a.Insert(3, (mo + 1).ToString("D2"));
                ReaLTaiizor.Controls.MaterialTextBox tbPara_a = this.Controls.Find(strSearchPara_a.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;
                if (eType == typeParameter.READ)
                {
                    tbPara_a.Text = SF_Test.SystemParameter.Para[mo, 0].a.ToString();
                }
                else if (eType == typeParameter.WRITE)
                {
                    try
                    {
                        SF_Test.SystemParameter.Para[mo, 0].a = Convert.ToSingle(tbPara_a.Text);
                    }
                    catch (Exception ex) {; }

                }

                // tbM00DefaultPara_b 
                strSearchPara_b.Remove(3, 2);
                strSearchPara_b.Insert(3, (mo + 1).ToString("D2"));
                ReaLTaiizor.Controls.MaterialTextBox tbPara_b = this.Controls.Find(strSearchPara_b.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;
                if (eType == typeParameter.READ)
                {
                    tbPara_b.Text = SF_Test.SystemParameter.Para[mo, 0].b.ToString();
                }
                else if (eType == typeParameter.WRITE)
                {
                    try
                    {
                        SF_Test.SystemParameter.Para[mo, 0].b = Convert.ToSingle(tbPara_b.Text);
                    }
                    catch (Exception ex) {; }
                }

                // tbM00DefaultPara_c 
                strSearchPara_c.Remove(3, 2);
                strSearchPara_c.Insert(3, (mo + 1).ToString("D2"));
                ReaLTaiizor.Controls.MaterialTextBox tbPara_c = this.Controls.Find(strSearchPara_c.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;
                if (eType == typeParameter.READ)
                {
                    tbPara_c.Text = SF_Test.SystemParameter.Para[mo, 0].c.ToString();
                }
                else if (eType == typeParameter.WRITE)
                {
                    try
                    {
                        SF_Test.SystemParameter.Para[mo, 0].c = Convert.ToSingle(tbPara_c.Text);
                    }
                    catch{}
                }

                // tbM00DefaultPara_Tm 
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    strSearchPara_Tm.Remove(3, 2);
                    strSearchPara_Tm.Insert(3, (mo + 1).ToString("D2"));
                    strSearchPara_Tm.Remove(22, 1);
                    strSearchPara_Tm.Insert(22, (ch + 1).ToString("D1"));

                    ReaLTaiizor.Controls.MaterialTextBox tbPara_Tm = this.Controls.Find(strSearchPara_Tm.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;
                    if (eType == typeParameter.READ)
                    {
                        tbPara_Tm.Text = SF_Test.SystemParameter.Para[mo, ch].Tm.ToString();
                    }
                    else if (eType == typeParameter.WRITE)
                    {
                        try
                        {
                            SF_Test.SystemParameter.Para[mo, ch].Tm = Convert.ToSingle(tbPara_Tm.Text);
                        }
                        catch {}

                    }
                }

                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    // CheckBox Name: "cbM01CH1Enable"
                    strSearchCH.Remove(3, 2);
                    strSearchCH.Insert(3, (mo + 1).ToString("D2"));
                    strSearchCH.Remove(7, 1);
                    strSearchCH.Insert(7, (ch + 1).ToString("D1"));
                    CheckBox cbChannel = this.Controls.Find(strSearchCH.ToString(), true)[0] as CheckBox;

                    // Currently enable all channel
                    if (SF_Test.SystemParameter.ModuleEnable[mo])
                    {
                        cbChannel.Checked = true;
                        SF_Test.SystemParameter.ChannelEnable[mo, ch] = true;
                    }
                    else
                    {
                        cbChannel.Checked = false;
                        SF_Test.SystemParameter.ChannelEnable[mo, ch] = false;
                    }

                    if (eType == typeParameter.READ)
                    {
                        cbChannel.Checked = SF_Test.SystemParameter.ChannelEnable[mo, ch];
                    }
                    else if (eType == typeParameter.WRITE)
                    {
                        SF_Test.SystemParameter.ChannelEnable[mo, ch] = cbChannel.Checked;
                    }
                }

                //   tbMxxCustomPara_CHx
                for (int ch = 0; ch < SFChannelLength; ch++)
                {
                    strSearchPara_Custom.Remove(3, 2);
                    strSearchPara_Custom.Insert(3, (mo + 1).ToString("D2"));
                    strSearchPara_Custom.Remove(18, 1);
                    strSearchPara_Custom.Insert(18, (ch + 1).ToString("D1"));

                    ReaLTaiizor.Controls.MaterialTextBox tbPara_Custom = this.Controls.Find(strSearchPara_Custom.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;
                    if (eType == typeParameter.READ)
                    {
                        if (SF_Test.SystemParameter.Para[mo, 0].c != 0)
                        {
                            tbPara_Custom.Text = Math.Round(SF_Test.SystemParameter.Para[mo, ch].Tm / SF_Test.SystemParameter.Para[mo, 0].c).ToString();
                        }
                        else
                        {
                            tbPara_Custom.Text = 0.ToString();
                        }
                    }
                    else if (eType == typeParameter.WRITE)
                    {
                        if (SF_Test.SystemParameter.Para[mo, 0].c != 0)
                        {
                            try
                            {
                                SF_Test.SystemParameter.Para[mo, ch].Tm = SF_Test.SystemParameter.Para[mo, 0].c * Convert.ToSingle(tbPara_Custom.Text);
                            }
                            catch (Exception ex) {; }
                        }
                        else
                        {
                            SF_Test.SystemParameter.Para[mo, ch].Tm = 0;
                        }
                    }
                }
            }
        }

        private void readSetupParameter()
        {
            exeSetupParameter(typeParameter.READ);
        }
        private void writeSetupParameter()
        {
            // 저장이후 Cancel버튼 동작안하도록함
            btCancel.Enabled = false;

            exeSetupParameter(typeParameter.WRITE);
        }

        private void updateFactorySettingScreen(Boolean fgFactory)
        {
            StringBuilder strChannelPannel = new StringBuilder("gbMxxCHPannel");
            StringBuilder strParaPannel = new StringBuilder("gbMxxParaPannel");
            StringBuilder strCustomPannel = new StringBuilder("gbMxxCustomPannel");

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                strChannelPannel.Remove(3, 2);
                strChannelPannel.Insert(3, (mo + 1).ToString("D2"));
                GroupBox gbChannelPannel = this.Controls.Find(strChannelPannel.ToString(), true)[0] as GroupBox;

                strParaPannel.Remove(3, 2);
                strParaPannel.Insert(3, (mo + 1).ToString("D2"));
                GroupBox gbParaPannel = this.Controls.Find(strParaPannel.ToString(), true)[0] as GroupBox;

                strCustomPannel.Remove(3, 2);
                strCustomPannel.Insert(3, (mo + 1).ToString("D2"));
                GroupBox gbCustomPannel = this.Controls.Find(strCustomPannel.ToString(), true)[0] as GroupBox;

                if (fgFactory)
                {
                    gbChannelPannel.Visible = true;
                    gbParaPannel.Visible = true;
                    gbCustomPannel.Visible = true;
                }
                else
                {
                    gbChannelPannel.Visible = false;
                    gbParaPannel.Visible = true;  // 2017/11/24 Visible : a,b,c값의 설정을 허용
                    gbCustomPannel.Visible = true;
                }
            }
        }

        private void updateLockSetupState(bool Lock)
        {
            if (cbLockSetup.Checked)
            {
                gbSetUpModule.Enabled = false;
                btLoad.Enabled = false;
                btSave.Enabled = false;
                btConfirm.Enabled = false;
                btWindowsParaRead.Enabled = false;
                btWindowsParaWrite.Enabled = false;
                btWindowsParaReset.Enabled = false;
                tbLayoutWinPara.Enabled = false;
            }
            else
            {
                gbSetUpModule.Enabled = true;
                btLoad.Enabled = true;
                btSave.Enabled = true;
                btConfirm.Enabled = true;
                btWindowsParaRead.Enabled = true;
                btWindowsParaWrite.Enabled = true;
                btWindowsParaReset.Enabled = true;
                tbLayoutWinPara.Enabled = true;
            }

            StringBuilder strChannelPannel = new StringBuilder("gbMxxCHPannel");
            StringBuilder strParaPannel = new StringBuilder("gbMxxParaPannel");
            StringBuilder strCustomPannel = new StringBuilder("gbMxxCustomPannel");

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                strChannelPannel.Remove(3, 2);
                strChannelPannel.Insert(3, (mo + 1).ToString("D2"));
                GroupBox gbChannelPannel = this.Controls.Find(strChannelPannel.ToString(), true)[0] as GroupBox;

                strParaPannel.Remove(3, 2);
                strParaPannel.Insert(3, (mo + 1).ToString("D2"));
                GroupBox gbParaPannel = this.Controls.Find(strParaPannel.ToString(), true)[0] as GroupBox;

                strCustomPannel.Remove(3, 2);
                strCustomPannel.Insert(3, (mo + 1).ToString("D2"));
                GroupBox gbCustomPannel = this.Controls.Find(strCustomPannel.ToString(), true)[0] as GroupBox;

                if (cbLockSetup.Checked)
                {
                    gbChannelPannel.Enabled = false;
                    gbParaPannel.Enabled = false;
                    gbCustomPannel.Enabled = false;
                    btConfirm.Enabled = false;
                }
                else
                {
                    gbChannelPannel.Enabled = true;
                    gbParaPannel.Enabled = true;
                    gbCustomPannel.Enabled = true;
                }
            }
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {
            this.Icon = SapflowApplication.Properties.Resources.logo_real;

            // 모듈수를 8로 제한한다.
            if(SFModuleLength> Limit_SFModuleLength) SFModuleLength = Limit_SFModuleLength; 

            // Factory Setting에 따라 불필요 파라메터를 숨김
            updateFactorySettingScreen(SF_Test.fgFactoryModeActivated);


            // Lock State에 따라 화면을 구성
            updateLockSetupState(cbLockSetup.Checked);

            // 파라메터를 읽어들여서 셋업화면을 구성한다.
            readSetupParameter();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            // 파라메터를 읽어들여서 셋업화면을 구성한다.
            if (cbLockSetup.Checked == false)
            {
                readSetupParameter();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbLockSetup.Checked == false)
            {
                // 파라메터를 저장한다
                writeSetupParameter();
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            // 파라메터를 저장하고 창을 닫는다
            writeSetupParameter();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            // 파라메터를 저장하지 않고 창을 닫는다
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbLockSetup_CheckedChanged(object sender, EventArgs e)
        {
            updateLockSetupState(cbLockSetup.Checked);
        }

        private void btWindowsParaReset_Click(object sender, EventArgs e)
        {
            SF_Test.fgGraphParameterSaved = false;
        }

        private void exeSetupWindowsPara(typeParameter eType)
        {
            StringBuilder strLocationX = new StringBuilder("tbMxLocX");
            StringBuilder strLocationY = new StringBuilder("tbMxLocY");
            StringBuilder strSizeX = new StringBuilder("tbMxSizX");
            StringBuilder strSizeY = new StringBuilder("tbMxSizY");

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                // tbMxLocX
                strLocationX.Remove(3, 1);
                strLocationX.Insert(3, (mo + 1).ToString("D1"));
                ReaLTaiizor.Controls.MaterialTextBox tbLocationX = this.Controls.Find(strLocationX.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;

                // tbMxLocY
                strLocationY.Remove(3, 1);
                strLocationY.Insert(3, (mo + 1).ToString("D1"));
                ReaLTaiizor.Controls.MaterialTextBox tbLocationY = this.Controls.Find(strLocationY.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;

                // tbMxSizX
                strSizeX.Remove(3, 1);
                strSizeX.Insert(3, (mo + 1).ToString("D1"));
                ReaLTaiizor.Controls.MaterialTextBox tbSizeX = this.Controls.Find(strSizeX.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;

                // tbMxSizY
                strSizeY.Remove(3, 1);
                strSizeY.Insert(3, (mo + 1).ToString("D1"));
                ReaLTaiizor.Controls.MaterialTextBox tbSizeY = this.Controls.Find(strSizeY.ToString(), true)[0] as ReaLTaiizor.Controls.MaterialTextBox;

                if (eType == typeParameter.READ)
                {
                    tbLocationX.Text = SF_Test.GraphLocation[mo].X.ToString();
                    tbLocationY.Text = SF_Test.GraphLocation[mo].Y.ToString();
                    tbSizeX.Text = SF_Test.GraphSize[mo].Width.ToString();
                    tbSizeY.Text = SF_Test.GraphSize[mo].Height.ToString();
                }
                else if (eType == typeParameter.WRITE)
                {
                    try
                    {
                        SF_Test.GraphLocation[mo].X = Convert.ToInt32(tbLocationX.Text);
                    }
                    catch { }

                    try
                    {
                        SF_Test.GraphLocation[mo].Y = Convert.ToInt32(tbLocationY.Text);
                    }
                    catch { }

                    try
                    {
                        SF_Test.GraphSize[mo].Width = Convert.ToInt32(tbSizeX.Text);
                    }
                    catch { }

                    try
                    {
                        SF_Test.GraphSize[mo].Height = Convert.ToInt32(tbSizeY.Text);
                    }
                    catch { }
                }

            }
        }

        private void readSetupWindowsPara()
        {
            exeSetupWindowsPara(typeParameter.READ);
        }
        private void writeSetupWindowsPara()
        {
            exeSetupWindowsPara(typeParameter.WRITE);
        }

        private void btWindowsParaRead_Click(object sender, EventArgs e)
        {
            readSetupWindowsPara();
        }

        private void btWindowsParaWrite_Click(object sender, EventArgs e)
        {
            writeSetupWindowsPara();
        }

        private void btWindowsParaReset_Click_1(object sender, EventArgs e)
        {
            SF_Test.fgGraphParameterSaved = false;
            btWindowsParaReset.Enabled = false;
        }

        private void cbMEnable_CheckedChanged(object sender, EventArgs e)
        {
            SF_Test.fgGraphParameterSaved = false;
            btWindowsParaReset.Enabled = false;
        }
    }
}
