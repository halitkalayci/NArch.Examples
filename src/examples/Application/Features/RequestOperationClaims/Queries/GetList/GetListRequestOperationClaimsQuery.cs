using Application.Features.RequestOperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.RequestOperationClaims.Constants.RequestOperationClaimsOperationClaims;

namespace Application.Features.RequestOperationClaims.Queries.GetList;

public class GetListRequestOperationClaimsQuery : IRequest<GetListResponse<GetListRequestOperationClaimsListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListRequestOperationClaimsQueryHandler : IRequestHandler<GetListRequestOperationClaimsQuery, GetListResponse<GetListRequestOperationClaimsListItemDto>>
    {
        private readonly IRequestOperationClaimsRepository _requestOperationClaimsRepository;
        private readonly IMapper _mapper;

        public GetListRequestOperationClaimsQueryHandler(IRequestOperationClaimsRepository requestOperationClaimsRepository, IMapper mapper)
        {
            _requestOperationClaimsRepository = requestOperationClaimsRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequestOperationClaimsListItemDto>> Handle(GetListRequestOperationClaimsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RequestOperationClaim> requestOperationClaims = await _requestOperationClaimsRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRequestOperationClaimsListItemDto> response = _mapper.Map<GetListResponse<GetListRequestOperationClaimsListItemDto>>(requestOperationClaims);
            return response;
        }
    }
}