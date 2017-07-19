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
    public partial class F_Categories : Form
    {
        private readonly QuestionManager _questionManager;

        public F_Categories()
        {
            _questionManager = new QuestionManager();
            InitializeComponent();
        }

        private void B_Add_Click(object sender, EventArgs e)
        {
            var addEditCategory = new F_AddEditCategory {IsEdit = false};
            if (addEditCategory.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void F_Categories_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            DGV_Category.AutoGenerateColumns = false;
            DGV_Category.DataSource = _questionManager.GetAllCategories();
        }
    }
}