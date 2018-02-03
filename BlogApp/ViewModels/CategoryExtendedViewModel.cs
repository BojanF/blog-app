using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class CategoryExtendedViewModel{

        public string categoryName { get; set; }
        public int countedPosts { get; set; }

        public CategoryExtendedViewModel(string categoryName, int countedPosts){
            this.categoryName = categoryName;
            this.countedPosts = countedPosts;
        }

    }
}
