using BlogApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models.Data
{
    public class BlogAppContext : DbContext {

        public BlogAppContext(DbContextOptions<BlogAppContext> options) : base(options)
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Notifications> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToTable("user");

            modelBuilder.Entity<Posts>().ToTable("post");
           
            modelBuilder.Entity<Comments>().ToTable("comment");

            modelBuilder.Entity<Notifications>().ToTable("notification");


//------Fluend API --------------------------------------------------------------------/
    //many to many (user and category) relationship
            modelBuilder.Entity<UserCategory>()
            .HasKey(uc => new { uc.UsersId, uc.CategoriesId });

            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.Users)
                .WithMany(u => u.UsersCategories)
                .HasForeignKey(uc => uc.UsersId);

            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.Categories)
                .WithMany(c => c.UsersCategories)
                .HasForeignKey(uc => uc.CategoriesId);

   //many to many (post and category) relationship
            modelBuilder.Entity<PostCategory>()
           .HasKey(pc => new { pc.PostsId, pc.CategoriesId });

            modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Posts)
                .WithMany(p => p.PostsCategories)
                .HasForeignKey(pc => pc.PostsId);

            modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Categories)
                .WithMany(c => c.PostsCategories)
                .HasForeignKey(pc => pc.CategoriesId);
//------/Fluend API --------------------------------------------------------------------/
        }

    }//end BlogAppContex
}
