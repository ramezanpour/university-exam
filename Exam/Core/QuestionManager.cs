using Exam.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Exam.Core
{
    public sealed class QuestionManager
    {
        private const string DatabaseFile = "db.xml";
        private readonly string _localStorageLocation;

        public QuestionManager()
        {
            const string dirName = "Exam";
            _localStorageLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                dirName);

            if (!Directory.Exists(_localStorageLocation))
            {
                Directory.CreateDirectory(_localStorageLocation);
            }

            _localStorageLocation = Path.Combine(_localStorageLocation, DatabaseFile);

            if (!File.Exists(_localStorageLocation))
            {
                CreateEmptyDatabase();
            }
        }

        private void CreateEmptyDatabase()
        {
            var xdoc = new XDocument();
            var root = new XElement("Db");
            root.Add(new XElement("Questions"));
            root.Add(new XElement("Categories"));
            xdoc.Add(root);
            xdoc.Save(_localStorageLocation);
        }

        private XDocument LoadDatabase()
        {
            return XDocument.Load(_localStorageLocation);
        }

        public void Add(Question entity)
        {
            var xdoc = LoadDatabase();
            var question = new XElement("Question",
                new XAttribute("id", entity.Id),
                new XAttribute("correct-answer", entity.CorrectAnswerId),
                new XAttribute("created-on", entity.CreatedOn),
                new XElement("Title", entity.Title),
                new XAttribute("category-id", entity.CategoryId),
                new XElement("Items"));

            foreach (var item in entity.Items)
            {
                question.Element("Items").Add(
                    new XElement("Item",
                        new XAttribute("id", item.Id),
                        item.Title));
            }

            xdoc.Element("Db").Element("Questions").Add(question);

            xdoc.Save(_localStorageLocation);
        }

        public void Delete(Guid id)
        {
            var xdoc = LoadDatabase();
            xdoc.Element("Db").Element("Questions").Elements("Question")
                .FirstOrDefault(k => k.Attribute("id").Value == id.ToString())
                .Remove();

            xdoc.Save(_localStorageLocation);
        }

        public void Edit(Question entity)
        {
            var xdoc = LoadDatabase();

            var question = xdoc.Element("Db").Element("Questions").Elements("Question")
                .FirstOrDefault(k => k.Attribute("id").Value == entity.Id.ToString());
            question.Element("Title").Value = entity.Title;
            question.Attribute("correct-answer").Value = entity.CorrectAnswerId.ToString();
            question.Attribute("category-id").Value = entity.CategoryId.ToString();

            foreach (var item in entity.Items)
            {
                var questionItem = question.Element("Items").Elements("Item").FirstOrDefault(k => k.Attribute("id")
                    .Value.Equals(item.Id.ToString(), StringComparison.InvariantCultureIgnoreCase));
                questionItem.Value = item.Title;
            }


            xdoc.Save(_localStorageLocation);
        }

        public Question GetQuestionById(Guid id)
        {
            var xdoc = LoadDatabase();
            var question = xdoc.Element("Db").Element("Questions").Elements("Question")
                .FirstOrDefault(k => k.Attribute("id").Value == id.ToString());
            return ParseQuestion(question);
        }

        private static Question ParseQuestion(XElement question)
        {
            var result = new Question
            {
                Items = new List<QuestionItem>(),
                Title = question.Element("Title").Value,
                CorrectAnswerId = new Guid(question.Attribute("correct-answer").Value),
                CreatedOn = DateTime.Parse(question.Attribute("created-on").Value),
                Id = new Guid(question.Attribute("id").Value)
            };


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

        public void AddCategory(string name)
        {
            UpdateDatabaseIfNeeded();
            var xdoc = LoadDatabase();
            var element = new XElement("item", new XAttribute("id", Guid.NewGuid()), name);
            xdoc.Element("Db").Element("Categories").Add(element);

            xdoc.Save(_localStorageLocation);
        }

        public void EditCategory(Guid id, string name)
        {
            UpdateDatabaseIfNeeded();
            var xdoc = LoadDatabase();
            xdoc.Element("Db").Element("Categories").Elements("item")
                .FirstOrDefault(k => k.Attribute("id").Value == id.ToString())
                .SetValue(name);
            xdoc.Save(_localStorageLocation);
        }

        private void UpdateDatabaseIfNeeded()
        {
            var xdoc = LoadDatabase();
            if (xdoc.Element("Db").Element("Categories") != null) return;
            xdoc.Element("Db").Add(new XElement("Categories"));
            xdoc.Save(_localStorageLocation);
        }

        public List<Question> GetAllQuestions(Guid categoryId)
        {
            var xdoc = LoadDatabase();
            var question = xdoc.Element("Db").Element("Questions").Elements("Question");
            if (categoryId != Guid.Empty)
            {
                question = question.Where(k => k
                    .Attribute("category-id").Value.Equals(categoryId.ToString(), StringComparison.OrdinalIgnoreCase));
            }

            return question.Select(ParseQuestion).ToList();
        }

        public List<Category> GetAllCategories()
        {
            UpdateDatabaseIfNeeded();
            var xdoc = LoadDatabase();
            var categories = xdoc.Element("Db").Element("Categories").Elements("item");
            var result = categories.Select(item => new Category
                {
                    Id = Guid.Parse(item.Attribute("id").Value),
                    Name = item.Value
                })
                .ToList();
            return result;
        }
    }
}