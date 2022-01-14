using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class OrderStockAndAllowedNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AmountInStock",
                table: "Ingredients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "IngredientInRecipes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountInStock",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "IngredientInRecipes");
        }
    }
}
