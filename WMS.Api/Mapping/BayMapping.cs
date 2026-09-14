using System;
using WMS.Api.Dtos;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class BayMapping
{   
    public static BayDto ToDto(this Bay bay)
    {
        return new BayDto(bay.Id, bay.BayNumber);
    }
}
