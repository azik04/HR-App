namespace App.Application.Payment.Query.GetById;

public class GetByIdPaymentDto
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public string WorkerName { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; }
    public string TransactionId { get; set; }
    public string PaymentUrl { get; set; }
    public string CreateAt { get; set; }
    public string? PaidAt { get; set; }
}