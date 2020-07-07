using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using System.Linq;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Tables
        public DbSet<User> User { get; set; }
        public DbSet<UserImage> UserImage {get; set;}
        public DbQuery<MyQueryType>  MyQueryType { get; set; }
       // public DbSet<object> dbObject { get; set; }
       

        public ApplicationDbContext()
        {
           
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=./../database_04.db");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

        }
    }
}
