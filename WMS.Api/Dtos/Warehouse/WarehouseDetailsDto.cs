namespace WMS.Api.Dtos;

public record class WarehouseDetailsDto
(
    int Id,
    string Name,
    string Address,
    byte[] FloorPlanImage,
    DateTime DateAdded
);
