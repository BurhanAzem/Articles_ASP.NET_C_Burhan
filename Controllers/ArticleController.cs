using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public IActionResult Create(ArticleDto articleDto)
        {
            var user = GetCurrentUser();
            var result = _articaleService.Create(articleDto.AsArticle(user),user).AsArticleDto(user);
            return Ok(result);
        }


        // GET /api/articles                     *Not without query --later--
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var user = GetCurrentUser();
            var result = _articaleService.GetAll().Select(x => x.AsArticleDto(user));
            return Ok(result);
        }

        // GET /api/articles/feed
        [HttpGet("feed")]
        [Authorize]
        public IActionResult GetFeed()
        {
            var user = GetCurrentUser();
            var result = ArticleRepository.Articles.FindAll(o => !o.author.profile.follow.IsNullOrEmpty()).Select(x => x.AsArticleDto(user));
            return Ok(result);
        }

        // GET /api/articles?author=...
        [HttpGet("author")]
        public IActionResult GetByAuthor([FromQuery] string author)
        {
            var user = GetCurrentUser();
            var result = ArticleRepository.Articles.FindAll(o => o.author.profile.username == author).Select(x => x.AsArticleDto(user));
            return Ok(result);
        }

        // GET /api/articles?UserName=...
        [HttpGet("username")]
        public IActionResult GetByUsername([FromQuery] string username)
        {
            var user = GetCurrentUser();
            var result = ArticleRepository.Articles.FindAll(o => o.favorite.FirstOrDefault(o => o.profile.username == username).profile.username == username).Select(x => x.AsArticleDto(user));
            return Ok(result);
        }

        // GET /api/articles?tagList=...
        [HttpGet("tagList")]
        public IActionResult GetByTagList([FromQuery] string tag)
        {
            var user = GetCurrentUser();
            var result = ArticleRepository.Articles.FindAll(o => o.tagList.Contains(tag)).Select(x => x.AsArticleDto(user));
            return Ok(result);
        }

        // PUT /api/articles/:slug
        [HttpPut("{slug}")]
        [Authorize]
        public IActionResult Update(string slug, [FromBody]ArticleDto articleDto)
        {
            var user = GetCurrentUser();
            var result = _articaleService.Update(articleDto.AsArticle(user), slug).AsArticleDto(user);
            if (result is null) return NotFound("Article not found");
            return Ok(result);
        }

        //DELETE /api/articles/:slug
        [HttpDelete("{slug}")]
        [Authorize]
        public IActionResult Delete(string slug)
        {
            var result = _articaleService.Delete(slug);
            if (result is false) return NotFound("something wrong");
            return Ok("Done");
        }
        // GET /api/articles/:slug
        [HttpGet("{slug}")]
        [Authorize]
        public IActionResult Get(string slug)
        {
            var user = GetCurrentUser(); 
            var result = _articaleService.GetByslug(slug).AsArticleDto(user);
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
        public IActionResult AddComments(string slug, [FromBody] CommentDto comments)
        {
            var user = GetCurrentUser();
            var result = _articaleService.AddComment(slug, comments.AsComment(user));
            if (result == null)
                return Ok("not exist");
            return Ok(result);
        }

        // DELETE /api/articles/:slug/comments/:id
        [HttpDelete("{slug}/comments/{commentsId}")]
        [Authorize]
        public IActionResult DeleteComments(string slug, int id)
        {
            var result = _articaleService.GetByslug(slug).comment.Remove(_articaleService.GetByslug(slug).comment.FirstOrDefault(o => o.id.Equals(id)));
            return Ok("Done");
        }

        // POST /api/articles/:slug/favorite
        [HttpPost("{slug}/favorite")]
        [Authorize]
        public IActionResult Favorite(string slug)
        {
            var user = GetCurrentUser();

            var result = _articaleService.favoriteOp(slug, user, true).AsArticleDto(user);

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }

        // DELETE /api/articles/:slug/favorite
        [HttpDelete("{slug}/favorite")]
        [Authorize]
        public IActionResult UnFavorite(string slug)
        {
            var user = GetCurrentUser();

            var result = _articaleService.favoriteOp(slug, user, false).AsArticleDto(user);

            if (result == null)
                return NotFound("profil not found");

            return Ok(result);
        }
        [HttpGet]
        [Route("tags")]
        public IActionResult GetTags()
        {
            return Ok(ArticleRepository.Articles.First().tagList);
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
