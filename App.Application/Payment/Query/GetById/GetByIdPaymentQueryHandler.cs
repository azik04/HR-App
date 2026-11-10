using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Payment.Query.GetById;

public class GetByIdPaymentQueryHandler 
    : IRequestHandler<GetByIdPaymentQuery, GenericResponse<GetByIdPaymentDto>>
{
    private readonly IGenericRepository<Payments> _paymentRepository;

    public GetByIdPaymentQueryHandler(
        IGenericRepository<Payments> paymentRepository)
        => _paymentRepository = paymentRepository;

    
    public async Task<GenericResponse<GetByIdPaymentDto>> Handle(
        GetByIdPaymentQuery request, 
        CancellationToken cancellationToken)
    {
        var data = await _paymentRepository
            .Where(x => x.Id == request.Id)
            .Include(x => x.Worker)
            .FirstOrDefaultAsync(cancellationToken);

        var dto = new GetByIdPaymentDto()
        {
            Id = data.Id,
            Amount = data.Amount,
            CreateAt = data.CreateAt.ToString("yyyy-MM-dd HH:mm"),
            Status = data.Status.ToString(),
            WorkerId = data.WorkerId,
            WorkerName = data.Worker.Name + " " + data.Worker.Surname,
            TransactionId = data.TransactionId,
            PaidAt = data.PaidAt.Value.ToString("yyyy-MM-dd HH:mm")
        };
        
        return GenericResponse<GetByIdPaymentDto>.Ok(dto);
    }
}