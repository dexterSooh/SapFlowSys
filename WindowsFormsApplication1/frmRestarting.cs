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
    public partial class frmRestarting : MaterialForm
    {
        public frmRestarting()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == 1)
            {
                lbMessage.ForeColor = Color.Ivory;
                lbMessage.BackColor = Color.Green;
                count = 0;
            }
            else
            {
                lbMessage.ForeColor = Color.DarkRed;
                lbMessage.BackColor = Color.Ivory;
                count = 1;
            }
        }

        private int count = 1;

        private void frmRestarting_Load(object sender, EventArgs e)
        {
            this.Icon = SapflowApplication.Properties.Resources.logo_real;
            SF_Test.SystemParameter.RestartingOn = true;
            count = 1;
        }

        private void frmRestarting_FormClosing(object sender, FormClosingEventArgs e)
        {
            SF_Test.SystemParameter.RestartingOn = false;
        }
    }
}
