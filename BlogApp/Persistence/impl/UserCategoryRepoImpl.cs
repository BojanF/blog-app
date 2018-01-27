using BlogApp.Model;
using BlogApp.Models;
using BlogApp.Models.Data;
using Microsoft.EntityFrameworkCore;
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

        public List<ApplicationUser> ModeratorsForCategory(long categoryId)
        {
            return _context.Users.Where(user => user.UsersCategories.Any(cat => cat.CategoryId == categoryId)).ToList();
            //return _context.Users.AsNoTracking().Include(user => user.UsersCategories).Where(user => user.UsersCategories.Any(cat => cat.CategoryId == categoryId)).ToList();
        }

        public async Task<int> DeleteAsync(UserCategory userCategory)
        {
            _context.Remove(userCategory);
            int removed = await _context.SaveChangesAsync();
            return removed;
        }
    }

}
