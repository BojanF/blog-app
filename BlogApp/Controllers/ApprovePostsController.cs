using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Service;
using BlogApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BlogApp.Services;
using BlogApp.Model;

namespace BlogApp.Controllers
{
    [Authorize]
    public class ApprovePostsController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IUserCategoryService _userCategoryService;
        private readonly UserManager<ApplicationUser> _userManager; //maintaining user properties
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApprovePostsController(
            IAdminService adminService,
            IPostService postService,
            IUserService userService,
            IUserCategoryService userCategoryService,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _adminService = adminService;
            _postService = postService;
            _userService = userService;
            _userCategoryService = userCategoryService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //i should generate list with unapprowed posts with all categories(admin)
        //or i should wirte a service where the service can give me unapproved posts for passed category(moderator)
        // GET :Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Header"] = "Approving Posts";
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var vm = new ApprovePostsIndexViewModel()
            {
                Posts = _adminService.GetAllUnApprovedPostsForAdmin(userId)
            };

            return View(vm);
        }

        [HttpGet]
        // GET: 
        public async Task<IActionResult> Update(long? id)
        {
            ViewData["Header"] = "Approving Post";
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(long id)
        {
            Post post = await _postService.GetById(id);
            post.Approved = true;
            try
            {
                await _postService.Update(post);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_postService.PostExists(post.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var userRoles = await _userManager.GetRolesAsync(post.UserId);
           // if (userRoles.Contains("Admin"))
           // {
                int countPostsForCategory = _userService.CountPostsFromUserForCategory(post.UserId.Id, post.Category.CategoryName);
                if (countPostsForCategory >= post.Category.PostRule)
                {
                    //zapisi u baza kaj m-n relacijata
                    UserCategory obj = new UserCategory();
                    obj.UserId = post.UserId.Id;
                    obj.User = post.UserId;
                    obj.CategoryId = post.CategoryId;
                    obj.Category = post.Category;

                    //try catch block fali
                    await _userCategoryService.Insert(obj);
                    //var user = await GetUserById(rvm.UserId);
                    //var result = await _userManager.AddToRoleAsync(post.UserId,, rvm.NewRole);

                }
            //}
            

            return  RedirectToAction("Index");
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}