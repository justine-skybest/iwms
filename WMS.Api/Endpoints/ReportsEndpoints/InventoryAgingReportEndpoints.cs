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
    public static class InventoryAgingReportEndpoints
    {
        public static RouteGroupBuilder MapInventoryAgingReportEndpoints(this RouteGroupBuilder group)
        {
            // -----------------------------------------------------------------------------
            // GET /reports/inventory-aging - List generated inventory aging reports
            // -----------------------------------------------------------------------------
            group.MapGet("/inventory-aging", async (
                WMSContext dbContext,
                int warehouseId,
                int page = 1,
                int pageSize = 15,
                CancellationToken cancellationToken = default) =>
            {
                var query = dbContext.ReportJobs
                    .Where(r => r.ReportType == ReportType.Aging && r.WarehouseId == warehouseId)
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
            .WithName("GetInventoryAgingReports")
            .WithSummary("Retrieve list of generated inventory aging reports");

            // -----------------------------------------------------------------------------
            // POST /reports/inventory-aging - Queue aging report generation job
            // -----------------------------------------------------------------------------
            group.MapPost("/inventory-aging", async (
                GenerateInventoryAgingReportRequest request,
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

                string jobNumber = $"REP-AGE-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";

                var job = new ReportJob
                {
                    JobNumber = jobNumber,
                    ReportType = ReportType.Aging,
                    Format = request.Format,
                    Status = ReportStatus.Pending,
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

                        // 1. Build Query with Navigation Metadata
                        var query = backgroundDb.ReceivedProducts
                            .Include(rp => rp.Receiving)
                                .ThenInclude(r => r!.Warehouse)
                            .Include(rp => rp.Product)
                            .Include(rp => rp.CheckIns)
                                .ThenInclude(ci => ci.Bins)
                                    .ThenInclude(b => b.Rack)
                            .Include(rp => rp.CheckIns)
                                .ThenInclude(ci => ci.Bins)
                                    .ThenInclude(b => b.Bay)
                            .Include(rp => rp.CheckIns)
                                .ThenInclude(ci => ci.Bins)
                                    .ThenInclude(b => b.Level)
                            .Include(rp => rp.CheckIns)
                                .ThenInclude(ci => ci.Bins)
                                    .ThenInclude(b => b.BinNames)
                            .AsNoTracking()
                            .AsQueryable();

                        if (request.WarehouseId.HasValue)
                        {
                            query = query.Where(rp => rp.Receiving != null && rp.Receiving.WarehouseId == request.WarehouseId.Value);
                        }

                        if (!string.IsNullOrWhiteSpace(request.Shipper))
                        {
                            query = query.Where(rp => rp.Receiving != null && rp.Receiving.Shipper.Contains(request.Shipper));
                        }

                        if (request.ProductId.HasValue)
                        {
                            query = query.Where(rp => rp.ProductId == request.ProductId.Value);
                        }

                        var receivedProducts = await query.ToListAsync();

                        // 2. Fetch Picked Quantities to calculate active on-hand stock
                        var receivedProductIds = receivedProducts.Select(rp => rp.Id).ToList();
                        var pickedDict = await backgroundDb.PickedProducts
                            .AsNoTracking()
                            .Where(pp => receivedProductIds.Contains(pp.ReceivedProductId))
                            .GroupBy(pp => pp.ReceivedProductId)
                            .Select(g => new { ReceivedProductId = g.Key, TotalPicked = g.Sum(pp => pp.QuantityPicked) })
                            .ToDictionaryAsync(x => x.ReceivedProductId, x => x.TotalPicked);

                        var today = DateTime.UtcNow.Date;

                        // 3. Process Aging & Map Flat DTOs
                        var items = receivedProducts.Select(rp =>
                        {
                            int originalQty = rp.ExpectedQuantity.HasValue && rp.ExpectedQuantity > 0
                                ? rp.ExpectedQuantity.Value
                                : rp.Quantity;
                            int pickedQty = pickedDict.TryGetValue(rp.Id, out int picked) ? picked : 0;
                            int remainingQty = Math.Max(0, originalQty - pickedQty);

                            DateTime receivedDate = rp.Receiving?.DateReceived ?? rp.Receiving?.DateAdded ?? DateTime.UtcNow;
                            int ageInDays = Math.Max(0, (today - receivedDate.Date).Days);

                            string bucket = ageInDays switch
                            {
                                <= 30 => "0 - 30 Days",
                                <= 60 => "31 - 60 Days",
                                <= 90 => "61 - 90 Days",
                                <= 180 => "91 - 180 Days",
                                _ => "180+ Days"
                            };

                            var bin = rp.CheckIns.SelectMany(ci => ci.Bins).FirstOrDefault();
                            string location = "UNASSIGNED";
                            if (bin != null)
                            {
                                string rackName = bin.Rack?.Name ?? "N/A";
                                string bayStr = bin.Bay != null ? $"Bay{bin.Bay.BayNumber}" : "N/A";
                                string levelStr = bin.Level != null ? $"Level{bin.Level.LevelNumber}" : "N/A";
                                string binName = bin.BinNames?.BinName ?? $"Bin#{bin.Id}";
                                location = $"{rackName}/{bayStr}/{levelStr}/{binName}";
                            }

                            return new AgingItemDto(
                                ProductCode: rp.Product?.Code ?? "N/A",
                                ProductName: rp.Product?.Name ?? rp.ExpectedProductName ?? "N/A",
                                Shipper: rp.Receiving?.Shipper ?? "UNASSIGNED",
                                WarehouseName: rp.Receiving?.Warehouse?.Name ?? (request.WarehouseId.HasValue ? $"Warehouse #{request.WarehouseId}" : "ALL"),
                                Location: location,
                                DateReceived: receivedDate,
                                AgeInDays: ageInDays,
                                AgingBucket: bucket,
                                RemainingQuantity: remainingQty,
                                Unit: rp.TypeOfPackage ?? "PCS"
                            );
                        })
                        .Where(x => x.RemainingQuantity > 0)
                        .OrderByDescending(x => x.AgeInDays)
                        .ToList();

                        var warehouse = request.WarehouseId.HasValue
                            ? await backgroundDb.Warehouses
                                .AsNoTracking()
                                .FirstOrDefaultAsync(w => w.Id == request.WarehouseId.Value)
                            : null;

                        string warehouseDisplayName = warehouse?.Name
                            ?? (request.WarehouseId.HasValue ? $"Warehouse #{request.WarehouseId.Value}" : "ALL");

                        // 4. Generate Excel Workbook with Tabs Grouped by Shipper
                        using var workbook = new XLWorkbook();

                        if (!items.Any())
                        {
                            // Single tab for empty state
                            AddAgingSheet(workbook, "Summary", new List<AgingItemDto>(), warehouseDisplayName, jobNumber, request.Shipper);
                        }
                        else
                        {
                            // TAB 1: Consolidated Overview across all Shippers
                            AddAgingSheet(workbook, "All Shippers", items, warehouseDisplayName, jobNumber, request.Shipper);

                            // TAB 2+: Group items into separate tabs per Shipper
                            var shipperGroups = items
                                .GroupBy(x => string.IsNullOrWhiteSpace(x.Shipper) ? "UNASSIGNED" : x.Shipper)
                                .OrderBy(g => g.Key);

                            var usedSheetNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "All Shippers", "Summary" };

                            foreach (var group in shipperGroups)
                            {
                                string rawShipperName = group.Key;
                                string sheetName = SanitizeSheetName(rawShipperName);

                                // Ensure unique sheet tab names
                                int counter = 1;
                                string baseName = sheetName;
                                while (usedSheetNames.Contains(sheetName))
                                {
                                    string suffix = $"_{counter++}";
                                    sheetName = $"{baseName.Substring(0, Math.Min(31 - suffix.Length, baseName.Length))}{suffix}";
                                }
                                usedSheetNames.Add(sheetName);

                                AddAgingSheet(workbook, sheetName, group.ToList(), warehouseDisplayName, jobNumber, rawShipperName);
                            }
                        }

                        // 5. Save Excel File
                        string reportsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "InventoryAging");
                        if (!Directory.Exists(reportsDirectory)) Directory.CreateDirectory(reportsDirectory);

                        string fileName = $"{jobNumber}.xlsx";
                        string fullPath = Path.Combine(reportsDirectory, fileName);
                        workbook.SaveAs(fullPath);

                        var completedJob = await backgroundDb.ReportJobs.FindAsync(jobId);
                        if (completedJob != null)
                        {
                            completedJob.Status = ReportStatus.Completed;
                            completedJob.FilePath = Path.Combine("Reports", "InventoryAging", fileName);
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
            .WithName("GenerateInventoryAgingReport")
            .WithSummary("Triggers an async job to generate an Excel report for Inventory Aging");

            // -----------------------------------------------------------------------------
            // GET /reports/inventory-aging/download/{id:int} - Download Report File
            // -----------------------------------------------------------------------------
            group.MapGet("/inventory-aging/download/{id:int}", async (
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
            .WithName("DownloadInventoryAgingReport")
            .WithSummary("Downloads the generated inventory aging report file");

            return group;
        }

        // -----------------------------------------------------------------------------
        // Helper to Render an Individual Aging Sheet Tab
        // -----------------------------------------------------------------------------
        private static void AddAgingSheet(
            XLWorkbook workbook,
            string sheetName,
            List<AgingItemDto> items,
            string warehouseDisplayName,
            string jobNumber,
            string? shipperNameFilter = null)
        {
            var ws = workbook.Worksheets.Add(sheetName);

            int totalOnHand = items.Sum(x => x.RemainingQuantity);
            int qty0to30 = items.Where(x => x.AgingBucket == "0 - 30 Days").Sum(x => x.RemainingQuantity);
            int qty31to60 = items.Where(x => x.AgingBucket == "31 - 60 Days").Sum(x => x.RemainingQuantity);
            int qty61to90 = items.Where(x => x.AgingBucket == "61 - 90 Days").Sum(x => x.RemainingQuantity);
            int qty91to180 = items.Where(x => x.AgingBucket == "91 - 180 Days").Sum(x => x.RemainingQuantity);
            int qty180Plus = items.Where(x => x.AgingBucket == "180+ Days").Sum(x => x.RemainingQuantity);

            // TITLE & FILTERS METADATA
            ws.Cell("A1").Value = "INVENTORY AGING REPORT";
            ws.Range("A1:J1").Merge()
                .Style.Font.SetBold().Font.SetFontSize(15)
                .Fill.SetBackgroundColor(XLColor.FromHtml("#1E293B"))
                .Font.SetFontColor(XLColor.White)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            ws.Cell("A3").Value = "Job Number:";
            ws.Cell("B3").Value = jobNumber;

            ws.Cell("A4").Value = "Date Generated:";
            ws.Cell("B4").Value = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(8)).ToString("yyyy-MM-dd hh:mm tt 'PST'");

            ws.Cell("A5").Value = "Warehouse Filter:";
            ws.Cell("B5").Value = warehouseDisplayName;

            ws.Cell("A6").Value = "Shipper Filter:";
            ws.Cell("B6").Value = !string.IsNullOrWhiteSpace(shipperNameFilter) ? shipperNameFilter : "ALL";

            ws.Range("A3:A6").Style.Font.SetBold();

            // SUMMARY BUCKETS BOX
            ws.Cell("G3").Value = "0-30 Days:";
            ws.Cell("H3").Value = qty0to30;

            ws.Cell("G4").Value = "31-60 Days:";
            ws.Cell("H4").Value = qty31to60;

            ws.Cell("G5").Value = "61-90 Days:";
            ws.Cell("H5").Value = qty61to90;

            ws.Cell("I3").Value = "91-180 Days:";
            ws.Cell("J3").Value = qty91to180;

            ws.Cell("I4").Value = "180+ Days (Critical):";
            ws.Cell("J4").Value = qty180Plus;

            ws.Cell("I5").Value = "Total On-Hand Qty:";
            ws.Cell("J5").Value = totalOnHand;

            ws.Range("G3:G5").Style.Font.SetBold();
            ws.Range("I3:I5").Style.Font.SetBold();
            ws.Range("G3:J5").Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
            ws.Cell("J4").Style.Font.SetFontColor(qty180Plus > 0 ? XLColor.Red : XLColor.Black).Font.SetBold();
            ws.Cell("J5").Style.Font.SetFontColor(XLColor.FromHtml("#0284C7")).Font.SetBold();

            int currentRow = 9;

            // ITEMIZED DETAILS TABLE
            ws.Cell(currentRow, 1).Value = $"ITEMIZED AGING INVENTORY ({sheetName.ToUpper()})";
            ws.Range(currentRow, 1, currentRow, 10).Merge()
                .Style.Font.SetBold().Font.SetFontSize(12)
                .Fill.SetBackgroundColor(XLColor.FromHtml("#0284C7"))
                .Font.SetFontColor(XLColor.White);
            currentRow++;

            string[] headers = {
                "Product Code", "Product Name", "Shipper", "Warehouse", "Bin Location",
                "Received Date", "Days in Warehouse", "Aging Bucket", "On-Hand Qty", "UOM"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(currentRow, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
            }
            currentRow++;

            if (!items.Any())
            {
                ws.Cell(currentRow, 1).Value = "No active on-hand inventory found for the selected parameters.";
                ws.Range(currentRow, 1, currentRow, 10).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            }
            else
            {
                foreach (var item in items)
                {
                    ws.Cell(currentRow, 1).Value = SanitizeXml(item.ProductCode);
                    ws.Cell(currentRow, 2).Value = SanitizeXml(item.ProductName);
                    ws.Cell(currentRow, 3).Value = SanitizeXml(item.Shipper);
                    ws.Cell(currentRow, 4).Value = SanitizeXml(item.WarehouseName);
                    ws.Cell(currentRow, 5).Value = SanitizeXml(item.Location);
                    ws.Cell(currentRow, 6).Value = item.DateReceived.ToString("yyyy-MM-dd");
                    ws.Cell(currentRow, 7).Value = item.AgeInDays;
                    ws.Cell(currentRow, 8).Value = item.AgingBucket;
                    ws.Cell(currentRow, 9).Value = item.RemainingQuantity;
                    ws.Cell(currentRow, 10).Value = SanitizeXml(item.Unit);

                    if (item.AgeInDays > 180)
                    {
                        ws.Cell(currentRow, 8).Style.Font.SetFontColor(XLColor.Red).Font.SetBold();
                    }
                    else if (item.AgeInDays > 90)
                    {
                        ws.Cell(currentRow, 8).Style.Font.SetFontColor(XLColor.Amber).Font.SetBold();
                    }

                    currentRow++;
                }
            }

            ws.Columns().AdjustToContents();
        }

        private static string SanitizeSheetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "Unassigned";
            var invalidChars = new[] { '\\', '/', '?', '*', ':', '[', ']' };
            foreach (var ch in invalidChars)
            {
                name = name.Replace(ch, '_');
            }
            name = SanitizeXml(name);
            return name.Length > 30 ? name.Substring(0, 30) : name;
        }

        private static string SanitizeXml(string? input) =>
            string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, @"[\x00-\x08\x0B\x0C\x0E-\x1F\x7F]", string.Empty);
    }
}