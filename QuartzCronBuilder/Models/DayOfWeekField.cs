using System.Linq;
using QuartzCronBuilder.Enums;

namespace QuartzCronBuilder.Models
{
    public class DayOfWeekField : CronField
    {
        public DayOfWeekField() : base()
        {
            this.allowedTokens.AddRange(new char[] { '?', 'L', '#' });
            this.MinValue = 1;
            this.MaxValue = 7;
        }

        public void Last()
        {
            this.CronExpression = "L";
        }

        public void NoSpecificValue()
        {
            this.CronExpression = "?";
        }

        public void NthDayOfMonth(int dayOfWeek, int weekNumber)
        {
            this.CronExpression = $"{dayOfWeek}#{weekNumber}";
        }

        public void SpecificValue(params CronDaysOfWeek[] daysOfWeek)
        {
            var intValues = daysOfWeek.Select(day => (int)day).ToArray();
            this.SpecificValues(intValues);
        }
    }
}
