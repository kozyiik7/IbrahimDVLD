namespace IbrahimDVLD
{
    partial class ucFilterDriverLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFilterDriverLicense));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucLicenseInfo1 = new IbrahimDVLD.ucLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.txtFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(15, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(548, 82);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            this.gbFilter.Enter += new System.EventHandler(this.gbFilter_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(286, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 32);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(116, 34);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(147, 27);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "License ID :";
            // 
            // ucLicenseInfo1
            // 
            this.ucLicenseInfo1.DateOfBirth = new System.DateTime(2026, 4, 27, 20, 16, 52, 0);
            this.ucLicenseInfo1.DriverID = 0;
            this.ucLicenseInfo1.ExpirationDate = new System.DateTime(2026, 4, 27, 20, 16, 52, 0);
            this.ucLicenseInfo1.Gendor = ((byte)(0));
            this.ucLicenseInfo1.ImagePath = "";
            this.ucLicenseInfo1.IsActive = false;
            this.ucLicenseInfo1.IsDetained = false;
            this.ucLicenseInfo1.IssueDate = new System.DateTime(2026, 5, 1, 10, 57, 12, 0);
            this.ucLicenseInfo1.IssueReason = "";
            this.ucLicenseInfo1.licenseClassName = "";
            this.ucLicenseInfo1.LicenseID = 0;
            this.ucLicenseInfo1.LocalDrivingLicenseID = -1;
            this.ucLicenseInfo1.Location = new System.Drawing.Point(15, 97);
            this.ucLicenseInfo1.Name = "ucLicenseInfo1";
            this.ucLicenseInfo1.NationalNumber = "";
            this.ucLicenseInfo1.Notes = "";
            this.ucLicenseInfo1.PersonName = "";
            this.ucLicenseInfo1.Size = new System.Drawing.Size(1108, 389);
            this.ucLicenseInfo1.TabIndex = 1;
            // 
            // ucFilterDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucLicenseInfo1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ucFilterDriverLicense";
            this.Size = new System.Drawing.Size(1140, 489);
            this.Load += new System.EventHandler(this.ucFilterDriverLicense_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private ucLicenseInfo ucLicenseInfo1;
        private System.Windows.Forms.Button btnSearch;
    }
}
