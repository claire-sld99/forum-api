using forum_api.DataAccess.DataObjects;
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

        public List<Comment> FindAll()
        {
            return this.repo.FindAll();
        }

        public Comment FindById(int id)
        {
            return this.repo.FindById(id);
        }

        public Comment Create(Comment comment)
        {
            Comment newComment = new Comment();
            return newComment;
        }

        public Comment Update(Comment comment)
        {
            Comment newComment = new Comment();
            return newComment;
        }

        public int Delete(int id)
        {
            return this.repo.Delete(id);
        }
    }
}
