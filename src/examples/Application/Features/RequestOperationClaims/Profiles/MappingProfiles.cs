using Application.Features.RequestOperationClaims.Commands.Create;
using Application.Features.RequestOperationClaims.Commands.Delete;
using Application.Features.RequestOperationClaims.Commands.Update;
using Application.Features.RequestOperationClaims.Queries.GetById;
using Application.Features.RequestOperationClaims.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RequestOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RequestOperationClaim, CreateRequestOperationClaimsCommand>().ReverseMap();
        CreateMap<RequestOperationClaim, CreatedRequestOperationClaimsResponse>().ReverseMap();
        CreateMap<RequestOperationClaim, UpdateRequestOperationClaimsCommand>().ReverseMap();
        CreateMap<RequestOperationClaim, UpdatedRequestOperationClaimsResponse>().ReverseMap();
        CreateMap<RequestOperationClaim, DeleteRequestOperationClaimsCommand>().ReverseMap();
        CreateMap<RequestOperationClaim, DeletedRequestOperationClaimsResponse>().ReverseMap();
        CreateMap<RequestOperationClaim, GetByIdRequestOperationClaimsResponse>().ReverseMap();
        CreateMap<RequestOperationClaim, GetListRequestOperationClaimsListItemDto>().ReverseMap();
        CreateMap<IPaginate<RequestOperationClaim>, GetListResponse<GetListRequestOperationClaimsListItemDto>>().ReverseMap();
    }
}