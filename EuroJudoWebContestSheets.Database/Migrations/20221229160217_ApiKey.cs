using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroJudoWebContestSheets.Database.Migrations
{
    public partial class ApiKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Owner = table.Column<string>(type: "TEXT", nullable: false),
                    Key = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiKeyLinkRoleConfiguration",
                columns: table => new
                {
                    ApiKeysId = table.Column<int>(type: "INTEGER", nullable: false),
                    RolesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeyLinkRoleConfiguration", x => new { x.ApiKeysId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ApiKeyLinkRoleConfiguration_ApiKeys_ApiKeysId",
                        column: x => x.ApiKeysId,
                        principalTable: "ApiKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApiKeyLinkRoleConfiguration_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiKeyLinkRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApiKeyId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeyLinkRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiKey_ApiKeyLinkRole",
                        column: x => x.ApiKeyId,
                        principalTable: "ApiKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_ApiKeyLinkRole",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    Short = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    SheetSize = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_Category",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestSheetData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Contest = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitorWhite = table.Column<string>(type: "TEXT", nullable: true),
                    CompetitorBlue = table.Column<string>(type: "TEXT", nullable: true),
                    IponWhite = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    WazaariWhite = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    ShidoWhite = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    IponBlue = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    WazaariBlue = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    ShidoBlue = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0),
                    ShowSimpleScore = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestSheetData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_ContestSheetData",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournament_ContestSheetData",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyLinkRoleConfiguration_RolesId",
                table: "ApiKeyLinkRoleConfiguration",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyLinkRoles_ApiKeyId",
                table: "ApiKeyLinkRoles",
                column: "ApiKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyLinkRoles_RoleId",
                table: "ApiKeyLinkRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TournamentId",
                table: "Categories",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestSheetData_CategoryId",
                table: "ContestSheetData",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestSheetData_TournamentId",
                table: "ContestSheetData",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKeyLinkRoleConfiguration");

            migrationBuilder.DropTable(
                name: "ApiKeyLinkRoles");

            migrationBuilder.DropTable(
                name: "ContestSheetData");

            migrationBuilder.DropTable(
                name: "ApiKeys");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
