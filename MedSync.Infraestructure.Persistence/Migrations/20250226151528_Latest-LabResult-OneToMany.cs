using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedSync.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LatestLabResultOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_LabTestId",
                table: "LabResults",
                column: "LabTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabResults_LabTests_LabTestId",
                table: "LabResults",
                column: "LabTestId",
                principalTable: "LabTests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabResults_LabTests_LabTestId",
                table: "LabResults");

            migrationBuilder.DropIndex(
                name: "IX_LabResults_LabTestId",
                table: "LabResults");

            migrationBuilder.AddColumn<int>(
                name: "LabResultId",
                table: "LabTests",
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
    }
}
