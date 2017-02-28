using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Model
{
    public sealed class Question
    {
        public Question()
        {
            if (Items == null)
                Items = new List<QuestionItem>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<QuestionItem> Items { get; set; }
        public Guid CorrectAnswerId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
