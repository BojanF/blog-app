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

namespace BlogApp.Controllers
{
    public class CategoriesController : Controller
    {
        

        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {            
            _categoryService = categoryService;    
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
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
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
