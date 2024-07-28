using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequestOperationClaimsRepository : IAsyncRepository<RequestOperationClaim, Guid>, IRepository<RequestOperationClaim, Guid>
{
}