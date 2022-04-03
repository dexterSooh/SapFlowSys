namespace SapflowApplication
{
    partial class frmMessageBox
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBox));
			this.lbMessage = new ReaLTaiizor.Controls.MaterialLabel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btConfirm = new ReaLTaiizor.Controls.MaterialButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbMessage
			// 
			this.lbMessage.Depth = 0;
			this.lbMessage.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbMessage.Location = new System.Drawing.Point(3, 0);
			this.lbMessage.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.lbMessage.Name = "lbMessage";
			this.lbMessage.Size = new System.Drawing.Size(292, 19);
			this.lbMessage.TabIndex = 0;
			this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.btConfirm, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lbMessage, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 241);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// btConfirm
			// 
			this.btConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btConfirm.Depth = 0;
			this.btConfirm.DrawShadows = true;
			this.btConfirm.HighEmphasis = true;
			this.btConfirm.Icon = null;
			this.btConfirm.Location = new System.Drawing.Point(111, 198);
			this.btConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btConfirm.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.btConfirm.Name = "btConfirm";
			this.btConfirm.Size = new System.Drawing.Size(75, 36);
			this.btConfirm.TabIndex = 1;
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
			// frmMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(304, 308);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMessageBox";
			this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Warning";
			this.Load += new System.EventHandler(this.frmMessageBox_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialLabel lbMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialButton btConfirm;
        private System.Windows.Forms.Timer timer1;
    }
}