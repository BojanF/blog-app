using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Service;
using BlogApp.Special;
using BlogApp.Models;
using BlogApp.Models.Data;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private IHomePageService service;
        

        public HomeController(IHomePageService service)
        {
            this.service = service;
        }

        /*public IActionResult Index()
        {
            var PostsList = service.GetAllPosts();
            return View(PostsList);
        }*/

        public async Task<IActionResult> Index(int? page)
        {
            
            ViewData["Header"] = "BlogApp";
           
            var posts = service.GetAllPosts();
            int pageSize = 3;
            return View(await PaginatedList<Post>.CreateAsync(posts, page ?? 1, pageSize));
        }

        public IActionResult About()
        {
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
