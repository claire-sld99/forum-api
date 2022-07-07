using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{
    public interface ITopicRepository
    {
        List<Topic> FindAll();
        Topic FindById(int id);
        Topic Create(Topic topic);
        Topic Update(Topic topic);
        int Delete(int id);
    }
}
