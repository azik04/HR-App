using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Helpers;
using App.Application.Common.Interfaces.Integrations;
using App.Application.Common.Interfaces.Repository;
using App.Domain.Entities;
using App.Infrastructure.BackgroundJob;
using App.Infrastructure.Context;
using App.Infrastructure.Helpers;
using App.Infrastructure.Identity;
using App.Infrastructure.Integrations;
using App.Infrastructure.Services;
using App.Infrastructure.Utils.AppSettingModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.DependencyInjection;

public static class ServiceDependency
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUsers, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenHelper, TokenHelper>();
        services.AddScoped<IAppFileService, AppFileService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IRefreshService, RefreshService>();

        services.AddScoped<IGenericRepository<WorkerJobHistories>, GenericRepository<WorkerJobHistories>>();
        services.AddScoped<IGenericRepository<Chats>, GenericRepository<Chats>>();
        services.AddScoped<IGenericRepository<Messages>, GenericRepository<Messages>>();
        services.AddScoped<IGenericRepository<Refreshes>, GenericRepository<Refreshes>>();
        services.AddScoped<IGenericRepository<Payments>, GenericRepository<Payments>>();
        services.AddScoped<IGenericRepository<Subscriptions>, GenericRepository<Subscriptions>>();
        services.AddScoped<IGenericRepository<Clients>, GenericRepository<Clients>>();
        services.AddScoped<IGenericRepository<Addresses>, GenericRepository<Addresses>>();
        services.AddScoped<IGenericRepository<Workers>, GenericRepository<Workers>>();

        services.AddScoped<IGenericRepository<Domain.Entities.Services>, GenericRepository<Domain.Entities.Services>>();
        services.AddScoped<IGenericRepository<Reviews>, GenericRepository<Reviews>>();
        services.AddScoped<IGenericRepository<JobFiles>, GenericRepository<JobFiles>>();
        services.AddScoped<IGenericRepository<Jobs>, GenericRepository<Jobs>>();
        services.AddScoped<IGenericRepository<ContactUs>, GenericRepository<ContactUs>>();
        services.AddScoped<IGenericRepository<WorkerServices>, GenericRepository<WorkerServices>>();
        services.AddScoped<IGenericRepository<WorkerJobs>, GenericRepository<WorkerJobs>>();
        services.AddScoped<IGenericRepository<ReviewFiles>, GenericRepository<ReviewFiles>>();

        services.AddHttpClient();

        services.AddTransient<UserBackgroundJob>();
        services.AddTransient<HostCheckBackgroundJob>();

        services.Configure<JwtSettings>(
            configuration.GetSection("JWT"));

        services.Configure<SmtpSettings>(
            configuration.GetSection("SMTP"));
    }
}