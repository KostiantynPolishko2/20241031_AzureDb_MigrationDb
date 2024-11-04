using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceObject.Migrations
{
    /// <inheritdoc />
    public partial class SpaceObjects_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asteroid_properties_asteroid_items_FK_isAsteroidItem",
                table: "asteroid_properties");

            migrationBuilder.RenameColumn(
                name: "FK_isAsteroidItem",
                table: "asteroid_properties",
                newName: "FK_IdAsteroidItem");

            migrationBuilder.AddForeignKey(
                name: "FK_asteroid_properties_asteroid_items_FK_IdAsteroidItem",
                table: "asteroid_properties",
                column: "FK_IdAsteroidItem",
                principalTable: "asteroid_items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asteroid_properties_asteroid_items_FK_IdAsteroidItem",
                table: "asteroid_properties");

            migrationBuilder.RenameColumn(
                name: "FK_IdAsteroidItem",
                table: "asteroid_properties",
                newName: "FK_isAsteroidItem");

            migrationBuilder.AddForeignKey(
                name: "FK_asteroid_properties_asteroid_items_FK_isAsteroidItem",
                table: "asteroid_properties",
                column: "FK_isAsteroidItem",
                principalTable: "asteroid_items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
