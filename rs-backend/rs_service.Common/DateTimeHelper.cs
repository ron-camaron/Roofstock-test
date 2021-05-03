using System;

namespace rs_service.Common
{
    public class DateTimeHelper : IDateTime
    {

        public DateTime EndOfDay(DateTime theDate)
        {
            return theDate.Date.AddDays(1).AddTicks(-1);
        }
        public DateTime StartOfDay(DateTime theDate)
        {
            return theDate.Date;
        }

        public DateTime StartOfMonth(DateTime theDate)
        {
            return new DateTime(theDate.Year, theDate.Month, 1);
        }

        public DateTime EndOfMonth(DateTime theDate)
        {
            var firstOfMonth = StartOfMonth(theDate);
            return firstOfMonth.AddMonths(1).AddDays(-1);
        }
    }
}
