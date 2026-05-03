namespace IbrahimDVLD
{
    partial class frmReplaceForDamage_LostLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplaceForDamage_LostLicense));
            this.lblMainAddress = new System.Windows.Forms.Label();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.gbApplicationInfoForLicenseReplacement = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblLRApplicationID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLR = new System.Windows.Forms.Label();
            this.llShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucFilterDriverLicense1 = new IbrahimDVLD.ucFilterDriverLicense();
            this.gbReplacementFor.SuspendLayout();
            this.gbApplicationInfoForLicenseReplacement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMainAddress
            // 
            this.lblMainAddress.AutoSize = true;
            this.lblMainAddress.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainAddress.ForeColor = System.Drawing.Color.Red;
            this.lblMainAddress.Location = new System.Drawing.Point(267, 23);
            this.lblMainAddress.Name = "lblMainAddress";
            this.lblMainAddress.Size = new System.Drawing.Size(488, 39);
            this.lblMainAddress.TabIndex = 0;
            this.lblMainAddress.Text = "Replace for Damaged License";
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbDamaged);
            this.gbReplacementFor.Controls.Add(this.rbLost);
            this.gbReplacementFor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementFor.Location = new System.Drawing.Point(745, 65);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(227, 93);
            this.gbReplacementFor.TabIndex = 2;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Location = new System.Drawing.Point(18, 26);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(104, 23);
            this.rbDamaged.TabIndex = 1;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Tag = "3";
            this.rbDamaged.Text = "Dameged";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(18, 60);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(61, 23);
            this.rbLost.TabIndex = 0;
            this.rbLost.TabStop = true;
            this.rbLost.Tag = "4";
            this.rbLost.Text = "Lost";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // gbApplicationInfoForLicenseReplacement
            // 
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.lblReplacedLicenseID);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.lblLRApplicationID);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.pictureBox3);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.pictureBox9);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.pictureBox6);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.pictureBox2);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.pictureBox7);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.pictureBox1);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.label3);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.label4);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.label5);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.label2);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.label1);
            this.gbApplicationInfoForLicenseReplacement.Controls.Add(this.labelLR);
            this.gbApplicationInfoForLicenseReplacement.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfoForLicenseReplacement.Location = new System.Drawing.Point(29, 535);
            this.gbApplicationInfoForLicenseReplacement.Name = "gbApplicationInfoForLicenseReplacement";
            this.gbApplicationInfoForLicenseReplacement.Size = new System.Drawing.Size(1073, 190);
            this.gbApplicationInfoForLicenseReplacement.TabIndex = 3;
            this.gbApplicationInfoForLicenseReplacement.TabStop = false;
            this.gbApplicationInfoForLicenseReplacement.Text = "Application Info For license Replacement";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(712, 126);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(70, 19);
            this.lblCreatedBy.TabIndex = 47;
            this.lblCreatedBy.Text = "[ ? ? ? ]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(712, 81);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(70, 19);
            this.lblOldLicenseID.TabIndex = 46;
            this.lblOldLicenseID.Text = "[ ? ? ? ]";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(712, 36);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(70, 19);
            this.lblReplacedLicenseID.TabIndex = 45;
            this.lblReplacedLicenseID.Text = "[ ? ? ? ]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(241, 126);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(70, 19);
            this.lblApplicationFees.TabIndex = 44;
            this.lblApplicationFees.Text = "[ ? ? ? ]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(241, 81);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(70, 19);
            this.lblApplicationDate.TabIndex = 43;
            this.lblApplicationDate.Text = "[ ? ? ? ]";
            // 
            // lblLRApplicationID
            // 
            this.lblLRApplicationID.AutoSize = true;
            this.lblLRApplicationID.Location = new System.Drawing.Point(241, 36);
            this.lblLRApplicationID.Name = "lblLRApplicationID";
            this.lblLRApplicationID.Size = new System.Drawing.Size(70, 19);
            this.lblLRApplicationID.TabIndex = 42;
            this.lblLRApplicationID.Text = "[ ? ? ? ]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(184, 115);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 30);
            this.pictureBox3.TabIndex = 41;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(184, 25);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(34, 30);
            this.pictureBox9.TabIndex = 40;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(184, 70);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(34, 30);
            this.pictureBox6.TabIndex = 39;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(655, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(655, 25);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(34, 30);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 37;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(655, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 30);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Created By :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Old License ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Replaced License ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Application Fees :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "ApplicationDate :";
            // 
            // labelLR
            // 
            this.labelLR.AutoSize = true;
            this.labelLR.Location = new System.Drawing.Point(6, 36);
            this.labelLR.Name = "labelLR";
            this.labelLR.Size = new System.Drawing.Size(167, 19);
            this.labelLR.TabIndex = 0;
            this.labelLR.Text = "L.R.Application ID :";
            // 
            // llShowNewLicenseInfo
            // 
            this.llShowNewLicenseInfo.AutoSize = true;
            this.llShowNewLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicenseInfo.Location = new System.Drawing.Point(241, 742);
            this.llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            this.llShowNewLicenseInfo.Size = new System.Drawing.Size(205, 19);
            this.llShowNewLicenseInfo.TabIndex = 26;
            this.llShowNewLicenseInfo.TabStop = true;
            this.llShowNewLicenseInfo.Text = "Show New Licenses Info";
            this.llShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicenseInfo_LinkClicked);
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(29, 742);
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.Size = new System.Drawing.Size(189, 19);
            this.llShowLicensesHistory.TabIndex = 25;
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = ((System.Drawing.Image)(resources.GetObject("btnIssueReplacement.Image")));
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(871, 731);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(231, 39);
            this.btnIssueReplacement.TabIndex = 24;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::IbrahimDVLD.Properties.Resources.icons8_close_48;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(676, 731);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 39);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucFilterDriverLicense1
            // 
            this.ucFilterDriverLicense1.Location = new System.Drawing.Point(12, 65);
            this.ucFilterDriverLicense1.Name = "ucFilterDriverLicense1";
            this.ucFilterDriverLicense1.Size = new System.Drawing.Size(1097, 446);
            this.ucFilterDriverLicense1.TabIndex = 1;
            // 
            // frmReplaceForDamage_LostLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 781);
            this.Controls.Add(this.llShowNewLicenseInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbApplicationInfoForLicenseReplacement);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.ucFilterDriverLicense1);
            this.Controls.Add(this.lblMainAddress);
            this.Name = "frmReplaceForDamage_LostLicense";
            this.Text = "Replace For Damage License";
            this.Load += new System.EventHandler(this.frmReplaceForDamage_LostLicense_Load);
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.gbApplicationInfoForLicenseReplacement.ResumeLayout(false);
            this.gbApplicationInfoForLicenseReplacement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainAddress;
        private ucFilterDriverLicense ucFilterDriverLicense1;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbDamaged;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.GroupBox gbApplicationInfoForLicenseReplacement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLR;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblLRApplicationID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.Button btnClose;
    }
}