using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoojaApi.Migrations
{
    /// <inheritdoc />
    public partial class removedAmountORderHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "OrderHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
