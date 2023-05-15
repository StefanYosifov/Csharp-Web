using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class CoursesInitialFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_UserCourses_UserCoursesCourseId_UserCoursesUserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_UserCoursesCourseId_UserCoursesUserId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "UserCoursesCourseId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "UserCoursesUserId",
                table: "UserCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserCoursesCourseId",
                table: "UserCourses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCoursesUserId",
                table: "UserCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserCoursesCourseId_UserCoursesUserId",
                table: "UserCourses",
                columns: new[] { "UserCoursesCourseId", "UserCoursesUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_UserCourses_UserCoursesCourseId_UserCoursesUserId",
                table: "UserCourses",
                columns: new[] { "UserCoursesCourseId", "UserCoursesUserId" },
                principalTable: "UserCourses",
                principalColumns: new[] { "CourseId", "UserId" });
        }
    }
}
