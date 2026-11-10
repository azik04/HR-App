using App.Infrastructure.Context;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private readonly AppDbContext _db;

    public ChatHub(AppDbContext db)
    {
        _db = db;
    }

    public async Task SendMessage(Guid chatId, string message)
    {
        var senderId = Context.UserIdentifier;

        if (string.IsNullOrWhiteSpace(senderId))
            throw new HubException("Unauthorized.");

        if (string.IsNullOrWhiteSpace(message))
            throw new HubException("Message cannot be empty.");

        var chat = await _db.Chats
            .FirstOrDefaultAsync(x =>
                x.Id == chatId &&
                (x.FirstUserId == senderId || x.SecondUserId == senderId));

        if (chat == null)
            throw new HubException("Chat not found.");

        var receiverId = chat.FirstUserId == senderId
            ? chat.SecondUserId
            : chat.FirstUserId;

        var newMessage = new Messages()
        {
            Id = Guid.NewGuid(),
            ChatId = chatId,
            SenderId = senderId,
            Content = message.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        await _db.Messages.AddAsync(newMessage);
        await _db.SaveChangesAsync();

        await Clients.User(receiverId).SendAsync("ReceiveMessage", newMessage);

        await Clients.Caller.SendAsync("ReceiveMessage", newMessage);
    }
}