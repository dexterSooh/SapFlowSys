using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SapflowApplication
{
    public partial class NewForm2_Demo : MaterialForm
    {
        private readonly MaterialManager materialManager;

        public NewForm2_Demo()
        {
            InitializeComponent();

            // Initialize MaterialManager
            materialManager = MaterialManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialManager.EnforceBackcolorOnAllComponents = true;

            // MaterialManager properties
            materialManager.AddFormToManage(this);
            materialManager.Theme = MaterialManager.Themes.LIGHT;
            materialManager.ColorScheme = new MaterialColorScheme(MaterialPrimary.Indigo500, MaterialPrimary.Indigo700, MaterialPrimary.Indigo100, MaterialAccent.Pink200, MaterialTextShade.WHITE);

            // Add dummy data to the listview
        }
    }
}