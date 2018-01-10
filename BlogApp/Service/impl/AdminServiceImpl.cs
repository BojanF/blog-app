﻿using BlogApp.Models;
using BlogApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Service.impl
{
    public class AdminServiceImpl : IAdminService
    {
        private readonly IAdminRepo _repository;

        public AdminServiceImpl(IAdminRepo repository)
        {
            _repository = repository;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public List<Post> GetAllUnApprovedPostsForAdmin(string UserId) {
            return _repository.GetAllUnApprovedPostsForAdmin(UserId);
        }
    }
}
