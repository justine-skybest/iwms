using System.ComponentModel.DataAnnotations;
using WMS.Api.Entities;

namespace WMS.Api.Dtos.Receiving;

public record class CreateReceivingDto(      
    [Required] int WarehouseId,
    [Required][StringLength(15)] string Series,
    [Required][StringLength(85)] string TransportCompany,
    [Required][StringLength(85)] string Shipper,
    [StringLength(85)] string Consignee,
    DateTime DateReceived,
    [Required][StringLength(35)] string Reference,
    List<ReceivedProductDetailsDto> Products,
    [Required][StringLength(25)] string PlateNumber,
    [Required][StringLength(50)] string DriverName,
    DateTime DateTime,
    [StringLength(50)] string ClientRepresentative,
    [StringLength(50)] string CheckerName,
    DateTime TimeStart,
    DateTime TimeEnd,
    DateTime DateAdded    
);
