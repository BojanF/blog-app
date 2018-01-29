using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Persistence
{
    public interface IAdminRepo
    {
        //ist<Post> GetAllUnApprovedPostsForAdmin(string UserId);
        IQueryable<Post> GetAllUnApprovedPostsForAdmin(string UserId);
        IQueryable<ApplicationUser> GetAllUsers();
    }
}
