using BlogApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models.Data
{
    public class BlogAppContext : IdentityDbContext<ApplicationUser> {

        public BlogAppContext(DbContextOptions<BlogAppContext> options) : base(options)
        {
            
        }

        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Post>().ToTable("Posts");
           
            modelBuilder.Entity<Comment>().ToTable("Comments");

            modelBuilder.Entity<Notification>().ToTable("Notifications");

            modelBuilder.Entity<Category>().ToTable("Categories");


//------Fluent API --------------------------------------------------------------------/
    //many to many (user and category) relationship
            modelBuilder.Entity<UserCategory>()
            .HasKey(uc => new { uc.UserId, uc.CategoryId });

            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UsersCategories)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.Category)
                .WithMany(c => c.UsersCategories)
                .HasForeignKey(uc => uc.CategoryId);

//------/Fluent API --------------------------------------------------------------------/
        }

    }//end BlogAppContex
}
