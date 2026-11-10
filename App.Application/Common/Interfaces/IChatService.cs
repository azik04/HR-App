using App.Application.Chat.Command.Create;
using App.Application.Chat.Query.GetAll;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces;

public interface IChatService
{
    Task<GenericResponse<Guid>> CreateChatAsync(CreateChatRequest request, CancellationToken cancellationToken = default);
    
    Task<GenericResponse<GetAllChatDto>> GetMessagesAsync(
        Guid chatId,
        string userId,
        int pageNumber = 1,
        int pageSize = 30,
        CancellationToken cancellationToken = default);
}