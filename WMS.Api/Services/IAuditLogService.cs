namespace WMS.Api.Services
{
    public interface IAuditLogService
    {
        Task LogAsync(
            string category,
            string action,
            string description,
            object? details = null,
            int statusCode = 200,
            string? userOverride = null,
            Guid? userIdOverride = null);
    }
}