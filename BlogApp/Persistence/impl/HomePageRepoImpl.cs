using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using BlogApp.Models.Data;

namespace BlogApp.Persistence.impl
{
    public class HomePageRepoImpl : IHomePageRepo
    {
        private BlogAppContext context;

        public HomePageRepoImpl(BlogAppContext context)
        {
            this.context = context;
        }

        public IQueryable<Post> GetAllPosts()
        {
            var rez = context.Posts.Where(p => p.Approved).Include(p => p.User).Include(p => p.PostsCategories).ThenInclude(m => m.Category);
            return rez;
        }
    }
}
