using App.Application.Chat.Command.Create;
using App.Application.Chat.Query.GetAll;
using App.Application.Common.Responses;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ChatController : ApiControllerBase
{
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)] 
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateChatCommand command) 
    { 
        var res = await Mediator.Send(command); 
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)] 
    [HttpGet("id/{id}/appId/{firstUserId}")]
    public async Task<IActionResult> CreateAsync([FromRoute] CreateChatRequest request) 
    { 
        var command = new CreateChatCommand(request);

        var res = await Mediator.Send(command); 
        return res.Success ? Ok(res) : BadRequest(res);
    }
}
