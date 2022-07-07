using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{

    public class TopicRepository : ITopicRepository
    {
        private readonly forumdbContext _forumdbContext;

        public TopicRepository(forumdbContext forumdbContext)
        {
            this._forumdbContext = forumdbContext;
        }

        public List<Topic> FindAll()
        {
            return this._forumdbContext.Topics.ToList();
        }

        public Topic FindById(int id)
        {
            return this._forumdbContext.Topics.FirstOrDefault(x => x.Idtopic == id);
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

            this._forumdbContext.Topics.Add(topic);
            this._forumdbContext.SaveChanges();

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

            this._forumdbContext.Topics.Update(topic);
            this._forumdbContext.SaveChanges();

            return topic;
        }

        public int Delete(int id)
        {
            this._forumdbContext.Topics.Remove(FindById(id));
            this._forumdbContext.SaveChanges();

            return id;
        }
    }
}
