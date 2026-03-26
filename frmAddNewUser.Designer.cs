namespace IbrahimDVLD
{
    partial class frmAddNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewUser));
            this.tabUser = new System.Windows.Forms.TabControl();
            this.tabPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabLoginInfo = new System.Windows.Forms.TabPage();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblUserIDValue = new System.Windows.Forms.Label();
            this.txtConfirmPasword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblFormAddress = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProviderAddNewUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucPersonInfoShow1 = new IbrahimDVLD.ucPersonInfoShow();
            this.ucFilter1 = new IbrahimDVLD.ucFilter();
            this.tabUser.SuspendLayout();
            this.tabPersonInfo.SuspendLayout();
            this.tabLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddNewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tabPersonInfo);
            this.tabUser.Controls.Add(this.tabLoginInfo);
            this.tabUser.Location = new System.Drawing.Point(29, 61);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(1194, 445);
            this.tabUser.TabIndex = 0;
            // 
            // tabPersonInfo
            // 
            this.tabPersonInfo.Controls.Add(this.ucPersonInfoShow1);
            this.tabPersonInfo.Controls.Add(this.ucFilter1);
            this.tabPersonInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonInfo.Name = "tabPersonInfo";
            this.tabPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonInfo.Size = new System.Drawing.Size(1186, 419);
            this.tabPersonInfo.TabIndex = 0;
            this.tabPersonInfo.Text = "Person Info";
            this.tabPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(1041, 507);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(172, 42);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabLoginInfo
            // 
            this.tabLoginInfo.Controls.Add(this.chkIsActive);
            this.tabLoginInfo.Controls.Add(this.lblUserIDValue);
            this.tabLoginInfo.Controls.Add(this.txtConfirmPasword);
            this.tabLoginInfo.Controls.Add(this.txtPassword);
            this.tabLoginInfo.Controls.Add(this.txtUserName);
            this.tabLoginInfo.Controls.Add(this.pictureBox4);
            this.tabLoginInfo.Controls.Add(this.pictureBox3);
            this.tabLoginInfo.Controls.Add(this.pictureBox2);
            this.tabLoginInfo.Controls.Add(this.pictureBox1);
            this.tabLoginInfo.Controls.Add(this.lblConfirmPassword);
            this.tabLoginInfo.Controls.Add(this.lblPassword);
            this.tabLoginInfo.Controls.Add(this.lblUserName);
            this.tabLoginInfo.Controls.Add(this.lblUserID);
            this.tabLoginInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tabLoginInfo.Name = "tabLoginInfo";
            this.tabLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoginInfo.Size = new System.Drawing.Size(1186, 462);
            this.tabLoginInfo.TabIndex = 1;
            this.tabLoginInfo.Text = "Login Info";
            this.tabLoginInfo.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(240, 199);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(99, 23);
            this.chkIsActive.TabIndex = 52;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblUserIDValue
            // 
            this.lblUserIDValue.AutoSize = true;
            this.lblUserIDValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIDValue.Location = new System.Drawing.Point(240, 48);
            this.lblUserIDValue.Name = "lblUserIDValue";
            this.lblUserIDValue.Size = new System.Drawing.Size(36, 19);
            this.lblUserIDValue.TabIndex = 51;
            this.lblUserIDValue.Text = "???";
            // 
            // txtConfirmPasword
            // 
            this.txtConfirmPasword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPasword.Location = new System.Drawing.Point(240, 147);
            this.txtConfirmPasword.Name = "txtConfirmPasword";
            this.txtConfirmPasword.PasswordChar = '*';
            this.txtConfirmPasword.Size = new System.Drawing.Size(148, 27);
            this.txtConfirmPasword.TabIndex = 50;
            this.txtConfirmPasword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPasword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(240, 114);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(148, 27);
            this.txtPassword.TabIndex = 49;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(240, 77);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(148, 27);
            this.txtUserName.TabIndex = 48;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(200, 40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 27);
            this.pictureBox4.TabIndex = 47;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(200, 147);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 27);
            this.pictureBox3.TabIndex = 46;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(200, 114);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 27);
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(202, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.BackColor = System.Drawing.SystemColors.Window;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(24, 147);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(170, 19);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm Passwoed :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.SystemColors.Window;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(96, 114);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(98, 19);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.SystemColors.Window;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(85, 81);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(109, 19);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name :";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.BackColor = System.Drawing.SystemColors.Window;
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(118, 48);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(76, 19);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "UserID :";
            // 
            // lblFormAddress
            // 
            this.lblFormAddress.AutoSize = true;
            this.lblFormAddress.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormAddress.ForeColor = System.Drawing.Color.Red;
            this.lblFormAddress.Location = new System.Drawing.Point(501, 29);
            this.lblFormAddress.Name = "lblFormAddress";
            this.lblFormAddress.Size = new System.Drawing.Size(181, 29);
            this.lblFormAddress.TabIndex = 1;
            this.lblFormAddress.Text = "Add New User";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::IbrahimDVLD.Properties.Resources.icons8_close_48;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(828, 555);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 39);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::IbrahimDVLD.Properties.Resources.icons8_save_48;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1041, 555);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 39);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProviderAddNewUser
            // 
            this.errorProviderAddNewUser.ContainerControl = this;
            // 
            // ucPersonInfoShow1
            // 
            this.ucPersonInfoShow1.Gendor = "???";
            this.ucPersonInfoShow1.imagePath = null;
            this.ucPersonInfoShow1.Location = new System.Drawing.Point(7, 107);
            this.ucPersonInfoShow1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPersonInfoShow1.Name = "ucPersonInfoShow1";
            this.ucPersonInfoShow1.PersonIDValue = 0;
            this.ucPersonInfoShow1.Size = new System.Drawing.Size(1154, 297);
            this.ucPersonInfoShow1.TabIndex = 1;
            // 
            // ucFilter1
            // 
            this.ucFilter1.Location = new System.Drawing.Point(7, 18);
            this.ucFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(997, 71);
            this.ucFilter1.TabIndex = 0;
            this.ucFilter1.TextValue = "";
            // 
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 597);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFormAddress);
            this.Controls.Add(this.tabUser);
            this.Name = "frmAddNewUser";
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmAddNewUser_Load);
            this.tabUser.ResumeLayout(false);
            this.tabPersonInfo.ResumeLayout(false);
            this.tabLoginInfo.ResumeLayout(false);
            this.tabLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddNewUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabUser;
        private System.Windows.Forms.TabPage tabPersonInfo;
        private System.Windows.Forms.TabPage tabLoginInfo;
        private System.Windows.Forms.Label lblFormAddress;
        private ucFilter ucFilter1;
        private ucPersonInfoShow ucPersonInfoShow1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUserIDValue;
        private System.Windows.Forms.TextBox txtConfirmPasword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProviderAddNewUser;
    }
}