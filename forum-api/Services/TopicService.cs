using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;

namespace forum_api.Services
{
    public class TopicService
    {
        public TopicRepository repo;

        public TopicService(TopicRepository repo)
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
            Topic newTopic = new Topic();
            return newTopic;
        }

        public Topic Update(Topic topic)
        {
            Topic newTopic = new Topic();
            return newTopic;
        }

        public int Delete(int id)
        {
            return this.repo.Delete(id);
        }
    }
}
