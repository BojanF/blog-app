using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Services {
    public interface IUserService {

        int CountApprovedPostsFromUserForCategory(string userId, long categoryId);

        IQueryable<Post> GetAllUnApprovedPostsForModerator(string UserId);

        int countModeratorCategories(string userId);

        List<string> AllNonAdminUsersId();

        ApplicationUser getById(string userId);

        List<ApplicationUser> ModeratorForCategory(string userId, long categoryId);
    }
}
