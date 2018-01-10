using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models.Data;
using BlogApp.Service;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BlogApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {

        private readonly IAdminService _adminService;
        private readonly UserManager<ApplicationUser> _userManager; //maintaining user properties
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(
            IAdminService adminService, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _adminService = adminService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            
            var vm = new UserManagementIndexViewModel {
                Users = _adminService.GetAllUsers()
            };
            
            return View(vm);
        }


        // GET :AddRole
        [HttpGet]
        public async Task<IActionResult> AddRole(string id) {

            var user = await GetUserById(id);

            var vm = new UserManagementAddRoleViewModel {
                ListOfRoles = GetAllRoles(),
                UserId = id,
                Email = user.Email
            };

            return View(vm);
        }

        //POST : AddRole
        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel rvm)
        {
            var user = await GetUserById(rvm.UserId);
            if (ModelState.IsValid)
            {
                var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(error.Code,error.Description);
                    }
                }
            }
            rvm.Email = user.Email;
            rvm.ListOfRoles = GetAllRoles();
            return View(rvm);
        }

        private async Task<ApplicationUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        private SelectList GetAllRoles() {
            return new SelectList(_roleManager.Roles.OrderBy(r => r.Name));
        }
    }
}
