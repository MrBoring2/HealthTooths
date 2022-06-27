using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class wsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsVisit_Record_RecordId",
                table: "ClientsVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Client",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record",
                table: "ClientsVisit");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "ClientsVisit",
                newName: "ClientId");

            migrationBuilder.AddColumn<int>(
                name: "ClientsVisitClientVisitId",
                table: "Record",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Record_ClientsVisitClientVisitId",
                table: "Record",
                column: "ClientsVisitClientVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsVisit_ClientId",
                table: "ClientsVisit",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsVisit_Client_ClientId",
                table: "ClientsVisit",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Client",
                table: "Record",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Record_ClientsVisit_ClientsVisitClientVisitId",
                table: "Record",
                column: "ClientsVisitClientVisitId",
                principalTable: "ClientsVisit",
                principalColumn: "ClientVisitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsVisit_Client_ClientId",
                table: "ClientsVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Client",
                table: "Record");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_ClientsVisit_ClientsVisitClientVisitId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record_ClientsVisitClientVisitId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_ClientsVisit_ClientId",
                table: "ClientsVisit");

            migrationBuilder.DropColumn(
                name: "ClientsVisitClientVisitId",
                table: "Record");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientsVisit",
                newName: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Record",
                table: "ClientsVisit",
                column: "RecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsVisit_Record_RecordId",
                table: "ClientsVisit",
                column: "RecordId",
                principalTable: "Record",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Client",
                table: "Record",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
