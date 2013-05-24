namespace Feedby.UI.Web.Utils
{
    using System;
    using System.Globalization;

    public class DateUtils
    {
        public static string GetWeekDates(DateTime from, DateTime to)
        {
            return string.Format(
                "{0} {1} - {2} {3}",
                from.ToString("MMM", CultureInfo.InvariantCulture),
                from.Day,
                to.ToString("MMM", CultureInfo.InvariantCulture),
                to.Day);
        }

        public static DateTime GetWeekFromDate(string week)
        {
            var year = int.Parse(week.Substring(0, 4));
            var weekNum = int.Parse(week.Substring(5, 2));

            return FirstDateOfWeek(year, weekNum);
        }

        public static DateTime GetToDate(string week)
        {
            var year = int.Parse(week.Substring(0, 4));
            var weekNum = int.Parse(week.Substring(5, 2));

            var firstDate = FirstDateOfWeek(year, weekNum);
            return firstDate.AddDays(6);
        }

        private static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            var jan1 = new DateTime(year, 1, 1);
            var daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            var firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            var firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }
    }
}