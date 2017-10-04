using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class MigrationV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_post_PostsID",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_user_UsersID",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_notification_user_UsersID",
                table: "notification");

            migrationBuilder.DropForeignKey(
                name: "FK_post_user_UsersID",
                table: "post");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "user",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "user",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "user",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UsersID",
                table: "post",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostedText",
                table: "post",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UsersID",
                table: "notification",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "notification",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UsersID",
                table: "comment",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PostsID",
                table: "comment",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "comment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_post_PostsID",
                table: "comment",
                column: "PostsID",
                principalTable: "post",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_user_UsersID",
                table: "comment",
                column: "UsersID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notification_user_UsersID",
                table: "notification",
                column: "UsersID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_user_UsersID",
                table: "post",
                column: "UsersID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_post_PostsID",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_user_UsersID",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_notification_user_UsersID",
                table: "notification");

            migrationBuilder.DropForeignKey(
                name: "FK_post_user_UsersID",
                table: "post");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "user",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "user",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "user",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "UsersID",
                table: "post",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "PostedText",
                table: "post",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "UsersID",
                table: "notification",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "notification",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "UsersID",
                table: "comment",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PostsID",
                table: "comment",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "comment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_comment_post_PostsID",
                table: "comment",
                column: "PostsID",
                principalTable: "post",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_user_UsersID",
                table: "comment",
                column: "UsersID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notification_user_UsersID",
                table: "notification",
                column: "UsersID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_post_user_UsersID",
                table: "post",
                column: "UsersID",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
