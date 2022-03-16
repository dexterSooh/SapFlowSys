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
    public partial class frmSubChannelMultiChartMinMax : Form
    {
        private frmSubChannelMultiChart parentForm;
        private int formID;
        private int formMo;

        public frmSubChannelMultiChartMinMax(frmSubChannelMultiChart parentForm, int formMo, int formID)
        {
            this.parentForm = parentForm;
            this.formMo = formMo;
            this.formID = formID;

            InitializeComponent();
        }
        
        private void frmSubChannelMultiChartMinMax_Load(object sender, EventArgs e)
        {
            int mo = formMo;
            int ch = formID;

            this.Text = String.Format("Module {0}, Channel {1}", (mo + 1).ToString(), (ch + 1).ToString()); 
        }
    }
}
