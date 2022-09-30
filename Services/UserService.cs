using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using System.Linq;

namespace Backend_Controller_Burhan.Services
{
    public class UserService : IUserService
    {
        public User Register(User user)
        {
            var old = UserRepository.Users.FirstOrDefault(o => o.Email == user.Email);
            if (old != null)
                return null;
            UserRepository.Users.Add(user);
            return user;

        }

        public User Get(string email)
        {
            User user1 = UserRepository.Users.FirstOrDefault(o => o.Email == email);
            if (user1 == null) return null;
            return user1;
        }
        public User GetL(UserLoginDto userlogin)
        {
            User user = UserRepository.Users.FirstOrDefault(x => x.Email.Equals(
                userlogin.Email, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(userlogin.Password));
            if (user == null) return null;
            return user;
        }

        public User Update(User newuser)
        {
            User olduser = UserRepository.Users.FirstOrDefault(newuser);
            if (olduser == null) return null;
            olduser.Email = newuser.Email;
            olduser.Password = newuser.Password;
            olduser.profile.image = newuser.profile.image;
            olduser.profile.bio = newuser.profile.bio;
            olduser.profile.UserName = newuser.profile.UserName;
            olduser.profile.follow = newuser.profile.follow;
            return newuser;
        }
    }
}
