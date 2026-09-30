using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WMS.Api.Data;
using WMS.Api.Entities;
using WMS.Api.Services;

namespace WMS.Api.Filters
{
    public class AuditLoggingFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var httpContext = context.HttpContext;
            var request = httpContext.Request;

            if (HttpMethods.IsGet(request.Method) || HttpMethods.IsOptions(request.Method))
            {
                return await next(context);
            }

            string? requestPayload = null;

            // CRITICAL FIX: Do NOT attempt to read multipart/form-data (Excel/Image files) into memory
            if (request.HasFormContentType)
            {
                requestPayload = "[Multipart Form Data / File Upload omitted from logs]";
            }
            else if (request.ContentLength > 0)
            {
                request.EnableBuffering();
                using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
                requestPayload = await reader.ReadToEndAsync();
                request.Body.Position = 0;
            }

            requestPayload = SanitizePayload(requestPayload);

            var stopwatch = Stopwatch.StartNew();
            var result = await next(context);
            stopwatch.Stop();

            try
            {
                var dbContext = httpContext.RequestServices.GetRequiredService<WMSContext>();
                var currentUser = httpContext.RequestServices.GetRequiredService<ICurrentUserService>();

                var endpoint = httpContext.GetEndpoint();
                var entityName = endpoint?.Metadata.GetMetadata<IEndpointGroupNameMetadata>()?.EndpointGroupName
                                 ?? request.Path.Value?.Split('/', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()
                                 ?? "API";

                var auditLog = new AuditLog
                {
                    TraceId = httpContext.TraceIdentifier, // <--- LINK: Add Trace ID
                    UserId = currentUser.UserId,
                    UserEmail = currentUser.Email,
                    UserRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value,
                    IpAddress = httpContext.Connection.RemoteIpAddress?.ToString(),
                    EntityName = entityName,
                    Action = request.Method,
                    PrimaryKey = request.Path,
                    NewValues = requestPayload,
                    Timestamp = DateTime.UtcNow,
                    StatusCode = httpContext.Response.StatusCode,
                    ExecutionTimeMs = stopwatch.ElapsedMilliseconds
                };

                dbContext.AuditLogs.Add(auditLog);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = httpContext.RequestServices.GetRequiredService<ILogger<AuditLoggingFilter>>();
                logger.LogError(ex, "Failed to save audit log for {Path}", request.Path);
            }

            return result;
        }

        private static string? SanitizePayload(string? payload)
        {
            if (string.IsNullOrWhiteSpace(payload)) return payload;

            if (payload.Contains("password", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    using var doc = JsonDocument.Parse(payload);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(payload);
                    if (dict != null)
                    {
                        foreach (var key in dict.Keys.ToList())
                        {
                            if (key.Contains("password", StringComparison.OrdinalIgnoreCase))
                            {
                                dict[key] = "********";
                            }
                        }
                        return JsonSerializer.Serialize(dict);
                    }
                }
                catch
                {
                    return "[Redacted Payload]";
                }
            }

            return payload;
        }
    }
}