﻿using System;
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

        public IQueryable<Post> GetAllPostsForUser(string userId) {
            return _context
                .Posts
                .OrderByDescending(post => post.PostedAt)
                .Where(pu => pu.UserId.Id == userId)
                .Include(p => p.Category);
        }

        public Task<Post> GetById(long? id)
        {
            return _context.Posts.Include(p => p.UserId).Include(p => p.Category).SingleOrDefaultAsync(m => m.ID == id);
        }

        public Task<Post> GetByIdDetailded(long? id)
        {
            return _context.Posts.Include(post => post.UserId).SingleOrDefaultAsync(m => m.ID == id);
            //return _context.Posts.SingleOrDefaultAsync(p => p.ID == id);
        
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

        public Category getCategoryForPost(long postId)
        {
            return _context.Posts.Include(p => p.Category).Where(p => p.ID == postId).Select(p => p.Category).Single();
            //return posts.First().CategoryId;
        }

        public DateTime getPostedAtForPost(long postId)
        {
            return _context.Posts.Where(p => p.ID == postId).Select(p => p.PostedAt).Single();
        }
        
    }
}
