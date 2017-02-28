namespace Exam
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.مدیریتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_QuestionManager = new System.Windows.Forms.ToolStripMenuItem();
            this.دانشآموزToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.B_StartExam = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مدیریتToolStripMenuItem,
            this.دانشآموزToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // مدیریتToolStripMenuItem
            // 
            this.مدیریتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_QuestionManager});
            this.مدیریتToolStripMenuItem.Name = "مدیریتToolStripMenuItem";
            this.مدیریتToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.مدیریتToolStripMenuItem.Text = "مدیریت";
            // 
            // MI_QuestionManager
            // 
            this.MI_QuestionManager.Name = "MI_QuestionManager";
            this.MI_QuestionManager.Size = new System.Drawing.Size(152, 22);
            this.MI_QuestionManager.Text = "مدیریت سوالات";
            this.MI_QuestionManager.Click += new System.EventHandler(this.MI_QuestionManager_Click);
            // 
            // دانشآموزToolStripMenuItem
            // 
            this.دانشآموزToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_StartExam});
            this.دانشآموزToolStripMenuItem.Name = "دانشآموزToolStripMenuItem";
            this.دانشآموزToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.دانشآموزToolStripMenuItem.Text = "دانش آموز";
            // 
            // B_StartExam
            // 
            this.B_StartExam.Name = "B_StartExam";
            this.B_StartExam.Size = new System.Drawing.Size(152, 22);
            this.B_StartExam.Text = "شروع امتحان";
            this.B_StartExam.Click += new System.EventHandler(this.B_StartExam_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 409);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "صفحه اصلی";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem مدیریتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MI_QuestionManager;
        private System.Windows.Forms.ToolStripMenuItem دانشآموزToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem B_StartExam;
    }
}