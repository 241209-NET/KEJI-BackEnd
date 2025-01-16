using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.API.Migrations
{
    /// <inheritdoc />
    public partial class statement_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Difference",
                table: "Statement",
                newName: "Starting");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Statement",
                newName: "Ending");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Starting",
                table: "Statement",
                newName: "Difference");

            migrationBuilder.RenameColumn(
                name: "Ending",
                table: "Statement",
                newName: "Amount");
        }
    }
}
