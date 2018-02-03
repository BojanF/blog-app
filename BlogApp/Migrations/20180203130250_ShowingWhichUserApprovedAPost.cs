using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class ShowingWhichUserApprovedAPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "approvedByUserId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_approvedByUserId",
                table: "Posts",
                column: "approvedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_approvedByUserId",
                table: "Posts",
                column: "approvedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_approvedByUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_approvedByUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "approvedByUserId",
                table: "Posts");
        }
    }
}
