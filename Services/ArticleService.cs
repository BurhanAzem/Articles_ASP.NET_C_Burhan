using Backend_Controller_Burhan.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Dtos;
using System.Security.Cryptography;

namespace Backend_Controller_Burhan.Services
{
    public  class ArticleService : IArticaleService
    {
        public Article Create(Article article, User user)
        {
            article.createdAt = DateTime.Now;   
            article.updatedAt = DateTime.Now;
            article.slug = StringExtensions.Slugify(article.title);
            article.author = user.profile;
            ArticleRepository.Articles.Add(article);
            return article;
        }
        public Article Update(Article newarticle, string slug)
        {
            var oldarticle = ArticleRepository.Articles.FirstOrDefault(x => x.slug.Equals(slug));
            if (oldarticle == null)
                return null;
            oldarticle.title = newarticle.title;
            oldarticle.body = newarticle.body;
            oldarticle.description = newarticle.description;
            return oldarticle;
        }
        public bool Delete(string slug)
        {
            var article1 = ArticleRepository.Articles.FirstOrDefault(x => x.slug.Equals(slug));
            if(article1 == null)
                return false;
            ArticleRepository.Articles.Remove(article1); 
            return true;    
        }
        public List<Article> GetAll()
        {
            return ArticleRepository.Articles;
        }
        public Article GetByslug(string slug)
        {
            var article = ArticleRepository.Articles.FirstOrDefault(x => x.slug == slug);
            return article;
        }
        public Article favoriteOp(string slug,User CurrentUserDto, bool favorite)
        {
            var article = ArticleRepository.Articles.FirstOrDefault(O => O.slug == slug);
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
            var article = ArticleRepository.Articles.FirstOrDefault(o => o.slug == slug);
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
            var article = ArticleRepository.Articles.FirstOrDefault(o => o.slug == slug);
            if (article == null)
                return false;
            article.comment.Remove(comment);
            return true;
        }
    }
}
