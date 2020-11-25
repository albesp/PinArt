using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Infrastructure.Data.Configurations
{
    class ArtistaEstiloConfiguration : IEntityTypeConfiguration<ArtistaEstilo>
    {
        public void Configure(EntityTypeBuilder<ArtistaEstilo> builder)
        {
            builder.ToTable("ArtistasEstilos");

            // LLAVE PRIMARIA
            builder.HasKey(ae => new { ae.ArtistaId, ae.EstiloId });

            // PROPIEDADES

            builder.Property(ae => ae.ArtistaId)
                .IsRequired();

            builder.Property(oe => oe.EstiloId)
               .IsRequired();

            // RELACIONES

            builder.HasOne(ae => ae.Artista)
                .WithMany(a => a.ArtistasEstilos)
                .HasForeignKey(ae => ae.ArtistaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(ae => ae.Estilo)
                .WithMany(ae => ae.ArtistasEstilos)
                .HasForeignKey(ae => ae.EstiloId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
