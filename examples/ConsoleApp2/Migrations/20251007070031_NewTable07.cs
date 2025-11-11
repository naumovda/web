using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTable07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PVBLayers_CoatingSurface_InnerCoating_CoatingSurfaceId",
                table: "PVBLayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PVBLayers_CoatingSurface_OuterCoating_CoatingSurfaceId",
                table: "PVBLayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PVBLayers_CoatingType_InnerCoating_CoatingTypeId",
                table: "PVBLayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PVBLayers_CoatingType_OuterCoating_CoatingTypeId",
                table: "PVBLayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PVBLayers_SubstrateType_SubstrateTypeId",
                table: "PVBLayers");

            migrationBuilder.DropIndex(
                name: "IX_PVBLayers_InnerCoating_CoatingSurfaceId",
                table: "PVBLayers");

            migrationBuilder.DropIndex(
                name: "IX_PVBLayers_InnerCoating_CoatingTypeId",
                table: "PVBLayers");

            migrationBuilder.DropIndex(
                name: "IX_PVBLayers_OuterCoating_CoatingSurfaceId",
                table: "PVBLayers");

            migrationBuilder.DropIndex(
                name: "IX_PVBLayers_OuterCoating_CoatingTypeId",
                table: "PVBLayers");

            migrationBuilder.DropColumn(
                name: "InnerCoating_CoatingSurfaceId",
                table: "PVBLayers");

            migrationBuilder.DropColumn(
                name: "InnerCoating_CoatingTypeId",
                table: "PVBLayers");

            migrationBuilder.DropColumn(
                name: "OuterCoating_CoatingSurfaceId",
                table: "PVBLayers");

            migrationBuilder.DropColumn(
                name: "OuterCoating_CoatingTypeId",
                table: "PVBLayers");

            migrationBuilder.RenameColumn(
                name: "SubstrateTypeId",
                table: "PVBLayers",
                newName: "PVBTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PVBLayers_SubstrateTypeId",
                table: "PVBLayers",
                newName: "IX_PVBLayers_PVBTypeId");

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
                name: "SubstrateLayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InnerCoating_CoatingTypeId = table.Column<int>(type: "int", nullable: true),
                    InnerCoating_CoatingSurfaceId = table.Column<int>(type: "int", nullable: true),
                    OuterCoating_CoatingTypeId = table.Column<int>(type: "int", nullable: true),
                    OuterCoating_CoatingSurfaceId = table.Column<int>(type: "int", nullable: true),
                    SubstrateTypeId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_PVBLayers_PVBType_PVBTypeId",
                table: "PVBLayers",
                column: "PVBTypeId",
                principalTable: "PVBType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PVBLayers_PVBType_PVBTypeId",
                table: "PVBLayers");

            migrationBuilder.DropTable(
                name: "PVBType");

            migrationBuilder.DropTable(
                name: "SubstrateLayers");

            migrationBuilder.RenameColumn(
                name: "PVBTypeId",
                table: "PVBLayers",
                newName: "SubstrateTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PVBLayers_PVBTypeId",
                table: "PVBLayers",
                newName: "IX_PVBLayers_SubstrateTypeId");

            migrationBuilder.AddColumn<int>(
                name: "InnerCoating_CoatingSurfaceId",
                table: "PVBLayers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InnerCoating_CoatingTypeId",
                table: "PVBLayers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OuterCoating_CoatingSurfaceId",
                table: "PVBLayers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OuterCoating_CoatingTypeId",
                table: "PVBLayers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PVBLayers_InnerCoating_CoatingSurfaceId",
                table: "PVBLayers",
                column: "InnerCoating_CoatingSurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PVBLayers_InnerCoating_CoatingTypeId",
                table: "PVBLayers",
                column: "InnerCoating_CoatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PVBLayers_OuterCoating_CoatingSurfaceId",
                table: "PVBLayers",
                column: "OuterCoating_CoatingSurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PVBLayers_OuterCoating_CoatingTypeId",
                table: "PVBLayers",
                column: "OuterCoating_CoatingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PVBLayers_CoatingSurface_InnerCoating_CoatingSurfaceId",
                table: "PVBLayers",
                column: "InnerCoating_CoatingSurfaceId",
                principalTable: "CoatingSurface",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PVBLayers_CoatingSurface_OuterCoating_CoatingSurfaceId",
                table: "PVBLayers",
                column: "OuterCoating_CoatingSurfaceId",
                principalTable: "CoatingSurface",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PVBLayers_CoatingType_InnerCoating_CoatingTypeId",
                table: "PVBLayers",
                column: "InnerCoating_CoatingTypeId",
                principalTable: "CoatingType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PVBLayers_CoatingType_OuterCoating_CoatingTypeId",
                table: "PVBLayers",
                column: "OuterCoating_CoatingTypeId",
                principalTable: "CoatingType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PVBLayers_SubstrateType_SubstrateTypeId",
                table: "PVBLayers",
                column: "SubstrateTypeId",
                principalTable: "SubstrateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
