using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedSync.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemakingtherelationshipbetweenLabTestandLabResultfromOneToManytoManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabResults_LabTests_LabTestId",
                table: "LabResults");

            migrationBuilder.DropIndex(
                name: "IX_LabResults_LabTestId",
                table: "LabResults");

            migrationBuilder.DropColumn(
                name: "LabTestId",
                table: "LabResults");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTestLabResult");

            migrationBuilder.AddColumn<int>(
                name: "LabTestId",
                table: "LabResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_LabTestId",
                table: "LabResults",
                column: "LabTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabResults_LabTests_LabTestId",
                table: "LabResults",
                column: "LabTestId",
                principalTable: "LabTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
