using Microsoft.EntityFrameworkCore.Migrations;

namespace PinArt.Infrastructure.Data.Migrations
{
    public partial class addOneTOManyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistaId",
                table: "Obras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TecnicaId",
                table: "Obras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Artistas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ArtistaId",
                table: "Obras",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_TecnicaId",
                table: "Obras",
                column: "TecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_PaisId",
                table: "Artistas",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_Paises_PaisId",
                table: "Artistas",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Artistas_ArtistaId",
                table: "Obras",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Tecnicas_TecnicaId",
                table: "Obras",
                column: "TecnicaId",
                principalTable: "Tecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_Paises_PaisId",
                table: "Artistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Artistas_ArtistaId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Tecnicas_TecnicaId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_ArtistaId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_TecnicaId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Artistas_PaisId",
                table: "Artistas");

            migrationBuilder.DropColumn(
                name: "ArtistaId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "TecnicaId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Artistas");
        }
    }
}
