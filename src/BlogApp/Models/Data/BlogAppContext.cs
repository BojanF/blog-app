using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models.Data
{
    public class BlogAppContext : DbContext {

        public BlogAppContext() : base()
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Notifications> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToTable("user");
            modelBuilder.Entity<Posts>().ToTable("post");
            modelBuilder.Entity<Comments>().ToTable("comment");
            modelBuilder.Entity<Notifications>().ToTable("category");
        }

    }//end BlogAppContex
}
