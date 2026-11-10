using App.Domain.Entities;
using App.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context;

public partial class AppDbContext
{
    public DbSet<Clients> Clients { get; set; }
    public DbSet<Workers> Workers { get; set; }
    public DbSet<Refreshes> Refreshs { get; set; }
    public DbSet<JobFiles> JobFiles { get; set; }
    public DbSet<Addresses> Addresses { get; set; }
    public DbSet<Chats> Chats { get; set; }
    public DbSet<Messages> Messages{ get; set; }
    public DbSet<ReviewFiles> ReviewFiles { get; set; }
    public DbSet<Domain.Entities.Services> Services { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<Jobs> Jobs { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Sms> Smses { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }
    public DbSet<WorkerJobs> WorkerJobs { get; set; }
    public DbSet<WorkerServices> WorkerServices { get; set; }
    public DbSet<WorkerJobHistories> WorkerJobHistories { get; set; }
}
