using System;
using System.Globalization;

namespace warehouseAndStore
{
    class MyDateTimeHelper  
    {
        public int GetIsoDayOfWeekNumber()
        {
            DateTime today = DateTime.Today;
            return today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)today.DayOfWeek;
        }
    }
}
