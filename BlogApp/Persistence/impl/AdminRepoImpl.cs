using BlogApp.Models.Data;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistence.impl
{
    public class AdminRepoImpl : IAdminRepo
    {
        private readonly BlogAppContext _context;

        public AdminRepoImpl(BlogAppContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationUser> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.UserName).Include(r => r.Roles);//Include is Eager Loading not Lazy load
        }

        public IQueryable<Post> GetAllUnApprovedPostsForAdmin(string UserId){        
            return _context.Posts
                .OrderBy(post => post.PostedAt)
                .Where(post => !post.Approved)
                .Where(post => post.UserId.Id != UserId)
                .Include(post => post.Category)
                .Include(post => post.UserId);
        }
    }
}
