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
            this.tabUser = new System.Windows.Forms.TabControl();
            this.tabPersonInfo = new System.Windows.Forms.TabPage();
            this.tabLoginInfo = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ucFilter1 = new IbrahimDVLD.ucFilter();
            this.ucPersonInfoShow1 = new IbrahimDVLD.ucPersonInfoShow();
            this.tabUser.SuspendLayout();
            this.tabPersonInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tabPersonInfo);
            this.tabUser.Controls.Add(this.tabLoginInfo);
            this.tabUser.Location = new System.Drawing.Point(29, 61);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(1047, 438);
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
            this.tabPersonInfo.Size = new System.Drawing.Size(1039, 412);
            this.tabPersonInfo.TabIndex = 0;
            this.tabPersonInfo.Text = "Person Info";
            this.tabPersonInfo.UseVisualStyleBackColor = true;
            // 
            // tabLoginInfo
            // 
            this.tabLoginInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tabLoginInfo.Name = "tabLoginInfo";
            this.tabLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoginInfo.Size = new System.Drawing.Size(751, 324);
            this.tabLoginInfo.TabIndex = 1;
            this.tabLoginInfo.Text = "Login Info";
            this.tabLoginInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(309, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New User";
            // 
            // ucFilter1
            // 
            this.ucFilter1.Location = new System.Drawing.Point(7, 18);
            this.ucFilter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(997, 71);
            this.ucFilter1.TabIndex = 0;
            // 
            // ucPersonInfoShow1
            // 
            this.ucPersonInfoShow1.Gendor = "???";
            this.ucPersonInfoShow1.imagePath = null;
            this.ucPersonInfoShow1.Location = new System.Drawing.Point(7, 107);
            this.ucPersonInfoShow1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucPersonInfoShow1.Name = "ucPersonInfoShow1";
            this.ucPersonInfoShow1.Size = new System.Drawing.Size(1035, 297);
            this.ucPersonInfoShow1.TabIndex = 1;
            // 
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabUser);
            this.Name = "frmAddNewUser";
            this.Text = "Add New User";
            this.tabUser.ResumeLayout(false);
            this.tabPersonInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabUser;
        private System.Windows.Forms.TabPage tabPersonInfo;
        private System.Windows.Forms.TabPage tabLoginInfo;
        private System.Windows.Forms.Label label1;
        private ucFilter ucFilter1;
        private ucPersonInfoShow ucPersonInfoShow1;
    }
}