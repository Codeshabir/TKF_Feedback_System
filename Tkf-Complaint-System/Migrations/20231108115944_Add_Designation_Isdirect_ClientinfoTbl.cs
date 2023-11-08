using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class Add_Designation_Isdirect_ClientinfoTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "clientInformation",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "isDirectBeneficiary",
                table: "clientInformation",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "clientInformation");

            migrationBuilder.DropColumn(
                name: "isDirectBeneficiary",
                table: "clientInformation");
        }
    }
}
