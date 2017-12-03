using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class CreatePostViewModel
    {
        public Post post { get; set; }
        public Category category {get; set; }
    }
}
