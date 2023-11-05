﻿using System.Security.Claims;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/publicKeyPointRequest")]
    public class PublicKeyPointRequestController:BaseApiController
    {
        private readonly IPublicKeyPointRequestService _requestService;

        public PublicKeyPointRequestController(IPublicKeyPointRequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpPost]
        public ActionResult<PublicKeyPointRequestResponseDto> Create([FromBody] PublicKeyPointRequestCreateDto request)
        {
            var result = _requestService.Create(request);
            return CreateResponse(result);
        }
    }
}