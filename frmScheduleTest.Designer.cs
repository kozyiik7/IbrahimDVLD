namespace IbrahimDVLD
{
    partial class frmScheduleTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleTest));
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTest = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.ucVisionTest1 = new IbrahimDVLD.ucVisionTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.ImageListMode = new System.Windows.Forms.ImageList(this.components);
            this.pnlTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::IbrahimDVLD.Properties.Resources.icons8_save_48;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(430, 595);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 45);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlTest
            // 
            this.pnlTest.Controls.Add(this.label12);
            this.pnlTest.Controls.Add(this.txtNotes);
            this.pnlTest.Controls.Add(this.rbFail);
            this.pnlTest.Controls.Add(this.rbPass);
            this.pnlTest.Controls.Add(this.label11);
            this.pnlTest.Location = new System.Drawing.Point(25, 416);
            this.pnlTest.Name = "pnlTest";
            this.pnlTest.Size = new System.Drawing.Size(465, 173);
            this.pnlTest.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 19);
            this.label12.TabIndex = 4;
            this.label12.Text = "Notes :";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(16, 69);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(438, 88);
            this.txtNotes.TabIndex = 3;
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFail.Location = new System.Drawing.Point(185, 13);
            this.rbFail.Name = "rbFail";
            this.rbFail.Size = new System.Drawing.Size(56, 23);
            this.rbFail.TabIndex = 2;
            this.rbFail.TabStop = true;
            this.rbFail.Text = "Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPass.Location = new System.Drawing.Point(100, 13);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(64, 23);
            this.rbPass.TabIndex = 1;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Result : ";
            // 
            // ucVisionTest1
            // 
            this.ucVisionTest1.AppID = 0;
            this.ucVisionTest1.AppointmentDate = new System.DateTime(2026, 4, 18, 10, 3, 42, 819);
            this.ucVisionTest1.EnableDateTimePicker = true;
            this.ucVisionTest1.gbRetakeTestVisible = true;
            this.ucVisionTest1.lblMainAddressText = "Schedule Test";
            this.ucVisionTest1.lblTestIDVisible = true;
            this.ucVisionTest1.Location = new System.Drawing.Point(-3, 2);
            this.ucVisionTest1.Name = "ucVisionTest1";
            this.ucVisionTest1.Size = new System.Drawing.Size(558, 587);
            this.ucVisionTest1.TabIndex = 0;
            this.ucVisionTest1.visibleSubAddressLable = false;
            this.ucVisionTest1.Load += new System.EventHandler(this.ucVisionTest1_Load);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::IbrahimDVLD.Properties.Resources.icons8_close_48;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(210, 617);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 41);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ImageListMode
            // 
            this.ImageListMode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListMode.ImageStream")));
            this.ImageListMode.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListMode.Images.SetKeyName(0, "VisionTest.png");
            this.ImageListMode.Images.SetKeyName(1, "WriteTest.png");
            this.ImageListMode.Images.SetKeyName(2, "StreetTest.png");
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 670);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlTest);
            this.Controls.Add(this.ucVisionTest1);
            this.Name = "frmScheduleTest";
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.pnlTest.ResumeLayout(false);
            this.pnlTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucVisionTest ucVisionTest1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlTest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList ImageListMode;
    }
}