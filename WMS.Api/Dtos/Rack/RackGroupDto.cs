using WMS.Api.Dtos.Bin;

namespace WMS.Api.Dtos.Rack
{
    public record RackGroupDto(
        int? RackId,
        string RackName,
        string WarehouseName,
        IReadOnlyList<BinSummaryDto> Bins
    );
}
