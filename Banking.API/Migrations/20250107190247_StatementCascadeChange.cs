using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.API.Migrations
{
    /// <inheritdoc />
    public partial class StatementCascadeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Statement_StatementId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "StatementId",
                table: "Activity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Statement_StatementId",
                table: "Activity",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "StatementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Statement_StatementId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "StatementId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Statement_StatementId",
                table: "Activity",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
