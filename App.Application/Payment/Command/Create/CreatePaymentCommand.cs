using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Payment.Command;

public sealed record CreatePaymentCommand(
    CreatePaymentDto dto
) : IRequest<GenericResponse<bool>>;