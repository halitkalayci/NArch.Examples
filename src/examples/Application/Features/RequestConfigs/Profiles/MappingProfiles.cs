using Application.Features.RequestConfigs.Commands.Create;
using Application.Features.RequestConfigs.Commands.Delete;
using Application.Features.RequestConfigs.Commands.Update;
using Application.Features.RequestConfigs.Queries.GetById;
using Application.Features.RequestConfigs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RequestConfigs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RequestConfig, CreateRequestConfigCommand>().ReverseMap();
        CreateMap<RequestConfig, CreatedRequestConfigResponse>().ReverseMap();
        CreateMap<RequestConfig, UpdateRequestConfigCommand>().ReverseMap();
        CreateMap<RequestConfig, UpdatedRequestConfigResponse>().ReverseMap();
        CreateMap<RequestConfig, DeleteRequestConfigCommand>().ReverseMap();
        CreateMap<RequestConfig, DeletedRequestConfigResponse>().ReverseMap();
        CreateMap<RequestConfig, GetByIdRequestConfigResponse>().ReverseMap();
        CreateMap<RequestConfig, GetListRequestConfigListItemDto>()
            .ForMember(m=>m.Claims, opt => opt.MapFrom(i=>i.RequestOperationClaims.Select(j=>j.OperationClaim).ToList()))
            .ForMember(m => m.ClaimIds, opt => opt.MapFrom(i => i.RequestOperationClaims.Select(j => j.OperationClaim.Id).ToList()))
            .ReverseMap();
        CreateMap<IPaginate<RequestConfig>, GetListResponse<GetListRequestConfigListItemDto>>().ReverseMap();
    }
}