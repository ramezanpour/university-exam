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
    public partial class F_Exam : Form
    {
        private List<Question> questions;
        private Queue<Question> selectedQuestions = new Queue<Question>();
        private List<Question> wrongAnswers = new List<Question>();
        private readonly QuestionManager manager = new QuestionManager();
        private Question currentQuestion = null;
        private int numberOfAnsweredQuestions = 0;
        private Random random = new Random();
        public F_Exam()
        {
            InitializeComponent();
        }

        private void B_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن هستید؟", "پیام سیستم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void B_Next_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        private void NextQuestion()
        {
            if (currentQuestion != null)
            {
                numberOfAnsweredQuestions++;
            }
            currentQuestion = selectedQuestions.Dequeue();

            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show($"Number of answered questions: {numberOfAnsweredQuestions}\nNumber of all questions:");
                this.Close();
            }

            BindItems();
        }

        private void BindItems()
        {
            L_Question.Text = currentQuestion.Title;
            P_Answers.Controls.Clear();
            int rowIndex = 0;
            foreach (var item in currentQuestion.Items)
            {
                var radio = new RadioButton {
                    Tag = item.Id,
                    Text = item.Title,
                    TextAlign = ContentAlignment.MiddleRight
                };
                P_Answers.Controls.Add(radio, 0, rowIndex);
                rowIndex++;
            }
        }

        private void F_Exam_Load(object sender, EventArgs e)
        {
            questions = manager.GetAllQuestions();

            
            while (questions.Count > 0)
            {
                AddSelectedQuestion();
            }

            NextQuestion();
        }

        private void AddSelectedQuestion()
        {
            int questionIndex = random.Next(0, questions.Count);

            if (questions[questionIndex] != null)
            {
                selectedQuestions.Enqueue(questions[questionIndex]);
                questions.RemoveAt(questionIndex);
            } else
            {
                AddSelectedQuestion();
            }
        }
    }
}
