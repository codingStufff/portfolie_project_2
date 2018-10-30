using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel;
using AutoMapper;
using rawdata_pp_2.Models;

namespace rawdata_pp_2.Controllers
{
    [Route("api/posts/")]
    [ApiController]
    public class PostController : Controller
    {
        IDataService _dataService;
        public PostController(IDataService dataService)
        {
            _dataService = dataService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public string postController()
        //{
        //    return "helloWorld";
        //}
        //[HttpGet("{id}", Name = nameof(GetPost))]
        //public IActionResult GetPost(int id)
        //{
        //    var post = _dataService.GetPostById(id);
        //    if (post == null) return NotFound();
        //    var model = Mapper.Map<PostModel>(post);

        //    model.Url = Url.Link(nameof(GetPost), new { id = post.Id });
        //    //model.Category = Url.Link(nameof(CategoriesController.GetCategory), new { id = product.Category.Id });
        //    return Ok(model);
        //}
        [HttpGet("{tagSearch}", Name = nameof(GetPostsByTags))]
        public IActionResult GetPostsByTags(string tagSearch)
        {
            var post = _dataService.GetPostsByTags(tagSearch);
         
            //var model = Mapper.Map<PostModel>(post);
            //foreach (var item in post)
            //{

            //}

            return Ok(post);

        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _dataService.createNewUser(user.UserPassword, user.Username, user.Age, user.DisplayName, user.UserLocation);

            return Ok(user);
        }
    }
}