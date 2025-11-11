using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AirMass_AirMassId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Illuminant_IlluminantId",
                table: "Project");

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

            migrationBuilder.AlterColumn<int>(
                name: "IlluminantId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AirMassId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObserverId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Observer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AirMass",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, 1, "1.0 EN 410" });

            migrationBuilder.InsertData(
                table: "Illuminant",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A" },
                    { 2, 2, "C" },
                    { 3, 3, "D65" }
                });

            migrationBuilder.InsertData(
                table: "Observer",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "2 градуса" },
                    { 2, 2, "10 градусов" },
                    { 3, 3, "Сумеречный вид" }
                });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AirMassId", "IlluminantId", "ObserverId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ObserverId",
                table: "Project",
                column: "ObserverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AirMass_AirMassId",
                table: "Project",
                column: "AirMassId",
                principalTable: "AirMass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Illuminant_IlluminantId",
                table: "Project",
                column: "IlluminantId",
                principalTable: "Illuminant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Observer_ObserverId",
                table: "Project",
                column: "ObserverId",
                principalTable: "Observer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project",
                column: "StandartId",
                principalTable: "Standart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AirMass_AirMassId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Illuminant_IlluminantId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Observer_ObserverId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Observer");

            migrationBuilder.DropIndex(
                name: "IX_Project_ObserverId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "AirMass",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Illuminant",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Illuminant",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Illuminant",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ObserverId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "StandartId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IlluminantId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AirMassId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AirMassId", "IlluminantId" },
                values: new object[] { null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AirMass_AirMassId",
                table: "Project",
                column: "AirMassId",
                principalTable: "AirMass",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Illuminant_IlluminantId",
                table: "Project",
                column: "IlluminantId",
                principalTable: "Illuminant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Standart_StandartId",
                table: "Project",
                column: "StandartId",
                principalTable: "Standart",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
