namespace IbrahimDVLD
{
    partial class frmManageUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.lblManageUsers = new System.Windows.Forms.Label();
            this.lblFilterBY = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cmsManageUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblRecoedValue = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmsManageUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManageUsers
            // 
            this.lblManageUsers.AutoSize = true;
            this.lblManageUsers.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageUsers.ForeColor = System.Drawing.Color.Red;
            this.lblManageUsers.Location = new System.Drawing.Point(325, 95);
            this.lblManageUsers.Name = "lblManageUsers";
            this.lblManageUsers.Size = new System.Drawing.Size(143, 23);
            this.lblManageUsers.TabIndex = 1;
            this.lblManageUsers.Text = "Manage Users";
            // 
            // lblFilterBY
            // 
            this.lblFilterBY.AutoSize = true;
            this.lblFilterBY.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBY.Location = new System.Drawing.Point(26, 139);
            this.lblFilterBY.Name = "lblFilterBY";
            this.lblFilterBY.Size = new System.Drawing.Size(59, 16);
            this.lblFilterBY.TabIndex = 2;
            this.lblFilterBY.Text = "Filter By";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(91, 138);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbFilter.TabIndex = 3;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(218, 139);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(124, 20);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmsManageUser;
            this.dgvUsers.Location = new System.Drawing.Point(29, 178);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(759, 206);
            this.dgvUsers.TabIndex = 5;
            // 
            // cmsManageUser
            // 
            this.cmsManageUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewUserToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sendEmailToolStripMenuItem,
            this.sendSMSToolStripMenuItem});
            this.cmsManageUser.Name = "cmsManageUser";
            this.cmsManageUser.Size = new System.Drawing.Size(169, 170);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewUserToolStripMenuItem.Image")));
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswordToolStripMenuItem.Image")));
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 6);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendEmailToolStripMenuItem.Image")));
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            // 
            // sendSMSToolStripMenuItem
            // 
            this.sendSMSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendSMSToolStripMenuItem.Image")));
            this.sendSMSToolStripMenuItem.Name = "sendSMSToolStripMenuItem";
            this.sendSMSToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sendSMSToolStripMenuItem.Text = "Send SMS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(338, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(35, 403);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(95, 19);
            this.lblRecord.TabIndex = 6;
            this.lblRecord.Text = "# Record :";
            // 
            // lblRecoedValue
            // 
            this.lblRecoedValue.AutoSize = true;
            this.lblRecoedValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecoedValue.Location = new System.Drawing.Point(136, 403);
            this.lblRecoedValue.Name = "lblRecoedValue";
            this.lblRecoedValue.Size = new System.Drawing.Size(0, 19);
            this.lblRecoedValue.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(749, 139);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Items.AddRange(new object[] {
            "All",
            "True",
            "False"});
            this.cmbIsActive.Location = new System.Drawing.Point(218, 138);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(121, 21);
            this.cmbIsActive.TabIndex = 9;
            this.cmbIsActive.SelectedIndexChanged += new System.EventHandler(this.cmbIsActive_SelectedIndexChanged);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblRecoedValue);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.lblFilterBY);
            this.Controls.Add(this.lblManageUsers);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cmsManageUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblManageUsers;
        private System.Windows.Forms.Label lblFilterBY;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblRecoedValue;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.ContextMenuStrip cmsManageUser;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendSMSToolStripMenuItem;
    }
}