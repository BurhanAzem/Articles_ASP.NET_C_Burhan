using Backend_Controller_Burhan.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Dtos;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Backend_Controller_Burhan.Services
{
    public  class ArticleService : IArticaleService
    {
        DemoContext _demoContext;   
        public ArticleService(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public Article Create(Article article, User user)
        {
            article.createdAt = DateTime.Now;   
            article.updatedAt = DateTime.Now;
            article.slug = StringExtensions.Slugify(article.title);
            article.author = user.profile;
            _demoContext.Articles.ToList().Add(article);
            return article;
        }
        public Article Update(Article newarticle, string slug)
        {
            var oldarticle = _demoContext.Articles.ToList().FirstOrDefault(x => x.slug.Equals(slug));
            if (oldarticle == null)
                return null;
            oldarticle.title = newarticle.title;
            oldarticle.body = newarticle.body;
            oldarticle.description = newarticle.description;
            return oldarticle;
        }
        public bool Delete(string slug)
        {
            var article1 = _demoContext.Articles.ToList().FirstOrDefault(x => x.slug.Equals(slug));
            if(article1 == null)
                return false;
            _demoContext.Articles.ToList().Remove(article1); 
            return true;    
        }
        public List<Article> GetAll()
        {
            return _demoContext.Articles.ToList();
        }
        public Article GetByslug(string slug)
        {
            var article = _demoContext.Articles.ToList().FirstOrDefault(x => x.slug == slug);
            return article;
        }
        public Article favoriteOp(string slug,User CurrentUserDto, bool favorite)
        {
            var article = _demoContext.Articles.ToList().FirstOrDefault(O => O.slug == slug);
            if (article == null) return null;
            if (favorite) article.favorite.Add(CurrentUserDto.profile);
            else article.favorite.Remove(CurrentUserDto.profile);
            return article;
        }

        public Comment AddComment(string slug,Comment comment)
        {
            Random a = new Random();     
            int MyNumber = 0;
            MyNumber = a.Next(0, 10);
            var article = _demoContext.Articles.ToList().FirstOrDefault(o => o.slug == slug);
            if (article == null)
                return null;
            comment.updatedAt = DateTime.Now;   
            comment.createdAt = DateTime.Now;
            comment.id = MyNumber;    
            article.comment.Add(comment);
            return comment;
        }
        public bool DeleteComment(string slug, Comment comment)
        {
            var article = _demoContext.Articles.ToList().FirstOrDefault(o => o.slug == slug);
            if (article == null)
                return false;
            article.comment.Remove(comment);
            return true;
        }

        public List<Article> GetFeed()
        {
            var result = _demoContext.Articles.ToList().FindAll(o => !o.author.follow.IsNullOrEmpty());
            return result;
        }

        public List<Article> GetByAuthor(string author)
        {
            var result = _demoContext.Articles.ToList().FindAll(o => o.author.username == author);
            return result;
        }

        public List<Article> GetByUserName(string userName)
        {
            var result = ArticleRepository.Articles.FindAll(o => o.favorite.FirstOrDefault(o => o.username == userName).username == userName);
            return result;
        }
    }
}
