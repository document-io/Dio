using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
    public partial class AddFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "CardAttachments");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "CardAttachments");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    ContentDisposition = table.Column<string>(nullable: true),
                    Length = table.Column<long>(nullable: true),
                    AttachmentId = table.Column<Guid>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "CardAttachments",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "CardAttachments",
                type: "text",
                nullable: true);
        }
    }
}
