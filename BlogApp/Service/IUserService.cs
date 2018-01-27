using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Services {
    public interface IUserService {

        int CountApprovedPostsFromUserForCategory(string userId, long categoryId);

        List<Post> GetAllUnApprovedPostsForModerator(string UserId);

        int countModeratorCategories(string userId);

        List<string> AllNonAdminUsersId();

        ApplicationUser getById(string userId);
    }
}
