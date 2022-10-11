using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend_Controller_Burhan.Controllerss
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;    
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET /api/profiles/:username
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var user = GetCurrentUser();

            var result = _profileService.getprofile(username).AsProfileDto(user);

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

        // POST /api/profiles/:username/follow
        [HttpPost("{username}/{follow}")]
        [Authorize]
        public IActionResult FollowOp(string username, [FromRoute] string email)
        {
            var user = GetCurrentUser();
            var result = _profileService.followOp(username, email, true).AsProfileDto(user);

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

        // DELETE /api/profiles/:username/follow
        [HttpDelete("{username}/{follow}")]
        [Authorize]
        public IActionResult UnFollowOp(string email, [FromRoute] string username)
        {
            var user = GetCurrentUser();
            var result = _profileService.followOp(username, email, false).AsProfileDto(user);

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

        public User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                var Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
                var CurrentUser = UserRepository.Users.FirstOrDefault(o => o.email == Email);
                return CurrentUser;
            }
            return null;
        }
    }
}
