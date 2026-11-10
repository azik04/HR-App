using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Subscription.Query.GetById;

public class GetByIdSubscriptionQueryHandler  
    : IRequestHandler<GetByIdSubscriptionQuery, GenericResponse<GetByIdSubscriptionDto>>
{
    private readonly IGenericRepository<Subscriptions> _subscriptionRepository;
    public GetByIdSubscriptionQueryHandler
        (IGenericRepository<Subscriptions> subscriptionRepository) => 
        _subscriptionRepository = subscriptionRepository;
    
    
    public async Task<GenericResponse<GetByIdSubscriptionDto>> Handle(
        GetByIdSubscriptionQuery request, 
        CancellationToken cancellationToken)
    {
        var data = await _subscriptionRepository
            .Where(x => x.Id == request.id)
            .Include(x => x.Worker)
            .Include(x => x.Payments)
            .FirstOrDefaultAsync(cancellationToken);

        var dto = new GetByIdSubscriptionDto()
        {
            Id = data.Id,
            WorkerId = data.WorkerId,
            PaymentId = data.PaymentId,
            EndAt = data.EndAt.ToString("yyyy-MM-dd HH:mm"),
            StartAt = data.StartAt.ToString("yyyy-MM-dd HH:mm"),
            CreatedAt = data.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
            PaymentDate = data.Payments.PaidAt.Value.ToString("yyyy-MM-dd HH:mm"),
            WorkerName = data.Worker.Name + " " + data.Worker.Surname,
        };

        return GenericResponse<GetByIdSubscriptionDto>.Ok(dto);
    }
}