using System;

namespace IbrahimDVLD
{
    partial class frmPersonInfo
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
            this.lblfrmAddress = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.ucPersonInfo1 = new IbrahimDVLD.ucPersonInfo();
            this.lblPersonIDValue = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();

         
            this.ucPersonInfo1 = new IbrahimDVLD.ucPersonInfo();
// 09d715aae32255d2841e0cdccf4ec6e3b86e8fe3
            this.SuspendLayout();
            // 
            // lblfrmAddress
            // 
            this.lblfrmAddress.AutoSize = true;
            this.lblfrmAddress.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfrmAddress.ForeColor = System.Drawing.Color.Red;
            this.lblfrmAddress.Location = new System.Drawing.Point(398, 9);
            this.lblfrmAddress.Name = "lblfrmAddress";
            this.lblfrmAddress.Size = new System.Drawing.Size(247, 29);
            this.lblfrmAddress.TabIndex = 2;
            this.lblfrmAddress.Text = "Person Information";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(317, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(490, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 

            // ucPersonInfo2
            
            // ucPersonInfo1
            // 
            this.ucPersonInfo1.Address = "";
            this.ucPersonInfo1.CountryID = 169;
            this.ucPersonInfo1.DateOfBirth = new System.DateTime(2008, 2, 5, 0, 0, 0, 0);
            this.ucPersonInfo1.Email = "";
            this.ucPersonInfo1.Enabled = false;
            this.ucPersonInfo1.FirstName = "";
            this.ucPersonInfo1.Gendor = ((short)(1));
            this.ucPersonInfo1.ImagePath = null;
            this.ucPersonInfo1.LastName = "";
            this.ucPersonInfo1.LinkedLabeleRemoveVisible = false;
            this.ucPersonInfo1.LinkedlabelSetImageVisible = true;

            this.ucPersonInfo1.Location = new System.Drawing.Point(-6, 26);

            this.ucPersonInfo1.Location = new System.Drawing.Point(12, 93);

            this.ucPersonInfo1.Name = "ucPersonInfo1";
            this.ucPersonInfo1.NationalNUmber = "";
            this.ucPersonInfo1.Phone = "";
            this.ucPersonInfo1.SecondName = "";

            this.ucPersonInfo1.Size = new System.Drawing.Size(874, 257);
            this.ucPersonInfo1.TabIndex = 0;
            this.ucPersonInfo1.ThirdName = "";
            // 
            // lblPersonIDValue
            // 
            this.lblPersonIDValue.AutoSize = true;
            this.lblPersonIDValue.Enabled = false;
            this.lblPersonIDValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonIDValue.Location = new System.Drawing.Point(139, 15);
            this.lblPersonIDValue.Name = "lblPersonIDValue";
            this.lblPersonIDValue.Size = new System.Drawing.Size(0, 19);
            this.lblPersonIDValue.TabIndex = 4;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Enabled = false;
            this.lblPersonID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(21, 16);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(84, 19);
            this.lblPersonID.TabIndex = 3;
            this.lblPersonID.Text = "PersonID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPersonID);
            this.groupBox1.Controls.Add(this.lblPersonIDValue);
            this.groupBox1.Controls.Add(this.ucPersonInfo1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 317);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Information";
            // 

            this.ucPersonInfo1.Size = new System.Drawing.Size(874, 345);
            this.ucPersonInfo1.TabIndex = 0;
            this.ucPersonInfo1.ThirdName = "";
            // 

            // frmPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblfrmAddress);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPersonInfo";
            this.Text = "frmPersonInfo";
            this.Load += new System.EventHandler(this.frmPersonInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblfrmAddress;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private ucPersonInfo ucPersonInfo1;
        private System.Windows.Forms.Label lblPersonIDValue;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}