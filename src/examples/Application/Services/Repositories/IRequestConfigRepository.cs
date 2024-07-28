using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequestConfigRepository : IAsyncRepository<RequestConfig, Guid>, IRepository<RequestConfig, Guid>
{
}