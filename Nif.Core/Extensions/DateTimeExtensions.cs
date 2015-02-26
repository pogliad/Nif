using System;

namespace Nif.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekday(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return false;

                default:
                    return true;
            }
        }

        public static bool IsWeekend(this DayOfWeek dayOfWeek)
        {
            return !dayOfWeek.IsWeekday();
        }
    }
}