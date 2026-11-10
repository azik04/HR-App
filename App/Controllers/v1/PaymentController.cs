using App.Application.Common.Responses;
using App.Application.Payment.Command;
using App.Application.Payment.Query.GetAll;
using App.Application.Payment.Query.GetById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class PaymentController : ApiControllerBase
{
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePaymentCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    
    [ProducesResponseType(typeof(GenericResponse<IReadOnlyList<GetAllPaymentDto>>), StatusCodes.Status200OK)]
    [HttpGet("workerId/{workerId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllPaymentQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    
    [ProducesResponseType(typeof(GenericResponse<IReadOnlyList<GetByIdPaymentDto>>), StatusCodes.Status200OK)]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetByIdPaymentQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}