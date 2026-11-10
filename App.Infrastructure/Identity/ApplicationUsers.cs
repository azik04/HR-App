using App.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Identity;

public class ApplicationUsers : IdentityUser
{
    public Guid? ClientId { get; set; }
    public Clients? Client { get; set; }
    public Guid? WorkerId { get; set; }
    public Workers? Worker { get; set; }
    public ICollection<Refreshes> Refreshes { get; set; }
    public ICollection<Chats> FirstChats { get; set; }
    public ICollection<Chats> SecondChats { get; set; }
    public ICollection<Messages> Messages { get; set; }
}
