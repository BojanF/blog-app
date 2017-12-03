using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlogApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration.UserSecrets;
using MySQL.Data.EntityFrameworkCore.Extensions;
using BlogApp.Service;
using BlogApp.Service.impl;
using BlogApp.Persistence;
using BlogApp.Persistence.impl;
using BlogApp.Controllers;
using BlogApp.Models;

namespace BlogApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

             
            // Add framework services.
            services.AddMvc();
            
            //db connection
            var DbConnection = @"server=kostancev.com;user id=BojanF;password=lozinka_lab5;database=blogApp;persistsecurityinfo=True;SslMode=none;";
            services.AddDbContext<BlogAppContext>(options => options.UseMySql(DbConnection));
            //user auth
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BlogAppContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                //to be fixed
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 3;

                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";

                // User settings
                options.User.RequireUniqueEmail = true;

            });
                

            //services + repos
            services.AddTransient<IHomePageService, HomePageServiceImpl>();
            services.AddTransient<IHomePageRepo, HomePageRepoImpl>();

            services.AddTransient<ICategoryService, CategoryServiceImpl>();
            services.AddTransient<ICategoryRepo, CategoryRepoImpl>();

            services.AddTransient<IPostService, PostServiceImpl>();
            services.AddTransient<IPostRepo, PostRepoImpl>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseGoogleAuthentication(new GoogleOptions() {
                ClientId = "439358740378-iv6408bsso73gen0vl4sjd4lb39hbm76.apps.googleusercontent.com",
                ClientSecret = "33S2E0Pao7UqY8KHU4z_R4Fl"
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });



        }
    }
}
