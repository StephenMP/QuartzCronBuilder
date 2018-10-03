using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class MinutesExpressionBuilder : ExpressionBuilder<MinutesField, HoursExpressionBuilder>
    {
        public MinutesExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.field = new MinutesField();
            this.expressionBuilder = new HoursExpressionBuilder(cronExpressionBuilder);
        }

        public HoursExpressionBuilder AllMinutes()
        {
            return base.All();
        }

        public HoursExpressionBuilder RangeOfMinutes(int from, int to)
        {
            return base.RangeOf(from, to);
        }

        public HoursExpressionBuilder RunEveryXMinutes(int interval)
        {
            return base.RunEveryXInterval(interval);
        }

        public HoursExpressionBuilder RunInMinuteIncrements(int startingValue, int increment)
        {
            return base.RunInIncrements(startingValue, increment);
        }

        public HoursExpressionBuilder SpecificMinutes(params int[] values)
        {
            return base.Specific(values);
        }
    }
}
