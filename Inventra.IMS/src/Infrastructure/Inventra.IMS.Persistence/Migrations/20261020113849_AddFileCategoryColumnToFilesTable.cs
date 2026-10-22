using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventra.IMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFileCategoryColumnToFilesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "file_category",
                schema: "public",
                table: "files",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 16);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_category",
                schema: "public",
                table: "files");
        }
    }
}
