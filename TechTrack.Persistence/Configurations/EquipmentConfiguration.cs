using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTrack.Domain.Enums;
using TechTrack.Domain.Models;

namespace TechTrack.Persistence.Configurations
{
        public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
        {
            public void Configure(EntityTypeBuilder<Equipment> builder)
            {
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                builder.Property(e => e.SerialNumber)
                    .HasMaxLength(256);

                builder.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(128);

                builder.Property(e => e.Status)
                .HasMaxLength(50)
                .HasConversion(
                    v => v.ToString(),
                    v => (EquipmentStatus)Enum.Parse(typeof(EquipmentStatus), v))
                .IsUnicode(false);

                builder.HasOne(e => e.AssignedTo)
                   .WithMany(u => u.AssignedEquipments)
                   .HasForeignKey(e => e.AssignedToUserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Ignore(e => e.DomainEvents);
            }
        }
}