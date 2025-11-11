using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTables5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GasType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubstrateType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstrateType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GasLayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GasTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasLayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasLayers_GasType_GasTypeId",
                        column: x => x.GasTypeId,
                        principalTable: "GasType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GasLayers_Layer_Id",
                        column: x => x.Id,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVBLayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubstrateTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVBLayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PVBLayers_Layer_Id",
                        column: x => x.Id,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVBLayers_SubstrateType_SubstrateTypeId",
                        column: x => x.SubstrateTypeId,
                        principalTable: "SubstrateType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GasLayers_GasTypeId",
                table: "GasLayers",
                column: "GasTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PVBLayers_SubstrateTypeId",
                table: "PVBLayers",
                column: "SubstrateTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasLayers");

            migrationBuilder.DropTable(
                name: "PVBLayers");

            migrationBuilder.DropTable(
                name: "GasType");

            migrationBuilder.DropTable(
                name: "SubstrateType");
        }
    }
}
