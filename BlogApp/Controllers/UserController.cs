using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlogApp.Services;
using BlogApp.Models;
using Microsoft.AspNetCore.Identity;
using BlogApp.ViewModels;
using BlogApp.Special;

namespace BlogApp.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            int postCount = _userService.CountApprovedPostByUser(userId);
            int commentsCount = _userService.CountUsersComments(userId);
            ApplicationUser user = _userService.getById(userId);
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            string moderatorCategories;
            string userRolesString = string.Join(", ", userRoles);  

            if (userRoles.Contains("Admin"))
            {
                moderatorCategories = "All categories.Because he is Administrator.";
            }
            else
            {
                if (userRoles.Contains("Moderator"))
                {
                    moderatorCategories = string.Join(", ", _userService.ModeratorCategories(userId));
                }
                else
                {
                    moderatorCategories = "He is not a moderator at the moment";
                }
            }
            ViewData["Title"] = user.UserName;
            ViewData["Header"] = user.UserName;
            var vm = new UserDetailsViewModel()
            {
                postCount = postCount,
                commentsCount = commentsCount,
                user = user,
                moderatorCategories = moderatorCategories,
                userRolesString = userRolesString
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;

            int postCount = _userService.CountApprovedPostByUser(userId);
            int commentsCount = _userService.CountUsersComments(userId);

            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            string moderatorCategories;
            string userRolesString = string.Join(", ", userRoles); 
            if (userRoles.Contains("Admin"))
            {
                moderatorCategories = "All categories.Because you are Administrator.";
            }
            else
            {
                if (userRoles.Contains("Moderator"))
                {
                    moderatorCategories = string.Join(", ", _userService.ModeratorCategories(userId));
                }
                else
                {
                    moderatorCategories = "You are not a moderator at the moment";
                }
            }           

            ViewData["Title"] = user.UserName;
            ViewData["Header"] = user.UserName;
            var vm = new UserDetailsViewModel()
            {
                postCount = postCount,
                commentsCount = commentsCount,
                user = user,
                moderatorCategories = moderatorCategories,
                userRolesString = userRolesString
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ApprovedPosts(string userId, int? page)
        {
            var approvedUserPosts = _userService.GetAllApprovedPostsForUser(userId);
            int pageSize = 5;
            ViewData["UserId"] = userId;
            ViewData["Header"] = _userService.getById(userId).UserName;
            return View(await PaginatedList<Post>.CreateAsync(approvedUserPosts, page ?? 1, pageSize));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}