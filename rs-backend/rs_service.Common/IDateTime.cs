using System;

namespace rs_service.Common
{
    public interface IDateTime
    {
        DateTime StartOfDay(DateTime theDate);

        DateTime EndOfDay(DateTime theDate);

        DateTime StartOfMonth(DateTime theDate);

        DateTime EndOfMonth(DateTime theDate);
    }
}
