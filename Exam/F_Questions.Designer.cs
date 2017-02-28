namespace Exam
{
    partial class F_Questions
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
            this.B_Add = new System.Windows.Forms.Button();
            this.DGV_Main = new System.Windows.Forms.DataGridView();
            this.C_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Add
            // 
            this.B_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Add.Location = new System.Drawing.Point(514, 12);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(106, 23);
            this.B_Add.TabIndex = 0;
            this.B_Add.Text = "افزودن سوال جدید";
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // DGV_Main
            // 
            this.DGV_Main.AllowUserToAddRows = false;
            this.DGV_Main.AllowUserToDeleteRows = false;
            this.DGV_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Id,
            this.C_Title,
            this.C_CreatedOn});
            this.DGV_Main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV_Main.Location = new System.Drawing.Point(0, 41);
            this.DGV_Main.Name = "DGV_Main";
            this.DGV_Main.ReadOnly = true;
            this.DGV_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Main.Size = new System.Drawing.Size(632, 361);
            this.DGV_Main.TabIndex = 1;
            this.DGV_Main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Main_CellDoubleClick);
            // 
            // C_Id
            // 
            this.C_Id.DataPropertyName = "Id";
            this.C_Id.HeaderText = "Id";
            this.C_Id.Name = "C_Id";
            this.C_Id.ReadOnly = true;
            this.C_Id.Visible = false;
            // 
            // C_Title
            // 
            this.C_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.C_Title.DataPropertyName = "Title";
            this.C_Title.HeaderText = "عنوان";
            this.C_Title.Name = "C_Title";
            this.C_Title.ReadOnly = true;
            // 
            // C_CreatedOn
            // 
            this.C_CreatedOn.DataPropertyName = "CreatedOn";
            this.C_CreatedOn.HeaderText = "تاریخ ایجاد";
            this.C_CreatedOn.Name = "C_CreatedOn";
            this.C_CreatedOn.ReadOnly = true;
            // 
            // F_Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 402);
            this.Controls.Add(this.DGV_Main);
            this.Controls.Add(this.B_Add);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Questions";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "مدیریت سوال ها";
            this.Load += new System.EventHandler(this.F_Questions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.DataGridView DGV_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_CreatedOn;
    }
}