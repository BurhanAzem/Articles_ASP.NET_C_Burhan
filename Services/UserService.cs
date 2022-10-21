using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using Backend_Controller_Burhan.Repository;
using SQLitePCL;
using System.Linq;

namespace Backend_Controller_Burhan.Services
{
    public class UserService : IUserService
    {
        DemoContext _demoContext;
        public UserService(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public User Register(User user)
        {
            var old = _demoContext.Users.FirstOrDefault(o => o.email == user.email);
            if (old != null)
                return null;
            _demoContext.Users.Add(user);
            _demoContext.SaveChanges();
            return user;

        }

        public User Get(string email)
        {
            User user = _demoContext.Users.Where(o => o.email == email).FirstOrDefault();
            if (user == null) return null;
            //user.profile = _demoContext.profiles.ToList().FirstOrDefault(o => o.username == user.profile.username);
            return user;
        }
        public User GetL(UserLogin userlogin)
        {
            //User user = _demoContext.Users.ToList().FirstOrDefault(x => x.email == userlogin.email && x.password == userlogin.password);
            User user = _demoContext.Users.Where(x => x.email == userlogin.email && x.password == userlogin.password).FirstOrDefault();
            if (user == null) return null;
            return user;
        }

        public User Update(User newuser)
        {
            User olduser = _demoContext.Users.Where(o => o.email == newuser.email).FirstOrDefault();
            if (olduser == null) return null;

            //_demoContext.Users.Remove(olduser);

            if (newuser.password != null)
                olduser.password = newuser.password;

            if (newuser.profile.image != null)
                olduser.profile.image = newuser.profile.image;

            if (newuser.profile.bio != null)
                olduser.profile.bio = newuser.profile.bio;

            if (newuser.profile.username != null)
                olduser.profile.username = newuser.profile.username;

            if (newuser.profile.follow != null)
                olduser.profile.follow = newuser.profile.follow;
            //_demoContext.Users.Add(olduser);
            _demoContext.SaveChanges();
            return olduser;
        }

    }
}
