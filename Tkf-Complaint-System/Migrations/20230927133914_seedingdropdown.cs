using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class seedingdropdown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProvinceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictName = table.Column<string>(type: "text", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_districts_provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_cities_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uCs",
                columns: table => new
                {
                    UCId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UCName = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uCs", x => x.UCId);
                    table.ForeignKey(
                        name: "FK_uCs_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uCs_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "DistrictId");
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectName = table.Column<string>(type: "text", nullable: false),
                    UCId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_projects_uCs_UCId",
                        column: x => x.UCId,
                        principalTable: "uCs",
                        principalColumn: "UCId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "provinces",
                columns: new[] { "ProvinceId", "ProvinceName" },
                values: new object[,]
                {
                    { 1, "Baluchistan" },
                    { 2, "Sindh" }
                });

            migrationBuilder.InsertData(
                table: "districts",
                columns: new[] { "DistrictId", "DistrictName", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Karachi", 2 },
                    { 2, "Quetta", 1 }
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "CityId", "CityName", "DistrictId" },
                values: new object[,]
                {
                    { 1, "Karachi", 1 },
                    { 2, "Quetta", 2 }
                });

            migrationBuilder.InsertData(
                table: "uCs",
                columns: new[] { "UCId", "CityId", "DistrictId", "UCName" },
                values: new object[,]
                {
                    { 1, 1, null, "North Karachi" },
                    { 2, 2, null, "Quetta Mariabad" }
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "ProjectId", "ProjectName", "UCId" },
                values: new object[,]
                {
                    { 1, "Karachi", 2 },
                    { 2, "Quetta", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_DistrictId",
                table: "cities",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_ProvinceId",
                table: "districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_UCId",
                table: "projects",
                column: "UCId");

            migrationBuilder.CreateIndex(
                name: "IX_uCs_CityId",
                table: "uCs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_uCs_DistrictId",
                table: "uCs",
                column: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "uCs");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "provinces");
        }
    }
}
