using System;
using System.Collections.Generic;
using System.Text;
namespace DomainModel
{
    public interface IDataService
    {
        Post GetPostById(int id);
        List<Post> GetPostsByTags(string tagSearch);
        List<Post> getPosts();
        void createNewUser(string _userpassword, string _userName, int _age, string _displayName, string _userLocation);
        List<Post> GetPosts(int page, int pageSize);
        int GetNumberOfPosts();
    }
}
