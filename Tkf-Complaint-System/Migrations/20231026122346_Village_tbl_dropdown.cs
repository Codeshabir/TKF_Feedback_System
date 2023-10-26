using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class Village_tbl_dropdown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_uCs_UCId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_uCs_districts_DistrictId",
                table: "uCs");

            migrationBuilder.DropIndex(
                name: "IX_uCs_DistrictId",
                table: "uCs");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "uCs");

            migrationBuilder.RenameColumn(
                name: "UCId",
                table: "projects",
                newName: "VillageId");

            migrationBuilder.RenameIndex(
                name: "IX_projects_UCId",
                table: "projects",
                newName: "IX_projects_VillageId");

            migrationBuilder.CreateTable(
                name: "villages",
                columns: table => new
                {
                    VillageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VillageName = table.Column<string>(type: "text", nullable: false),
                    UCId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villages", x => x.VillageId);
                    table.ForeignKey(
                        name: "FK_villages_uCs_UCId",
                        column: x => x.UCId,
                        principalTable: "uCs",
                        principalColumn: "UCId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "ProjectName", "VillageId" },
                values: new object[] { "UNICEF - KHI", 1 });

            migrationBuilder.UpdateData(
                table: "projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                columns: new[] { "ProjectName", "VillageId" },
                values: new object[] { "UNICEF - Quetta", 2 });

            migrationBuilder.InsertData(
                table: "villages",
                columns: new[] { "VillageId", "UCId", "VillageName" },
                values: new object[,]
                {
                    { 1, 1, "village1" },
                    { 2, 2, "Quetta" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_villages_UCId",
                table: "villages",
                column: "UCId");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_villages_VillageId",
                table: "projects",
                column: "VillageId",
                principalTable: "villages",
                principalColumn: "VillageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_villages_VillageId",
                table: "projects");

            migrationBuilder.DropTable(
                name: "villages");

            migrationBuilder.RenameColumn(
                name: "VillageId",
                table: "projects",
                newName: "UCId");

            migrationBuilder.RenameIndex(
                name: "IX_projects_VillageId",
                table: "projects",
                newName: "IX_projects_UCId");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "uCs",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "ProjectName", "UCId" },
                values: new object[] { "Karachi", 2 });

            migrationBuilder.UpdateData(
                table: "projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                columns: new[] { "ProjectName", "UCId" },
                values: new object[] { "Quetta", 1 });

            migrationBuilder.UpdateData(
                table: "uCs",
                keyColumn: "UCId",
                keyValue: 1,
                column: "DistrictId",
                value: null);

            migrationBuilder.UpdateData(
                table: "uCs",
                keyColumn: "UCId",
                keyValue: 2,
                column: "DistrictId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_uCs_DistrictId",
                table: "uCs",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_uCs_UCId",
                table: "projects",
                column: "UCId",
                principalTable: "uCs",
                principalColumn: "UCId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uCs_districts_DistrictId",
                table: "uCs",
                column: "DistrictId",
                principalTable: "districts",
                principalColumn: "DistrictId");
        }
    }
}
