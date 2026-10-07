using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using WMS.Api.Data;
using WMS.Api.Dtos.Reporting;
using WMS.Api.Entities;
using WMS.Api.Entities.Reporting;

namespace WMS.Api.Endpoints.ReportsEndpoints
{
    public static class PickOrderReportEndpoints
    {
        public static RouteGroupBuilder MapPickOrderReportEndpoints(this RouteGroupBuilder group)
        {
            // -----------------------------------------------------------------------------
            // GET /reports/pick-orders - List generated pick order reports
            // -----------------------------------------------------------------------------
            group.MapGet("/pick-orders", async (
                WMSContext dbContext,
                int warehouseId,
                int page = 1,
                int pageSize = 15,
                CancellationToken cancellationToken = default) =>
            {
                var query = dbContext.ReportJobs
                    .Where(r => r.ReportType == ReportType.PickOrder && r.WarehouseId == warehouseId)
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
            .WithName("GetPickOrderReports")
            .WithSummary("Retrieve list of generated pick order reports");

            // -----------------------------------------------------------------------------
            // POST /reports/pickorders/generate - Queue Pick Order report generation job
            // -----------------------------------------------------------------------------
            group.MapPost("/pickorders/generate", async (
                GeneratePickOrderReportRequest request,
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

                string jobNumber = $"REP-PICK-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";

                var job = new ReportJob
                {
                    JobNumber = jobNumber,
                    ReportType = ReportType.PickOrder,
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

                        var query = backgroundDb.ManualPickings
                            .Include(mp => mp.Warehouse)
                            .Include(mp => mp.Bin)
                                .ThenInclude(b => b!.Rack)
                            .Include(mp => mp.Bin)
                                .ThenInclude(b => b!.Bay)
                            .Include(mp => mp.Bin)
                                .ThenInclude(b => b!.Level)
                            .Include(mp => mp.Bin)
                                .ThenInclude(b => b!.BinNames)
                            .Include(mp => mp.PickedProducts)
                                .ThenInclude(pp => pp.ReceivedProduct)
                                    .ThenInclude(rp => rp!.Receiving)
                            .Include(mp => mp.PickedProducts)
                                .ThenInclude(pp => pp.ReceivedProduct)
                                    .ThenInclude(rp => rp!.Product)
                            .AsNoTracking()
                            .Where(mp => mp.PickingDate >= startDate && mp.PickingDate <= endDate);

                        if (request.WarehouseId.HasValue)
                            query = query.Where(mp => mp.WarehouseId == request.WarehouseId.Value);

                        if (!string.IsNullOrWhiteSpace(request.Shipper))
                        {
                            query = query.Where(mp => mp.PickedProducts.Any(pp =>
                                pp.ReceivedProduct != null &&
                                pp.ReceivedProduct.Receiving != null &&
                                pp.ReceivedProduct.Receiving.Shipper.Contains(request.Shipper)));
                        }

                        var manualPickings = await query.ToListAsync();

                        var warehouse = request.WarehouseId.HasValue
                            ? await backgroundDb.Warehouses
                                .AsNoTracking()
                                .FirstOrDefaultAsync(w => w.Id == request.WarehouseId.Value)
                            : null;

                        string warehouseDisplayName = warehouse?.Name
                            ?? (request.WarehouseId.HasValue ? $"Warehouse #{request.WarehouseId.Value}" : "ALL");

                        var allPickedProducts = manualPickings.SelectMany(mp => mp.PickedProducts).ToList();
                        int totalPickedQty = allPickedProducts.Sum(p => p.QuantityPicked);

                        var uniqueShippers = allPickedProducts
                            .Select(p => p.ReceivedProduct?.Receiving?.Shipper)
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .Distinct()
                            .ToList();

                        string headerShippers = uniqueShippers.Any() ? string.Join(", ", uniqueShippers) : "ALL";

                        using var workbook = new XLWorkbook();
                        var ws = workbook.Worksheets.Add("Pick Orders");

                        ws.Cell("A1").Value = "PICK ORDER REPORT";
                        ws.Range("A1:H1").Merge()
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

                        ws.Cell("A7").Value = "Shipper(s):";
                        ws.Cell("B7").Value = !string.IsNullOrWhiteSpace(request.Shipper) ? request.Shipper : headerShippers;

                        ws.Range("A3:A7").Style.Font.SetBold();

                        ws.Cell("F3").Value = "Total Picked Qty:";
                        ws.Cell("G3").Value = totalPickedQty;

                        ws.Cell("F3").Style.Font.SetBold();
                        ws.Range("F3:G3").Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
                        ws.Range("G3").Style.Font.SetFontColor(XLColor.FromHtml("#0284C7")).Font.SetBold();

                        int currentRow = 10;

                        ws.Cell(currentRow, 1).Value = "LIST OF PICKED PRODUCTS";
                        ws.Range(currentRow, 1, currentRow, 9).Merge()
                            .Style.Font.SetBold().Font.SetFontSize(12)
                            .Fill.SetBackgroundColor(XLColor.FromHtml("#0284C7"))
                            .Font.SetFontColor(XLColor.White);
                        currentRow++;

                        string[] headers = {
                            "Pick ID", "Picking Date", "Warehouse", "Bin", "Shipper",
                            "Product Code", "Product Name", "Picked Qty", "Notes"
                        };

                        for (int i = 0; i < headers.Length; i++)
                        {
                            var cell = ws.Cell(currentRow, i + 1);
                            cell.Value = headers[i];
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        }
                        currentRow++;

                        if (!manualPickings.Any())
                        {
                            ws.Cell(currentRow, 1).Value = "No items picked for the selected parameters.";
                            ws.Range(currentRow, 1, currentRow, 9).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            currentRow++;
                        }
                        else
                        {
                            foreach (var mp in manualPickings)
                            {
                                foreach (var pp in mp.PickedProducts ?? new List<PickedProduct>())
                                {
                                    ws.Cell(currentRow, 1).Value = $"MP-{mp.Id}";
                                    ws.Cell(currentRow, 2).Value = mp.PickingDate.ToString("yyyy-MM-dd HH:mm");
                                    ws.Cell(currentRow, 3).Value = SanitizeXml(mp.Warehouse?.Name ?? $"ID:{mp.WarehouseId}");

                                    if (mp.Bin != null)
                                    {
                                        string rackName = mp.Bin.Rack?.Name ?? "N/A";
                                        string bayStr = mp.Bin.Bay != null ? $"Bay{mp.Bin.Bay.BayNumber}" : "N/A";
                                        string levelStr = mp.Bin.Level != null ? $"Level{mp.Bin.Level.LevelNumber}" : "N/A";
                                        string binName = mp.Bin.BinNames?.BinName ?? $"Bin#{mp.BinId}";

                                        ws.Cell(currentRow, 4).Value = SanitizeXml($"{rackName}/{bayStr}/{levelStr}/{binName}");
                                    }
                                    else
                                    {
                                        ws.Cell(currentRow, 4).Value = $"Bin ID: {mp.BinId}";
                                    }

                                    ws.Cell(currentRow, 5).Value = SanitizeXml(pp.ReceivedProduct?.Receiving?.Shipper ?? "N/A");
                                    ws.Cell(currentRow, 6).Value = SanitizeXml(pp.ReceivedProduct?.Product?.Code ?? "N/A");
                                    ws.Cell(currentRow, 7).Value = SanitizeXml(pp.ReceivedProduct?.ExpectedProductName ?? pp.ReceivedProduct?.Product?.Name ?? "N/A");
                                    ws.Cell(currentRow, 8).Value = pp.QuantityPicked;
                                    ws.Cell(currentRow, 9).Value = SanitizeXml(mp.Notes);

                                    currentRow++;
                                }
                            }
                        }

                        ws.Columns().AdjustToContents();

                        string reportsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "PickOrders");
                        if (!Directory.Exists(reportsDirectory)) Directory.CreateDirectory(reportsDirectory);

                        string fileName = $"{jobNumber}.xlsx";
                        string fullPath = Path.Combine(reportsDirectory, fileName);
                        workbook.SaveAs(fullPath);

                        var completedJob = await backgroundDb.ReportJobs.FindAsync(jobId);
                        if (completedJob != null)
                        {
                            completedJob.Status = ReportStatus.Completed;
                            completedJob.FilePath = Path.Combine("Reports", "PickOrders", fileName);
                            completedJob.CompletedAt = DateTimeOffset.UtcNow;
                            completedJob.LastModifiedAt = DateTimeOffset.UtcNow;
                            completedJob.LastModifiedBy = "System (Background Task)";
                            await backgroundDb.SaveChangesAsync();
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
            .WithName("GeneratePickOrderReport")
            .WithSummary("Triggers an async job to generate an Excel report for Manual Pickings");

            // -----------------------------------------------------------------------------
            // GET /reports/pickorders/download/{id} - Download Pick Order Report
            // -----------------------------------------------------------------------------
            group.MapGet("/pickorders/download/{id:int}", async (
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
            .WithName("DownloadPickOrderReport")
            .WithSummary("Downloads the generated pick order report file");

            return group;
        }

        private static string SanitizeXml(string? input) =>
            string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, @"[\x00-\x08\x0B\x0C\x0E-\x1F\x7F]", string.Empty);
    }
}