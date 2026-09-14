# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Quick Start

This solution has two .NET 8 projects:

- **WMS.Api** — ASP.NET Core Minimal API (project under `WMS.Api/`)
- **WMS.Frontend** — Blazor Server app (project under `WMS.Frontend/`)

Each project has its own `.sln` file. To run both:

```powershell
# Run the API (from WMS.Api/)
cd WMS.Api
dotnet run --launch-profile http   # API on http://localhost:8805 (dev profile)

# Run the Frontend (from WMS.Frontend/)
cd WMS.Frontend
dotnet run --launch-profile http   # Frontend on http://localhost:8806 (dev profile)
```

Run each project from its own directory (the two projects have separate `.sln` files).

## Build / Lint / Test

| Command | Description |
|---|---|
| `dotnet build` | Build the current project |
| `dotnet run` | Build and run (using launchSettings profile) |
| `dotnet test` | Run unit tests (no test projects exist in this repo) |
| `dotnet tool restore` | Restore .NET tools |

There are no lint rules configured and no test projects in this repository.

## Architecture Overview

**WMS.Api** (`WMS.Api/`):
- Minimal ASP.NET Core Web API using minimal APIs
- Endpoint groups defined in `Endpoints/` (e.g., `WarehouseEndpoint.cs`, `ReceivingEndpoint.cs`)
- DTOs in `Dtos/` — request/response models for the API
- Entity definitions in `Entities/` mapped to MySQL tables via EF Core
- EF Core `WMSContext` (`Data/WMSContext.cs`) using Pomelo MySQL provider
- Database migrations in `Data/Migrations/`
- Auto-migration on startup via `DataExtensions.MigrateDb()` called from `Program.cs`
- DTO-to-entity mapping via static extension methods in `Mapping/`
- Connection string from `appsettings.json`: `server=localhost; database=WMS; user=root; password=;`
- API base URL configurable via `WMSApiUrl` appsetting (default `http://127.0.0.1:8805`)

**WMS.Frontend** (`WMS.Frontend/`):
- Blazor Server with interactive render mode (`Program.cs` line 44-45)
- UI pages in `Components/Pages/` using Razor components
- Layout: `MainLayout.razor` with NavMenu, breadcrumbs, and `@Body`
- API clients in `Clients/` (`WarehouseClient.cs`, `ReceivingClient.cs`, etc.) using `HttpClient`
- Model DTOs in `Models/`
- Services for document generation in `Services/`
- Static assets in `wwwroot/` (choices.js, QRCoder, BarcodeLib, etc.)
- Frontend configured with `WMSApiUrl` from `appsettings.Development.json` (default `http://localhost:8805`)

**Data Flow**: Frontend HTTP clients → WMS.Api Endpoints → `WMSContext` → MySQL. DTO ↔ Entity mapping happens via extension methods in the `Mapping/` folders on both sides.

## Key Commands per Project

### WMS.Api

```powershell
# Build
dotnet build

# Run with dev profile (port 8805)
dotnet run --launch-profile http

# EF Core migrations
dotnet tool install --global dotnet-ef  # if not already installed
dotnet ef migrations add <name>       # add migration
dotnet ef database update               # apply migrations

# API client testing (WMS.http has curl-like examples)
# Port: http://127.0.0.1:8805 (or configured port)
```

### WMS.Frontend

```powershell
# Build
dotnet build

# Run with dev profile (port 8806)
dotnet run --launch-profile http

# Frontend connects to API at http://localhost:8805 (configurable via WMSApiUrl)
# The WMSApiUrl is read from appsettings.Development.json
```

## Development Notes

- The API uses `WithParameterValidation()` on endpoint groups for request validation
- Frontend HttpClients are configured in `Program.cs` with `builder.Configuration["WMSApiUrl"]` — if unset, throws an exception
- Database migrations are auto-applied on startup via `app.MigrateDb()` in `Program.cs` (`DataExtensions.cs`)
- The solution has two separate `.sln` files; opening one in Visual Studio may not show the other project
- No unit test projects exist; add `xunit` or `NUnit` if needed
- Ports: API defaults to 8805 (dev), Frontend to 8806 (dev) per `launchSettings.json`
- The `WMS.http` file under `WMS.Api/` contains example API requests (GET/POST/PUT/DELETE) for all endpoints