using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using BlogApp.Models.Data;
using BlogApp.ViewModels;

namespace BlogApp.Persistence.impl
{
    public class HomePageRepoImpl : IHomePageRepo
    {
        private BlogAppContext _context;

        public HomePageRepoImpl(BlogAppContext context)
        {
            _context = context;
        }

        public IQueryable<Post> GetAllPosts()
        {           
            return _context
                .Posts
                .OrderByDescending(post => post.PostedAt)
                .Where(post => post.Approved)
                .Include(post => post.Category)
                .Include(post => post.UserId);
        }

        public IQueryable<Post> ApprovedPostsForCategory(long? categoryId)
        {
            return _context
                .Posts
                .OrderByDescending(post => post.PostedAt)
                .Include(post => post.UserId)
                .Where(post => post.Approved && post.CategoryId == categoryId);
        }
    }
}
