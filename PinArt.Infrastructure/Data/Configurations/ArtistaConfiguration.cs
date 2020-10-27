using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Infrastructure.Data.Configurations
{
    class ArtistaConfiguration : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artistas");

            // LLAVE PRIMARIA
            builder.HasKey(a => a.Id);

            // PROPIEDADES

            builder.Property(a => a.Id);

            builder.Property(a => a.Nombre)
             .IsRequired()
             .HasMaxLength(25);

            builder.Property(a => a.Apellido1)
              .IsRequired()
              .HasMaxLength(25);

            builder.Property(a => a.Apellido2)
              .HasMaxLength(25);

            builder.Property(a => a.Biografia)
              .HasMaxLength(500);

            builder.Property(a => a.PaisId);
              

            // RELACIONES

            builder.HasOne(a => a.Pais)
                .WithMany(p => p.Artistas)
                .HasForeignKey(a => a.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
