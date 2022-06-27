using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class editClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientLogin",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ClientPassword",
                table: "Client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientLogin",
                table: "Client",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientPassword",
                table: "Client",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
