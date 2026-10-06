using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WMS.Api.Data;
using WMS.Api.Dtos.Reporting;
using WMS.Api.Entities;
using WMS.Api.Entities.Reporting;
using WMS.Api.Services;

public record GenerateReportResponse(
    string Message,
    int JobId,
    string JobNumber
);

public record ReceivingReportListResponse(
    List<ReportJob> Items,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages
);

namespace WMS.Api.Endpoints
{
    public record CheckInProductDto(
        int Id,
        string? ProductName,
        int? Quantity,
        string? LotNumber,
        string? ContainerName,
        DateOnly? ExpirationDate
    );

    public record BinCheckInDto(
        int Id,
        string CheckInType,
        DateTime CheckInDate,
        int? PalletId,
        string? Notes,
        IReadOnlyCollection<CheckInProductDto> Products
    );

    public record BinOccupancyDto(
        int Id,
        string? BinName,
        int RackId,
        string? RackName,
        int? BayNumber,
        int? LevelNumber,
        bool IsOccupied,
        IReadOnlyCollection<BinCheckInDto> CheckIns
    );

    public record OccupancySummaryDto(
        int TotalBins,
        int OccupiedBins,
        int VacantBins,
        double OccupancyRate
    );

    public record OccupancyReportResponse(
        OccupancySummaryDto Summary,
        IReadOnlyCollection<BinOccupancyDto> Bins
    );

    public static class ReportEndpoints
    {
        public static RouteGroupBuilder MapReportEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/reports")
                .WithTags("Reports");

