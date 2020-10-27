using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Infrastructure.Data.Configurations
{
    class ObraConfiguration : IEntityTypeConfiguration<Obra>
    {
        public void Configure(EntityTypeBuilder<Obra> builder)
        {
            builder.ToTable("Obras");

            // LLAVE PRIMARIA
            builder.HasKey(o => o.Id);

            // PROPIEDADES

            builder.Property(o => o.Id);

            builder.Property(o => o.Nombre)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(o => o.Fecha)
             .HasColumnType("datetime");

            // RELACIONES

            builder.HasOne(o => o.Artista)
                .WithMany(a => a.Obras)
                .HasForeignKey(o => o.ArtistaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(o => o.Tecnica)
                .WithMany(t => t.Obras)
                .HasForeignKey(o => o.TecnicaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
