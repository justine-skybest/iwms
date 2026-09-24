using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Endpoints;
using WMS.Api.Hubs;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddEndpointsApiExplorer();

// 3. Configure Swagger to generate string definitions for enums
builder.Services.AddSwaggerGen(options =>
{
    options.UseInlineDefinitionsForEnums();
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

builder.Services.AddDbContext<WMSContext>(
    dbContextOptions => dbContextOptions
    .UseMySql(connString, ServerVersion.AutoDetect(connString))
);

var app = builder.Build();

app.UseCors("AngularOrigin");
app.MapHub<NotificationHub>("/hubs/notifications");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WMS API v1");
});

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

// app.MigrateDb();

app.Run();