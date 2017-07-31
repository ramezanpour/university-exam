using Exam.Core;
using Exam.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Exam
{
    public partial class F_Exam : Form
    {
        private List<Question> _questions;
        private readonly Queue<Question> _selectedQuestions = new Queue<Question>();
        private readonly List<Question> _wrongAnswers = new List<Question>();
        private readonly List<Question> _correctQuestions = new List<Question>();
        private readonly QuestionManager _manager = new QuestionManager();
        private Question _currentQuestion;
        private int _numberOfQuestions;
        public Guid CategoryId { get; set; }
        private readonly Dictionary<Question, int> _retryQuestions = new Dictionary<Question, int>();
        private readonly Random _random = new Random();
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
            if (_currentQuestion != null)
            {
                foreach (var control in P_Answers.Controls)
                {
                    if (control is RadioButton && ((RadioButton)control).Checked)
                    {
                        var radio = (RadioButton)control;
                        if (radio.Tag.ToString().Equals(_currentQuestion.CorrectAnswerId.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            _correctQuestions.Add(_currentQuestion);
                        }
                        else
                        {
                            _wrongAnswers.Add(_currentQuestion);
                            if (_retryQuestions.ContainsKey(_currentQuestion))
                            {
                                var i = _retryQuestions[_currentQuestion];
                                _retryQuestions[_currentQuestion] = i + 1;
                            }
                            else
                            {
                                _retryQuestions.Add(_currentQuestion, 0);
                            }

                            if (_retryQuestions[_currentQuestion] < 3)
                            {
                                _selectedQuestions.Enqueue(_currentQuestion);
                            }

                            // Highlight the wrong answer
                            radio.BackColor = Color.Red;

                            // Show the correct answer
                            foreach (var c in P_Answers.Controls)
                            {
                                if (c is RadioButton)
                                {
                                    var r = (RadioButton)c;
                                    if (r.Tag.ToString().Equals(_currentQuestion.CorrectAnswerId.ToString(), StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        r.BackColor = Color.Green;
                                        break;
                                    }
                                }
                            }

                            Application.DoEvents();
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                }
            }

            if (_selectedQuestions.Count == 0)
            {
                MessageBox.Show($"سوالات صحیح: {_correctQuestions.Count} \nسوالات اشتباه: {_wrongAnswers.Count} \nکل سوالات: {_numberOfQuestions}");
                this.Close();
            }
            else
            {
                _currentQuestion = _selectedQuestions.Dequeue();
            }

            BindItems();
        }

        private void BindItems()
        {
            try
            {
                L_Question.Text = _currentQuestion.Title;
                P_Answers.Controls.Clear();
                var rowIndex = 0;
                foreach (var item in _currentQuestion.Items)
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
            catch
            {
                // ignored
            }
        }

        private void F_Exam_Load(object sender, EventArgs e)
        {
            _questions = _manager.GetAllQuestions(CategoryId);
            _numberOfQuestions = _questions.Count;

            while (_questions.Count > 0)
            {
                AddSelectedQuestion();
            }

            NextQuestion();
        }

        private void AddSelectedQuestion()
        {
            var questionIndex = _random.Next(0, _questions.Count);

            if (_questions[questionIndex] != null)
            {
                _selectedQuestions.Enqueue(_questions[questionIndex]);
                _questions.RemoveAt(questionIndex);
            }
            else
            {
                AddSelectedQuestion();
            }
        }
    }
}
