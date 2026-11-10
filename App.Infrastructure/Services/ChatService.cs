using App.Application.Chat.Command.Create;
using App.Application.Chat.Query.GetAll;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public class ChatService : IChatService
{
    private readonly IGenericRepository<Chats>  _chatRepository;
    private readonly IGenericRepository<Messages>  _messagesRepository;

    public ChatService(
        IGenericRepository<Chats> chatRepository,
        IGenericRepository<Messages> messagesRepository)
    {
        _chatRepository = chatRepository;
        _messagesRepository = messagesRepository;
    }
    
    
    public async Task<GenericResponse<Guid>> CreateChatAsync(CreateChatRequest request, CancellationToken cancellationToken = default)
    {
        if (request.FirstUserId == request.SecondUserId)
            throw new InvalidOperationException("You cannot create a chat with yourself.");

        var chat = await _chatRepository
            .Where(x => x.FirstUserId == request.FirstUserId && x.SecondUserId == request.SecondUserId)
            .FirstOrDefaultAsync();
        
        if (chat != null)
            return GenericResponse<Guid>.Ok(chat.Id);

        chat = new Chats()
        {
            Id = Guid.NewGuid(),
            FirstUserId = request.FirstUserId,
            SecondUserId = request.SecondUserId,
            CreatedAt = DateTime.Now
        };

        await _chatRepository.InsertAsync(chat, cancellationToken);

        return GenericResponse<Guid>.Ok(chat.Id);
    }

    public async Task<GenericResponse<GetAllChatDto>> GetMessagesAsync(Guid chatId, string userId, int pageNumber = 1,
        int pageSize = 30,
        CancellationToken cancellationToken = default)
    {
        var chat = await _chatRepository
            .Where(x => x.Id == chatId &&
                        (x.FirstUserId == userId || x.SecondUserId == userId))
            .Select(x => new
            {
                x.Id,
                x.FirstUserId,
                x.SecondUserId,
                x.CreatedAt,
                FirstUserName = x.FirstUser.UserName,
                SecondUserName = x.SecondUser.UserName
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (chat == null)
            throw new UnauthorizedAccessException("You are not a member of this chat.");

        var receiverId = chat.FirstUserId == userId
            ? chat.SecondUserId
            : chat.FirstUserId;

        var receiverName = chat.FirstUserId == userId
            ? chat.SecondUserName
            : chat.FirstUserName;

        var query = _messagesRepository
            .Where(x => x.ChatId == chatId);

        var totalCount = await query.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(
            (double)totalCount / pageSize);

        var messages = await query
            .OrderByDescending(x => x.CreatedAt)
            .ThenByDescending(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new GetAllMessageDto
            {
                Id = x.Id,
                SenderId = x.SenderId,
                Content = x.Content,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync(cancellationToken);

        messages.Reverse();

        var result = new GetAllChatDto
        {
            Id = chat.Id,
            ReceiverId = receiverId,
            ReceiverName = receiverName ?? string.Empty,
            CreatedAt = chat.CreatedAt,
            Messages = PaginatedResponse<GetAllMessageDto>.Ok(
                messages,
                pageNumber,
                pageSize,
                totalCount,
                totalPages)
        };
        
        return GenericResponse<GetAllChatDto>.Ok(result);
    }
}