using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Videos_VideoId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_VideoId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Topics");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_TopicId",
                table: "Videos",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Topics_TopicId",
                table: "Videos",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
