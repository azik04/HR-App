using App.Application.Common.Responses;
using App.Application.Subscription.Query.GetAll;
using App.Application.Subscription.Query.GetById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/subscriptions")]
[ApiController]
public class SubscriptionController : ApiControllerBase
{
    [ProducesResponseType(typeof(GenericResponse<List<GetAllSubscriptionDto>>), StatusCodes.Status200OK)]
    [HttpGet("workerId/{workerId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllSubscriptionQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    
    [ProducesResponseType(typeof(GenericResponse<List<GetByIdSubscriptionDto>>), StatusCodes.Status200OK)]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetByIdSubscriptionQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}