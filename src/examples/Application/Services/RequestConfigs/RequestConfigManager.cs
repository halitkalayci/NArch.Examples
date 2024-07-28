using Application.Features.RequestConfigs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequestConfigs;

public class RequestConfigManager : IRequestConfigService
{
    private readonly IRequestConfigRepository _requestConfigRepository;
    private readonly RequestConfigBusinessRules _requestConfigBusinessRules;

    public RequestConfigManager(IRequestConfigRepository requestConfigRepository, RequestConfigBusinessRules requestConfigBusinessRules)
    {
        _requestConfigRepository = requestConfigRepository;
        _requestConfigBusinessRules = requestConfigBusinessRules;
    }

    public async Task<RequestConfig?> GetAsync(
        Expression<Func<RequestConfig, bool>> predicate,
        Func<IQueryable<RequestConfig>, IIncludableQueryable<RequestConfig, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RequestConfig? requestConfig = await _requestConfigRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return requestConfig;
    }

    public async Task<IPaginate<RequestConfig>?> GetListAsync(
        Expression<Func<RequestConfig, bool>>? predicate = null,
        Func<IQueryable<RequestConfig>, IOrderedQueryable<RequestConfig>>? orderBy = null,
        Func<IQueryable<RequestConfig>, IIncludableQueryable<RequestConfig, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RequestConfig> requestConfigList = await _requestConfigRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return requestConfigList;
    }

    public async Task<RequestConfig> AddAsync(RequestConfig requestConfig)
    {
        RequestConfig addedRequestConfig = await _requestConfigRepository.AddAsync(requestConfig);

        return addedRequestConfig;
    }

    public async Task<RequestConfig> UpdateAsync(RequestConfig requestConfig)
    {
        RequestConfig updatedRequestConfig = await _requestConfigRepository.UpdateAsync(requestConfig);

        return updatedRequestConfig;
    }

    public async Task<RequestConfig> DeleteAsync(RequestConfig requestConfig, bool permanent = false)
    {
        RequestConfig deletedRequestConfig = await _requestConfigRepository.DeleteAsync(requestConfig);

        return deletedRequestConfig;
    }
}
