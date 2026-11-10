using App.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration;

public class ChatConfiguration  : IEntityTypeConfiguration<Chats>
{
    public void Configure(EntityTypeBuilder<Chats> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.FirstUser)
            .WithMany(x => x.FirstChats)
            .HasForeignKey(x => x.FirstUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.SecondUser)
            .WithMany(x => x.SecondChats)
            .HasForeignKey(x => x.SecondUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}