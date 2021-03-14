using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conservice.Migrations
{
    public partial class ShiftChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ShiftEnd",
                table: "Employees",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ShiftStart",
                table: "Employees",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "IT" },
                    { 3, "Executive" }
                });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1,
                column: "Name",
                value: "Recruiter");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2,
                column: "Name",
                value: "Senior Recruiter");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 3,
                column: "Name",
                value: "Developer");

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "Name" },
                values: new object[,]
                {
                    { 4, "Senior Developer" },
                    { 5, "CTO" },
                    { 6, "COO" },
                    { 7, "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Color", "DepartmentId", "EmploymentStatus", "End", "ManagerId", "Name", "PhoneNumber", "Photo", "PositionId", "ShiftEnd", "ShiftStart", "Start" },
                values: new object[] { 3, "103 Fake St", "Pink", 3, 0, null, null, "Alex Honnold", "9192342344", null, 7, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTime(1996, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });


            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Color", "DepartmentId", "EmploymentStatus", "End", "ManagerId", "Name", "PhoneNumber", "Photo", "PositionId", "ShiftEnd", "ShiftStart", "Start" },
                values: new object[] { 4, "104 Fake St", "Blue", 2, 0, null, 3, "Richard Valenziano", "9192362344", null, 3, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });


            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Color", "DepartmentId", "EmploymentStatus", "End", "ManagerId", "Name", "PhoneNumber", "Photo", "PositionId", "ShiftEnd", "ShiftStart", "Start" },
                values: new object[] { 2, "102 Fake St", "Blue", 1, 0, null, 3, "Sally Summers", "9192353534", null, 2, new TimeSpan(0, 21, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTime(1995, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Color", "DepartmentId", "EmploymentStatus", "End", "ManagerId", "Name", "PhoneNumber", "Photo", "PositionId", "ShiftEnd", "ShiftStart", "Start" },
                values: new object[] { 5, "104 Fake St", "Blue", 2, 0, null, 3, "Terry Tao", "9192362344", null, 4, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Color", "DepartmentId", "EmploymentStatus", "End", "ManagerId", "Name", "PhoneNumber", "Photo", "PositionId", "ShiftEnd", "ShiftStart", "Start" },
                values: new object[] { 1, "101 Fake St", "Pink", 1, 0, null, 2, "Bilbo Baggins", "9192342534", null, 1, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTime(1995, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "ShiftEnd",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ShiftStart",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shift",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1,
                column: "Name",
                value: "HR");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2,
                column: "Name",
                value: "IT");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 3,
                column: "Name",
                value: "CEO");
        }
    }
}
