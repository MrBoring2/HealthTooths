using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Doctor_DoctorEmployeeId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record_DoctorEmployeeId",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "DoctorEmployeeId",
                table: "Record");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Record",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Record_DoctorId",
                table: "Record",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Doctor_DoctorId",
                table: "Record",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Doctor_DoctorId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record_DoctorId",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Record");

            migrationBuilder.AddColumn<int>(
                name: "DoctorEmployeeId",
                table: "Record",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Record_DoctorEmployeeId",
                table: "Record",
                column: "DoctorEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Doctor_DoctorEmployeeId",
                table: "Record",
                column: "DoctorEmployeeId",
                principalTable: "Doctor",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
