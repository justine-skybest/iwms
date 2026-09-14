using WMS.Api.Dtos.Product;

namespace WMS.Api.Dtos.Bin;

public record class BinStockDto(
    string CheckInType,    
    string PalletNumber,
    List<ProductStockDto> Products
);