using Moq;
using Xunit;
using FluentAssertions;
using Ampol_API.Models;
using Ampol_API.Services;
using Ampol_API.Controllers;
using Microsoft.Extensions.Logging;


namespace Ampol_API.Tests.ControllerTests
{
    public class CounterControllerTests
    {
        private readonly Mock<ILogger<CounterController>> _loggerMock;
        private readonly Mock<ICounterService> _counterServiceMock;

        public CounterControllerTests()
        {
            _loggerMock = new Mock<ILogger<CounterController>>();
            _counterServiceMock = new Mock<ICounterService>();
        }

        [Fact]
        public void Should_Return_Receipt()
        {
            // Arrage
            var purchase = new Purchase();
            var receipt = new Receipt();
            _counterServiceMock.Setup(p => p.Checkout(purchase)).Returns(receipt);
            var controller = new CounterController(_loggerMock.Object, _counterServiceMock.Object);
            // Act
            var result = controller.Checkout(purchase);
            // Assert
            _counterServiceMock.Verify(p => p.Checkout(purchase), Times.Once());
            result.Should().BeEquivalentTo(new Microsoft.AspNetCore.Mvc.OkObjectResult(receipt));
        }
    }
}
