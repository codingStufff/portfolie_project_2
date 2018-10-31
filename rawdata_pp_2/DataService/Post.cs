using System;
using Npgsql.EntityFrameworkCore;
namespace DomainModel
{
    public class Post
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int Score { get; set; }
        public string PostText { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int AuthorId { get; set; }
        public Comment Comment { get; set; }
    }
}
