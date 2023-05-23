using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoojaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedTwoMorePropInOrderHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OrderHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotActive",
                table: "OrderHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OrderHistory");

            migrationBuilder.DropColumn(
                name: "NotActive",
                table: "OrderHistory");
        }
    }
}
