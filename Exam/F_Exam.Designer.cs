namespace Exam
{
    partial class F_Exam
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.L_Question = new System.Windows.Forms.Label();
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Exit = new System.Windows.Forms.Button();
            this.P_Answers = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.P_Answers);
            this.groupBox1.Controls.Add(this.L_Question);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "سوال";
            // 
            // L_Question
            // 
            this.L_Question.Dock = System.Windows.Forms.DockStyle.Top;
            this.L_Question.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Question.Location = new System.Drawing.Point(3, 17);
            this.L_Question.Name = "L_Question";
            this.L_Question.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.L_Question.Size = new System.Drawing.Size(668, 13);
            this.L_Question.TabIndex = 0;
            this.L_Question.Text = "سوال";
            this.L_Question.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(611, 332);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(75, 23);
            this.B_Next.TabIndex = 1;
            this.B_Next.Text = "سوال بعدی";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Exit
            // 
            this.B_Exit.Location = new System.Drawing.Point(12, 332);
            this.B_Exit.Name = "B_Exit";
            this.B_Exit.Size = new System.Drawing.Size(75, 23);
            this.B_Exit.TabIndex = 2;
            this.B_Exit.Text = "خروج";
            this.B_Exit.UseVisualStyleBackColor = true;
            this.B_Exit.Click += new System.EventHandler(this.B_Exit_Click);
            // 
            // P_Answers
            // 
            this.P_Answers.ColumnCount = 1;
            this.P_Answers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.P_Answers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_Answers.Location = new System.Drawing.Point(3, 43);
            this.P_Answers.Name = "P_Answers";
            this.P_Answers.RowCount = 1;
            this.P_Answers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.P_Answers.Size = new System.Drawing.Size(668, 268);
            this.P_Answers.TabIndex = 1;
            // 
            // F_Exam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 358);
            this.Controls.Add(this.B_Exit);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Exam";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "امتحان";
            this.Load += new System.EventHandler(this.F_Exam_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label L_Question;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button B_Exit;
        private System.Windows.Forms.TableLayoutPanel P_Answers;
    }
}