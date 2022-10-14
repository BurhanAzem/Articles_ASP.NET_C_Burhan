using System.ComponentModel.DataAnnotations;

namespace Backend_Controller_Burhan.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; } = 0;
        public DateTime ?createdAt { get; set; }
        public DateTime ?updatedAt { get; set; }
        public string body { get; set; }
        public Profile author { get; set; }
    }
}
