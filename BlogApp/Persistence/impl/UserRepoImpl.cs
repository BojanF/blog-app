using BlogApp.Models.Data;
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
            return _context.Posts.Where(p => p.UserId.Id == userId).Where(p => p.Category.CategoryName == CategoryName).Count();
          
        }
    }
}
