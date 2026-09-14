using WMS.Api.Dtos;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class WarehouseMapping
{   
    public static Warehouse ToEntity(this CreateWarehouseDto warehouse)
    {
        return new Warehouse()
        {
            Name = warehouse.Name,
            Address = warehouse.Address,
            FloorPlanImage = warehouse.FloorPlanImage,
            DateAdded = warehouse.DateAdded
        };
    }

    public static Warehouse ToEntity(this UpdateWarehouseDto warehouse, int id)
    {
        return new Warehouse()
        {
            Id = id,
            Name = warehouse.Name,
            Address = warehouse.Address,
            FloorPlanImage = warehouse.FloorPlanImage,
            DateAdded = warehouse.DateAdded
        };
    }

    public static WarehouseDetailsDto ToWarehouseDetailsDto(this Warehouse warehouse)
    {
        return new (
            warehouse.Id,
            warehouse.Name,
            warehouse.Address,
            warehouse.FloorPlanImage ?? Array.Empty<byte>(),
            warehouse.DateAdded
        );
    }
}
