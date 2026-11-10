using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Chat.Query.GetAll;

public record GetAllChatQuery(
    Guid id,
    string firstUserId, 
    int pageNumber, 
    int pageSize) 
    : IRequest<GenericResponse<GetAllChatDto>>;