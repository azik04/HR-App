namespace App.Application.Payment.Query.GetAll;

public class GetAllPaymentDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; }
    public string CreateAt { get; set; }
}