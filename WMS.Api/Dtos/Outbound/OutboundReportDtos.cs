namespace WMS.Api.Dtos.Outbound
{
    public record DispatchManifestReportDto(
        int LoadingPlanId,
        string LoadingReference,
        string WarehouseName,
        string Status,
        string? CustomerName,
        string? ShipperName,
        string? ConsigneeName,
        string? Destination,
        TransportDetailsDto Transport,
        PersonnelDetailsDto Personnel,
        LoadingTimestampsDto Timestamps,
        int TotalQuantityPlanned,
        int TotalQuantityLoaded,
        double FulfillmentRatePercentage,
        List<DispatchManifestLineDto> Lines
    );

    public record TransportDetailsDto(
        string? VehiclePlateNumber,
        string? TrailerPlateNumber,
        string? ContainerNumber,
        string? ContainerType,
        string? SealNumber
    );

    public record PersonnelDetailsDto(Guid? SupervisorUserId, Guid? LoaderUserId);

    public record LoadingTimestampsDto(
        DateTime? ScheduledDate,
        DateTime? PlannedStartAt,
        DateTime? ActualStartAt,
        DateTime? CompletedAt,
        double? DurationMinutes
    );

    public record DispatchManifestLineDto(
        int LineId,
        int? OutboundStageId,
        int? PickedProductId,
        string ProductName,
        string ProductCode,
        int? OriginalPalletId,
        int QuantityPlanned,
        int QuantityLoaded,
        int RemainingQuantity,
        string Status
    );

    // 2. Dock Turnaround
    public record DockTurnaroundReportDto(
        int Id,
        string LoadingReference,
        string? VehiclePlateNumber,
        string? ContainerNumber,
        DateTime? ScheduledDate,
        DateTime? PlannedStartAt,
        DateTime? ActualStartAt,
        DateTime? CompletedAt,
        double? StartDelayMinutes,
        double NetTurnaroundMinutes,
        int TotalUnitsLoaded,
        int TotalPalletsCount,
        double UnitsPerHour,
        Guid? SupervisorUserId,
        Guid? LoaderUserId
    );

    // 3. Staging Velocity
    public record StagingVelocityReportDto(
        int StageId,
        string StageReference,
        int ManualPickingId,
        int WarehouseId,
        int? StagingBinId,
        string Status,
        DateTime RequestedAt,
        DateTime? StartedAt,
        DateTime? CompletedAt,
        double? StagingDurationMinutes,
        int TotalRequested,
        int TotalStaged,
        double StagingAccuracyRate,
        int LineCount,
        Guid? RequestedByUserId,
        Guid? VerifiedByUserId
    );

    // 4. Pallet Verifications
    public record PalletVerificationReportSummaryDto(
        int TotalScans,
        int AuthorizedCount,
        int DiscrepancyCount,
        double ErrorRatePercentage,
        List<PalletVerificationLogDto> Verifications
    );

    public record PalletVerificationLogDto(
        int Id,
        int LoadingPlanId,
        string LoadingReference,
        int PalletId,
        string ScanResult,
        Guid? ScannedByUserId,
        DateTime ScanTime,
        string? Remarks,
        bool IsDiscrepancy
    );

    // 5. Exceptions Log
    public record LoadingExceptionReportDto(
        int ExceptionId,
        int LoadingPlanId,
        string LoadingReference,
        string ExceptionType,
        string Severity,
        string? Description,
        int? PalletId,
        int? LoadingPlanLineId,
        string AffectedProduct,
        Guid? ApprovedByUserId,
        DateTime CreatedAt
    );

    // 6. Chain of Custody (Evidence)
    public record EvidenceComplianceSummaryDto(
        int TotalCompletedPlans,
        int CompliantCount,
        int NonCompliantCount,
        double ComplianceRate,
        List<EvidenceCompliancePlanDto> Plans
    );

    public record EvidenceCompliancePlanDto(
        int Id,
        string LoadingReference,
        string? VehiclePlateNumber,
        string? ContainerNumber,
        string? SealNumber,
        DateTime? CompletedAt,
        List<EvidenceDetailDto> EvidenceCaptured,
        bool HasVehicleInspection,
        bool HasLoadingStart,
        bool HasSealCheck,
        bool HasFinalDispatch,
        bool IsAuditCompliant
    );

    public record EvidenceDetailDto(
        string EvidenceType,
        string FileName,
        string StoredPath,
        Guid? UploadedByUserId,
        DateTime UploadedAt
    );

    // 7. Cancellations & Returns
    public record CancellationReturnReportDto(
        int CancellationId,
        string CancellationReference,
        int StageId,
        string StageReference,
        string Status,
        string? Reason,
        Guid? RequestedByUserId,
        Guid? ApprovedByUserId,
        DateTime RequestedAt,
        DateTime? ApprovedAt,
        DateTime? CompletedAt,
        int TotalUnitsCancelled,
        int TotalLinesReturned,
        int TotalLinesPending,
        int TotalLinesException,
        List<CancellationReturnLineDto> Lines
    );

    public record CancellationReturnLineDto(
        int Id,
        int OutboundStageLineId,
        int QuantityCancelled,
        int OriginalBinHashCode,
        int ReturnBinHashCode,
        string Status,
        string? ExceptionReason,
        DateTime CreatedAt
    );

    // 8. Workforce Productivity
    public record WorkforceProductivityReportDto(
        List<LoaderStatsDto> Loaders,
        List<StagingOperatorStatsDto> StagingOperators,
        List<ScannerStatsDto> PalletScanners
    );

    public record LoaderStatsDto(Guid UserId, string Role, int PlansAssigned, int PlansCompleted, int TotalUnitsLoaded);
    public record StagingOperatorStatsDto(Guid UserId, string Role, int LinesProcessed, int LinesStaged, int TotalUnitsStaged);
    public record ScannerStatsDto(Guid UserId, int TotalScans, int AuthorizedScans, int MismatchesFlagged);
}
