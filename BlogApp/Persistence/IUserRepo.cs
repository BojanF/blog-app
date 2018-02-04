using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence
{
    public interface IUserRepo
    {
        int CountApprovedPostsFromUserForCategory(string userId, long categoryId);

        IQueryable<Post> GetAllUnApprovedPostsForModerator(string UserId);

        int countModeratorCategories(string userID);

        List<string> AllNonAdminUsersId();

        ApplicationUser getById(string userId);

        List<ApplicationUser> ModeratorForCategory(string userId, long categoryId);

        int CountApprovedPostByUser(string userId);

        IQueryable<Post> GetAllApprovedPostsForUser(string userId);

        int CountUsersComments(string userId);

        List<string> ModeratorCategories(string userId);
    }
}
