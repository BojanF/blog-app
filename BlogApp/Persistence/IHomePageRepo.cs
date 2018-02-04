using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence
{
    public interface IHomePageRepo
    {
        IQueryable<Post> GetAllPosts();

        IQueryable<Post> ApprovedPostsForCategory(long? categoryId);
    }
}
