﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Services {
    interface UserService {
        Posts BlogPost(string UserId, long CategoryId, string Caption, string Headline, string PostedText);
        void EditPost(string UserId, long PostId, string Caption, string Headline, string PostedText);
        Comments CommentOnPost(long PostId, long UserId, string CommentText);
        void EditOwnComment(long CommentId, string CommentText);
        void DeleteOwnComment(long PostId, long CommentId);
        void DeleteCommentOnOwnPost(long PostId, long CommentId);
        bool Like(long PostId);
        Notifications Report(string UserId, long ReportedUserId, string Text);
    }
}