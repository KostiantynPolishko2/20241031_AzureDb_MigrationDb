using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceObject.Migrations
{
    /// <inheritdoc />
    public partial class SpaceObjects_00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asteroid_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asteroid_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asteroid_properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    speed = table.Column<int>(type: "int", nullable: false),
                    FK_isAsteroidItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asteroid_properties", x => x.id);
                    table.ForeignKey(
                        name: "FK_asteroid_properties_asteroid_items_FK_isAsteroidItem",
                        column: x => x.FK_isAsteroidItem,
                        principalTable: "asteroid_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsteroidProperty_idAsteroidItem",
                table: "asteroid_properties",
                column: "FK_isAsteroidItem",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asteroid_properties");

            migrationBuilder.DropTable(
                name: "asteroid_items");
        }
    }
}
