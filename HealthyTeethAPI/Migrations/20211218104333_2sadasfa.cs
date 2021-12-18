using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class _2sadasfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "ClientsVisit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientsVisit_DoctorId",
                table: "ClientsVisit",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsVisit_Doctor_DoctorId",
                table: "ClientsVisit",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsVisit_Doctor_DoctorId",
                table: "ClientsVisit");

            migrationBuilder.DropIndex(
                name: "IX_ClientsVisit_DoctorId",
                table: "ClientsVisit");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "ClientsVisit");
        }
    }
}
