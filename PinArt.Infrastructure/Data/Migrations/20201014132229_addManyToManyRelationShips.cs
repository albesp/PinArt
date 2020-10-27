using Microsoft.EntityFrameworkCore.Migrations;

namespace PinArt.Infrastructure.Data.Migrations
{
    public partial class addManyToManyRelationShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistasEstilos",
                columns: table => new
                {
                    ArtistaId = table.Column<int>(nullable: false),
                    EstiloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistasEstilos", x => new { x.ArtistaId, x.EstiloId });
                    table.ForeignKey(
                        name: "FK_ArtistasEstilos_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistasEstilos_Estilos_EstiloId",
                        column: x => x.EstiloId,
                        principalTable: "Estilos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistasEstilos_EstiloId",
                table: "ArtistasEstilos",
                column: "EstiloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistasEstilos");
        }
    }
}
