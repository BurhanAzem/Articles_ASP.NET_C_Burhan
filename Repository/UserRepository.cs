using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Repository
{
    public class UserRepository
    {
        public static List<User> Users = new()
        {
            new()
            {
                profile = new()
                {
                    UserName = "BurhanAzem",
                    image = "higicgisbgcyugfuywcjyvuyecg",
                    bio = "9iji99i899u8hi99j",
                    follow = null
                } ,
                Email = "burhan12sab@gmail.com",
                Password = "my-password"
            },
            new()
            {
                profile = new()
                {
                    UserName = "Areej",
                    image = "higicgisbgcyugfuywcjyvuyecg",
                    bio = "9iji99i899u8hi99j",
                    follow = null
                } ,
                Email = "burhan13sab@gmail.com",
                Password = "my-mom"
            }
        };
    }
}
