using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BlogApp.Models.Data;

namespace BlogApp.Migrations
{
    [DbContext(typeof(BlogAppContext))]
    [Migration("20170704223953_Initial-Migration1")]
    partial class InitialMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogApp.Model.UserCategory", b =>
                {
                    b.Property<int>("UsersId");

                    b.Property<int>("CategoriesId");

                    b.HasKey("UsersId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("UserCategory");
                });

            modelBuilder.Entity("BlogApp.Models.Categories", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<int>("LikesRule");

                    b.Property<int>("PostRule");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogApp.Models.Comments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentText");

                    b.Property<DateTime>("CommentedAt");

                    b.Property<int?>("PostsID");

                    b.Property<int?>("UsersID");

                    b.HasKey("ID");

                    b.HasIndex("PostsID");

                    b.HasIndex("UsersID");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("BlogApp.Models.Notifications", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Recived");

                    b.Property<string>("Text");

                    b.Property<DateTime>("Time");

                    b.Property<int?>("UsersID");

                    b.HasKey("ID");

                    b.HasIndex("UsersID");

                    b.ToTable("notification");
                });

            modelBuilder.Entity("BlogApp.Models.PostCategory", b =>
                {
                    b.Property<int>("PostsId");

                    b.Property<int>("CategoriesId");

                    b.HasKey("PostsId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("PostCategory");
                });

            modelBuilder.Entity("BlogApp.Models.Posts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<int>("Dislikes");

                    b.Property<int>("Likes");

                    b.Property<DateTime>("PostedAt");

                    b.Property<string>("PostedText");

                    b.Property<int?>("UsersID");

                    b.HasKey("ID");

                    b.HasIndex("UsersID");

                    b.ToTable("post");
                });

            modelBuilder.Entity("BlogApp.Models.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("RoleType")
                        .HasColumnName("role");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("BlogApp.Model.UserCategory", b =>
                {
                    b.HasOne("BlogApp.Models.Categories", "Categories")
                        .WithMany("UsersCategories")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogApp.Models.Users", "Users")
                        .WithMany("UsersCategories")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApp.Models.Comments", b =>
                {
                    b.HasOne("BlogApp.Models.Posts", "Posts")
                        .WithMany("comments")
                        .HasForeignKey("PostsID");

                    b.HasOne("BlogApp.Models.Users", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("UsersID");
                });

            modelBuilder.Entity("BlogApp.Models.Notifications", b =>
                {
                    b.HasOne("BlogApp.Models.Users", "Users")
                        .WithMany("Notifications")
                        .HasForeignKey("UsersID");
                });

            modelBuilder.Entity("BlogApp.Models.PostCategory", b =>
                {
                    b.HasOne("BlogApp.Models.Categories", "Categories")
                        .WithMany("PostsCategories")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogApp.Models.Posts", "Posts")
                        .WithMany("PostsCategories")
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApp.Models.Posts", b =>
                {
                    b.HasOne("BlogApp.Models.Users", "Users")
                        .WithMany("Posts")
                        .HasForeignKey("UsersID");
                });
        }
    }
}
