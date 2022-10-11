using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Dtos
{
    public class ProfileDto
    {
        public string username { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
        public bool follow { get; set; } = false;
    }
}
