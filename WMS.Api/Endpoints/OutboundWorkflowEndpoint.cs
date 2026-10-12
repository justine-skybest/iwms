using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using WMS.Api.Data;
using WMS.Api.Dtos.Outbound;
using WMS.Api.Entities;
using WMS.Api.Mapping;
using WMS.Api.Services;

namespace WMS.Api.Endpoints;

public static class OutboundWorkflowEndpoint
{
    public static RouteGroupBuilder MapOutboundWorkflowEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("outbound").WithTags("Outbound");

        // -----------------------------------------------------------------------------
        // GET /stages
        // -----------------------------------------------------------------------------
        group.MapGet("/stages", async (WMSContext dbContext, CancellationToken cancellationToken) =>
        {
            var stages = await dbContext.OutboundStages
                .Include(stage => stage.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .AsNoTracking()
                .OrderByDescending(stage => stage.CreatedAt)
                .ToListAsync(cancellationToken);

            return Results.Ok(stages.Select(stage => stage.ToDto()));
        })
        .WithSummary("Get outbound stages")
        .Produces<List<OutboundStageDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /stages/{id}
        // -----------------------------------------------------------------------------
        group.MapGet("/stages/{id:int}", async (int id, WMSContext dbContext, CancellationToken cancellationToken) =>
        {
            var stage = await dbContext.OutboundStages
                .Include(stage => stage.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(stage => stage.Id == id, cancellationToken);

            return stage is null ? Results.NotFound() : Results.Ok(stage.ToDto());
        })
        .WithSummary("Get an outbound stage")
        .Produces<OutboundStageDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // PUT /stages/{id}/lines - Record actual staged quantities
        // -----------------------------------------------------------------------------
        group.MapPut("/stages/{id:int}/lines", async (
            int id,
            UpdateOutboundStageQuantitiesDto dto,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            if (dto.Lines is null || dto.Lines.Count == 0)
            {
                return Results.BadRequest(new { Message = "At least one staged quantity is required." });
            }

            if (dto.Lines.GroupBy(line => line.OutboundStageLineId).Any(grouping => grouping.Count() > 1))
            {
                return Results.BadRequest(new { Message = "A stage line can only be updated once per request." });
            }

            var stage = await dbContext.OutboundStages
                .Include(currentStage => currentStage.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .FirstOrDefaultAsync(currentStage => currentStage.Id == id, cancellationToken);

            if (stage is null)
            {
                return Results.NotFound(new { Message = $"Outbound stage #{id} was not found." });
            }

            if (stage.Status == OutboundStageStatus.Cancelled
                || stage.Status == OutboundStageStatus.CancellationRequested)
            {
                return Results.Conflict(new { Message = $"An outbound stage with status '{stage.Status}' cannot record staged quantities." });
            }

            var stageLinesById = stage.Lines.ToDictionary(line => line.Id);
            var requestedLineIds = dto.Lines.Select(line => line.OutboundStageLineId).ToList();
            foreach (var requestedLine in dto.Lines)
            {
                if (!stageLinesById.TryGetValue(requestedLine.OutboundStageLineId, out var stageLine))
                {
                    return Results.BadRequest(new { Message = $"Stage line #{requestedLine.OutboundStageLineId} does not belong to outbound stage #{id}." });
                }

                if (requestedLine.QuantityStaged < 0 || requestedLine.QuantityStaged > stageLine.QuantityToStage)
                {
                    return Results.BadRequest(new { Message = $"Staged quantity for line #{stageLine.Id} must be between 0 and {stageLine.QuantityToStage}." });
                }
            }

            var plannedQuantities = await dbContext.LoadingPlanLines
                .Where(line => line.OutboundStageLineId.HasValue
                    && requestedLineIds.Contains(line.OutboundStageLineId.Value)
                    && line.LoadingPlan != null
                    && line.LoadingPlan.Status != LoadingStatus.Cancelled)
                .GroupBy(line => line.OutboundStageLineId!.Value)
                .Select(grouping => new { LineId = grouping.Key, Quantity = grouping.Sum(line => line.QuantityPlanned) })
                .ToDictionaryAsync(item => item.LineId, item => item.Quantity, cancellationToken);

            foreach (var requestedLine in dto.Lines)
            {
                if (plannedQuantities.TryGetValue(requestedLine.OutboundStageLineId, out var allocatedQuantity)
                    && requestedLine.QuantityStaged < allocatedQuantity)
                {
                    return Results.Conflict(new { Message = $"Staged quantity for line #{requestedLine.OutboundStageLineId} cannot be less than its {allocatedQuantity} quantity already assigned to loading plans." });
                }
            }

            var now = DateTime.UtcNow;
            foreach (var requestedLine in dto.Lines)
            {
                var stageLine = stageLinesById[requestedLine.OutboundStageLineId];
                stageLine.QuantityStaged = requestedLine.QuantityStaged;
                stageLine.Status = requestedLine.QuantityStaged == stageLine.QuantityToStage
                    ? OutboundStageLineStatus.Staged
                    : OutboundStageLineStatus.Pending;
                stageLine.ConfirmedAt = requestedLine.QuantityStaged > 0 ? now : null;
                stageLine.UpdatedAt = now;
            }

            var allLinesStaged = stage.Lines.All(line => line.QuantityStaged >= line.QuantityToStage);
            var anyQuantityStaged = stage.Lines.Any(line => line.QuantityStaged > 0);
            stage.Status = allLinesStaged
                ? OutboundStageStatus.Completed
                : anyQuantityStaged ? OutboundStageStatus.Partial : OutboundStageStatus.Pending;
            if (anyQuantityStaged)
            {
                stage.StartedAt ??= now;
            }
            stage.CompletedAt = allLinesStaged ? now : null;
            stage.UpdatedAt = now;

            await dbContext.SaveChangesAsync(cancellationToken);

            var resultDto = stage.ToDto();

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Updated",
                description: $"Updated staged quantities for stage '{stage.StageReference}' (ID: {id}). Stage status is now '{stage.Status}'.",
                details: new
                {
                    StageId = stage.Id,
                    stage.StageReference,
                    ResultingStageStatus = stage.Status.ToString(),
                    Products = resultDto.Lines.Select(l => new
                    {
                        StageLineId = l.Id,
                        l.PickedProductId,
                        ProductName = l.ProductName ?? "Unknown Product",
                        l.QuantityStaged,
                        l.QuantityToStage,
                        l.Status
                    })
                }
            );

            return Results.Ok(resultDto);
        })
        .WithName("UpdateOutboundStageLineQuantities")
        .WithSummary("Record actual staged quantities")
        .WithDescription("Records actual quantities moved to staging. Quantities are absolute totals and cannot exceed the requested quantities.")
        .Produces<OutboundStageDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        // -----------------------------------------------------------------------------
        // POST /stages - Create an outbound stage
        // -----------------------------------------------------------------------------
        group.MapPost("/stages", async (
            CreateOutboundStageDto dto,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            if (dto.Lines is null || dto.Lines.Count == 0)
            {
                return Results.BadRequest(new { Message = "At least one stage line is required." });
            }

            var manualPicking = await dbContext.ManualPickings
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == dto.ManualPickingId, cancellationToken);

            if (manualPicking is null)
            {
                return Results.NotFound(new { Message = $"Manual picking #{dto.ManualPickingId} was not found." });
            }

            var pickedProductIds = dto.Lines.Select(line => line.PickedProductId).Distinct().ToList();
            var pickedProducts = await dbContext.PickedProducts
                .Include(product => product.ReceivedProduct)
                    .ThenInclude(product => product!.Product)
                .Where(product => pickedProductIds.Contains(product.Id))
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (pickedProducts.Count != pickedProductIds.Count)
            {
                return Results.BadRequest(new { Message = "One or more picked product records are invalid for this stage." });
            }

            if (dto.Lines.Select(line => line.PickedProductId).Distinct().Count() != dto.Lines.Count)
            {
                return Results.BadRequest(new { Message = "A picked product can only be included once per stage." });
            }

            if (pickedProducts.Any(product => product.ManualPickingId != dto.ManualPickingId))
            {
                return Results.BadRequest(new { Message = "Every picked product must belong to the selected pick order." });
            }

            if (dto.Lines.Any(line => line.QuantityToStage <= 0))
            {
                return Results.BadRequest(new { Message = "Stage quantities must be greater than zero." });
            }

            var reservedQuantities = await dbContext.OutboundStageLines
                .Where(line => pickedProductIds.Contains(line.PickedProductId)
                    && line.OutboundStage != null
                    && line.OutboundStage.Status != OutboundStageStatus.Cancelled
                    && line.Status != OutboundStageLineStatus.Cancelled)
                .GroupBy(line => line.PickedProductId)
                .Select(grouping => new { PickedProductId = grouping.Key, Quantity = grouping.Sum(line => line.QuantityToStage) })
                .ToDictionaryAsync(item => item.PickedProductId, item => item.Quantity, cancellationToken);

            var alreadyDispatchedQuantities = await dbContext.LoadingPlanLines
                .Where(line => line.PickedProductId.HasValue
                    && pickedProductIds.Contains(line.PickedProductId.Value)
                    && line.OutboundStageLineId == null
                    && line.LoadingPlan != null
                    && line.LoadingPlan.Status == LoadingStatus.Completed)
                .GroupBy(line => line.PickedProductId!.Value)
                .Select(grouping => new { PickedProductId = grouping.Key, Quantity = grouping.Sum(line => line.QuantityLoaded) })
                .ToDictionaryAsync(item => item.PickedProductId, item => item.Quantity, cancellationToken);

            foreach (var requestedLine in dto.Lines)
            {
                var pickedProduct = pickedProducts.First(product => product.Id == requestedLine.PickedProductId);
                var remainingQuantity = Math.Max(
                    pickedProduct.QuantityPicked
                    - reservedQuantities.GetValueOrDefault(pickedProduct.Id)
                    - alreadyDispatchedQuantities.GetValueOrDefault(pickedProduct.Id),
                    0);
                if (requestedLine.QuantityToStage > remainingQuantity)
                {
                    return Results.Conflict(new { Message = $"Picked product #{pickedProduct.Id} has only {remainingQuantity} quantity remaining to stage." });
                }
            }

            var stage = dto.ToEntity();
            stage.WarehouseId = manualPicking.WarehouseId;

            foreach (var line in stage.Lines)
            {
                var pickedProduct = pickedProducts.First(product => product.Id == line.PickedProductId);
                line.Status = OutboundStageLineStatus.Pending;
                line.QuantityStaged = 0;
                line.ReceivedProductId = pickedProduct.ReceivedProductId;
                line.OriginalPalletId = pickedProduct.ReceivedProduct?.PalletId ?? line.OriginalPalletId;
            }

            dbContext.OutboundStages.Add(stage);
            await dbContext.SaveChangesAsync(cancellationToken);

            var createdStage = await dbContext.OutboundStages
                .Include(s => s.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .FirstAsync(s => s.Id == stage.Id, cancellationToken);

            var resultDto = createdStage.ToDto();

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Created",
                description: $"Created outbound stage '{resultDto.StageReference}' (ID: {stage.Id}) for manual picking #{dto.ManualPickingId} with {resultDto.Lines.Count} product(s).",
                details: new
                {
                    StageId = stage.Id,
                    resultDto.StageReference,
                    dto.ManualPickingId,
                    stage.WarehouseId,
                    Products = resultDto.Lines.Select(l => new
                    {
                        l.PickedProductId,
                        ProductName = l.ProductName ?? "Unknown Product",
                        l.QuantityToStage
                    })
                }
            );

            return Results.Created($"/outbound/stages/{stage.Id}", resultDto);
        })
        .WithSummary("Create an outbound stage")
        .Produces<OutboundStageDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        // -----------------------------------------------------------------------------
        // GET /loading-plans
        // -----------------------------------------------------------------------------
        group.MapGet("/loading-plans", async (WMSContext dbContext, CancellationToken cancellationToken) =>
        {
            var plans = await dbContext.LoadingPlans
                .Include(plan => plan.Lines)
                    .ThenInclude(line => line.OriginalPallet)
                .Include(plan => plan.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .Include(plan => plan.Evidence)
                .Include(plan => plan.Exceptions)
                .AsNoTracking()
                .OrderByDescending(plan => plan.CreatedAt)
                .ToListAsync(cancellationToken);

            return Results.Ok(plans.Select(plan => plan.ToDto()));
        })
        .WithSummary("Get loading plans")
        .Produces<List<LoadingPlanDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /loading-plans/{id}
        // -----------------------------------------------------------------------------
        group.MapGet("/loading-plans/{id:int}", async (int id, WMSContext dbContext, CancellationToken cancellationToken) =>
        {
            var plan = await dbContext.LoadingPlans
                .Include(plan => plan.Lines)
                    .ThenInclude(line => line.OriginalPallet)
                .Include(plan => plan.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .Include(plan => plan.Evidence)
                .Include(plan => plan.Exceptions)
                .AsNoTracking()
                .FirstOrDefaultAsync(plan => plan.Id == id, cancellationToken);

            return plan is null ? Results.NotFound() : Results.Ok(plan.ToDto());
        })
        .WithSummary("Get a loading plan")
        .Produces<LoadingPlanDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // POST /loading-plans/{id}/photos - Upload a loading-plan photo
        // -----------------------------------------------------------------------------
        group.MapPost("/loading-plans/{id:int}/photos", async (
            int id,
            IFormFile file,
            WMSContext dbContext,
            IConfiguration configuration,
            ILoggerFactory loggerFactory,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            if (file.Length == 0)
            {
                return Results.BadRequest(new { Message = "Choose a non-empty photo to upload." });
            }

            if (file.Length > 10 * 1024 * 1024)
            {
                return Results.BadRequest(new { Message = "Photo uploads cannot exceed 10 MB." });
            }

            if (string.IsNullOrWhiteSpace(file.ContentType)
                || !file.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
            {
                return Results.BadRequest(new { Message = "The uploaded file must be an image." });
            }

            var planExists = await dbContext.LoadingPlans
                .AnyAsync(plan => plan.Id == id, cancellationToken);
            if (!planExists)
            {
                return Results.NotFound(new { Message = $"Loading plan #{id} was not found." });
            }

            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];
            if (string.IsNullOrWhiteSpace(cloudName)
                || string.IsNullOrWhiteSpace(apiKey)
                || string.IsNullOrWhiteSpace(apiSecret))
            {
                return Results.Problem(
                    title: "Photo uploads are not configured",
                    detail: "Cloudinary credentials must be configured before uploading photos.",
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }

            var fileName = Path.GetFileName(file.FileName);
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return Results.BadRequest(new { Message = "The uploaded photo must have a file name." });
            }

            var cloudinary = new Cloudinary(new Account(cloudName, apiKey, apiSecret));
            using var stream = file.OpenReadStream();
            var uploadResult = await cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
                Folder = $"wms/loading-plans/{id}/photos",
                UniqueFilename = true
            }, cancellationToken);

            if (uploadResult.Error is not null || uploadResult.SecureUrl is null)
            {
                loggerFactory.CreateLogger("WMS.Api.OutboundWorkflow").LogError(
                    "Cloudinary photo upload failed for loading plan {LoadingPlanId}: {CloudinaryError}",
                    id,
                    uploadResult.Error?.Message ?? "No secure URL was returned.");
                return Results.Problem(
                    title: "Photo upload failed",
                    detail: "Cloudinary did not accept the photo upload.",
                    statusCode: StatusCodes.Status502BadGateway);
            }

            var photoUrl = uploadResult.SecureUrl.ToString();
            dbContext.LoadingEvidence.Add(new LoadingEvidence
            {
                LoadingPlanId = id,
                EvidenceType = LoadingEvidenceType.LoadingStart,
                FileName = fileName,
                StoredPath = photoUrl,
                MimeType = file.ContentType,
                UploadedAt = DateTime.UtcNow
            });
            await dbContext.SaveChangesAsync(cancellationToken);

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Uploaded",
                description: $"Uploaded photo '{fileName}' for loading plan #{id}.",
                details: new
                {
                    LoadingPlanId = id,
                    FileName = fileName,
                    PhotoUrl = photoUrl
                }
            );

            return Results.Ok(photoUrl);
        })
        .DisableAntiforgery()
        .WithName("UploadLoadingPlanPhoto")
        .WithSummary("Upload a loading-plan photo")
        .WithDescription("Uploads an image to Cloudinary, stores the returned URL as loading-plan evidence, and returns that URL.")
        .Accepts<IFormFile>("multipart/form-data")
        .Produces<string>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status502BadGateway)
        .ProducesProblem(StatusCodes.Status503ServiceUnavailable);

        // -----------------------------------------------------------------------------
        // POST /loading-plans/{id}/evidence - Upload categorized loading-plan evidence
        // -----------------------------------------------------------------------------
        group.MapPost("/loading-plans/{id:int}/evidence", async (
            int id,
            IFormFile file,
            [FromForm] LoadingEvidenceType evidenceType,
            WMSContext dbContext,
            IConfiguration configuration,
            ILoggerFactory loggerFactory,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            if (!Enum.IsDefined(evidenceType))
            {
                return Results.BadRequest(new { Message = "Choose a supported evidence type." });
            }

            if (file.Length == 0)
            {
                return Results.BadRequest(new { Message = "Choose a non-empty photo to upload." });
            }

            if (file.Length > 10 * 1024 * 1024)
            {
                return Results.BadRequest(new { Message = "Photo uploads cannot exceed 10 MB." });
            }

            if (string.IsNullOrWhiteSpace(file.ContentType)
                || !file.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
            {
                return Results.BadRequest(new { Message = "The uploaded file must be an image." });
            }

            var planExists = await dbContext.LoadingPlans
                .AnyAsync(plan => plan.Id == id, cancellationToken);
            if (!planExists)
            {
                return Results.NotFound(new { Message = $"Loading plan #{id} was not found." });
            }

            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];
            if (string.IsNullOrWhiteSpace(cloudName)
                || string.IsNullOrWhiteSpace(apiKey)
                || string.IsNullOrWhiteSpace(apiSecret))
            {
                return Results.Problem(
                    title: "Photo uploads are not configured",
                    detail: "Cloudinary credentials must be configured before uploading photos.",
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }

            var fileName = Path.GetFileName(file.FileName);
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return Results.BadRequest(new { Message = "The uploaded photo must have a file name." });
            }

            var cloudinary = new Cloudinary(new Account(cloudName, apiKey, apiSecret));
            using var stream = file.OpenReadStream();
            var uploadResult = await cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
                Folder = $"wms/loading-plans/{id}/evidence/{evidenceType}",
                UniqueFilename = true
            }, cancellationToken);

            if (uploadResult.Error is not null || uploadResult.SecureUrl is null)
            {
                loggerFactory.CreateLogger("WMS.Api.OutboundWorkflow").LogError(
                    "Cloudinary evidence upload failed for loading plan {LoadingPlanId} and type {EvidenceType}: {CloudinaryError}",
                    id,
                    evidenceType,
                    uploadResult.Error?.Message ?? "No secure URL was returned.");
                return Results.Problem(
                    title: "Evidence upload failed",
                    detail: "Cloudinary did not accept the evidence photo.",
                    statusCode: StatusCodes.Status502BadGateway);
            }

            var evidence = new LoadingEvidence
            {
                LoadingPlanId = id,
                EvidenceType = evidenceType,
                FileName = fileName,
                StoredPath = uploadResult.SecureUrl.ToString(),
                MimeType = file.ContentType,
                UploadedAt = DateTime.UtcNow
            };
            dbContext.LoadingEvidence.Add(evidence);
            await dbContext.SaveChangesAsync(cancellationToken);

            var resultDto = evidence.ToDto();

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Uploaded",
                description: $"Uploaded '{evidenceType}' evidence photo ('{fileName}') for loading plan #{id}.",
                details: new
                {
                    LoadingPlanId = id,
                    EvidenceType = evidenceType.ToString(),
                    FileName = fileName,
                    StoredPath = evidence.StoredPath
                }
            );

            return Results.Created(
                $"/outbound/loading-plans/{id}",
                resultDto);
        })
        .DisableAntiforgery()
        .WithName("UploadLoadingPlanEvidence")
        .WithSummary("Upload categorized loading-plan evidence")
        .WithDescription("Uploads an image for loading start, seal check, vehicle inspection, damaged items, or final dispatch.")
        .Accepts<UploadLoadingPlanEvidenceRequest>("multipart/form-data")
        .Produces<LoadingEvidenceDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status502BadGateway)
        .ProducesProblem(StatusCodes.Status503ServiceUnavailable);

        // -----------------------------------------------------------------------------
        // POST /loading-plans/{id}/exceptions - Record a loading-plan exception
        // -----------------------------------------------------------------------------
        group.MapPost("/loading-plans/{id:int}/exceptions", async (
            int id,
            CreateLoadingExceptionDto dto,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            if (!Enum.IsDefined(dto.ExceptionType))
            {
                return Results.BadRequest(new { Message = "Choose a supported loading exception type." });
            }

            var severity = dto.Severity?.Trim();
            if (severity is not ("Low" or "Medium" or "High" or "Critical"))
            {
                return Results.BadRequest(new { Message = "Severity must be Low, Medium, High, or Critical." });
            }

            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return Results.BadRequest(new { Message = "An exception description is required." });
            }

            if (dto.Description.Length > 2000)
            {
                return Results.BadRequest(new { Message = "The exception description cannot exceed 2000 characters." });
            }

            var plan = await dbContext.LoadingPlans
                .Include(currentPlan => currentPlan.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .FirstOrDefaultAsync(currentPlan => currentPlan.Id == id, cancellationToken);
            if (plan is null)
            {
                return Results.NotFound(new { Message = $"Loading plan #{id} was not found." });
            }

            if (plan.Status is LoadingStatus.Completed or LoadingStatus.Cancelled or LoadingStatus.Rejected)
            {
                return Results.Conflict(new { Message = $"A loading plan with status '{plan.Status}' cannot record new exceptions." });
            }

            LoadingPlanLine? loadingLine = null;
            if (dto.LoadingPlanLineId.HasValue)
            {
                loadingLine = plan.Lines.FirstOrDefault(line => line.Id == dto.LoadingPlanLineId.Value);
                if (loadingLine is null)
                {
                    return Results.BadRequest(new { Message = $"Loading-plan line #{dto.LoadingPlanLineId.Value} does not belong to loading plan #{id}." });
                }

                if (dto.PalletId.HasValue && loadingLine.OriginalPalletId != dto.PalletId)
                {
                    return Results.BadRequest(new { Message = "The selected pallet does not match the selected loading-plan line." });
                }
            }

            var palletId = dto.PalletId ?? loadingLine?.OriginalPalletId;
            if (palletId.HasValue
                && !await dbContext.Pallets.AnyAsync(pallet => pallet.Id == palletId.Value, cancellationToken))
            {
                return Results.BadRequest(new { Message = $"Pallet #{palletId.Value} was not found." });
            }

            var exception = new LoadingException
            {
                LoadingPlanId = id,
                ExceptionType = dto.ExceptionType,
                Description = dto.Description.Trim(),
                Severity = severity!,
                PalletId = palletId,
                LoadingPlanLineId = loadingLine?.Id,
                CreatedAt = DateTime.UtcNow
            };
            dbContext.LoadingExceptions.Add(exception);
            await dbContext.SaveChangesAsync(cancellationToken);

            var resultDto = exception.ToDto();
            var affectedProductName = loadingLine?.PickedProduct?.ReceivedProduct?.Product?.Name ?? "N/A";

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Created",
                description: $"Recorded '{severity}' severity exception ('{dto.ExceptionType}') for loading plan '{plan.LoadingReference}' (ID: {id}).",
                details: new
                {
                    ExceptionId = exception.Id,
                    LoadingPlanId = id,
                    plan.LoadingReference,
                    ExceptionType = dto.ExceptionType.ToString(),
                    Severity = severity,
                    exception.Description,
                    exception.PalletId,
                    LoadingPlanLineId = loadingLine?.Id,
                    AffectedProductName = affectedProductName
                }
            );

            return Results.Created($"/outbound/loading-plans/{id}", resultDto);
        })
        .WithName("CreateLoadingPlanException")
        .WithSummary("Record a loading-plan exception")
        .WithDescription("Records an exception type, description, severity, and optional pallet or loading-plan line. Open exceptions do not block final dispatch.")
        .Produces<LoadingExceptionDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        // -----------------------------------------------------------------------------
        // POST /loading-plans/{id}/start - Start loading a loading plan
        // -----------------------------------------------------------------------------
        group.MapPost("/loading-plans/{id:int}/start", async (
            int id,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            var plan = await dbContext.LoadingPlans
                .Include(currentPlan => currentPlan.Lines)
                    .ThenInclude(line => line.OriginalPallet)
                .Include(currentPlan => currentPlan.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .Include(currentPlan => currentPlan.Evidence)
                .Include(currentPlan => currentPlan.Exceptions)
                .FirstOrDefaultAsync(currentPlan => currentPlan.Id == id, cancellationToken);

            if (plan is null)
            {
                return Results.NotFound(new { Message = $"Loading plan #{id} was not found." });
            }

            if (plan.Status != LoadingStatus.Planned && plan.Status != LoadingStatus.Assigned)
            {
                return Results.Conflict(new { Message = $"A loading plan with status '{plan.Status}' cannot be started." });
            }

            if (plan.Lines.Count == 0)
            {
                return Results.Conflict(new { Message = "A loading plan without lines cannot be started." });
            }

            plan.Status = LoadingStatus.InProgress;
            plan.ActualStartAt = DateTime.UtcNow;
            plan.UpdatedAt = DateTime.UtcNow;
            await dbContext.SaveChangesAsync(cancellationToken);

            var resultDto = plan.ToDto();

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Updated",
                description: $"Started loading plan '{plan.LoadingReference}' (ID: {id}) containing {resultDto.Lines.Count} planned product line(s). Status set to InProgress.",
                details: new
                {
                    LoadingPlanId = id,
                    plan.LoadingReference,
                    Status = plan.Status.ToString(),
                    plan.ActualStartAt,
                    Products = resultDto.Lines.Select(l => new
                    {
                        l.Id,
                        l.PickedProductId,
                        ProductName = l.ProductName ?? "Unknown Product",
                        l.QuantityPlanned
                    })
                }
            );

            return Results.Ok(resultDto);
        })
        .WithName("StartLoadingPlan")
        .WithSummary("Start loading a loading plan")
        .WithDescription("Transitions a planned or assigned loading plan to InProgress and records its actual start time.")
        .Produces<LoadingPlanDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        // -----------------------------------------------------------------------------
        // PUT /loading-plans/{id}/lines - Record loaded quantities
        // -----------------------------------------------------------------------------
        group.MapPut("/loading-plans/{id:int}/lines", async (
            int id,
            UpdateLoadingPlanQuantitiesDto dto,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            if (dto.Lines is null || dto.Lines.Count == 0)
            {
                return Results.BadRequest(new { Message = "At least one loading-plan line quantity is required." });
            }

            var duplicateLineIds = dto.Lines
                .GroupBy(line => line.LoadingPlanLineId)
                .Any(grouping => grouping.Count() > 1);

            if (duplicateLineIds)
            {
                return Results.BadRequest(new { Message = "A loading-plan line can only be updated once per request." });
            }

            var plan = await dbContext.LoadingPlans
                .Include(currentPlan => currentPlan.Lines)
                    .ThenInclude(line => line.OriginalPallet)
                .Include(currentPlan => currentPlan.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .Include(currentPlan => currentPlan.Evidence)
                .Include(currentPlan => currentPlan.Exceptions)
                .FirstOrDefaultAsync(currentPlan => currentPlan.Id == id, cancellationToken);

            if (plan is null)
            {
                return Results.NotFound(new { Message = $"Loading plan #{id} was not found." });
            }

            if (plan.Status != LoadingStatus.InProgress && plan.Status != LoadingStatus.Partial)
            {
                return Results.Conflict(new { Message = $"A loading plan with status '{plan.Status}' cannot have loaded quantities recorded." });
            }

            var planLinesById = plan.Lines.ToDictionary(line => line.Id);
            foreach (var requestedLine in dto.Lines)
            {
                if (!planLinesById.TryGetValue(requestedLine.LoadingPlanLineId, out var planLine))
                {
                    return Results.BadRequest(new { Message = $"Loading-plan line #{requestedLine.LoadingPlanLineId} does not belong to loading plan #{id}." });
                }

                if (requestedLine.QuantityLoaded < 0 || requestedLine.QuantityLoaded > planLine.QuantityPlanned)
                {
                    return Results.BadRequest(new { Message = $"Loaded quantity for line #{planLine.Id} must be between 0 and {planLine.QuantityPlanned}." });
                }

                planLine.QuantityLoaded = requestedLine.QuantityLoaded;
                planLine.Status = requestedLine.QuantityLoaded switch
                {
                    0 => "Planned",
                    var quantity when quantity < planLine.QuantityPlanned => "Partial",
                    _ => "Loaded"
                };
                planLine.UpdatedAt = DateTime.UtcNow;
            }

            plan.Status = plan.Lines.Any(line => line.QuantityLoaded > 0 && line.QuantityLoaded < line.QuantityPlanned)
                || plan.Lines.Any(line => line.QuantityLoaded == 0)
                ? LoadingStatus.Partial
                : LoadingStatus.InProgress;
            plan.UpdatedAt = DateTime.UtcNow;
            await dbContext.SaveChangesAsync(cancellationToken);

            var resultDto = plan.ToDto();

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Updated",
                description: $"Recorded loaded quantities for loading plan '{plan.LoadingReference}' (ID: {id}). Status is now '{plan.Status}'.",
                details: new
                {
                    LoadingPlanId = id,
                    plan.LoadingReference,
                    ResultingStatus = plan.Status.ToString(),
                    Products = resultDto.Lines.Select(l => new
                    {
                        LoadingPlanLineId = l.Id,
                        l.PickedProductId,
                        ProductName = l.ProductName ?? "Unknown Product",
                        l.QuantityLoaded,
                        l.QuantityPlanned,
                        l.Status
                    })
                }
            );

            return Results.Ok(resultDto);
        })
        .WithName("UpdateLoadingPlanLineQuantities")
        .WithSummary("Record loaded quantities")
        .WithDescription("Updates actual loaded quantities for one or more lines on a loading plan that is InProgress or Partial. Quantities are absolute totals and cannot exceed planned quantities.")
        .Produces<LoadingPlanDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        // -----------------------------------------------------------------------------
        // POST /loading-plans/{id}/dispatch - Confirm final dispatch
        // -----------------------------------------------------------------------------
        group.MapPost("/loading-plans/{id:int}/dispatch", async (
            int id,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            var plan = await dbContext.LoadingPlans
                .Include(currentPlan => currentPlan.Lines)
                    .ThenInclude(line => line.OriginalPallet)
                .Include(currentPlan => currentPlan.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .Include(currentPlan => currentPlan.Evidence)
                .Include(currentPlan => currentPlan.Exceptions)
                .FirstOrDefaultAsync(currentPlan => currentPlan.Id == id, cancellationToken);

            if (plan is null)
            {
                return Results.NotFound(new { Message = $"Loading plan #{id} was not found." });
            }

            if (plan.Status != LoadingStatus.InProgress && plan.Status != LoadingStatus.Partial)
            {
                return Results.Conflict(new { Message = $"A loading plan with status '{plan.Status}' cannot be dispatched." });
            }

            if (plan.Lines.Count == 0 || plan.Lines.Any(line => line.QuantityLoaded != line.QuantityPlanned))
            {
                return Results.Conflict(new { Message = "Every loading-plan line must be fully loaded before final dispatch." });
            }

            plan.Status = LoadingStatus.Completed;
            plan.CompletedAt = DateTime.UtcNow;
            plan.UpdatedAt = DateTime.UtcNow;
            await dbContext.SaveChangesAsync(cancellationToken);

            var resultDto = plan.ToDto();

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Dispatched",
                description: $"Confirmed final dispatch for loading plan '{plan.LoadingReference}' (ID: {id}) containing {resultDto.Lines.Count} fully loaded product(s). Status set to Completed.",
                details: new
                {
                    LoadingPlanId = id,
                    plan.LoadingReference,
                    Status = plan.Status.ToString(),
                    plan.CompletedAt,
                    DispatchedProducts = resultDto.Lines.Select(l => new
                    {
                        l.PickedProductId,
                        ProductName = l.ProductName ?? "Unknown Product",
                        l.QuantityLoaded
                    })
                }
            );

            return Results.Ok(resultDto);
        })
        .WithName("DispatchLoadingPlan")
        .WithSummary("Confirm final dispatch")
        .WithDescription("Marks an InProgress or Partial loading plan as Completed after verifying every planned quantity was loaded.")
        .Produces<LoadingPlanDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        // -----------------------------------------------------------------------------
        // POST /loading-plans - Create a loading plan
        // -----------------------------------------------------------------------------
        group.MapPost("/loading-plans", async (
            CreateLoadingPlanDto dto,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            if (dto.StageIds is null || dto.StageIds.Count == 0)
            {
                return Results.BadRequest(new { Message = "At least one outbound stage must be assigned to the loading plan." });
            }

            var stages = await dbContext.OutboundStages
                .Include(stage => stage.Lines)
                .Where(stage => dto.StageIds.Contains(stage.Id))
                .ToListAsync(cancellationToken);

            if (stages.Count != dto.StageIds.Distinct().Count())
            {
                return Results.BadRequest(new { Message = "One or more selected stages were not found." });
            }

            if (stages.Any(stage => stage.WarehouseId != dto.WarehouseId))
            {
                return Results.BadRequest(new { Message = "All selected stages must belong to the loading plan warehouse." });
            }

            if (stages.Any(stage => stage.Lines.Count == 0))
            {
                return Results.BadRequest(new { Message = "Every selected stage must contain at least one line." });
            }

            var stageLineIds = stages.SelectMany(stage => stage.Lines).Select(line => line.Id).ToList();
            var previouslyPlannedQuantities = await dbContext.LoadingPlanLines
                .Where(line => line.OutboundStageLineId.HasValue
                    && stageLineIds.Contains(line.OutboundStageLineId.Value)
                    && line.LoadingPlan != null
                    && line.LoadingPlan.Status != LoadingStatus.Cancelled)
                .GroupBy(line => line.OutboundStageLineId!.Value)
                .Select(grouping => new { LineId = grouping.Key, Quantity = grouping.Sum(line => line.QuantityPlanned) })
                .ToDictionaryAsync(item => item.LineId, item => item.Quantity, cancellationToken);

            var plannedLines = stages
                .Where(stage => stage.Status != OutboundStageStatus.Cancelled
                    && stage.Status != OutboundStageStatus.CancellationRequested)
                .SelectMany(stage => stage.Lines
                    .Where(line => line.Status != OutboundStageLineStatus.Cancelled && line.QuantityStaged > 0)
                    .Select(line => new
                    {
                        Stage = stage,
                        Line = line,
                        QuantityAvailable = line.QuantityStaged - previouslyPlannedQuantities.GetValueOrDefault(line.Id)
                    }))
                .Where(item => item.QuantityAvailable > 0)
                .ToList();

            if (plannedLines.Count == 0)
            {
                return Results.Conflict(new { Message = "The selected stages have no staged quantities available to load." });
            }

            var plan = dto.ToEntity();
            dbContext.LoadingPlans.Add(plan);
            await dbContext.SaveChangesAsync(cancellationToken);

            foreach (var item in plannedLines)
            {
                dbContext.LoadingPlanLines.Add(new LoadingPlanLine
                {
                    LoadingPlanId = plan.Id,
                    OutboundStageId = item.Stage.Id,
                    OutboundStageLineId = item.Line.Id,
                    PickedProductId = item.Line.PickedProductId,
                    OriginalPalletId = item.Line.OriginalPalletId,
                    QuantityPlanned = item.QuantityAvailable,
                    QuantityLoaded = 0,
                    Status = "Planned",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            var createdPlan = await dbContext.LoadingPlans
                .Include(plan => plan.Lines)
                    .ThenInclude(line => line.OriginalPallet)
                .Include(plan => plan.Lines)
                    .ThenInclude(line => line.PickedProduct)
                        .ThenInclude(product => product!.ReceivedProduct)
                            .ThenInclude(product => product!.Product)
                .Include(plan => plan.Evidence)
                .Include(plan => plan.Exceptions)
                .FirstAsync(currentPlan => currentPlan.Id == plan.Id, cancellationToken);

            var resultDto = createdPlan.ToDto();

            await auditLogService.LogAsync(
                category: "Outbound",
                action: "Created",
                description: $"Created loading plan '{resultDto.LoadingReference}' (ID: {plan.Id}) assigned to warehouse #{dto.WarehouseId} with {resultDto.Lines.Count} product(s).",
                details: new
                {
                    LoadingPlanId = plan.Id,
                    resultDto.LoadingReference,
                    dto.WarehouseId,
                    AssignedStageIds = dto.StageIds,
                    Products = resultDto.Lines.Select(l => new
                    {
                        l.OutboundStageId,
                        l.PickedProductId,
                        ProductName = l.ProductName ?? "Unknown Product",
                        l.QuantityPlanned
                    })
                }
            );

            return Results.Created($"/outbound/loading-plans/{plan.Id}", resultDto);
        })
        .WithName("CreateOutboundLoadingPlan")
        .WithSummary("Create a loading plan")
        .Produces<LoadingPlanDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status409Conflict);

        return group;
    }
}