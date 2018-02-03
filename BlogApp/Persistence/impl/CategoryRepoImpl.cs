using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using BlogApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Persistence.impl
{
    public class CategoryRepoImpl : ICategoryRepo
    {
        private readonly BlogAppContext _context;

        public CategoryRepoImpl(BlogAppContext context)
        {
            _context = context;
        }
      
        public Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.ToListAsync();
        }

        public IQueryable<Category> GetAllCategoriesQuaryable()
        {
            return _context.Categories;
        }

        public Task<Category> GetById(long? id)
        {
            return _context.Categories.AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);
        }        

        public async Task<int> DeleteByIdAsync(long id)
        {
            var category = await GetById(id);
             _context.Categories.Remove(category);
            int removed = await _context.SaveChangesAsync();
            return removed;
        }

        public async Task<Category> Insert(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public bool CategoryExists(long id)
        {
            return _context.Categories.Any(e => e.ID == id);
        }

        public async Task<int> Update(Category category)
        {
            _context.Update(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<Category> categoryForPost(long postId)
        {
            return  _context.Posts.AsNoTracking().Where(post => post.ID == postId).Select(post => post.Category).Single();
        }

        public int CountPostsForCategory(long? categoryId)
        {
            return _context.Posts.Where(post => post.Category.ID == categoryId).Count();
        }
    }
}
