namespace Backend_Controller_Burhan.Models
{
    public class ArticleProfile
    {
        public string slug { get; set; }
        public Article article { get; set; }
        public string username { get; set; }
        public Profile Profile { get; set; } 
        
    }
}
