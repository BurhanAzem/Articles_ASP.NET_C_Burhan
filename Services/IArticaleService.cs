using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Services
{
    public interface IArticaleService
    {
        public Article Create(Article article, User user);
        public Article Update(Article newarticle, string slug);
        public bool Delete(string slug); 
        public List<Article> GetAll();
        public Article GetByslug(string slug);
        public Comment AddComment(string slug, Comment comment);   
        public Article favoriteOp(string slug,User CurrentUserDto, bool favorite);
        public bool DeleteComment(string slug, Comment comment);
        public List<Article> GetFeed();
        public List<Article> GetByAuthor(string author);    
        public List<Article> GetByUserName(string userName);    


        //public Article AddComment(string slug);
    }
}
