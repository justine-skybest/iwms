using Microsoft.Extensions.FileProviders;
using WMS.Frontend.Clients;
using WMS.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
builder.Services.AddBlazorBootstrap();

var WMSApiUrl = builder.Configuration["WMSApiUrl"] ??
    throw new Exception("WMSApiUrl is not set");

builder.Services.AddHttpClient<WarehouseClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<RackClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<BinClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<BayClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<LevelClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<BinNamesClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<ProductClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<ReceivingClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<PalletClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<CheckInClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddHttpClient<ManualPickingClient>(client => client.BaseAddress = new Uri(WMSApiUrl));
builder.Services.AddScoped<DocumentServiceWindows>();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
