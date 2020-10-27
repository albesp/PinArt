using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Infrastructure.Data.Configurations
{
    class TecnicaConfiguration : IEntityTypeConfiguration<Tecnica>
    {
        public void Configure(EntityTypeBuilder<Tecnica> builder)
        {
            builder.ToTable("Tecnicas");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id);

            builder.Property(t => t.Nombre)
             .IsRequired()
             .HasMaxLength(25);

            builder.Property(t => t.Descripcion)
             .HasMaxLength(500);
        }
    }
}
