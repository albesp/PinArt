using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Infrastructure.Data.Configurations
{    
    class EstiloConfiguration : IEntityTypeConfiguration<Estilo>
    {
        public void Configure(EntityTypeBuilder<Estilo> builder)
        {
            builder.ToTable("Estilos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);

            builder.Property(t => t.Nombre)
             .IsRequired()
             .HasMaxLength(25);

            builder.Property(t => t.Descripcion)
             .HasMaxLength(500);
        }
    }
}
