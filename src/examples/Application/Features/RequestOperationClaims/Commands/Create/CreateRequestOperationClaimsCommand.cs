using Application.Features.RequestOperationClaims.Constants;
using Application.Features.RequestOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestOperationClaims.Constants.RequestOperationClaimsOperationClaims;

namespace Application.Features.RequestOperationClaims.Commands.Create;

public class CreateRequestOperationClaimsCommand : IRequest<CreatedRequestOperationClaimsResponse>, ISecuredRequest
{
    public Guid RequestConfigId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => [Admin, Write, RequestOperationClaimsOperationClaims.Create];

    public class CreateRequestOperationClaimsCommandHandler : IRequestHandler<CreateRequestOperationClaimsCommand, CreatedRequestOperationClaimsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestOperationClaimsRepository _requestOperationClaimsRepository;
        private readonly RequestOperationClaimsBusinessRules _requestOperationClaimsBusinessRules;

        public CreateRequestOperationClaimsCommandHandler(IMapper mapper, IRequestOperationClaimsRepository requestOperationClaimsRepository,
                                         RequestOperationClaimsBusinessRules requestOperationClaimsBusinessRules)
        {
            _mapper = mapper;
            _requestOperationClaimsRepository = requestOperationClaimsRepository;
            _requestOperationClaimsBusinessRules = requestOperationClaimsBusinessRules;
        }

        public async Task<CreatedRequestOperationClaimsResponse> Handle(CreateRequestOperationClaimsCommand request, CancellationToken cancellationToken)
        {
            RequestOperationClaim requestOperationClaims = _mapper.Map<RequestOperationClaim>(request);

            await _requestOperationClaimsRepository.AddAsync(requestOperationClaims);

            CreatedRequestOperationClaimsResponse response = _mapper.Map<CreatedRequestOperationClaimsResponse>(requestOperationClaims);
            return response;
        }
    }
}