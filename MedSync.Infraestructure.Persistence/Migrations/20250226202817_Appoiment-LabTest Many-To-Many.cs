using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedSync.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppoimentLabTestManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTests_Appoiments_AppoimentId",
                table: "LabTests");

            migrationBuilder.DropIndex(
                name: "IX_LabTests_AppoimentId",
                table: "LabTests");

            migrationBuilder.DropColumn(
                name: "AppoimentId",
                table: "LabTests");

            migrationBuilder.CreateTable(
                name: "AppoimentLabTest",
                columns: table => new
                {
                    AppoimentsId = table.Column<int>(type: "int", nullable: false),
                    LabTestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppoimentLabTest", x => new { x.AppoimentsId, x.LabTestsId });
                    table.ForeignKey(
                        name: "FK_AppoimentLabTest_Appoiments_AppoimentsId",
                        column: x => x.AppoimentsId,
                        principalTable: "Appoiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppoimentLabTest_LabTests_LabTestsId",
                        column: x => x.LabTestsId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppoimentLabTest_LabTestsId",
                table: "AppoimentLabTest",
                column: "LabTestsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppoimentLabTest");

            migrationBuilder.AddColumn<int>(
                name: "AppoimentId",
                table: "LabTests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_AppoimentId",
                table: "LabTests",
                column: "AppoimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTests_Appoiments_AppoimentId",
                table: "LabTests",
                column: "AppoimentId",
                principalTable: "Appoiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
