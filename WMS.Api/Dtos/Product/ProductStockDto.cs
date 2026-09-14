namespace WMS.Api.Dtos.Product;

public record class ProductStockDto(
    int id,
    string Name,
    string TypeOfPackage,
    string Measurement,
    decimal Weight,    
    int CheckedInQuantity,
    int PickedQuantity,
    int CurrentStock
);

