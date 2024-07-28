using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequestOperationClaimsRepository : EfRepositoryBase<RequestOperationClaim, Guid, BaseDbContext>, IRequestOperationClaimsRepository
{
    public RequestOperationClaimsRepository(BaseDbContext context) : base(context)
    {
    }
}