using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rawdata_pp_2.Models
{
    public class BookmarkModel
    {
        public string URL { get; set; }
        public int userid { get; set; }
        public string annotation { get; set; }
        public DateTime markingDate { get; set; }
    }
}
