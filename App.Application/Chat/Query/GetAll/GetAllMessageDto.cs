namespace App.Application.Chat.Query.GetAll;

public class GetAllMessageDto
{
    public Guid Id { get; set; }

    public string SenderId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? ReadAt { get; set; }

    public bool IsMine { get; set; }
}