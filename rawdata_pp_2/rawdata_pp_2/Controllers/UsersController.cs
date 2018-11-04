using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rawdata_pp_2.Models;
using rawdata_pp_2.Service;

namespace rawdata_pp_2.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IDataService _dataService;
        public PasswordService _passwordService = new PasswordService();
        public int PswSize = 256;

        public UsersController(IDataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _dataService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(UserRegistrationModel model)
        {
            //int.TryParse(PswSize, out var size);
            var salt = PasswordService.GenerateSalt(PswSize);
            var pwd = PasswordService.HashPassword(model.UserPassword, salt, PswSize);
            _dataService.createUser(pwd, model.UserName, model.Age, model.DisplayName, model.UserLocation, salt);
            return Ok();
        }
    }
}