using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel;
namespace rawdata_pp_2.Controllers
{
    [Route("api/posts")]
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

        [HttpGet]
        public string postController()
        {
            return "helloWorld";
        }
        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
           
            return Ok(_dataService.GetPostById(id));
        }

    }
}