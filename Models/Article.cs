using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Controller_Burhan.Models
{
    public class Article
    {
        public Article()
        {
            this.comment = new List<Comment> {};
            this.tagList = new List<Tag> {};
            this.author = new Profile();
        }
        [Key]
        public string slug { get; set; }   
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public List<Tag>? tagList { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int ?favoritesCount { get; set; } = 0;
        public Profile author { get; set; } 
        public string profileusername { get; set; }
        public List<Comment> ?comment { get; set; } 
        public IList<ArticleProfile> ?FavoritArticle { get; set; }   
    }
    public class Tag
    {
       
        public string ?tag { get; set; }
        
        public Article ?article { get; set; }    
        public string ?articleslug { get; set; } 
    }
}
