namespace APDS
{
    partial class frmIdentifyWindow
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
            this.lblMon = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblMon.Location = new System.Drawing.Point(0, 0);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(105, 17);
            this.lblMon.TabIndex = 0;
            this.lblMon.Text = "This is monitor: ";
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblClose.Location = new System.Drawing.Point(0, 44);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(43, 13);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "lblClose";
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 1000;
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // frmIdentifyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(224, 66);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMon);
            this.Name = "frmIdentifyWindow";
            this.Text = "frmIdentifyWindow";
            this.Load += new System.EventHandler(this.frmIdentifyWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Timer tmrCountdown;
    }
}