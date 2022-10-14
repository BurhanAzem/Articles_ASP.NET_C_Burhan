using System.ComponentModel.DataAnnotations;

namespace Backend_Controller_Burhan.Models
{
    public class Profile
    {
        [Key]
        public string username { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
        public List<Profile> ?follow { get; set; } = new List<Profile>();
    }
}
