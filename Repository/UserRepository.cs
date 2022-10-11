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
                    username = "BurhanAzem",
                    image = "higicgisbgcyugfuywcjyvuyecg",
                    bio = "9iji99i899u8hi99j",
                    follow = null
                } ,
                email = "burhan12sab@gmail.com",
                password = "my-password"
            },
            new()
            {
                profile = new()
                {
                    username = "Areej",
                    image = "higicgisbgcyugfuywcjyvuyecg",
                    bio = "9iji99i899u8hi99j",
                    follow = null
                } ,
                email = "burhan13sab@gmail.com",
                password = "my-mom"
            }
        };
    }
}
