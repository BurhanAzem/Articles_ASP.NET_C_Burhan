using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Repository
{
    public class ArticleRepository
    {
        public static List<Article> Articles = new()
        {
            new()
            {
                updatedAt = DateTime.Now,
                createdAt = DateTime.Now,
                body = "ya-man-be-111",
                slug = "11111111111",
                title = "matrexman",
                favorite = true,
                favoratesCount = 0,
                description = "popopopopopo",
                author = null,
                comment = new()
                {
                    new()
                    {
                        Id = 1,
                        body = "i love you"
                    }
                }
            },
            new()
            {
                updatedAt = DateTime.Now,
                createdAt = DateTime.Now,
                body = "ya-man-be-222",
                slug = "222222222222",
                title = "matrexman",
                favorite = true,
                favoratesCount = 0,
                description = "popopopopopo",
                author = null
            }
        };
    }
}
