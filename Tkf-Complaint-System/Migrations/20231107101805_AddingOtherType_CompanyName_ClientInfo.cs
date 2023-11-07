using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class AddingOtherType_CompanyName_ClientInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherType",
                table: "clientInformation",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OthersCompanyName",
                table: "clientInformation",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherType",
                table: "clientInformation");

            migrationBuilder.DropColumn(
                name: "OthersCompanyName",
                table: "clientInformation");
        }
    }
}
