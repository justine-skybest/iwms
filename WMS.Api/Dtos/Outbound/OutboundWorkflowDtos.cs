using WMS.Api.Entities;

namespace WMS.Api.Dtos.Outbound;

public record RequestStageCancellationDto(
    string Reason,
    Guid? RequestedByUserId,
    List<StageCancellationLineItemDto>? Lines = null
);

public record StageCancellationLineItemDto(
    int OutboundStageLineId,
    int QuantityToCancel
);

public record ReviewStageCancellationDto(
    bool Approve,
    Guid? ReviewedByUserId,
    string? Remarks
);

public record ProcessReturnToBinItemDto(
    int CancellationLineId,
    int ReturnBinId,
    bool IsException = false,
    string? ExceptionReason = null
);

public record ProcessReturnToBinDto(
    List<ProcessReturnToBinItemDto> ReturnLines
);

public record RecordPalletVerificationDto(
    int PalletId,
    Guid? ScannedByUserId,
    LoadingScanResult ScanResult,
    string? Remarks
);

public record CreateOutboundStageLineDto(
    int PickedProductId,
    int ReceivedProductId,
    int? OriginalBinId,
    int? OriginalPalletId,
    int QuantityToStage,
    int? StagingBinId = null,
    string? Remarks = null
);

public record CreateOutboundStageDto(
    int ManualPickingId,
    int WarehouseId,
    int? StagingBinId,
    List<CreateOutboundStageLineDto> Lines,
    Guid? RequestedByUserId = null,
    string? Notes = null
);

public record OutboundStageLineDto(
    int Id,
    int PickedProductId,
    int ReceivedProductId,
    int? OriginalBinId,
    int? OriginalPalletId,
    int? StagingBinId,
    int QuantityToStage,
    int QuantityStaged,
    string Status,
    string? Remarks,
    string? ProductName,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record OutboundStageDto(
    int Id,
    int ManualPickingId,
    int WarehouseId,
    int? StagingBinId,
    string StageReference,
    string Status,
    string? Notes,
    List<OutboundStageLineDto> Lines,
    DateTime RequestedAt,
    DateTime? StartedAt,
    DateTime? CompletedAt,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record UpdateOutboundStageQuantitiesDto(
    List<OutboundStageLineQuantityDto> Lines
);

public record OutboundStageLineQuantityDto(
    int OutboundStageLineId,
    int QuantityStaged
);

public record CreateLoadingPlanDto(
    int WarehouseId,
    string LoadingReference,
    string? VehiclePlateNumber,
    string? TrailerPlateNumber,
    string? ContainerNumber,
    string? ContainerType,
    string? SealNumber,
    string? CustomerName,
    string? ShipperName,
    string? ConsigneeName,
    string? Destination,
    DateTime? ScheduledDate,
    Guid? SupervisorUserId,
    Guid? LoaderUserId,
    List<int> StageIds,
    string? Remarks = null
);

public record LoadingPlanLineDto(
    int Id,
    int LoadingPlanId,
    int? OutboundStageId,
    int? OutboundStageLineId,
    int? PickedProductId,
    int? OriginalPalletId,
    int? PalletNumber,
    int? PalletHashCode,
    int QuantityPlanned,
    int QuantityLoaded,
    int RemainingQuantity,
    string Status,
    string? ProductName,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record LoadingPlanDto(
    int Id,
    int WarehouseId,
    string LoadingReference,
    string Status,
    string? VehiclePlateNumber,
    string? ContainerNumber,
    string? SealNumber,
    string? CustomerName,
    string? ShipperName,
    string? Destination,
    List<LoadingPlanLineDto> Lines,
    List<string> PhotoUrls,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? ActualStartAt,
    DateTime? CompletedAt,
    List<LoadingEvidenceDto> Evidence,
    List<LoadingExceptionDto> Exceptions
);

public record LoadingEvidenceDto(
    int Id,
    LoadingEvidenceType EvidenceType,
    string FileName,
    string StoredPath,
    string? MimeType,
    DateTime UploadedAt
);

public record UploadLoadingPlanEvidenceRequest(
    IFormFile File,
    LoadingEvidenceType EvidenceType
);

public record CreateLoadingExceptionDto(
    LoadingExceptionType ExceptionType,
    string? Description,
    string Severity,
    int? PalletId,
    int? LoadingPlanLineId
);

public record LoadingExceptionDto(
    int Id,
    int LoadingPlanId,
    LoadingExceptionType ExceptionType,
    string? Description,
    string Severity,
    int? PalletId,
    int? LoadingPlanLineId,
    DateTime CreatedAt
);

public record UpdateLoadingPlanQuantitiesDto(
    List<LoadingPlanLineQuantityDto> Lines
);

public record LoadingPlanLineQuantityDto(
    int LoadingPlanLineId,
    int QuantityLoaded
);
