﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public;

public interface ITourSearchService
{
    Result<PagedResult<TourResponseDto>> Search(double longitude, double latitude, double maxDistance, int page, int pageSize);
}