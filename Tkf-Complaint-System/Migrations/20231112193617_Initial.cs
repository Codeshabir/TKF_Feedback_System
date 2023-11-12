using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OthersCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallBackMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDirectBeneficiary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "feedbackTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project_Tbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Donor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectUC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_Tbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "feedbackSubtypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackSubtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackSubtypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feedbackSubtypes_feedbackTypes_FeedbackTypeId",
                        column: x => x.FeedbackTypeId,
                        principalTable: "feedbackTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
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
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ComplaintDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintFeedbackRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedBackPriority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FeedbackByAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feedbacks_clientInformation_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clientInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedbacks_project_Tbls_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project_Tbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedbacks_statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
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
                    UCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UCName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "villages",
                columns: table => new
                {
                    VillageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UCId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_projects_villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "villages",
                        principalColumn: "VillageId",
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
                columns: new[] { "UCId", "CityId", "UCName" },
                values: new object[,]
                {
                    { 1, 1, "North Karachi" },
                    { 2, 2, "Quetta Mariabad" }
                });

            migrationBuilder.InsertData(
                table: "villages",
                columns: new[] { "VillageId", "UCId", "VillageName" },
                values: new object[,]
                {
                    { 1, 1, "Village1" },
                    { 2, 2, "Quetta Village" }
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "ProjectId", "ProjectName", "VillageId" },
                values: new object[,]
                {
                    { 1, "UNICEF - KHI", 1 },
                    { 2, "UNICEF - Quetta", 2 }
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
                name: "IX_feedbacks_ClientId",
                table: "feedbacks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_ProjectId",
                table: "feedbacks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_StatusId",
                table: "feedbacks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbackSubtypes_FeedbackTypeId",
                table: "feedbackSubtypes",
                column: "FeedbackTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_VillageId",
                table: "projects",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_uCs_CityId",
                table: "uCs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_villages_UCId",
                table: "villages",
                column: "UCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "feedbackSubtypes");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "clientInformation");

            migrationBuilder.DropTable(
                name: "project_Tbls");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "feedbackTypes");

            migrationBuilder.DropTable(
                name: "villages");

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
