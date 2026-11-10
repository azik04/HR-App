namespace App.Infrastructure.Identity;

public class Chats
{
    public Guid Id { get; set; }

    public string FirstUserId { get; set; } = null!;
    public string SecondUserId { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ApplicationUsers FirstUser { get; set; } = null!;
    public ApplicationUsers SecondUser { get; set; } = null!;

    public ICollection<Messages> Message { get; set; }
}