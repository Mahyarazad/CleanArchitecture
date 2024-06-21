using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.Core.CityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config;
internal class AreaConfiguration : IEntityTypeConfiguration<Area>
{
  public void Configure(EntityTypeBuilder<Area> builder)
  {
    builder.Property(x=>x.AreaName)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(x => x.AreaDisplayName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);


    builder.HasIndex(x => x.AreaName, "IX_AreaName");

    builder.HasOne(x => x.City)
      .WithMany(x=> x.Aera)
      .HasForeignKey(x=>x.CityId)
      .HasConstraintName("FK_Area_City").IsRequired(false);
  }
}
