namespace Backend_Controller_Burhan.Models
{
    public class Profile
    {
        public string UserName { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
        public List<User> follow { get; set; }
    }
}
