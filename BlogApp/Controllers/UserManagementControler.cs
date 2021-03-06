﻿using System;
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
using BlogApp.Special;

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
        public async Task<IActionResult> Index(int? page)
        {

            /*var vm = new UserManagementIndexViewModel {
                Users = _adminService.GetAllUsers()
            };
            return View(vm);*/
            int pageSize = 7;
            var users = _adminService.GetAllUsers();

            return View(await PaginatedList<ApplicationUser>.CreateAsync(users, page ?? 1, pageSize));

           
        }


        // GET :AddRole
        [HttpGet]        
        public async Task<IActionResult> AddRole(string id) {

            var user = await GetUserById(id);

            var vm = new UserManagementAddRoleViewModel {
                ListOfRoles = GetAllRoles(),
                UserId = id,
                UserName = user.UserName
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
                //var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);
                var result = await _userManager.AddToRoleAsync(user, "Admin");
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
            rvm.UserName = user.UserName;
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
