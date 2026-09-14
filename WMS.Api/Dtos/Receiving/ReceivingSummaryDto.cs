using WMS.Api.Entities;

namespace WMS.Api.Dtos.Receiving;

public record class ReceivingSummaryDto(
    int Id,
    int WarehouseId,
    string Warehouse,
    string Series,
    string TransportCompany,
    string Shipper,
    string Consignee,
    DateTime DateReceived,
    string Reference,
    List<ReceivedProductSummaryDto> Products,
    string PlateNumber,
    string DriverName,
    DateTime DateTime,
    string ClientRepresentative,
    string CheckerName,
    DateTime TimeStart,
    DateTime TimeEnd,
    DateTime DateAdded
);
