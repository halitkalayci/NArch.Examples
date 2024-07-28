using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequestConfigRepository : EfRepositoryBase<RequestConfig, Guid, BaseDbContext>, IRequestConfigRepository
{
    public RequestConfigRepository(BaseDbContext context) : base(context)
    {
    }
}