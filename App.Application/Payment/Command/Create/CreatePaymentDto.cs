namespace App.Application.Payment.Command;

public class CreatePaymentDto
{
    public Guid WorkerId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "AZN";
    public string TransactionId { get; set; }
    public string PaymentUrl { get; set; }
}