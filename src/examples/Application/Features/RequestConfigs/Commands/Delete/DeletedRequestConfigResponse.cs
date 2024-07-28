using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestConfigs.Commands.Delete;

public class DeletedRequestConfigResponse : IResponse
{
    public Guid Id { get; set; }
}