using Backend.Api.Common.Errors;
using Backend.Application;
using Backend.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSingleton<ProblemDetailsFactory, BackendProblemDetailsFactory>();

var app = builder.Build();

// app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();