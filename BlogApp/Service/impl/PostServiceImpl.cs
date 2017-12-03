using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using BlogApp.Persistence;

namespace BlogApp.Service
{
    public class PostServiceImpl : IPostService
    {
        private readonly IPostRepo _repository;

        public PostServiceImpl(IPostRepo repository)
        {
            _repository = repository;
        }
        public Task<int> DeleteByIdAsync(long id)
        {
            return _repository.DeleteByIdAsync(id);
        }

        public Task<List<Post>> GetAllPosts()
        {
            return _repository.GetAllPosts();
        }

        public Task<Post> GetById(long? id)
        {
            return _repository.GetById(id);
        }

        public Task<Post> GetByIdDetailed(long? id)
        {
            return _repository.GetByIdDetailded(id);
        }

        public Task<Post> Insert(Post post)
        {
            return _repository.Insert(post);
        }

        public bool PostExists(long id)
        {
            return _repository.PostExists(id);
        }

        public Task<int> Update(Post post)
        {
            return _repository.Update(post);
        }
        public IQueryable<Comment> CommentsForPost(long? id)
        {
            return _repository.CommentsForPost(id);
        }

        public Task<Comment> InsertComment(Comment comment) {
            return _repository.InsertComment(comment);
        }
    }
}