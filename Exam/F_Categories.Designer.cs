namespace Exam
{
    partial class F_Categories
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
            this.DGV_Category = new System.Windows.Forms.DataGridView();
            this.B_Add = new System.Windows.Forms.Button();
            this.C_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Category)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Category
            // 
            this.DGV_Category.AllowUserToAddRows = false;
            this.DGV_Category.AllowUserToDeleteRows = false;
            this.DGV_Category.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Category.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Id,
            this.C_name});
            this.DGV_Category.Location = new System.Drawing.Point(12, 41);
            this.DGV_Category.Name = "DGV_Category";
            this.DGV_Category.ReadOnly = true;
            this.DGV_Category.Size = new System.Drawing.Size(593, 358);
            this.DGV_Category.TabIndex = 0;
            // 
            // B_Add
            // 
            this.B_Add.Location = new System.Drawing.Point(493, 12);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(112, 23);
            this.B_Add.TabIndex = 1;
            this.B_Add.Text = "افزودن درس جدید";
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // C_Id
            // 
            this.C_Id.DataPropertyName = "Id";
            this.C_Id.HeaderText = "Id";
            this.C_Id.Name = "C_Id";
            this.C_Id.ReadOnly = true;
            this.C_Id.Visible = false;
            // 
            // C_name
            // 
            this.C_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.C_name.DataPropertyName = "Name";
            this.C_name.HeaderText = "عنوان";
            this.C_name.Name = "C_name";
            this.C_name.ReadOnly = true;
            // 
            // F_Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 411);
            this.Controls.Add(this.B_Add);
            this.Controls.Add(this.DGV_Category);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Categories";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مدیریت دروس";
            this.Load += new System.EventHandler(this.F_Categories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Category)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Category;
        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_name;
    }
}