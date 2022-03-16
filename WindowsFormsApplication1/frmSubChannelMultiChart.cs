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
    public partial class frmSubChannelMultiChart : Form
    {
        private frmSfMultiModules parentForm;
        private int formID;
        private int formMo;

        public frmSubChannelMultiChart(frmSfMultiModules parentForm, int formMo, int formID)
        {
            this.parentForm = parentForm;
            this.formMo = formMo;
            this.formID = formID;

            InitializeComponent();
        }

        private void frmSubChannelMultiChart_Load(object sender, EventArgs e)
        {

        }

#if false
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int mo = formMo;
                int ch = formID;

                String strText = String.Format("Module {0}, Channel {1}", (mo + 1).ToString(), (ch + 1).ToString());
                EventHandler eh = new EventHandler(MenuClick);
                
                MenuItem[] ami = {
                    new MenuItem(strText,eh),
                    new MenuItem("Min/Max Setting",eh),
                    };
                ContextMenu = new System.Windows.Forms.ContextMenu(ami);
            }
        }

        void MenuClick(object obj, EventArgs ea)
        {
            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;

            if (str == "Min/Max Setting")
            {

            }
            
        }
#endif
    }
}
