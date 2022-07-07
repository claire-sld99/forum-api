using forum_api.Repositories;

namespace forum_api.Services
{
    public class CommentService
    {

        private CommentRepository repo;

        public CommentService(CommentRepository repo)
        {
            this.repo = repo;
        }
    }
}
