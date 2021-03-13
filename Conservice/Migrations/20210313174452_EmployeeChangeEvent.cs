using Microsoft.EntityFrameworkCore.Migrations;

namespace Conservice.Migrations
{
    public partial class EmployeeChangeEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChangeEvents_EmployeeId",
                table: "EmployeeChangeEvents",
                column: "EmployeeId");

            //migrationBuilder.DropForeignKey(name: "FK_EmployeeChangeEvents_Employees_EmployeeId",
            //    table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeChangeEvents_Employees_EmployeeId",
                table: "EmployeeChangeEvents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeChangeEvents_Employees_EmployeeId",
                table: "EmployeeChangeEvents");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeChangeEvents_EmployeeId",
                table: "EmployeeChangeEvents");
        }
    }
}