            group.MapGet("/warehouse-occupancy", async (
                WMSContext dbContext,
                int? warehouseId,
                int? rackId,
                CancellationToken cancellationToken) =>
            {
                var query = dbContext.Bins.AsNoTracking();

                if (warehouseId.HasValue)
                {
                    query = query.Where(bin => bin.Rack != null && bin.Rack.WarehouseId == warehouseId.Value);
                }

                if (rackId.HasValue)
                {
                    query = query.Where(bin => bin.RackId == rackId.Value);
                }

                // Step 1: Query raw bin data and sum total picked quantities per ReceivedProduct
                var rawBinData = await query
                    .Select(bin => new
                    {
                        bin.Id,
                        BinName = bin.BinNames != null ? bin.BinNames.BinName : null,
                        bin.RackId,
                        RackName = bin.Rack != null ? bin.Rack.Name : null,
                        BayNumber = bin.Bay != null ? (int?)bin.Bay.BayNumber : null,
                        LevelNumber = bin.Level != null ? (int?)bin.Level.LevelNumber : null,
                        CheckIns = bin.CheckIns.Select(ci => new
                        {
                            ci.Id,
                            ci.CheckInType,
                            ci.CheckInDate,
                            ci.PalletId,
                            ci.Notes,
                            // Direct Unpalletized Products
                            DirectProducts = ci.ReceivedProducts.Select(rp => new
                            {
                                rp.ReceivingId,
                                ProductName = rp.ExpectedProductName,
                                OriginalQuantity = rp.ExpectedQuantity > 0 ? rp.ExpectedQuantity : rp.Quantity,
                                PickedQuantity = dbContext.PickedProducts
                                    .Where(pp => pp.ReceivedProductId == rp.Id)
                                    .Sum(pp => (int?)pp.QuantityPicked) ?? 0,
                                rp.LotNumber,
                                rp.ContainerName,
                                rp.ExpectedExpirationDate
                            }).ToList(),
                            // Palletized Products (EF Core handles null Pallet automatically via LEFT JOIN)
                            PalletProducts = ci.Pallet.ReceivedProducts.Select(rp => new
                            {
                                rp.ReceivingId,
                                ProductName = rp.Product.Name,
                                OriginalQuantity = rp.ExpectedQuantity > 0 ? rp.ExpectedQuantity : rp.Quantity,
                                PickedQuantity = dbContext.PickedProducts
                                    .Where(pp => pp.ReceivedProductId == rp.Id)
                                    .Sum(pp => (int?)pp.QuantityPicked) ?? 0,
                                rp.LotNumber,
                                rp.ContainerName,
                                rp.ExpectedExpirationDate
                            }).ToList()
                        }).ToList()
                    })
                    .ToListAsync(cancellationToken);

                // Step 2: In-memory filtering — strictly exclude 0-quantity products and empty check-ins
                // Step 2: In-memory filtering — prioritize PalletProducts over DirectProducts to prevent duplication
                var binData = rawBinData.Select(bin =>
                {
                    var activeCheckIns = bin.CheckIns.Select(ci =>
                    {
                        // 1. Pick PalletProducts if available, otherwise fall back to DirectProducts
                        var targetProducts = (ci.PalletProducts != null && ci.PalletProducts.Count > 0)
                            ? ci.PalletProducts
                            : ci.DirectProducts;

                        // 2. Deduct picked stock and exclude 0-quantity items
                        var remainingProducts = targetProducts
                            .Select(p => new
                            {
                                Product = p,
                                RemainingQuantity = p.OriginalQuantity - p.PickedQuantity
                            })
                            .Where(x => x.RemainingQuantity > 0)
                            .Select(x => new CheckInProductDto(
                                x.Product.ReceivingId,
                                x.Product.ProductName,
                                x.RemainingQuantity,
                                x.Product.LotNumber,
                                x.Product.ContainerName,
                                x.Product.ExpectedExpirationDate
                            ))
                            .ToList();

                        return new
                        {
                            ci.Id,
                            ci.CheckInType,
                            ci.CheckInDate,
                            ci.PalletId,
                            ci.Notes,
                            Products = remainingProducts
                        };
                    })
                    .Where(ci => ci.Products.Count > 0)
                    .Select(ci => new BinCheckInDto(
                        ci.Id,
                        ci.CheckInType,
                        ci.CheckInDate,
                        ci.PalletId,
                        ci.Notes,
                        ci.Products
                    ))
                    .ToList();

                    bool isOccupied = activeCheckIns.Count > 0;

                    return new BinOccupancyDto(
                        bin.Id,
                        bin.BinName,
                        bin.RackId,
                        bin.RackName,
                        bin.BayNumber,
                        bin.LevelNumber,
                        isOccupied,
                        activeCheckIns
                    );
                }).ToList();

                var totalBins = binData.Count;
                var occupiedBins = binData.Count(b => b.IsOccupied);
                var vacantBins = totalBins - occupiedBins;
                var occupancyRate = totalBins > 0 ? (double)occupiedBins / totalBins * 100 : 0.0;

                var response = new OccupancyReportResponse(
                    Summary: new OccupancySummaryDto(
                        TotalBins: totalBins,
                        OccupiedBins: occupiedBins,
                        VacantBins: vacantBins,
                        OccupancyRate: Math.Round(occupancyRate, 2)
                    ),
                    Bins: binData
                );

                return TypedResults.Ok(response);
            })
            .WithName("GetWarehouseOccupancyReport")
            .WithSummary("Get warehouse bin occupancy statistics")
            .WithDescription("Calculates bin occupancy metrics with itemized bin check-ins and product details.")
            .Produces<OccupancyReportResponse>(StatusCodes.Status200OK);

            group.MapGet("/transaction-summary", async (
                WMSContext dbContext,
                DateTime startDate,
                DateTime endDate,
                int? warehouseId = null) =>
            {

            });

