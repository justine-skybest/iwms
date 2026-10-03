using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WMS.Api.Data;
using WMS.Api.Endpoints;
using WMS.Api.Entities;
using WMS.Api.Hubs;
using WMS.Api.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Caching.Hybrid;

DotNetEnv.Env.Load();

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

// 1. Register Redis as the secondary (L2) distributed cache provider
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "WMS_";
});

// 2. Register HybridCache (automatically links to L1 In-Memory + L2 Redis)
#pragma warning disable EXTEXP0018 // Experimental API in earlier .NET releases
builder.Services.AddHybridCache(options =>
{
    // Global maximum payload size limit (Default: 1MB)
    options.MaximumPayloadBytes = 1024 * 1024 * 10; // 10 MB

    // Default expiration settings across endpoints
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(10),        // L2 Redis TTL
        LocalCacheExpiration = TimeSpan.FromSeconds(5) // L1 Memory TTL (Keep short for fast invalidation)
    };
});
#pragma warning restore EXTEXP0018

// 1. Minimal API JSON Serialization
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// 2. Swashbuckle Schema Generator JSON Converter
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var connString = builder.Configuration.GetConnectionString("WMS");

// 3. Database Context (MySQL with WMSContext)
builder.Services.AddDbContext<WMSContext>(dbContextOptions =>
    dbContextOptions.UseMySql(connString, ServerVersion.AutoDetect(connString)));

// 4. ASP.NET Core Identity Core Configuration
builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<WMSContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

// 5. Authentication & External Google Provider Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddCookie(IdentityConstants.ApplicationScheme, options =>
{
    options.Cookie.Name = ".Skybest.WMS.Auth";
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
})
.AddCookie(IdentityConstants.ExternalScheme)
.AddGoogle("Google", options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    options.SaveTokens = true;
});

// 6. Global Fallback Authorization Policy
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

// 7. Context & Auth Service Dependency Injections
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>(); // ✅ CORRECT SINGLE REGISTRATION
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddEndpointsApiExplorer();

// 8. Configure Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.UseInlineDefinitionsForEnums();
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "WMS API v1", Version = "v1" });

    options.AddSecurityDefinition("CookieAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Cookie,
        Name = ".Skybest.WMS.Auth",
        Description = "ASP.NET Core Identity Application Cookie"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "CookieAuth" }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure Forwarded Headers
var forwardedHeadersOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
forwardedHeadersOptions.KnownNetworks.Clear();
forwardedHeadersOptions.KnownProxies.Clear();

app.UseForwardedHeaders(forwardedHeadersOptions);

// Seed Roles & System Admin
await IdentityDataSeeder.SeedRolesAndAdminAsync(app.Services, app.Configuration);

app.UseCors("AngularOrigin");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WMS API v1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<NotificationHub>("/hubs/notifications");

// Endpoints
app.MapAuthEndpoints();
app.MapWarehouseEndpoints();
app.MapRackEndpoints();
app.MapBinEndpoints();
app.MapBayEndpoints();
app.MapLevelEndpoints();
app.MapBinNameEndpoints();
app.MapProductEndpoints();
app.MapReceivingEndpoints();
app.MapReceivedProductEndpoints();
app.MapCheckInEndpoints();
app.MapPalletEndpoints();
app.MapManualPickingEndpoints();
app.MapTransferEndpoints();
app.MapTransferV2Endpoints();
app.MapDashboardEndpoints();
app.MapInventoryEndpoints();
app.MapIncomingEndpoints();
app.MapIncomingImportEndpoints();
app.MapIncomingTemplateEndpoints();
app.MapReportEndpoints();
app.MapAuditLogEndpoints();

app.Run();