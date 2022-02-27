using Microsoft.EntityFrameworkCore.Migrations;

namespace EuroJudoWebContestSheets.Migrations
{
    public partial class CategoryShortAndWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Short",
                table: "Categories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Categories",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Short",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Categories");
        }
    }
}
