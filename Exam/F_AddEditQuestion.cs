using Exam.Core;
using Exam.Core.Model;
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
    public partial class F_AddEditQuestion : Form
    {
        private readonly QuestionManager manager = new QuestionManager();
        public bool IsAdd { get; set; }
        public Guid QuestionId { get; set; }

        private Question question = new Question();
        public F_AddEditQuestion()
        {
            InitializeComponent();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (IsAdd)
                {
                    question.Title = TB_Title.Text;
                    question.CreatedOn = DateTime.Now;
                    question.Id = Guid.NewGuid();

                    // First answer
                    var answer1 = new QuestionItem();
                    answer1.Id = Guid.NewGuid();
                    answer1.Title = TB_Answer1.Text;
                    question.Items.Add(answer1);

                    // Second answer
                    var answer2 = new QuestionItem();
                    answer2.Id = Guid.NewGuid();
                    answer2.Title = TB_Answer2.Text;
                    question.Items.Add(answer2);

                    // Third answer
                    var answer3 = new QuestionItem();
                    answer3.Id = Guid.NewGuid();
                    answer3.Title = TB_Answer3.Text;
                    question.Items.Add(answer3);

                    // Forth answer
                    var answer4 = new QuestionItem();
                    answer4.Id = Guid.NewGuid();
                    answer4.Title = TB_Answer4.Text;
                    question.Items.Add(answer4);

                    DetermineCorrectAnswer(question, answer1, answer2, answer3, answer4);
                    question.CategoryId = Guid.Parse(CB_Category.SelectedValue.ToString());
                    manager.Add(question);
                    MessageBox.Show("سوال مورد نظر با موفقیت اضافه شد.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // Update

                    question.Title = TB_Title.Text;

                    // First answer
                    var answer1 = new QuestionItem();
                    answer1.Id = question.Items[0].Id;
                    answer1.Title = TB_Answer1.Text;
                    question.Items[0] = answer1;

                    // Second answer
                    var answer2 = new QuestionItem();
                    answer2.Id = question.Items[1].Id;
                    answer2.Title = TB_Answer2.Text;

                    question.Items[1] = answer2;

                    // Third answer
                    var answer3 = new QuestionItem();
                    answer3.Id = question.Items[2].Id;
                    answer3.Title = TB_Answer3.Text;

                    question.Items[2] = answer3;

                    // Forth answer
                    var answer4 = new QuestionItem();
                    answer4.Id = question.Items[3].Id;
                    answer4.Title = TB_Answer4.Text;

                    question.Items[3] = answer4;

                    DetermineCorrectAnswer(question, answer1, answer2, answer3, answer4);

                    manager.Edit(question);
                    MessageBox.Show("سوال مورد نظر با موفقیت ویرایش شد.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void DetermineCorrectAnswer(Question question, QuestionItem answer1, QuestionItem answer2, QuestionItem answer3, QuestionItem answer4)
        {
            // Determine the correct answer.

            if (RB_CorrectAnswer1.Checked)
            {
                question.CorrectAnswerId = answer1.Id;
            }
            else if (RB_CorrectAnswer2.Checked)
            {
                question.CorrectAnswerId = answer2.Id;
            }
            else if (RB_CorrectAnswer3.Checked)
            {
                question.CorrectAnswerId = answer3.Id;
            }
            else if (RB_CorrectAnswer4.Checked)
            {
                question.CorrectAnswerId = answer4.Id;
            }
        }

        private bool ValidateInputs()
        {
            if (TB_Title.Text.IsNullOrEmpty() || TB_Answer1.Text.IsNullOrEmpty() || TB_Answer3.Text.IsNullOrEmpty() || TB_Answer4.Text.IsNullOrEmpty())
            {
                MessageBox.Show("همه فیلد ها اجباری می باشند. ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            if (!RB_CorrectAnswer1.Checked && !RB_CorrectAnswer2.Checked && !RB_CorrectAnswer3.Checked && !RB_CorrectAnswer4.Checked)
            {
                MessageBox.Show("حداقل یکی از جواب ها باید صحیح باشند.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }

        private void F_AddEditQuestion_Load(object sender, EventArgs e)
        {
            BindCategories();
            B_Delete.Visible = !IsAdd;

            if (!IsAdd)
            {
                question = manager.GetQuestionById(QuestionId);
                FillItems(question);
            }
        }

        private void BindCategories()
        {
            CB_Category.DisplayMember = "Name";
            CB_Category.ValueMember = "Id";
            CB_Category.DataSource = manager.GetAllCategories();
        }

        private void FillItems(Question question)
        {
            TB_Title.Text = question.Title;

            var first = question.Items[0];
            TB_Answer1.Text = first.Title;
            RB_CorrectAnswer1.Tag = first.Id;

            var second = question.Items[1];
            TB_Answer2.Text = second.Title;
            RB_CorrectAnswer2.Tag = second.Id;

            var third = question.Items[2];
            TB_Answer3.Text = third.Title;
            RB_CorrectAnswer3.Tag = third.Id;

            var fourth = question.Items[3];
            TB_Answer4.Text = fourth.Title;
            RB_CorrectAnswer4.Tag = fourth.Id;

            // Check current correct answer.

            foreach (var control in groupBox1.Controls)
            {
                if (control is RadioButton)
                {
                    var rb = (RadioButton)control;
                    if (rb.Tag.ToString() == question.CorrectAnswerId.ToString())
                    {
                        rb.Checked = true;
                    }
                }
            }
        }

        private void B_Delete_Click(object sender, EventArgs e)
        {
            if (!IsAdd)
            {
                if (MessageBox.Show("آیا مطمئن هستید؟", "پیام سیستم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    manager.Delete(QuestionId);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
