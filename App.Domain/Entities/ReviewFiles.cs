namespace App.Domain.Entities;

public class ReviewFiles
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public Guid ReviewId { get; set; }
    public Reviews Review { get; set; }
}
