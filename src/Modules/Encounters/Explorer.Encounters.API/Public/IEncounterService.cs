﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;

namespace Explorer.Encounters.API.Public
{
    public interface IEncounterService
    {
        Result<EncounterResponseDto> Create<EncounterCreateDto>(EncounterCreateDto encounter);
        Result<EncounterResponseDto> Update<EncounterUpdateDto>(EncounterUpdateDto encounter);
        Result<PagedResult<EncounterResponseDto>> GetPaged(int page, int pageSize);
        Result<PagedResult<EncounterResponseDto>> GetActive(int page, int pageSize);
        Result<EncounterResponseDto> Get(long id);
        Result CreateMiscEncounter(MiscEncounterCreateDto encounter);
        Result Delete(long id);
        Result<EncounterResponseDto> ActivateEncounter(long userId, long encounterId, double longitute, double latitude);
        Result<TouristProgressResponseDto> CompleteEncounter(long userId, long encounterId);
        Result<EncounterResponseDto> CancelEncounter(long userId, long encounterId);

    }
}