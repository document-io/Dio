using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
    public partial class MoveFilesToAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "CardAttachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentDisposition",
                table: "CardAttachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "CardAttachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CardAttachments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "CardAttachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CardAttachments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "CardAttachments");

            migrationBuilder.DropColumn(
                name: "ContentDisposition",
                table: "CardAttachments");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "CardAttachments");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CardAttachments");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "CardAttachments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CardAttachments");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Content = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentDisposition = table.Column<string>(type: "text", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Length = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_CardAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "CardAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_AttachmentId",
                table: "Files",
                column: "AttachmentId");
        }
    }
}
