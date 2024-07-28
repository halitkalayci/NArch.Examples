using Application.Features.RequestConfigs.Constants;
using Application.Features.RequestConfigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestConfigs.Constants.RequestConfigsOperationClaims;
using Application.Services.OperationClaims;
using Application.Services.RequestOperationClaims;

namespace Application.Features.RequestConfigs.Commands.Create;

public class CreateRequestConfigCommand : IRequest<CreatedRequestConfigResponse>, ISecuredRequest
{
    public string RequestName { get; set; }
    public List<int> OperationClaims { get; set; }

    public string[] Roles => [Admin, Write, RequestConfigsOperationClaims.Create];

    public class CreateRequestConfigCommandHandler : IRequestHandler<CreateRequestConfigCommand, CreatedRequestConfigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestConfigRepository _requestConfigRepository;
        private readonly RequestConfigBusinessRules _requestConfigBusinessRules;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IRequestOperationClaimsService _requestOperationClaimsService;

        public CreateRequestConfigCommandHandler(IMapper mapper, IRequestConfigRepository requestConfigRepository,
                                         RequestConfigBusinessRules requestConfigBusinessRules, IOperationClaimService operationClaimService, IRequestOperationClaimsService requestOperationClaimsService)
        {
            _mapper = mapper;
            _requestConfigRepository = requestConfigRepository;
            _requestConfigBusinessRules = requestConfigBusinessRules;
            _operationClaimService = operationClaimService;
            _requestOperationClaimsService = requestOperationClaimsService;
        }

        public async Task<CreatedRequestConfigResponse> Handle(CreateRequestConfigCommand request, CancellationToken cancellationToken)
        {
            RequestConfig requestConfig = _mapper.Map<RequestConfig>(request);

            RequestConfig addedConfig = await _requestConfigRepository.AddAsync(requestConfig);

            foreach (var id in request.OperationClaims)
            {
                OperationClaim? claim = await _operationClaimService.GetAsync(i => i.Id == id);

                await _requestOperationClaimsService.AddAsync(new RequestOperationClaim() { OperationClaimId = claim.Id, RequestConfigId = addedConfig.Id });
            }

            CreatedRequestConfigResponse response = _mapper.Map<CreatedRequestConfigResponse>(requestConfig);
            return response;
        }
    }
}