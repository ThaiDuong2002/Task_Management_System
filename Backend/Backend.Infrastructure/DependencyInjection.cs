using System.Text;
using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Cloudinary;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Common.Interfaces.Services;
using Backend.Infrastructure.Authentication;
using Backend.Infrastructure.Authentication.Identity;
using Backend.Infrastructure.Cloudinary;
using Backend.Infrastructure.Persistence;
using Backend.Infrastructure.Persistence.Repositories;
using Backend.Infrastructure.Services;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using Serilog;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddPersistence(configuration)
            .AddAuth(configuration)
            .AddLogging()
            .AddCloudinary(configuration)
            .AddNotification();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddLogging(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File("../Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        services.AddSingleton<ILoggerService, LoggerService>();
        return services;
    }

    private static IServiceCollection AddCloudinary(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<CloudinarySettings>(configuration.GetSection(CloudinarySettings.SectionName));

        services.AddSingleton(service =>
        {
            var config = service.GetRequiredService<IOptions<CloudinarySettings>>().Value;
            return new CloudinaryDotNet.Cloudinary(new Account(config.CloudName, config.ApiKey, config.ApiSecret));
        });

        services.AddScoped<ICloudinaryService, CloudinaryService>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<PostgresDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<UserIdentity, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<PostgresDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IDependencyRepository, DependencyRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<ISecurePasswordProvider, SecurePasswordProvider>();
        services.AddSingleton<INotificationHub, NotificationHub>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            }
        );

        return services;
    }

    private static IServiceCollection AddNotification(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddScoped<NotificationJob>();
        services.AddQuartz(option =>
        {
            option.AddJob<NotificationJob>(job => job.WithIdentity("NotificationJob"));
            option.AddTrigger(trigger =>
                trigger.ForJob("NotificationJob")
                    .WithIdentity("NotificationJobTrigger")
                    .WithSimpleSchedule(x =>
                        x.WithIntervalInMinutes(1).RepeatForever()));
        });

        services.AddQuartzHostedService(options => { options.WaitForJobsToComplete = true; });

        return services;
    }
}