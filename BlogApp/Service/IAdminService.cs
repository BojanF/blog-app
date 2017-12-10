using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;


namespace BlogApp.Services {
    interface AdminService {
        void ApprovePost(long PostId, long AdminId, long UserId);
        Notifications DisapprovePost(long PostId, long AdminId, long UserId, string Text);
        Categories AddCategory(long CategoryId, string CategoryName, int LikesRule, int CommentsRule, int PostRule);
        void DeleteComment(long CommentId, long AdminId, long UserId);

    }
}
