using App.Domain.Enums;

namespace App.Domain.Entities;

public class WorkerJobs
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Workers { get; set; }
    public Guid JobId { get; set; }
    public Jobs Jobs { get; set; }
    public WorkerJobStatus Status { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? FinishAt { get; set; }

    public List<WorkerJobHistories> WorkerJobHistories { get; set; }
}
