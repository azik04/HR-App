using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration;

public class ReviewFileConfiguration : IEntityTypeConfiguration<ReviewFiles>
{
    public void Configure(EntityTypeBuilder<ReviewFiles> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Review).WithMany(x => x.ReviewFile).HasForeignKey(x => x.ReviewId).OnDelete(DeleteBehavior.Restrict);
    }
}
