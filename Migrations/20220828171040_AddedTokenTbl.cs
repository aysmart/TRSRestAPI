using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRSRestAPI.Migrations
{
    public partial class AddedTokenTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserToken",
                table: "UserAuthentication");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserToken",
                table: "UserAuthentication",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
