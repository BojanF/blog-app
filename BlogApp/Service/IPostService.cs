using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();

        List<Post> GetAllPostsForModerator(string userId);

        List<Post> GetAllPostsForUser(string userId);

        Task<Post> GetById(long? id);

        Task<Post> GetByIdDetailed(long? id);

        Task<int> DeleteByIdAsync(long id);

        Task<Post> Insert(Post post);

        bool PostExists(long id);

        Task<int> Update(Post post);

        IQueryable<Comment> CommentsForPost(long? id);

        Task<Comment> InsertComment(Comment comment);

    }
}
