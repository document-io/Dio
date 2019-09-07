// ReSharper disable All
using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DocumentIO.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(nullable: false),
					Description = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Employees",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					FirstName = table.Column<string>(nullable: false),
					MiddleName = table.Column<string>(nullable: false),
					LastName = table.Column<string>(nullable: false),
					Email = table.Column<string>(nullable: false),
					PasswordHash = table.Column<string>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Employees", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Documents",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Registration = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: false),
					Description = table.Column<string>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					CategoryId = table.Column<int>(nullable: false),
					CreatorId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Documents", x => x.Id);
					table.ForeignKey(
						name: "FK_Documents_Categories_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Categories",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Documents_Employees_CreatorId",
						column: x => x.CreatorId,
						principalTable: "Employees",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Assignments",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					DueDate = table.Column<DateTime>(nullable: true),
					DocumentId = table.Column<int>(nullable: false),
					PerformerId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Assignments", x => x.Id);
					table.ForeignKey(
						name: "FK_Assignments_Documents_DocumentId",
						column: x => x.DocumentId,
						principalTable: "Documents",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Assignments_Employees_PerformerId",
						column: x => x.PerformerId,
						principalTable: "Employees",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Versions",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(nullable: false),
					Description = table.Column<string>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					DocumentId = table.Column<int>(nullable: false),
					EditedById = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Versions", x => x.Id);
					table.ForeignKey(
						name: "FK_Versions_Documents_DocumentId",
						column: x => x.DocumentId,
						principalTable: "Documents",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Versions_Employees_EditedById",
						column: x => x.EditedById,
						principalTable: "Employees",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "VersionContents",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Content = table.Column<byte[]>(nullable: false),
					FileExtension = table.Column<string>(nullable: false),
					VersionId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VersionContents", x => x.Id);
					table.ForeignKey(
						name: "FK_VersionContents_Versions_VersionId",
						column: x => x.VersionId,
						principalTable: "Versions",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "VersionReviews",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Comment = table.Column<string>(nullable: false),
					ReviewerId = table.Column<int>(nullable: false),
					VersionId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VersionReviews", x => x.Id);
					table.ForeignKey(
						name: "FK_VersionReviews_Employees_ReviewerId",
						column: x => x.ReviewerId,
						principalTable: "Employees",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_VersionReviews_Versions_VersionId",
						column: x => x.VersionId,
						principalTable: "Versions",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Assignments_DocumentId",
				table: "Assignments",
				column: "DocumentId");

			migrationBuilder.CreateIndex(
				name: "IX_Assignments_PerformerId",
				table: "Assignments",
				column: "PerformerId");

			migrationBuilder.CreateIndex(
				name: "IX_Documents_CategoryId",
				table: "Documents",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Documents_CreatorId",
				table: "Documents",
				column: "CreatorId");

			migrationBuilder.CreateIndex(
				name: "IX_VersionContents_VersionId",
				table: "VersionContents",
				column: "VersionId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_VersionReviews_ReviewerId",
				table: "VersionReviews",
				column: "ReviewerId");

			migrationBuilder.CreateIndex(
				name: "IX_VersionReviews_VersionId",
				table: "VersionReviews",
				column: "VersionId");

			migrationBuilder.CreateIndex(
				name: "IX_Versions_DocumentId",
				table: "Versions",
				column: "DocumentId");

			migrationBuilder.CreateIndex(
				name: "IX_Versions_EditedById",
				table: "Versions",
				column: "EditedById");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Assignments");

			migrationBuilder.DropTable(
				name: "VersionContents");

			migrationBuilder.DropTable(
				name: "VersionReviews");

			migrationBuilder.DropTable(
				name: "Versions");

			migrationBuilder.DropTable(
				name: "Documents");

			migrationBuilder.DropTable(
				name: "Categories");

			migrationBuilder.DropTable(
				name: "Employees");
		}
	}
}