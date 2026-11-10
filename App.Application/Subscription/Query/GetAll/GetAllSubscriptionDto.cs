namespace App.Application.Subscription.Query.GetAll;

public class GetAllSubscriptionDto
{
    public Guid Id { get; set; }
    public Guid PaymentId { get; set; }
    public string StartAt { get; set; }
    public string EndAt { get; set; }
    public string CreatedAt { get; set; }
}