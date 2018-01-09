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

        public List<ApplicationUser> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.Email).Include(r => r.Roles).ToList();//Include is Eager Loading not Lazy load
        }

        public List<Post> GetAllUnApprovedPostsForAdmin(string UserId) {
            return _context.Posts.OrderBy(pt => pt.PostedAt).Where(p => !p.Approved).Where(p => p.UserId.Id != UserId).Include(cat => cat.Category).ToList();
        }
    }
}
