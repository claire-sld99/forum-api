using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;

namespace forum_api.Services
{
    public class CommentService
    {

        private ICommentRepository repo;

        public CommentService(ICommentRepository repo)
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
            return this.repo.Create(comment);
        }

        public Comment Update(Comment comment)
        {
            return this.repo.Update(comment);
        }

        public int Delete(int id)
        {
            return this.repo.Delete(id);
        }
    }
}
