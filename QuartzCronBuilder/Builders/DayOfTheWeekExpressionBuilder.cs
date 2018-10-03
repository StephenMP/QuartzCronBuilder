using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class DayOfTheWeekExpressionBuilder
    {
        private readonly DayOfWeekField dayOfWeekField;
        private readonly YearExpressionBuilder yearExpressionBuilder;

        public DayOfTheWeekExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.dayOfWeekField = new DayOfWeekField();
            this.yearExpressionBuilder = new YearExpressionBuilder(cronExpressionBuilder);
        }

        public YearExpressionBuilder AllDaysOfTheWeek()
        {
            this.dayOfWeekField.AllValues();
            return this.yearExpressionBuilder;
        }

        public string BuildCronExpression() => $"{this.dayOfWeekField.CronExpression} {this.yearExpressionBuilder.BuildCronExpression()}";

        public YearExpressionBuilder LastDaysOfTheWeek()
        {
            this.dayOfWeekField.Last();
            return this.yearExpressionBuilder;
        }

        public YearExpressionBuilder NoSpecificDaysOfTheWeek()
        {
            this.dayOfWeekField.NoSpecificValue();
            return this.yearExpressionBuilder;
        }

        public YearExpressionBuilder NthDayOfMonth(int dayOfWeek, int weekNumber)
        {
            this.dayOfWeekField.NthDayOfMonth(dayOfWeek, weekNumber);
            return this.yearExpressionBuilder;
        }

        public YearExpressionBuilder RangeOfDaysOfTheWeek(int from, int to)
        {
            this.dayOfWeekField.RangeOfValues(from, to);
            return this.yearExpressionBuilder;
        }

        public YearExpressionBuilder RunInDaysOfTheWeekIncrements(int startingValue, int increment)
        {
            this.dayOfWeekField.RunInIncrements(startingValue, increment);
            return this.yearExpressionBuilder;
        }

        public YearExpressionBuilder SpecificDaysOfTheWeek(params int[] seconds)
        {
            this.dayOfWeekField.SpecificValues(seconds);
            return this.yearExpressionBuilder;
        }
    }
}
