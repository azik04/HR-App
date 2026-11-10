using App.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context;

public partial class AppDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserConfiguration());
        builder.ApplyConfiguration(new ClientConfiguration());
        builder.ApplyConfiguration(new RefreshConfiguration());
        builder.ApplyConfiguration(new RolesConfiguration());
        builder.ApplyConfiguration(new WorkerConfiguration());

        builder.ApplyConfiguration(new JobFileConfiguration());
        builder.ApplyConfiguration(new AddressConfiguration());
        builder.ApplyConfiguration(new ReviewFileConfiguration());
        builder.ApplyConfiguration(new ServiceConfiguration());

        builder.ApplyConfiguration(new ContactUsConfiguration());
        builder.ApplyConfiguration(new JobConfiguration());
        builder.ApplyConfiguration(new PaymentConfiguration());
        builder.ApplyConfiguration(new ReviewConfiguration());
        builder.ApplyConfiguration(new SmsConfiguration());
        builder.ApplyConfiguration(new SubscriptionConfiguration());

        builder.ApplyConfiguration(new WorkerJobConfiguration());
        builder.ApplyConfiguration(new WorkerServiceConfiguration());

        builder.ApplyConfiguration(new WorkerJobHistoryConfiguration());
    }
}
