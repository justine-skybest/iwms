namespace WMS.Api.Entities;

public enum OutboundStageStatus
{
    Pending = 1,
    InProgress,
    Completed,
    Partial,
    Cancelled,
    CancellationRequested
}

public enum OutboundStageLineStatus
{
    Pending = 1,
    Staged,
    Cancelled,
    Exception
}

public enum OutboundStageCancellationStatus
{
    Requested = 1,
    Approved,
    Rejected,
    Completed
}

public enum LoadingStatus
{
    Planned = 1,
    Assigned,
    InProgress,
    Partial,
    Completed,
    Cancelled,
    Rejected
}

public enum LoadingScanResult
{
    Authorized = 1,
    Duplicate,
    Unauthorized,
    Missing,
    Damaged,
    Rejected
}

public enum LoadingEvidenceType
{
    LoadingStart = 1,
    SealCheck,
    VehicleInspection,
    Damage,
    FinalDispatch
}

public enum LoadingExceptionType
{
    MissingPallet = 1,
    DamagedItem,
    UnauthorizedPallet,
    WrongVehicle,
    SealMismatch,
    QuantityOverflow
}

public class OutboundStage
{
    public int Id { get; set; }

    public int ManualPickingId { get; set; }

    public ManualPicking? ManualPicking { get; set; }

    public int WarehouseId { get; set; }

    public Warehouse? Warehouse { get; set; }

    public int? StagingBinId { get; set; }

    public Bin? StagingBin { get; set; }

    public required string StageReference { get; set; }

    public OutboundStageStatus Status { get; set; } = OutboundStageStatus.Pending;

    public Guid? RequestedByUserId { get; set; }

    public Guid? VerifiedByUserId { get; set; }

    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

    public DateTime? StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<OutboundStageLine> Lines { get; set; } = new List<OutboundStageLine>();

    public ICollection<OutboundStageCancellation> Cancellations { get; set; } = new List<OutboundStageCancellation>();
}

public class OutboundStageLine
{
    public int Id { get; set; }

    public int OutboundStageId { get; set; }

    public OutboundStage? OutboundStage { get; set; }

    public int PickedProductId { get; set; }

    public PickedProduct? PickedProduct { get; set; }

    public int ReceivedProductId { get; set; }

    public ReceivedProduct? ReceivedProduct { get; set; }

    public int? OriginalBinId { get; set; }

    public Bin? OriginalBin { get; set; }

    public int? OriginalPalletId { get; set; }

    public Pallet? OriginalPallet { get; set; }

    public int? StagingBinId { get; set; }

    public Bin? StagingBin { get; set; }

    public int QuantityToStage { get; set; }

    public int QuantityStaged { get; set; }

    public OutboundStageLineStatus Status { get; set; } = OutboundStageLineStatus.Pending;

    public Guid? OperatorUserId { get; set; }

    public DateTime? ConfirmedAt { get; set; }

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class OutboundStageCancellation
{
    public int Id { get; set; }

    public int OutboundStageId { get; set; }

    public OutboundStage? OutboundStage { get; set; }

    public required string CancellationReference { get; set; }

    public OutboundStageCancellationStatus Status { get; set; } = OutboundStageCancellationStatus.Requested;

    public Guid? RequestedByUserId { get; set; }

    public Guid? ApprovedByUserId { get; set; }

    public string? Reason { get; set; }

    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ApprovedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public ICollection<OutboundStageCancellationLine> Lines { get; set; } = new List<OutboundStageCancellationLine>();
}

public class OutboundStageCancellationLine
{
    public int Id { get; set; }

    public int OutboundStageCancellationId { get; set; }

    public OutboundStageCancellation? OutboundStageCancellation { get; set; }

    public int OutboundStageLineId { get; set; }

    public OutboundStageLine? OutboundStageLine { get; set; }

    public int QuantityCancelled { get; set; }

    public int? OriginalBinId { get; set; }

    public Bin? OriginalBin { get; set; }

    public int? ReturnBinId { get; set; }

    public Bin? ReturnBin { get; set; }

    public string Status { get; set; } = "PendingReturn";

    public string? ExceptionReason { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class LoadingPlan
{
    public int Id { get; set; }

    public int WarehouseId { get; set; }

    public Warehouse? Warehouse { get; set; }

    public required string LoadingReference { get; set; }

    public string? CustomerName { get; set; }

    public string? ShipperName { get; set; }

    public string? ConsigneeName { get; set; }

    public string? Destination { get; set; }

    public string? VehiclePlateNumber { get; set; }

    public string? TrailerPlateNumber { get; set; }

    public string? ContainerNumber { get; set; }

    public string? ContainerType { get; set; }

    public string? SealNumber { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public DateTime? PlannedStartAt { get; set; }

    public DateTime? ActualStartAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public Guid? SupervisorUserId { get; set; }

    public Guid? LoaderUserId { get; set; }

    public LoadingStatus Status { get; set; } = LoadingStatus.Planned;

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<LoadingPlanLine> Lines { get; set; } = new List<LoadingPlanLine>();

    public ICollection<LoadingPalletVerification> PalletVerifications { get; set; } = new List<LoadingPalletVerification>();

    public ICollection<LoadingEvidence> Evidence { get; set; } = new List<LoadingEvidence>();

    public ICollection<LoadingException> Exceptions { get; set; } = new List<LoadingException>();
}

public class LoadingPlanLine
{
    public int Id { get; set; }

    public int LoadingPlanId { get; set; }

    public LoadingPlan? LoadingPlan { get; set; }

    public int? OutboundStageId { get; set; }

    public OutboundStage? OutboundStage { get; set; }

    public int? OutboundStageLineId { get; set; }

    public OutboundStageLine? OutboundStageLine { get; set; }

    public int? PickedProductId { get; set; }

    public PickedProduct? PickedProduct { get; set; }

    public int? OriginalPalletId { get; set; }

    public Pallet? OriginalPallet { get; set; }

    public int QuantityPlanned { get; set; }

    public int QuantityLoaded { get; set; }

    public int RemainingQuantity => Math.Max(QuantityPlanned - QuantityLoaded, 0);

    public string Status { get; set; } = "Planned";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class LoadingPalletVerification
{
    public int Id { get; set; }

    public int LoadingPlanId { get; set; }

    public LoadingPlan? LoadingPlan { get; set; }

    public int PalletId { get; set; }

    public Pallet? Pallet { get; set; }

    public Guid? ScannedByUserId { get; set; }

    public DateTime ScanTime { get; set; } = DateTime.UtcNow;

    public LoadingScanResult ScanResult { get; set; } = LoadingScanResult.Authorized;

    public string? Remarks { get; set; }
}

public class LoadingEvidence
{
    public int Id { get; set; }

    public int LoadingPlanId { get; set; }

    public LoadingPlan? LoadingPlan { get; set; }

    public LoadingEvidenceType EvidenceType { get; set; }

    public required string FileName { get; set; }

    public required string StoredPath { get; set; }

    public string? MimeType { get; set; }

    public Guid? UploadedByUserId { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}

public class LoadingException
{
    public int Id { get; set; }

    public int LoadingPlanId { get; set; }

    public LoadingPlan? LoadingPlan { get; set; }

    public int? PalletId { get; set; }

    public Pallet? Pallet { get; set; }

    public int? LoadingPlanLineId { get; set; }

    public LoadingPlanLine? LoadingPlanLine { get; set; }

    public LoadingExceptionType ExceptionType { get; set; }

    public string? Description { get; set; }

    public string Severity { get; set; } = "Medium";

    public Guid? ApprovedByUserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
