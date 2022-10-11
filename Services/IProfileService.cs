using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Services
{
    public interface IProfileService
    {
        public Profile getprofile(string username);
        public Profile followOp(string username, string email, bool follow);


    }
}
