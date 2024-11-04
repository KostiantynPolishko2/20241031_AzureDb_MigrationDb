using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceObject.Migrations
{
    /// <inheritdoc />
    public partial class SpaceObjects_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "speed",
                table: "asteroid_properties",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "speed",
                table: "asteroid_properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
