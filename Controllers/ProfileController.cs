using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend_Controller_Burhan.Controllers
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

            var result = _profileService.getprofile(username).AsProfileDto();

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

        // POST /api/profiles/:username/follow
        [HttpPost("{username}/{follow}")]
        [Authorize]
        public IActionResult FollowOp([FromRoute]string username, bool follow)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = identity.Claims;
            var Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
            var CurrentUser = UserRepository.Users.FirstOrDefault(o => o.Email == Email).AsUserDto();
            var result = _profileService.followOp(username,CurrentUser, follow).AsProfileDto();

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

        // DELETE /api/profiles/:username/follow
        [HttpDelete("{username}/{follow}")]
        [Authorize]
        public IActionResult UnFollowOp([FromRoute] string username, bool follow)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = identity.Claims;
            var Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
            var CurrentUser = UserRepository.Users.FirstOrDefault(o => o.Email == Email).AsUserDto();
            var result = _profileService.followOp(username, CurrentUser, follow).AsProfileDto();

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

    }
}
