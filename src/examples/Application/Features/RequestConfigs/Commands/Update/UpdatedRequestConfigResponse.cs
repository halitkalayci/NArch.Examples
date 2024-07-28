using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestConfigs.Commands.Update;

public class UpdatedRequestConfigResponse : IResponse
{
    public Guid Id { get; set; }
    public string RequestName { get; set; }
}