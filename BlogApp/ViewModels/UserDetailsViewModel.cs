using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class UserDetailsViewModel
    {
        public int postCount;
        public int commentsCount;
        public ApplicationUser user;
        public string moderatorCategories;
        public string userRolesString;
    }
}
