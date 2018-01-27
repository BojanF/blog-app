using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAllCategories();

        Task<Category> GetById(long? id);

        Task<int> DeleteByIdAsync(long id);

        Task<Category> Insert(Category category);

        bool CategoryExists(long id);

        Task<int> Update(Category category);

        Task<Category> categoryForPost(long postId);

        int CountPostsForCategory(long? categoryId);
    }
}
