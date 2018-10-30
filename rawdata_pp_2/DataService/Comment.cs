using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int Score { get; set; }
        public string CommentText { get; set; }
        public DateTime CreationDate { get; set; }
        public int AuthorId { get; set; }
    }
}
