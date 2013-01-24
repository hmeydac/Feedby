using System;
using System.Globalization;

namespace Feedby.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public FeedbackType FeedbackType { get; set; }

        public string Text { get; set; }

        public Employee SubmittedTo { get; set; }

        public Employee SubmittedBy { get; set; }

        public DateTime SubmittedDate { get; set; } 

        public string WeekYear
        {
            get
            {
                var weekNumber = DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(this.SubmittedDate,
                                                                             CalendarWeekRule.FirstFourDayWeek,
                                                                             DayOfWeek.Monday);
                return string.Format("Week {0}.{1}", this.SubmittedDate.Year, weekNumber.ToString("00"));
            }
        }
    }
}