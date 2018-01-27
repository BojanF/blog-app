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

        List<Post> GetAllUnApprovedPostsForModerator(string UserId);

        int countModeratorCategories(string userID);

        List<string> AllNonAdminUsersId();

        ApplicationUser getById(string userId);
    }
}
