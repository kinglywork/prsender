using Microsoft.EntityFrameworkCore.Migrations;

namespace MergeRequestService.Migrations
{
    public partial class addReviewerFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reviewer",
                table: "MergeRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reviewer",
                table: "MergeRequests");
        }
    }
}
