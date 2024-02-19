using WebApplication3.Interfaces;

namespace WebApplication3.Services
{
    public class TimeOfDayService : ITimeOfDayService
    {
        public string GetTimeOfDay()
        {
            var currentTime = DateTime.Now;
            var hour = currentTime.Hour;
            var minute = currentTime.Minute;

            string timeOfDay;

            if (hour >= 12 && hour < 18)
                timeOfDay = "ДЕНЬ";
            else if (hour >= 18 && hour < 24)
                timeOfDay = "ВЕЧІР";
            else if (hour >= 0 && hour < 6)
                timeOfDay = "НІЧ";
            else
                timeOfDay = "РАНОК";

            return $"Зараз {timeOfDay} {hour:D2}:{minute:D2}";
        }
    }
}
