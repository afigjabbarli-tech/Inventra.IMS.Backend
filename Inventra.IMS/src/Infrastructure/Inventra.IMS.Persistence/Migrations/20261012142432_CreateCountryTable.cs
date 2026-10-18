using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventra.IMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateCountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "public",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    common_name = table.Column<string>(type: "text", nullable: false),
                    official_name = table.Column<string>(type: "text", nullable: false),
                    native_name = table.Column<string>(type: "text", nullable: false),
                    alpha2_code = table.Column<string>(type: "varchar(2)", nullable: false),
                    alpha3_code = table.Column<string>(type: "varchar(3)", nullable: false),
                    numeric_code = table.Column<string>(type: "varchar(3)", nullable: false),
                    tld = table.Column<string>(type: "varchar(10)", nullable: false),
                    overview = table.Column<string>(type: "text", nullable: true),
                    capital = table.Column<string>(type: "text", nullable: false),
                    phone_code = table.Column<string>(type: "varchar(10)", nullable: false),
                    largest_city_by_area = table.Column<string>(type: "text", nullable: true),
                    smallest_city_by_area = table.Column<string>(type: "text", nullable: true),
                    area_km2 = table.Column<double>(type: "double precision", nullable: false),
                    population = table.Column<long>(type: "bigint", nullable: false),
                    demonym = table.Column<string>(type: "text", nullable: true),
                    gdp = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.uid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countries",
                schema: "public");
        }
    }
}
