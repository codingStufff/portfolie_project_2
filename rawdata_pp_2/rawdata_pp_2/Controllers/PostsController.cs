using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel;
using AutoMapper;
using rawdata_pp_2.Models;
using Microsoft.AspNetCore.Authorization;


namespace rawdata_pp_2.Controllers
{

    [Route("api/posts")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IDataService _dataService;
        public PostsController(IDataService dataService)
        {
            _dataService = dataService;
        }
        public IActionResult Index()
        {
            return View();
        }

       [HttpGet("bestMatch/{searchString}", Name = nameof(BestMatch))]
        public IActionResult BestMatch(string searchString, int page, int pageSize = 10 )
        {
            var resultObject = _dataService.wordToWordSearch(searchString, page, pageSize);//.list.Select(CreateSearchList);
            var listOfPosts = resultObject.list.Select(CreateSearchList);
            var searchType = "bestMatch/";


            var numberOfItems = resultObject.count;//_dataService.GetNumberOfPosts();
            var totalPages = CalculateTotalPages(pageSize, numberOfItems);

            var result = new
            {
                NumberOfItems = numberOfItems,
                NumberOfPages = totalPages,
                First = CreateLink(page, pageSize, searchType),
                PreviousPage = CreateLinkToPrevPage(page, pageSize, searchType),
                NextPage = CreateLinkToNextPage(page, pageSize, totalPages, searchType),
                Last = CreateLink(totalPages - 1, pageSize, searchType),
                Items = listOfPosts
            };

            return Ok(result);
            //return Ok(results);
        }

        [HttpGet ("exactMatch/{searchString}", Name = nameof(ExactMatch))]
        public IActionResult ExactMatch(string searchString, int page, int pageSize = 10)
        {
            var resultObject = _dataService.ExactMatch(searchString, page, pageSize);//.Select(CreateExactSearchListModel);
            var listOfPosts = resultObject.list.Select(CreateExactSearchListModel);
            string searchType = "exactMatch/";

            
            var numberOfItems = resultObject.count;//_dataService.GetNumberOfPosts();
            var totalPages = CalculateTotalPages(pageSize, numberOfItems);

            var result = new
            {
                NumberOfItems = numberOfItems,
                NumberOfPages = totalPages,
                First = CreateLink(page, pageSize, searchType),
                PreviousPage = CreateLinkToPrevPage(page, pageSize, searchType),
                NextPage = CreateLinkToNextPage(page, pageSize, totalPages, searchType),
                Last = CreateLink(totalPages - 1, pageSize, searchType),
                Items = listOfPosts
            };

            return Ok(result);
        }

        [HttpGet ("weightedSearch/{searchString}", Name = nameof(WeightedSearch))]
        public IActionResult WeightedSearch(string searchString, int page, int pageSize = 10)
        {

            var resultObject = _dataService.WeightedSearch(searchString, page, pageSize);//.Select(CreateSearchList);
            var listOfPosts = resultObject.list.Select(CreateSearchList);

            var searchType = "weightedSearch/";

            var numberOfItems = resultObject.count;//_dataService.GetNumberOfPosts();
            var totalPages = CalculateTotalPages(pageSize, numberOfItems);

            var result = new
            {
                NumberOfItems = numberOfItems,
                NumberOfPages = totalPages,
                First = CreateLink(page, pageSize, searchType),
                PreviousPage = CreateLinkToPrevPage(page, pageSize, searchType),
                NextPage = CreateLinkToNextPage(page, pageSize, totalPages, searchType),
                Last = CreateLink(totalPages - 1, pageSize, searchType),
                Items = listOfPosts
            };

            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetPost))]
        public IActionResult GetPost(int id)
        {
            var post = _dataService.GetPostById(id);
            if (post == null) return NotFound();
            var model = Mapper.Map<PostModel>(post);
      
            model.Url = Url.Link(nameof(GetPost), new { id = post.Id });
           // model.Comment = Url.Link(nameof(CommentsController.GetComment), new { id = post.Comment.Id });
            return Ok(model);
        }

        [HttpGet("tag/{tagName}", Name = nameof(GetPostsByTags))]
        public IActionResult GetPostsByTags(string tagName)
        {
            var post = _dataService.GetPostsByTags(tagName);
            return Ok(post);
        }

       
        

        //[HttpGet(Name = nameof(GetPosts))]
        //[Authorize]
        //public IActionResult GetPosts([FromQuery] Args args)
        //{
        //    var posts = _dataService.GetPosts(args)
        //            .Select(CreatePostList);
            
        //        var numberOfItems = _dataService.GetNumberOfPosts();
        //        var totalPages = CalculateTotalPages(args.PageSize, numberOfItems);
            
        //        var result = new
        //        {
        //            NumberOfItems = numberOfItems,
        //            NumberOfPages = totalPages,
        //            First = CreateLink(args.Page, args.PageSize),
        //            PreviousPage = CreateLinkToPrevPage(args.Page, args.PageSize),
        //            NextPage = CreateLinkToNextPage(args.Page, args.PageSize, totalPages),
        //            Last = CreateLink(totalPages - 1, args.PageSize),
        //            Items = posts
        //        };

        //        return Ok(result);
            
        //}

        // assist methods

        private PostListModel CreatePostList(Post post)
        {
            var model = Mapper.Map<PostListModel>(post);
            model.url = Url.Link(nameof(GetPost), new { id = post.Id });

            if (post.Comment != null)
            {
                var id = post.Comment.Id;
                model.Comment = Url.Link(nameof(CommentsController.GetComment), id);
            }
            
            return model;
        }

        private SearchResultListModel CreateSearchList(SearchResult sr)
        {
            var model = Mapper.Map<SearchResultListModel>(sr);
            model.URL = Url.Link(nameof(GetPost), new { id = sr.postid });
            return model;
        }

        private ExactSearchResultListModel CreateExactSearchListModel(ExactMatchResult sr)
        {
            var model = Mapper.Map<ExactSearchResultListModel>(sr);
            model.url = Url.Link(nameof(GetPost), new { id = sr.postid });
            return model;
        }
     

        private static int CalculateTotalPages(int pageSize, int numberOfItems)
        {

            return (int)Math.Ceiling((double)numberOfItems / pageSize);
        }

        private string CreateLink(int page, int pageSize, string searchType)
        {
            if(searchType == "exactMatch/")
            {
                return Url.Link(nameof(ExactMatch), new { page, pageSize });
            }
           else if (searchType== "bestMatch/")
            {
                return Url.Link(nameof(BestMatch), new { page, pageSize });
            }
            else if(searchType == "weightedSearch/")
            {
                return Url.Link(nameof(WeightedSearch), new { page, pageSize });
            }
            else return null;
        }

        private string CreateLinkToPrevPage(int page, int pageSize, string searchType)
        {
            return page == 0 ? null : CreateLink(page - 1, pageSize, searchType);
        }

        private string CreateLinkToNextPage(int page, int pageSize, int numberOfPages, string searchType)
        {
            return page >= numberOfPages - 1 ? null : CreateLink(page = page + 1, pageSize, searchType);
        }
    }
}