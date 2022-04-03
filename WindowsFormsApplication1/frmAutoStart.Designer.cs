namespace SapflowApplication
{
    partial class frmAutoStart
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoStart));
			this.label1 = new ReaLTaiizor.Controls.MaterialLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new ReaLTaiizor.Controls.MaterialLabel();
			this.btCancel = new ReaLTaiizor.Controls.MaterialButton();
			this.lbWait = new ReaLTaiizor.Controls.MaterialLabel();
			this.btConfirm = new ReaLTaiizor.Controls.MaterialButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label3 = new ReaLTaiizor.Controls.MaterialLabel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Yellow;
			this.label1.Depth = 0;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(371, 54);
			this.label1.TabIndex = 0;
			this.label1.Text = "WARNING";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(15, 75);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(371, 54);
			this.panel1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Depth = 0;
			this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.Location = new System.Drawing.Point(15, 136);
			this.label2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(371, 29);
			this.label2.TabIndex = 2;
			this.label2.Text = "Program will be started automatically...";
			// 
			// btCancel
			// 
			this.btCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btCancel.Depth = 0;
			this.btCancel.DrawShadows = true;
			this.btCancel.HighEmphasis = true;
			this.btCancel.Icon = null;
			this.btCancel.Location = new System.Drawing.Point(311, 247);
			this.btCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btCancel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(67, 36);
			this.btCancel.TabIndex = 3;
			this.btCancel.Text = "Cancel";
			this.btCancel.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btCancel.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btCancel.UseAccentColor = false;
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// lbWait
			// 
			this.lbWait.Depth = 0;
			this.lbWait.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbWait.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lbWait.Location = new System.Drawing.Point(15, 164);
			this.lbWait.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.lbWait.Name = "lbWait";
			this.lbWait.Size = new System.Drawing.Size(371, 29);
			this.lbWait.TabIndex = 2;
			this.lbWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btConfirm
			// 
			this.btConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btConfirm.Depth = 0;
			this.btConfirm.DrawShadows = true;
			this.btConfirm.HighEmphasis = true;
			this.btConfirm.Icon = null;
			this.btConfirm.Location = new System.Drawing.Point(230, 247);
			this.btConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btConfirm.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btConfirm.Name = "btConfirm";
			this.btConfirm.Size = new System.Drawing.Size(75, 36);
			this.btConfirm.TabIndex = 3;
			this.btConfirm.Text = "Confirm";
			this.btConfirm.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btConfirm.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btConfirm.UseAccentColor = false;
			this.btConfirm.UseVisualStyleBackColor = true;
			this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label3
			// 
			this.label3.Depth = 0;
			this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label3.Location = new System.Drawing.Point(15, 201);
			this.label3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(371, 44);
			this.label3.TabIndex = 2;
			this.label3.Text = "If you want to disable this fuction, Uncheck [Auto start with Windows].";
			// 
			// frmAutoStart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 297);
			this.Controls.Add(this.btConfirm);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.lbWait);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAutoStart";
			this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
			this.Text = "WARNING - Auto Start";
			this.Load += new System.EventHandler(this.frmAutoStart_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialLabel label1;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.MaterialLabel label2;
        private ReaLTaiizor.Controls.MaterialButton btCancel;
        private ReaLTaiizor.Controls.MaterialLabel lbWait;
        private ReaLTaiizor.Controls.MaterialButton btConfirm;
        private System.Windows.Forms.Timer timer1;
        private ReaLTaiizor.Controls.MaterialLabel label3;
    }
}