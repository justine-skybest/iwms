using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using WMS.Api.Data;
using WMS.Api.Dtos.Reporting;
using WMS.Api.Entities;
using WMS.Api.Entities.Reporting;
using WMS.Api.Services;

namespace WMS.Api.Endpoints.ReportsEndpoints
{
    public static class ReceivingReportEndpoints
    {
        public static RouteGroupBuilder MapReceivingReportEndpoints(this RouteGroupBuilder group)
        {
            // -----------------------------------------------------------------------------
            // GET /reports/receiving - List generated receiving reports
            // -----------------------------------------------------------------------------
            group.MapGet("/receiving", async (
                WMSContext dbContext,
                int warehouseId,
                int page = 1,
                int pageSize = 15,
                CancellationToken cancellationToken = default) =>
            {
                var query = dbContext.ReportJobs
                    .Where(r => r.ReportType == ReportType.Receiving && r.WarehouseId == warehouseId)
                    .OrderByDescending(r => r.CreatedAt)
                    .AsNoTracking();

                var totalCount = await query.CountAsync(cancellationToken);
                var jobs = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                return TypedResults.Ok(new ReportListResponse(
                    jobs,
                    page,
                    pageSize,
                    totalCount,
                    (int)Math.Ceiling(totalCount / (double)pageSize)
                ));
            })
            .Produces<ReportListResponse>(StatusCodes.Status200OK)
            .WithName("GetReceivingReports")
            .WithSummary("Retrieve list of generated receiving reports");

            // -----------------------------------------------------------------------------
            // POST /reports/generate-receiving-report - Queue receiving report job
            // -----------------------------------------------------------------------------
            group.MapPost("/generate-receiving-report", async (
                GenerateReceivingReportRequest request,
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

                DateTime startDate = (request.StartDate ?? DateTime.UtcNow.AddMonths(-1)).Date;
                DateTime endDate = (request.EndDate ?? DateTime.UtcNow).Date.AddDays(1).AddTicks(-1);

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
                    CreatedAt = DateTimeOffset.UtcNow,
                    WarehouseId = request.WarehouseId
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

                        var incomingQuery = backgroundDb.Incomings
                            .Include(i => i.Products)
                                .ThenInclude(p => p.Product)
                            .AsNoTracking();

                        if (request.IncomingId.HasValue)
                            incomingQuery = incomingQuery.Where(i => i.Id == request.IncomingId.Value);

                        if (request.WarehouseId.HasValue)
                            incomingQuery = incomingQuery.Where(i => i.WarehouseId == request.WarehouseId.Value);

                        if (matchingIncomingIds != null)
                            incomingQuery = incomingQuery.Where(i => matchingIncomingIds.Contains(i.Id));

                        var incomings = await incomingQuery.ToListAsync();
                        var targetIncomingIds = incomings.Select(i => i.Id).ToList();

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

                        var warehouse = request.WarehouseId.HasValue
                            ? await backgroundDb.Warehouses
                                .AsNoTracking()
                                .FirstOrDefaultAsync(w => w.Id == request.WarehouseId.Value)
                            : null;

                        string warehouseDisplayName = warehouse?.Name
                            ?? (request.WarehouseId.HasValue ? $"Warehouse #{request.WarehouseId.Value}" : "ALL");

                        var allReceivedProducts = receivings.SelectMany(r => r.Products ?? new List<ReceivedProduct>()).ToList();
                        var allExpectedProducts = incomings.SelectMany(i => i.Products ?? new List<IncomingProduct>()).ToList();

                        int totalExpectedQuantity = allExpectedProducts.Sum(p => p.Quantity);
                        int totalReceivedQuantity = allReceivedProducts.Sum(p => p.Quantity);
                        int totalRemainingQuantity = Math.Max(0, totalExpectedQuantity - totalReceivedQuantity);

                        string headerShippers = string.Join(", ", incomings.Select(i => i.Shipper).Where(s => !string.IsNullOrWhiteSpace(s)).Distinct());
                        string headerConsignees = string.Join(", ", incomings.Select(i => i.Consignee).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct());
                        string headerStatuses = string.Join(", ", incomings.Select(i => i.Status.ToString()).Distinct());

                        using var workbook = new XLWorkbook();
                        var ws = workbook.Worksheets.Add("Receiving Report");

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

                        ws.Cell("A6").Value = "Warehouse Filter:";
                        ws.Cell("B6").Value = warehouseDisplayName;

                        ws.Cell("A7").Value = "Packing List Filter:";
                        ws.Cell("B7").Value = !string.IsNullOrWhiteSpace(request.PackingListNumber) ? request.PackingListNumber : (request.IncomingId.HasValue ? $"INC-{request.IncomingId}" : "ALL");

                        ws.Cell("A8").Value = "Pallet Filter:";
                        ws.Cell("B8").Value = !string.IsNullOrWhiteSpace(request.PalletNumber) ? request.PalletNumber : "ALL";

                        ws.Cell("A9").Value = "Plate Number Filter:";
                        ws.Cell("B9").Value = !string.IsNullOrWhiteSpace(request.PlateNumber) ? request.PlateNumber : "ALL";

                        ws.Cell("A10").Value = "Shipper(s):";
                        ws.Cell("B10").Value = !string.IsNullOrWhiteSpace(headerShippers) ? headerShippers : "N/A";

                        ws.Cell("A11").Value = "Consignee(s):";
                        ws.Cell("B11").Value = !string.IsNullOrWhiteSpace(headerConsignees) ? headerConsignees : "N/A";

                        ws.Cell("A12").Value = "Incoming Status:";
                        ws.Cell("B12").Value = !string.IsNullOrWhiteSpace(headerStatuses) ? headerStatuses : "N/A";

                        ws.Range("A3:A12").Style.Font.SetBold();

                        ws.Cell("I3").Value = "Total Expected Qty:";
                        ws.Cell("J3").Value = totalExpectedQuantity;

                        ws.Cell("I4").Value = "Total Received Qty:";
                        ws.Cell("J4").Value = totalReceivedQuantity;

                        ws.Cell("I5").Value = "Remaining Balance Qty:";
                        ws.Cell("J5").Value = totalRemainingQuantity;

                        ws.Range("I3:I5").Style.Font.SetBold();
                        ws.Range("I3:J5").Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                        ws.Range("J5").Style.Font.SetFontColor(totalRemainingQuantity == 0 ? XLColor.Emerald : XLColor.Red).Font.SetBold();

                        int currentRow = 14;

                        ws.Cell(currentRow, 1).Value = "1. LIST OF RECEIVED ITEMS";
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
                                    ws.Cell(currentRow, 1).Value = SanitizeXml(r.Series);
                                    ws.Cell(currentRow, 2).Value = r.DateReceived.ToString("yyyy-MM-dd");
                                    ws.Cell(currentRow, 3).Value = SanitizeXml(r.Reference);
                                    ws.Cell(currentRow, 4).Value = SanitizeXml(r.Shipper ?? r.Incoming?.Shipper ?? "N/A");
                                    ws.Cell(currentRow, 5).Value = SanitizeXml(r.Consignee ?? r.Incoming?.Consignee ?? "N/A");
                                    ws.Cell(currentRow, 6).Value = SanitizeXml(rp.Product?.Code ?? "N/A");
                                    ws.Cell(currentRow, 7).Value = SanitizeXml(rp.Product?.Name ?? rp.ExpectedProductName ?? "N/A");
                                    ws.Cell(currentRow, 8).Value = rp.Quantity;
                                    ws.Cell(currentRow, 9).Value = SanitizeXml(rp.TypeOfPackage);
                                    ws.Cell(currentRow, 10).Value = SanitizeXml(rp.CBM);
                                    ws.Cell(currentRow, 11).Value = SanitizeXml(rp.TotalWeight);
                                    ws.Cell(currentRow, 12).Value = $"PAL-{(rp.Pallet != null ? rp.Pallet.PalletNumber : rp.PalletId?.ToString() ?? "UNASSIGNED")} / {SanitizeXml(r.PlateNumber)}";
                                    currentRow++;
                                }
                            }
                        }

                        currentRow += 2;

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
                                    ws.Cell(currentRow, 1).Value = SanitizeXml(packingListRef);
                                    ws.Cell(currentRow, 2).Value = SanitizeXml(inc.Shipper ?? "N/A");
                                    ws.Cell(currentRow, 3).Value = SanitizeXml(inc.Consignee ?? "N/A");
                                    ws.Cell(currentRow, 4).Value = SanitizeXml(ep.Product?.Code ?? "N/A");
                                    ws.Cell(currentRow, 5).Value = SanitizeXml(ep.Product?.Name ?? "N/A");
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
            // GET /reports/receiving/download/{id:int} - Download Receiving Report
            // -----------------------------------------------------------------------------
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

        private static string SanitizeXml(string? input) =>
            string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, @"[\x00-\x08\x0B\x0C\x0E-\x1F\x7F]", string.Empty);
    }
}