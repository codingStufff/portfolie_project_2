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

        //public List<Post> GetPosts(int page, int pageSize)
        //{
        //    using (var db = new StackoverflowContext())
        //    {
        //        List<Post> list = db.posts.ToList();
        //        return list;
        //    }
        //}

        public void CreateNewUser(string _userpassword, string _userName, int _age, string _displayName, string _userLocation)
        {
            using (var db = new StackoverflowContext())
            {
                db.user.Add(new User
                {
                    Id = 1,
                    UserPassword = _userpassword,
                    Username = _userName,
                    Age = _age,
                    DisplayName = _displayName,
                    UserLocation = _userLocation,
                    CreationDate = new DateTime().Date
                });
                db.SaveChanges();
            }
        }

        public List<Post> GetPosts(int page, int pageSize)
        {
            using(var db= new StackoverflowContext())
            {
                return db.posts
                    .Include(x => x.Comment)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        public int GetNumberOfPosts()
        {
            using (var db = new StackoverflowContext())
            {
                return db.posts.Count();
            }
        }

        public List<User> GetUsers()
        {
            using(var db = new StackoverflowContext())
            {
                return db.user.ToList();
            }
        }

        public Comment GetComment(int id)
        {
            using(var db = new StackoverflowContext())
            {
               return db.comment.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Post> GetPosts(Args args)
        {
            using (var db = new StackoverflowContext())
            {
                var query = db.posts
                    .Include(x => x.Comment)
                .Skip(args.Page * args.PageSize)
                .Take(args.PageSize);

                //if (!string.IsNullOrEmpty(args.Tag))
                //{
                //    query.Where(x => x.Tags.Contains(args.Tag));
                //}

                //query.Skip(args.Page * args.PageSize)
                //    .Take(args.PageSize);
                return query.ToList();
            }
        }
    }
}
