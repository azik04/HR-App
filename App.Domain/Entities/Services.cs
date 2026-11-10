namespace App.Domain.Entities;

public class Services
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Jobs> Job { get; set; }
    public List<WorkerServices> WorkerService { get; set; }
}
