using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Controller_Burhan.Models
{
    public class DemoContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().Navigation(a => a.author).AutoInclude();
            modelBuilder.Entity<Article>().Navigation(a => a.favorite).AutoInclude();
            modelBuilder.Entity<Article>().Navigation(a => a.comment).AutoInclude();
            modelBuilder.Entity<User>().Navigation(u => u.profile).AutoInclude();
            modelBuilder.Entity<Profile>().Navigation(p => p.follow).AutoInclude();
            modelBuilder.Entity<Comment>().Navigation(c => c.author).AutoInclude();
        }
        public DbSet<Profile>? profiles { get; set; }
        public DbSet<User>? Users { get; set; }  
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Article>? Articles { get; set; }

        //protected override void OnModelCreating(ModelBuilder ModelBuilder)
        //{
        //    ModelBuilder
        //        .Entity<Profile>(
        //            eb =>
        //            {
        //                eb.Property(v => v.UserName).Pri;
        //            });
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source = D:\Temp\Demo.db");
    }
}
