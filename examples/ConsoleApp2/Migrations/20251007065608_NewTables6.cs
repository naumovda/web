using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTables6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CoatingSurface",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatingSurface", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoatingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatingType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoatingSurface",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Inner" },
                    { 2, 2, "Outer" }
                });

            migrationBuilder.InsertData(
                table: "CoatingType",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Film" },
                    { 2, 2, "Frit" }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "CoatingSurface");

            migrationBuilder.DropTable(
                name: "CoatingType");

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
        }
    }
}
