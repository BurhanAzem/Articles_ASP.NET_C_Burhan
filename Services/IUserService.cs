using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Services
{
    public interface IUserService
    {
        public User Register(User user);
        public User Get(string email);
        public User GetL(UserLoginDto userlogin);
        public User Update(User user);
    }
}
