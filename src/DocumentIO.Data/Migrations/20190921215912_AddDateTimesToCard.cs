using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
	public partial class AddDateTimesToCard : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "CreatedAt",
				table: "Cards",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "UpdatedAt",
				table: "Cards",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CreatedAt",
				table: "Cards");

			migrationBuilder.DropColumn(
				name: "UpdatedAt",
				table: "Cards");
		}
	}
}