using BlogApp.Model;
using BlogApp.Models;
using BlogApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Service.impl
{
    public class UserCategoryServiceImpl : IUserCategoryService
    {
        private readonly IUserCategoryRepo _repository;

        public UserCategoryServiceImpl(IUserCategoryRepo repository)
        {
            _repository = repository;
        }

        public async Task<UserCategory> Insert(UserCategory userCategory)
        {
            return await _repository.Insert(userCategory);
        }

        public List<ApplicationUser> FindModeratorsForCategory(long categoryId)
        {
            return _repository.ModeratorsForCategory(categoryId);
        }

        public async Task<int> DeleteAsync(UserCategory userCategory)
        {
            return await _repository.DeleteAsync(userCategory);
        }
    }
}
