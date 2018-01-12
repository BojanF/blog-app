using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Services {
    public interface IUserService {

        int CountPostsFromUserForCategory(string userId,string CategoryName);
        List<Post> GetAllUnApprovedPostsForModerator(string UserId);
    }
}
