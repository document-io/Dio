using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
    public partial class MarkdownToContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Markdown",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "Markdown",
                table: "Cards",
                type: "text",
                nullable: true);
        }
    }
}
