using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequestOperationClaimsConfiguration : IEntityTypeConfiguration<RequestOperationClaim>
{
    public void Configure(EntityTypeBuilder<RequestOperationClaim> builder)
    {
        builder.ToTable("RequestOperationClaims").HasKey(roc => roc.Id);

        builder.Property(roc => roc.Id).HasColumnName("Id").IsRequired();
        builder.Property(roc => roc.RequestConfigId).HasColumnName("RequestConfigId");
        builder.Property(roc => roc.OperationClaimId).HasColumnName("OperationClaimId");
        builder.Property(roc => roc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(roc => roc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(roc => roc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(roc => !roc.DeletedDate.HasValue);
    }
}