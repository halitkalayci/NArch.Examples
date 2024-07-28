using Application.Features.RequestConfigs.Constants;
using Application.Features.RequestConfigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestConfigs.Constants.RequestConfigsOperationClaims;

namespace Application.Features.RequestConfigs.Queries.GetById;

public class GetByIdRequestConfigQuery : IRequest<GetByIdRequestConfigResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdRequestConfigQueryHandler : IRequestHandler<GetByIdRequestConfigQuery, GetByIdRequestConfigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestConfigRepository _requestConfigRepository;
        private readonly RequestConfigBusinessRules _requestConfigBusinessRules;

        public GetByIdRequestConfigQueryHandler(IMapper mapper, IRequestConfigRepository requestConfigRepository, RequestConfigBusinessRules requestConfigBusinessRules)
        {
            _mapper = mapper;
            _requestConfigRepository = requestConfigRepository;
            _requestConfigBusinessRules = requestConfigBusinessRules;
        }

        public async Task<GetByIdRequestConfigResponse> Handle(GetByIdRequestConfigQuery request, CancellationToken cancellationToken)
        {
            RequestConfig? requestConfig = await _requestConfigRepository.GetAsync(predicate: rc => rc.Id == request.Id, cancellationToken: cancellationToken);
            await _requestConfigBusinessRules.RequestConfigShouldExistWhenSelected(requestConfig);

            GetByIdRequestConfigResponse response = _mapper.Map<GetByIdRequestConfigResponse>(requestConfig);
            return response;
        }
    }
}