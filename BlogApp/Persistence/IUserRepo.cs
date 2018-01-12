using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence
{
    public interface IUserRepo
    {
        int CountPostsFromUserForCategory(string userId, string CategoryName);
        List<Post> GetAllUnApprovedPostsForModerator(string UserId);
    }
}
