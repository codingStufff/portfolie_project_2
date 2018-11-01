using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace rawdata_pp_2.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly IDataService _dataService;
        public CommentsController(IDataService service)
        {
            _dataService = service;
        }

        [HttpGet("{id}", Name = nameof(GetComment))]
        public IActionResult GetComment(int id)
        {
            var comment= _dataService.GetComment(id);
            if (comment == null) return NotFound();

            return Ok(comment);
        }
    }
}