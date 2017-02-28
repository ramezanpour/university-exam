using Exam.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam.Core
{
    public sealed class QuestionManager
    {
        private const string databaseFile = "db.xml";
        private readonly string LocalStorageLocation;

        public QuestionManager()
        {
            string dirName = "Exam";
            LocalStorageLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dirName);

            if (!Directory.Exists(LocalStorageLocation))
            {
                Directory.CreateDirectory(LocalStorageLocation);
            }

            LocalStorageLocation = Path.Combine(LocalStorageLocation, databaseFile);

            if (!File.Exists(LocalStorageLocation))
            {
                CreateEmptyDatabase();
            }
        }

        private void CreateEmptyDatabase()
        {
            XDocument xdoc = new XDocument();
            xdoc.Add(new XElement("Questions"));
            xdoc.Save(LocalStorageLocation);
        }

        private XDocument LoadDatabase()
        {
            return XDocument.Load(LocalStorageLocation);
        }

        public void Add(Question entity)
        {
            var xdoc = LoadDatabase();
            var question = new XElement("Question",
                new XAttribute("id", entity.Id),
                new XAttribute("correct-answer", entity.CorrectAnswerId),
                new XAttribute("created-on", entity.CreatedOn),
                new XElement("Title", entity.Title),
                new XElement("Items"));

            foreach (var item in entity.Items)
            {
                question.Element("Items").Add(
                    new XElement("Item",
                        new XAttribute("id", item.Id),
                        item.Title));
            }

            xdoc.Element("Questions").Add(question);

            xdoc.Save(LocalStorageLocation);
        }

        public void Delete(Guid id)
        {
            var xdoc = LoadDatabase();
            xdoc.Element("Questions").Elements("Question").FirstOrDefault(k => k.Attribute("id").Value == id.ToString()).Remove();

            xdoc.Save(LocalStorageLocation);
        }

        public void Edit(Question entity)
        {
            var xdoc = LoadDatabase();

            var question = xdoc.Element("Questions").Elements("Question").FirstOrDefault(k => k.Attribute("id").Value == entity.Id.ToString());
            question.Element("Title").Value = entity.Title;
            question.Attribute("correct-answer").Value = entity.CorrectAnswerId.ToString();

            foreach (var item in entity.Items)
            {
                var questionItem = question.Element("Items").Elements("Item").FirstOrDefault(k => k.Attribute("id").Value.Equals(item.Id.ToString(), StringComparison.InvariantCultureIgnoreCase));
                questionItem.Value = item.Title;
            }


            xdoc.Save(LocalStorageLocation);
        }

        public Question GetQuestionById(Guid id)
        {
            var xdoc = LoadDatabase();
            var question = xdoc.Element("Questions").Elements("Question").FirstOrDefault(k => k.Attribute("id").Value == id.ToString());
            return ParseQuestion(question);
        }

        private Question ParseQuestion(XElement question)
        {
            var result = new Question();
            result.Items = new List<QuestionItem>();

            result.Title = question.Element("Title").Value;
            result.CorrectAnswerId = new Guid(question.Attribute("correct-answer").Value);
            result.CreatedOn = DateTime.Parse(question.Attribute("created-on").Value);
            result.Id = new Guid(question.Attribute("id").Value);

            var items = question.Element("Items").Elements("Item");

            foreach (var item in items)
            {
                result.Items.Add(new QuestionItem
                {
                    Id = new Guid(item.Attribute("id").Value),
                    Title = item.Value,
                });
            }

            return result;
        }

        public List<Question> GetAllQuestions()
        {
            var result = new List<Question>();
            var xdoc = LoadDatabase();
            var question = xdoc.Element("Questions").Elements("Question");

            foreach (var item in question)
            {
                result.Add(ParseQuestion(item));
            }

            return result;
        }
    }
}
