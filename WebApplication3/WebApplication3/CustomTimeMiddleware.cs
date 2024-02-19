using Microsoft.Extensions.Logging;
using WebApplication3.Interfaces;

namespace WebApplication3
{
    public class CustomTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITimeOfDayService _timeOfDayService;
        private readonly ILogger<CustomTimeMiddleware> _logger;

        public CustomTimeMiddleware(RequestDelegate next, ITimeOfDayService timeOfDayService)
        {
            _next = next;
            _timeOfDayService = timeOfDayService;
        }


        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            var timeOfDay = _timeOfDayService.GetTimeOfDay();
            await context.Response.WriteAsync($"{timeOfDay}");

        }
    }
}
