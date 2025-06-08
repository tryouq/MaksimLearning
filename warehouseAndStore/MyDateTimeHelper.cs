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
        public static int IsIntDayOfWeek(this DateOnly date) 
        {
            DateTime today = DateTime.Today;
            return today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)today.DayOfWeek;
        }
    }
}
