namespace App.Domain.Entities;

public class Workers
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Rating { get; set; } = 0;
    public string? FilePath { get; set; }
    public bool IsSubscribed { get; set; } = false;
    public string Pin { get; set; }
    public string PhoneNumber { get; set; }
    public List<WorkerJobs> WorkerJob { get; set; }
    public List<Reviews> Review { get; set; }
    public List<Payments> Payment { get; set; }
    public List<Subscriptions> Subscription { get; set; }
    public List<WorkerServices> WorkerService { get; set; }
    public List<Sms> Sms { get; set; }
    public List<Addresses> Adresses { get; set; }
    public List<WorkerJobHistories> WorkerJobHistory { get; set; }
}
