﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Payments.Core.UseCases;

public class TourSaleService : BaseService<TourSale>, ITourSaleService
{
    private readonly ICrudRepository<TourSale> _crudRepository;
    private readonly ITourSaleRepository _saleRepository;

    private Action<TourSale> CheckIfTourIsAlreadyOnSale(TourSale sale)
    {
        return s => { if (sale.EndDate >= s.StartDate && sale.StartDate <= s.EndDate && sale.TourIds.Any(t => s.TourIds.Contains(t))) throw new InvalidOperationException("At least one of the tours is already on sale."); };
    }

    public TourSaleService(ICrudRepository<TourSale> crudRepository, IMapper mapper, ITourSaleRepository saleRepository) : base(mapper)
    {
        _crudRepository = crudRepository;
        _saleRepository = saleRepository;
    }

    public Result<TourSaleResponseDto> Create(TourSaleCreateDto sale)
    {
        try
        {
            var saleDomain = MapToDomain(sale);
            List<TourSale> tourSales = _crudRepository.GetAll();
            tourSales.ForEach(CheckIfTourIsAlreadyOnSale(saleDomain));
            var result = _crudRepository.Create(saleDomain);
            return MapToDto<TourSaleResponseDto>(result);
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
        }
    }

    public Result<List<TourSaleResponseDto>> GetByAuthorId(long authorId)
    {
        var result = _saleRepository.GetByAuthorId(authorId);
        return MapToDto<TourSaleResponseDto>(result);
    }
}
