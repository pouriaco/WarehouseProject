using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialDocumnet_Shelf_ShelfId",
                table: "SerialDocumnet");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelf_Warehouses_WarehouseId",
                table: "Shelf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelf",
                table: "Shelf");

            migrationBuilder.DropIndex(
                name: "IX_Shelf_WarehouseId",
                table: "Shelf");

            migrationBuilder.RenameTable(
                name: "Shelf",
                newName: "Shelfs");

            migrationBuilder.AlterColumn<int>(
                name: "OccupiedSpace",
                table: "Shelfs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Levels",
                table: "Shelfs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelfs",
                table: "Shelfs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialDocumnet_Shelfs_ShelfId",
                table: "SerialDocumnet",
                column: "ShelfId",
                principalTable: "Shelfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialDocumnet_Shelfs_ShelfId",
                table: "SerialDocumnet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelfs",
                table: "Shelfs");

            migrationBuilder.RenameTable(
                name: "Shelfs",
                newName: "Shelf");

            migrationBuilder.AlterColumn<int>(
                name: "OccupiedSpace",
                table: "Shelf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Levels",
                table: "Shelf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelf",
                table: "Shelf",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shelf_WarehouseId",
                table: "Shelf",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialDocumnet_Shelf_ShelfId",
                table: "SerialDocumnet",
                column: "ShelfId",
                principalTable: "Shelf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelf_Warehouses_WarehouseId",
                table: "Shelf",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
