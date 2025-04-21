using Backend.Api;
using Backend.Application;
using Backend.Infrastructure;
using Backend.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = long.MaxValue);

var app = builder.Build();

app.UseExceptionHandler("/error");
app.MapHub<NotificationHub>("/hubs/notifications");

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();