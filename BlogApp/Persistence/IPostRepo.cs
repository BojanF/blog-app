using BlogApp.Models;
using BlogApp.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence
{
    public interface IPostRepo
    {
        Task<List<Post>> GetAllPosts();

        List<Post> GetAllPostsForUser(string userId);

        Task<Post> GetById(long? id);

        Task<Post> GetByIdDetailded(long? id);

        Task<int> DeleteByIdAsync(long id);

        Task<Post> Insert(Post post);

        bool PostExists(long id);

        Task<int> Update(Post post);

        Task<Comment> InsertComment(Comment comment);

        IQueryable<Comment> CommentsForPost(long? id);

    }
}
