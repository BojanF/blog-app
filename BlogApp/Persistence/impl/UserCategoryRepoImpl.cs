using BlogApp.Model;
using BlogApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence.impl
{
    public class UserCategoryRepoImpl : IUserCategoryRepo
    {
        private readonly BlogAppContext _context;

        public UserCategoryRepoImpl(BlogAppContext context)
        {
            _context = context;
        }
       
        public async Task<UserCategory> Insert(UserCategory userCategory)
        {
            _context.Add(userCategory);
            await _context.SaveChangesAsync();
            return userCategory;
        }
    }

}
