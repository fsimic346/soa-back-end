﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Tourist;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Payments.Tests.Integration
{
    [Collection("Sequential")]
    public class TourTokenCommandTest : BasePaymentsIntegrationTest
    {
        public TourTokenCommandTest(PaymentsTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();
            var newEntity = new TourTokenCreateDto
            {
                TouristId = 3,
                TourId = -3
            };

            // Act
            var result = ((ObjectResult)controller.AddToken(newEntity.TourId, newEntity.TouristId).Result)?.Value as TourTokenResponseDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.TouristId.ShouldBe(newEntity.TouristId);
            result.TourId.ShouldBe(newEntity.TourId);

            // Assert - Database
            var storedEntity = dbContext.Records.FirstOrDefault(i => i.TouristId == newEntity.TouristId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.TouristId.ShouldBe(result.TouristId);
            storedEntity.TourId.ShouldBe(result.TourId);
        }

        
        private static TourTokenController CreateController(IServiceScope scope)
        {
            return new TourTokenController(scope.ServiceProvider.GetRequiredService<ITourTokenService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
