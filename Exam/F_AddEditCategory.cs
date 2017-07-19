using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam.Core;

namespace Exam
{
    public partial class F_AddEditCategory : Form
    {
        private readonly QuestionManager _questionManager = new QuestionManager();
        public bool IsEdit { get; set; }
        public Guid Id { get; set; }
        public F_AddEditCategory()
        {
            InitializeComponent();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            _questionManager.AddCategory(TB_Name.Text);
            DialogResult = DialogResult.OK;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();
    }
}
