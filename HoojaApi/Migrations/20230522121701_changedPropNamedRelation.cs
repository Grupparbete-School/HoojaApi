using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoojaApi.Migrations
{
    /// <inheritdoc />
    public partial class changedPropNamedRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "QuantityStock");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "OrderHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderHistory");

            migrationBuilder.RenameColumn(
                name: "QuantityStock",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