            // -----------------------------------------------------------------------------
            // POST /reports/generate-receiving-report - Triggers the report generation job
            // -----------------------------------------------------------------------------
            group.MapPost("/generate-receiving-report", async (
                GenerateReceivingReportRequest request, // 👈 Binds JSON request body automatically
                WMSContext dbContext,
                IServiceScopeFactory scopeFactory,
                IHttpContextAccessor httpContextAccessor,
                CancellationToken cancellationToken) =>
            {
                var httpContext = httpContextAccessor.HttpContext;
                var user = httpContext?.User;

                Guid.TryParse(user?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);
                string currentUserEmail = user?.FindFirst(ClaimTypes.Email)?.Value
                    ?? user?.FindFirst("email")?.Value
                    ?? user?.Identity?.Name
                    ?? "System";

                // Extract dates with safe fallbacks
                DateTime startDate = request.StartDate ?? DateTime.UtcNow.AddMonths(-1);
                DateTime endDate = request.EndDate ?? DateTime.UtcNow;

                string jobNumber = $"REP-RCV-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";

                var job = new ReportJob
                {
                    JobNumber = jobNumber,
                    ReportType = ReportType.Receiving,
                    Format = ReportFormat.Excel,
                    Status = ReportStatus.Pending,
                    PeriodStart = startDate,
                    PeriodEnd = endDate,
                    RequestedBy = currentUserEmail,
                    CreatedBy = currentUserEmail,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                dbContext.ReportJobs.Add(job);
                await dbContext.SaveChangesAsync(cancellationToken);
                int jobId = job.Id;

                _ = Task.Run(async () =>
                {
                    using var scope = scopeFactory.CreateScope();
                    var backgroundDb = scope.ServiceProvider.GetRequiredService<WMSContext>();

                    try
                    {
                        var processingJob = await backgroundDb.ReportJobs.FindAsync(jobId);
                        if (processingJob != null)
                        {
                            processingJob.Status = ReportStatus.Processing;
                            processingJob.LastModifiedAt = DateTimeOffset.UtcNow;
                            processingJob.LastModifiedBy = "System (Background Task)";
                            await backgroundDb.SaveChangesAsync();
                        }

                        // 1. Resolve targeted Incoming IDs
                        List<int>? matchingIncomingIds = null;
                        if (!string.IsNullOrWhiteSpace(request.PackingListNumber))
                        {
                            matchingIncomingIds = await backgroundDb.Receivings
                                .AsNoTracking()
                                .Where(r => r.IncomingId != null && r.Reference.Contains(request.PackingListNumber))
                                .Select(r => r.IncomingId!.Value)
                                .Distinct()
                                .ToListAsync();
                        }

                        // 2. Query Target Incomings & Expected Products
                        var incomingQuery = backgroundDb.Incomings
                            .Include(i => i.Products!)
                                .ThenInclude(p => p.Product)
                            .AsNoTracking()
                            .AsQueryable();

                        if (request.IncomingId.HasValue)
                            incomingQuery = incomingQuery.Where(i => i.Id == request.IncomingId.Value);

                        if (matchingIncomingIds != null)
                            incomingQuery = incomingQuery.Where(i => matchingIncomingIds.Contains(i.Id));

                        var incomings = await incomingQuery.ToListAsync();
                        var targetIncomingIds = incomings.Select(i => i.Id).ToList();

                        // 3. Query Actual Receivings & Received Products
                        var receivingQuery = backgroundDb.Receivings
                            .Include(r => r.Products!)
                                .ThenInclude(p => p.Product)
                            .Include(r => r.Products!)
                                .ThenInclude(p => p.Pallet)
                            .AsNoTracking()
                            .Where(r => r.IncomingId != null && targetIncomingIds.Contains(r.IncomingId.Value)
                                     && r.DateReceived >= startDate && r.DateReceived <= endDate);

                        if (!string.IsNullOrWhiteSpace(request.PlateNumber))
                            receivingQuery = receivingQuery.Where(r => r.PlateNumber.Contains(request.PlateNumber));

                        var receivings = await receivingQuery.ToListAsync();

                        if (!string.IsNullOrWhiteSpace(request.PalletNumber))
                        {
                            // Clean target value in case 'PAL-' prefix was included in the string
                            string targetPallet = request.PalletNumber.Trim().Replace("PAL-", "", StringComparison.OrdinalIgnoreCase);

                            foreach (var r in receivings)
                            {
                                r.Products = r.Products?
                                    .Where(p => p.Pallet != null &&
                                                p.Pallet.PalletNumber.ToString().Equals(targetPallet, StringComparison.OrdinalIgnoreCase))
                                    .ToList() ?? new List<ReceivedProduct>();
                            }

                            receivings = receivings.Where(r => r.Products != null && r.Products.Any()).ToList();
                        }

                        // 4. Calculate Summary Metrics & Header Data
                        var allReceivedProducts = receivings.SelectMany(r => r.Products ?? new List<ReceivedProduct>()).ToList();
                        var allExpectedProducts = incomings.SelectMany(i => i.Products ?? new List<IncomingProduct>()).ToList();

                        int totalExpectedQuantity = allExpectedProducts.Sum(p => p.Quantity);
                        int totalReceivedQuantity = allReceivedProducts.Sum(p => p.Quantity);
                        int totalRemainingQuantity = Math.Max(0, totalExpectedQuantity - totalReceivedQuantity);

                        string headerShippers = string.Join(", ", incomings.Select(i => i.Shipper).Where(s => !string.IsNullOrWhiteSpace(s)).Distinct());
                        string headerConsignees = string.Join(", ", incomings.Select(i => i.Consignee).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct());
                        string headerStatuses = string.Join(", ", incomings.Select(i => i.Status.ToString()).Distinct());

                        // 5. Generate Excel Sheet
                        using var workbook = new XLWorkbook();
                        var ws = workbook.Worksheets.Add("Receiving Report");

                        // -------------------------------------------------------------
                        // SECTION A: TITLE & FILTERS HEADER METADATA
                        // -------------------------------------------------------------
                        ws.Cell("A1").Value = "RECEIVING RECONCILIATION REPORT";
                        ws.Range("A1:L1").Merge()
                            .Style.Font.SetBold().Font.SetFontSize(15)
                            .Fill.SetBackgroundColor(XLColor.FromHtml("#1E293B"))
                            .Font.SetFontColor(XLColor.White)
                            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        ws.Cell("A3").Value = "Job Number:";
                        ws.Cell("B3").Value = jobNumber;

                        ws.Cell("A4").Value = "Date Generated:";
                        ws.Cell("B4").Value = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(8)).ToString("yyyy-MM-dd hh:mm tt 'PST'");

                        ws.Cell("A5").Value = "Date Range:";
                        ws.Cell("B5").Value = $"{startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}";

                        ws.Cell("A6").Value = "Packing List Filter:";
                        ws.Cell("B6").Value = !string.IsNullOrWhiteSpace(request.PackingListNumber) ? request.PackingListNumber : (request.IncomingId.HasValue ? $"INC-{request.IncomingId}" : "ALL");

                        ws.Cell("A7").Value = "Pallet Filter:";
                        ws.Cell("B7").Value = !string.IsNullOrWhiteSpace(request.PalletNumber) ? request.PalletNumber : "ALL";

                        ws.Cell("A8").Value = "Plate Number Filter:";
                        ws.Cell("B8").Value = !string.IsNullOrWhiteSpace(request.PlateNumber) ? request.PlateNumber : "ALL";

                        ws.Cell("A9").Value = "Shipper(s):";
                        ws.Cell("B9").Value = !string.IsNullOrWhiteSpace(headerShippers) ? headerShippers : "N/A";

                        ws.Cell("A10").Value = "Consignee(s):";
                        ws.Cell("B10").Value = !string.IsNullOrWhiteSpace(headerConsignees) ? headerConsignees : "N/A";

                        ws.Cell("A11").Value = "Incoming Status:";
                        ws.Cell("B11").Value = !string.IsNullOrWhiteSpace(headerStatuses) ? headerStatuses : "N/A";

                        ws.Range("A3:A11").Style.Font.SetBold();

                        // -------------------------------------------------------------
                        // SECTION B: RECONCILIATION SUMMARY BOX
                        // -------------------------------------------------------------
                        ws.Cell("I3").Value = "Total Expected Qty:";
                        ws.Cell("J3").Value = totalExpectedQuantity;

                        ws.Cell("I4").Value = "Total Received Qty:";
                        ws.Cell("J4").Value = totalReceivedQuantity;

                        ws.Cell("I5").Value = "Remaining Balance Qty:";
                        ws.Cell("J5").Value = totalRemainingQuantity;

                        ws.Range("I3:I5").Style.Font.SetBold();
                        ws.Range("I3:J5").Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                        ws.Range("J5").Style.Font.SetFontColor(totalRemainingQuantity == 0 ? XLColor.Emerald : XLColor.Red).Font.SetBold();

                        int currentRow = 13; // 👈 Updated starting row for Table 1 to accommodate the extra header row

                        // -------------------------------------------------------------
                        // TABLE 1: RECEIVED ITEMS
                        // -------------------------------------------------------------
                        ws.Cell(currentRow, 1).Value = "1. LIST OF RECEIVED ITEMS";
                        // Increased span to 12 columns to accommodate the new CBM column
                        ws.Range(currentRow, 1, currentRow, 12).Merge()
                            .Style.Font.SetBold().Font.SetFontSize(12)
                            .Fill.SetBackgroundColor(XLColor.FromHtml("#059669"))
                            .Font.SetFontColor(XLColor.White);
                        currentRow++;

                        string[] receivedHeaders = {
    "Receipt Series", "Date Received", "Reference", "Shipper", "Consignee",
    "Product Code", "Product Name", "Received Qty", "UOM", "CBM", "Weight (KG)",
    "Pallet / Plate"
};

                        for (int i = 0; i < receivedHeaders.Length; i++)
                        {
                            var cell = ws.Cell(currentRow, i + 1);
                            cell.Value = receivedHeaders[i];
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        }
                        currentRow++;

                        if (!allReceivedProducts.Any())
                        {
                            ws.Cell(currentRow, 1).Value = "No items received for the selected parameters.";
                            ws.Range(currentRow, 1, currentRow, 12).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            currentRow++;
                        }
                        else
                        {
                            foreach (var r in receivings)
                            {
                                foreach (var rp in r.Products!)
                                {
                                    ws.Cell(currentRow, 1).Value = r.Series;
                                    ws.Cell(currentRow, 2).Value = r.DateReceived.ToString("yyyy-MM-dd");
                                    ws.Cell(currentRow, 3).Value = r.Reference;
                                    ws.Cell(currentRow, 4).Value = r.Shipper ?? r.Incoming?.Shipper ?? "N/A";
                                    ws.Cell(currentRow, 5).Value = r.Consignee ?? r.Incoming?.Consignee ?? "N/A";
                                    ws.Cell(currentRow, 6).Value = rp.Product?.Code ?? "N/A";
                                    ws.Cell(currentRow, 7).Value = rp.Product?.Name ?? rp.ExpectedProductName ?? "N/A";
                                    ws.Cell(currentRow, 8).Value = rp.Quantity;
                                    ws.Cell(currentRow, 9).Value = rp.TypeOfPackage;
                                    ws.Cell(currentRow, 10).Value = rp.CBM;        
                                    ws.Cell(currentRow, 11).Value = rp.TotalWeight; 
                                    ws.Cell(currentRow, 12).Value = $"PAL-{(rp.Pallet != null ? rp.Pallet.PalletNumber : rp.PalletId?.ToString() ?? "UNASSIGNED")} / {r.PlateNumber}";
                                    currentRow++;
                                }
                            }
                        }

                        currentRow += 2;

                        // TABLE 2: REMAINING ITEMS
                        ws.Cell(currentRow, 1).Value = "2. LIST OF REMAINING ITEMS (PENDING RECEIPT)";
                        ws.Range(currentRow, 1, currentRow, 8).Merge()
                            .Style.Font.SetBold().Font.SetFontSize(12)
                            .Fill.SetBackgroundColor(XLColor.FromHtml("#DC2626"))
                            .Font.SetFontColor(XLColor.White);
                        currentRow++;

                        string[] remainingHeaders = {
                "Packing List Ref", "Shipper", "Consignee", "Product Code",
                "Product Name", "Expected Qty", "Received Qty", "Remaining Shortage Qty"
            };

                        for (int i = 0; i < remainingHeaders.Length; i++)
                        {
                            var cell = ws.Cell(currentRow, i + 1);
                            cell.Value = remainingHeaders[i];
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        }
                        currentRow++;

                        bool hasRemaining = false;
                        foreach (var inc in incomings)
                        {
                            string packingListRef = receivings
                                .Where(r => r.IncomingId == inc.Id)
                                .Select(r => r.Reference)
                                .FirstOrDefault() ?? $"INC-{inc.Id}";

                            foreach (var ep in inc.Products ?? new List<IncomingProduct>())
                            {
                                int actualReceived = allReceivedProducts
                                    .Where(rp => rp.IncomingProductId == ep.Id || rp.ProductId == ep.ProductId)
                                    .Sum(rp => rp.Quantity);

                                int remaining = Math.Max(0, ep.Quantity - actualReceived);

                                if (remaining > 0)
                                {
                                    hasRemaining = true;
                                    ws.Cell(currentRow, 1).Value = packingListRef;
                                    ws.Cell(currentRow, 2).Value = inc.Shipper ?? "N/A";
                                    ws.Cell(currentRow, 3).Value = inc.Consignee ?? "N/A";
                                    ws.Cell(currentRow, 4).Value = ep.Product?.Code ?? "N/A";
                                    ws.Cell(currentRow, 5).Value = ep.Product?.Name ?? "N/A";
                                    ws.Cell(currentRow, 6).Value = ep.Quantity;
                                    ws.Cell(currentRow, 7).Value = actualReceived;
                                    ws.Cell(currentRow, 8).Value = remaining;
                                    ws.Cell(currentRow, 8).Style.Font.SetFontColor(XLColor.Red).Font.SetBold();
                                    currentRow++;
                                }
                            }
                        }

                        if (!hasRemaining)
                        {
                            ws.Cell(currentRow, 1).Value = "All items under the selected incoming packing list(s) have been fully received!";
                            ws.Range(currentRow, 1, currentRow, 9).Merge().Style.Font.SetFontColor(XLColor.Emerald).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold();
                        }

                        ws.Columns().AdjustToContents();

                        // SAVE & COMPLETE JOB
                        string reportsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Receiving");
                        if (!Directory.Exists(reportsDirectory)) Directory.CreateDirectory(reportsDirectory);

                        string fileName = $"{jobNumber}.xlsx";
                        string fullPath = Path.Combine(reportsDirectory, fileName);
                        workbook.SaveAs(fullPath);

                        var completedJob = await backgroundDb.ReportJobs.FindAsync(jobId);
                        if (completedJob != null)
                        {
                            completedJob.Status = ReportStatus.Completed;
                            completedJob.FilePath = Path.Combine("Reports", "Receiving", fileName);
                            completedJob.CompletedAt = DateTimeOffset.UtcNow;
                            completedJob.LastModifiedAt = DateTimeOffset.UtcNow;
                            completedJob.LastModifiedBy = "System (Background Task)";
                            await backgroundDb.SaveChangesAsync();

                            var auditLogService = scope.ServiceProvider.GetRequiredService<IAuditLogService>();
                            await auditLogService.LogAsync(
                                category: "Reporting",
                                action: "Generated",
                                description: $"Generated Receiving Report '{completedJob.JobNumber}'. Expected: {totalExpectedQuantity}, Received: {totalReceivedQuantity}, Remaining: {totalRemainingQuantity}.",
                                details: new Dictionary<string, object?>
                                {
                                    ["JobId"] = completedJob.Id,
                                    ["JobNumber"] = completedJob.JobNumber,
                                    ["Format"] = completedJob.Format.ToString(),
                                    ["FilePath"] = completedJob.FilePath,
                                    ["Shipper"] = headerShippers,
                                    ["Consignee"] = headerConsignees,
                                    ["Status"] = headerStatuses,
                                    ["Filters"] = request
                                },
                                userOverride: currentUserEmail,
                                userIdOverride: userId
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        var failedJob = await backgroundDb.ReportJobs.FindAsync(jobId);
                        if (failedJob != null)
                        {
                            failedJob.Status = ReportStatus.Failed;
                            failedJob.ErrorMessage = ex.Message;
                            failedJob.CompletedAt = DateTimeOffset.UtcNow;
                            failedJob.LastModifiedAt = DateTimeOffset.UtcNow;
                            failedJob.LastModifiedBy = "System (Background Task)";
                            await backgroundDb.SaveChangesAsync();
                        }
                    }
                });

                return TypedResults.Accepted($"/api/reports/{job.Id}", new GenerateReportResponse(
                    "Report generation started.",
                    job.Id,
                    job.JobNumber
                ));
            })
            .Produces<GenerateReportResponse>(StatusCodes.Status202Accepted)
            .WithName("GenerateReceivingReport")
            .WithSummary("Triggers an async job to generate a Reconciled Receiving Excel report");


            // -----------------------------------------------------------------------------
            // GET /reports/receiving
            // -----------------------------------------------------------------------------
            group.MapGet("/receiving", async (
                WMSContext dbContext,
                int page = 1,
                int pageSize = 15,
                CancellationToken cancellationToken = default) =>
            {
                var query = dbContext.ReportJobs
                    .Where(r => r.ReportType == ReportType.Receiving)
                    .OrderByDescending(r => r.CreatedAt)
                    .AsNoTracking();

                var totalCount = await query.CountAsync(cancellationToken);
                var jobs = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                // ✅ Explicitly return TypedResults with DTO
                return TypedResults.Ok(new ReceivingReportListResponse(
                    jobs,
                    page,
                    pageSize,
                    totalCount,
                    (int)Math.Ceiling(totalCount / (double)pageSize)
                ));
            })
            .Produces<ReceivingReportListResponse>(StatusCodes.Status200OK)
            .WithName("GetReceivingReports")
            .WithSummary("Retrieve list of generated receiving reports");

            group.MapGet("/receiving/download/{id:int}", async (
                int id,
                WMSContext dbContext,
                CancellationToken cancellationToken = default) =>
            {
                var job = await dbContext.ReportJobs.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

                if (job == null)
                    return Results.NotFound(new { Message = "Report job not found." });

                if (job.Status != ReportStatus.Completed || string.IsNullOrEmpty(job.FilePath))
                    return Results.BadRequest(new { Message = $"Report is not ready. Current Status: {job.Status}" });

                var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), job.FilePath);

                if (!File.Exists(absolutePath))
                    return Results.NotFound(new { Message = "Physical report file missing on disk." });

                string contentType = Path.GetExtension(absolutePath).ToLower() switch
                {
                    ".pdf" => "application/pdf",
                    ".csv" => "text/csv",
                    ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    _ => "application/octet-stream"
                };

                string fileName = Path.GetFileName(absolutePath);

                return Results.File(absolutePath, contentType, fileName);
            })
            .Produces(StatusCodes.Status200OK, contentType: "application/octet-stream")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("DownloadReport")
            .WithSummary("Downloads the generated report file");

            return group;
        }
    }
}