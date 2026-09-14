namespace WMS.Api.Dtos.Warehouse;

public record class WarehouseSummaryDto
(
    int Id,
    string Name,
    string Address,
    byte[] FloorPlanImage,
    RackSummaryDto[] Racks,
    DateTime DateAdded
);