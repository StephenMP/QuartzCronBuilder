using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class DayOfTheMonthExpressionBuilder
    {
        private readonly DayOfMonthField dayOfMonthField;
        private readonly MonthExpressionBuilder monthExpressionBuilder;

        public DayOfTheMonthExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.dayOfMonthField = new DayOfMonthField();
            this.monthExpressionBuilder = new MonthExpressionBuilder(cronExpressionBuilder);
        }

        public MonthExpressionBuilder AllDaysOfTheMonth()
        {
            this.dayOfMonthField.AllValues();
            return this.monthExpressionBuilder;
        }

        public string BuildCronExpression() => $"{this.dayOfMonthField.CronExpression} {this.monthExpressionBuilder.BuildCronExpression()}";

        public MonthExpressionBuilder LastDayOfTheMonth()
        {
            this.dayOfMonthField.Last();
            return this.monthExpressionBuilder;
        }

        public MonthExpressionBuilder NoSpecificDaysOfTheMonth()
        {
            this.dayOfMonthField.NoSpecificValue();
            return this.monthExpressionBuilder;
        }

        public MonthExpressionBuilder RangeOfDaysOfTheMonth(int from, int to)
        {
            this.dayOfMonthField.RangeOfValues(from, to);
            return this.monthExpressionBuilder;
        }

        public MonthExpressionBuilder RunInDaysOfTheMonthIncrements(int startingValue, int increment)
        {
            this.dayOfMonthField.RunInIncrements(startingValue, increment);
            return this.monthExpressionBuilder;
        }

        public MonthExpressionBuilder SpecificDaysOfTheMonth(params int[] seconds)
        {
            this.dayOfMonthField.SpecificValues(seconds);
            return this.monthExpressionBuilder;
        }

        public MonthExpressionBuilder WeekdaysOnly()
        {
            this.dayOfMonthField.WeekdaysOnly();
            return this.monthExpressionBuilder;
        }
    }
}
