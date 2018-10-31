using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rawdata_pp_2.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IDataService _dataService;
        public UsersController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _dataService.createNewUser(user.UserPassword, user.Username, user.Age, user.DisplayName, user.UserLocation);
            return Ok(user);
        }
    }
}