using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestConfigs.Commands.Create;

public class CreatedRequestConfigResponse : IResponse
{
    public Guid Id { get; set; }
    public string RequestName { get; set; }
}