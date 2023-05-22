using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubstationTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedSubstationMovementTableAndSomeColumnEditedFromInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubstationInventories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProcessTime",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "RemainingAmount",
                table: "Inventories",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Inventories",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Inventories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Inventories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuditId",
                table: "Inventories",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<Guid>(
                name: "SubstationMovementId",
                table: "Inventories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateTable(
                name: "SubstationMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubstationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuditId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstationMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubstationMovements_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubstationMovements_Substations_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "Substations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SubstationMovementId",
                table: "Inventories",
                column: "SubstationMovementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubstationMovements_AuditId",
                table: "SubstationMovements",
                column: "AuditId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubstationMovements_SubstationId",
                table: "SubstationMovements",
                column: "SubstationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_SubstationMovements_SubstationMovementId",
                table: "Inventories",
                column: "SubstationMovementId",
                principalTable: "SubstationMovements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_SubstationMovements_SubstationMovementId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "SubstationMovements");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SubstationMovementId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SubstationMovementId",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Inventories",
                newName: "RemainingAmount");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Inventories",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Inventories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Inventories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuditId",
                table: "Inventories",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "RemainingAmount",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric")
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Inventories",
                type: "boolean",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessTime",
                table: "Inventories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.CreateTable(
                name: "SubstationInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubstationId = table.Column<Guid>(type: "uuid", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuditId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstationInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubstationInventories_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubstationInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubstationInventories_Substations_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "Substations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubstationInventories_AuditId",
                table: "SubstationInventories",
                column: "AuditId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubstationInventories_InventoryId",
                table: "SubstationInventories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstationInventories_SubstationId",
                table: "SubstationInventories",
                column: "SubstationId");
        }
    }
}
