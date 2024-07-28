using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class RequestOperationClaim : Entity<Guid>
{
    public Guid RequestConfigId { get; set; }
    public virtual RequestConfig RequestConfig { get; set; }
    public int OperationClaimId { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }
}
