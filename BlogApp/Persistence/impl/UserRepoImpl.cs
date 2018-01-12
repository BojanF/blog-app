using BlogApp.Models;
using BlogApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence.impl
{
    public class UserRepoImpl : IUserRepo
    {
        private readonly BlogAppContext _context;

        public UserRepoImpl(BlogAppContext context)
        {
            _context = context;
        }

        public int CountPostsFromUserForCategory(string userId, string CategoryName) {
            return _context.
                Posts.
                Where(p => p.UserId.Id == userId).
                Where(p => p.Category.
                CategoryName == CategoryName).
                Count();          
        }

        public List<Post> GetAllUnApprovedPostsForModerator(string UserId)
        {

            return _context.
                Posts.
                OrderBy(post => post.PostedAt).
                Where(post => !post.Approved).
                Where(post => post.UserId.Id != UserId).
                Where(post => post.Category.UsersCategories.Any(c => c.CategoryId == post.CategoryId)).
                Where(post => post.Category.UsersCategories.Any(c => c.UserId == UserId)).
                Include(cat => cat.Category).
                ToList();
        }
    }
}
