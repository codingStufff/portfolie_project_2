using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace DomainModel
{
    public class User
    {
        public int Id { get; set; }
        public string UserPassword { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string DisplayName { get; set; }
        public string UserLocation { get; set; }
        public DateTime CreationDate { get; set; }
        public string Salt { get; set; }
    }
}
