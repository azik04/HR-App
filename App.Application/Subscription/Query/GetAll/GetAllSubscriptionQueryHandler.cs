using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Subscription.Query.GetAll;

public class GetAllSubscriptionQueryHandler : 
    IRequestHandler<GetAllSubscriptionQuery, PaginatedResponse<GetAllSubscriptionDto>>
{
    private readonly IGenericRepository<Subscriptions> _subscriptionRepository;
    public GetAllSubscriptionQueryHandler(
        IGenericRepository<Subscriptions> subscriptionRepository) => 
        _subscriptionRepository = subscriptionRepository;
    
    
    public async Task<PaginatedResponse<GetAllSubscriptionDto>> Handle(
        GetAllSubscriptionQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _subscriptionRepository
            .Where(x => x.WorkerId == request.WorkerId);
        
        var totalCount = await query.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalCount / request.pageSize);

        var data = await query
            .OrderByDescending(x => x.CreatedAt)
            .Skip((request.pageNumber - 1) * request.pageSize)
            .Take(request.pageSize)
            .Select(x => new GetAllSubscriptionDto()
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                PaymentId = x.PaymentId,
                EndAt = x.EndAt.ToString("yyyy-MM-dd HH:mm"),
                StartAt = x.StartAt.ToString("yyyy-MM-dd HH:mm"),
            }).ToListAsync(cancellationToken);
        
        return PaginatedResponse<GetAllSubscriptionDto>.Ok(
            data,
            request.pageNumber,
            request.pageSize,
            totalCount,
            totalPages
        );
    }
}