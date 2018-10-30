using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace DomainModel
{
    public class DataService
    {
        public Post GetPostById(int id)
        {
            using(var db = new StackoverflowContext())
            {
                return db.posts.FirstOrDefault(x => x.Id== id);
            }
        }
    }
}
