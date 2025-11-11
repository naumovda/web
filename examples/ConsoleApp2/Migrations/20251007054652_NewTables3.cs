using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makeup_Parameter_ParameterId",
                table: "Makeup");

            migrationBuilder.DropIndex(
                name: "IX_Makeup_ParameterId",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "ParameterId",
                table: "Makeup");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParameterId",
                table: "Makeup",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Makeup_ParameterId",
                table: "Makeup",
                column: "ParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makeup_Parameter_ParameterId",
                table: "Makeup",
                column: "ParameterId",
                principalTable: "Parameter",
                principalColumn: "Id");
        }
    }
}
