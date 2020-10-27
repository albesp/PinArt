using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinArt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Infrastructure.Data.Configurations
{
    class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {        
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.Nombre)
             .IsRequired()
             .HasMaxLength(25);
        }
    }
}