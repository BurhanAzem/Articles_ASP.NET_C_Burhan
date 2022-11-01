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
            article.slug = StringExtensions.Slugify(article.title);
            article.author = user.profile;
            article.tagList.ForEach(a => a.articleslug = article.slug);
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
            Article article = _demoContext.Articles.Include(a => a.FavoritArticle).Where(x => x.slug == slug).FirstOrDefault();
            Profile profile = CurrentUser.profile;
            if (article == null) return null;
            if (profile == null) return null;
            ArticleProfile articleProfile = new()
            {
                slug = article.slug,
                article = article,
                username = profile.username,
                Profile = profile
            };
    
            if (favorite)
            {
                article.FavoritArticle.Add(articleProfile);
                article.favoritesCount = article.FavoritArticle.Count;
                _demoContext.SaveChanges();
            }
            else
            {
                article.FavoritArticle.Remove(articleProfile);
                article.favoritesCount = article.FavoritArticle.Count;
                _demoContext.Update(article);
                _demoContext.SaveChanges();
            }

            return article;
        }

        public Comment AddComment(string slug,Comment comment)
        {
            
            Article article = _demoContext.Articles.Where(x => x.slug == slug).FirstOrDefault();
            if (article == null)
                return null;
            comment.updatedAt = DateTime.Now;   
            comment.createdAt = DateTime.Now;
            article.comment.Add(comment);
            _demoContext.SaveChanges();
            return comment;
        }
        public bool DeleteComment(string slug, int id)
        {
            Article article = _demoContext.Articles.Include(a => a.comment).Where(x => x.slug == slug).FirstOrDefault();
            if (article == null)
                return false;
            Comment comment1 = _demoContext.Comments.Where(a => a.id == id).FirstOrDefault();
            if (comment1 == null) return false;
            article.comment.Remove(comment1);
            _demoContext.SaveChanges();
            return true;
        }

        public List<Article> GetFeed()
        {
            var result = _demoContext.Articles.Where(o => !o.author.ProfileFolloweres.IsNullOrEmpty()).ToList();
            return result;
        }

        public List<Article> GetByAuthor(string author)
        {
            List<Article> result = _demoContext.Articles.Where(o => o.author.username == author).ToList();
            return result;
        }
         
        public List<Article> GetByUserName(string userName)
        {
            List<Article> articles = _demoContext.Articles.Include(a => a.FavoritArticle).ToList();
            List<Article> result = new List<Article>();
            for (int i = 0; i < articles.Count; i++)
            {
                for(int j = 0; j < articles[i].FavoritArticle.Count; j++)
                {
                    if (articles[i].FavoritArticle[j].username == userName)
                    {
                        result.Add(articles[i]);
                        break;
                    }
                }
            }
            return result;
        }

        public List<Comment> GetComments(string slug)
        {
            Article article = _demoContext.Articles.Include(a => a.comment).Where(a => a.slug == slug).FirstOrDefault();
            return article.comment.ToList();
        }

        public List<Article> GetByTagList(string tag)
        {
            List<Article> articles = _demoContext.Articles.Include(a => a.tagList).ToList();
            List<Article> result = new List<Article>();
            for (int i = 0; i < articles.Count; i++)
            {
                for (int j = 0; j < articles[i].FavoritArticle.Count; j++)
                {
                    if (articles[i].tagList[j].tag == tag)
                    {
                        result.Add(articles[i]);
                        break;
                    }
                }
            }
            return result;
        }

        public List<Tag> GetTags()
        {
            List<Tag> result = _demoContext.Tages.ToList(); 
            return result;
        }
    }
}
