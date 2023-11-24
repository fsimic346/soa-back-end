﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class FollowerService : CrudService<FollowerResponseDto, Follower>, IFollowerService
    {
        private readonly IFollowerRepository _followerRepository;

        public FollowerService(ICrudRepository<Follower> repository, IFollowerRepository followerRepository, IMapper mapper) : base( repository, mapper)
        {
            _followerRepository = followerRepository;
        }

        public Result<PagedResult<FollowerResponseWithUsernameDto>> GetFollowers(int page, int pageSize, long userId)
        {
            var result = _followerRepository.GetFollowersPagedById(page, pageSize, userId);
            return MapToDto<FollowerResponseWithUsernameDto>(result);
        }
        public Result<PagedResult<FollowingResponseWithUsernameDto>> GetFollowings(int page, int pageSize, long userId)
        {
            var result = _followerRepository.GetFollowingsPagedById(page, pageSize, userId);
            return MapToDto<FollowingResponseWithUsernameDto>(result);
        }
    }
}