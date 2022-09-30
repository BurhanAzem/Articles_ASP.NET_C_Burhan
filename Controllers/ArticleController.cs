using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;

namespace Backend_Controller_Burhan.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticaleService _articaleService;
        public ArticleController(IArticaleService articaleService)
        {
            _articaleService = articaleService;
        }

        //POST /api/articles
        [HttpPost]
        [Authorize]
        public IActionResult Create(Article article)
        {
            var result = _articaleService.Create(article).AsArticleDto();
            return Ok(result);
        }

        // GET /api/articles                     *Not without query --later--
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _articaleService.GetAll().Select(x => x.AsArticleDto());
            return Ok(result);
        }
        // PUT /api/articles/:slug
        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody]Article article)
        {
            var result = _articaleService.Update(article).AsArticleDto();
            if (result is null) return NotFound("Article not found");
            return Ok(result);
        }

        //DELETE /api/articles/:slug
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(string slug)
        {
            var result = _articaleService.Delete(slug);
            if (result is false) return NotFound("something wrong");
            return Ok(result);
        }
        // GET /api/articles/:slug
        [HttpGet("{slug}")]
        [Authorize]
        public IActionResult Get(string slug)
        {
            var result = _articaleService.GetByslug(slug).AsArticleDto();
            return Ok(result);
        }

        // GET /api/articles/:slug/comments
        [HttpGet("{slug}/comments")]
        [Authorize]
        public IActionResult GetComments(string slug)
        {
            var result = _articaleService.GetByslug(slug).comment.Select(x => x.AsCommentDto());
            return Ok(result);
        }

        // Post /api/articles/:slug/comments
        [HttpPost("{slug}/comments")]
        [Authorize]
        public IActionResult AddComments([FromBody]string slug, CommentDto commentDto)
        {
            var result = _articaleService.AddComment(slug, commentDto);
            return Ok(result);
        }

        // DELETE /api/articles/:slug/comments/:id
        [HttpDelete("{slug}/comments/{id}")]
        [Authorize]
        public IActionResult DeleteComments(string slug, int id)
        {
            var result = _articaleService.GetByslug(slug).comment.Remove(_articaleService.GetByslug(slug).comment.FirstOrDefault(o => o.Id.Equals(id)));
            return Ok();
        }

        // POST /api/articles/:slug/favorite
        [HttpPost("{slug}/{favorite}")]
        [Authorize]
        public IActionResult Favorite(string slug, bool favorite)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;


            var userClaims = identity.Claims;
            var Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
            var CurrentUser = UserRepository.Users.FirstOrDefault(o => o.Email == Email).AsUserDto();
            var result = _articaleService.favoriteOp(slug, CurrentUser, favorite).AsArticleDto();

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

        // DELETE /api/articles/:slug/favorite
        [HttpDelete("{slug}/{favorite}")]
        [Authorize]
        public IActionResult FavoriteOp([FromRoute] string slug, bool favorite)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;


            var userClaims = identity.Claims;
            var Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
            var CurrentUser = UserRepository.Users.FirstOrDefault(o => o.Email == Email).AsUserDto();


            var result = _articaleService.favoriteOp(slug, CurrentUser, favorite).AsArticleDto();

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

    }
}
