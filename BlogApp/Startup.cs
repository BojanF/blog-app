﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlogApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using BlogApp.Service;
using BlogApp.Service.impl;
using BlogApp.Persistence;
using BlogApp.Persistence.impl;

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
            
            var DbConnection = @"server=kostancev.com;user id=BojanF;password=lozinka_lab5;database=blogApp;persistsecurityinfo=True;SslMode=none;";

            

            services.AddDbContext<BlogAppContext>(options => options.UseMySql(DbConnection));

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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
