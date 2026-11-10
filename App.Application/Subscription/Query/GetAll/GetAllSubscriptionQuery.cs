using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Subscription.Query.GetAll;

public record GetAllSubscriptionQuery(Guid WorkerId, int pageNumber, int pageSize) :
    IRequest<PaginatedResponse<GetAllSubscriptionDto>>;