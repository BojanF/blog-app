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
        private IHomePageRepo repository;

        public HomePageServiceImpl(IHomePageRepo repository)
        {
            this.repository = repository;
        }

        public IQueryable<Post> GetAllPosts()
        {
            return repository.GetAllPosts();
        }
    }
}
