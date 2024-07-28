using Application.Features.RequestConfigs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.RequestConfigs.Constants.RequestConfigsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RequestConfigs.Queries.GetList;

public class GetListRequestConfigQuery : IRequest<GetListResponse<GetListRequestConfigListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListRequestConfigQueryHandler : IRequestHandler<GetListRequestConfigQuery, GetListResponse<GetListRequestConfigListItemDto>>
    {
        private readonly IRequestConfigRepository _requestConfigRepository;
        private readonly IMapper _mapper;

        public GetListRequestConfigQueryHandler(IRequestConfigRepository requestConfigRepository, IMapper mapper)
        {
            _requestConfigRepository = requestConfigRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequestConfigListItemDto>> Handle(GetListRequestConfigQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RequestConfig> requestConfigs = await _requestConfigRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                include:i=>i.Include(i=>i.RequestOperationClaims).ThenInclude(i=>i.OperationClaim),
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRequestConfigListItemDto> response = _mapper.Map<GetListResponse<GetListRequestConfigListItemDto>>(requestConfigs);
            return response;
        }
    }
}