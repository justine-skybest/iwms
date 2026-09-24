using System;

namespace WMS.Api.Dtos.Receiving;

public record class ReceivingDetailsDto(
    int Id,
    int WarehouseId,
    int? IncomingId,
    string Series,
    string TransportCompany,
    string Shipper,
    string Consignee,
    DateTime DateReceived,
    string Reference,
    List<ReceivedProductDetailsDto> Products,
    string PlateNumber,
    string DriverName,
    DateTime DateTime,
    string ClientRepresentative,
    string CheckerName,
    DateTime TimeStart,
    DateTime TimeEnd    
);
