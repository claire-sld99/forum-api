using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> FindAll();
        Comment FindById(int id);
        Comment Create(Comment comment);
        Comment Update(Comment comment);
        int Delete(int id);
    }
}
