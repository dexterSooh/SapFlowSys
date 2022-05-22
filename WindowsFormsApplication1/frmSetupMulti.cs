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
	public partial class frmSetupMulti : MaterialForm
	{
		SF_Test parentForm;
		private const int SFModuleLength = SF_Test.SFModuleLength;      // SF_Test에 정의된 채널수를 참조
		private const int SFChannelLength = SF_Test.SFChannelLength;      // SF_Test에 정의된 채널수를 참조

		public frmSetupMulti(SF_Test parentForm)
		{
			this.parentForm = parentForm;
			InitializeComponent();
		}

		private SF_Test.paraSapFlow Default_SFabcParameter;

		private void frmSetupMulti_Load(object sender, EventArgs e)
		{
			Default_SFabcParameter.a = SF_Test.Default_Const_SFParameter.a;
			Default_SFabcParameter.b = SF_Test.Default_Const_SFParameter.b;
			Default_SFabcParameter.c = SF_Test.Default_Const_SFParameter.c;
			Default_SFabcParameter.Tm = SF_Test.Default_Const_SFParameter.Tm;

			tbDefault_a.Text = Default_SFabcParameter.a.ToString();
			tbDefault_b.Text = Default_SFabcParameter.b.ToString();
			tbDefault_c.Text = Default_SFabcParameter.c.ToString();
			tbDefault_Tm.Text = Default_SFabcParameter.Tm.ToString();

			setupDataGridView();
			setupDataGridView2();

			// 파라메터를 읽어들여서 셋업화면을 구성한다.
			readSetupParameter();

			// Lock Status를 업데이트한다.
			updateLockSetupState(cbLockSetup.Checked);
		}

		private string[] IndexDataGrid = { "Module", "Enable", "a", "b", "c", "Tm1", "Tm2", "Tm3", "Tm4" };
		private string[] IndexDataGrid2 = { "Enable", "Module", "Channel", "SF Min.", "SF Max.", "RTemp Min.", "RTemp Max." };

		private void setupDataGridView()
		{
			//Controls.Add(dataGridView1);

			dataGridView1.Columns.Clear();
			dataGridView1.ColumnCount = IndexDataGrid.GetLength(0);
			for (int index = 0; index < IndexDataGrid.GetLength(0); index++)
			{
				dataGridView1.Columns[index].Name = (IndexDataGrid[index]);
				if (index == 0)
				{
					dataGridView1.Columns[index].Width = 60;
					dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView1.Columns[index].ReadOnly = true;
				}
				else if (index == 1)
				{
					dataGridView1.Columns[index].Width = 60;
					dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					//   dataGridView1.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				else
				{
					dataGridView1.Columns[index].Width = 70;
					dataGridView1.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView1.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
				string[] rowString = new string[dataGridView1.ColumnCount];

				int ch = 0;
				foreach (var item in IndexDataGrid)
				{
					int indexGrid = Array.IndexOf(IndexDataGrid, item);

					rowString[indexGrid] = null;
					if (item.StartsWith("Module"))
					{
						rowString[indexGrid] = (mo + 1).ToString("D2");
					}
					else if (item.StartsWith("Enable"))
					{
						rowString[indexGrid] = null;
					}
					else if (item.StartsWith("a"))
					{
						rowString[indexGrid] = SF_Test.SystemParameter.Para[mo, 0].a.ToString();
					}
					else if (item.StartsWith("b"))
					{
						rowString[indexGrid] = SF_Test.SystemParameter.Para[mo, 0].b.ToString();
					}
					else if (item.StartsWith("c"))
					{
						rowString[indexGrid] = SF_Test.SystemParameter.Para[mo, 0].c.ToString();
					}
					else if (item.StartsWith("Tm"))
					{
						ch = Convert.ToInt32(item.Substring(item.Length - 1)) - 1;
						rowString[indexGrid] = SF_Test.SystemParameter.Para[mo, ch].Tm.ToString();
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

				if (SF_Test.SystemParameter.ModuleEnable[mo])
				{
					cbEnableBox.Value = true;
				}
				else
				{
					cbEnableBox.Value = false;
				}
				dataGridView1.Rows[index].Cells[1] = cbEnableBox;

				if (mo == (SFModuleLength - 1))
				{
					//   dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				}
			}
		}

		// DataGrid의 내용을 얻어와 파라메터 저장
		// 저장이 정상완료되면 true리턴
		private bool getDataFromDataGridView()
		{
			bool fgResult = true;
			int mo;
			bool ModuleEnable;
			float a, b, c;
			float[] Tm = new float[SFChannelLength];

			mo = 0;
			ModuleEnable = false;
			a = 0.0f;
			b = 0.0f;
			c = 0.0f;
			Tm[0] = 0.0f;
			Tm[1] = 0.0f;
			Tm[2] = 0.0f;
			Tm[3] = 0.0f;

			foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
			{
				foreach (var item in IndexDataGrid)
				{
					int indexGrid = Array.IndexOf(IndexDataGrid, item);
					if (item.StartsWith("Module"))
					{
						try
						{
							mo = Convert.ToInt32(dataGridViewRow.Cells[indexGrid].Value) - 1;
						}
						catch { fgResult = false; }
					}
					else if (item.StartsWith("Enable"))
					{
						try
						{
							ModuleEnable = (bool)dataGridViewRow.Cells[indexGrid].Value;
						}
						catch { fgResult = false; }
					}
					else if (item.StartsWith("a"))
					{
						try
						{
							a = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
						catch { fgResult = false; }
					}
					else if (item.StartsWith("b"))
					{
						try
						{
							b = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
						catch { fgResult = false; }
					}
					else if (item.StartsWith("c"))
					{
						try
						{
							c = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
						catch { fgResult = false; }
					}
					else if (item.StartsWith("Tm"))
					{
						int ch;
						ch = Convert.ToInt32(item.Substring(item.Length - 1)) - 1;
						try
						{
							Tm[ch] = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
						catch { fgResult = false; }
					}
				}

				if (fgResult == true)  // 에러가 없는 경우에만 데이터를 업데이트
				{
					SF_Test.SystemParameter.ModuleEnable[mo] = ModuleEnable;
					for (int ch = 0; ch < SFChannelLength; ch++)
					{
						SF_Test.SystemParameter.Para[mo, ch].a = a;
						SF_Test.SystemParameter.Para[mo, ch].b = b;
						SF_Test.SystemParameter.Para[mo, ch].c = c;
						SF_Test.SystemParameter.Para[mo, ch].Tm = Tm[ch];
						if (SF_Test.SystemParameter.ModuleEnable[mo] == true)
						{
							SF_Test.SystemParameter.ChannelEnable[mo, ch] = true;
						}
						else
						{
							SF_Test.SystemParameter.ChannelEnable[mo, ch] = false;
						}
					}
				}
			}

			return (fgResult);
		}

		// DataGrid2의 내용을 얻어와 파라메터 저장
		// 저장이 정상완료되면 true리턴
		private bool getDataFromDataGridView2()
		{
			bool fgResult = true;

			int mo = 0, ch = 0;
			bool fgGraphEnable;
			float SFMax = 0, SFMin = 0, RTempMax = 0, RTempMin = 0;

			foreach (DataGridViewRow dataGridViewRow in dataGridView2.Rows)
			{
				foreach (var item in IndexDataGrid2)
				{
					int indexGrid = Array.IndexOf(IndexDataGrid2, item);
					try
					{
						if (item.StartsWith("Module"))
						{
							mo = Convert.ToInt32(dataGridViewRow.Cells[indexGrid].Value) - 1;
						}
						else if (item.StartsWith("Channel"))
						{
							ch = Convert.ToInt32(dataGridViewRow.Cells[indexGrid].Value) - 1;
						}
						else if (item.StartsWith("Enable"))
						{
							fgGraphEnable = (bool)dataGridViewRow.Cells[indexGrid].Value;
						}
						else if (item.StartsWith("SF Min"))
						{
							SFMin = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
						else if (item.StartsWith("SF Max"))
						{
							SFMax = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
						else if (item.StartsWith("RTemp Min"))
						{
							RTempMin = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
						else if (item.StartsWith("RTemp Max"))
						{
							RTempMax = Convert.ToSingle(dataGridViewRow.Cells[indexGrid].Value);
						}
					}
					catch { fgResult = false; }
				}

				if (fgResult == true)  // 에러가 없는 경우에만 데이터를 업데이트
				{
					// fgGraphEnable .. 사용??
					// SFMax, SFMin, RTempMax, RTempMin
					SF_Test.GraphMin[mo, ch] = SFMin;
					SF_Test.GraphMax[mo, ch] = SFMax;
					SF_Test.GraphMin2[mo, ch] = RTempMin;
					SF_Test.GraphMax2[mo, ch] = RTempMax;

					SF_Test.fgGraphMin[mo, ch] = !float.IsNaN(SFMin);
					SF_Test.fgGraphMax[mo, ch] = !float.IsNaN(SFMax);
					SF_Test.fgGraphMin2[mo, ch] = !float.IsNaN(RTempMin);
					SF_Test.fgGraphMax2[mo, ch] = !float.IsNaN(RTempMax);
				}
			}
			return (fgResult);
		}


		private void setupDataGridView2()
		{
			tableLayoutPanel5.Controls.Add(dataGridView2);

			dataGridView2.Columns.Clear();
			dataGridView2.ColumnCount = IndexDataGrid2.GetLength(0);
			for (int index = 0; index < IndexDataGrid2.GetLength(0); index++)
			{
				dataGridView2.Columns[index].Name = (IndexDataGrid2[index]);
				if (index == 0)
				{
					dataGridView2.Columns[index].Width = 50;
					dataGridView2.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].ReadOnly = true;
				}
				else if (index == 1)
				{
					dataGridView2.Columns[index].Width = 65;
					dataGridView2.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				else if (index == 2)
				{
					dataGridView2.Columns[index].Width = 65;
					dataGridView2.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				else if ((index >= 3) && (index < 7))
				{
					dataGridView2.Columns[index].Width = 110;
					dataGridView2.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dataGridView2.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				else
				{
					dataGridView2.Columns[index].Width = 80;
					dataGridView2.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridView2.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
		}

		private void populateDataGridView2()
		{
			dataGridView2.Rows.Clear();
			dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

			for (int mo = 0; mo < SFModuleLength; mo++)
			{
				for (int ch = 0; ch < SFChannelLength; ch++)
				{

					string[] rowString = new string[dataGridView2.ColumnCount];

					foreach (var item in IndexDataGrid2)
					{
						int indexGrid = Array.IndexOf(IndexDataGrid2, item);

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
						else if (item.StartsWith("SF Min"))
						{
							rowString[indexGrid] = SF_Test.GraphMin[mo, ch].ToString();
						}
						else if (item.StartsWith("SF Max"))
						{
							rowString[indexGrid] = SF_Test.GraphMax[mo, ch].ToString();
						}
						else if (item.StartsWith("RTemp Min"))
						{
							rowString[indexGrid] = SF_Test.GraphMin2[mo, ch].ToString();
						}
						else if (item.StartsWith("RTemp Max"))
						{
							rowString[indexGrid] = SF_Test.GraphMax2[mo, ch].ToString();
						}
					}

					int index;
					index = dataGridView2.Rows.Add(rowString);

					// Add ComboBox
					//DataGridViewComboBoxCell cbEnableBox = new DataGridViewComboBoxCell();
					//cbEnableBox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
					//cbEnableBox.Items.Add("Enable");
					//cbEnableBox.Items.Add("Disable");

					// Add CheckBox
					DataGridViewCheckBoxCell cbEnableBox = new DataGridViewCheckBoxCell();

					if (SF_Test.fgGraphMin[mo, ch] && SF_Test.fgGraphMax[mo, ch])
					{
						cbEnableBox.Value = true;
					}
					else
					{
						cbEnableBox.Value = false;
					}
					dataGridView2.Rows[index].Cells[0] = cbEnableBox;       // Enable Box is located on Index=0

					if (mo == (SFModuleLength - 1))
					{
						//   dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
					}
				}
			}
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

			btGraph_Click(sender, e);

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
				updateLockStateForDataGridView2(true);
			}
			else
			{
				btLoad.Enabled = true;
				btSave.Enabled = true;
				btConfirm.Enabled = true;
				dataGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
				updateLockStateForDataGridView(false);
				updateLockStateForDataGridView2(false);
			}
		}

		// fgReadOnly true인 경우 DataGridView Cell이 ReadOnly상태임
		private void updateLockStateForDataGridView(bool fgReadOnly)
		{
			for (int i = 0; i < dataGridView1.RowCount; i++)
			{
				for (int j = 0; j < dataGridView1.ColumnCount; j++)
				{
					if ((j == 0))
					{
						dataGridView1.Rows[i].Cells[j].ReadOnly = true;    // 모듈번호는 항상 true
					}
					else
					{
						dataGridView1.Rows[i].Cells[j].ReadOnly = fgReadOnly;
					}
				}
			}
		}

		// fgReadOnly true인 경우 DataGridView Cell이 ReadOnly상태임
		private void updateLockStateForDataGridView2(bool fgReadOnly)
		{
			for (int i = 0; i < dataGridView2.RowCount; i++)
			{
				for (int j = 0; j < dataGridView2.ColumnCount; j++)
				{
					if ((j == 1) || (j == 2))
					{
						dataGridView2.Rows[i].Cells[j].ReadOnly = true;    // 모듈번호는 항상 true
					}
					else
					{
						dataGridView2.Rows[i].Cells[j].ReadOnly = fgReadOnly;
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
				populateDataGridView2();
				lbResultText.Text = "Load OK";
				lbResultText.ForeColor = Color.Green;
			}
			else if (eType == typeParameter.WRITE)
			{
				bool fgResult;
				if (tabControl1.SelectedTab.Name == "tbpMultiSetup")
				{
					// Multi Setup Save
					fgResult = getDataFromDataGridView();
				}
				else
				{
					// Graph Setup Save
					fgResult = getDataFromDataGridView2();
				}
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

		private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			foreach (var item in IndexDataGrid)
			{
				if ((item.StartsWith("Module")) || (item.StartsWith("Enable")))
				{
					e.Control.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
				}
				else
				{
					e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
				}
			}

		}

		// 업데이트가 성공하면 true를 반환
		private bool updateDataGridRow(DataGridViewRow dataGridViewRow)
		{
			bool fgResult;

			try
			{
				int ch = 0;
				foreach (var item in IndexDataGrid)
				{
					int indexGrid = Array.IndexOf(IndexDataGrid, item);

					if (item.StartsWith("Enable"))
					{
						if (cbEnableFlag.CheckState == CheckState.Checked)
						{
							dataGridViewRow.Cells[indexGrid].Value = true;
						}
						else
						{
							dataGridViewRow.Cells[indexGrid].Value = false;
						}
					}
					else if (item.StartsWith("a"))
					{
						dataGridViewRow.Cells[indexGrid].Value = tbDefault_a.Text;
					}
					else if (item.StartsWith("b"))
					{
						dataGridViewRow.Cells[indexGrid].Value = tbDefault_b.Text;
					}
					else if (item.StartsWith("c"))
					{
						dataGridViewRow.Cells[indexGrid].Value = tbDefault_c.Text;

					}
					else if (item.StartsWith("Tm"))
					{
						ch = Convert.ToInt32(item.Substring(item.Length - 1)) - 1;
						dataGridViewRow.Cells[indexGrid].Value = tbDefault_Tm.Text;
					}
				}
				fgResult = true;
			}
			catch
			{
				fgResult = false;
			}


			return (fgResult);
		}

		private void btDefault_Click(object sender, EventArgs e)
		{

			bool fgResult = subSetParameter(false);

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

		private void btDefaultAll_Click(object sender, EventArgs e)
		{
			bool fgResult = subSetParameter(true);

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

		// 전체 모듈에 적용시 fgAllModule= true
		// 업데이트 성공시 true반환
		private Boolean subSetParameter(bool fgAllModule)
		{
			bool fgResult = true;

			if (fgAllModule == true)
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
				foreach (DataGridViewRow dataGridViewRow in dataGridView1.SelectedRows)
				{
					fgResult = updateDataGridRow(dataGridViewRow);
					if (fgResult == false)
					{
						break;
					}
				}
			}
			return (fgResult);
		}

		private void btGraph_Click(object sender, EventArgs e)
		{
			if (SF_Test.SystemParameter.MultiModuleOn == false)
			{
				parentForm.initializefrmSfMultiModules();
				this.Focus();
			}
		}

		private void closeMultiModules()
		{
			if (SF_Test.SystemParameter.MultiModuleOn)
			{
				parentForm.m_frmSfMultiModules.Close();
				this.Focus();
			}
		}

		private void btSetGraph_Click(object sender, EventArgs e)
		{
			bool fgResult = subSetParameter2(false);

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

		private void btSetGraphAll_Click(object sender, EventArgs e)
		{
			bool fgResult = subSetParameter2(true);

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

		// 전체 모듈에 적용시 fgAllModule= true
		// 업데이트 성공시 true반환
		private Boolean subSetParameter2(bool fgAllModule)
		{
			bool fgResult = true;

			if (fgAllModule == true)
			{
				foreach (DataGridViewRow dataGridViewRow in dataGridView2.Rows)
				{
					fgResult = updateDataGridRow2(dataGridViewRow);
					if (fgResult == false)
					{
						break;
					}
				}
			}
			else
			{
				foreach (DataGridViewRow dataGridViewRow in dataGridView2.SelectedRows)
				{
					fgResult = updateDataGridRow2(dataGridViewRow);
					if (fgResult == false)
					{
						break;
					}
				}
			}
			return (fgResult);
		}

		// 업데이트가 성공하면 true를 반환
		private bool updateDataGridRow2(DataGridViewRow dataGridViewRow)
		{
			bool fgResult;

			try
			{
				foreach (var item in IndexDataGrid2)
				{
					int indexGrid = Array.IndexOf(IndexDataGrid2, item);

					if (item.StartsWith("Enable"))
					{
						dataGridViewRow.Cells[indexGrid].Value = cbGraphEnable.Checked;
					}
					else if (item.StartsWith("SF Min"))
					{
						if (cbEnableSFMin.Checked)
						{
							dataGridViewRow.Cells[indexGrid].Value = tbSFMin.Text;
						}
					}
					else if (item.StartsWith("SF Max"))
					{
						if (cbEnableSFMax.Checked)
						{
							dataGridViewRow.Cells[indexGrid].Value = tbSFMax.Text;
						}
					}
					else if (item.StartsWith("RTemp Min"))
					{
						if (cbEnableRTempMin.Checked)
						{
							dataGridViewRow.Cells[indexGrid].Value = tbRTempMin.Text;
						}
					}
					else if (item.StartsWith("RTemp Max"))
					{
						if (cbEnableRTempMax.Checked)
						{
							dataGridViewRow.Cells[indexGrid].Value = tbRTempMax.Text;
						}
					}
				}
				fgResult = true;
			}
			catch
			{
				fgResult = false;
			}


			return (fgResult);
		}

		private void btResetLocation_Click(object sender, EventArgs e)
		{
			SF_Test.fgGraphParameterSaved = false;

		}

		private void btNew_Click(object sender, EventArgs e)
		{
			var mo = dataGridView1.Rows.Cast<DataGridViewRow>()
						.Max(r => Convert.ToInt32(r.Cells["Module"].Value));

			string[] rowString = new string[dataGridView1.ColumnCount];

			int ch = 0;
			foreach (var item in IndexDataGrid)
			{
				int indexGrid = Array.IndexOf(IndexDataGrid, item);

				rowString[indexGrid] = null;
				if (item.StartsWith("Module"))
				{
					rowString[indexGrid] = (mo + 1).ToString("D2");
				}
				else if (item.StartsWith("Enable"))
				{
					rowString[indexGrid] = null;
				}
				else if (item.StartsWith("a"))
				{
					rowString[indexGrid] = SF_Test.SystemParameter.Para[0, 0].a.ToString();
				}
				else if (item.StartsWith("b"))
				{
					rowString[indexGrid] = SF_Test.SystemParameter.Para[0, 0].b.ToString();
				}
				else if (item.StartsWith("c"))
				{
					rowString[indexGrid] = SF_Test.SystemParameter.Para[0, 0].c.ToString();
				}
				else if (item.StartsWith("Tm"))
				{
					ch = Convert.ToInt32(item.Substring(item.Length - 1)) - 1;
					rowString[indexGrid] = SF_Test.SystemParameter.Para[0, ch].Tm.ToString();
				}
			}

			int index;
			index = dataGridView1.Rows.Add(rowString);

			// Add CheckBox
			DataGridViewCheckBoxCell cbEnableBox = new DataGridViewCheckBoxCell();
			cbEnableBox.Value = false;

			dataGridView1.Rows[index].Cells[1] = cbEnableBox;
		}
	}
}