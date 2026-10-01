using System.Security.Claims;
using System.Text.Json;
using WMS.Api.Data;
using WMS.Api.Entities;

namespace WMS.Api.Services
{
    public class AuditLogService(
        WMSContext dbContext,
        IHttpContextAccessor httpContextAccessor) : IAuditLogService
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public async Task LogAsync(string category, string action, string description, object? details = null, int statusCode = 200)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var user = httpContext?.User;

            Guid.TryParse(user?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);

            var userEmail = user?.FindFirst(ClaimTypes.Email)?.Value
                ?? user?.FindFirst("email")?.Value
                ?? user?.Identity?.Name
                ?? "System";

            var log = new AuditLog
            {
                TraceId = httpContext?.TraceIdentifier,
                UserId = userId == Guid.Empty ? null : userId,
                UserEmail = userEmail,
                UserRole = user?.FindFirst(ClaimTypes.Role)?.Value,
                IpAddress = httpContext?.Connection.RemoteIpAddress?.ToString(),
                Category = category,
                Action = action,
                Description = description,
                DetailsJson = details != null ? JsonSerializer.Serialize(details, JsonOptions) : null,
                StatusCode = statusCode,
                Timestamp = DateTime.UtcNow
            };

            dbContext.AuditLogs.Add(log);
            await dbContext.SaveChangesAsync();
        }
    }
}
