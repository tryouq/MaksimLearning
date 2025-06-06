using System;
using System.Globalization;

namespace warehouseAndStore
{
    public static class  MyDateTimeHelper  
    {
        public static bool IsHololliday(this DateOnly date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
