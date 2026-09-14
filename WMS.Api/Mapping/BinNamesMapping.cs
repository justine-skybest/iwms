using System;
using WMS.Api.Dtos;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class BinNamesMapping
{
    public static BinNamesDto ToDto(this BinNames binNames)
    {
        return new BinNamesDto(binNames.Id, binNames.BinName);
    }
}
