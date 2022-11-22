using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBook.API.Migrations
{
    public partial class RecipesNumber_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipesNumber",
                table: "RecipeBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RecipeBooks",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecipesNumber",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipesNumber",
                table: "RecipeBooks");
        }
    }
}
