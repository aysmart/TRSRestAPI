using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRSRestAPI.Migrations
{
    public partial class AddAuthenticationTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegDate",
                table: "UserAuthentication",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegDate",
                table: "UserAuthentication");
        }
    }
}
