namespace App.Infrastructure.Identity;

public class Messages
{
    public Guid Id { get; set; }

    public Guid ChatId { get; set; }

    public string SenderId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ReadAt { get; set; }

    public Chats Chat { get; set; } = null!;

    public ApplicationUsers Sender { get; set; } = null!;
}