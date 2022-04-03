namespace SapflowApplication
{
    partial class frmSubChannelMultiChartMinMax
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubChannelMultiChartMinMax));
			this.button2 = new ReaLTaiizor.Controls.MaterialButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label2 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label3 = new ReaLTaiizor.Controls.MaterialLabel();
			this.label4 = new ReaLTaiizor.Controls.MaterialLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button2.Depth = 0;
			this.button2.DrawShadows = true;
			this.button2.HighEmphasis = true;
			this.button2.Icon = null;
			this.button2.Location = new System.Drawing.Point(265, 192);
			this.button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.button2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(59, 36);
			this.button2.TabIndex = 1;
			this.button2.Text = "Close";
			this.button2.TextState = ReaLTaiizor.Controls.MaterialButton.TextStateType.Normal;
			this.button2.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
			this.button2.UseAccentColor = false;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 76);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 107);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Depth = 0;
			this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.Location = new System.Drawing.Point(106, 0);
			this.label1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Min.";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Depth = 0;
			this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.Location = new System.Drawing.Point(210, 0);
			this.label2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Max.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Depth = 0;
			this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.Location = new System.Drawing.Point(3, 26);
			this.label3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "Sap Flow";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Depth = 0;
			this.label4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label4.Location = new System.Drawing.Point(3, 52);
			this.label4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 19);
			this.label4.TabIndex = 3;
			this.label4.Text = "R. Temp.";
			// 
			// frmSubChannelMultiChartMinMax
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 235);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.button2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmSubChannelMultiChartMinMax";
			this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
			this.Text = "frmSubChannelMultiChartMinMax";
			this.Load += new System.EventHandler(this.frmSubChannelMultiChartMinMax_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialButton button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ReaLTaiizor.Controls.MaterialLabel label1;
        private ReaLTaiizor.Controls.MaterialLabel label2;
        private ReaLTaiizor.Controls.MaterialLabel label3;
        private ReaLTaiizor.Controls.MaterialLabel label4;
    }
}