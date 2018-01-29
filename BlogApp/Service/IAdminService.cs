using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;


namespace BlogApp.Service {

    public interface IAdminService {

        //Notification DisapprovePost(long PostId, long AdminId, long UserId, string Text);

        IQueryable<Post> GetAllUnApprovedPostsForAdmin(string UserId);

        IQueryable<ApplicationUser> GetAllUsers();

    }
}
