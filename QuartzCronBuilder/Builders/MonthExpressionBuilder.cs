using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class MonthExpressionBuilder
    {
        private readonly DayOfTheWeekExpressionBuilder dayOfTheWeekExpressionBuilder;
        private readonly MonthField monthField;

        public MonthExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.monthField = new MonthField();
            this.dayOfTheWeekExpressionBuilder = new DayOfTheWeekExpressionBuilder(cronExpressionBuilder);
        }

        public DayOfTheWeekExpressionBuilder AllMonths()
        {
            this.monthField.AllValues();
            return this.dayOfTheWeekExpressionBuilder;
        }

        public string BuildCronExpression() => $"{this.monthField.CronExpression} {this.dayOfTheWeekExpressionBuilder.BuildCronExpression()}";

        public DayOfTheWeekExpressionBuilder RangeOfMonths(int from, int to)
        {
            this.monthField.RangeOfValues(from, to);
            return this.dayOfTheWeekExpressionBuilder;
        }

        public DayOfTheWeekExpressionBuilder RunEveryXMonths(int interval)
        {
            this.monthField.RunEveryXYears(interval);
            return this.dayOfTheWeekExpressionBuilder;
        }

        public DayOfTheWeekExpressionBuilder RunInMonthsIncrements(int startingValue, int increment)
        {
            this.monthField.RunInIncrements(startingValue, increment);
            return this.dayOfTheWeekExpressionBuilder;
        }

        public DayOfTheWeekExpressionBuilder SpecificMonths(params int[] seconds)
        {
            this.monthField.SpecificValues(seconds);
            return this.dayOfTheWeekExpressionBuilder;
        }
    }
}
