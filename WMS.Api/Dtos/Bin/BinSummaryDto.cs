using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Bin;

public record class BinSummaryDto
(   
    int Id,
    string Warehouse,
    string Rack,
    string Bay,
    string Level,
    string BinName,
    string BinHashCode,
    DateTime DateAdded
);
