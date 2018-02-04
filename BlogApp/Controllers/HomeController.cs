using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Service;
using BlogApp.Special;
using BlogApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BlogApp.ViewModels;
using Newtonsoft.Json;

namespace BlogApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IHomePageService _homePageService;
        private readonly ICategoryService _categoryService;

        public HomeController(IHomePageService homePageService, 
            UserManager<ApplicationUser> userManager,
            ICategoryService categoryService
            )
        {
            _userManager = userManager;
            _homePageService = homePageService;
            _categoryService = categoryService;
        }

        // GET: Index
        [HttpGet]
        public async Task<IActionResult> Index(int criteria, int? page)
        {

            ViewData["Header"] = "BlogApp";
            ApplicationUser user = _userManager.GetUserAsync(HttpContext.User).Result;

            ViewBag.Message = $"Welcome {user.UserName}!";
            var posts = _homePageService.GetAllPosts();

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

            int pageSize = 5;
            ViewBag.SortingCriteria = criteria;
            return View(await PaginatedList<Post>.CreateAsync(posts, page ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult AccessGraanted() {
            return View();
            
        }

        [HttpGet]
        public IActionResult About()
        {
            ViewData["Header"] = "About us";

            List<Category> categoryList = _categoryService.GetAllCategories().Result;
            List<CategoryExtendedViewModel> statisticList = new List<CategoryExtendedViewModel>();
            for (int i=0;i<categoryList.Count;i++) {
                int countedPosts = _categoryService.CountPostsForCategory(categoryList[i].ID);
                CategoryExtendedViewModel catItem = new CategoryExtendedViewModel(categoryList[i].CategoryName, countedPosts);
                statisticList.Add(catItem);
            }
            string json = JsonConvert.SerializeObject(statisticList);
            
            ViewData["statisticList"] = json;
            
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryPosts(long? categoryId, int? page)
        {
            var postsForCategory = _homePageService.ApprovedPostsForCategory(categoryId);    
            int pageSize = 5;
            var category = _categoryService.getById(categoryId).Result.CategoryName;
            ViewData["Title"] = category;
            ViewData["Header"] = category;
            ViewData["CategoryId"] = categoryId;
            return View(await PaginatedList<Post>.CreateAsync(postsForCategory, page ?? 1, pageSize));
        }
    }
}
