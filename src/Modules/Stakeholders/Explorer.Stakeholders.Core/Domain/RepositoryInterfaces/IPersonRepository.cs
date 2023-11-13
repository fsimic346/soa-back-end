﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain.Problems;
using FluentResults;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IPersonRepository
    {
        Person? GetByUserId(long id);
        Result<PagedResult<Person>> GetAll(int page, int pageSize);
        Result<PagedResult<Person>> GetPagedByAdmin(int page, int pageSize, long adminId);
    }
}
