﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Explorer.API.Controllers.Author;

[Authorize(Policy = "authorPolicy")]
[Route("api/tour-sales")]
public class TourSaleController : BaseApiController
{
    private readonly ITourSaleService _saleService;

    public TourSaleController(ITourSaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpPost]
    public ActionResult<TourSaleResponseDto> Create([FromBody] TourSaleCreateDto request)
    {
        var result = _saleService.Create(request);
        return CreateResponse(result);
    }

    [HttpGet]
    public ActionResult<List<TourSaleResponseDto>> GetByAuthor()
    {
        var authorId = long.Parse(HttpContext.User.Claims.First(i => i.Type.Equals("id", StringComparison.OrdinalIgnoreCase)).Value);
        var result = _saleService.GetByAuthorId(authorId);
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _saleService.Delete(id);
        return CreateResponse(result);
    }
}
