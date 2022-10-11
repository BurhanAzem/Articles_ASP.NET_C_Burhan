using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Dtos
{
    public class CommentDto
    {
        public int? id { get; set; } = 0;   
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string body { get; set; }
        public Profile ?author { get; set; }
    }
}
