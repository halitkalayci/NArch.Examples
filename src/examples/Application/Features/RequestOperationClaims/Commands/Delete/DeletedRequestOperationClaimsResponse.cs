using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestOperationClaims.Commands.Delete;

public class DeletedRequestOperationClaimsResponse : IResponse
{
    public Guid Id { get; set; }
}