using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication3.Services;
using System;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("text/plain")]
    public class CalcController : ControllerBase
    {
        private readonly CalcService _calcService;
        private readonly ILogger<CalcController> _logger;

        public CalcController(CalcService calcService, ILogger<CalcController> logger)
        {
            _calcService = calcService;
            _logger = logger;
        }

        private ActionResult<T> Calculate<T>(Func<int, int, T> operation, string operationName, int a, int b)
        {
            try
            {
                T result = operation(a, b);
                _logger.LogInformation($"{operationName} result: {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {operationName} method");
                return BadRequest("An error occurred during calculation.");
            }
        }

        [HttpGet("calculate")]
        public ActionResult<int> Calculate([FromQuery] int a, [FromQuery] int b, [FromQuery] string operation)
        {
            switch (operation.ToLower())
            {
                case "add":
                    return Calculate(_calcService.Add, "Add", a, b);
                case "subtract":
                    return Calculate(_calcService.Subtract, "Subtract", a, b);
                case "multiply":
                    return Calculate(_calcService.Multiply, "Multiply", a, b);
                case "divide":
                    return Calculate(_calcService.Divide, "Divide", a, b);
                default:
                    return BadRequest("Invalid operation specified.");
            }
        }
    }
}
