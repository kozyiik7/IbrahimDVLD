namespace IbrahimDVLD
{
    partial class frmShowUserDetails
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
            this.ucPersonInfoShow1 = new IbrahimDVLD.ucPersonInfoShow();
            this.loginInformation1 = new IbrahimDVLD.LoginInformation();
            this.SuspendLayout();
            // 
            // ucPersonInfoShow1
            // 
            this.ucPersonInfoShow1.Gendor = "???";
            this.ucPersonInfoShow1.imagePath = null;
            this.ucPersonInfoShow1.Location = new System.Drawing.Point(3, 12);
            this.ucPersonInfoShow1.Name = "ucPersonInfoShow1";
            this.ucPersonInfoShow1.PersonIDValue = 0;
            this.ucPersonInfoShow1.Size = new System.Drawing.Size(876, 272);
            this.ucPersonInfoShow1.TabIndex = 0;
            // 
            // loginInformation1
            // 
            this.loginInformation1.IsActive = false;
            this.loginInformation1.Location = new System.Drawing.Point(3, 290);
            this.loginInformation1.Name = "loginInformation1";
            this.loginInformation1.PersonID = -1;
            this.loginInformation1.Size = new System.Drawing.Size(876, 70);
            this.loginInformation1.TabIndex = 1;
            this.loginInformation1.UserName = "User Name :";
            // 
            // frmShowUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 450);
            this.Controls.Add(this.loginInformation1);
            this.Controls.Add(this.ucPersonInfoShow1);
            this.Name = "frmShowUserDetails";
            this.Text = "frmShowUserDetails";
            this.Load += new System.EventHandler(this.frmShowUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPersonInfoShow ucPersonInfoShow1;
        private LoginInformation loginInformation1;
    }
}