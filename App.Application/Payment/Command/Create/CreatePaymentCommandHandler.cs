using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Domain.Entities;
using MediatR;

namespace App.Application.Payment.Command;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Payments> _paymentRepository;
    private readonly IGenericRepository<Subscriptions> _subscriptionRepository;
    private readonly IGenericRepository<Workers> _workersRepository;

    public CreatePaymentCommandHandler
    (IGenericRepository<Payments> paymentRepository, 
        IGenericRepository<Subscriptions> subscriptionRepository,
        IGenericRepository<Workers> workersRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        _paymentRepository = paymentRepository;
        _workersRepository = workersRepository;
    }

    public async Task<GenericResponse<bool>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payments()
        {
            Id = Guid.NewGuid(),
            WorkerId = request.dto.WorkerId,
            TransactionId = request.dto.TransactionId,
            Amount = request.dto.Amount,
            Currency = request.dto.Currency,
            PaymentUrl = request.dto.PaymentUrl,
        };
        
        await _paymentRepository.InsertAsync(payment, cancellationToken);
        
        var startDate = DateOnly.FromDateTime(payment.CreateAt);

        var subscription = new Subscriptions()
        {
            WorkerId = request.dto.WorkerId,
            PaymentId = payment.Id,
            Id = Guid.NewGuid(),
            StartAt = startDate,
            EndAt = startDate.AddMonths(1),
        };
        
        await _subscriptionRepository.InsertAsync(subscription, cancellationToken);
        
        var worker = await _workersRepository.GetByIdAsync(request.dto.WorkerId, null, cancellationToken);
        
        worker.IsSubscribed = true;
        
        await _workersRepository.Update(worker, cancellationToken);
        
        return GenericResponse<bool>.Ok(true);
    }
}