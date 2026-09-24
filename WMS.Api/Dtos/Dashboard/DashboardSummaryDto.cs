using System;

namespace WMS.Api.Dtos.Dashboard;

public record class RecentReceivingDto(
    int Id,
    string Series,
    string Warehouse,
    string Shipper,
    DateTime DateReceived
);

public record class ExpiringProductDto(
    string ProductName,
    string ReceivingSeries,
    DateOnly? ExpirationDate,
    int Quantity,
    string Warehouse
);

public record class AgingInventoryDto(
    string ProductName,
    string ReceivingSeries,
    string Warehouse,
    string Bins,
    int QuantityRemaining,
    int DaysInStorage
);

public record class DailyActivityDto(
    DateOnly Date,
    int ReceivedQuantity,
    int PickedQuantity
);

public record class WarehouseBreakdownDto(
    int WarehouseId,
    string WarehouseName,
    int TotalPallets,
    int TotalBins,
    int OccupiedBins,
    int PendingCheckInPallets,
    int PendingCheckInItems
);

public record class TopProductDto(
    string ProductName,
    int OnHandQuantity
);

public record class DashboardSummaryDto(
    int TotalWarehouses,
    int TotalPallets,
    int PendingCheckInPallets,
    int PendingCheckInItems,
    int TotalBins,
    int OccupiedBins,
    int ExpiringSoonCount,
    int ExpiredCount,
    int TodayReceivingCount,
    decimal TodayReceivingCBM,
    int TodayPickedQuantity,
    List<RecentReceivingDto> RecentReceivings,
    List<ExpiringProductDto> ExpiringProducts,
    List<AgingInventoryDto> AgingInventory,
    List<DailyActivityDto> ActivityTrend,
    List<WarehouseBreakdownDto> WarehouseBreakdown,
    List<TopProductDto> TopProducts
);
