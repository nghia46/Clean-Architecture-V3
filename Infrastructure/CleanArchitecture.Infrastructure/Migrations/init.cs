#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations;

/// <inheritdoc />
public partial class init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Products",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                Name = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                Price = table.Column<float>("real", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Products", x => x.Id); });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Products");
    }
}