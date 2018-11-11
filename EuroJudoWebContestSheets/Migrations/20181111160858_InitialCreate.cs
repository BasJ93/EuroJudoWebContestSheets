using Microsoft.EntityFrameworkCore.Migrations;

namespace EuroJudoWebContestSheets.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true),
                    SheetSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContestSheetData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Contest = table.Column<int>(nullable: false),
                    CompeditorWhite = table.Column<string>(nullable: true),
                    CompeditorBlue = table.Column<string>(nullable: true),
                    IponWhite = table.Column<int>(nullable: false),
                    WazaariWhite = table.Column<int>(nullable: false),
                    ShidoWhite = table.Column<int>(nullable: false),
                    IponBlue = table.Column<int>(nullable: false),
                    WazaarieBlue = table.Column<int>(nullable: false),
                    ShidoBlue = table.Column<int>(nullable: false),
                    ShowSimpleScore = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestSheetData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContestSheetData_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestSheetData_CategoryID",
                table: "ContestSheetData",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestSheetData");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
