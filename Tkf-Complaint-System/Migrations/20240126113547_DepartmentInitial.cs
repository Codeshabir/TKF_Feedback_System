using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tkf_Complaint_System.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DeptSubType_DeptSubTypeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeptSubType_DepartmentType_DepartmentTypeId",
                table: "DeptSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeptSubType",
                table: "DeptSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentType",
                table: "DepartmentType");

            migrationBuilder.RenameTable(
                name: "DeptSubType",
                newName: "DeptSubTypes");

            migrationBuilder.RenameTable(
                name: "DepartmentType",
                newName: "DepartmentTypes");

            migrationBuilder.RenameIndex(
                name: "IX_DeptSubType_DepartmentTypeId",
                table: "DeptSubTypes",
                newName: "IX_DeptSubTypes_DepartmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeptSubTypes",
                table: "DeptSubTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentTypes",
                table: "DepartmentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DeptSubTypes_DeptSubTypeId",
                table: "Departments",
                column: "DeptSubTypeId",
                principalTable: "DeptSubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeptSubTypes_DepartmentTypes_DepartmentTypeId",
                table: "DeptSubTypes",
                column: "DepartmentTypeId",
                principalTable: "DepartmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DeptSubTypes_DeptSubTypeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeptSubTypes_DepartmentTypes_DepartmentTypeId",
                table: "DeptSubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeptSubTypes",
                table: "DeptSubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentTypes",
                table: "DepartmentTypes");

            migrationBuilder.RenameTable(
                name: "DeptSubTypes",
                newName: "DeptSubType");

            migrationBuilder.RenameTable(
                name: "DepartmentTypes",
                newName: "DepartmentType");

            migrationBuilder.RenameIndex(
                name: "IX_DeptSubTypes_DepartmentTypeId",
                table: "DeptSubType",
                newName: "IX_DeptSubType_DepartmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeptSubType",
                table: "DeptSubType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentType",
                table: "DepartmentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DeptSubType_DeptSubTypeId",
                table: "Departments",
                column: "DeptSubTypeId",
                principalTable: "DeptSubType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeptSubType_DepartmentType_DepartmentTypeId",
                table: "DeptSubType",
                column: "DepartmentTypeId",
                principalTable: "DepartmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
