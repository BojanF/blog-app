using BlogApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class UserManagementAddRoleViewModel {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string NewRole { get; set; }
        public SelectList ListOfRoles { get; set; }
    }
}
