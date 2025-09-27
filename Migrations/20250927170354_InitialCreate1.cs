using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Course_CourseId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Student_StudentId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Course_CourseId",
                table: "Review",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Student_StudentId",
                table: "Review",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Course_CourseId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Student_StudentId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Course_CourseId",
                table: "Review",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Student_StudentId",
                table: "Review",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
