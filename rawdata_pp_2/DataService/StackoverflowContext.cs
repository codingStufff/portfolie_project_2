using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace DomainModel
{
    //public class UserID
    //{
    //    public int Id { get; set; }
    //}
    public class StackoverflowContext : DbContext
    {
        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comment { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Bookmark> bookmark { get; set; }

        public DbQuery<SearchResult> SearchResults { get; set; }
        public DbQuery<ExactMatchResult> ExactSearchResults { get; set; }
        public DbQuery<WordCloud> WordCloudResults { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;db=raw11;uid=raw11;pwd=a.iwA8IN");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // mapping the posts table data from the database
            builder.Entity<Post>().ToTable("posts");
            builder.Entity<Post>().Property(x => x.Id).HasColumnName("postid");
            builder.Entity<Post>().Property(x => x.TypeId).HasColumnName("typeid");
            builder.Entity<Post>().Property(x => x.AcceptedAnswerId).HasColumnName("acceptedanswerid");
            builder.Entity<Post>().Property(x => x.CreationDate).HasColumnName("creationdate");
            builder.Entity<Post>().Property(x => x.Score).HasColumnName("score");
            builder.Entity<Post>().Property(x => x.PostText).HasColumnName("posttext");
            builder.Entity<Post>().Property(x => x.ClosedDate).HasColumnName("closeddate");
            builder.Entity<Post>().Property(x => x.Title).HasColumnName("title");
            builder.Entity<Post>().Property(x => x.Tags).HasColumnName("tags");
            builder.Entity<Post>().Property(x => x.AuthorId).HasColumnName("author_id");

            // mapping the comments table from the database
            builder.Entity<Comment>().ToTable("comments");
            builder.Entity<Comment>().Property(x => x.Id).HasColumnName("id");
            builder.Entity<Comment>().Property(x => x.PostId).HasColumnName("postid");
            builder.Entity<Comment>().Property(x => x.Score).HasColumnName("score");
            builder.Entity<Comment>().Property(x => x.CommentText).HasColumnName("commenttext");
            builder.Entity<Comment>().Property(x => x.CreationDate).HasColumnName("creationdate");
            builder.Entity<Comment>().Property(x => x.AuthorId).HasColumnName("author_id");

            // mapping authors from the author table from the database
            builder.Entity<Author>().ToTable("author");
            builder.Entity<Author>().Property(x => x.Id).HasColumnName("id");
            builder.Entity<Author>().Property(x => x.Age).HasColumnName("age");
            builder.Entity<Author>().Property(x => x.DisplayName).HasColumnName("displayname");
            builder.Entity<Author>().Property(x => x.AuthorLocation).HasColumnName("authorlocation");
            builder.Entity<Author>().Property(x => x.CreationDate).HasColumnName("creatioondate");

            // mapping users from the users table from the database
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().Property(x => x.Id).HasColumnName("id");
            builder.Entity<User>().Property(x => x.UserPassword).HasColumnName("userpassword");
            builder.Entity<User>().Property(x => x.Username).HasColumnName("username");
            builder.Entity<User>().Property(x => x.Age).HasColumnName("age");
            builder.Entity<User>().Property(x => x.DisplayName).HasColumnName("displayname");
            builder.Entity<User>().Property(x => x.UserLocation).HasColumnName("userlocation");
            builder.Entity<User>().Property(x => x.CreationDate).HasColumnName("creationdate");
            builder.Entity<User>().Property(x => x.Salt).HasColumnName("salt");

            //mapping bookmark from the mark table from the database
            builder.Entity<Bookmark>().ToTable("mark");
            //modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });
            builder.Entity<Bookmark>().HasKey(bm => new { bm.postid, bm.userid });
            builder.Entity<Bookmark>().Property(x => x.postid).HasColumnName("post_id");
            builder.Entity<Bookmark>().Property(x => x.userid).HasColumnName("user_id");
            builder.Entity<Bookmark>().Property(x => x.annotation).HasColumnName("annotation");
            builder.Entity<Bookmark>().Property(x => x.markingdate).HasColumnName("markingdate");
            
            //search results for bestmatch and weightsearch
            builder.Query<SearchResult>().Property(x => x.postid).HasColumnName("postid");
            builder.Query<SearchResult>().Property(x => x.rank).HasColumnName("rank");
            builder.Query<SearchResult>().Property(x => x.body).HasColumnName("body");
           
            //search results for exactmatch
            builder.Query<ExactMatchResult>().Property(x => x.postid).HasColumnName("postid");
            builder.Query<ExactMatchResult>().Property(x => x.body).HasColumnName("body");

            // search results for word cloud
            builder.Query<WordCloud>().Property(x => x.word).HasColumnName("word");
            builder.Query<WordCloud>().Property(x => x.grade).HasColumnName("grade1");
        }
        public static readonly LoggerFactory MyLoggerFactory
        = new LoggerFactory(new[]
        {
        new ConsoleLoggerProvider((category, level)
            => category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information, true)
        });



    }

}
