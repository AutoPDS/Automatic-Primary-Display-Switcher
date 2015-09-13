namespace APDS
{
    partial class frmGrabTitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrabTitle));
            this.btnWinListRefresh = new System.Windows.Forms.Button();
            this.btnWinListOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listWinTitles = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnWinListRefresh
            // 
            this.btnWinListRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnWinListRefresh.Location = new System.Drawing.Point(225, 7);
            this.btnWinListRefresh.Name = "btnWinListRefresh";
            this.btnWinListRefresh.Size = new System.Drawing.Size(73, 23);
            this.btnWinListRefresh.TabIndex = 1;
            this.btnWinListRefresh.Text = "Refresh";
            this.btnWinListRefresh.UseVisualStyleBackColor = true;
            this.btnWinListRefresh.Click += new System.EventHandler(this.btnWinListRefresh_Click);
            // 
            // btnWinListOK
            // 
            this.btnWinListOK.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnWinListOK.Location = new System.Drawing.Point(133, 420);
            this.btnWinListOK.Name = "btnWinListOK";
            this.btnWinListOK.Size = new System.Drawing.Size(75, 23);
            this.btnWinListOK.TabIndex = 2;
            this.btnWinListOK.Text = "OK";
            this.btnWinListOK.UseVisualStyleBackColor = true;
            this.btnWinListOK.Click += new System.EventHandler(this.btnWinListOK_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button1.Location = new System.Drawing.Point(225, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listWinTitles
            // 
            this.listWinTitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1});
            this.listWinTitles.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listWinTitles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listWinTitles.Location = new System.Drawing.Point(0, 36);
            this.listWinTitles.Name = "listWinTitles";
            this.listWinTitles.Size = new System.Drawing.Size(310, 380);
            this.listWinTitles.TabIndex = 4;
            this.listWinTitles.UseCompatibleStateImageBehavior = false;
            this.listWinTitles.View = System.Windows.Forms.View.Details;
            // 
            // column1
            // 
            this.column1.Text = "  ";
            this.column1.Width = 29;
            // 
            // frmGrabTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 446);
            this.Controls.Add(this.listWinTitles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWinListOK);
            this.Controls.Add(this.btnWinListRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGrabTitle";
            this.Text = "Grab title from window";
            this.Load += new System.EventHandler(this.frmGrabTitle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWinListRefresh;
        private System.Windows.Forms.Button btnWinListOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listWinTitles;
        private System.Windows.Forms.ColumnHeader column1;
    }
}