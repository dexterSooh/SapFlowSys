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
    public partial class frmValveControlSetup : MaterialForm
    {
        private const int SFModuleLength = SF_Test.SFModuleLength;      // SF_Test에 정의된 채널수를 참조
        private const int SFChannelLength = SF_Test.SFChannelLength;      // SF_Test에 정의된 채널수를 참조

        public frmValveControlSetup()
        {
            InitializeComponent();
        }


        private void frmValveControlSetup_Load(object sender, EventArgs e)
        {
            setupDataGridView();
            setupModuleChannelNumber();

            // 파라메터를 읽어들여서 셋업화면을 구성한다.
            readSetupParameter();

            // Lock Status를 업데이트한다.
            updateLockSetupState(cbLockSetup.Checked);
        }

        private void setupModuleChannelNumber()
        {
            // Module Number Setup
            setupSubModuleListboxUpdate(cbModuleNumber, SFModuleLength);

            // Channel Number Setup
            setupSubModuleListboxUpdate(cbChannelNumber, SFChannelLength);
        }

        private void setupSubModuleListboxUpdate(ComboBox cbBox, int Number)
        {
            cbBox.Items.Clear();
            for (int num = 0; num < Number; num++)
            {
                cbBox.Items.Add((num + 1).ToString());
            }
            cbBox.Items.Add("all");
            cbBox.Items.Add("selected");

            cbBox.SelectedIndex = cbBox.Items.Count - 1;
        }

        private string[] IndexDataGrid = { "Enable", "Module", "Channel", "Graph Min.", "Graph Max.", "Valve Control Min.", "Valve Control Max.", "Constraint", "%" };

        private void setupDataGridView()
        {
            tabValveControl.Controls.Add(dataGridView1);

            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = IndexDataGrid.GetLength(0);
            for (int index = 0; index < IndexDataGrid.GetLength(0); index++)
            {
                dataGridView1.Columns[index].Name = (IndexDataGrid[index]);
                if (index == 0)
                {
                    dataGridView1.Columns[index].Width = 50;
                    dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].ReadOnly = true;
                }
                else if (index == 1)
                {
                    dataGridView1.Columns[index].Width = 60;
                    dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                else if (index == 2)
                {
                    dataGridView1.Columns[index].Width = 60;
                    dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                else if ((index >= 3) && (index < 7))
                {
                    dataGridView1.Columns[index].Width = 120;
                    dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                else
                {
                    dataGridView1.Columns[index].Width = 80;
                    dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void populateDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            for (int mo = 0; mo < SFModuleLength; mo++)
            {
                for (int ch = 0; ch < SFChannelLength; ch++)
                {

                    string[] rowString = new string[dataGridView1.ColumnCount];

                    foreach (var item in IndexDataGrid)
                    {
                        int indexGrid = Array.IndexOf(IndexDataGrid, item);

                        rowString[indexGrid] = null;
                        if (item.StartsWith("Enable"))
                        {
                            rowString[indexGrid] = null;
                        }
                        if (item.StartsWith("Module"))
                        {
                            rowString[indexGrid] = (mo + 1).ToString();
                        }
                        else if (item.StartsWith("Channel"))
                        {
                            rowString[indexGrid] = (ch + 1).ToString();
                        }
                        else if (item.StartsWith("Graph Min"))
                        {
                            rowString[indexGrid] = SF_Test.GraphMin[mo, ch].ToString();
                        }
                        else if (item.StartsWith("Graph Max"))
                        {
                            rowString[indexGrid] = SF_Test.GraphMax[mo, ch].ToString();
                        }
                        else if (item.StartsWith("Valve Control Min"))
                        {
                            rowString[indexGrid] = SF_Test.VCParameter.Min[mo, ch].ToString();
                        }
                        else if (item.StartsWith("Valve Control Max"))
                        {
                            rowString[indexGrid] = SF_Test.VCParameter.Max[mo, ch].ToString();
                        }
                        else if (item.StartsWith("Constraint"))
                        {
                            rowString[indexGrid] = SF_Test.VCParameter.Constrain[mo, ch].ToString();
                        }
                        else if (item.StartsWith("%"))
                        {
                            rowString[indexGrid] = SF_Test.VCParameter.Ratio[mo, ch].ToString();
                        }
                    }

                    int index;
                    index = dataGridView1.Rows.Add(rowString);

                    // Add ComboBox
                    //DataGridViewComboBoxCell cbEnableBox = new DataGridViewComboBoxCell();
                    //cbEnableBox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    //cbEnableBox.Items.Add("Enable");
                    //cbEnableBox.Items.Add("Disable");

                    // Add CheckBox
                    DataGridViewCheckBoxCell cbEnableBox = new DataGridViewCheckBoxCell();

                    if (SF_Test.VCParameter.Enabled[mo, ch])
                    {
                        cbEnableBox.Value = true;
                    }
                    else
                    {
                        cbEnableBox.Value = false;
                    }
                    dataGridView1.Rows[index].Cells[0] = cbEnableBox;       // Enable Box is located on Index=0

                    if (mo == (SFModuleLength - 1))
                    {
                        //   dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                }
            }
        }

        // 저장이 정상완료되면 true리턴
        private bool getDataFromDataGridView()
        {
            bool fgResult = true;
            int mo, ch;
            bool VCEnable;
            float GraphMin, GraphMax, VCMin, VCMax;
            int VCConstraint, VCRatio;

            mo = 0;
            ch = 0;
            GraphMin = 0.0f;
            GraphMax = 0.0f;
            VCMin = 0.0f;
            VCMax = 0.0f;
            VCConstraint = 0;
            VCRatio = 0;
            VCEnable = false;

            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                foreach (var item in IndexDataGrid)
                {
                    int indexGrid = Array.IndexOf(IndexDataGrid, item);
                    if (item.StartsWith("Enable"))
                    {
                        try
                        {
                            VCEnable = (bool)dataGridViewRow.Cells[indexGrid].Value;
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("Module"))
                    {
                        try
                        {
                            mo = Convert.ToInt32(dataGridViewRow.Cells[indexGrid].Value) - 1;
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("Channel"))
                    {
                        try
                        {
                            ch = Convert.ToInt32(dataGridViewRow.Cells[indexGrid].Value) - 1;
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("Graph Min"))
                    {
                        try
                        {
                            GraphMin = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("Graph Max"))
                    {
                        try
                        {
                            GraphMax = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("Valve Control Min"))
                    {
                        try
                        {
                            VCMin = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("Valve Control Max"))
                    {
                        try
                        {
                            VCMax = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("Constraint"))
                    {
                        try
                        {
                            VCConstraint = Convert.ToInt32(dataGridViewRow.Cells[indexGrid].Value);
                        }
                        catch { fgResult = false; }
                    }
                    else if (item.StartsWith("%"))
                    {
                        try
                        {
                            VCRatio = Convert.ToInt32(dataGridViewRow.Cells[indexGrid].Value);
                        }
                        catch { fgResult = false; }
                    }
                }

                // Set Parameters
                if (fgResult == true)  // 에러가 없는 경우에만 데이터를 업데이트
                {
                    // Enable
                    SF_Test.VCParameter.Enabled[mo, ch] = VCEnable;
  
                    // Graph
                    SF_Test.GraphMin[mo, ch] = GraphMin;
                    SF_Test.GraphMax[mo, ch] = GraphMax;

                    // Valve Control
                    SF_Test.VCParameter.Min[mo, ch] = VCMin;
                    SF_Test.VCParameter.Max[mo, ch] = VCMax;
                    SF_Test.VCParameter.Constrain[mo, ch] = VCConstraint;
                    SF_Test.VCParameter.Ratio[mo, ch] = VCRatio;
                }
            }

            return (fgResult);
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

        private void btConfirm_Click(object sender, EventArgs e)
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

        private void updateLockSetupState(bool Lock)
        {
            if (cbLockSetup.Checked)
            {
                btLoad.Enabled = false;
                btSave.Enabled = false;
                btConfirm.Enabled = false;
                dataGridView1.ForeColor = Color.LightGray;
                updateLockStateForDataGridView(true);
            }
            else
            {
                btLoad.Enabled = true;
                btSave.Enabled = true;
                btConfirm.Enabled = true;
                dataGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
                updateLockStateForDataGridView(false);
            }
        }


        // fgReadOnly true인 경우 DataGridView Cell이 ReadOnly상태임
        private void updateLockStateForDataGridView(bool fgReadOnly)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if ((j == 1) || (j == 2))
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;    // 모듈/채널번호는 항상 true
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = fgReadOnly;
                    }
                }
            }
        }

        enum typeParameter
        {
            READ,
            WRITE
        };

        private void exeSetupParameter(typeParameter eType)
        {
            if (eType == typeParameter.READ)
            {
                populateDataGridView();
                lbResultText.Text = "Load OK";
                lbResultText.ForeColor = Color.Green;
            }
            else if (eType == typeParameter.WRITE)
            {
                bool fgResult;
                fgResult = getDataFromDataGridView();
                if (fgResult == true)
                {
                    lbResultText.Text = "Save OK";
                    lbResultText.ForeColor = Color.Green;
                }
                else
                {
                    lbResultText.Text = "Save NG";
                    lbResultText.ForeColor = Color.Red;
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        // 업데이트가 성공하면 true를 반환
        private bool updateDataGridRow(DataGridViewRow dataGridViewRow)
        {
            bool fgResult = true;
            try
            {
                foreach (var item in IndexDataGrid)
                {
                    int indexGrid = Array.IndexOf(IndexDataGrid, item);
                    if (item.StartsWith("Enable"))
                    {
                        if (cbEnableEnable.Checked)
                        {
                            if (cbEnableFlag.Checked)
                            {
                                dataGridViewRow.Cells[indexGrid].Value = true;
                            }
                            else
                            {
                                dataGridViewRow.Cells[indexGrid].Value = false;
                            }
                        }
                    }
                    else if (item.StartsWith("Graph Min"))
                    {
                        if (cbEnableGraphMin.Checked)
                        {
                            dataGridViewRow.Cells[indexGrid].Value = Convert.ToSingle(tbGraphMin.Text.ToString());
                        }
                    }
                    else if (item.StartsWith("Graph Max"))
                    {
                        if (cbEnableGraphMax.Checked)
                        {
                            dataGridViewRow.Cells[indexGrid].Value = Convert.ToSingle(tbGraphMax.Text.ToString());
                        }
                    }
                    else if (item.StartsWith("Valve Control Min"))
                    {
                        if (cbEnableVCMin.Checked)
                        {
                            dataGridViewRow.Cells[indexGrid].Value = Convert.ToSingle(tbVCMin.Text.ToString());
                        }
                    }
                    else if (item.StartsWith("Valve Control Max"))
                    {
                        if (cbEnableVCMax.Checked)
                        {
                            dataGridViewRow.Cells[indexGrid].Value = Convert.ToSingle(tbVCMax.Text.ToString());
                        }
                    }
                    else if (item.StartsWith("Constraint"))
                    {
                        if (cbEnableVCConstraint.Checked)
                        {
                            dataGridViewRow.Cells[indexGrid].Value = Convert.ToInt32(tbConstraint.Text.ToString());
                        }
                    }
                    else if (item.StartsWith("%"))
                    {
                        if (cbEnableVCRatio.Checked)
                        {
                            dataGridViewRow.Cells[indexGrid].Value = Convert.ToInt32(tbVCRatio.Text.ToString());
                        }
                    }
                }
            }
            catch { fgResult = false; }

            return (fgResult);
        }

        private void btDefault_Click(object sender, EventArgs e)
        {
            bool fgResult = true;

            if (cbModuleNumber.SelectedItem.ToString() == "selected")
            {
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.SelectedRows)
                {
                    fgResult = updateDataGridRow(dataGridViewRow);
                    if (fgResult == false)
                    {
                        break;
                    }
                }
            }
            else if (cbModuleNumber.SelectedItem.ToString() == "all")
            {
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    fgResult = updateDataGridRow(dataGridViewRow);
                    if (fgResult == false)
                    {
                        break;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    try
                    {
                        string strMo, strCh;

                        strMo = cbModuleNumber.SelectedItem.ToString();
                        strCh = cbChannelNumber.SelectedItem.ToString();

                        if ((strMo == dataGridViewRow.Cells[1].Value.ToString()) && (strCh == dataGridViewRow.Cells[2].Value.ToString()))
                        {
                            fgResult = updateDataGridRow(dataGridViewRow);
                            if (fgResult == false)
                            {
                                break;
                            }
                        }
                    }
                    catch
                    {
                        fgResult = false;
                        break;
                    }
                }
            }

            if (fgResult == true)
            {
                lbResultText.Text = "Set OK";
                lbResultText.ForeColor = Color.Green;
            }
            else
            {
                lbResultText.Text = "Set NG";
                lbResultText.ForeColor = Color.Red;
            }
        }

        private void cbModuleNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModuleNumber.SelectedItem.ToString() == "selected")
            {
                cbChannelNumber.SelectedItem = "selected";
            }
            else if (cbModuleNumber.SelectedItem.ToString() == "all")
            {
                cbChannelNumber.SelectedItem = "all";
            }
            else if ((cbChannelNumber.SelectedItem.ToString() == "selected") || (cbChannelNumber.SelectedItem.ToString() == "all"))
            {
                cbChannelNumber.SelectedIndex = 0;
            }
        }


        private void cbChannelNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChannelNumber.SelectedItem.ToString() == "selected")
            {
                cbModuleNumber.SelectedItem = "selected";
            }
            else if (cbChannelNumber.SelectedItem.ToString() == "all")
            {
                cbModuleNumber.SelectedItem = "all";
            }
            else if ((cbModuleNumber.SelectedItem.ToString() == "selected") || (cbModuleNumber.SelectedItem.ToString() == "all"))
            {
                cbModuleNumber.SelectedIndex = 0;
            }

        }
    }
}
