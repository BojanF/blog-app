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

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
       
        private readonly IPostService _postService;

        private readonly BlogAppContext _context;

        public PostsController(BlogAppContext context, IPostService postService)
        {            
            _postService = postService;
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {            
            ViewData["Header"] = "Post Title";
            return View(await _postService.GetAllPosts());
        }

        
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

            if (post == null )
            {
                return NotFound();
            }
            
            ViewData["Header"] = post.Headline;
            ViewData["Message"] = "Posted by ";
            ViewData["Autor"] = post.User.Username;
            ViewData["Count"] = post.Comments.Count();
            ViewData["Posted"] = " on " + post.PostedAt.ToString();

            return View(post);
        }
               
        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["Header"] = "BlogApp";
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Post post)
        public async Task<IActionResult> Create([Bind("ID,Headline,Caption,PostedText")] Post post)
        {
            post.Headline = "h1";
            post.Caption = "caption";
            post.PostedText = "lakljkldjkldjklsd";
            post.Likes = 0;
            post.Approved = true;
            post.PostedAt = DateTime.Now;
            post.Edited = false;
            post.User = _context.Users.Where(m => m.ID == 1).First();
            
            /*ICollection<Comment> Comments = new Collection<Comment>();
            post.Comments = Comments;
            ICollection<PostCategory> Categories = new Collection<PostCategory>();
            post.PostsCategories = Categories;*/
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //System.Diagnostics.Debug.WriteLine(errors);
            if (ModelState.IsValid)
            {      
                await _postService.Insert(post);
                return RedirectToAction("Index");
            }
            /*else
            {
                return NotFound();
            }*/
            return View(post);
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
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
