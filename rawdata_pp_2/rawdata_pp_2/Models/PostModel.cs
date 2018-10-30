using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rawdata_pp_2.Models
{
    public class PostModel
    {
        public string Url { get; set; }
        public int TypeId { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int Score { get; set; }
        public string PostText { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int AuthorId { get; set; }
        public string Comment { get; set; }
    }
}
