using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestOperationClaims.Commands.Create;

public class CreatedRequestOperationClaimsResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RequestConfigId { get; set; }
    public int OperationClaimId { get; set; }
}