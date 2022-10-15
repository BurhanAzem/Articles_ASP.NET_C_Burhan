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
        private readonly  IConfiguration _configuration;
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
        [HttpPost("users")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            var user = _userservices.Register(userDto.AsUser());
            if (user == null)
                return NotFound("already registered");
            var Dto = user.AsUserDto();
            return Ok(Dto);
        }

        // GET /api/user
        [HttpGet("user")]
        [Authorize]
        public IActionResult GetCurrent()
        {
            var currentUser = GetCurrentUser();
            var userDto = currentUser.AsUserDto();
            if (userDto == null)
                return NotFound();
            return Ok(userDto);
        }
        // PUT /api/user
        [HttpPut("user")]
        [Authorize]
        public IActionResult Update([FromBody] UserDto newuser)
        {
            var result = _userservices.Update(newuser.AsUser());
            if (result == null)
                return NotFound();
            var userDto = result.AsUserDto();
            return Ok(userDto);
        }
        
        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                var Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
                var CurrentUser = _userservices.Get(Email);
                return CurrentUser;
            }
            return null;
        }
    }
}

       

               
