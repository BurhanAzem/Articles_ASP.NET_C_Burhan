using System.ComponentModel.DataAnnotations;

namespace Backend_Controller_Burhan.Models
{
    public class Profile
    {
        [Key]
        public string username { get; set; }
        public string ?bio { get; set; }
        public string ?image { get; set; }
        public User ?User { get; set; }  
        public string ?emailuser { get; set; }   
        public Article ?article { get; set; }    
        public string ?articleslug { get; set; }
        public IList<ArticleProfile> ?FavoritArticle { get; set; }

        public List<Profile> ? ProfileFollowing { get; set; }
        public List<Profile> ? ProfileFolloweres { get; set; } 
    }
}
