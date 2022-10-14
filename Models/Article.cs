using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Backend_Controller_Burhan.Models
{
    public class Article
    {
        [Key]
        public string slug { get; set; }   
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public List<Tag>? tagList { get; set; } = new List<Tag>();
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int ?favoritesCount { get; set; } = 0;   
        public Profile ?author { get; set; }
        public List<Comment> ?comment { get; set; } = new List<Comment>();
        public List<Profile> ?favorite { get; set; } = new List<Profile>();
    }
    public class Tag
    {
        [Key]
        public string tag { get; set; } = null!;    
    }
}
