using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using BlogApp.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistence.impl
{
    public class PostRepoImpl : IPostRepo
    {

        private readonly BlogAppContext _context;

        public PostRepoImpl(BlogAppContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var post = await GetById(id);
            _context.Posts.Remove(post);
            int removed = await _context.SaveChangesAsync();
            return removed;
        }

        public Task<List<Post>> GetAllPosts()
        {
            return _context.Posts.ToListAsync();
        }

        public Task<Post> GetById(long? id)
        {
            return _context.Posts.Include(p => p.UserId).Include(p => p.Category).SingleOrDefaultAsync(m => m.ID == id);
        }

        public Task<Post> GetByIdDetailded(long? id)
        {
            // return _context.Posts.Include(p => p.UserName).Include(p=> p.PostsCategories).ThenInclude(p => p.Category).SingleOrDefaultAsync(p => p.ID == id && p.Approved);
            return _context.Posts.Where(p => p.Approved).SingleOrDefaultAsync(p => p.ID == id && p.Approved);
        
        }

        public async Task<Post> Insert(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public bool PostExists(long id)
        {
            return _context.Posts.Any(e => e.ID == id);
        }

        public async Task<int> Update(Post post)
        {
            _context.Update(post);
            return await _context.SaveChangesAsync();
        }

        public async Task<Comment> InsertComment(Comment comment) {
            _context.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public IQueryable<Comment> CommentsForPost(long? id)
        {
            
            return _context.Comments.Where(c => c.Post.ID == id).Include(c => c.Users).OrderByDescending(c => c.CommentedAt);
        }
        
    }
}
