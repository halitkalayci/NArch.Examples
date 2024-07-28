using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RequestConfigs.Queries.GetList;

public class GetListRequestConfigListItemDto : IDto
{
    public Guid Id { get; set; }
    public string RequestName { get; set; }
    public List<OperationClaim> Claims { get; set; }
    public List<int> ClaimIds { get; set; }
}