using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration;

public class PaymentConfiguration : IEntityTypeConfiguration<Payments>
{
    public void Configure(EntityTypeBuilder<Payments> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Worker).WithMany(x => x.Payment).HasForeignKey(x => x.WorkerId).OnDelete(DeleteBehavior.Restrict);
    }
}