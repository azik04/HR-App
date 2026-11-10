using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Payment.Query.GetAll;

public record GetAllPaymentQuery(Guid workerId, int pageNumber, int pageSize) :
    IRequest<PaginatedResponse<GetAllPaymentDto>>;