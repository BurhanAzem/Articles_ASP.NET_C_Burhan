using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using System.Linq;

namespace Backend_Controller_Burhan.Services
{
    public class UserService : IUserService
    {
        public User Register(User user)
        {
            var old = UserRepository.Users.FirstOrDefault(o => o.email == user.email);
            if (old != null)
                return null;
            UserRepository.Users.Add(user);
            return user;

        }

        public User Get(string email)
        {
            User user1 = UserRepository.Users.FirstOrDefault(o => o.email == email);
            if (user1 == null) return null;
            return user1;
        }
        public User GetL(UserLoginDto userlogin)
        {
            User user = UserRepository.Users.FirstOrDefault(x => x.email.Equals(
                userlogin.email, StringComparison.OrdinalIgnoreCase) && x.password.Equals(userlogin.password));
            if (user == null) return null;
            return user;
        }

        public User Update(User newuser)
        {
            User olduser = UserRepository.Users.FirstOrDefault(newuser);
            if (olduser == null) return null;
            if (newuser.email != null)
                olduser.password = newuser.password;
            if (newuser.profile.image != null)
                olduser.profile.image = newuser.profile.image;
            if (newuser.profile.bio != null)
                olduser.profile.bio = newuser.profile.bio;
            if (newuser.profile.username != null)
                olduser.profile.username = newuser.profile.username;
            if (newuser.profile.follow != null)
                olduser.profile.follow = newuser.profile.follow;
            return olduser;
        }
    }
}
