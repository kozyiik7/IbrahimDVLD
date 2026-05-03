namespace IbrahimDVLD
{
    partial class frmLicenseInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicenseInfo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucLicenseInfo1 = new IbrahimDVLD.ucLicenseInfo();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(509, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(398, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driver License Info";
            // 
            // ucLicenseInfo1
            // 
            this.ucLicenseInfo1.DateOfBirth = new System.DateTime(2026, 4, 25, 10, 27, 36, 0);
            this.ucLicenseInfo1.DriverID = 0;
            this.ucLicenseInfo1.ExpirationDate = new System.DateTime(2026, 4, 25, 10, 27, 36, 0);
            this.ucLicenseInfo1.Gendor = ((byte)(0));
            this.ucLicenseInfo1.ImagePath = "";
            this.ucLicenseInfo1.IsActive = false;
            this.ucLicenseInfo1.IsDetained = false;
            this.ucLicenseInfo1.IssueDate = new System.DateTime(2026, 5, 1, 17, 50, 11, 0);
            this.ucLicenseInfo1.IssueReason = "";
            this.ucLicenseInfo1.licenseClassName = "";
            this.ucLicenseInfo1.LicenseID = 0;
            this.ucLicenseInfo1.LocalDrivingLicenseID = -1;
            this.ucLicenseInfo1.Location = new System.Drawing.Point(17, 153);
            this.ucLicenseInfo1.Name = "ucLicenseInfo1";
            this.ucLicenseInfo1.NationalNumber = "";
            this.ucLicenseInfo1.Notes = "";
            this.ucLicenseInfo1.PersonName = "";
            this.ucLicenseInfo1.Size = new System.Drawing.Size(1078, 389);
            this.ucLicenseInfo1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::IbrahimDVLD.Properties.Resources.icons8_close_48;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(953, 555);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 41);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 608);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmLicenseInfo";
            this.Text = "License Info";
            this.Load += new System.EventHandler(this.frmLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ucLicenseInfo ucLicenseInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}