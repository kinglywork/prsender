using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MergeRequestService.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MergeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SourceBranch = table.Column<string>(nullable: true),
                    TargetBranch = table.Column<string>(nullable: true),
                    ChangeSetId = table.Column<int>(nullable: false),
                    IsToQa = table.Column<bool>(nullable: false),
                    DevChangeSetId = table.Column<int>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    SubmitterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MergeRequests");
        }
    }
}