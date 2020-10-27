using Microsoft.EntityFrameworkCore.Migrations;

namespace PinArt.Infrastructure.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // PAISES
            migrationBuilder.Sql("INSERT INTO Paises (Nombre) VALUES ('Holanda') ");
            migrationBuilder.Sql("INSERT INTO Paises (Nombre) VALUES ('España') ");
            migrationBuilder.Sql("INSERT INTO Paises (Nombre) VALUES ('Colombia') ");
            migrationBuilder.Sql("INSERT INTO Paises (Nombre) VALUES ('EU') ");

            // ESTILOS
            migrationBuilder.Sql("INSERT INTO Estilos (Nombre) VALUES ('Barroco') ");
            migrationBuilder.Sql("INSERT INTO Estilos (Nombre) VALUES ('Renacimiento') ");
            migrationBuilder.Sql("INSERT INTO Estilos (Nombre) VALUES ('Moderno') ");
            migrationBuilder.Sql("INSERT INTO Estilos (Nombre) VALUES ('Contemporaneo') ");

            // TECNICAS
            migrationBuilder.Sql("INSERT INTO Tecnicas (Nombre) VALUES ('Oleo') ");
            migrationBuilder.Sql("INSERT INTO Tecnicas (Nombre) VALUES ('Acuarela') ");
            migrationBuilder.Sql("INSERT INTO Tecnicas (Nombre) VALUES ('Acrilico') ");
            migrationBuilder.Sql("INSERT INTO Tecnicas (Nombre) VALUES ('Carboncillo') ");

            // ARTISTAS
            migrationBuilder.Sql("INSERT INTO Artistas (Nombre, Apellido1, Apellido2, Biografia, PaisId) VALUES ('Pablo','Picasso',null,null, (SELECT Id FROM Paises WHERE Nombre = 'España'))");
            migrationBuilder.Sql("INSERT INTO Artistas (Nombre, Apellido1, Apellido2, Biografia, PaisId) VALUES ('Fernando','Botero',null,null, (SELECT Id FROM Paises WHERE Nombre = 'Colombia'))");

            // OBRAS
            migrationBuilder.Sql("INSERT INTO Obras (Nombre, Fecha, ArtistaId, TecnicaId) VALUES ('Sin Título',null, (SELECT Id FROM Artistas WHERE Apellido1 = 'Picasso'), (SELECT Id FROM Tecnicas WHERE Nombre = 'Oleo'))");

            // ARTISTAS - ESTILOS
            migrationBuilder.Sql("INSERT INTO ArtistasEstilos (ArtistaId, EstiloId) VALUES ((SELECT Id FROM Artistas WHERE Apellido1 = 'Picasso'), (SELECT Id FROM Estilos WHERE Nombre = 'Moderno')) ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ArtistasEstilos");
            migrationBuilder.Sql("DELETE FROM Obras");
            migrationBuilder.Sql("DELETE FROM Artistas");
            migrationBuilder.Sql("DELETE FROM Tecnicas");
            migrationBuilder.Sql("DELETE FROM Estilos");
            migrationBuilder.Sql("DELETE FROM Paises");      
        }
    }
}
