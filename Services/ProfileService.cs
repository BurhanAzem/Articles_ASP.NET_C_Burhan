using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;

namespace Backend_Controller_Burhan.Services
{
    public class ProfileService : IProfileService
    {
        public Profile getprofile(string username)
        {
            var user = UserRepository.Users.FirstOrDefault(o => o.profile.username == username);
            if (user == null) return null;
            return user.profile;
        }
        public Profile followOp(string username,string email, bool follow)
        {
            var user = UserRepository.Users.FirstOrDefault(O => O.profile.username == username);
            var follower = UserRepository.Users.FirstOrDefault(O => O.email == email);
            if (user == null) return null;
            if (follow) user.profile.follow.Add(follower.profile);
            else user.profile.follow.Remove(follower.profile);
            return user.profile;
        }

        
    }
}
