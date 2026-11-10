using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration;

public class ServiceConfiguration : IEntityTypeConfiguration<Domain.Entities.Services>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Services> builder)
    {
        builder.HasKey(x => x.Id);
    }
}