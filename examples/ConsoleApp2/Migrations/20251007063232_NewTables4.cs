using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTables4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LayerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MakeupWarning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarningTypeId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeupWarning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MakeupWarning_Makeup_MakeupId",
                        column: x => x.MakeupId,
                        principalTable: "Makeup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MakeupWarning_WarningType_WarningTypeId",
                        column: x => x.WarningTypeId,
                        principalTable: "WarningType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Layer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    LayerTypeId = table.Column<int>(type: "int", nullable: false),
                    MakeupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layer_LayerType_LayerTypeId",
                        column: x => x.LayerTypeId,
                        principalTable: "LayerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Layer_Makeup_MakeupId",
                        column: x => x.MakeupId,
                        principalTable: "Makeup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LayerType",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Substrate" },
                    { 2, 2, "AirGap" },
                    { 3, 3, "PVB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Layer_LayerTypeId",
                table: "Layer",
                column: "LayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Layer_MakeupId",
                table: "Layer",
                column: "MakeupId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeupWarning_MakeupId",
                table: "MakeupWarning",
                column: "MakeupId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeupWarning_WarningTypeId",
                table: "MakeupWarning",
                column: "WarningTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Layer");

            migrationBuilder.DropTable(
                name: "MakeupWarning");

            migrationBuilder.DropTable(
                name: "LayerType");
        }
    }
}
