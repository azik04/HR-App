using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Chat.Query.GetAll;

public class GetAllChatQueryHandler : IRequestHandler<GetAllChatQuery, GenericResponse<GetAllChatDto>>
{
    private readonly IChatService _chatService;
    public GetAllChatQueryHandler(
        IChatService chatService)
        => _chatService = chatService;
    
    
    public async Task<GenericResponse<GetAllChatDto>> Handle(
        GetAllChatQuery request, 
        CancellationToken cancellationToken)
    {
        return await _chatService.GetMessagesAsync(request.id, request.firstUserId, request.pageNumber, request.pageSize, cancellationToken);
    }
}