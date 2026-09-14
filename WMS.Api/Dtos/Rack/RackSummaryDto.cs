using System.ComponentModel.DataAnnotations;
using WMS.Api.Entities;

namespace WMS.Api.Dtos;

public record class RackSummaryDto
(    
    int Id,
    [Required][StringLength(50)] string Name,
    string Warehouse,
    string Bay,
    string Level,
    ICollection<RackFloorMapObjectDetails> RackFloorMapObject,  
    DateTime DateAdded
);
