using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinArt.Core.Entities;
using PinArt.Core.Enumerations;
using System;

namespace PinArt.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {       
         public void Configure(EntityTypeBuilder<Security> builder)
         {
                builder.ToTable("Security");

                builder.HasKey(s => s.Id);

                builder.Property(s => s.Id);

                builder.Property(s => s.User)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(s => s.Password)
                   .IsRequired()
                   .HasMaxLength(200)
                   .IsUnicode(false);

                builder.Property(s => s.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                builder.Property(s => s.Role)
                   .HasMaxLength(15)
                   .IsRequired()
                   .HasConversion(
                    x => x.ToString(),
                    x => (RoleType)Enum.Parse(typeof(RoleType), x)
                    );
         }
        
    }
}
