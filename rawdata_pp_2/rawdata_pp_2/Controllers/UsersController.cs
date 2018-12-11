﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        //public PasswordService _passwordService = new PasswordService();
        // this needs to be in the configuration file!!! safely hidden away
        //public int PswSize = 256;


        public UsersController(IDataService dataService, IConfiguration configuration)
        {
            _configuration = configuration;
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
            int.TryParse(_configuration["security:pwdsize"], out var size);
            var salt = PasswordService.GenerateSalt(size);
            var pwd = PasswordService.HashPassword(model.UserPassword, salt, size);
            _dataService.createUser(pwd, model.UserName, model.Age, model.DisplayName, model.UserLocation, salt);
            return Ok();
        }
        [HttpPost("login")]
<<<<<<< HEAD
        public IActionResult UserLogin([FromBody] UserLoginModel model)
=======
        public IActionResult UserLogin([FromBody]UserLoginModel model)
>>>>>>> f2771f542131f92ed5671abfdfe1a8964e97de46
        {
            // this needs to be in the configuration file!! hidden safely away

            //string key = "AasdasdaASFF78SDsdasDSADAF";
            int.TryParse(_configuration["security:pwdsize"], out var size);
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

            var tempUser = _dataService.GetUserByUsername(model.UserName);

            /* Test example
            if(tempUser != null){
                return Ok("UserExists");
            }
            */


            if (tempUser == null)
            {
                return BadRequest("User doesn't exist");
            }

            var pwd = PasswordService.HashPassword(model.UserPassword, tempUser.Salt, size);

            //Base Case
            if (pwd != tempUser.UserPassword){
                return BadRequest("Password wasn't correct");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["security:key"]);

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
                tempUser.Id,
                token
            };
            return Ok(response);
        }

        [HttpPost("bookmark", Name = nameof(CreateBookmark))]
        public IActionResult CreateBookmark(int postid, int userid, string annotation)
        {
           var result = _dataService.BookmarkPost(postid, userid, annotation);
            if (result == 0) return BadRequest("bookmark failed, try again");
            else return Ok("bookmark made");
        }
    }
}