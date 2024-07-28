using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OperationClaims.Queries.GetList;

public class GetListOperationClaimQuery : IRequest<List<OperationClaim>>, ISecuredRequest
{
    public string[] Roles => [OperationClaimsOperationClaims.Read];


    public class GetListOperationClaimQueryHandler
        : IRequestHandler<GetListOperationClaimQuery, List<OperationClaim>>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<List<OperationClaim>> Handle(
            GetListOperationClaimQuery request,
            CancellationToken cancellationToken
        )
        {
            List<OperationClaim> operationClaims = _operationClaimRepository.Query(
            ).ToList();

           
            return operationClaims;
        }
    }
}
