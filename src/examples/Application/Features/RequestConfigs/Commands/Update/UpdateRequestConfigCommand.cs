using Application.Features.RequestConfigs.Constants;
using Application.Features.RequestConfigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RequestConfigs.Constants.RequestConfigsOperationClaims;

namespace Application.Features.RequestConfigs.Commands.Update;

public class UpdateRequestConfigCommand : IRequest<UpdatedRequestConfigResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string RequestName { get; set; }

    public string[] Roles => [Admin, Write, RequestConfigsOperationClaims.Update];

    public class UpdateRequestConfigCommandHandler : IRequestHandler<UpdateRequestConfigCommand, UpdatedRequestConfigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestConfigRepository _requestConfigRepository;
        private readonly RequestConfigBusinessRules _requestConfigBusinessRules;

        public UpdateRequestConfigCommandHandler(IMapper mapper, IRequestConfigRepository requestConfigRepository,
                                         RequestConfigBusinessRules requestConfigBusinessRules)
        {
            _mapper = mapper;
            _requestConfigRepository = requestConfigRepository;
            _requestConfigBusinessRules = requestConfigBusinessRules;
        }

        public async Task<UpdatedRequestConfigResponse> Handle(UpdateRequestConfigCommand request, CancellationToken cancellationToken)
        {
            RequestConfig? requestConfig = await _requestConfigRepository.GetAsync(predicate: rc => rc.Id == request.Id, cancellationToken: cancellationToken);
            await _requestConfigBusinessRules.RequestConfigShouldExistWhenSelected(requestConfig);
            requestConfig = _mapper.Map(request, requestConfig);

            await _requestConfigRepository.UpdateAsync(requestConfig!);

            UpdatedRequestConfigResponse response = _mapper.Map<UpdatedRequestConfigResponse>(requestConfig);
            return response;
        }
    }
}