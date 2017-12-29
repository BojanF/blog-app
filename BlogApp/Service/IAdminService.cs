using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;


namespace BlogApp.Service {

    public interface IAdminService {
        //void ApprovePost(long PostId, long AdminId, long UserId);
        //Notification DisapprovePost(long PostId, long AdminId, long UserId, string Text);
        //Category AddCategory(long CategoryId, string CategoryName, int LikesRule, int CommentsRule, int PostRule);
        //void DeleteComment(long CommentId, long AdminId, long UserId);
        List<ApplicationUser> GetAllUsers();

    }
}
