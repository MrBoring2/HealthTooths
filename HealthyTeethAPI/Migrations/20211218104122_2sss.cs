using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class _2sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_ClientsVisit_ClientsVisitClientVisitId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record_ClientsVisitClientVisitId",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "ClientsVisitClientVisitId",
                table: "Record");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientsVisitClientVisitId",
                table: "Record",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Record_ClientsVisitClientVisitId",
                table: "Record",
                column: "ClientsVisitClientVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_ClientsVisit_ClientsVisitClientVisitId",
                table: "Record",
                column: "ClientsVisitClientVisitId",
                principalTable: "ClientsVisit",
                principalColumn: "ClientVisitId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
