using System.ComponentModel.DataAnnotations;

namespace Backend_Controller_Burhan.Models
{
    public class User
    {
        //public string username { get; set; }
        public string password { get; set; }
        [Key]
        public string email { get; set; }
        public Profile profile { get; set; }
        //public string bio { get; set; }
        //public string image { get; set; }
    }
}
