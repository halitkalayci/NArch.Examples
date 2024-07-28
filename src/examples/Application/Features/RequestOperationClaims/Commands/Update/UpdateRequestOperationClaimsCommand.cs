using Application.Features.RequestOperationClaims.Constants;
using Application.Features.RequestOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestOperationClaims.Constants.RequestOperationClaimsOperationClaims;

namespace Application.Features.RequestOperationClaims.Commands.Update;

public class UpdateRequestOperationClaimsCommand : IRequest<UpdatedRequestOperationClaimsResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid RequestConfigId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => [Admin, Write, RequestOperationClaimsOperationClaims.Update];

    public class UpdateRequestOperationClaimsCommandHandler : IRequestHandler<UpdateRequestOperationClaimsCommand, UpdatedRequestOperationClaimsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestOperationClaimsRepository _requestOperationClaimsRepository;
        private readonly RequestOperationClaimsBusinessRules _requestOperationClaimsBusinessRules;

        public UpdateRequestOperationClaimsCommandHandler(IMapper mapper, IRequestOperationClaimsRepository requestOperationClaimsRepository,
                                         RequestOperationClaimsBusinessRules requestOperationClaimsBusinessRules)
        {
            _mapper = mapper;
            _requestOperationClaimsRepository = requestOperationClaimsRepository;
            _requestOperationClaimsBusinessRules = requestOperationClaimsBusinessRules;
        }

        public async Task<UpdatedRequestOperationClaimsResponse> Handle(UpdateRequestOperationClaimsCommand request, CancellationToken cancellationToken)
        {
            RequestOperationClaim? requestOperationClaims = await _requestOperationClaimsRepository.GetAsync(predicate: roc => roc.Id == request.Id, cancellationToken: cancellationToken);
            await _requestOperationClaimsBusinessRules.RequestOperationClaimsShouldExistWhenSelected(requestOperationClaims);
            requestOperationClaims = _mapper.Map(request, requestOperationClaims);

            await _requestOperationClaimsRepository.UpdateAsync(requestOperationClaims!);

            UpdatedRequestOperationClaimsResponse response = _mapper.Map<UpdatedRequestOperationClaimsResponse>(requestOperationClaims);
            return response;
        }
    }
}