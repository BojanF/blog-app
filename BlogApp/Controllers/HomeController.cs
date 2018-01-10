using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Service;
using BlogApp.Special;
using BlogApp.Models;
using BlogApp.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BlogApp.ViewModels;

namespace BlogApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IHomePageService service;
        

        public HomeController(IHomePageService service, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            this.service = service;
        }

        // GET: Index
        public async Task<IActionResult> Index(int criteria, int? page)
        {

            ViewData["Header"] = "BlogApp";
            ApplicationUser user = _userManager.GetUserAsync
                            (HttpContext.User).Result;

            ViewBag.Message = $"Welcome {user.UserName}!";
            var posts = service.GetAllPosts();

            //switch by criteria
            switch (criteria)
            {
                case 0:
                    posts = posts.OrderByDescending(service => service.PostedAt);
                    break;
                case 1:
                    posts = posts.OrderBy(service => service.PostedAt);
                    break;
                case 2:
                    posts = posts.OrderBy(service => service.Headline);
                    break;
                case 3:
                    posts = posts.OrderBy(service => service.UserName);
                    break;
            }

            int pageSize = 3;
            ViewBag.SortingCriteria = criteria;
            return View(await PaginatedList<Post>.CreateAsync(posts, page ?? 1, pageSize));
        }

        public IActionResult AccessGraanted() {
            return View();
            
        }

        public IActionResult About()
        {
            ViewData["Header"] = "About us";
            ViewData["Message"] = "BOJAN";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
