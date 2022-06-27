using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyTeethAPI.Migrations
{
    public partial class dsda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesInStorage_Consumable_ConsumableId",
                table: "ConsumablesInStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesInStorage_Storage_StorageId",
                table: "ConsumablesInStorage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsumablesInStorage",
                table: "ConsumablesInStorage");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "Storages");

            migrationBuilder.RenameTable(
                name: "ConsumablesInStorage",
                newName: "ConsumablesInStorages");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumablesInStorage_ConsumableId",
                table: "ConsumablesInStorages",
                newName: "IX_ConsumablesInStorages_ConsumableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "StorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsumablesInStorages",
                table: "ConsumablesInStorages",
                columns: new[] { "StorageId", "ConsumableId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesInStorages_Consumable_ConsumableId",
                table: "ConsumablesInStorages",
                column: "ConsumableId",
                principalTable: "Consumable",
                principalColumn: "ConsumableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesInStorages_Storages_StorageId",
                table: "ConsumablesInStorages",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesInStorages_Consumable_ConsumableId",
                table: "ConsumablesInStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesInStorages_Storages_StorageId",
                table: "ConsumablesInStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsumablesInStorages",
                table: "ConsumablesInStorages");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "Storage");

            migrationBuilder.RenameTable(
                name: "ConsumablesInStorages",
                newName: "ConsumablesInStorage");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumablesInStorages_ConsumableId",
                table: "ConsumablesInStorage",
                newName: "IX_ConsumablesInStorage_ConsumableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "StorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsumablesInStorage",
                table: "ConsumablesInStorage",
                columns: new[] { "StorageId", "ConsumableId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesInStorage_Consumable_ConsumableId",
                table: "ConsumablesInStorage",
                column: "ConsumableId",
                principalTable: "Consumable",
                principalColumn: "ConsumableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesInStorage_Storage_StorageId",
                table: "ConsumablesInStorage",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
