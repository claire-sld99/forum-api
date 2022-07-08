using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api.Repositories;
using Moq;
using forum_api.DataAccess.DataObjects;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class CommentServiceTests
    {
        private CommentService _service;
        private Mock<ICommentRepository> _repository;
        private List<Comment> _comments;
        private Comment comment;


        [TestInitialize]
        public void Initialize()
        {
            _repository = new Mock<ICommentRepository>();
            _service = new CommentService(_repository.Object);
            _comments = new List<Comment>();
            _comments.Add(new Comment());
            _comments.Add(new Comment());
            _comments.Add(new Comment());
            _comments.Add(new Comment());

        }


        [TestMethod()]
        public void FindAll_Ok()
        {
            //GIVEN
            _repository.Setup(repo => repo.FindAll()).Returns(_comments);
            //WHEN
            List<Comment> comments = _service.FindAll();
            //THEN
            Assert.AreEqual(_comments, comments);
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void FindById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.FindById(It.IsAny<int>())).Returns(_comments.Find(v => v.Idcomment == id));
            Comment expectedComment = _comments.Find(v => v.Idcomment == id);
            //WHEN
            Comment comment = _service.FindById(id);
            //THEN
            Assert.AreEqual(expectedComment, comment);
        }


        [TestMethod()]
        public void Create_Ok()
        {
            //GIVEN
            Comment comment = new Comment()
            {
                Idcomment = 5,
                Content = "Meilleur gateau",
                Author = "Guillaume",
                DateCreation = DateTime.Now,
                DateUpdate = DateTime.Now,
            };
            _repository.Setup(repo => repo.Create(It.IsAny<Comment>())).Returns(comment);
            //WHEN
            Comment comment2 = _service.Create(comment);
            //THEN
            Assert.AreEqual(comment.Idcomment, comment2.Idcomment);
        }

        [TestMethod()]
        public void Update_Ok()
        {
            //GIVEN
            Comment comment = new Comment()
            {
                Idcomment = 5,
                Content = "Gateau bof",
                Author = "Claire",
                DateCreation = DateTime.Now,
                DateUpdate = DateTime.Now,
            };
            _repository.Setup(repo => repo.Update(It.IsAny<Comment>())).Returns(comment);
            //WHEN
            Comment comment2 = _service.Update(comment);
            //THEN
            Assert.AreEqual(comment, comment2);
        }

        [TestMethod()]
        [DataRow(4)]
        public void Delete_Ok(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.Delete(It.IsAny<int>())).Returns(id);
            //WHEN
            int idComment = _service.Delete(id);
            //THEN
            Assert.AreEqual(id, idComment);
        }
    }
}