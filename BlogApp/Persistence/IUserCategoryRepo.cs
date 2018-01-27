using BlogApp.Model;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence
{
    public interface IUserCategoryRepo
    {
        Task<UserCategory> Insert(UserCategory userCategory);

        List<ApplicationUser> ModeratorsForCategory(long categoryId);

        Task<int> DeleteAsync(UserCategory userCategory);
    }
}
