using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
	public partial class AddDateTimeOffset : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "DueDate",
				table: "Invites",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "Invites",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "UpdatedAt",
				table: "Cards",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "DueDate",
				table: "Cards",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "Cards",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AddColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "CardEvents",
				nullable: false,
				defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
					new TimeSpan(0, 0, 0, 0, 0)));

			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "CardComments",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AddColumn<DateTimeOffset>(
				name: "UpdatedAt",
				table: "CardComments",
				nullable: true);

			migrationBuilder.AddColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "CardAttachments",
				nullable: false,
				defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
					new TimeSpan(0, 0, 0, 0, 0)));

			migrationBuilder.AddColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "CardAssignments",
				nullable: false,
				defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
					new TimeSpan(0, 0, 0, 0, 0)));

			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "Boards",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AlterColumn<DateTimeOffset>(
				name: "CreatedAt",
				table: "Accounts",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CreatedAt",
				table: "CardEvents");

			migrationBuilder.DropColumn(
				name: "UpdatedAt",
				table: "CardComments");

			migrationBuilder.DropColumn(
				name: "CreatedAt",
				table: "CardAttachments");

			migrationBuilder.DropColumn(
				name: "CreatedAt",
				table: "CardAssignments");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DueDate",
				table: "Invites",
				type: "timestamp without time zone",
				nullable: true,
				oldClrType: typeof(DateTimeOffset),
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Invites",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTimeOffset));

			migrationBuilder.AlterColumn<DateTime>(
				name: "UpdatedAt",
				table: "Cards",
				type: "timestamp without time zone",
				nullable: true,
				oldClrType: typeof(DateTimeOffset),
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "DueDate",
				table: "Cards",
				type: "timestamp without time zone",
				nullable: true,
				oldClrType: typeof(DateTimeOffset),
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Cards",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTimeOffset));

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "CardComments",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTimeOffset));

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Boards",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTimeOffset));

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Accounts",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTimeOffset));
		}
	}
}