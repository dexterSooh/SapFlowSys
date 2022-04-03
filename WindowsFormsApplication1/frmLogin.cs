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
using ReaLTaiizor.Forms;

namespace SapflowApplication
{
    public partial class frmLogin : MaterialForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public string ID
        {
            get
            {
                return (txbID.Text);
            }
        }

        public string Password
        {
            get
            {
                return (txbPassword.Text);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ID == "real")
            {
                if(Password=="real")
                {
                    Debug.WriteLine("118");
                }
                string passwd ="";

                bool fgPasswordMatched = true;
                if (Password.Length >= 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (Password.Substring(i, 1) != (i + 1).ToString())
                        {
                            fgPasswordMatched = false;
                        }
                    }
                }
                else
                {
                    fgPasswordMatched = false;
                }

                if (fgPasswordMatched)
                {
                    SF_Test.fgActivateFactorySetup = true;
                }
                if (Password == "address")
                {
                    Debug.WriteLine("08826");
                }

            }

            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txbID.Select();
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (txbPassword.Text != "")
                {
                    try
                    {
                        btnOK_Click(sender, e);
                    }
                    catch (Exception ex) { Debug.WriteLine(ex.Message.ToString()); }
                }
            }

        }
    }
}
