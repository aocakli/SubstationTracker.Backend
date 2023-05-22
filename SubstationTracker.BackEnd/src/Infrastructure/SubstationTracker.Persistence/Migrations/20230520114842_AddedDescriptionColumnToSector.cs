using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubstationTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionColumnToSector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Sectors",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sectors",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sectors");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Sectors",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 4);
        }
    }
}
