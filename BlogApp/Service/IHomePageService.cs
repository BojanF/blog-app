using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public interface IHomePageService
    {
        IQueryable<Post> GetAllPosts();

        IQueryable<Post> ApprovedPostsForCategory(long? categoryId);
    }
}
