using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public interface IUserCategoryService
    {
        Task<UserCategory> Insert(UserCategory userCategory);
    }
}
