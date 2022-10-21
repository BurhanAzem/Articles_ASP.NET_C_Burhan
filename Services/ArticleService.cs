using Backend_Controller_Burhan.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Dtos;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

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
            article.favoritesCount = article.favoritesCount + 1;    
            article.slug = StringExtensions.Slugify(article.title);
            article.author = user.profile;
            _demoContext.Articles.Add(article);
            _demoContext.SaveChanges();
            return article;
        }
        public Article Update(Article newarticle, string slug)
        {
            Article oldarticle = _demoContext.Articles.Where(x => x.slug == slug).FirstOrDefault();
            if (oldarticle == null)
                return null;
            oldarticle.title = newarticle.title;
            oldarticle.body = newarticle.body;
            oldarticle.description = newarticle.description;
            return oldarticle;
        }
        public bool Delete(string slug)
        {
            Article article = _demoContext.Articles.Where(x => x.slug == slug).FirstOrDefault();
            if (article == null)
                return false;
            _demoContext.Articles.Remove(article);
            _demoContext.SaveChanges();
            return true;    
        }
        public List<Article> GetAll()
        {
            List<Article> articles = _demoContext.Articles.ToList();
            return articles;
        }
        public Article GetByslug(string slug)
        {
            Article article = _demoContext.Articles.Where(x => x.slug == slug).FirstOrDefault();
            return article;
        }
        public Article favoriteOp(string slug,User CurrentUser, bool favorite)
        {
            Article article = _demoContext.Articles.Where(x => x.slug == slug).FirstOrDefault();
            if (article == null) return null;
            if (favorite)
            {
                Profile profile = CurrentUser.profile;
                article.favorite.Add(profile);
                _demoContext.Articles.Update(article);
                _demoContext.SaveChanges();
            }
            else
            {
                Profile profile = CurrentUser.profile;
                article.favorite.Remove(profile);
                _demoContext.Articles.Update(article);
                _demoContext.SaveChanges();
            }

            return article;
        }

        public Comment AddComment(string slug,Comment comment)
        {
            Random a = new Random();     
            int MyNumber = 0;
            MyNumber = a.Next(0, 10);
            Article article = _demoContext.Articles.Where(x => x.slug == slug).FirstOrDefault();
            if (article == null)
                return null;
            comment.updatedAt = DateTime.Now;   
            comment.createdAt = DateTime.Now;
            comment.id = MyNumber;    
            article.comment.Add(comment);
            _demoContext.Update(article);
            _demoContext.SaveChanges();
            return comment;
        }
        public bool DeleteComment(string slug, Comment comment)
        {
            Article article = _demoContext.Articles.Where(x => x.slug == slug).FirstOrDefault();
            if (article == null)
                return false;
            _demoContext.Comments.Remove(comment);
            _demoContext.Remove(comment);
            _demoContext.SaveChanges();
            return true;
        }

        public List<Article> GetFeed()
        {
            var result = _demoContext.Articles.Where(o => !o.author.follow.IsNullOrEmpty()).ToList();
            return result;
        }

        public List<Article> GetByAuthor(string author)
        {
            List<Article> result = _demoContext.Articles.Where(o => o.author.username == author).ToList();
            return result;
        }

        public List<Article> GetByUserName(string userName)
        {
            List<Article> result = _demoContext.Articles.Where(o => o.favorite.FirstOrDefault(o => o.username == userName).username == userName).ToList();   
            return result;
        }
    }
}
