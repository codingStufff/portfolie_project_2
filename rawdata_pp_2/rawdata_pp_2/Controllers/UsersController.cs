using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public IActionResult UserLogin(UserLoginModel model)
        {
            string key = "AasdasdaASFF78SDsdasDSADAF";

            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.UserPassword))
            {
                return BadRequest("Both username and password needs to be filled");
            }
            //when we get the configuration file woeking we need to use this if statement
            /*if(size == 0)
            {
                //we fucked something up!
                return BadRequest();
            }*/


            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(key);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescription));

            var response = new
            {
                model.UserName,
                token
            };
            return Ok(response);
        }
    }
}