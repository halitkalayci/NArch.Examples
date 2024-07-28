using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequestConfigConfiguration : IEntityTypeConfiguration<RequestConfig>
{
    public void Configure(EntityTypeBuilder<RequestConfig> builder)
    {
        builder.ToTable("RequestConfigs").HasKey(rc => rc.Id);

        builder.Property(rc => rc.Id).HasColumnName("Id").IsRequired();
        builder.Property(rc => rc.RequestName).HasColumnName("RequestName");
        builder.Property(rc => rc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rc => rc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rc => rc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rc => !rc.DeletedDate.HasValue);
    }
}