using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalBankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedBranchAndManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "Name", "PhoneNumber" },
                values: new object[] { "BR001", "Sohag", "Main Branch", "01000000000" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "BranchCode", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[] { 1, "BR001", "ahmed@bank.com", "Ahmed Mohamed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011111111" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "BR001");
        }
    }
}
