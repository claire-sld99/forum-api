using System;
using System.Collections.Generic;

namespace forum_api.DataAccess.DataObjects
{
    public partial class Comment
    {
        public Comment()
        {
            Topics = new HashSet<Topic>();
        }

        public int Idcomment { get; set; }
        public string Author { get; set; } = null!;
        public DateTime? DateCreation { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string Content { get; set; } = null!;

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
