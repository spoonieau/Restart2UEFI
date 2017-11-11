namespace Restart2UEFI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnAbout = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnFirmware = new System.Windows.Forms.Button();
            this.btnFirmwareRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Location = new System.Drawing.Point(12, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(30, 30);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "?";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(49, 12);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(318, 29);
            this.txtStatus.TabIndex = 3;
            // 
            // btnFirmware
            // 
            this.btnFirmware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirmware.Image = global::Restart2UEFI.Properties.Resources.ICicon128;
            this.btnFirmware.Location = new System.Drawing.Point(12, 49);
            this.btnFirmware.Name = "btnFirmware";
            this.btnFirmware.Size = new System.Drawing.Size(170, 170);
            this.btnFirmware.TabIndex = 4;
            this.btnFirmware.Text = "Set Boot To Firmware Falg and Shutdown";
            this.btnFirmware.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFirmware.UseVisualStyleBackColor = true;
            this.btnFirmware.Click += new System.EventHandler(this.btnFirmware_Click);
            // 
            // btnFirmwareRestart
            // 
            this.btnFirmwareRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirmwareRestart.Image = global::Restart2UEFI.Properties.Resources.ICiconRestart128;
            this.btnFirmwareRestart.Location = new System.Drawing.Point(197, 49);
            this.btnFirmwareRestart.Name = "btnFirmwareRestart";
            this.btnFirmwareRestart.Size = new System.Drawing.Size(170, 170);
            this.btnFirmwareRestart.TabIndex = 5;
            this.btnFirmwareRestart.Text = "Set Boot to Frimware Falg and Restart ";
            this.btnFirmwareRestart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFirmwareRestart.UseVisualStyleBackColor = true;
            this.btnFirmwareRestart.Click += new System.EventHandler(this.btnFirmwareRestart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 231);
            this.Controls.Add(this.btnFirmwareRestart);
            this.Controls.Add(this.btnFirmware);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnFirmware;
        private System.Windows.Forms.Button btnFirmwareRestart;
    }
}

