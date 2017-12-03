using BlogApp.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        //noting here coz its already implemented
        public ICollection<Comment> Comments { get; set; }//one user has many comments(1 to many)
        public ICollection<Post> Posts { get; set; } //one user has many posts(1 to many)
        public ICollection<Notification> Notifications { get; set; } //(1 to many)

        public ICollection<UserCategory> UsersCategories { set; get; } //(many to many)
    }
}
