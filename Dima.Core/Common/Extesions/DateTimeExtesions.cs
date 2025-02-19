using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Core.Common.Extesions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetFirstDay(this DateTime date, int? year = null, int? month = null)
        => new (year ?? date.Year, month ?? date.Month, 1);
        
        public static DateTime GetLastDay(
        this DateTime date, int? year = null, int? month = null)
        => new DateTime(
                year ?? date.Year,
                month ?? date.Month,
                1).AddMonths(1).AddDays(-1);
         
        
    }
}