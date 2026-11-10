using App.Domain.Enums;

namespace App.Domain.Entities;

public class Jobs
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ClientId { get; set; }
    public Clients Client { get; set; }
    public JobStatuses JobStatuses { get; set; }
    public int AddressId { get; set; }
    public Addresses Address { get; set; }
    public int ServiceId { get; set; } 
    public Services Service { get; set; }
    public DateTime CreateAt { get; set; } 
    public List<JobFiles> JobFile { get; set; }
    public List<WorkerJobs> WorkerJob { get; set; }
    public List<WorkerJobHistories> WorkerJobHistory { get; set; }
}
