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
            DataService service = new DataService();
            return Ok(service.GetPostById(id));
        }

    }
}