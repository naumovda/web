using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTable10 : Migration
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
                name: "PVBType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVBType", x => x.Id);
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
                name: "Gas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GasTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gas_GasType_GasTypeId",
                        column: x => x.GasTypeId,
                        principalTable: "GasType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gas_Layer_Id",
                        column: x => x.Id,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PVBTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PVB_Layer_Id",
                        column: x => x.Id,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVB_PVBType_PVBTypeId",
                        column: x => x.PVBTypeId,
                        principalTable: "PVBType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Substrate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InnerCoatingId = table.Column<int>(type: "int", nullable: true),
                    OuterCoatingId = table.Column<int>(type: "int", nullable: true),
                    SubstrateTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substrate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Substrate_Coating_InnerCoatingId",
                        column: x => x.InnerCoatingId,
                        principalTable: "Coating",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Substrate_Coating_OuterCoatingId",
                        column: x => x.OuterCoatingId,
                        principalTable: "Coating",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Substrate_Layer_Id",
                        column: x => x.Id,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Substrate_SubstrateType_SubstrateTypeId",
                        column: x => x.SubstrateTypeId,
                        principalTable: "SubstrateType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gas_GasTypeId",
                table: "Gas",
                column: "GasTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PVB_PVBTypeId",
                table: "PVB",
                column: "PVBTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Substrate_InnerCoatingId",
                table: "Substrate",
                column: "InnerCoatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Substrate_OuterCoatingId",
                table: "Substrate",
                column: "OuterCoatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Substrate_SubstrateTypeId",
                table: "Substrate",
                column: "SubstrateTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gas");

            migrationBuilder.DropTable(
                name: "PVB");

            migrationBuilder.DropTable(
                name: "Substrate");

            migrationBuilder.DropTable(
                name: "GasType");

            migrationBuilder.DropTable(
                name: "PVBType");

            migrationBuilder.DropTable(
                name: "SubstrateType");
        }
    }
}
