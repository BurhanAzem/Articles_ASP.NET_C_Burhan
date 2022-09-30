using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Services
{
    public interface IArticaleService
    {
        public Article Create(Article article);
        public Article Update(Article newarticle);
        public bool Delete(string slug); 
        public List<Article> GetAll();
        public Article GetByslug(string slug);
        public CommentDto AddComment(string slug, CommentDto comment);   
        public Article favoriteOp(string slug,UserDto CurrentUserDto, bool favorite);

        //public Article AddComment(string slug);
    }
}
