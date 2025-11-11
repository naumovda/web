using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirMassId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IlluminantId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AirMass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirMass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illuminant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illuminant", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AirMassId", "IlluminantId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Project_AirMassId",
                table: "Project",
                column: "AirMassId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IlluminantId",
                table: "Project",
                column: "IlluminantId");

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

            migrationBuilder.DropTable(
                name: "AirMass");

            migrationBuilder.DropTable(
                name: "Illuminant");

            migrationBuilder.DropIndex(
                name: "IX_Project_AirMassId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_IlluminantId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "AirMassId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IlluminantId",
                table: "Project");
        }
    }
}
