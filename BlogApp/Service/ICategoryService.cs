using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();

        Task<Category> getById(long? id);

        Task<int> DeleteByIdAsync(long id);

        Task<Category> Insert(Category category);

        bool CategoryExists(long id);

        Task<int> Update(Category category);

        Task<Category> categoryForPost(long postId);

        int CountPostsForCategory(long? categoryId);
    }
}
