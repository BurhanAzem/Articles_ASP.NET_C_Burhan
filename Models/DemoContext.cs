using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Controller_Burhan.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<Profile> profiles { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Article> Articles { get; set; }

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
