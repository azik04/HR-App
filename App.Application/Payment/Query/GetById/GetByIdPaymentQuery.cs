using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Payment.Query.GetById;

public record GetByIdPaymentQuery(Guid Id) 
    : IRequest<GenericResponse<GetByIdPaymentDto>>;