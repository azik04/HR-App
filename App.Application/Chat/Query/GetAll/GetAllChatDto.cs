using App.Application.Common.Responses;

namespace App.Application.Chat.Query.GetAll;

public class GetAllChatDto
{
    public Guid Id { get; set; }
    public string ReceiverId { get; set; } = null!;
    public string ReceiverName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public PaginatedResponse<GetAllMessageDto> Messages { get; set; }
}