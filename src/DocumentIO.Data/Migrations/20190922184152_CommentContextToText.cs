using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
    public partial class CommentContextToText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "CardComments");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "CardComments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "CardComments");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "CardComments",
                type: "text",
                nullable: true);
        }
    }
}
