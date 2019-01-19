using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MergeRequestService.Migrations
{
    public partial class updateMailSendingJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastExecuteTime",
                table: "MailSendingJobs");

            migrationBuilder.DropColumn(
                name: "NextExecuteTime",
                table: "MailSendingJobs");

            migrationBuilder.DropColumn(
                name: "Recurring",
                table: "MailSendingJobs");

            migrationBuilder.AddColumn<string>(
                name: "CronExpression",
                table: "MailSendingJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MailSendingJobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CronExpression",
                table: "MailSendingJobs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MailSendingJobs");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastExecuteTime",
                table: "MailSendingJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NextExecuteTime",
                table: "MailSendingJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Recurring",
                table: "MailSendingJobs",
                nullable: false,
                defaultValue: 0);
        }
    }
}
