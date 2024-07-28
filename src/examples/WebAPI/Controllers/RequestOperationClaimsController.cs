using Application.Features.RequestOperationClaims.Commands.Create;
using Application.Features.RequestOperationClaims.Commands.Delete;
using Application.Features.RequestOperationClaims.Commands.Update;
using Application.Features.RequestOperationClaims.Queries.GetById;
using Application.Features.RequestOperationClaims.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestOperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRequestOperationClaimsCommand createRequestOperationClaimsCommand)
    {
        CreatedRequestOperationClaimsResponse response = await Mediator.Send(createRequestOperationClaimsCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRequestOperationClaimsCommand updateRequestOperationClaimsCommand)
    {
        UpdatedRequestOperationClaimsResponse response = await Mediator.Send(updateRequestOperationClaimsCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRequestOperationClaimsResponse response = await Mediator.Send(new DeleteRequestOperationClaimsCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRequestOperationClaimsResponse response = await Mediator.Send(new GetByIdRequestOperationClaimsQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRequestOperationClaimsQuery getListRequestOperationClaimsQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRequestOperationClaimsListItemDto> response = await Mediator.Send(getListRequestOperationClaimsQuery);
        return Ok(response);
    }
}