using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;

namespace forum_api.Services
{
    public class TopicService
    {
        public ITopicRepository repo;

        public TopicService(ITopicRepository repo)
        {
            this.repo = repo;
        }

        public List<Topic> FindAll()
        {
            return this.repo.FindAll();
        }

        public Topic FindById(int id)
        {
            return this.repo.FindById(id);
        }

        public Topic Create(Topic topic)
        {
            return this.repo.Create(topic);
        }

        public Topic Update(Topic topic)
        {
            return this.repo.Update(topic);
        }

        public int Delete(int id)
        {
            return this.repo.Delete(id);
        }
    }
}
