using Application.Features.RequestOperationClaims.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RequestOperationClaims.Rules;

public class RequestOperationClaimsBusinessRules : BaseBusinessRules
{
    private readonly IRequestOperationClaimsRepository _requestOperationClaimsRepository;
    private readonly ILocalizationService _localizationService;

    public RequestOperationClaimsBusinessRules(IRequestOperationClaimsRepository requestOperationClaimsRepository, ILocalizationService localizationService)
    {
        _requestOperationClaimsRepository = requestOperationClaimsRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RequestOperationClaimsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RequestOperationClaimsShouldExistWhenSelected(RequestOperationClaim? requestOperationClaims)
    {
        if (requestOperationClaims == null)
            await throwBusinessException(RequestOperationClaimsBusinessMessages.RequestOperationClaimsNotExists);
    }

    public async Task RequestOperationClaimsIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RequestOperationClaim? requestOperationClaims = await _requestOperationClaimsRepository.GetAsync(
            predicate: roc => roc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequestOperationClaimsShouldExistWhenSelected(requestOperationClaims);
    }
}