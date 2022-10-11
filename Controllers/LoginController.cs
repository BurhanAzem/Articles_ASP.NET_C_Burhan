using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Controller_Burhan.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;  
        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService; 
        }
        // POST /api/users/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                var userDto = user.AsUserDto(); 
                userDto.token = token;
                return Ok(userDto);
            }

            return NotFound("User not found");
        }

        private string Generate(User user)
        {

                var claims = new[]
                {
            new Claim(ClaimTypes.Dns, user.password),
            new Claim(ClaimTypes.Email, user.email)

                };

                var token = new JwtSecurityToken
                    (
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(100),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"])),
                        SecurityAlgorithms.HmacSha256)
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenString;
            }
            

           
        

        private User Authenticate(UserLogin userLogin)
        {
            var currentUser = UserRepository.Users.FirstOrDefault(x => x.email.ToLower() ==
                userLogin.email.ToLower() && x.password == userLogin.password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;

        }
    }
}
