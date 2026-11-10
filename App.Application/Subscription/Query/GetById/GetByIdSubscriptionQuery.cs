using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Subscription.Query.GetById;

public record GetByIdSubscriptionQuery(Guid id) : IRequest<GenericResponse<GetByIdSubscriptionDto>>
{
    
}