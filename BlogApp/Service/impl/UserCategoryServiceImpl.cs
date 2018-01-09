using BlogApp.Model;
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
    }
}
