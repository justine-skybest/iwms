using WMS.Api.Dtos.Outbound;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class OutboundWorkflowMapping
{
    public static OutboundStage ToEntity(this CreateOutboundStageDto dto)
    {
        return new OutboundStage
        {
            ManualPickingId = dto.ManualPickingId,
            WarehouseId = dto.WarehouseId,
            StagingBinId = dto.StagingBinId,
            StageReference = $"STG-{DateTime.UtcNow:yyyyMMddHHmmss}-{dto.ManualPickingId}",
            RequestedByUserId = dto.RequestedByUserId,
            Notes = dto.Notes,
            Status = OutboundStageStatus.Pending,
            RequestedAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Lines = dto.Lines.Select(line => new OutboundStageLine
            {
                PickedProductId = line.PickedProductId,
                ReceivedProductId = line.ReceivedProductId,
                OriginalBinId = line.OriginalBinId,
                OriginalPalletId = line.OriginalPalletId,
                StagingBinId = line.StagingBinId ?? dto.StagingBinId,
                QuantityToStage = line.QuantityToStage,
                QuantityStaged = 0,
                Status = OutboundStageLineStatus.Pending,
                Remarks = line.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }).ToList()
        };
    }

    public static OutboundStageDto ToDto(this OutboundStage stage)
    {
        return new OutboundStageDto(
            stage.Id,
            stage.ManualPickingId,
            stage.WarehouseId,
            stage.StagingBinId,
            stage.StageReference,
            stage.Status.ToString(),
            stage.Notes,
            stage.Lines.OrderBy(line => line.Id).Select(line => line.ToDto()).ToList(),
            stage.RequestedAt,
            stage.StartedAt,
            stage.CompletedAt,
            stage.CreatedAt,
            stage.UpdatedAt);
    }

    public static OutboundStageLineDto ToDto(this OutboundStageLine line)
    {
        return new OutboundStageLineDto(
            line.Id,
            line.PickedProductId,
            line.ReceivedProductId,
            line.OriginalBinId,
            line.OriginalPalletId,
            line.StagingBinId,
            line.QuantityToStage,
            line.QuantityStaged,
            line.Status.ToString(),
            line.Remarks,
            line.PickedProduct?.ReceivedProduct?.Product?.Name,
            line.CreatedAt,
            line.UpdatedAt
        );
    }

    public static LoadingPlan ToEntity(this CreateLoadingPlanDto dto)
    {
        return new LoadingPlan
        {
            WarehouseId = dto.WarehouseId,
            LoadingReference = dto.LoadingReference,
            VehiclePlateNumber = dto.VehiclePlateNumber,
            TrailerPlateNumber = dto.TrailerPlateNumber,
            ContainerNumber = dto.ContainerNumber,
            ContainerType = dto.ContainerType,
            SealNumber = dto.SealNumber,
            CustomerName = dto.CustomerName,
            ShipperName = dto.ShipperName,
            ConsigneeName = dto.ConsigneeName,
            Destination = dto.Destination,
            ScheduledDate = dto.ScheduledDate,
            SupervisorUserId = dto.SupervisorUserId,
            LoaderUserId = dto.LoaderUserId,
            Status = LoadingStatus.Planned,
            Remarks = dto.Remarks,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Lines = new List<LoadingPlanLine>()
        };
    }

    public static LoadingPlanDto ToDto(this LoadingPlan plan)
    {
        return new LoadingPlanDto(
            plan.Id,
            plan.WarehouseId,
            plan.LoadingReference,
            plan.Status.ToString(),
            plan.VehiclePlateNumber,
            plan.ContainerNumber,
            plan.SealNumber,
            plan.CustomerName,
            plan.ShipperName,
            plan.Destination,
            plan.Lines.OrderBy(line => line.Id).Select(line => line.ToDto()).ToList(),
            plan.Evidence.OrderBy(evidence => evidence.UploadedAt)
                .Select(evidence => evidence.StoredPath)
                .ToList(),
            plan.CreatedAt,
            plan.UpdatedAt,
            plan.ActualStartAt,
            plan.CompletedAt,
            plan.Evidence.OrderBy(evidence => evidence.UploadedAt)
                .Select(evidence => evidence.ToDto())
                .ToList(),
            plan.Exceptions.OrderByDescending(exception => exception.CreatedAt)
                .Select(exception => exception.ToDto())
                .ToList()
        );
    }

    public static LoadingEvidenceDto ToDto(this LoadingEvidence evidence)
    {
        return new LoadingEvidenceDto(
            evidence.Id,
            evidence.EvidenceType,
            evidence.FileName,
            evidence.StoredPath,
            evidence.MimeType,
            evidence.UploadedAt);
    }

    public static LoadingExceptionDto ToDto(this LoadingException exception)
    {
        return new LoadingExceptionDto(
            exception.Id,
            exception.LoadingPlanId,
            exception.ExceptionType,
            exception.Description,
            exception.Severity,
            exception.PalletId,
            exception.LoadingPlanLineId,
            exception.CreatedAt);
    }

    public static LoadingPlanLineDto ToDto(this LoadingPlanLine line)
    {
        return new LoadingPlanLineDto(
            line.Id,
            line.LoadingPlanId,
            line.OutboundStageId,
            line.OutboundStageLineId,
            line.PickedProductId,
            line.OriginalPalletId,
            line.OriginalPallet?.PalletNumber,
            line.OriginalPallet?.PalletHashCode,
            line.QuantityPlanned,
            line.QuantityLoaded,
            line.RemainingQuantity,
            line.Status,
            line.PickedProduct?.ReceivedProduct?.Product?.Name,
            line.CreatedAt,
            line.UpdatedAt
        );
    }
}
