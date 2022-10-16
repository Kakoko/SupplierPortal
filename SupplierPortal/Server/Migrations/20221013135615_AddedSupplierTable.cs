using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierPortal.Server.Migrations
{
    public partial class AddedSupplierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Company", "Email", "Name" },
                values: new object[] { new Guid("4a0a65be-0479-4727-8136-4794fbe2a9db"), "GetTech Limited", "gt@get.com", "XYZ" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Company", "Email", "Name" },
                values: new object[] { new Guid("6aaf0ae1-f37a-4062-a0e8-ee7baa76d3aa"), "Cleaning Limited", "clean@clean.com", "ABC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
