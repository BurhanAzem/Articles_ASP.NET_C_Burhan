using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;

namespace Backend_Controller_Burhan.Services
{
    public class ProfileService : IProfileService
    {
        DemoContext _demoContext;
        public ProfileService(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public Profile getprofile(string username)
        {
            User user = _demoContext.Users.Where(o => o.profile.username == username).FirstOrDefault();
            if (user == null) return null;
            return user.profile;
        }
        public Profile followOp(string username,string email, bool follow)
        {
            User user = _demoContext.Users.Where(o => o.profile.username == username).FirstOrDefault();
            User follower = _demoContext.Users.Where(O => O.email == email).FirstOrDefault();
            if (user == null) return null;
            if (follow)
            {
                user.profile.ProfileFolloweres.Add(follower.profile);
                follower.profile.ProfileFollowing.Add(user.profile);
                _demoContext.SaveChanges();
            }
            else
            {
                user.profile.ProfileFolloweres.Remove(follower.profile);
                follower.profile.ProfileFollowing.Remove(user.profile);
                _demoContext.SaveChanges();
            }
                return user.profile;
        }

        
    }
}
