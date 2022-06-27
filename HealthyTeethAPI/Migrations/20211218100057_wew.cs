using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class wew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsVisit_Record",
                table: "ClientsVisit");

            migrationBuilder.DropColumn(
                name: "ClientVisitId",
                table: "Record");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsVisit_Record_RecordId",
                table: "ClientsVisit",
                column: "RecordId",
                principalTable: "Record",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsVisit_Record_RecordId",
                table: "ClientsVisit");

            migrationBuilder.AddColumn<int>(
                name: "ClientVisitId",
                table: "Record",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsVisit_Record",
                table: "ClientsVisit",
                column: "RecordId",
                principalTable: "Record",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
