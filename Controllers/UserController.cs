using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend_Controller_Burhan.Services;
using Backend_Controller_Burhan.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend_Controller_Burhan.Repository;
using Microsoft.AspNetCore.Authorization;
using Backend_Controller_Burhan.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Linq.Expressions;
using System.Net.Mail;

namespace Backend_Controller_Burhan.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userservices;
        private IConfiguration _configuration;
        //private IHttpContextAccessor _httpContextAccessor;
        //private  UserManager<IdentityUser> _userManager;

        public UserController(IUserService userservices, IConfiguration configuration)
        {
            _userservices = userservices;
            _configuration = configuration;
            //_httpContextAccessor = httpContextAccessor;
            //_userManager = userManager;  
        }

        // POST /api/users
        [HttpPost("user")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            var old = _userservices.Register(userDto.AsUser());
            if (old == null)
                return NotFound("already registered");
            return Ok(userDto);
        }

        // GET /api/user
        [HttpGet("user")]
        [Authorize]
        public IActionResult GetCurrent()
        {
            var currentUser = GetCurrentUser();

            return Ok(currentUser);
        }
        // PUT /api/user
        [HttpPut("user")]
        [Authorize]
        public IActionResult Update([FromBody] User newuser)
        {
            var result = _userservices.Update(newuser);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        
        private UserDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                var Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
                var CurrentUser = UserRepository.Users.FirstOrDefault(o => o.Email == Email).AsUserDto();
                return CurrentUser;
            }
            return null;
        }
    }
}

       

               
