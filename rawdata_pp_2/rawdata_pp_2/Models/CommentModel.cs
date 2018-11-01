using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rawdata_pp_2.Models
{
    public class CommentModel
    {
        public string Url { get; set; }
        public int PostId { get; set; }
        public int Score { get; set; }
        public string CommentText { get; set; }
        public DateTime CreationDate { get; set; }
        public int AuthorId { get; set; }
    }
}
