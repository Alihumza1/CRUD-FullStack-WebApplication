using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Log(LoggingData logData)
        {
            // Perform any necessary processing or validation on the log data

            // Log the received log data
            _logger.LogInformation($"[{logData.Timestamp}] [{logData.Level}] {logData.Message}");

            return Ok();
        }
    }
}
