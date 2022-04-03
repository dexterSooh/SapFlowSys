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
    public partial class frmAutoStart : MaterialForm
    {
        public frmAutoStart()
        {
            InitializeComponent();
        }

        private int waitTime = 10;      // wait 10 seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbWait.Text = "Wait ... " + waitTime.ToString();
            waitTime--;
            if(waitTime < 0)
            {
                btConfirm_Click(null, null);
                timer1.Enabled = false;
            }
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmAutoStart_Load(object sender, EventArgs e)
        {

        }
    }
}
