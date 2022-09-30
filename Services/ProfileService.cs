using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;

namespace Backend_Controller_Burhan.Services
{
    public class ProfileService : IProfileService
    {
        public Profile getprofile(string username)
        {
            var user = UserRepository.Users.FirstOrDefault(o => o.profile.UserName == username);
            if (user == null) return null;
            return user.profile;
        }
        public Profile followOp(string username,UserDto CurrentuserDto, bool follow)
        {
            var user = UserRepository.Users.FirstOrDefault(O => O.profile.UserName == username);
            if (user == null) return null;
            if (follow) user.profile.follow.Add(CurrentuserDto.AsUser());
            else user.profile.follow.Remove(CurrentuserDto.AsUser());
            return user.profile;
        }

        
    }
}
