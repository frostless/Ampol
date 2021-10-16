using Ampol_API.Models;
using Ampol_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ampol_API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CounterController
    {
        private readonly ILogger<CounterController> _logger;
        private readonly ICounterService _counterSerivce;

        public CounterController(ILogger<CounterController> logger, ICounterService counterSerivce)
        {
            _logger = logger;
            _counterSerivce = counterSerivce;
        }

        [HttpPost]
        public Receipt Checkout(Purchase purchase)
        {
            return _counterSerivce.Checkout(purchase);
        }
    }
}
