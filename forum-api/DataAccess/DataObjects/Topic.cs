using System;
using System.Collections.Generic;

namespace forum_api.DataAccess.DataObjects
{
    public partial class Topic
    {
             

        public int Idtopic { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? CommentId { get; set; }

        public virtual Comment? Comment { get; set; }

        public Topic(int idtopic, string title, string author,  DateTime dateTime1, DateTime dateTime2, int commentId, Comment comment)
        {
            this.Idtopic = idtopic;
            this.Title = title;
            this.Author = author;
            this.DateCreation = dateTime1;
            this.DateUpdate = dateTime2;
            this.CommentId = commentId;
            this.Comment = comment;
        }
    }
}
