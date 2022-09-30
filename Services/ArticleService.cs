using Backend_Controller_Burhan.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using Backend_Controller_Burhan.Repository;
using Backend_Controller_Burhan.Dtos;

namespace Backend_Controller_Burhan.Services
{
    public  class ArticleService : IArticaleService
    {
        public Article Create(Article article)
        {
            article.createdAt = DateTime.Now;   
            article.updatedAt = DateTime.Now;
            article.slug = StringExtensions.Slugify(article.title);
            article.author = null;
            ArticleRepository.Articles.Add(article);
            return article;
        }
        public Article Update(Article newarticle)
        {
            var oldarticle = ArticleRepository.Articles.FirstOrDefault(x => x.slug.Equals(newarticle.slug));
            if (oldarticle == null)
                return null;
            oldarticle.title = newarticle.title;
            oldarticle.body = newarticle.body;
            oldarticle.description = newarticle.description;
            oldarticle.slug = StringExtensions.Slugify(newarticle.title);
            return newarticle;
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
        public Article favoriteOp(string slug,UserDto CurrentUserDto, bool favorite)
        {
            var article = ArticleRepository.Articles.FirstOrDefault(O => O.slug == slug);
            if (article == null) return null;
            if (favorite) article.favorite.Add(CurrentUserDto.AsUser());
            else article.favorite.Remove(CurrentUserDto.AsUser());
            return article;
        }

        public CommentDto AddComment(string slug,CommentDto commentDto)
        {
            var article = ArticleRepository.Articles.FirstOrDefault(o => o.slug == slug);
            article.comment.Add(commentDto.AsComment());
            return commentDto;
        }
    }
}
