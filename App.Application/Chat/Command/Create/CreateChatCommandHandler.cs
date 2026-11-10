using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Chat.Command.Create;

public class CreateChatCommandHandler : 
    IRequestHandler<CreateChatCommand, GenericResponse<Guid>>
{
    public readonly IChatService _chatService;
    public CreateChatCommandHandler(IChatService chatService)
        => _chatService = chatService;
    
    
    public async Task<GenericResponse<Guid>> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        return await _chatService.CreateChatAsync(request.Request, cancellationToken);
    }
}