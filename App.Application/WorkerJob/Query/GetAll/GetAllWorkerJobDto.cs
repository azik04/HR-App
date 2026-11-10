namespace App.Application.WorkerJob.Query.GetAll;

public class GetAllWorkerJobDto
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public string WorkerName { get; set; }
    public Guid JobId { get; set; }
    public string JobName { get; set; }
    public string Status { get; set; }
    public string CreateAt { get; set; }
    public string? FinishAt { get; set; }
}
