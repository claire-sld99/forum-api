using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{


    public class TopicRepository
    {
        public List<Topic> FindAll()
        {
                List<Topic> topics = DataAccess.DataObjects.Topic.GetAll();
        }

        public virtual Topic FindById(int id)
        {
            return new Topic();
        }

        public Topic Create(Topic topic)
        {
            topic = new Topic()
            {
                Title = topic.Title,
                Author = topic.Author,
                DateCreation = topic.DateCreation,
                DateUpdate = topic.DateUpdate
            };
            return topic;
        }

        public Topic Update(Topic topic)
        {
            topic = new Topic()
            {
                Title = topic.Title,
                Author = topic.Author,
                DateCreation = topic.DateCreation,
                DateUpdate = topic.DateUpdate
            };
            return topic;
        }

        public int Delete(int id)
        {
            Topic.DeleteOne(topic => topic.Id == id);
            return id;
        }
    }
}
