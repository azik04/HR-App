using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Application.Payment.Query.GetAll;
using App.Application.Reviews.Query.GetAll;
using App.Application.Subscription.Query.GetAll;
using App.Application.WorkerJobHistory.Query.GetAll;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Worker.Query.GetById;

public class GetByIdWorkerQueryHandler : IRequestHandler<GetByIdWorkerQuery, GenericResponse<GetByIdWorkerDto>>
{
    private readonly IGenericRepository<Workers> _workersRepository;
    public GetByIdWorkerQueryHandler(
        IGenericRepository<Workers> workersRepository) 
        => _workersRepository = workersRepository;


    public async Task<GenericResponse<GetByIdWorkerDto>> Handle(GetByIdWorkerQuery request, CancellationToken cancellationToken)
    {
        var data = await _workersRepository.Where(x => x.Id == request.id)
            .Include(x => x.Review)
            .Include(x => x.WorkerService)
                .ThenInclude(x => x.Service)
            .Include(x => x.Payment)
            .Include(x => x.WorkerJob)
            .Include(x => x.WorkerJobHistory)
                .ThenInclude(x => x.Jobs)
            .Include(x => x.Payment)
            .Include(x => x.Subscription)
            .Include(x => x.Review)
            .SingleOrDefaultAsync(cancellationToken);

        var dto = new GetByIdWorkerDto()
        {
            Name = data.Name,
            Id = data.Id,
            FilePath = data.FilePath,
            Surname = data.Surname,
            Service = data.WorkerService.Select(x => x.Service.Name).ToList(),
            Rating = data.Rating,
            ReviewCount = data.Review.Count,
            Pin = data.Pin,
            PhoneNumber = data.PhoneNumber,
            HistoryCount = data.WorkerJob.Where(x => x.WorkerId == data.Id && x.Status == Domain.Enums.WorkerJobStatus.Completed).Count(),
            Subscriptions = data.Subscription == null || !data.Subscription.Any()
                ? null
                : data.Subscription
                    .OrderByDescending(x => x.CreatedAt)
                    .Take(5)
                    .Select(x => new GetAllSubscriptionDto
                    {
                        Id = x.Id,
                        PaymentId = x.PaymentId,
                        CreatedAt = x.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                        EndAt = x.EndAt.ToString("yyyy-MM-dd HH:mm"),
                        StartAt = x.StartAt.ToString("yyyy-MM-dd HH:mm")
                    })
                    .ToList(),
            Payments = data.Payment == null || !data.Payment.Any()
                ? null
                : data.Payment
                    .OrderByDescending(x => x.CreateAt)
                    .Take(5)
                    .Select(x => new GetAllPaymentDto
                    {
                        Id = x.Id,
                        CreateAt = x.CreateAt.ToString("yyyy-MM-dd HH:mm"),
                        Amount = x.Amount,
                        Currency = x.Currency,
                        Status = x.Status.ToString()
                    })
                    .ToList(),
            JobHistory = data.WorkerJobHistory == null || !data.WorkerJobHistory.Any()
                ? null
                : data.WorkerJobHistory
                    .OrderByDescending(x => x.CreateAt)
                    .Take(5)
                    .Select(x => new GetAllWorkerJobHistoryDto()
                    {
                        Id = x.Id,
                        WorkerId = x.WorkerId,
                        JobId = x.JobId,
                        JobName = x.Jobs.Name,
                        WorkerName = x.Workers.Name + " " + x.Workers.Surname,
                        Status = x.Status.ToString(),
                        CreateAt = x.CreateAt.ToString("yyyy-MM-dd HH:mm"),
                        FinishAt = x.FinishAt.Value.ToString("yyyy-MM-dd HH:mm"),
                    })
                    .ToList(),
            Reviews = data.Review == null || !data.Review.Any()
                ? null
                : data.Review
                    .OrderByDescending(x => x.CreateAt)
                    .Take(5)
                    .Select(x => new GetAllReviewDto()
                    {
                        ClientId = x.ClientId,
                        ClientName = x.Client.Name,
                        Id = x.Id,
                        Name = x.Name,
                        Stars = x.Stars
                    })
                    .ToList()
        };
        
        return GenericResponse<GetByIdWorkerDto>.Ok(dto);
    }
}