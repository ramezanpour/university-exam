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
        private List<Question> correctQuestions = new List<Question>();
        private readonly QuestionManager manager = new QuestionManager();
        private Question currentQuestion = null;
        private int numberOfQuestions = 0;
        private Dictionary<Question, int> retryQuestions = new Dictionary<Question, int>();
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
                foreach (var control in P_Answers.Controls)
                {
                    if (control is RadioButton && ((RadioButton)control).Checked)
                    {
                        var radio = (RadioButton)control;
                        if (radio.Tag.ToString().Equals(currentQuestion.CorrectAnswerId.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            correctQuestions.Add(currentQuestion);
                        }
                        else
                        {
                            wrongAnswers.Add(currentQuestion);
                            if (retryQuestions.ContainsKey(currentQuestion))
                            {
                                var i = retryQuestions[currentQuestion];
                                retryQuestions[currentQuestion] = i + 1;
                            } else
                            {
                                retryQuestions.Add(currentQuestion, 0);
                            }

                            if (retryQuestions[currentQuestion] < 3)
                            {
                                selectedQuestions.Enqueue(currentQuestion);
                            }
                        }
                    }
                }
            }

            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show($"سوالات صحیح: {correctQuestions.Count} \nسوالات اشتباه: {wrongAnswers.Count} \nکل سوالات: {numberOfQuestions}");
                this.Close();
            }
            else
            {
                currentQuestion = selectedQuestions.Dequeue();
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
                var radio = new RadioButton
                {
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
            numberOfQuestions = questions.Count;

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
            }
            else
            {
                AddSelectedQuestion();
            }
        }
    }
}
