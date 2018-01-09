using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;


namespace BlogApp.Service {

    public interface IAdminService {

        //Notification DisapprovePost(long PostId, long AdminId, long UserId, string Text);
        //Category AddCategory(long CategoryId, string CategoryName, int LikesRule, int CommentsRule, int PostRule);
        //void DeleteComment(long CommentId, long AdminId, long UserId);
        //void ApprovePost(long PostId, string ToUserId,string FromAdminModeratorId);
        
        List<Post> GetAllUnApprovedPostsForAdmin(string UserId);

        List<ApplicationUser> GetAllUsers();

    }
}
