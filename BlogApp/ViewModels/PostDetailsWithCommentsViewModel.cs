using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class PostDetailsWithCommentsViewModel{

        public Post Post { get; set; }
        public IQueryable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }

        public PostDetailsWithCommentsViewModel(Post Post, IQueryable<Comment> Comments){
            this.Post = Post;
            this.Comments = Comments;
        }
    }
}
