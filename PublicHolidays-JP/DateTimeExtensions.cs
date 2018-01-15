using System;

namespace InAsync.PublicHolidays.JP {

    internal static class DateTimeExtensions {

        public static int WeekOfMonth(this DateTime date) => (date.Day - 1) / 7 + 1;
    }
}