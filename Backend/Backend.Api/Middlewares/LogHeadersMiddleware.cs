namespace Backend.Api.Middlewares;

public class LogHeadersMiddleware
{
    private readonly RequestDelegate _next;

    public LogHeadersMiddleware(RequestDelegate next, ILogger<LogHeadersMiddleware> logger)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log all headers from the request
        foreach (var header in context.Request.Headers) Console.WriteLine($"{header.Key}: {header.Value}");

        Console.WriteLine(context.User.Identity?.IsAuthenticated);


        await _next(context); // Call the next middleware in the pipeline
    }
}