using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswortSeries",
                table: "Employees",
                newName: "PassportSeries");

            migrationBuilder.RenameColumn(
                name: "PasswordSeries",
                table: "Client",
                newName: "PassportSeries");

            migrationBuilder.RenameColumn(
                name: "PasswordNumber",
                table: "Client",
                newName: "PassportNumber");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "ConsumablesInStorage",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ConsumableId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumablesInStorage", x => new { x.StorageId, x.ConsumableId });
                    table.ForeignKey(
                        name: "FK_ConsumablesInStorage_Consumable_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumable",
                        principalColumn: "ConsumableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumablesInStorage_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesInStorage_ConsumableId",
                table: "ConsumablesInStorage",
                column: "ConsumableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumablesInStorage");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PassportSeries",
                table: "Employees",
                newName: "PasswortSeries");

            migrationBuilder.RenameColumn(
                name: "PassportSeries",
                table: "Client",
                newName: "PasswordSeries");

            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "Client",
                newName: "PasswordNumber");
        }
    }
}
