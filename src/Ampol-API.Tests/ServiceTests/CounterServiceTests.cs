using Moq;
using Xunit;
using System;
using Ampol_API.Data;
using Ampol_API.Services;
using Ampol_API.Models;
using FluentAssertions;
using Ampol_API.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace Ampol_API.Tests.ServiceTests
{
    public class CounterServiceTests
    {
        private readonly Mock<DataContext> _dataContextMock;
        public CounterServiceTests()
        {
            _dataContextMock = new Mock<DataContext>();
        }

        [Fact]
        public void Get_Promotion_Points_Should_Return_Correct_Points()
        {
            // Arrage
            var fakeProjects = new List<Product>()
            {
                new Product("PRD01", "Vortext95", "Fuel", 1.2M),
                new Product("PRD02", "Vortext98", "Fuel", 1.3M),
                new Product("PRD03", "Diesel", "Fuel", 1.1M),
                new Product("PRD04", "Twix 55g", "Shop", 2.3M),
                new Product("PRD5", "Mars 72g", "Shop", 5.1M),
                new Product("PRD06", "SNICKERS 72G", "Shop", 3.4M),
                new Product("PRD07", "Bounty 3 63g", "Shop", 6.9M),
                new Product("PRD08", "Snickers 50g", "Shop", 4.0M)
            };

            var pointPerDollarForAny = 2;
            var pointPerDollarForFuel = 3;
            var pointPerDollarForShop = 4;
            var fakePointsPromotion = new List<PointsPromotion>()
            {
                new PointsPromotion("PPD01", "New Year Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200130", "yyyyMMdd", CultureInfo.InvariantCulture),  "Any", pointPerDollarForAny),
                new PointsPromotion("PPD02", "Fuel Promo", DateTime.ParseExact("20200205", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), "Fuel", pointPerDollarForFuel),
                new PointsPromotion("PPD03", "Shop Promo", DateTime.ParseExact("20200301", "yyyyMMdd", CultureInfo.InvariantCulture),DateTime.ParseExact("20200302", "yyyyMMdd", CultureInfo.InvariantCulture), "Shop", pointPerDollarForShop)
            };

            var quantity = 3;
            var unitPrice = 1.2M;
            var basket = new Basket();
            basket.ProductId = "PRD01";
            basket.Quantity = quantity;
            basket.UnitPrice = unitPrice;

            var date = DateTime.ParseExact("20200105", "yyyyMMdd", CultureInfo.InvariantCulture);

            _dataContextMock.Setup(p => p.GetProducts()).Returns(fakeProjects);
            _dataContextMock.Setup(p => p.GetPointsPromotion()).Returns(fakePointsPromotion);
            var counterService = new CounterService(_dataContextMock.Object);
            // Act
            var result = counterService.GetPromotionPoints(basket, date);
            // Assert
            // Assert
            _dataContextMock.Verify(p => p.GetProducts(), Times.Once());
            _dataContextMock.Verify(p => p.GetPointsPromotion(), Times.Once());
            result.Should().Be((int)Math.Ceiling(quantity * unitPrice) * pointPerDollarForAny);
        }

        [Fact]
        public void Get_Promotion_Points_Should_Return_Zero_Points()
        {
            // Arrage
            var fakeProjects = new List<Product>()
            {
                new Product("PRD01", "Vortext95", "Fuel", 1.2M),
                new Product("PRD02", "Vortext98", "Fuel", 1.3M),
                new Product("PRD03", "Diesel", "Fuel", 1.1M),
                new Product("PRD04", "Twix 55g", "Shop", 2.3M),
                new Product("PRD5", "Mars 72g", "Shop", 5.1M),
                new Product("PRD06", "SNICKERS 72G", "Shop", 3.4M),
                new Product("PRD07", "Bounty 3 63g", "Shop", 6.9M),
                new Product("PRD08", "Snickers 50g", "Shop", 4.0M)
            };

            var pointPerDollarForAny = 2;
            var pointPerDollarForFuel = 3;
            var pointPerDollarForShop = 4;
            var fakePointsPromotion = new List<PointsPromotion>()
            {
                new PointsPromotion("PPD01", "New Year Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200130", "yyyyMMdd", CultureInfo.InvariantCulture),  "Any", pointPerDollarForAny),
                new PointsPromotion("PPD02", "Fuel Promo", DateTime.ParseExact("20200205", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), "Fuel", pointPerDollarForFuel),
                new PointsPromotion("PPD03", "Shop Promo", DateTime.ParseExact("20200301", "yyyyMMdd", CultureInfo.InvariantCulture),DateTime.ParseExact("20200302", "yyyyMMdd", CultureInfo.InvariantCulture), "Shop", pointPerDollarForShop)
            };

            var quantity = 3;
            var unitPrice = 1.2M;
            var basket = new Basket();
            basket.ProductId = "PRD01";
            basket.Quantity = quantity;
            basket.UnitPrice = unitPrice;

            var date = DateTime.ParseExact("20200505", "yyyyMMdd", CultureInfo.InvariantCulture);

            _dataContextMock.Setup(p => p.GetProducts()).Returns(fakeProjects);
            _dataContextMock.Setup(p => p.GetPointsPromotion()).Returns(fakePointsPromotion);
            var counterService = new CounterService(_dataContextMock.Object);
            // Act
            var result = counterService.GetPromotionPoints(basket, date);
            // Assert
            // Assert
            _dataContextMock.Verify(p => p.GetProducts(), Times.Once());
            _dataContextMock.Verify(p => p.GetPointsPromotion(), Times.Once());
            result.Should().Be(0);
        }

        [Fact]
        public void Get_Promotion_Points_Should_Return_Highest_Points()
        {
            // Arrage
            var fakeProjects = new List<Product>()
            {
                new Product("PRD01", "Vortext95", "Fuel", 1.2M),
                new Product("PRD02", "Vortext98", "Fuel", 1.3M),
                new Product("PRD03", "Diesel", "Fuel", 1.1M),
                new Product("PRD04", "Twix 55g", "Shop", 2.3M),
                new Product("PRD5", "Mars 72g", "Shop", 5.1M),
                new Product("PRD06", "SNICKERS 72G", "Shop", 3.4M),
                new Product("PRD07", "Bounty 3 63g", "Shop", 6.9M),
                new Product("PRD08", "Snickers 50g", "Shop", 4.0M)
            };

            var pointPerDollarForAny = 2;
            var pointPerDollarForFuel = 3;
            var pointPerDollarForShop = 4;
            var fakePointsPromotion = new List<PointsPromotion>()
            {
                new PointsPromotion("PPD01", "New Year Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200130", "yyyyMMdd", CultureInfo.InvariantCulture),  "Any", pointPerDollarForAny),
                new PointsPromotion("PPD02", "Fuel Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200130", "yyyyMMdd", CultureInfo.InvariantCulture), "Fuel", pointPerDollarForFuel),
                new PointsPromotion("PPD03", "Shop Promo", DateTime.ParseExact("20200301", "yyyyMMdd", CultureInfo.InvariantCulture),DateTime.ParseExact("20200302", "yyyyMMdd", CultureInfo.InvariantCulture), "Shop", pointPerDollarForShop)
            };

            var quantity = 3;
            var unitPrice = 1.3M;
            var basket = new Basket();
            basket.ProductId = "PRD02";
            basket.Quantity = quantity;
            basket.UnitPrice = unitPrice;

            var date = DateTime.ParseExact("20200105", "yyyyMMdd", CultureInfo.InvariantCulture);

            _dataContextMock.Setup(p => p.GetProducts()).Returns(fakeProjects);
            _dataContextMock.Setup(p => p.GetPointsPromotion()).Returns(fakePointsPromotion);
            var counterService = new CounterService(_dataContextMock.Object);
            // Act
            var result = counterService.GetPromotionPoints(basket, date);
            // Assert
            // Assert
            _dataContextMock.Verify(p => p.GetProducts(), Times.Once());
            _dataContextMock.Verify(p => p.GetPointsPromotion(), Times.Once());
            result.Should().Be((int)Math.Ceiling(quantity * unitPrice) * Math.Max(pointPerDollarForAny, pointPerDollarForFuel));
        }

        [Fact]
        public void Get_Promotion_Discount_Should_Return_Correct_Discount()
        {
            // Arrage
            var discountPercentage001 = 0.2M;
            var discountPercentage002 = 0.15M;
            var fakeDiscountPromotion = new List<DiscountPromotion>()
            {
                new DiscountPromotion("DP001", "Fuel Discount Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage001),
                new DiscountPromotion("DP002", "Happy Promo", DateTime.ParseExact("20200301", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200320", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage002)
            };

            var fakeDiscountPromotionProducts = new List<DiscountPromotionProduct>()
            {
                new DiscountPromotionProduct("DP001", "PRD02"),
                new DiscountPromotionProduct("DP002", "PRD02")
            };

            var quantity = 3;
            var unitPrice = 1.3M;
            var basket = new Basket();
            basket.ProductId = "PRD02";
            basket.Quantity = quantity;
            basket.UnitPrice = unitPrice;

            var date = DateTime.ParseExact("20200105", "yyyyMMdd", CultureInfo.InvariantCulture);

            _dataContextMock.Setup(p => p.GetDiscountPromotion()).Returns(fakeDiscountPromotion);
            _dataContextMock.Setup(p => p.GetDiscountPromotionProducts()).Returns(fakeDiscountPromotionProducts);
            var counterService = new CounterService(_dataContextMock.Object);
            // Act
            var result = counterService.GetPromotionDiscount(basket, date);
            // Assert
            _dataContextMock.Verify(p => p.GetDiscountPromotion(), Times.Once());
            _dataContextMock.Verify(p => p.GetDiscountPromotionProducts(), Times.Once());
            result.Should().Be(quantity * unitPrice * discountPercentage001);
        }

        [Fact]
        public void Get_Promotion_Discount_Should_Return_Zero_Discount()
        {
            // Arrage
            var discountPercentage001 = 0.2M;
            var discountPercentage002 = 0.15M;
            var discountPercentage003 = 0.5M;
            var fakeDiscountPromotion = new List<DiscountPromotion>()
            {
                new DiscountPromotion("DP001", "Fuel Discount Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage001),
                new DiscountPromotion("DP002", "Happy Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage002),
                new DiscountPromotion("DP003", "New Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage003)

            };

            var fakeDiscountPromotionProducts = new List<DiscountPromotionProduct>()
            {
                new DiscountPromotionProduct("DP001", "PRD02"),
                new DiscountPromotionProduct("DP002", "PRD02"),
                new DiscountPromotionProduct("DP003", "PRD02")
            };

            var quantity = 3;
            var unitPrice = 1.3M;
            var basket = new Basket();
            basket.ProductId = "PRD02";
            basket.Quantity = quantity;
            basket.UnitPrice = unitPrice;

            var date = DateTime.ParseExact("20200505", "yyyyMMdd", CultureInfo.InvariantCulture);

            _dataContextMock.Setup(p => p.GetDiscountPromotion()).Returns(fakeDiscountPromotion);
            _dataContextMock.Setup(p => p.GetDiscountPromotionProducts()).Returns(fakeDiscountPromotionProducts);
            var counterService = new CounterService(_dataContextMock.Object);
            // Act
            var result = counterService.GetPromotionDiscount(basket, date);
            // Assert
            _dataContextMock.Verify(p => p.GetDiscountPromotion(), Times.Once());
            _dataContextMock.Verify(p => p.GetDiscountPromotionProducts(), Times.Once());
            result.Should().Be(0);
        }

        [Fact]
        public void Get_Promotion_Discount_Should_Return_Highest_Discount()
        {
            // Arrage
            var discountPercentage001 = 0.2M;
            var discountPercentage002 = 0.15M;
            var discountPercentage003 = 0.5M;
            var fakeDiscountPromotion = new List<DiscountPromotion>()
            {
                new DiscountPromotion("DP001", "Fuel Discount Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage001),
                new DiscountPromotion("DP002", "Happy Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage002),
                new DiscountPromotion("DP003", "New Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), discountPercentage003)

            };

            var fakeDiscountPromotionProducts = new List<DiscountPromotionProduct>()
            {
                new DiscountPromotionProduct("DP001", "PRD02"),
                new DiscountPromotionProduct("DP002", "PRD02"),
                new DiscountPromotionProduct("DP003", "PRD02")
            };

            var quantity = 3;
            var unitPrice = 1.3M;
            var basket = new Basket();
            basket.ProductId = "PRD02";
            basket.Quantity = quantity;
            basket.UnitPrice = unitPrice;

            var date = DateTime.ParseExact("20200105", "yyyyMMdd", CultureInfo.InvariantCulture);

            _dataContextMock.Setup(p => p.GetDiscountPromotion()).Returns(fakeDiscountPromotion);
            _dataContextMock.Setup(p => p.GetDiscountPromotionProducts()).Returns(fakeDiscountPromotionProducts);
            var counterService = new CounterService(_dataContextMock.Object);
            // Act
            var result = counterService.GetPromotionDiscount(basket, date);
            // Assert
            _dataContextMock.Verify(p => p.GetDiscountPromotion(), Times.Once());
            _dataContextMock.Verify(p => p.GetDiscountPromotionProducts(), Times.Once());
            result.Should().Be(quantity * unitPrice * Math.Max(Math.Max(discountPercentage001, discountPercentage002), discountPercentage003));
        }
    }
}