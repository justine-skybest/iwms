using System.Reflection;
using System.Text.Json;

namespace WMS.Api.Endpoints
{
        public static class SystemEndpoints
        {
            public static RouteGroupBuilder MapSystemEndpoints(this WebApplication app)
            {
                var group = app.MapGroup("system")
                    .WithTags("System");

            group.MapGet("/version", async (IWebHostEnvironment env, CancellationToken cancellationToken) =>
            {
                // 1. Read local changelog file
                var changelogPath = Path.Combine(env.ContentRootPath, "changelog.json");
                List<ReleaseNoteDto> releaseNotes = new();

                if (File.Exists(changelogPath))
                {
                    var jsonContent = await File.ReadAllTextAsync(changelogPath, cancellationToken);
                    releaseNotes = JsonSerializer.Deserialize<List<ReleaseNoteDto>>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new();
                }

                // 2. Extract assembly version and top changelog version
                var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3);
                var latestChangelogVersion = releaseNotes.FirstOrDefault()?.Version;

                // Use assembly version if customized, otherwise automatically pick the latest version in changelog.json
                string currentVersion = (assemblyVersion != null && assemblyVersion != "1.0.0")
                    ? assemblyVersion
                    : (latestChangelogVersion ?? "1.0.0");

                return Results.Ok(new SystemVersionResponseDto
                {
                    CurrentVersion = currentVersion,
                    Environment = env.EnvironmentName,
                    ReleaseNotes = releaseNotes
                });
            })
            .WithName("GetSystemVersion")
            .Produces<SystemVersionResponseDto>()
            .WithSummary("Retrieves the current application release version and changelog history");

            return group;
            }
        }

        public record ChangeItemDto(string Type, string Description);

        public record ReleaseNoteDto(
            string Version,
            string ReleaseDate,
            string Title,
            List<ChangeItemDto> Changes
        );

        public record SystemVersionResponseDto
        {
            public string CurrentVersion { get; set; } = "1.0.0";
            public string Environment { get; set; } = "Production";
            public List<ReleaseNoteDto> ReleaseNotes { get; set; } = new();
        }
}
