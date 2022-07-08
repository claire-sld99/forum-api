using forum_api.DataAccess.DataObjects;
using forum_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly TopicService _service;
        private readonly CommentService _commentService;

        public CommentController(TopicService topicService, CommentService commentService)
        {
            _service = topicService;
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(this._commentService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            return Ok(this._commentService.FindById(id));
        }

        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            this._commentService.Create(comment);
            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(Comment comment)
        {
            this._commentService.Update(comment);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._commentService.Delete(id);
            return Ok("Deleted");
        }
    }
}
