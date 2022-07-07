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
    }
}
