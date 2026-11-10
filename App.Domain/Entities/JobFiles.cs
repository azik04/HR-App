namespace App.Domain.Entities;

public class JobFiles
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public Guid JobId { get; set; }
    public Jobs Job { get; set; }
}
