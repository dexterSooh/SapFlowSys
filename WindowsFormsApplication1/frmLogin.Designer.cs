namespace SapflowApplication
{
    partial class frmLogin
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
			this.btnOK = new ReaLTaiizor.Controls.MaterialButton();
			this.btnCancel = new ReaLTaiizor.Controls.MaterialButton();
			this.label3 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label2 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label1 = new ReaLTaiizor.Controls.MaterialLabel();
			this.txbPassword = new ReaLTaiizor.Controls.MaterialTextBox();
			this.txbID = new ReaLTaiizor.Controls.MaterialTextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.AutoSize = false;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.Depth = 0;
			this.btnOK.DrawShadows = true;
			this.btnOK.HighEmphasis = true;
			this.btnOK.Icon = null;
			this.btnOK.Location = new System.Drawing.Point(237, 259);
			this.btnOK.Margin = new System.Windows.Forms.Padding(2);
			this.btnOK.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(67, 36);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btnOK.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btnOK.UseAccentColor = false;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = false;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.Depth = 0;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.DrawShadows = true;
			this.btnCancel.HighEmphasis = true;
			this.btnCancel.Icon = null;
			this.btnCancel.Location = new System.Drawing.Point(145, 259);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
			this.btnCancel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(67, 36);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.btnCancel.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.btnCancel.UseAccentColor = false;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Depth = 0;
			this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.Location = new System.Drawing.Point(151, 198);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "PW";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Depth = 0;
			this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.Location = new System.Drawing.Point(158, 144);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 19);
			this.label2.TabIndex = 5;
			this.label2.Text = "ID";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Depth = 0;
			this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.Location = new System.Drawing.Point(189, 91);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Real login";
			// 
			// txbPassword
			// 
			this.txbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txbPassword.Depth = 0;
			this.txbPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.txbPassword.Location = new System.Drawing.Point(184, 189);
			this.txbPassword.Margin = new System.Windows.Forms.Padding(2);
			this.txbPassword.MaxLength = 50;
			this.txbPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.txbPassword.Multiline = false;
			this.txbPassword.Name = "txbPassword";
			this.txbPassword.Password = true;
			this.txbPassword.Size = new System.Drawing.Size(122, 36);
			this.txbPassword.TabIndex = 1;
			this.txbPassword.Text = "";
			this.txbPassword.UseTallSize = false;
			this.txbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPassword_KeyPress);
			// 
			// txbID
			// 
			this.txbID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txbID.Depth = 0;
			this.txbID.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.txbID.Location = new System.Drawing.Point(184, 131);
			this.txbID.Margin = new System.Windows.Forms.Padding(2);
			this.txbID.MaxLength = 50;
			this.txbID.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
			this.txbID.Multiline = false;
			this.txbID.Name = "txbID";
			this.txbID.Password = true;
			this.txbID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txbID.Size = new System.Drawing.Size(122, 36);
			this.txbID.TabIndex = 0;
			this.txbID.Text = "";
			this.txbID.UseTallSize = false;
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 319);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txbPassword);
			this.Controls.Add(this.txbID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialButton btnOK;
        private ReaLTaiizor.Controls.MaterialButton btnCancel;
        private ReaLTaiizor.Controls.MaterialTextBox txbPassword;
        private ReaLTaiizor.Controls.MaterialTextBox txbID;
        private ReaLTaiizor.Controls.MaterialLabel label3;
        private ReaLTaiizor.Controls.MaterialLabel label2;
        private ReaLTaiizor.Controls.MaterialLabel label1;
    }
}