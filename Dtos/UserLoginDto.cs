using System.ComponentModel.DataAnnotations;

namespace Backend_Controller_Burhan.Dtos
{
    public class UserLoginDto
    {
        public string email { get; set; }   
        public string password { get; set; }    
    }
}
