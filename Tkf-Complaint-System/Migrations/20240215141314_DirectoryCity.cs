using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class DirectoryCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentTypeId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DirectoryCityId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentTypeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DirectoryCityId",
                table: "Departments");
        }
    }
}
