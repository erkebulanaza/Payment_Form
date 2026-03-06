namespace Api.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeader = "Api-Key";
    private readonly string? _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKey = configuration["ApiKey"];
    }
    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(ApiKeyHeader, out var extractedApiKey) || extractedApiKey != _apiKey)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Неверный API ключь");
            return;
        }
        await _next(context);
    }
}