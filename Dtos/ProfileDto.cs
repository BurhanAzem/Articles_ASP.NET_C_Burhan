using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Dtos
{
    public class ProfileDto
    {
        public string UserName { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
        public List<User> follow { get; set; }
    }
}
