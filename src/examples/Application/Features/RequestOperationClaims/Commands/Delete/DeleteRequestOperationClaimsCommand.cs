using Application.Features.RequestOperationClaims.Constants;
using Application.Features.RequestOperationClaims.Constants;
using Application.Features.RequestOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestOperationClaims.Constants.RequestOperationClaimsOperationClaims;

namespace Application.Features.RequestOperationClaims.Commands.Delete;

public class DeleteRequestOperationClaimsCommand : IRequest<DeletedRequestOperationClaimsResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, RequestOperationClaimsOperationClaims.Delete];

    public class DeleteRequestOperationClaimsCommandHandler : IRequestHandler<DeleteRequestOperationClaimsCommand, DeletedRequestOperationClaimsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestOperationClaimsRepository _requestOperationClaimsRepository;
        private readonly RequestOperationClaimsBusinessRules _requestOperationClaimsBusinessRules;

        public DeleteRequestOperationClaimsCommandHandler(IMapper mapper, IRequestOperationClaimsRepository requestOperationClaimsRepository,
                                         RequestOperationClaimsBusinessRules requestOperationClaimsBusinessRules)
        {
            _mapper = mapper;
            _requestOperationClaimsRepository = requestOperationClaimsRepository;
            _requestOperationClaimsBusinessRules = requestOperationClaimsBusinessRules;
        }

        public async Task<DeletedRequestOperationClaimsResponse> Handle(DeleteRequestOperationClaimsCommand request, CancellationToken cancellationToken)
        {
            RequestOperationClaim? requestOperationClaims = await _requestOperationClaimsRepository.GetAsync(predicate: roc => roc.Id == request.Id, cancellationToken: cancellationToken);
            await _requestOperationClaimsBusinessRules.RequestOperationClaimsShouldExistWhenSelected(requestOperationClaims);

            await _requestOperationClaimsRepository.DeleteAsync(requestOperationClaims!);

            DeletedRequestOperationClaimsResponse response = _mapper.Map<DeletedRequestOperationClaimsResponse>(requestOperationClaims);
            return response;
        }
    }
}