using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class DayOfTheMonthExpressionBuilder : ExpressionBuilder<DayOfMonthField, MonthExpressionBuilder>
    {
        public DayOfTheMonthExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.field = new DayOfMonthField();
            this.expressionBuilder = new MonthExpressionBuilder(cronExpressionBuilder);
        }

        public MonthExpressionBuilder AllDaysOfTheMonth()
        {
            return base.All();
        }

        public MonthExpressionBuilder LastDayOfTheMonth()
        {
            this.field.Last();
            return this.expressionBuilder;
        }

        public MonthExpressionBuilder NoSpecificDaysOfTheMonth()
        {
            this.field.NoSpecificValue();
            return this.expressionBuilder;
        }

        public MonthExpressionBuilder RangeOfDaysOfTheMonth(int from, int to)
        {
            return base.RangeOf(from, to);
        }

        public MonthExpressionBuilder RunInDaysOfTheMonthIncrements(int startingValue, int increment)
        {
            return base.RunInIncrements(startingValue, increment);
        }

        public MonthExpressionBuilder SpecificDaysOfTheMonth(params int[] values)
        {
            return base.Specific(values);
        }

        public MonthExpressionBuilder WeekdaysOnly()
        {
            this.field.WeekdaysOnly();
            return this.expressionBuilder;
        }
    }
}
