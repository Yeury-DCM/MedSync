using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedSync.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OnetoonerelationshipLabTestLabResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTestLabResult");

            migrationBuilder.DropColumn(
                name: "Exaquartum",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "LabResultId",
                table: "LabTests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LabTestId",
                table: "LabResults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_LabResultId",
                table: "LabTests",
                column: "LabResultId",
                unique: true,
                filter: "[LabResultId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTests_LabResults_LabResultId",
                table: "LabTests",
                column: "LabResultId",
                principalTable: "LabResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTests_LabResults_LabResultId",
                table: "LabTests");

            migrationBuilder.DropIndex(
                name: "IX_LabTests_LabResultId",
                table: "LabTests");

            migrationBuilder.DropColumn(
                name: "LabResultId",
                table: "LabTests");

            migrationBuilder.DropColumn(
                name: "LabTestId",
                table: "LabResults");

            migrationBuilder.AddColumn<string>(
                name: "Exaquartum",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LabTestLabResult",
                columns: table => new
                {
                    LabResultsId = table.Column<int>(type: "int", nullable: false),
                    LabTestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestLabResult", x => new { x.LabResultsId, x.LabTestsId });
                    table.ForeignKey(
                        name: "FK_LabTestLabResult_LabResults_LabResultsId",
                        column: x => x.LabResultsId,
                        principalTable: "LabResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabTestLabResult_LabTests_LabTestsId",
                        column: x => x.LabTestsId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabTestLabResult_LabTestsId",
                table: "LabTestLabResult",
                column: "LabTestsId");
        }
    }
}
