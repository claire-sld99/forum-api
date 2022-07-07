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
        private Mock<TopicRepository> _repository;
        private List<Topic> _topics;
        private Comment comment;


        [TestInitialize]
        public void Initialize()
        {
            _repository = new Mock<TopicRepository>();
            _service = new TopicService(_repository.Object);
            _topics = new List<Topic>();
            _topics.Add(new Topic(1, "Gateau au chocolat", "Claire", new DateTime(), new DateTime(), 0, comment));
            _topics.Add(new Topic(2, "Cours", "Lena",  new DateTime(), new DateTime(), 0, comment));
            _topics.Add(new Topic(3, "Gateau a la fraise", "Audrey", new DateTime(), new DateTime(), 0, comment));
            _topics.Add(new Topic(4, "Paris", "Danielle",new DateTime(), new DateTime(), 0, comment)); 

        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void FindById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.FindById(id)).Returns(_topics.Find(v => v.Idtopic == id));
            Topic expectedTopic = _topics.Find(v => v.Idtopic == id);
            //WHEN
            Topic topic = _service.FindById(id);
            //THEN
            Assert.AreEqual(expectedTopic, topic);
        }
    }
}