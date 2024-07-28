using Application.Features.RequestConfigs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RequestConfigs.Rules;

public class RequestConfigBusinessRules : BaseBusinessRules
{
    private readonly IRequestConfigRepository _requestConfigRepository;
    private readonly ILocalizationService _localizationService;

    public RequestConfigBusinessRules(IRequestConfigRepository requestConfigRepository, ILocalizationService localizationService)
    {
        _requestConfigRepository = requestConfigRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RequestConfigsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RequestConfigShouldExistWhenSelected(RequestConfig? requestConfig)
    {
        if (requestConfig == null)
            await throwBusinessException(RequestConfigsBusinessMessages.RequestConfigNotExists);
    }

    public async Task RequestConfigIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RequestConfig? requestConfig = await _requestConfigRepository.GetAsync(
            predicate: rc => rc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequestConfigShouldExistWhenSelected(requestConfig);
    }
}