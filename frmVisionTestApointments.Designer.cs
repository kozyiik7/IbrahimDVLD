namespace IbrahimDVLD
{
    partial class frmVisionTestApointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisionTestApointments));
            this.lblMainAddress = new System.Windows.Forms.Label();
            this.pbMainImage = new System.Windows.Forms.PictureBox();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ucApplicationAllInfo1 = new IbrahimDVLD.ucApplicationAllInfo();
            this.ImageListMode = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMainAddress
            // 
            this.lblMainAddress.AutoSize = true;
            this.lblMainAddress.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainAddress.ForeColor = System.Drawing.Color.Red;
            this.lblMainAddress.Location = new System.Drawing.Point(326, 120);
            this.lblMainAddress.Name = "lblMainAddress";
            this.lblMainAddress.Size = new System.Drawing.Size(275, 25);
            this.lblMainAddress.TabIndex = 1;
            this.lblMainAddress.Text = " Vision Test Appoinments";
            // 
            // pbMainImage
            // 
            this.pbMainImage.Image = ((System.Drawing.Image)(resources.GetObject("pbMainImage.Image")));
            this.pbMainImage.Location = new System.Drawing.Point(382, 12);
            this.pbMainImage.Name = "pbMainImage";
            this.pbMainImage.Size = new System.Drawing.Size(187, 105);
            this.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMainImage.TabIndex = 2;
            this.pbMainImage.TabStop = false;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppointments.Location = new System.Drawing.Point(12, 544);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(898, 150);
            this.dgvAppointments.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.takeTestToolStripMenuItem.Text = "&Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appointments :";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(8, 715);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(108, 19);
            this.lblNumberOfRecords.TabIndex = 5;
            this.lblNumberOfRecords.Text = "# Records : ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(832, 501);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // ucApplicationAllInfo1
            // 
            this.ucApplicationAllInfo1.AppID = 0;
            this.ucApplicationAllInfo1.Location = new System.Drawing.Point(12, 148);
            this.ucApplicationAllInfo1.Name = "ucApplicationAllInfo1";
            this.ucApplicationAllInfo1.Size = new System.Drawing.Size(898, 347);
            this.ucApplicationAllInfo1.TabIndex = 0;
            // 
            // ImageListMode
            // 
            this.ImageListMode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListMode.ImageStream")));
            this.ImageListMode.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListMode.Images.SetKeyName(0, "VisionTest.png");
            this.ImageListMode.Images.SetKeyName(1, "WriteTest.png");
            this.ImageListMode.Images.SetKeyName(2, "StreetTest.png");
            // 
            // frmVisionTestApointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 743);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.pbMainImage);
            this.Controls.Add(this.lblMainAddress);
            this.Controls.Add(this.ucApplicationAllInfo1);
            this.Name = "frmVisionTestApointments";
            this.Text = "frmVisionTestApointments";
            this.Load += new System.EventHandler(this.frmVisionTestApointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucApplicationAllInfo ucApplicationAllInfo1;
        private System.Windows.Forms.Label lblMainAddress;
        private System.Windows.Forms.PictureBox pbMainImage;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.ImageList ImageListMode;
    }
}