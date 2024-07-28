using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestConfigs.Queries.GetById;

public class GetByIdRequestConfigResponse : IResponse
{
    public Guid Id { get; set; }
    public string RequestName { get; set; }
}