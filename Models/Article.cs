using Microsoft.VisualBasic;

namespace Backend_Controller_Burhan.Models
{
    public class Article
    {
        public string ?slug { get; set; }   
        public string ?title { get; set; }
        public string ?description { get; set; }
        public string ?body { get; set; }
        public List<string> ?tagList { get; set; } = new List<string>() { "reactjs", "angularjs" };
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int ?favoritesCount { get; set; } = 0;   
        public User ?author { get; set; }
        public List<Comment> ?comment { get; set; } = new List<Comment>();
        public List<User> ?favorite { get; set; } = new List<User>();
    }
}
