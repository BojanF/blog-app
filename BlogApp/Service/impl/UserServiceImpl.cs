using BlogApp.Persistence;
using BlogApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Service.impl
{
    public class UserServiceImpl : IUserService
    {

        private readonly IUserRepo _repository;

         public UserServiceImpl(IUserRepo repository)
         {
             _repository = repository;
         }
         
        public int CountApprovedPostsFromUserForCategory(string userId, long categoryId) {
            return _repository.CountApprovedPostsFromUserForCategory(userId, categoryId);
        }

        public IQueryable<Post> GetAllUnApprovedPostsForModerator(string UserId)
        {
            return _repository.GetAllUnApprovedPostsForModerator(UserId);
        }

        public int countModeratorCategories(string userId)
        {
            return _repository.countModeratorCategories(userId);
        }

        public List<string> AllNonAdminUsersId()
        {
            return _repository.AllNonAdminUsersId();
        }

        public ApplicationUser getById(string userId)
        {
            return _repository.getById(userId);
        }

        public List<ApplicationUser> ModeratorForCategory(string userId, long categoryId)
        {
            return _repository.ModeratorForCategory(userId, categoryId);
        }

        public int CountApprovedPostByUser(string userId)
        {
            return _repository.CountApprovedPostByUser(userId);
        }

        public IQueryable<Post> GetAllApprovedPostsForUser(string userId)
        {
            return _repository.GetAllApprovedPostsForUser(userId);
        }

        public int CountUsersComments(string userId)
        {
            return _repository.CountUsersComments(userId);
        }

        public List<string> ModeratorCategories(string userId)
        {
            return _repository.ModeratorCategories(userId);

        }
    }
}
