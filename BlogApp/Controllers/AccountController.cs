using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using BlogApp.Models.Data;
using Microsoft.Extensions.Logging;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp.Controllers
{
    public class AccountController : Controller
    {
        //dependency injecting 
        private readonly UserManager<ApplicationUser> _userManager; //maintaining user properties
        private readonly SignInManager<ApplicationUser> _signInManager; // user log in/out

        public AccountController(UserManager<ApplicationUser> userManager, 
                                    SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        //GET : Account
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Sign Page";
            ViewData["Header"] = "Singing in";
            return View();
        }
        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Registration Page";
            ViewData["Header"] = "Registration";
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModelLogin)//ViewModel is a model for a view not a database entity (binding)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser signedUser = await _userManager.FindByEmailAsync(viewModelLogin.Email);
                if (signedUser == null)
                {
                    ModelState.AddModelError("", "User does not exist.");
                }
                else { 
                    //var Verif = await _signInManager.CheckPasswordSignInAsync(signedUser,viewModelLogin.Password,lockoutOnFailure:false);
                    //var Test = _userManager
                    var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, viewModelLogin.Password, viewModelLogin.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Login Attempt.");
                    }
                }
            }
            return View(viewModelLogin);
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOut() {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login","Account");
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModelRegister)//ViewModel is a model for a view not a database entity 
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser { 
                    UserName = viewModelRegister.Username,
                    Email = viewModelRegister.Email
                    
                };
                
                var result = await _userManager.CreateAsync(appUser, viewModelRegister.Password);//here you entering the password
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, isPersistent: false);//inPersist meaning about cookie
                    //_logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction(nameof(HomeController.Index), "Home");

                }
                else {
                    //adderrors
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
                return View(viewModelRegister);
        }
    }
}