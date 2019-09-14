using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
    public partial class RefactorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_InviteId",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Invites",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_InviteId",
                table: "Accounts",
                column: "InviteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_InviteId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Invites",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_InviteId",
                table: "Accounts",
                column: "InviteId");
        }
    }
}
