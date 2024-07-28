using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequestConfigs;

public interface IRequestConfigService
{
    Task<RequestConfig?> GetAsync(
        Expression<Func<RequestConfig, bool>> predicate,
        Func<IQueryable<RequestConfig>, IIncludableQueryable<RequestConfig, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RequestConfig>?> GetListAsync(
        Expression<Func<RequestConfig, bool>>? predicate = null,
        Func<IQueryable<RequestConfig>, IOrderedQueryable<RequestConfig>>? orderBy = null,
        Func<IQueryable<RequestConfig>, IIncludableQueryable<RequestConfig, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RequestConfig> AddAsync(RequestConfig requestConfig);
    Task<RequestConfig> UpdateAsync(RequestConfig requestConfig);
    Task<RequestConfig> DeleteAsync(RequestConfig requestConfig, bool permanent = false);
}
