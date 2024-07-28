using Application.Features.RequestConfigs.Constants;
using Application.Features.RequestConfigs.Constants;
using Application.Features.RequestConfigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestConfigs.Constants.RequestConfigsOperationClaims;

namespace Application.Features.RequestConfigs.Commands.Delete;

public class DeleteRequestConfigCommand : IRequest<DeletedRequestConfigResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, RequestConfigsOperationClaims.Delete];

    public class DeleteRequestConfigCommandHandler : IRequestHandler<DeleteRequestConfigCommand, DeletedRequestConfigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestConfigRepository _requestConfigRepository;
        private readonly RequestConfigBusinessRules _requestConfigBusinessRules;

        public DeleteRequestConfigCommandHandler(IMapper mapper, IRequestConfigRepository requestConfigRepository,
                                         RequestConfigBusinessRules requestConfigBusinessRules)
        {
            _mapper = mapper;
            _requestConfigRepository = requestConfigRepository;
            _requestConfigBusinessRules = requestConfigBusinessRules;
        }

        public async Task<DeletedRequestConfigResponse> Handle(DeleteRequestConfigCommand request, CancellationToken cancellationToken)
        {
            RequestConfig? requestConfig = await _requestConfigRepository.GetAsync(predicate: rc => rc.Id == request.Id, cancellationToken: cancellationToken);
            await _requestConfigBusinessRules.RequestConfigShouldExistWhenSelected(requestConfig);

            await _requestConfigRepository.DeleteAsync(requestConfig!);

            DeletedRequestConfigResponse response = _mapper.Map<DeletedRequestConfigResponse>(requestConfig);
            return response;
        }
    }
}