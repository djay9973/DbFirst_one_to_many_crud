using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbFirst_one_to_many_crud.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments_jay",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments_jay", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    ErrorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoggedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "Employees_jay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_jay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_jay_Departments_jay_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments_jay",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments_jay",
                columns: new[] { "DepartmentId", "DepartmentName", "Description" },
                values: new object[,]
                {
                    { 1, "SMD", "SMD DEPARTMENT" },
                    { 2, "POC", "POC DEPARTMENT " }
                });

            migrationBuilder.InsertData(
                table: "Employees_jay",
                columns: new[] { "Id", "DepID", "DepartmentId", "Description", "Email", "FirstName", "LastName", "Mobile" },
                values: new object[,]
                {
                    { 1, 0, null, "hi", "SMD@gmailcom", "Arya", "khan", "7878765656" },
                    { 2, 0, null, "hi mayank", "SMD123@gmailcom", "Mayank", "khanna", "7876564556" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_jay_DepartmentId",
                table: "Employees_jay",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees_jay");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "Departments_jay");
        }
    }
}
