using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Author
    { 
        public int Id { get; set; }
        public int Age { get; set; }
        public string DisplayName { get; set; }
        public string AuthorLocation { get; set; }
        public DateTime CreationDate { get; set; }
    
    }
}
