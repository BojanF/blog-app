using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogApp.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Special
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;
       // private IEnumerable<RoleManager<IdentityRole>> enumerable;

        public UserRoleSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void Seed()
        {
            //string[] userRoles = { "Admin", "Moderator", "User" };
            foreach(string userRole in Enum.GetNames(typeof(UserRole))){
                //string role = Convert.ToString(userRole);
                if ((await _roleManager.FindByNameAsync(userRole)) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = userRole });
                }
            }
        }
    }
}
