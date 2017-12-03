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
        private BlogAppContext context;

        public HomePageRepoImpl(BlogAppContext context)
        {
            this.context = context;
        }

        public IQueryable<Post> GetAllPosts()
        {
            /*var result = from post in context.Posts
                         join category in context.Categories on post.CategoryId equals category.ID
                         select post;*/
            // var rez = context.Posts.Where(p => p.Approved).Include(p => p.UserName).Include(p => p.PostsCategories).ThenInclude(m => m.Category);
            var rez = context.Posts.Where(p => p.Approved).Include(p => p.Category);
          
            return rez;
        }
    }
}
