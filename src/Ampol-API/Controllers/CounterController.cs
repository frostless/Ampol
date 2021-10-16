using Ampol_API.Models;
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
        public CounterController(ILogger<CounterController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Receipt Checkout(Purchase purchase)
        {
            return null;
        }
    }
}
