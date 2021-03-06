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
using System.Text.RegularExpressions;

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

        [HttpPost("register")]
        public IActionResult CreateUser(UserRegistrationModel model)
        {
            int.TryParse(_configuration["security:pwdsize"], out var size);
            var salt = PasswordService.GenerateSalt(size);
            var pwd = PasswordService.HashPassword(model.UserPassword, salt, size);

            var checkUser = _dataService.GetUserByUsername(model.UserName);
            if(checkUser != null)
            {
                return Ok("User already exists");
            }

            if(checkUser == null)
            {
                _dataService.createUser(pwd, model.UserName, model.Age, model.DisplayName, model.UserLocation, salt);
            }
            var response = new
            {
                model.UserName, 
                model.DisplayName
            };
            return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult UserLogin([FromBody] UserLoginModel model)
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

        
    }
}