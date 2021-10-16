using Ampol_API.Models;
using Ampol_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ampol_API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CounterController : Controller
    {
        private readonly ILogger<CounterController> _logger;
        private readonly ICounterService _counterSerivce;

        public CounterController(ILogger<CounterController> logger, ICounterService counterSerivce)
        {
            _logger = logger;
            _counterSerivce = counterSerivce;
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (purchase == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var receipt = _counterSerivce.Checkout(purchase);

            return Ok(new { receipt });
        }
    }
}
