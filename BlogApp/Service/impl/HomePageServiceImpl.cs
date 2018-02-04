using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using BlogApp.Persistence;

namespace BlogApp.Service
{
    public class HomePageServiceImpl : IHomePageService
    {
        private IHomePageRepo _repository;

        public HomePageServiceImpl(IHomePageRepo repository)
        {
            _repository = repository;
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _repository.GetAllPosts();
        }

        public IQueryable<Post> ApprovedPostsForCategory(long? categoryId)
        {
            return _repository.ApprovedPostsForCategory(categoryId);
        }
    }
}
