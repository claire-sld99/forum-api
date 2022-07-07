using forum_api.DataAccess.DataObjects;

namespace forum_api.Repositories
{

        public class CommentRepository : ICommentRepository
        {
            private readonly forumdbContext _forumdbContext;

            public CommentRepository(forumdbContext forumdbContext)
            {
                this._forumdbContext = forumdbContext;
            }

            public List<Comment> FindAll()
            {
                return this._forumdbContext.Comments.ToList();
            }

            public Comment FindById(int id)
            {
                return this._forumdbContext.Comments.FirstOrDefault(x => x.Idcomment == id);
            }

            public Comment Create(Comment comment)
            {
            comment = new Comment()
                {
                    Content = comment.Content,
                    Author = comment.Author,
                    DateCreation = comment.DateCreation,
                    DateUpdate = comment.DateUpdate
                };

                this._forumdbContext.Comments.Add(comment);
                this._forumdbContext.SaveChanges();

                return comment;
            }

            public Comment Update(Comment comment)
            {
                 comment = new Comment()
                {
                    Content = comment.Content,
                    Author = comment.Author,
                    DateCreation = comment.DateCreation,
                    DateUpdate = comment.DateUpdate
                };

                this._forumdbContext.Comments.Update(comment);
                this._forumdbContext.SaveChanges();

                return comment;
            }

            public int Delete(int id)
            {
                this._forumdbContext.Comments.Remove(FindById(id));
                this._forumdbContext.SaveChanges();

                return id;
            }
        }
    }
