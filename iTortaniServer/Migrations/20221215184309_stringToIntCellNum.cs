using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTortaniServer.Migrations
{
    /// <inheritdoc />
    public partial class stringToIntCellNum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CellNum",
                table: "Spese",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CellNum",
                table: "Spese",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
