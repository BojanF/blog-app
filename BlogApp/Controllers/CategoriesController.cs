using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogApp.Models;
using BlogApp.Models.Data;
using BlogApp.Service;
using Microsoft.AspNetCore.Authorization;
using BlogApp.Services;
using BlogApp.Model;
using Microsoft.AspNetCore.Identity;
using BlogApp.ViewModels;

namespace BlogApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        

        private readonly ICategoryService _categoryService;
        private readonly IUserCategoryService _userCategoryService;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoriesController(ICategoryService categoryService,
                                    IUserCategoryService userCategoryService, 
                                    IUserService userService,
                                    UserManager<ApplicationUser> userManager)
        {            
            _categoryService = categoryService;
            _userCategoryService = userCategoryService;
            _userService = userService;
            _userManager = userManager;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            ViewData["Header"] = "BlogApp";
            return View(await _categoryService.GetAllCategories());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            ViewData["Header"] = "BlogApp";

            if (id == null)
            {
                return NotFound();
            }
            
            var category = await _categoryService.getById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["Header"] = "BlogApp";
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CategoryName,LikesRule,PostRule")] Category category)
        {
            ViewData["Header"] = "BlogApp";
            if (ModelState.IsValid)
            {                
                await _categoryService.Insert(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            ViewData["Header"] = "BlogApp";
            if (id == null)
            {
                return NotFound();
            }
                       
            var category = await _categoryService.getById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,CategoryName,LikesRule,PostRule")] Category category)
        {
            ViewData["Header"] = "BlogApp";
            if (id != category.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //novo
                Category notUpdated = await _categoryService.getById(id);
                
                try
                {
                    await _categoryService.Update(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoryService.CategoryExists(category.ID))                    
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (notUpdated.PostRule < category.PostRule)
                {
                    //nekoi od mometalnite moderatori za kategorijata mozebi ke treba da im se odzeme taa nadleznost
                    //bidejki so zgolemuvanjeto na uslovot(PostRule) mozebi veke ne go ispolnuvaaat
                    List<ApplicationUser> categoryModerators =  _userCategoryService.FindModeratorsForCategory(category.ID);
                    foreach(ApplicationUser user in categoryModerators)
                    {
                        int userPostsOnCategory = _userService.CountApprovedPostsFromUserForCategory(user.Id, category.ID);
                        if(userPostsOnCategory < category.PostRule)
                        {
                            int moderatorCategories = _userService.countModeratorCategories(user.Id);
                            moderatorCategories -= 1;

                            UserCategory obj = new UserCategory();
                            obj.UserId = user.Id;
                            obj.User = user;
                            obj.CategoryId = category.ID;
                            obj.Category = category;
                            int deleteResult = await _userCategoryService.DeleteAsync(obj);
                            int z = 0;
                            if (moderatorCategories == 0)
                            {
                                var result = await _userManager.RemoveFromRoleAsync(user, "Moderator");
                            }
                        }
                    }
                }
                else if (notUpdated.PostRule > category.PostRule)
                {
                    //so namaluvanjeto na uslovot da se bide moderator za odredena kategorija mozebi ke treba da se
                    //dodadat novi korisnici za moderator na taa kategorija bidejki so nameluvanjeto nauslovot istiot ke go zadovoluvaat

                    //da se selektiraat site useri sto ne se Admini,
                    //a imaat dovolno approved postovi za da stanat Moderatori za dadenata kategorija

                    List<string> nonAdminUsers = _userService.AllNonAdminUsersId();

                    foreach(string userId in nonAdminUsers)
                    {
                        int approvedPostsForCategory = _userService.CountApprovedPostsFromUserForCategory(userId, id);

                        if(approvedPostsForCategory == category.PostRule)
                        {
                            ApplicationUser newModerator = _userService.getById(userId);
                            UserCategory obj = new UserCategory();
                            obj.UserId = userId;
                            obj.User = newModerator;
                            obj.CategoryId = category.ID;
                            obj.Category = category;
                            await _userCategoryService.Insert(obj);

                            var userRoles = await _userManager.GetRolesAsync(newModerator);
                            bool add = userRoles.Contains("Moderator");
                            if (!add)
                            {
                                await _userManager.AddToRoleAsync(newModerator, "Moderator");
                            }
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            ViewData["Header"] = "BlogApp";
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.getById(id);
            //get postsForCategory
            //ako e >0 togas ne smee da se brise kategorijata
            if (category == null)
            {
                return NotFound();
            }

            int postsForCategory = _categoryService.CountPostsForCategory(id);
            bool canDeleteCategory = false;
            if(postsForCategory == 0)
            {
                canDeleteCategory = true;
            }

            var vm = new CategoryViewModel()
            {
                category = category,
                delete = canDeleteCategory
            };
            return View(vm);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _categoryService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }

        
    }
}
