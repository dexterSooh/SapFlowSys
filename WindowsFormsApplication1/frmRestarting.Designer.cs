namespace SapflowApplication
{
    partial class frmRestarting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestarting));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbMessage = new ReaLTaiizor.Controls.MaterialLabel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Ivory;
			this.panel1.Controls.Add(this.lbMessage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(278, 99);
			this.panel1.TabIndex = 0;
			// 
			// lbMessage
			// 
			this.lbMessage.Depth = 0;
			this.lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbMessage.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lbMessage.FontType = ReaLTaiizor.Util.MaterialManager.FontType.H5;
			this.lbMessage.Location = new System.Drawing.Point(0, 0);
			this.lbMessage.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.lbMessage.Name = "lbMessage";
			this.lbMessage.Size = new System.Drawing.Size(278, 99);
			this.lbMessage.TabIndex = 0;
			this.lbMessage.Text = "Auto Restarting...";
			this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmRestarting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 166);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRestarting";
			this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
			this.Text = "SF_Test Restarting";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRestarting_FormClosing);
			this.Load += new System.EventHandler(this.frmRestarting_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.MaterialLabel lbMessage;
        private System.Windows.Forms.Timer timer1;
    }
}