using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using BlogApp.Persistence;

namespace BlogApp.Service.impl
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepo _repository;

        public CategoryServiceImpl(ICategoryRepo repository)
        {
            _repository = repository;
        }

        public Task<List<Category>> GetAllCategories()
        {
            return _repository.GetAllCategories();
        }

        public IQueryable<Category> GetAllCategoriesQuaryable()
        {
            return _repository.GetAllCategoriesQuaryable();
        }

        public Task<Category> getById(long? id)
        {
            return _repository.GetById(id);
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public Task<Category> Insert(Category category)
        {
            return _repository.Insert(category);
        }

        public bool CategoryExists(long id)
        {
            return _repository.CategoryExists(id);
        }

        public Task<int> Update(Category category)
        {
            return _repository.Update(category);
        }

        public async Task<Category> categoryForPost(long postId)
        {
            return await _repository.categoryForPost(postId);
        }

        public int CountPostsForCategory(long? categoryId)
        {
            return _repository.CountPostsForCategory(categoryId);
        }
    }
}
