using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Bookmark
    {
        public int postid { get; set; }
        public int userid { get; set; }
        public string annotation { get; set; }
        public DateTime markingdate { get; set; }
    }
}
