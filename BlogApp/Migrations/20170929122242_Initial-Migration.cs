using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CategoryName = table.Column<string>(nullable: true),
                    LikesRule = table.Column<int>(nullable: false),
                    PostRule = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UsersId = table.Column<long>(nullable: false),
                    CategoriesId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => new { x.UsersId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_UserCategory_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategory_user_UsersId",
                        column: x => x.UsersId,
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Recived = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    UsersID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_notification_user_UsersID",
                        column: x => x.UsersID,
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Approved = table.Column<bool>(nullable: false),
                    Dislikes = table.Column<int>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    PostedAt = table.Column<DateTime>(nullable: false),
                    PostedText = table.Column<string>(nullable: true),
                    UsersID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.ID);
                    table.ForeignKey(
                        name: "FK_post_user_UsersID",
                        column: x => x.UsersID,
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CommentText = table.Column<int>(nullable: false),
                    CommentedAt = table.Column<DateTime>(nullable: false),
                    PostsID = table.Column<long>(nullable: true),
                    UsersID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_comment_post_PostsID",
                        column: x => x.PostsID,
                        principalTable: "post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comment_user_UsersID",
                        column: x => x.UsersID,
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    PostsId = table.Column<long>(nullable: false),
                    CategoriesId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => new { x.PostsId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_PostCategory_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategory_post_PostsId",
                        column: x => x.PostsId,
                        principalTable: "post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_CategoriesId",
                table: "UserCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_PostsID",
                table: "comment",
                column: "PostsID");

            migrationBuilder.CreateIndex(
                name: "IX_comment_UsersID",
                table: "comment",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_notification_UsersID",
                table: "notification",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoriesId",
                table: "PostCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_post_UsersID",
                table: "post",
                column: "UsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
