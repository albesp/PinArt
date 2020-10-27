using Microsoft.EntityFrameworkCore;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PinArt.Infrastructure.Data
{
    public class PinArtDbContext : DbContext
    {
        public PinArtDbContext(DbContextOptions<PinArtDbContext> options)
             : base(options)
        {

        }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<ArtistaEstilo> ArtistaEstilos { get; set; }
        public DbSet<Tecnica> Tecnicas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
