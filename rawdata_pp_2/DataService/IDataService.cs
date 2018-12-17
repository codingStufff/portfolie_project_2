using System;
using System.Collections.Generic;
using System.Text;
using static DomainModel.DataService;

namespace DomainModel
{
    public interface IDataService
    {
        Post GetPostById(int id);
        List<Post> GetPostsByTags(string tagSearch);
        //List<Post> GetPosts();
        void CreateNewUser(string _userpassword, string _userName, int _age, string _displayName, string _userLocation);
        List<Post> GetPosts(int page, int pageSize);
        List<Post> GetPosts(Args args);
        int GetNumberOfPosts();
        List<User> GetUsers();
        Comment GetComment(int id);
        void createUser(string userPWD, string userName, int age, string displayName, string userLoc, string salt);
        User GetUserByUsername(string FetchUser);
        //List<SearchResult> wordToWordSearch(string wordSearch);
        SearchResultObject/*List<SearchResult>*/ wordToWordSearch(string wordSearch, int page, int pageSize);
        SearchResultObjectExact ExactMatch(string wordSearch, int page, int pageSize);
        SearchResultObject WeightedSearch(string wordSearch, int page, int pageSize);
        int BookmarkPost(int postid, int userid, string annotation);
        List<WordCloud> GetWordCloud(string wordSearch);
        List<Bookmark> getBookmarks(int userid);
    }
}
