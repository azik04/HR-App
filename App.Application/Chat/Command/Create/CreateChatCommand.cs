using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Chat.Command.Create;

public sealed record CreateChatCommand(CreateChatRequest Request) : 
    IRequest<GenericResponse<Guid>>;