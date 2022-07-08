using forum_api.DataAccess.DataObjects;
using forum_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicService _service;
        private readonly CommentService _commentService;

        public TopicController(TopicService service, CommentService commentService)
        {
            _service = service;
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(this._service.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            return Ok(this._service.FindById(id));
        }

        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            this._service.Create(topic);
            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(Topic topic)
        {
            this._service.Update(topic);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._service.Delete(id);
            return Ok("Deleted");
        }
    }
}
