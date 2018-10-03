using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class YearExpressionBuilder : ExpressionBuilder<YearField, CronExpressionBuilder>
    {
        public YearExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.field = new YearField();
            this.expressionBuilder = cronExpressionBuilder;
        }

        public CronExpressionBuilder AllYears()
        {
            return base.All();
        }

        public override string BuildCronExpression() => this.field.CronExpression;

        public CronExpressionBuilder RangeOfYears(int from, int to)
        {
            return base.RangeOf(from, to);
        }

        public CronExpressionBuilder RunEveryXYears(int interval)
        {
            return base.RunEveryXInterval(interval);
        }

        public CronExpressionBuilder RunInYearsIncrements(int startingValue, int increment)
        {
            return base.RunInIncrements(startingValue, increment);
        }

        public CronExpressionBuilder SpecificYears(params int[] values)
        {
            return base.Specific(values);
        }
    }
}
