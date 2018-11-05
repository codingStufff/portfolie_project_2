using System;
using Xunit;
using DomainModel;
using System.Diagnostics;

namespace DomainModelTest
{
    public class UnitTest1
    {
        DataService _db = new DataService();

        [Fact]
        public void GetPostByInvalidId()
        {
            var post = _db.GetPostById(0);
            Assert.Null(post);
        }

        [Fact]
        public void getPostByValidId()
        {
            var post = _db.GetPostById(19);
            Assert.Equal(19, post.Id);
        }
    }
}
