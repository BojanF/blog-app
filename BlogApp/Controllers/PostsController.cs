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
using System.Collections.ObjectModel;
using BlogApp.Special;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections;
using BlogApp.ViewModels;

namespace BlogApp.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
       
        private readonly IPostService _postService;

        private readonly BlogAppContext _context;
        private readonly UserManager<ApplicationUser> _userManager; //maintaining user properties
        private readonly ICategoryService _categoryService;

        public PostsController(BlogAppContext context, IPostService postService,
            UserManager<ApplicationUser> userManager,ICategoryService categoryService)
        {            
            _postService = postService;
            _categoryService = categoryService;
            _context = context;
            _userManager = userManager;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {            
            ViewData["Header"] = "Post Title";
            return View(await _postService.GetAllPosts());
        }


        // GET: Post/Comments/id
        public async Task<IActionResult> Comments(long? id, int? page)
        {
            ViewData["Header"] = "Comments";
            var post = _postService.GetById(id);
            ViewData["PostHeadline"] = post.Result.Headline;
            ViewData["PostID"] = id;
            var comments = _postService.CommentsForPost(id);
            int pageSize = 2;
            return View(await PaginatedList<Comment>.CreateAsync(comments, page ?? 1, pageSize));
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetByIdDetailed(id);
            var commentsForPost = _postService.CommentsForPost(id);
           
            PostDetailsWithCommentsViewModel vm = new PostDetailsWithCommentsViewModel(post, commentsForPost);
            
            if (post == null )
            {
                return NotFound();
            }
            
            
            ViewData["Header"] = post.Headline;
            ViewData["Message"] = "Posted by ";
            ViewData["Autor"] = post.UserName;
            ViewData["Count"] = commentsForPost.Count();
            vm.Post.Comments = commentsForPost.ToList();
            ViewData["Posted"] = " on " + post.PostedAt.ToString();

            return View(vm);
        }

        // POST: Posts/Details
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(long? id,Comment comment)
        {
            
            Post post = await _postService.GetByIdDetailed(id);
            //var commentsForPost = _postService.CommentsForPost(id);
            //vm = new PostDetailsWithCommentsViewModel(post, commentsForPost);
            ApplicationUser userId = await _userManager.GetUserAsync(User);
            
            comment.Users = userId;
            comment.Post = post;
            comment.CommentedAt = DateTime.Now;
            await _postService.InsertComment(comment);//inserting comment

            return RedirectToAction("Details");
        }

        // GET: Posts/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Header"] = "BlogApp";
            List<Category> categoriesList = new List<Category>();
            categoriesList = await _categoryService.GetAllCategories();
            categoriesList.Insert(0, new Category { ID = 0, CategoryName = "Select" });//Inserting Select item in the List(only View)

            ViewBag.ListOfCategories = categoriesList;
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostViewModel newPostViewModel)
        {

            if (newPostViewModel.post.CategoryId == 0) {
                ModelState.AddModelError("", "Select Category");
            }
            else {
                long SelectedValue = newPostViewModel.post.CategoryId;
                //ViewBag.SelectedValue =category.id;

                newPostViewModel.post.Likes = 0;
                newPostViewModel.post.Approved = false;
                newPostViewModel.post.PostedAt = DateTime.Now;
                newPostViewModel.post.Edited = false;
                var userName = _userManager.GetUserName(User);
                newPostViewModel.post.UserName = userName;
                ApplicationUser userId = await _userManager.GetUserAsync(User);
                newPostViewModel.post.UserId = userId;
                newPostViewModel.post.CategoryId = SelectedValue;
            }

            await _postService.Insert(newPostViewModel.post);
                return RedirectToAction("Index", "Home");
            
            /*else
            {
                return NotFound();
            }*/
           // return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
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

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Headline,Caption,PostedText,Likes,Approved,PostedAt,Edited")] Post post)
        {
            if (id != post.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
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

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _postService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }

        
    }
}
