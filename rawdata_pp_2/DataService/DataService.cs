using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace DomainModel
{
    public class DataService : IDataService
    {
        public Post GetPostById(int id)
        {
            using (var db = new StackoverflowContext())
            {
                return db.posts.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Post> GetPostsByTags(string tagSearch)
        {
            using (var db = new StackoverflowContext())
            {
                return db.posts.Where(x => x.Tags.Contains(tagSearch)).ToList();
            }
        }

        public List<Post> getPosts()
        {
            using (var db = new StackoverflowContext())
            {
                List<Post> list = db.posts.ToList();
                return list;
            }
        }

        public void createNewUser(string _userpassword, string _userName, int _age, string _displayName, string _userLocation, DateTime _creationDate)
        {
            using (var db = new StackoverflowContext())
            {
                db.user.Add(new User
                {
                    UserPassword = _userpassword,
                    Username = _userName,
                    Age = _age,
                    DisplayName = _displayName,
                    UserLocation = _userLocation,
                    CreationDate = _creationDate
                });
                db.SaveChanges();
            }
        }
    }
}
