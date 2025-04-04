using System.Text;
using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Common.Interfaces.Services;
using Backend.Infrastructure.Authentication;
using Backend.Infrastructure.Authentication.Identity;
using Backend.Infrastructure.Persistence;
using Backend.Infrastructure.Persistence.Repositories;
using Backend.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
            .AddLogging();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddLogging(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        services.AddSingleton<ILoggerService, LoggerService>();
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

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(
            options => options.TokenValidationParameters = new TokenValidationParameters
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
}