using App.Domain.Enums;

namespace App.Domain.Entities;

public class Sms
{
    public int Id { get; set; }
    public Guid? ClientId {  get; set; }
    public Clients? Client { get; set; }
    public Guid? WorkerId { get; set; }
    public Workers? Worker { get; set; }
    public SmsTypes SmsType { get; set; }
}
