using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequestOperationClaims;

public interface IRequestOperationClaimsService
{
    Task<RequestOperationClaim?> GetAsync(
        Expression<Func<RequestOperationClaim, bool>> predicate,
        Func<IQueryable<RequestOperationClaim>, IIncludableQueryable<RequestOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RequestOperationClaim>?> GetListAsync(
        Expression<Func<RequestOperationClaim, bool>>? predicate = null,
        Func<IQueryable<RequestOperationClaim>, IOrderedQueryable<RequestOperationClaim>>? orderBy = null,
        Func<IQueryable<RequestOperationClaim>, IIncludableQueryable<RequestOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RequestOperationClaim> AddAsync(RequestOperationClaim requestOperationClaims);
    Task<RequestOperationClaim> UpdateAsync(RequestOperationClaim requestOperationClaims);
    Task<RequestOperationClaim> DeleteAsync(RequestOperationClaim requestOperationClaims, bool permanent = false);
}
