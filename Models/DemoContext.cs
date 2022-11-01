using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Backend_Controller_Burhan.Models
{
    public class DemoContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleProfile>().HasKey(ap => new { ap.username, ap.slug });
            modelBuilder.Entity<Tag>().HasKey(t => new { t.tag, t.articleslug });


            //modelBuilder.Entity<ProfileFollow>().HasKey(pf => new { pf.usernamefollower, pf.usernamefollow });
            //modelBuilder
            //.Entity<Tag>(
            //    eb =>
            //    {
            //        eb.HasNoKey();
            //    });

            modelBuilder.Entity<Profile>()
            .HasOne<User>(p => p.User)
            .WithOne(ad => ad.profile)
            .HasForeignKey<User>(u => u.profileusername);

            modelBuilder.Entity<Article>()
            .HasOne<Profile>(p => p.author)
            .WithOne(a => a.article)
            .HasForeignKey<Profile>(p => p.articleslug);

            modelBuilder.Entity<Profile>()
            .HasMany(c => c.ProfileFollowing)
            .WithMany(c => c.ProfileFolloweres);

            modelBuilder.Entity<Article>()
                .HasMany<Tag>(a => a.tagList)
                .WithOne(t => t.article);
            modelBuilder.Entity<Article>().Navigation(a => a.author).AutoInclude();
            modelBuilder.Entity<Profile>().Navigation(p => p.article).AutoInclude();
            //delBuilder.Entity<Article>().Navigation(a => a.favorite).AutoInclude();
            //odelBuilder.Entity<Article>().Navigation(a => a.comment).AutoInclude();
            modelBuilder.Entity<User>().Navigation(u => u.profile).AutoInclude();
   
        }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleProfile> ArticleProfiles { get; set; }  
        public DbSet<Tag> Tages { get; set; }
        //
        //public DbSet<ProfileFollow> ProfileFollowers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source = D:\Temp\Demo.db");
    }
}
