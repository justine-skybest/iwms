using System;
using WMS.Api.Dtos;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class LevelMapping
{
    public static LevelDto ToDto(this Level level)
    {
        return new LevelDto(level.Id, level.LevelNumber);
    }
}
