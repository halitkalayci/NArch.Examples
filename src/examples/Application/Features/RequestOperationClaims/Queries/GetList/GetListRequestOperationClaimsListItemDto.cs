using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RequestOperationClaims.Queries.GetList;

public class GetListRequestOperationClaimsListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid RequestConfigId { get; set; }
    public int OperationClaimId { get; set; }
}