namespace IbrahimDVLD
{
    partial class frmNewInternationalLicenseApplication
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
            this.ucFilterDriverLicense1 = new IbrahimDVLD.ucFilterDriverLicense();
            this.label1 = new System.Windows.Forms.Label();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucFilterDriverLicense1
            // 
            this.ucFilterDriverLicense1.Location = new System.Drawing.Point(12, 63);
            this.ucFilterDriverLicense1.Name = "ucFilterDriverLicense1";
            this.ucFilterDriverLicense1.Size = new System.Drawing.Size(1105, 491);
            this.ucFilterDriverLicense1.TabIndex = 0;
            this.ucFilterDriverLicense1.Load += new System.EventHandler(this.ucFilterDriverLicense1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(329, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License Application";
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.label6);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Controls.Add(this.label8);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.label5);
            this.gbApplicationInfo.Controls.Add(this.label4);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(29, 560);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(1075, 326);
            this.gbApplicationInfo.TabIndex = 2;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "Application Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "I.L.Application ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Issue Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fees :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Created By :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Expiration Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Local license ID :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(460, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "I.L.License ID :";
            // 
            // frmNewInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 931);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucFilterDriverLicense1);
            this.Name = "frmNewInternationalLicenseApplication";
            this.Text = "frmNewInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmNewInternationalLicenseApplication_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucFilterDriverLicense ucFilterDriverLicense1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}