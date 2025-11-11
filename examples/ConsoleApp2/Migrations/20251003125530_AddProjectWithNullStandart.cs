using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectWithNullStandart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "StandartId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project",
                column: "StandartId",
                principalTable: "Standart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "StandartId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project",
                column: "StandartId",
                principalTable: "Standart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
