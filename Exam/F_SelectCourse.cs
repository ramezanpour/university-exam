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
    public partial class F_SelectCourse : Form
    {
        private readonly QuestionManager _manager = new QuestionManager();
        public F_SelectCourse()
        {
            InitializeComponent();
        }

        private void B_Start_Click(object sender, EventArgs e)
        {
            var examForm = new F_Exam {CategoryId = Guid.Parse(CB_SelectCourse.SelectedValue.ToString())};
            Close();
            examForm.ShowDialog();
        }

        private void F_SelectCourse_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            CB_SelectCourse.DisplayMember = "Name";
            CB_SelectCourse.ValueMember = "id";
            CB_SelectCourse.DataSource = _manager.GetAllCategories();
        }
    }
}
