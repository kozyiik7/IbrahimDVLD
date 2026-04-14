namespace IbrahimDVLD
{
    partial class ucFilterWithPersonInof
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
            this.ucFilter1 = new IbrahimDVLD.ucFilter();
            this.ucPersonInfoShow1 = new IbrahimDVLD.ucPersonInfoShow();
            this.SuspendLayout();
            // 
            // ucFilter1
            // 
            this.ucFilter1.Location = new System.Drawing.Point(3, 3);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.PersonIDValue = -1;
            this.ucFilter1.Size = new System.Drawing.Size(541, 63);
            this.ucFilter1.TabIndex = 0;
            this.ucFilter1.TextValue = "";
            // 
            // ucPersonInfoShow1
            // 
            this.ucPersonInfoShow1.Gendor = "???";
            this.ucPersonInfoShow1.imagePath = null;
            this.ucPersonInfoShow1.Location = new System.Drawing.Point(3, 72);
            this.ucPersonInfoShow1.Name = "ucPersonInfoShow1";
            this.ucPersonInfoShow1.PersonIDValue = 0;
            this.ucPersonInfoShow1.Size = new System.Drawing.Size(876, 272);
            this.ucPersonInfoShow1.TabIndex = 1;
            // 
            // ucFilterWithPersonInof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPersonInfoShow1);
            this.Controls.Add(this.ucFilter1);
            this.Name = "ucFilterWithPersonInof";
            this.Size = new System.Drawing.Size(891, 359);
            this.Load += new System.EventHandler(this.ucFilterWithPersonInof_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucFilter ucFilter1;
        private ucPersonInfoShow ucPersonInfoShow1;
    }
}
