using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project",
                column: "StandartId",
                principalTable: "Standart",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project",
                column: "StandartId",
                principalTable: "Standart",
                principalColumn: "Id");
        }
    }
}
