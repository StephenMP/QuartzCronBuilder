using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class MonthExpressionBuilder : ExpressionBuilder<MonthField, DayOfTheWeekExpressionBuilder>
    {
        public MonthExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.field = new MonthField();
            this.expressionBuilder = new DayOfTheWeekExpressionBuilder(cronExpressionBuilder);
        }

        public DayOfTheWeekExpressionBuilder AllMonths()
        {
            return base.All();
        }

        public DayOfTheWeekExpressionBuilder RangeOfMonths(int from, int to)
        {
            return base.RangeOf(from, to);
        }

        public DayOfTheWeekExpressionBuilder RunEveryXMonths(int interval)
        {
            return base.RunEveryXInterval(interval);
        }

        public DayOfTheWeekExpressionBuilder RunInMonthsIncrements(int startingValue, int increment)
        {
            return base.RunInIncrements(startingValue, increment);
        }

        public DayOfTheWeekExpressionBuilder SpecificMonths(params int[] values)
        {
            return base.Specific(values);
        }
    }
}
