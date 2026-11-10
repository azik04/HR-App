using App.Application.Payment.Query.GetAll;
using App.Application.Reviews.Query.GetAll;
using App.Application.Subscription.Query.GetAll;
using App.Application.WorkerJobHistory.Query.GetAll;

namespace App.Application.Worker.Query.GetById;

public class GetByIdWorkerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Rating { get; set; }
    public string PhoneNumber { get; set; }
    public string Pin { get; set; }
    public string? FilePath { get; set; }
    public List<string> Service { get; set; }
    public int ReviewCount { get; set; }
    public int HistoryCount { get; set; } = 0;
    public IReadOnlyList<GetAllPaymentDto>? Payments { get; set; }
    public IReadOnlyList<GetAllSubscriptionDto>? Subscriptions { get; set; }
    public IReadOnlyList<GetAllWorkerJobHistoryDto>? JobHistory { get; set; }
    public IReadOnlyList<GetAllReviewDto>? Reviews { get; set; }
}