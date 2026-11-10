namespace App.Domain.Entities;

public class WorkerServices
{
    public int Id { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Worker { get; set; }
    public int ServiceId { get; set; }
    public Services Service { get; set; }
}
