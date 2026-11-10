using App.Domain.Enums;

namespace App.Domain.Entities;

public class Payments
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Worker { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "AZN";
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string TransactionId { get; set; }
    public string PaymentUrl { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? PaidAt { get; set; }
    public List<Subscriptions> Subscription { get; set; }
}
