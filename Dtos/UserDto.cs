using Backend_Controller_Burhan.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Controller_Burhan.Dtos
{
    public class UserDto
    {
        public string ?username { get; set; }
        public string ?token { get; set; }
        [Key]
        public string email { get; set; }
        //public Profile profile { get; set; }
        public string ?bio { get; set; }
        public string ?image { get; set; }
    }
}
