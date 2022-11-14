using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBook.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    Serves = table.Column<int>(type: "int", nullable: false),
                    RatingsAvg = table.Column<double>(type: "float", nullable: false),
                    RecipeBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeBooks_RecipeBookId",
                        column: x => x.RecipeBookId,
                        principalTable: "RecipeBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RecipeBooks",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "...", "My recipe book" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookTime", "Ingredients", "Method", "Name", "RatingsAvg", "RecipeBookId", "Serves" },
                values: new object[] { 1, 12, "3 Eggs", "Cook", "Apple pie", 0.5, 1, 0 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookTime", "Ingredients", "Method", "Name", "RatingsAvg", "RecipeBookId", "Serves" },
                values: new object[] { 2, 10, "2 Eggs", "Cook", "Apple pie2", 0.5, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeBookId",
                table: "Recipes",
                column: "RecipeBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeBooks");
        }
    }
}
