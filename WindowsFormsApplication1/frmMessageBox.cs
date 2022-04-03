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
    public partial class frmMessageBox : MaterialForm
    {
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

        private string strMessage;
        public frmMessageBox(string mesg)
        {
            strMessage = mesg;
            InitializeComponent();
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            lbMessage.Text = strMessage;
            if(strMessage.Length > 100)
            {
                this.Width = this.Width * 2;
            }
            else if(strMessage.Length > 200)
            {
                this.Width = this.Width * 3;
            }

            btConfirm.Text = "Confirm(" + waitTime.ToString() + ")";
            // Auto Closing Function
        //    for (int i = 5; i > 0; i--)
            {
         //       this.Text ="Warning: auto-closing(" + i.ToString() + "s)";
       //         Delay(1000);
            }
         //   this.Close();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int waitTime = 5;      // wait 10 seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            waitTime--;

            btConfirm.Text = "Confirm(" + waitTime.ToString()+")";
            if (waitTime < 0)
            {
                btConfirm_Click(null, null);
                timer1.Enabled = false;
            }


        }

    }
}
