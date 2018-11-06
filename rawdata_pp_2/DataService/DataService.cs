using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DomainModel
{
    public class DataService : IDataService
    {
       // private string connectingString = "host=localhost;db=stackoverflow;uid=postgres;pwd=postgres";
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

        public User GetUserByUsername (string FetchUser){
            using (var db = new StackoverflowContext())
            {
                return db.user.FirstOrDefault(x => x.Username == FetchUser);
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
                              .Include(x => x.Comment).AsQueryable();


             // query = query.Where(x => x.Tags.Contains("sasdsdasd"));

                //query = query.Skip(args.Page * args.PageSize)
                //.Take(args.PageSize);
                /*
                if (!string.IsNullOrEmpty(args.Tag))
                {
                   query = query.Where(x => x.Tags.Contains(args.Tag));

                }
                */
                query = query.Skip(args.Page * args.PageSize)
                    .Take(args.PageSize);
                return query.ToList();
            }
        }
        public void createUser(string userPWD, string userName, int age, string displayName,string userLoc, string salt)
        {
            using (var db = new StackoverflowContext())
            {
                db.Database.ExecuteSqlCommand("select createusers({0},{1},{2},{3},{4},{5})", userPWD, userName, age, displayName, userLoc, salt);
                
            }   

        }
    }
}
