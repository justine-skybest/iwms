using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Entities;

namespace WMS.Api.Endpoints
{
    public record AuditLogPagedResponseDto(
        int TotalCount,
        int Page,
        int PageSize,
        int TotalPages,
        List<AuditLog> Items
    );
    public static class AuditLogEndpoints
    {
        public static RouteGroupBuilder MapAuditLogEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/audit-logs")
                              .WithTags("Audit Logs");
                              //.RequireAuthorization("AdminOnly");

            // 1. Get Paginated & Filtered Audit Logs
            group.MapGet("/", async (
                WMSContext db,
                string? search,
                string? entityName,
                string? action,
                string? userEmail,
                DateTime? fromDate,
                DateTime? toDate,
                int page = 1,
                int pageSize = 20) =>
            {
                page = page < 1 ? 1 : page;
                pageSize = pageSize is < 1 or > 100 ? 20 : pageSize;

                var query = db.AuditLogs.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var term = search.Trim().ToLower();
                    query = query.Where(x =>
                        (x.UserEmail != null && x.UserEmail.ToLower().Contains(term)) ||
                        x.EntityName.ToLower().Contains(term) ||
                        x.Action.ToLower().Contains(term) ||
                        x.PrimaryKey.ToLower().Contains(term) ||
                        x.TraceId!.ToLower().Contains(term)
                    );
                }

                if (!string.IsNullOrWhiteSpace(entityName))
                {
                    query = query.Where(x => x.EntityName == entityName);
                }

                if (!string.IsNullOrWhiteSpace(action))
                {
                    query = query.Where(x => x.Action == action);
                }

                if (!string.IsNullOrWhiteSpace(userEmail))
                {
                    query = query.Where(x => x.UserEmail != null && x.UserEmail == userEmail);
                }

                if (fromDate.HasValue)
                {
                    query = query.Where(x => x.Timestamp >= fromDate.Value.ToUniversalTime());
                }

                if (toDate.HasValue)
                {
                    query = query.Where(x => x.Timestamp <= toDate.Value.ToUniversalTime());
                }

                var totalCount = await query.CountAsync();

                var items = await query
                    .OrderByDescending(x => x.Timestamp)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var response = new AuditLogPagedResponseDto(
                    totalCount,
                    page,
                    pageSize,
                    (int)Math.Ceiling((double)totalCount / pageSize),
                    items
                );

                return Results.Ok(response);
            })
            .WithSummary("Get paginated audit logs")
            .WithDescription("Retrieves a filtered, paginated list of system audit history.")
            .Produces<AuditLogPagedResponseDto>(StatusCodes.Status200OK);

            // 2. Get Audit Log Entry Details by ID
            group.MapGet("/{id:guid}", async (Guid id, WMSContext db) =>
            {
                var log = await db.AuditLogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return log is not null ? Results.Ok(log) : Results.NotFound();
            })
            .WithSummary("Get audit log details by ID")
            .WithDescription("Retrieves complete audit log details including OldValues and NewValues diff payloads.")
            .Produces<AuditLog>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // 3. Get Distinct Entity Names (For Frontend Dropdown Filters)
            group.MapGet("/entity-names", async (WMSContext db) =>
            {
                var names = await db.AuditLogs
                    .AsNoTracking()
                    .Select(x => x.EntityName)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

                return Results.Ok(names);
            })
            .WithSummary("Get list of audited entity names")
            .WithDescription("Returns distinct entity names recorded in audit logs to populate UI filter dropdowns.")
            .Produces<List<string>>(StatusCodes.Status200OK);

            return group;
        }
    }
}
