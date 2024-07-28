using Application.Features.RequestOperationClaims.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequestOperationClaims;

public class RequestOperationClaimsManager : IRequestOperationClaimsService
{
    private readonly IRequestOperationClaimsRepository _requestOperationClaimsRepository;
    private readonly RequestOperationClaimsBusinessRules _requestOperationClaimsBusinessRules;

    public RequestOperationClaimsManager(IRequestOperationClaimsRepository requestOperationClaimsRepository, RequestOperationClaimsBusinessRules requestOperationClaimsBusinessRules)
    {
        _requestOperationClaimsRepository = requestOperationClaimsRepository;
        _requestOperationClaimsBusinessRules = requestOperationClaimsBusinessRules;
    }

    public async Task<RequestOperationClaim?> GetAsync(
        Expression<Func<RequestOperationClaim, bool>> predicate,
        Func<IQueryable<RequestOperationClaim>, IIncludableQueryable<RequestOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RequestOperationClaim? requestOperationClaims = await _requestOperationClaimsRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return requestOperationClaims;
    }

    public async Task<IPaginate<RequestOperationClaim>?> GetListAsync(
        Expression<Func<RequestOperationClaim, bool>>? predicate = null,
        Func<IQueryable<RequestOperationClaim>, IOrderedQueryable<RequestOperationClaim>>? orderBy = null,
        Func<IQueryable<RequestOperationClaim>, IIncludableQueryable<RequestOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RequestOperationClaim> requestOperationClaimsList = await _requestOperationClaimsRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return requestOperationClaimsList;
    }

    public async Task<RequestOperationClaim> AddAsync(RequestOperationClaim requestOperationClaims)
    {
        RequestOperationClaim addedRequestOperationClaims = await _requestOperationClaimsRepository.AddAsync(requestOperationClaims);

        return addedRequestOperationClaims;
    }

    public async Task<RequestOperationClaim> UpdateAsync(RequestOperationClaim requestOperationClaims)
    {
        RequestOperationClaim updatedRequestOperationClaims = await _requestOperationClaimsRepository.UpdateAsync(requestOperationClaims);

        return updatedRequestOperationClaims;
    }

    public async Task<RequestOperationClaim> DeleteAsync(RequestOperationClaim requestOperationClaims, bool permanent = false)
    {
        RequestOperationClaim deletedRequestOperationClaims = await _requestOperationClaimsRepository.DeleteAsync(requestOperationClaims);

        return deletedRequestOperationClaims;
    }
}
