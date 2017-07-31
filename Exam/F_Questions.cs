using Exam.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class F_Questions : Form
    {
        private readonly QuestionManager manager = new QuestionManager();
        public F_Questions()
        {
            InitializeComponent();
        }

        private void F_Questions_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            DGV_Main.AutoGenerateColumns = false;
            DGV_Main.DataSource = manager.GetAllQuestions(Guid.Empty);
        }

        private void B_Add_Click(object sender, EventArgs e)
        {
            var newQuestion = new F_AddEditQuestion() { IsAdd = true };
            if (newQuestion.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void DGV_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var questionId = new Guid(DGV_Main.Rows[e.RowIndex].Cells[0].Value.ToString());

            var editQuestion = new F_AddEditQuestion() { IsAdd = false, QuestionId = questionId };

            if (editQuestion.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }
    }
}
