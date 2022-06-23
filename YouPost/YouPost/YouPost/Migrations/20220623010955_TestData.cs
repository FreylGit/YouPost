using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouPost.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("1d959faf-f70d-4b0e-96f5-8da74dfc93dd"), "edfb7184-b838-49a4-84d5-fd5dff870c01", "user", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d959faf-f70d-4b0e-96f5-8da74dfc93dd"));
        }
    }
}
