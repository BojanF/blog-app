using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BlogApp.Models.Data;

namespace BlogApp.Migrations
{
    [DbContext(typeof(BlogAppContext))]
    [Migration("20171013214139_BojanV2")]
    partial class BojanV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BlogApp.Model.UserCategory", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("CategoryId");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserCategory");
                });

            modelBuilder.Entity("BlogApp.Models.Category", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.Property<int>("LikesRule");

                    b.Property<int>("PostRule");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogApp.Models.Comment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentText")
                        .IsRequired();

                    b.Property<DateTime>("CommentedAt");

                    b.Property<long>("PostID");

                    b.Property<long>("UsersID");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.HasIndex("UsersID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BlogApp.Models.Notification", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Recived");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<DateTime>("Time");

                    b.Property<long>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("BlogApp.Models.Post", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<string>("Caption")
                        .IsRequired();

                    b.Property<bool>("Edited");

                    b.Property<string>("Headline")
                        .IsRequired();

                    b.Property<int>("Likes");

                    b.Property<DateTime>("PostedAt");

                    b.Property<string>("PostedText")
                        .IsRequired();

                    b.Property<long>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogApp.Models.PostCategory", b =>
                {
                    b.Property<long>("PostId");

                    b.Property<long>("CategoryId");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategory");
                });

            modelBuilder.Entity("BlogApp.Models.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("RoleType")
                        .IsRequired()
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogApp.Model.UserCategory", b =>
                {
                    b.HasOne("BlogApp.Models.Category", "Category")
                        .WithMany("UsersCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogApp.Models.User", "User")
                        .WithMany("UsersCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApp.Models.Comment", b =>
                {
                    b.HasOne("BlogApp.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogApp.Models.User", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApp.Models.Notification", b =>
                {
                    b.HasOne("BlogApp.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApp.Models.Post", b =>
                {
                    b.HasOne("BlogApp.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApp.Models.PostCategory", b =>
                {
                    b.HasOne("BlogApp.Models.Category", "Category")
                        .WithMany("PostsCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogApp.Models.Post", "Post")
                        .WithMany("PostsCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
