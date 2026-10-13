using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WMS.Api.Endpoints;

public static class ImageUploadEndpoint
{
    public static RouteGroupBuilder MapImageUploadEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("upload").WithTags("Upload").WithParameterValidation();

        // ------------------------------------------------------------------
        // POST /upload/image - Upload Image to Cloudinary
        // ------------------------------------------------------------------
        group.MapPost("/image", async (
            IFormFile file,
            IConfiguration config,
            CancellationToken cancellationToken) =>
        {
            if (file == null || file.Length == 0)
            {
                return Results.BadRequest(new { Message = "An image file is required." });
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp", ".heic" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return Results.BadRequest(new { Message = "Only JPG, PNG, WEBP, and HEIC images are allowed." });
            }

            // Fetch Cloudinary credentials from appsettings.json or environment variables
            var cloudName = config["Cloudinary:CloudName"];
            var apiKey = config["Cloudinary:ApiKey"];
            var apiSecret = config["Cloudinary:ApiSecret"];

            if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
            {
                return Results.Problem("Cloudinary credentials are missing in configuration.");
            }

            var account = new Account(cloudName, apiKey, apiSecret);
            var cloudinary = new Cloudinary(account);

            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "wms/exceptions",
                Transformation = new Transformation().Quality("auto").FetchFormat("auto")
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams, cancellationToken);

            if (uploadResult.Error != null)
            {
                return Results.BadRequest(new { Message = uploadResult.Error.Message });
            }

            return Results.Ok(new ImageUploadResponseDto
            {
                ImageUrl = uploadResult.SecureUrl.ToString(),
                PublicId = uploadResult.PublicId
            });
        })
        .DisableAntiforgery()
        .WithName("UploadImageToCloudinary")
        .WithSummary("Upload an exception photo to Cloudinary and return the secure image URL")
        .Accepts<IFormFile>("multipart/form-data")
        .Produces<ImageUploadResponseDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        return group;
    }
}

public record ImageUploadResponseDto
{
    public required string ImageUrl { get; init; }
    public required string PublicId { get; init; }
}