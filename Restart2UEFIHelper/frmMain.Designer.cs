namespace Restart2UEFIHelper
{
    partial class frmMain
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
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFirmware
            // 
            this.txtFirmware.Location = new System.Drawing.Point(12, 12);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.Size = new System.Drawing.Size(126, 20);
            this.txtFirmware.TabIndex = 0;
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(12, 47);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(126, 20);
            this.txtArgs.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 84);
            this.Controls.Add(this.txtArgs);
            this.Controls.Add(this.txtFirmware);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Restart2FirmwareHelper";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirmware;
        private System.Windows.Forms.TextBox txtArgs;
    }
}

