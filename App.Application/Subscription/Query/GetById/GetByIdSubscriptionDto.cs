namespace App.Application.Subscription.Query.GetById;

public class GetByIdSubscriptionDto
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public string WorkerName { get; set; }
    public Guid PaymentId { get; set; }
    public string PaymentDate { get; set; }
    public string StartAt { get; set; }
    public string EndAt { get; set; }
    public string CreatedAt { get; set; }
}