using App.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration;

public class MessageConfiguration : IEntityTypeConfiguration<Messages>
{
    public void Configure(EntityTypeBuilder<Messages> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.HasOne(x => x.Chat)
            .WithMany(x => x.Message)
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Sender)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}