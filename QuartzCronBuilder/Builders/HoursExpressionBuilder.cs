using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class HoursExpressionBuilder
    {
        private readonly DayOfTheMonthExpressionBuilder dayOfTheMonthExpressionBuilder;
        private readonly HoursField hoursField;

        public HoursExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.hoursField = new HoursField();
            this.dayOfTheMonthExpressionBuilder = new DayOfTheMonthExpressionBuilder(cronExpressionBuilder);
        }

        public DayOfTheMonthExpressionBuilder AllHours()
        {
            this.hoursField.AllValues();
            return this.dayOfTheMonthExpressionBuilder;
        }

        public string BuildCronExpression() => $"{this.hoursField.CronExpression} {this.dayOfTheMonthExpressionBuilder.BuildCronExpression()}";

        public DayOfTheMonthExpressionBuilder RangeOfHours(int from, int to)
        {
            this.hoursField.RangeOfValues(from, to);
            return this.dayOfTheMonthExpressionBuilder;
        }

        public DayOfTheMonthExpressionBuilder RunEveryXHours(int interval)
        {
            this.hoursField.RunEveryXYears(interval);
            return this.dayOfTheMonthExpressionBuilder;
        }

        public DayOfTheMonthExpressionBuilder RunInHourIncrements(int startingValue, int increment)
        {
            this.hoursField.RunInIncrements(startingValue, increment);
            return this.dayOfTheMonthExpressionBuilder;
        }

        public DayOfTheMonthExpressionBuilder SpecificHours(params int[] seconds)
        {
            this.hoursField.SpecificValues(seconds);
            return this.dayOfTheMonthExpressionBuilder;
        }
    }
}
