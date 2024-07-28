using Application.Features.RequestConfigs.Commands.Create;
using Application.Features.RequestConfigs.Commands.Delete;
using Application.Features.RequestConfigs.Commands.Update;
using Application.Features.RequestConfigs.Queries.GetById;
using Application.Features.RequestConfigs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Configuration.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestConfigsController : BaseController
{
    private readonly IServiceProvider _serviceProvider;

    public RequestConfigsController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpGet("Reload")]
    public async Task<IActionResult> Reload()
    {
        RoleConfigurationManager.LoadRoles();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRequestConfigCommand createRequestConfigCommand)
    {
        CreatedRequestConfigResponse response = await Mediator.Send(createRequestConfigCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRequestConfigCommand updateRequestConfigCommand)
    {
        UpdatedRequestConfigResponse response = await Mediator.Send(updateRequestConfigCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRequestConfigResponse response = await Mediator.Send(new DeleteRequestConfigCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRequestConfigResponse response = await Mediator.Send(new GetByIdRequestConfigQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListRequestConfigListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRequestConfigQuery getListRequestConfigQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRequestConfigListItemDto> response = await Mediator.Send(getListRequestConfigQuery);
        return Ok(response);
    }
}