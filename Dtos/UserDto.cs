using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Dtos
{
    public class UserDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public Profile profile { get; set; }
    }
}
