using System.Windows.Forms;

namespace IbrahimDVLD
{
   public partial class ucFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFilter));
            this.lblFindBy = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.pbAddNewPerson = new System.Windows.Forms.PictureBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.cmbFindBy = new System.Windows.Forms.ComboBox();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFindBy
            // 
            this.lblFindBy.AutoSize = true;
            this.lblFindBy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindBy.Location = new System.Drawing.Point(6, 23);
            this.lblFindBy.Name = "lblFindBy";
            this.lblFindBy.Size = new System.Drawing.Size(65, 16);
            this.lblFindBy.TabIndex = 0;
            this.lblFindBy.Text = "Find By : ";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.pbAddNewPerson);
            this.gbFilter.Controls.Add(this.pbSearch);
            this.gbFilter.Controls.Add(this.txtFindBy);
            this.gbFilter.Controls.Add(this.cmbFindBy);
            this.gbFilter.Controls.Add(this.lblFindBy);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(525, 55);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            this.gbFilter.Enter += new System.EventHandler(this.gbFilter_Enter);
            // 
            // pbAddNewPerson
            // 
            this.pbAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("pbAddNewPerson.Image")));
            this.pbAddNewPerson.Location = new System.Drawing.Point(470, 17);
            this.pbAddNewPerson.Name = "pbAddNewPerson";
            this.pbAddNewPerson.Size = new System.Drawing.Size(42, 27);
            this.pbAddNewPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddNewPerson.TabIndex = 4;
            this.pbAddNewPerson.TabStop = false;
            this.pbAddNewPerson.Click += new System.EventHandler(this.pbAddNewPerson_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Image = ((System.Drawing.Image)(resources.GetObject("pbSearch.Image")));
            this.pbSearch.Location = new System.Drawing.Point(413, 17);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(42, 27);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 3;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // txtFindBy
            // 
            this.txtFindBy.Location = new System.Drawing.Point(228, 17);
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.Size = new System.Drawing.Size(159, 27);
            this.txtFindBy.TabIndex = 2;
            this.txtFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindBy_KeyPress);
            // 
            // cmbFindBy
            // 
            this.cmbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindBy.FormattingEnabled = true;
            this.cmbFindBy.Location = new System.Drawing.Point(68, 17);
            this.cmbFindBy.Name = "cmbFindBy";
            this.cmbFindBy.Size = new System.Drawing.Size(144, 27);
            this.cmbFindBy.TabIndex = 1;
            // 
            // ucFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Name = "ucFilter";
            this.Size = new System.Drawing.Size(541, 63);
            this.Load += new System.EventHandler(this.ucFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFindBy;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.ComboBox cmbFindBy;
        private System.Windows.Forms.PictureBox pbAddNewPerson;
    }
}
