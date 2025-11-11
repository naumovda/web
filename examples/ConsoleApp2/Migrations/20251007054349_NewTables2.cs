using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class NewTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makeup_Project_ProjectId",
                table: "Makeup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParameterValue",
                table: "ParameterValue");

            migrationBuilder.DropIndex(
                name: "IX_ParameterValue_ParameterId",
                table: "ParameterValue");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Makeup",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalculationStateId",
                table: "Makeup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Makeup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Makeup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MakeupTypeId",
                table: "Makeup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Makeup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "NominalWeight",
                table: "Makeup",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ParameterId",
                table: "Makeup",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slope",
                table: "Makeup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SoundReduction",
                table: "Makeup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Makeup",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParameterValue",
                table: "ParameterValue",
                columns: new[] { "ParameterId", "MakeupId" });

            migrationBuilder.CreateTable(
                name: "CalculationState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MakeupType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeupType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarningType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarningType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CalculationState",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Calculated" },
                    { 2, 2, "Has warnings" },
                    { 3, 3, "Has errors" }
                });

            migrationBuilder.InsertData(
                table: "MakeupType",
                columns: new[] { "Id", "Code", "Icon", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, 1, "mono.png", "Mono", "Mono" },
                    { 2, 2, "double.png", "Double", "DBU" },
                    { 3, 3, "tripe.png", "Triple", "TBU" }
                });

            migrationBuilder.InsertData(
                table: "WarningType",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Error" },
                    { 2, 2, "Warning" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValue_MakeupId",
                table: "ParameterValue",
                column: "MakeupId");

            migrationBuilder.CreateIndex(
                name: "IX_Makeup_CalculationStateId",
                table: "Makeup",
                column: "CalculationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Makeup_MakeupTypeId",
                table: "Makeup",
                column: "MakeupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Makeup_ParameterId",
                table: "Makeup",
                column: "ParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makeup_CalculationState_CalculationStateId",
                table: "Makeup",
                column: "CalculationStateId",
                principalTable: "CalculationState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Makeup_MakeupType_MakeupTypeId",
                table: "Makeup",
                column: "MakeupTypeId",
                principalTable: "MakeupType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Makeup_Parameter_ParameterId",
                table: "Makeup",
                column: "ParameterId",
                principalTable: "Parameter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Makeup_Project_ProjectId",
                table: "Makeup",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makeup_CalculationState_CalculationStateId",
                table: "Makeup");

            migrationBuilder.DropForeignKey(
                name: "FK_Makeup_MakeupType_MakeupTypeId",
                table: "Makeup");

            migrationBuilder.DropForeignKey(
                name: "FK_Makeup_Parameter_ParameterId",
                table: "Makeup");

            migrationBuilder.DropForeignKey(
                name: "FK_Makeup_Project_ProjectId",
                table: "Makeup");

            migrationBuilder.DropTable(
                name: "CalculationState");

            migrationBuilder.DropTable(
                name: "MakeupType");

            migrationBuilder.DropTable(
                name: "WarningType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParameterValue",
                table: "ParameterValue");

            migrationBuilder.DropIndex(
                name: "IX_ParameterValue_MakeupId",
                table: "ParameterValue");

            migrationBuilder.DropIndex(
                name: "IX_Makeup_CalculationStateId",
                table: "Makeup");

            migrationBuilder.DropIndex(
                name: "IX_Makeup_MakeupTypeId",
                table: "Makeup");

            migrationBuilder.DropIndex(
                name: "IX_Makeup_ParameterId",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "CalculationStateId",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "MakeupTypeId",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "NominalWeight",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "ParameterId",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "Slope",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "SoundReduction",
                table: "Makeup");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Makeup");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Makeup",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParameterValue",
                table: "ParameterValue",
                columns: new[] { "MakeupId", "ParameterId" });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValue_ParameterId",
                table: "ParameterValue",
                column: "ParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makeup_Project_ProjectId",
                table: "Makeup",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
