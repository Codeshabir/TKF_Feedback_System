using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class Feedback_ForiegnKey_Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_StatusId",
                table: "feedbacks",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_statuses_StatusId",
                table: "feedbacks",
                column: "StatusId",
                principalTable: "statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_statuses_StatusId",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_StatusId",
                table: "feedbacks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "feedbacks");
        }
    }
}
