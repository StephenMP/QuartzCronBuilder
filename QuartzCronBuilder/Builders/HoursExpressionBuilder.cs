using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class HoursExpressionBuilder : ExpressionBuilder<HoursField, DayOfTheMonthExpressionBuilder>
    {
        public HoursExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.field = new HoursField();
            this.expressionBuilder = new DayOfTheMonthExpressionBuilder(cronExpressionBuilder);
        }

        public DayOfTheMonthExpressionBuilder AllHours()
        {
            return base.All();
        }

        public DayOfTheMonthExpressionBuilder RangeOfHours(int from, int to)
        {
            return base.RangeOf(from, to);
        }

        public DayOfTheMonthExpressionBuilder RunEveryXHours(int interval)
        {
            return base.RunEveryXInterval(interval);
        }

        public DayOfTheMonthExpressionBuilder RunInHourIncrements(int startingValue, int increment)
        {
            return base.RunInIncrements(startingValue, increment);
        }

        public DayOfTheMonthExpressionBuilder SpecificHours(params int[] values)
        {
            return base.Specific(values);
        }
    }
}
