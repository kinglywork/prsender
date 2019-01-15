using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MergeRequestService.Migrations
{
    public partial class deleteIsToQaField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsToQa",
                table: "MergeRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "MergeRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "MergeRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "MergeRequests");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "MergeRequests");

            migrationBuilder.AddColumn<bool>(
                name: "IsToQa",
                table: "MergeRequests",
                nullable: false,
                defaultValue: false);
        }
    }
}
