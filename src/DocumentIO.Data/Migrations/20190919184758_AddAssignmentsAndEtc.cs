// ReSharper disable All

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentIO.Migrations
{
	public partial class AddAssignmentsAndEtc : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Email",
				table: "Invites");

			migrationBuilder.DropColumn(
				name: "Identifier",
				table: "Invites");

			migrationBuilder.AddColumn<Guid>(
				name: "Secret",
				table: "Invites",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.CreateTable(
				name: "CardAssignments",
				columns: table => new
				{
					CardId = table.Column<Guid>(nullable: false),
					AccountId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CardAssignments", x => new {x.AccountId, x.CardId});
					table.ForeignKey(
						name: "FK_CardAssignments_Accounts_AccountId",
						column: x => x.AccountId,
						principalTable: "Accounts",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CardAssignments_Cards_CardId",
						column: x => x.CardId,
						principalTable: "Cards",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CardAttachments",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					MimeType = table.Column<string>(nullable: true),
					Content = table.Column<byte[]>(nullable: true),
					CardId = table.Column<Guid>(nullable: false),
					AccountId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CardAttachments", x => x.Id);
					table.ForeignKey(
						name: "FK_CardAttachments_Accounts_AccountId",
						column: x => x.AccountId,
						principalTable: "Accounts",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CardAttachments_Cards_CardId",
						column: x => x.CardId,
						principalTable: "Cards",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CardComments",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Content = table.Column<string>(nullable: true),
					CreatedAt = table.Column<DateTime>(nullable: false),
					CardId = table.Column<Guid>(nullable: false),
					AccountId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CardComments", x => x.Id);
					table.ForeignKey(
						name: "FK_CardComments_Accounts_AccountId",
						column: x => x.AccountId,
						principalTable: "Accounts",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CardComments_Cards_CardId",
						column: x => x.CardId,
						principalTable: "Cards",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CardEvents",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Content = table.Column<string>(nullable: true),
					CardId = table.Column<Guid>(nullable: false),
					AccountId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CardEvents", x => x.Id);
					table.ForeignKey(
						name: "FK_CardEvents_Accounts_AccountId",
						column: x => x.AccountId,
						principalTable: "Accounts",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CardEvents_Cards_CardId",
						column: x => x.CardId,
						principalTable: "Cards",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Labels",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true),
					Color = table.Column<string>(nullable: true),
					BoardId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Labels", x => x.Id);
					table.ForeignKey(
						name: "FK_Labels_Boards_BoardId",
						column: x => x.BoardId,
						principalTable: "Boards",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CardLabels",
				columns: table => new
				{
					CardId = table.Column<Guid>(nullable: false),
					LabelId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CardLabels", x => new {x.CardId, x.LabelId});
					table.ForeignKey(
						name: "FK_CardLabels_Cards_CardId",
						column: x => x.CardId,
						principalTable: "Cards",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CardLabels_Labels_LabelId",
						column: x => x.LabelId,
						principalTable: "Labels",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_CardAssignments_CardId",
				table: "CardAssignments",
				column: "CardId");

			migrationBuilder.CreateIndex(
				name: "IX_CardAttachments_AccountId",
				table: "CardAttachments",
				column: "AccountId");

			migrationBuilder.CreateIndex(
				name: "IX_CardAttachments_CardId",
				table: "CardAttachments",
				column: "CardId");

			migrationBuilder.CreateIndex(
				name: "IX_CardComments_AccountId",
				table: "CardComments",
				column: "AccountId");

			migrationBuilder.CreateIndex(
				name: "IX_CardComments_CardId",
				table: "CardComments",
				column: "CardId");

			migrationBuilder.CreateIndex(
				name: "IX_CardEvents_AccountId",
				table: "CardEvents",
				column: "AccountId");

			migrationBuilder.CreateIndex(
				name: "IX_CardEvents_CardId",
				table: "CardEvents",
				column: "CardId");

			migrationBuilder.CreateIndex(
				name: "IX_CardLabels_LabelId",
				table: "CardLabels",
				column: "LabelId");

			migrationBuilder.CreateIndex(
				name: "IX_Labels_BoardId",
				table: "Labels",
				column: "BoardId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "CardAssignments");

			migrationBuilder.DropTable(
				name: "CardAttachments");

			migrationBuilder.DropTable(
				name: "CardComments");

			migrationBuilder.DropTable(
				name: "CardEvents");

			migrationBuilder.DropTable(
				name: "CardLabels");

			migrationBuilder.DropTable(
				name: "Labels");

			migrationBuilder.DropColumn(
				name: "Secret",
				table: "Invites");

			migrationBuilder.AddColumn<string>(
				name: "Email",
				table: "Invites",
				type: "text",
				nullable: true);

			migrationBuilder.AddColumn<Guid>(
				name: "Identifier",
				table: "Invites",
				type: "uuid",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
		}
	}
}