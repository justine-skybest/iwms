using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Endpoints;
using WMS.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("WMS");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.MapDashboardEndpoints();
app.MapInventoryEndpoints();
// app.MigrateDb();

app.Run();

