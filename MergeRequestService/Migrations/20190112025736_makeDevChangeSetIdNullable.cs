using Microsoft.EntityFrameworkCore.Migrations;

namespace MergeRequestService.Migrations
{
    public partial class makeDevChangeSetIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DevChangeSetId",
                table: "MergeRequests",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DevChangeSetId",
                table: "MergeRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
