using Microsoft.AspNetCore.Mvc;
using CongestionTax.Service;
using CongestionTax.Domain;

namespace CongestionTax.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongestionTaxController : ControllerBase
    {

        private readonly ILogger<CongestionTaxController> _logger;
        private readonly ICongestionTaxService _congestionService;

        public CongestionTaxController(ILogger<CongestionTaxController> logger, ICongestionTaxService congestionService)
        {
            _logger = logger;
            _congestionService = congestionService;
        }

        [HttpPost(Name = "Calculate")]
        public async Task<IActionResult> Calculate(Guid cityId, Vehicle vehicle, List<DateTime> dateTimes)
        {
            try
            { 
                var result = await _congestionService.GetTax(cityId, vehicle, dateTimes);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
