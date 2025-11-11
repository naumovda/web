using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTable08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasLayers");

            migrationBuilder.DropTable(
                name: "PVBLayers");

            migrationBuilder.DropTable(
                name: "SubstrateLayers");

            migrationBuilder.DropTable(
                name: "GasType");

            migrationBuilder.DropTable(
                name: "PVBType");

            migrationBuilder.DropTable(
                name: "SubstrateType");

            migrationBuilder.CreateSequence(
                name: "CoatingSequence");

            migrationBuilder.CreateTable(
                name: "Coating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [CoatingSequence]"),
                    CoatingTypeId = table.Column<int>(type: "int", nullable: true),
                    CoatingSurfaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coating_CoatingSurface_CoatingSurfaceId",
                        column: x => x.CoatingSurfaceId,
                        principalTable: "CoatingSurface",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coating_CoatingType_CoatingTypeId",
                        column: x => x.CoatingTypeId,
                        principalTable: "CoatingType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coating_CoatingSurfaceId",
                table: "Coating",
                column: "CoatingSurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Coating_CoatingTypeId",
                table: "Coating",
                column: "CoatingTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coating");

            migrationBuilder.DropSequence(
                name: "CoatingSequence");

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
                    PVBTypeId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_PVBLayers_PVBType_PVBTypeId",
                        column: x => x.PVBTypeId,
                        principalTable: "PVBType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubstrateLayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubstrateTypeId = table.Column<int>(type: "int", nullable: false),
                    InnerCoating_CoatingSurfaceId = table.Column<int>(type: "int", nullable: true),
                    InnerCoating_CoatingTypeId = table.Column<int>(type: "int", nullable: true),
                    OuterCoating_CoatingSurfaceId = table.Column<int>(type: "int", nullable: true),
                    OuterCoating_CoatingTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstrateLayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubstrateLayers_CoatingSurface_InnerCoating_CoatingSurfaceId",
                        column: x => x.InnerCoating_CoatingSurfaceId,
                        principalTable: "CoatingSurface",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubstrateLayers_CoatingSurface_OuterCoating_CoatingSurfaceId",
                        column: x => x.OuterCoating_CoatingSurfaceId,
                        principalTable: "CoatingSurface",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubstrateLayers_CoatingType_InnerCoating_CoatingTypeId",
                        column: x => x.InnerCoating_CoatingTypeId,
                        principalTable: "CoatingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubstrateLayers_CoatingType_OuterCoating_CoatingTypeId",
                        column: x => x.OuterCoating_CoatingTypeId,
                        principalTable: "CoatingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubstrateLayers_Layer_Id",
                        column: x => x.Id,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubstrateLayers_SubstrateType_SubstrateTypeId",
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
                name: "IX_PVBLayers_PVBTypeId",
                table: "PVBLayers",
                column: "PVBTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstrateLayers_InnerCoating_CoatingSurfaceId",
                table: "SubstrateLayers",
                column: "InnerCoating_CoatingSurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstrateLayers_InnerCoating_CoatingTypeId",
                table: "SubstrateLayers",
                column: "InnerCoating_CoatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstrateLayers_OuterCoating_CoatingSurfaceId",
                table: "SubstrateLayers",
                column: "OuterCoating_CoatingSurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstrateLayers_OuterCoating_CoatingTypeId",
                table: "SubstrateLayers",
                column: "OuterCoating_CoatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstrateLayers_SubstrateTypeId",
                table: "SubstrateLayers",
                column: "SubstrateTypeId");
        }
    }
}
