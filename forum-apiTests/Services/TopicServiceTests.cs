using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;
using Moq;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class TopicServiceTests
    {
        
        private TopicService _service;
        private Mock<ITopicRepository> _repository;
        private List<Topic> _topics;
        private Comment comment;


        [TestInitialize]
        public void Initialize()
        {
            _repository = new Mock<ITopicRepository>();
            _service = new TopicService(_repository.Object);
            _topics = new List<Topic>();
            _topics.Add(new Topic());
            _topics.Add(new Topic());
            _topics.Add(new Topic());
            _topics.Add(new Topic()); 

        }


        [TestMethod()]
        public void FindAll_Ok()
        {
            //GIVEN
            _repository.Setup(repo => repo.FindAll()).Returns(_topics);
            //WHEN
            List<Topic> topics = _service.FindAll();
            //THEN
            Assert.AreEqual(_topics, topics);
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void FindById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.FindById(It.IsAny<int>())).Returns(_topics.Find(v => v.Idtopic == id));
            Topic expectedTopic = _topics.Find(v => v.Idtopic == id);
            //WHEN
            Topic topic = _service.FindById(id);
            //THEN
            Assert.AreEqual(expectedTopic, topic);
        }
               

        [TestMethod()]
        public void Create_Ok()
        {
            //GIVEN
            Topic topic = new Topic() {
            Idtopic=5,
            Title= "Gateau nature",
            Author = "Ben",
            DateCreation = DateTime.Now,
            DateUpdate = DateTime.Now,
             };
            _repository.Setup(repo => repo.Create(It.IsAny<Topic>())).Returns(topic);
            //WHEN
            Topic topic2 = _service.Create(topic);
            //THEN
            Assert.AreEqual(topic.Idtopic, topic2.Idtopic);
        }

        [TestMethod()]
        public void Update_Ok()
        {
            //GIVEN
            Topic topic = new Topic()
            {
                Idtopic = 1,
                Title = "Gateau nature",
                Author = "Claire",
                DateCreation = DateTime.Now,
                DateUpdate = DateTime.Now,
            };
            _repository.Setup(repo => repo.Update(It.IsAny<Topic>())).Returns(topic);
            //WHEN
            Topic topic2 = _service.Update(topic);
            //THEN
            Assert.AreEqual(topic, topic2);
        }

        [TestMethod()]
        [DataRow(4)]
        public void Delete_Ok(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.Delete(It.IsAny<int>())).Returns(id);
            //WHEN
            int idTopic = _service.Delete(id);
            //THEN
            Assert.AreEqual(id, idTopic);
        }
    }
}