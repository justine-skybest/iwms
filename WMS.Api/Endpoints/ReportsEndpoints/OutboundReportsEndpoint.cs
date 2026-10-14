using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Outbound;
using WMS.Api.Entities;
using WMS.Api.Services;

namespace WMS.Api.Endpoints.ReportsEndpoints;

public static class OutboundReportsEndpoint
{
    public static RouteGroupBuilder MapOutboundReportsEndpoints(this RouteGroupBuilder app)
    {
        var group = app.MapGroup("outbound/reports").WithTags("Outbound Reports");

        // -----------------------------------------------------------------------------
        // 1. Dispatch Manifest & Loading Summary
        // -----------------------------------------------------------------------------
        group.MapGet("/dispatch-manifest", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int? warehouseId,
            [FromQuery] LoadingStatus? status,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.LoadingPlans
                .AsNoTracking()
                .Include(p => p.Warehouse)
                .Include(p => p.Lines)
                    .ThenInclude(l => l.PickedProduct)
                        .ThenInclude(pp => pp!.ReceivedProduct)
                            .ThenInclude(rp => rp!.Product)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(p => p.CompletedAt >= fromDate.Value || p.CreatedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(p => p.CompletedAt <= toDate.Value || p.CreatedAt <= toDate.Value);
            if (warehouseId.HasValue) query = query.Where(p => p.WarehouseId == warehouseId.Value);
            if (status.HasValue) query = query.Where(p => p.Status == status.Value);

            // Fetch entity graph first to avoid SQL DateTime - DateTime coercion errors
            var plans = await query
                .OrderByDescending(p => p.CompletedAt ?? p.CreatedAt)
                .ToListAsync(cancellationToken);

            var result = plans.Select(p => new DispatchManifestReportDto(
                p.Id,
                p.LoadingReference,
                p.Warehouse != null ? p.Warehouse.Name : "N/A",
                p.Status.ToString(),
                p.CustomerName,
                p.ShipperName,
                p.ConsigneeName,
                p.Destination,
                new TransportDetailsDto(
                    p.VehiclePlateNumber,
                    p.TrailerPlateNumber,
                    p.ContainerNumber,
                    p.ContainerType,
                    p.SealNumber
                ),
                new PersonnelDetailsDto(
                    p.SupervisorUserId,
                    p.LoaderUserId
                ),
                new LoadingTimestampsDto(
                    p.ScheduledDate,
                    p.PlannedStartAt,
                    p.ActualStartAt,
                    p.CompletedAt,
                    p.ActualStartAt.HasValue && p.CompletedAt.HasValue
                        ? Math.Round((p.CompletedAt.Value - p.ActualStartAt.Value).TotalMinutes, 2)
                        : null
                ),
                p.Lines.Sum(l => l.QuantityPlanned),
                p.Lines.Sum(l => l.QuantityLoaded),
                p.Lines.Sum(l => l.QuantityPlanned) > 0
                    ? Math.Round(((double)p.Lines.Sum(l => l.QuantityLoaded) / p.Lines.Sum(l => l.QuantityPlanned)) * 100, 2)
                    : 0,
                p.Lines.Select(l => new DispatchManifestLineDto(
                    l.Id,
                    l.OutboundStageId,
                    l.PickedProductId,
                    l.PickedProduct?.ReceivedProduct?.Product?.Name ?? "N/A",
                    l.PickedProduct?.ReceivedProduct?.Product?.Code ?? "N/A",
                    l.OriginalPalletId,
                    l.QuantityPlanned,
                    l.QuantityLoaded,
                    l.RemainingQuantity,
                    l.Status
                )).ToList()
            )).ToList();

            return Results.Ok(result);
        })
        .WithSummary("Outbound dispatch manifest & cargo loading summary")
        .Produces<List<DispatchManifestReportDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // 2. Dock Turnaround & Carrier Adherence Report
        // -----------------------------------------------------------------------------
        group.MapGet("/dock-turnaround", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int? warehouseId,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.LoadingPlans
                .AsNoTracking()
                .Include(p => p.Lines)
                .Where(p => p.ActualStartAt.HasValue && p.CompletedAt.HasValue)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(p => p.CompletedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(p => p.CompletedAt <= toDate.Value);
            if (warehouseId.HasValue) query = query.Where(p => p.WarehouseId == warehouseId.Value);

            var plans = await query
                .OrderByDescending(p => p.CompletedAt)
                .ToListAsync(cancellationToken);

            var result = plans.Select(p =>
            {
                var netMinutes = Math.Round((p.CompletedAt!.Value - p.ActualStartAt!.Value).TotalMinutes, 2);
                var netHours = (p.CompletedAt!.Value - p.ActualStartAt!.Value).TotalHours;
                var totalLoaded = p.Lines.Sum(l => l.QuantityLoaded);

                return new DockTurnaroundReportDto(
                    p.Id,
                    p.LoadingReference,
                    p.VehiclePlateNumber,
                    p.ContainerNumber,
                    p.ScheduledDate,
                    p.PlannedStartAt,
                    p.ActualStartAt,
                    p.CompletedAt,
                    p.PlannedStartAt.HasValue && p.ActualStartAt.HasValue
                        ? Math.Round((p.ActualStartAt.Value - p.PlannedStartAt.Value).TotalMinutes, 2)
                        : null,
                    netMinutes,
                    totalLoaded,
                    p.Lines.Select(l => l.OriginalPalletId).Distinct().Count(),
                    netHours > 0 ? Math.Round(totalLoaded / netHours, 1) : 0,
                    p.SupervisorUserId,
                    p.LoaderUserId
                );
            }).ToList();

            return Results.Ok(result);
        })
        .WithSummary("Dock turnaround times and carrier loading throughput")
        .Produces<List<DockTurnaroundReportDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // 3. Staging-to-Loading Velocity & Dwell Time Analysis
        // -----------------------------------------------------------------------------
        group.MapGet("/staging-velocity", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int? warehouseId,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.OutboundStages
                .AsNoTracking()
                .Include(s => s.Lines)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(s => s.CreatedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(s => s.CreatedAt <= toDate.Value);
            if (warehouseId.HasValue) query = query.Where(s => s.WarehouseId == warehouseId.Value);

            var stages = await query
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync(cancellationToken);

            var result = stages.Select(s => new StagingVelocityReportDto(
                s.Id,
                s.StageReference,
                s.ManualPickingId,
                s.WarehouseId,
                s.StagingBinId,
                s.Status.ToString(),
                s.RequestedAt,
                s.StartedAt,
                s.CompletedAt,
                s.StartedAt.HasValue && s.CompletedAt.HasValue
                    ? Math.Round((s.CompletedAt.Value - s.StartedAt.Value).TotalMinutes, 2)
                    : null,
                s.Lines.Sum(l => l.QuantityToStage),
                s.Lines.Sum(l => l.QuantityStaged),
                s.Lines.Sum(l => l.QuantityToStage) > 0
                    ? Math.Round(((double)s.Lines.Sum(l => l.QuantityStaged) / s.Lines.Sum(l => l.QuantityToStage)) * 100, 2)
                    : 0,
                s.Lines.Count,
                s.RequestedByUserId,
                s.VerifiedByUserId
            )).ToList();

            return Results.Ok(result);
        })
        .WithSummary("Staging dwell time and staging velocity")
        .Produces<List<StagingVelocityReportDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // 4. Loading Pallet Verification & Scan Discrepancy Log
        // -----------------------------------------------------------------------------
        group.MapGet("/pallet-verifications", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] LoadingScanResult? scanResult,
            [FromQuery] int? loadingPlanId,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.LoadingPalletVerifications
                .AsNoTracking()
                .Include(v => v.LoadingPlan)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(v => v.ScanTime >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(v => v.ScanTime <= toDate.Value);
            if (scanResult.HasValue) query = query.Where(v => v.ScanResult == scanResult.Value);
            if (loadingPlanId.HasValue) query = query.Where(v => v.LoadingPlanId == loadingPlanId.Value);

            var logs = await query
                .OrderByDescending(v => v.ScanTime)
                .Select(v => new PalletVerificationLogDto(
                    v.Id,
                    v.LoadingPlanId,
                    v.LoadingPlan != null ? v.LoadingPlan.LoadingReference : "N/A",
                    v.PalletId,
                    v.ScanResult.ToString(),
                    v.ScannedByUserId,
                    v.ScanTime,
                    v.Remarks,
                    v.ScanResult != LoadingScanResult.Authorized
                ))
                .ToListAsync(cancellationToken);

            var summary = new PalletVerificationReportSummaryDto(
                logs.Count,
                logs.Count(l => l.ScanResult == LoadingScanResult.Authorized.ToString()),
                logs.Count(l => l.IsDiscrepancy),
                logs.Count > 0 ? Math.Round(((double)logs.Count(l => l.IsDiscrepancy) / logs.Count) * 100, 2) : 0,
                logs
            );

            return Results.Ok(summary);
        })
        .WithSummary("Audit log of pallet scans, duplicate warnings, and unassigned attempts")
        .Produces<PalletVerificationReportSummaryDto>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // 5. Outbound Exceptions & Severity Log
        // -----------------------------------------------------------------------------
        group.MapGet("/exceptions", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] string? severity,
            [FromQuery] LoadingExceptionType? exceptionType,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.LoadingExceptions
                .AsNoTracking()
                .Include(e => e.LoadingPlan)
                .Include(e => e.LoadingPlanLine)
                    .ThenInclude(l => l!.PickedProduct)
                        .ThenInclude(pp => pp!.ReceivedProduct)
                            .ThenInclude(rp => rp!.Product)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(e => e.CreatedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(e => e.CreatedAt <= toDate.Value);
            if (!string.IsNullOrWhiteSpace(severity)) query = query.Where(e => e.Severity == severity.Trim());
            if (exceptionType.HasValue) query = query.Where(e => e.ExceptionType == exceptionType.Value);

            var exceptions = await query
                .OrderByDescending(e => e.CreatedAt)
                .Select(e => new LoadingExceptionReportDto(
                    e.Id,
                    e.LoadingPlanId,
                    e.LoadingPlan != null ? e.LoadingPlan.LoadingReference : "N/A",
                    e.ExceptionType.ToString(),
                    e.Severity,
                    e.Description,
                    e.PalletId,
                    e.LoadingPlanLineId,
                    e.LoadingPlanLine != null
                        && e.LoadingPlanLine.PickedProduct != null
                        && e.LoadingPlanLine.PickedProduct.ReceivedProduct != null
                        && e.LoadingPlanLine.PickedProduct.ReceivedProduct.Product != null
                        ? e.LoadingPlanLine.PickedProduct.ReceivedProduct.Product.Name : "N/A",
                    e.ApprovedByUserId,
                    e.CreatedAt
                ))
                .ToListAsync(cancellationToken);

            return Results.Ok(exceptions);
        })
        .WithSummary("Warehouse loading exceptions, damages, seal mismatches, and severities")
        .Produces<List<LoadingExceptionReportDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // 6. Chain-of-Custody & Evidence Compliance Audit
        // -----------------------------------------------------------------------------
        group.MapGet("/evidence-compliance", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int? warehouseId,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.LoadingPlans
                .AsNoTracking()
                .Include(p => p.Evidence)
                .Where(p => p.Status == LoadingStatus.Completed)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(p => p.CompletedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(p => p.CompletedAt <= toDate.Value);
            if (warehouseId.HasValue) query = query.Where(p => p.WarehouseId == warehouseId.Value);

            var plans = await query
                .OrderByDescending(p => p.CompletedAt)
                .Select(p => new EvidenceCompliancePlanDto(
                    p.Id,
                    p.LoadingReference,
                    p.VehiclePlateNumber,
                    p.ContainerNumber,
                    p.SealNumber,
                    p.CompletedAt,
                    p.Evidence.Select(e => new EvidenceDetailDto(
                        e.EvidenceType.ToString(),
                        e.FileName,
                        e.StoredPath,
                        e.UploadedByUserId,
                        e.UploadedAt
                    )).ToList(),
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.VehicleInspection),
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.LoadingStart),
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.SealCheck),
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.FinalDispatch),
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.VehicleInspection) &&
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.LoadingStart) &&
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.SealCheck) &&
                    p.Evidence.Any(e => e.EvidenceType == LoadingEvidenceType.FinalDispatch)
                ))
                .ToListAsync(cancellationToken);

            var summary = new EvidenceComplianceSummaryDto(
                plans.Count,
                plans.Count(p => p.IsAuditCompliant),
                plans.Count(p => !p.IsAuditCompliant),
                plans.Count > 0 ? Math.Round(((double)plans.Count(p => p.IsAuditCompliant) / plans.Count) * 100, 2) : 0,
                plans
            );

            return Results.Ok(summary);
        })
        .WithSummary("Proof of shipment and photographic chain-of-custody compliance")
        .Produces<EvidenceComplianceSummaryDto>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // 7. Stage Cancellation & Return-to-Stock Audit
        // -----------------------------------------------------------------------------
        group.MapGet("/cancellations-returns", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] OutboundStageCancellationStatus? status,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.OutboundStageCancellations
                .AsNoTracking()
                .Include(c => c.OutboundStage)
                .Include(c => c.Lines)
                    .ThenInclude(l => l.OriginalBin)
                .Include(c => c.Lines)
                    .ThenInclude(l => l.ReturnBin)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(c => c.RequestedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(c => c.RequestedAt <= toDate.Value);
            if (status.HasValue) query = query.Where(c => c.Status == status.Value);

            var report = await query
                .OrderByDescending(c => c.RequestedAt)
                .Select(c => new CancellationReturnReportDto(
                    c.Id,
                    c.CancellationReference,
                    c.OutboundStageId,
                    c.OutboundStage != null ? c.OutboundStage.StageReference : "N/A",
                    c.Status.ToString(),
                    c.Reason,
                    c.RequestedByUserId,
                    c.ApprovedByUserId,
                    c.RequestedAt,
                    c.ApprovedAt,
                    c.CompletedAt,
                    c.Lines.Sum(l => l.QuantityCancelled),
                    c.Lines.Count(l => l.Status == "Returned"),
                    c.Lines.Count(l => l.Status == "PendingReturn"),
                    c.Lines.Count(l => l.Status == "Exception"),
                    c.Lines.Select(l => new CancellationReturnLineDto(
                        l.Id,
                        l.OutboundStageLineId,
                        l.QuantityCancelled,
                        l.OriginalBin != null ? l.OriginalBin.BinHashCode : 0,
                        l.ReturnBin != null ? l.ReturnBin.BinHashCode : 0,
                        l.Status,
                        l.ExceptionReason,
                        l.CreatedAt
                    )).ToList()
                ))
                .ToListAsync(cancellationToken);

            return Results.Ok(report);
        })
        .WithSummary("Track cancelled staging orders and return-to-bin stock movements")
        .Produces<List<CancellationReturnReportDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // 8. Workforce Productivity Scorecard
        // -----------------------------------------------------------------------------
        group.MapGet("/workforce-productivity", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var planQuery = dbContext.LoadingPlans.AsNoTracking().AsQueryable();
            var stageLineQuery = dbContext.OutboundStageLines.AsNoTracking().AsQueryable();
            var scanQuery = dbContext.LoadingPalletVerifications.AsNoTracking().AsQueryable();

            if (fromDate.HasValue)
            {
                planQuery = planQuery.Where(p => p.CompletedAt >= fromDate.Value || p.CreatedAt >= fromDate.Value);
                stageLineQuery = stageLineQuery.Where(sl => sl.ConfirmedAt >= fromDate.Value || sl.CreatedAt >= fromDate.Value);
                scanQuery = scanQuery.Where(s => s.ScanTime >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                planQuery = planQuery.Where(p => p.CompletedAt <= toDate.Value || p.CreatedAt <= toDate.Value);
                stageLineQuery = stageLineQuery.Where(sl => sl.ConfirmedAt <= toDate.Value || sl.CreatedAt <= toDate.Value);
                scanQuery = scanQuery.Where(s => s.ScanTime <= toDate.Value);
            }

            var loaderStats = await planQuery
                .Where(p => p.LoaderUserId.HasValue)
                .GroupBy(p => p.LoaderUserId!.Value)
                .Select(g => new LoaderStatsDto(
                    g.Key,
                    "Loader",
                    g.Count(),
                    g.Count(p => p.Status == LoadingStatus.Completed),
                    g.SelectMany(p => p.Lines).Sum(l => l.QuantityLoaded)
                ))
                .ToListAsync(cancellationToken);

            var operatorStats = await stageLineQuery
                .Where(sl => sl.OperatorUserId.HasValue)
                .GroupBy(sl => sl.OperatorUserId!.Value)
                .Select(g => new StagingOperatorStatsDto(
                    g.Key,
                    "StagingOperator",
                    g.Count(),
                    g.Count(l => l.Status == OutboundStageLineStatus.Staged),
                    g.Sum(l => l.QuantityStaged)
                ))
                .ToListAsync(cancellationToken);

            var scannerStats = await scanQuery
                .Where(s => s.ScannedByUserId.HasValue)
                .GroupBy(s => s.ScannedByUserId!.Value)
                .Select(g => new ScannerStatsDto(
                    g.Key,
                    g.Count(),
                    g.Count(s => s.ScanResult == LoadingScanResult.Authorized),
                    g.Count(s => s.ScanResult != LoadingScanResult.Authorized)
                ))
                .ToListAsync(cancellationToken);

            var result = new WorkforceProductivityReportDto(loaderStats, operatorStats, scannerStats);
            return Results.Ok(result);
        })
        .WithSummary("Workforce labor breakdown by loader, staging operator, and scanning activity")
        .Produces<WorkforceProductivityReportDto>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Export: Dispatch Manifest
        // -----------------------------------------------------------------------------
        group.MapGet("/dispatch-manifest/export", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int? warehouseId,
            [FromQuery] LoadingStatus? status,
            [FromQuery] ExportFormat format,
            WMSContext dbContext,
            IOutboundReportExportService exportService,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.LoadingPlans
                .AsNoTracking()
                .Include(p => p.Warehouse)
                .Include(p => p.Lines)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(p => p.CompletedAt >= fromDate.Value || p.CreatedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(p => p.CompletedAt <= toDate.Value || p.CreatedAt <= toDate.Value);
            if (warehouseId.HasValue) query = query.Where(p => p.WarehouseId == warehouseId.Value);
            if (status.HasValue) query = query.Where(p => p.Status == status.Value);

            var plans = await query
                .OrderByDescending(p => p.CompletedAt ?? p.CreatedAt)
                .ToListAsync(cancellationToken);

            var records = plans.Select(p => new
            {
                p.LoadingReference,
                WarehouseName = p.Warehouse != null ? p.Warehouse.Name : "N/A",
                Status = p.Status.ToString(),
                p.CustomerName,
                p.ShipperName,
                p.ConsigneeName,
                p.Destination,
                Transport = new
                {
                    p.VehiclePlateNumber,
                    p.TrailerPlateNumber,
                    p.ContainerNumber,
                    p.ContainerType,
                    p.SealNumber
                },
                Personnel = new
                {
                    p.SupervisorUserId,
                    p.LoaderUserId
                },
                Timestamps = new
                {
                    p.ScheduledDate,
                    p.PlannedStartAt,
                    p.ActualStartAt,
                    p.CompletedAt
                },
                TotalQuantityPlanned = p.Lines.Sum(l => l.QuantityPlanned),
                TotalQuantityLoaded = p.Lines.Sum(l => l.QuantityLoaded),
                FulfillmentRatePercentage = p.Lines.Sum(l => l.QuantityPlanned) > 0
                    ? Math.Round(((double)p.Lines.Sum(l => l.QuantityLoaded) / p.Lines.Sum(l => l.QuantityPlanned)) * 100, 2)
                    : 0
            }).ToList();

            var timeStamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");

            if (format == ExportFormat.Csv)
            {
                var flatCsvData = records.Select(r => new
                {
                    r.LoadingReference,
                    r.Status,
                    r.WarehouseName,
                    r.CustomerName,
                    r.Destination,
                    r.Transport.VehiclePlateNumber,
                    r.Transport.SealNumber,
                    r.TotalQuantityPlanned,
                    r.TotalQuantityLoaded,
                    r.FulfillmentRatePercentage,
                    CompletedAt = r.Timestamps.CompletedAt?.ToString("u")
                });

                var csvBytes = exportService.GenerateGenericCsv(flatCsvData);
                return Results.File(csvBytes, "text/csv", $"dispatch_manifest_{timeStamp}.csv");
            }

            var excelBytes = exportService.GenerateDispatchManifestExcel(records);
            return Results.File(
                excelBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"dispatch_manifest_{timeStamp}.xlsx"
            );
        })
        .WithSummary("Export Outbound Dispatch Manifest as formatted Excel or CSV");

        // -----------------------------------------------------------------------------
        // Export: Dock Turnaround
        // -----------------------------------------------------------------------------
        group.MapGet("/dock-turnaround/export", async (
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int? warehouseId,
            [FromQuery] ExportFormat format,
            WMSContext dbContext,
            IOutboundReportExportService exportService,
            CancellationToken cancellationToken) =>
        {
            var query = dbContext.LoadingPlans
                .AsNoTracking()
                .Include(p => p.Lines)
                .Where(p => p.ActualStartAt.HasValue && p.CompletedAt.HasValue)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(p => p.CompletedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(p => p.CompletedAt <= toDate.Value);
            if (warehouseId.HasValue) query = query.Where(p => p.WarehouseId == warehouseId.Value);

            var plans = await query
                .OrderByDescending(p => p.CompletedAt)
                .ToListAsync(cancellationToken);

            var records = plans.Select(p =>
            {
                var netMinutes = Math.Round((p.CompletedAt!.Value - p.ActualStartAt!.Value).TotalMinutes, 2);
                var netHours = (p.CompletedAt!.Value - p.ActualStartAt!.Value).TotalHours;
                var totalLoaded = p.Lines.Sum(l => l.QuantityLoaded);

                return new
                {
                    p.LoadingReference,
                    p.VehiclePlateNumber,
                    p.ContainerNumber,
                    p.ScheduledDate,
                    p.PlannedStartAt,
                    p.ActualStartAt,
                    p.CompletedAt,
                    StartDelayMinutes = p.PlannedStartAt.HasValue && p.ActualStartAt.HasValue
                        ? (double?)Math.Round((p.ActualStartAt.Value - p.PlannedStartAt.Value).TotalMinutes, 2)
                        : null,
                    NetTurnaroundMinutes = netMinutes,
                    TotalUnitsLoaded = totalLoaded,
                    TotalPalletsCount = p.Lines.Select(l => l.OriginalPalletId).Distinct().Count(),
                    UnitsPerHour = netHours > 0 ? Math.Round(totalLoaded / netHours, 1) : 0
                };
            }).ToList();

            var timeStamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");

            if (format == ExportFormat.Csv)
            {
                var csvBytes = exportService.GenerateGenericCsv(records);
                return Results.File(csvBytes, "text/csv", $"dock_turnaround_{timeStamp}.csv");
            }

            var excelBytes = exportService.GenerateTurnaroundExcel(records);
            return Results.File(
                excelBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"dock_turnaround_{timeStamp}.xlsx"
            );
        })
        .WithSummary("Export dock turnaround analysis as formatted Excel or CSV");

        return group;
    }
}