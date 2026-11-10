namespace App.Domain.Entities;

public class Reviews
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ClientId { get; set; }
    public Clients Client { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Worker { get; set; }
    public int Stars { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public List<ReviewFiles> ReviewFile { get; set; }
}
