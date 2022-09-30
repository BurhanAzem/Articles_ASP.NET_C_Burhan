using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Dtos
{
    public class CommentDto
    {
        public int? Id { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string body { get; set; }
        public User author { get; set; }
    }
}
