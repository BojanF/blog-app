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
    public class UserRepoImpl : IUserRepo
    {
        private readonly BlogAppContext _context;

        public UserRepoImpl(BlogAppContext context)
        {
            _context = context;
        }

        public int CountApprovedPostsFromUserForCategory(string userId, long categoryId) {
            return _context
                .Posts
                .Where(p => p.Approved == true)
                .Where(p => p.UserId.Id == userId)
                .Where(p => p.Category.ID == categoryId)
                .Count();          
        }

        public IQueryable<Post> GetAllUnApprovedPostsForModerator(string UserId)
        {

            return _context
                .Posts
                .OrderBy(post => post.PostedAt)
                .Where(post => !post.Approved)
                .Where(post => post.UserId.Id != UserId)
                .Where(post => post.Category.UsersCategories.Any(c => c.CategoryId == post.CategoryId))
                .Where(post => post.Category.UsersCategories.Any(c => c.UserId == UserId))
                .Include(post => post.Category)
                .Include(post => post.UserId);
        }

        public  int countModeratorCategories(string userId)
        {
            List<ApplicationUser> Users = _context
                .Users
                .AsNoTracking()
                .Include(user => user.UsersCategories)
                .Where(user => user.Id == userId)
                .ToList();
            return Users.First().UsersCategories.Count();            
        }

        public List<string> AllNonAdminUsersId()
        {
            string adminId = _context.Roles.Where(role => role.Name == "Admin").Select(role => role.Id).Single();
            var adminUsersIDs= _context.UserRoles.Where(roleU => roleU.RoleId == adminId).Select(uId => uId.UserId);
            return _context.UserRoles.Select(roleU => roleU.UserId).Except(adminUsersIDs).Distinct().ToList();
        }

        public ApplicationUser getById(string userId)
        {
            return _context.Users.Where(user => user.Id == userId).Single();
        }

        public List<ApplicationUser> ModeratorForCategory(string userId, long categoryId)
        {
            return _context
                .Users
                .Where(user => user.UsersCategories.Any(uc => uc.UserId==userId && uc.CategoryId == categoryId))
                .ToList();
        }

        public int CountApprovedPostByUser(string userId)
        {
            return _context.Posts.Where(post => post.UserId.Id == userId && post.Approved).Count();
        }

        public IQueryable<Post> GetAllApprovedPostsForUser(string userId)
        {
            return _context
                .Posts
                .OrderByDescending(post => post.PostedAt)
                .Where(post => post.Approved && post.UserId.Id == userId)
                .Include(post => post.Category);
        }

        public int CountUsersComments(string userId)
        {
            return _context.Comments.Where(comm => comm.Users.Id == userId).Count();
        }

        public List<string> ModeratorCategories(string userId)
        {
            var enumerableUserCategoriesInList = _context.Users.Where(user => user.Id == userId).Select(user => user.UsersCategories).ToList();
            var userCategories = enumerableUserCategoriesInList.First();
            List<long> catIds = new List<long>();
            foreach(UserCategory uc in userCategories)
            {
                catIds.Add(uc.CategoryId);
            }
            return _context.Categories.Where(cat => catIds.Contains(cat.ID)).Select(cat => cat.CategoryName).ToList();
           
        }
    }
}
