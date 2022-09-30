using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Dtos
{
    public class ArticleDto
    {
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool favorited { get; set; } = false;
        public int favoratesCount { get; set; }
        public User author { get; set; }
        public List<Comment> comment { get; set; }
        public bool favorite { get; set; } = false;
    }
}
