using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Payment.Query.GetAll;

public class GetAllPaymentQueryHandler
    : IRequestHandler<GetAllPaymentQuery, PaginatedResponse<GetAllPaymentDto>>
{
    private readonly IGenericRepository<Payments> _paymentRepository;

    public GetAllPaymentQueryHandler(
        IGenericRepository<Payments> paymentRepository)
        => _paymentRepository = paymentRepository;

    
    public async Task<PaginatedResponse<GetAllPaymentDto>> Handle(
        GetAllPaymentQuery request,
        CancellationToken cancellationToken)
    {
        var query = _paymentRepository
            .Where(x => x.WorkerId == request.workerId);

        var totalCount = await query.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalCount / request.pageSize);
        
        var data = await query
            .OrderByDescending(x => x.CreateAt)
            .Skip((request.pageNumber - 1) * request.pageSize)
            .Take(request.pageSize)
            .Select(x => new GetAllPaymentDto()
            {
                Id = x.Id,
                Amount = x.Amount,
                CreateAt = x.CreateAt.ToString("yyyy-MM-dd HH:mm"),
                Status = x.Status.ToString()
            }).ToListAsync();
        
        return PaginatedResponse<GetAllPaymentDto>.Ok(
            data,
            request.pageNumber,
            request.pageSize,
            totalCount,
            totalPages
        );
    }
}