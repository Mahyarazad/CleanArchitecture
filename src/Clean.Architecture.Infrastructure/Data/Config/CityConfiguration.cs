using Clean.Architecture.Core.CityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config;
internal class CityConfiguration : IEntityTypeConfiguration<City>
{
  public void Configure(EntityTypeBuilder<City> builder)
  {
    builder.Property(x => x.CityName)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(x => x.CityDisplayName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);


    builder.HasIndex(x => x.CityName, "IX_CityName");

    builder.HasMany(x => x.Aera)
      .WithOne(x => x.City)
      .HasForeignKey(x => x.CityId)
      .HasConstraintName("FK_City_Area").IsRequired(false);
  }
}
