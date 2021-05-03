using rs_service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace rs_service.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            // maps "Property" domain object to the database table "Properties"
            builder.ToTable("Properties");

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ZipCode).HasColumnName("Zip").HasMaxLength(5);
        }
    }
}
