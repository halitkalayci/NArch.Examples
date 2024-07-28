using Application.Features.RequestOperationClaims.Constants;
using Application.Features.RequestOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestOperationClaims.Constants.RequestOperationClaimsOperationClaims;

namespace Application.Features.RequestOperationClaims.Queries.GetById;

public class GetByIdRequestOperationClaimsQuery : IRequest<GetByIdRequestOperationClaimsResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdRequestOperationClaimsQueryHandler : IRequestHandler<GetByIdRequestOperationClaimsQuery, GetByIdRequestOperationClaimsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestOperationClaimsRepository _requestOperationClaimsRepository;
        private readonly RequestOperationClaimsBusinessRules _requestOperationClaimsBusinessRules;

        public GetByIdRequestOperationClaimsQueryHandler(IMapper mapper, IRequestOperationClaimsRepository requestOperationClaimsRepository, RequestOperationClaimsBusinessRules requestOperationClaimsBusinessRules)
        {
            _mapper = mapper;
            _requestOperationClaimsRepository = requestOperationClaimsRepository;
            _requestOperationClaimsBusinessRules = requestOperationClaimsBusinessRules;
        }

        public async Task<GetByIdRequestOperationClaimsResponse> Handle(GetByIdRequestOperationClaimsQuery request, CancellationToken cancellationToken)
        {
            RequestOperationClaim? requestOperationClaims = await _requestOperationClaimsRepository.GetAsync(predicate: roc => roc.Id == request.Id, cancellationToken: cancellationToken);
            await _requestOperationClaimsBusinessRules.RequestOperationClaimsShouldExistWhenSelected(requestOperationClaims);

            GetByIdRequestOperationClaimsResponse response = _mapper.Map<GetByIdRequestOperationClaimsResponse>(requestOperationClaims);
            return response;
        }
    }
}