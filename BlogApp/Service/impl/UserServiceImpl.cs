using BlogApp.Persistence;
using BlogApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Service.impl
{
    public class UserServiceImpl : IUserService
    {

        private readonly IUserRepo _repository;

         public UserServiceImpl(IUserRepo repository)
         {
             _repository = repository;
         }
         
        public int CountPostsFromUserForCategory(string userId, string CategoryName) {
            return _repository.CountPostsFromUserForCategory(userId, CategoryName);
        }
    }
}
