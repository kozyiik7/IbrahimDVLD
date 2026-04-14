namespace IbrahimDVLD
{
    partial class ucApplicationAllInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucApplicationBasicInfo1 = new IbrahimDVLD.ucApplicationBasicInfo();
            this.ucDrivingLicenseApplicationInfo1 = new IbrahimDVLD.ucDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // ucApplicationBasicInfo1
            // 
            this.ucApplicationBasicInfo1.ApplicantName = "Applicant :";
            this.ucApplicationBasicInfo1.ApplicationDate = new System.DateTime(2026, 4, 12, 17, 22, 18, 963);
            this.ucApplicationBasicInfo1.CreatedBy = "Created By :";
            this.ucApplicationBasicInfo1.Location = new System.Drawing.Point(3, 123);
            this.ucApplicationBasicInfo1.Name = "ucApplicationBasicInfo1";
            this.ucApplicationBasicInfo1.PersonID = 0;
            this.ucApplicationBasicInfo1.Size = new System.Drawing.Size(949, 226);
            this.ucApplicationBasicInfo1.Status = "Status :";
            this.ucApplicationBasicInfo1.StatusDate = new System.DateTime(2026, 4, 12, 17, 22, 18, 953);
            this.ucApplicationBasicInfo1.TabIndex = 1;
            this.ucApplicationBasicInfo1.Type = "Type :";
            // 
            // ucDrivingLicenseApplicationInfo1
            // 
            this.ucDrivingLicenseApplicationInfo1.AppliedForLicense = "Applied For license :";
            this.ucDrivingLicenseApplicationInfo1.LicenseInfo = "ShowLicesneInfo";
            this.ucDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucDrivingLicenseApplicationInfo1.Name = "ucDrivingLicenseApplicationInfo1";
            this.ucDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(952, 117);
            this.ucDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // ucApplicationAllInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.ucApplicationBasicInfo1);
            this.Name = "ucApplicationAllInfo";
            this.Size = new System.Drawing.Size(949, 388);
            this.Load += new System.EventHandler(this.ucApplicationAllInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucApplicationBasicInfo ucApplicationBasicInfo1;
        private ucDrivingLicenseApplicationInfo ucDrivingLicenseApplicationInfo1;
    }
}
