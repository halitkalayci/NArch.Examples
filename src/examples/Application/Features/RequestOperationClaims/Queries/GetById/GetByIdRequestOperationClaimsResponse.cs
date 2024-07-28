using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestOperationClaims.Queries.GetById;

public class GetByIdRequestOperationClaimsResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RequestConfigId { get; set; }
    public int OperationClaimId { get; set; }
}