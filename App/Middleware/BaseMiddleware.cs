using System.Text.Json;
using App.Application.Common.Responses;
using Serilog;

namespace App.Middleware;

public class BaseMiddleware
{
    private readonly RequestDelegate _next;

    public BaseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.Now;

        var transactionId = Guid.NewGuid().ToString();
        context.Items["TransactionId"] = transactionId;

        context.Response.OnStarting(() =>
        {
            context.Response.Headers["X-Transaction-ID"] = transactionId;
            context.Response.Headers["TimeStamp"] = start.ToString();

            return Task.CompletedTask;
        });


        try
        {
            await _next(context);

            var duration = DateTime.Now - start;
            var statusCode = context.Response.StatusCode;

            if (statusCode >= 200 && statusCode < 300)
            {
                Log.Information(
                    "Success: {Method} {Path} -> {StatusCode} in {Duration}ms | TransactionId: {TransactionId}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode,
                    duration.TotalMilliseconds,
                    transactionId);
            }
            else if (statusCode >= 400 && statusCode < 500)
            {
                Log.Warning(
                    "Client error: {Method} {Path} -> {StatusCode} | TransactionId: {TransactionId}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode,
                    transactionId);
            }
            else
            {
                Log.Error(
                    "Server error: {Method} {Path} -> {StatusCode} | TransactionId: {TransactionId}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode,
                    transactionId);
            }
        }
        catch (Exception ex)
        {
            Log.Error(
                ex,
                "Unhandled exception: {Method} {Path} | TransactionId: {TransactionId}",
                context.Request.Method,
                context.Request.Path,
                transactionId);

            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = GenericResponse<object>.Fail(ex.Message, ex.StackTrace);

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}