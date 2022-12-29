using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroJudoWebContestSheets.Database.Migrations
{
    public partial class ApiKey_Link_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKeyLinkRoleConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiKeyLinkRoles",
                table: "ApiKeyLinkRoles");

            migrationBuilder.DropIndex(
                name: "IX_ApiKeyLinkRoles_ApiKeyId",
                table: "ApiKeyLinkRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApiKeyLinkRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiKeyLinkRoles",
                table: "ApiKeyLinkRoles",
                columns: new[] { "ApiKeyId", "RoleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiKeyLinkRoles",
                table: "ApiKeyLinkRoles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApiKeyLinkRoles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiKeyLinkRoles",
                table: "ApiKeyLinkRoles",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyLinkRoles_ApiKeyId",
                table: "ApiKeyLinkRoles",
                column: "ApiKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyLinkRoleConfiguration_RolesId",
                table: "ApiKeyLinkRoleConfiguration",
                column: "RolesId");
        }
    }
}
