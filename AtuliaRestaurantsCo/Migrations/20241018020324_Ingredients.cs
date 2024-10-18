using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtuliaRestaurantsCo.Migrations
{
    /// <inheritdoc />
    public partial class Ingredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Pricw",
                table: "OrderItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "IngredientName",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderItems",
                newName: "Pricw");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "IngredientName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");
        }
    }
}
