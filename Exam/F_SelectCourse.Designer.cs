namespace Exam
{
    partial class F_SelectCourse
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
            this.label1 = new System.Windows.Forms.Label();
            this.CB_SelectCourse = new System.Windows.Forms.ComboBox();
            this.B_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "لطفا درس مورد نظر را انتخاب کنید";
            // 
            // CB_SelectCourse
            // 
            this.CB_SelectCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SelectCourse.FormattingEnabled = true;
            this.CB_SelectCourse.Location = new System.Drawing.Point(12, 25);
            this.CB_SelectCourse.Name = "CB_SelectCourse";
            this.CB_SelectCourse.Size = new System.Drawing.Size(450, 21);
            this.CB_SelectCourse.TabIndex = 1;
            // 
            // B_Start
            // 
            this.B_Start.Location = new System.Drawing.Point(12, 52);
            this.B_Start.Name = "B_Start";
            this.B_Start.Size = new System.Drawing.Size(75, 23);
            this.B_Start.TabIndex = 2;
            this.B_Start.Text = "شروع";
            this.B_Start.UseVisualStyleBackColor = true;
            this.B_Start.Click += new System.EventHandler(this.B_Start_Click);
            // 
            // F_SelectCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 82);
            this.Controls.Add(this.B_Start);
            this.Controls.Add(this.CB_SelectCourse);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_SelectCourse";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "انتخاب درس";
            this.Load += new System.EventHandler(this.F_SelectCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_SelectCourse;
        private System.Windows.Forms.Button B_Start;
    }
}